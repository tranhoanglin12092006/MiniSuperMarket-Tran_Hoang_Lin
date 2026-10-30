/*
 * Ho ten sinh vien: Tran Hoang Lin
 * Ma sinh vien: 2124110134
 * Ngay tao: 22/10/2026
 * Mo ta: Controller Báo cáo - Kết hợp EF Core và ADO.NET thực thi Stored Procedure (Buổi 5 - Tiết 3)
 */
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;
using System.Data;
using System.Data.Common;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;
        private readonly IConfiguration _configuration;

        public ReportsController(SupermarketDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection") 
                ?? "Server=127.0.0.1;Port=3306;Database=tranhoanglin_minisupermarketdb;User=root;Password=;SslMode=None;CharSet=utf8mb4;";
        }

        // =========================================================================
        // BUỔI 5 - TIẾT 3: BÁO CÁO DOANH THU THEO THU NGÂN BẰNG STORED PROCEDURE
        // =========================================================================
        // GET: api/reports/revenue-by-cashier
        [AllowAnonymous]
        [HttpGet("revenue-by-cashier")]
        public IActionResult GetRevenueByCashier()
        {
            var reportList = new List<CashierRevenueDto>();
            string connectionString = GetConnectionString();

            using (DbConnection connection = AdoDbHelper.CreateConnection(connectionString))
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "sp_GetRevenueByCashier";
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var item = new CashierRevenueDto
                                {
                                    CashierUsername = reader["CashierUsername"].ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"]),
                                    TotalPointsAwarded = reader["TotalPointsAwarded"] != DBNull.Value
                                        ? Convert.ToInt32(reader["TotalPointsAwarded"])
                                        : 0
                                };

                                reportList.Add(item);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi thực thi Stored Procedure: " + ex.Message
                        });
                    }
                }
            }

            return Ok(new
            {
                success = true,
                generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.1: STORED PROCEDURE BÁO CÁO DOANH THU THEO KHOẢNG NGÀY (CÓ THAM SỐ)
        // =========================================================================
        // GET: api/reports/revenue-by-date-range?fromDate=2026-08-01&toDate=2026-08-31
        [AllowAnonymous]
        [HttpGet("revenue-by-date-range")]
        public IActionResult GetRevenueByDateRange([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            var fDate = fromDate ?? DateTime.Today.AddMonths(-3);
            var tDate = toDate ?? DateTime.Today.AddDays(1);

            var reportList = new List<DateRangeRevenueDto>();
            string connectionString = GetConnectionString();

            using (DbConnection connection = AdoDbHelper.CreateConnection(connectionString))
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "sp_GetRevenueByDateRange";
                    command.CommandType = CommandType.StoredProcedure;
                    
                    bool isMySql = AdoDbHelper.IsMySql(connectionString);
                    AdoDbHelper.AddParam(command, isMySql ? "p_FromDate" : "@FromDate", fDate);
                    AdoDbHelper.AddParam(command, isMySql ? "p_ToDate" : "@ToDate", tDate);

                    try
                    {
                        connection.Open();
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                reportList.Add(new DateRangeRevenueDto
                                {
                                    CashierUsername = reader["CashierUsername"].ToString() ?? string.Empty,
                                    TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                    TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi thực thi Stored Procedure: " + ex.Message
                        });
                    }
                }
            }

            return Ok(new
            {
                success = true,
                fromDate = fDate.ToString("yyyy-MM-dd HH:mm:ss"),
                toDate = tDate.ToString("yyyy-MM-dd HH:mm:ss"),
                totalCashiers = reportList.Count,
                grandTotalRevenue = reportList.Sum(x => x.TotalRevenue),
                data = reportList
            });
        }

        // =========================================================================
        // BÀI TẬP 3.2: STORED PROCEDURE TOP 5 SẢN PHẨM BÁN CHẠY NHẤT
        // =========================================================================
        // GET: api/reports/top-selling-products
        [AllowAnonymous]
        [HttpGet("top-selling-products")]
        public IActionResult GetTop5SellingProducts()
        {
            var topList = new List<TopSellingProductDto>();
            string connectionString = GetConnectionString();

            using (DbConnection connection = AdoDbHelper.CreateConnection(connectionString))
            {
                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = "sp_GetTop5SellingProducts";
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                topList.Add(new TopSellingProductDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"].ToString() ?? string.Empty,
                                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                    TotalSold = Convert.ToInt32(reader["TotalSold"]),
                                    TotalSalesRevenue = Convert.ToDecimal(reader["TotalSalesRevenue"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, new
                        {
                            success = false,
                            message = "Lỗi thực thi Stored Procedure: " + ex.Message
                        });
                    }
                }
            }

            return Ok(new
            {
                success = true,
                generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                data = topList
            });
        }

        // =========================================================================
        // CÁC ENDPOINT EF CORE CŨ (TƯƠNG THÍCH FORMQUICKREPORT TRÊN WINFORMS)
        // =========================================================================
        // GET: api/reports/daily?date=2026-10-08
        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyReport([FromQuery] DateTime date)
        {
            try
            {
                var startDate = date.Date;
                var endDate = startDate.AddDays(1);

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

        // GET: api/reports/orders?date=2026-10-01&all=false
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrdersByDate(
            [FromQuery] DateTime? date, 
            [FromQuery] bool all = false,
            [FromQuery] DateTime? fromDate = null,
            [FromQuery] DateTime? toDate = null)
        {
            try
            {
                var query = _context.Orders
                    .AsNoTracking()
                    .Include(o => o.Customer)
                    .AsQueryable();

                if (fromDate.HasValue && toDate.HasValue)
                {
                    var startDate = fromDate.Value.Date;
                    var endDate = toDate.Value.Date.AddDays(1);
                    query = query.Where(o => o.CreatedDate >= startDate && o.CreatedDate < endDate);
                }
                else if (!all && date.HasValue)
                {
                    var startDate = date.Value.Date;
                    var endDate = startDate.AddDays(1);
                    query = query.Where(o => o.CreatedDate >= startDate && o.CreatedDate < endDate);
                }

                var orders = await query
                    .OrderByDescending(o => o.CreatedDate)
                    .Select(o => new
                    {
                        o.OrderId,
                        o.OrderCode,
                        Time = o.CreatedDate.ToString("dd/MM/yyyy HH:mm:ss"),
                        CustomerName = (o.Customer != null && !string.IsNullOrWhiteSpace(o.Customer.CustomerName) && o.Customer.CustomerName != "Khách lẻ")
                            ? o.Customer.CustomerName
                            : "Khách hàng vãng lai",
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

        // GET: api/reports/orders/{orderId}/details (Xem chi tiết từng món hàng trong hóa đơn)
        [HttpGet("orders/{orderId}/details")]
        public async Task<IActionResult> GetOrderDetails(int orderId)
        {
            try
            {
                var details = await _context.OrderDetails
                    .AsNoTracking()
                    .Where(od => od.OrderId == orderId)
                    .Include(od => od.Product)
                    .Select(od => new
                    {
                        od.OrderDetailId,
                        od.OrderId,
                        od.ProductId,
                        ProductName = od.Product != null ? od.Product.ProductName : $"Sản phẩm #{od.ProductId}",
                        Barcode = od.Product != null ? od.Product.Barcode : "",
                        od.Quantity,
                        od.UnitPrice,
                        od.LineTotal
                    })
                    .ToListAsync();

                return Ok(details);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi lấy chi tiết hóa đơn: " + ex.Message });
            }
        }

        // =========================================================================
        // ITEM 44: DASHBOARD THẺ CHỈ SỐ TỔNG QUAN (KPI SUMMARY CARDS)
        // Nghiệp vụ: Doanh thu hôm nay (VNĐ), Tổng số hóa đơn đã xuất,
        //            Số lượng khách hàng mới đăng ký, Số mặt hàng sắp hết hàng (tồn kho <= 10)
        // Kỹ thuật: Viết 1 Action API GET api/reports/dashboard-summary dùng LINQ Count(), Sum()
        // =========================================================================
        [AllowAnonymous]
        [HttpGet("dashboard-summary")]
        public async Task<IActionResult> GetDashboardSummary()
        {
            try
            {
                var today = DateTime.Today;
                var tomorrow = today.AddDays(1);

                // 1. Doanh thu hôm nay (VNĐ)
                var todayRevenue = await _context.Orders
                    .AsNoTracking()
                    .Where(o => o.CreatedDate >= today && o.CreatedDate < tomorrow)
                    .SumAsync(o => (decimal?)o.FinalAmount) ?? 0m;

                // 2. Tổng số hóa đơn đã xuất
                var totalOrders = await _context.Orders.AsNoTracking().CountAsync();
                var todayOrders = await _context.Orders
                    .AsNoTracking()
                    .CountAsync(o => o.CreatedDate >= today && o.CreatedDate < tomorrow);

                // 3. Số lượng khách hàng mới đăng ký
                var newCustomers = await _context.Customers.AsNoTracking().CountAsync();

                // 4. Số mặt hàng sắp hết hàng (tồn kho <= 10)
                var lowStockCount = await _context.Products
                    .AsNoTracking()
                    .CountAsync(p => p.StockQuantity <= 10);

                return Ok(new
                {
                    success = true,
                    todayRevenue = todayRevenue,
                    totalOrders = totalOrders,
                    todayOrders = todayOrders,
                    newCustomers = newCustomers,
                    lowStockCount = lowStockCount
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Lỗi tính toán Dashboard KPI: " + ex.Message });
            }
        }

        // =========================================================================
        // ITEM 45: BIỂU ĐỒ CỘT DOANH THU THEO KHOẢNG NGÀY (BAR/COLUMN CHART)
        // Kỹ thuật: Phía API viết query gom nhóm GROUP BY CAST(CreatedDate AS DATE)
        // =========================================================================
        [AllowAnonymous]
        [HttpGet("daily-revenue-chart")]
        public async Task<IActionResult> GetDailyRevenueChart([FromQuery] DateTime? fromDate, [FromQuery] DateTime? toDate)
        {
            try
            {
                var fDate = (fromDate ?? DateTime.Today.AddDays(-7)).Date;
                var tDate = (toDate ?? DateTime.Today).Date.AddDays(1).AddTicks(-1);

                var chartData = new List<object>();
                string connectionString = GetConnectionString();

                try
                {
                    using (DbConnection connection = AdoDbHelper.CreateConnection(connectionString))
                    {
                        using (DbCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "sp_GetDailyRevenueByDateRange";
                            command.CommandType = CommandType.StoredProcedure;
                            bool isMySql = AdoDbHelper.IsMySql(connectionString);
                            AdoDbHelper.AddParam(command, isMySql ? "p_FromDate" : "@FromDate", fDate);
                            AdoDbHelper.AddParam(command, isMySql ? "p_ToDate" : "@ToDate", tDate);

                            connection.Open();
                            using (DbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    chartData.Add(new
                                    {
                                        OrderDate = Convert.ToDateTime(reader["OrderDate"]).ToString("dd/MM/yyyy"),
                                        DateKey = Convert.ToDateTime(reader["OrderDate"]).ToString("yyyy-MM-dd"),
                                        TotalOrders = Convert.ToInt32(reader["TotalOrders"]),
                                        TotalRevenue = Convert.ToDecimal(reader["TotalRevenue"])
                                    });
                                }
                            }
                        }
                    }
                }
                catch
                {
                    // Fallback LINQ gom nhóm theo ngày
                    var linqResult = await _context.Orders
                        .AsNoTracking()
                        .Where(o => o.CreatedDate >= fDate && o.CreatedDate <= tDate)
                        .GroupBy(o => o.CreatedDate.Date)
                        .Select(g => new
                        {
                            Date = g.Key,
                            TotalOrders = g.Count(),
                            TotalRevenue = g.Sum(x => x.FinalAmount)
                        })
                        .OrderBy(x => x.Date)
                        .ToListAsync();

                    chartData = linqResult.Select(x => (object)new
                    {
                        OrderDate = x.Date.ToString("dd/MM/yyyy"),
                        DateKey = x.Date.ToString("yyyy-MM-dd"),
                        TotalOrders = x.TotalOrders,
                        TotalRevenue = x.TotalRevenue
                    }).ToList();
                }

                return Ok(new
                {
                    success = true,
                    fromDate = fDate.ToString("yyyy-MM-dd"),
                    toDate = tDate.ToString("yyyy-MM-dd"),
                    data = chartData
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Lỗi lấy dữ liệu biểu đồ doanh thu: " + ex.Message });
            }
        }

        // =========================================================================
        // ITEM 46: THỐNG KÊ TOP 5 SẢN PHẨM BÁN CHẠY NHẤT (BEST-SELLERS)
        // Kỹ thuật: LINQ GroupBy(od => od.ProductId) -> OrderByDescending(Sum Quantity) -> Take(5)
        // =========================================================================
        [AllowAnonymous]
        [HttpGet("top-selling-products-linq")]
        public async Task<IActionResult> GetTop5SellingProductsLinq()
        {
            try
            {
                var topGroup = await _context.OrderDetails
                    .AsNoTracking()
                    .GroupBy(od => od.ProductId)
                    .Select(g => new
                    {
                        ProductId = g.Key,
                        TotalSold = g.Sum(od => od.Quantity),
                        TotalSalesRevenue = g.Sum(od => od.LineTotal)
                    })
                    .OrderByDescending(x => x.TotalSold)
                    .Take(5)
                    .ToListAsync();

                var productIds = topGroup.Select(x => x.ProductId).ToList();
                var products = await _context.Products
                    .AsNoTracking()
                    .Where(p => productIds.Contains(p.ProductId))
                    .ToDictionaryAsync(p => p.ProductId);

                var result = topGroup.Select(x => new
                {
                    ProductId = x.ProductId,
                    Barcode = products.ContainsKey(x.ProductId) ? products[x.ProductId].Barcode : "",
                    ProductName = products.ContainsKey(x.ProductId) ? products[x.ProductId].ProductName : $"Sản phẩm #{x.ProductId}",
                    TotalSold = x.TotalSold,
                    TotalSalesRevenue = x.TotalSalesRevenue
                }).ToList();

                return Ok(new
                {
                    success = true,
                    generatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Lỗi LINQ Top 5 sản phẩm: " + ex.Message });
            }
        }
    }
}