using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public OrdersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // POST: api/orders/checkout
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutRequestDto request)
        {
            try
            {
                if (request == null || request.Items == null || !request.Items.Any())
                {
                    return BadRequest(new { message = "Giỏ hàng không có sản phẩm nào!" });
                }

                // 1. Kiểm tra tồn kho và tính tổng tiền
                decimal totalAmount = 0;
                var updatedProducts = new List<Product>();

                foreach (var item in request.Items)
                {
                    var product = await _context.Products.FindAsync(item.ProductId);
                    if (product == null)
                    {
                        return NotFound(new { message = $"Sản phẩm ID {item.ProductId} không tồn tại!" });
                    }

                    if (product.StockQuantity < item.Quantity)
                    {
                        return BadRequest(new { message = $"Sản phẩm '{product.ProductName}' không đủ tồn kho (còn {product.StockQuantity}, yêu cầu {item.Quantity})!" });
                    }

                    // Trừ kho
                    product.StockQuantity -= item.Quantity;
                    totalAmount += item.Quantity * item.UnitPrice;
                    updatedProducts.Add(product);
                }

                // 2. Tích điểm thưởng cho khách hàng (nếu có số điện thoại)
                Customer? customer = null;
                if (!string.IsNullOrWhiteSpace(request.CustomerPhone))
                {
                    customer = await _context.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == request.CustomerPhone.Trim());
                    if (customer != null)
                    {
                        // Quy tắc: 10,000 VND = 1 điểm tích lũy
                        int pointsEarned = (int)(totalAmount / 10000m);
                        customer.RewardPoints += pointsEarned;

                        // Tự động nâng hạng theo điểm
                        if (customer.RewardPoints >= 500)
                            customer.MembershipRank = "Kim Cương";
                        else if (customer.RewardPoints >= 200)
                            customer.MembershipRank = "Vàng";
                        else if (customer.RewardPoints >= 50)
                            customer.MembershipRank = "Bạc";
                    }
                }

                // Lưu các thay đổi xuống database
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Thanh toán thành công!",
                    totalAmount = totalAmount,
                    itemCount = request.Items.Count,
                    customerName = customer != null ? customer.CustomerName : "Khách vãng lai",
                    rewardPoints = customer?.RewardPoints ?? 0
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi xử lý thanh toán: " + ex.Message });
            }
        }
    }

    public class CheckoutRequestDto
    {
        public string CashierUsername { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public List<CheckoutItemDto> Items { get; set; } = new();
    }

    public class CheckoutItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
