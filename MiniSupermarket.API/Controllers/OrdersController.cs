using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Cashier")] // Thu ngân và Admin có quyền lập hóa đơn bán hàng
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
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (request == null || request.Items == null || !request.Items.Any())
                {
                    return BadRequest(new { message = "Giỏ hàng không có sản phẩm nào!" });
                }

                // 1. Kiểm tra tồn kho và tính tổng tiền
                decimal grossAmount = 0;
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
                    grossAmount += item.Quantity * item.UnitPrice;
                    updatedProducts.Add(product);
                }

                // 2. Tích điểm thưởng cho khách hàng (nếu có số điện thoại)
                Customer? customer = null;
                int customerId;

                if (!string.IsNullOrWhiteSpace(request.CustomerPhone))
                {
                    customer = await _context.Customers.FirstOrDefaultAsync(c => c.PhoneNumber == request.CustomerPhone.Trim());
                }

                // =====================================================================
                // ĐỔI ĐIỂM THƯỞNG TRỪ TIỀN (Item 47: Loyalty Points Redemption)
                // Cập nhật đồng thời trừ điểm trong bảng Customers và trừ tiền FinalAmount
                // trong cùng một SqlTransaction / DbTransaction
                // =====================================================================
                decimal discountFromPoints = 0;
                int pointsToRedeem = request.PointsToRedeem;

                if (customer != null)
                {
                    customerId = customer.CustomerId;

                    if (pointsToRedeem > 0)
                    {
                        if (customer.RewardPoints < pointsToRedeem)
                        {
                            return BadRequest(new { message = $"Khách hàng không đủ điểm tích lũy! (Hiện có: {customer.RewardPoints}, yêu cầu: {pointsToRedeem})" });
                        }

                        // 1 điểm = 1.000 VNĐ
                        discountFromPoints = pointsToRedeem * 1000m;
                        if (discountFromPoints > grossAmount)
                        {
                            discountFromPoints = grossAmount;
                        }

                        // Trừ điểm thưởng của khách trong transaction
                        customer.RewardPoints -= pointsToRedeem;
                    }

                    // Tính điểm tích lũy mới sau khi trừ tiền thanh toán
                    decimal payableAfterDiscount = Math.Max(0, grossAmount - discountFromPoints);
                    int earnedPoints = (int)(payableAfterDiscount / 10000m);
                    customer.RewardPoints += earnedPoints;

                    // Tự động nâng hạng theo điểm
                    if (customer.RewardPoints >= 500)
                        customer.MembershipRank = "Kim Cương";
                    else if (customer.RewardPoints >= 200)
                        customer.MembershipRank = "Vàng";
                    else if (customer.RewardPoints >= 50)
                        customer.MembershipRank = "Bạc";
                }
                else
                {
                    // Khách hàng không nhập số điện thoại hoặc không có tài khoản -> Ghi nhận là "Khách hàng vãng lai"
                    var guestCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerName == "Khách hàng vãng lai");
                    if (guestCustomer == null)
                    {
                        guestCustomer = new Customer
                        {
                            CustomerName = "Khách hàng vãng lai",
                            PhoneNumber = "0000000000",
                            MembershipRank = "Chuẩn",
                            RewardPoints = 0,
                            Address = "Khách mua lẻ trực tiếp tại quầy"
                        };
                        _context.Customers.Add(guestCustomer);
                        await _context.SaveChangesAsync();
                    }
                    customerId = guestCustomer.CustomerId;
                }

                decimal finalAmount = Math.Max(0, grossAmount - discountFromPoints);
                int rewardPointsForOrder = (int)(finalAmount / 10000m);

                // 3. Tạo bản ghi Hóa đơn (Order)
                string cashierUser = string.IsNullOrWhiteSpace(request.CashierUsername) ? "cashier01" : request.CashierUsername.Trim();
                string orderCode = $"HD{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString()[..6].ToUpper()}";
                int totalItemsCount = request.Items.Sum(x => x.Quantity);

                var order = new Order
                {
                    OrderCode = orderCode,
                    CreatedDate = DateTime.Now,
                    CustomerId = customerId,
                    CashierUsername = cashierUser,
                    TotalItems = totalItemsCount,
                    FinalAmount = finalAmount,
                    RewardPoints = rewardPointsForOrder
                };

                _context.Orders.Add(order);
                await _context.SaveChangesAsync(); // Lưu để sinh OrderId

                // 4. Tạo các bản ghi Chi tiết hóa đơn (OrderDetails)
                foreach (var item in request.Items)
                {
                    var orderDetail = new OrderDetail
                    {
                        OrderId = order.OrderId,
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice,
                        LineTotal = item.Quantity * item.UnitPrice
                    };
                    _context.OrderDetails.Add(orderDetail);
                }

                // Lưu các thay đổi chi tiết và trừ kho xuống database
                await _context.SaveChangesAsync();

                // Xác nhận giao dịch trong Transaction
                await transaction.CommitAsync();

                return Ok(new
                {
                    message = "Thanh toán thành công!",
                    orderCode = order.OrderCode,
                    orderId = order.OrderId,
                    grossAmount = grossAmount,
                    discountFromPoints = discountFromPoints,
                    pointsRedeemed = pointsToRedeem,
                    totalAmount = finalAmount,
                    finalAmount = finalAmount,
                    itemCount = request.Items.Count,
                    customerName = customer != null ? customer.CustomerName : "Khách vãng lai",
                    rewardPoints = customer?.RewardPoints ?? 0
                });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { message = "Lỗi khi xử lý thanh toán: " + ex.Message });
            }
        }
    }
}