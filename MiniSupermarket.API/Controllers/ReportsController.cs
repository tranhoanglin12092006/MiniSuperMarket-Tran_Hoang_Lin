using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MiniSupermarket.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly SupermarketDbContext _context; // Đảm bảo tên DbContext đúng với dự án của bạn

        public ReportsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/reports/daily?date=2026-10-08
        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyReport([FromQuery] DateTime date)
        {
            try
            {
                // Khoảng thời gian từ 00:00:00 đến 23:59:59 của ngày được chọn
                var startDate = date.Date;
                var endDate = startDate.AddDays(1);

                // Lọc danh sách hóa đơn trong ngày
                var ordersInDay = await _context.Orders
                    .AsNoTracking()
                    .Where(o => o.CreatedDate >= startDate && o.CreatedDate < endDate)
                    .ToListAsync();

                int totalOrders = ordersInDay.Count;
                decimal totalRevenue = ordersInDay.Sum(o => o.FinalAmount);

                string bestSellerProduct = "Chưa có dữ liệu";

                if (totalOrders > 0)
                {
                    var orderIds = ordersInDay.Select(o => o.OrderId).ToList();

                    // Tìm mặt hàng có tổng số lượng bán nhiều nhất trong ngày
                    var topProductGroup = await _context.OrderDetails
                        .AsNoTracking()
                        .Where(od => orderIds.Contains(od.OrderId))
                        .GroupBy(od => od.ProductId)
                        .Select(g => new
                        {
                            ProductId = g.Key,
                            TotalQuantity = g.Sum(x => x.Quantity)
                        })
                        .OrderByDescending(x => x.TotalQuantity)
                        .FirstOrDefaultAsync();

                    if (topProductGroup != null)
                    {
                        var product = await _context.Products
                            .AsNoTracking()
                            .FirstOrDefaultAsync(p => p.ProductId == topProductGroup.ProductId);

                        if (product != null)
                        {
                            bestSellerProduct = $"{product.ProductName} ({topProductGroup.TotalQuantity:N0} cái)";
                        }
                    }
                }
                else
                {
                    // Nếu ngày chọn không có đơn hàng nào, tìm mặt hàng bán chạy nhất toàn thời gian để hiển thị tham khảo
                    var allTimeTopProduct = await _context.OrderDetails
                        .AsNoTracking()
                        .GroupBy(od => od.ProductId)
                        .Select(g => new
                        {
                            ProductId = g.Key,
                            TotalQuantity = g.Sum(x => x.Quantity)
                        })
                        .OrderByDescending(x => x.TotalQuantity)
                        .FirstOrDefaultAsync();

                    if (allTimeTopProduct != null)
                    {
                        var product = await _context.Products
                            .AsNoTracking()
                            .FirstOrDefaultAsync(p => p.ProductId == allTimeTopProduct.ProductId);

                        if (product != null)
                        {
                            bestSellerProduct = $"{product.ProductName} (Tất cả: {allTimeTopProduct.TotalQuantity:N0})";
                        }
                    }
                }

                return Ok(new
                {
                    TotalOrders = totalOrders,
                    TotalRevenue = totalRevenue,
                    BestSellerProduct = bestSellerProduct
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi server: " + ex.Message });
            }
        }

        // GET: api/reports/orders?date=2026-10-01
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrdersByDate([FromQuery] DateTime date)
        {
            try
            {
                var startDate = date.Date;
                var endDate = startDate.AddDays(1);

                var orders = await _context.Orders
                    .AsNoTracking()
                    .Where(o => o.CreatedDate >= startDate && o.CreatedDate < endDate)
                    .Include(o => o.Customer)
                    .OrderByDescending(o => o.CreatedDate)
                    .Select(o => new
                    {
                        o.OrderId,
                        o.OrderCode,
                        Time = o.CreatedDate.ToString("HH:mm:ss"),
                        CustomerName = o.Customer != null ? o.Customer.CustomerName : "Khách lẻ",
                        Cashier = o.CashierUsername,
                        TotalItems = o.TotalItems,
                        FinalAmount = o.FinalAmount,
                        RewardPoints = o.RewardPoints
                    })
                    .ToListAsync();

                return Ok(orders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi lấy danh sách hóa đơn: " + ex.Message });
            }
        }
    }
}