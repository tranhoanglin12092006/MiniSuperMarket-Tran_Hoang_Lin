/*
 * Ho ten sinh vien: Tran Hoang Lin
 * Ma sinh vien: 2124110134
 * Ngay tao: 22/10/2026
 * Mo ta: Controller ADO.NET thuan - Ho tro ca MySQL va SQL Server qua ADO.NET (Buoi 5 - Tiet 2)
 */
using Microsoft.AspNetCore.Mvc;
using MiniSupermarket.API.Data;
using System.Data;
using System.Data.Common;

namespace MiniSupermarket.API.Controllers
{
    public class ProductLookupDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }

    public class CategoryProductSummaryDto
    {
        public int CategoryId { get; set; }
        public int TotalProducts { get; set; }
    }

    [Route("api/ado-products")]
    [ApiController]
    public class AdoProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AdoProductController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("DefaultConnection") 
                ?? "Server=127.0.0.1;Port=3306;Database=tranhoanglin_minisupermarketdb;User=root;Password=;SslMode=None;CharSet=utf8mb4;";
        }

        // =========================================================================
        // THAO TÁC 1: TRA CỨU THEO MÃ VẠCH (CONNECTED MODE - DATAREADER)
        // =========================================================================
        // GET: api/ado-products/barcode/893456789001
        [HttpGet("barcode/{barcode}")]
        public IActionResult GetProductByBarcode(string barcode)
        {
            if (string.IsNullOrWhiteSpace(barcode))
            {
                return BadRequest(new { message = "Mã vạch không được để trống!" });
            }

            string connectionString = GetConnectionString();

            using (DbConnection connection = AdoDbHelper.CreateConnection(connectionString))
            {
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                 FROM products 
                                 WHERE Barcode = @Barcode";

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    AdoDbHelper.AddParam(command, "@Barcode", barcode.Trim());

                    try
                    {
                        connection.Open();

                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var productDto = new ProductLookupDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"].ToString() ?? string.Empty,
                                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                                };

                                return Ok(productDto);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, new { message = "Lỗi truy vấn: " + ex.Message });
                    }
                }
            }

            return NotFound(new { message = $"Không tìm thấy sản phẩm có mã vạch: {barcode}" });
        }

        // =========================================================================
        // THAO TÁC 2: TẢI DANH SÁCH LƯU ĐỆM (DISCONNECTED MODE - DATATABLE & ADAPTER)
        // =========================================================================
        // GET: api/ado-products/disconnected-cache
        [HttpGet("disconnected-cache")]
        public IActionResult GetProductsDisconnected()
        {
            string connectionString = GetConnectionString();
            DataTable productTable = new DataTable("CachedProducts");

            using (DbConnection connection = AdoDbHelper.CreateConnection(connectionString))
            {
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                 FROM products 
                                 ORDER BY ProductId ASC";

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (DbDataAdapter adapter = AdoDbHelper.CreateDataAdapter(command, connectionString))
                    {
                        adapter.Fill(productTable);
                    }
                }
            }

            var resultList = new List<ProductLookupDto>();
            foreach (DataRow row in productTable.Rows)
            {
                resultList.Add(new ProductLookupDto
                {
                    ProductId = Convert.ToInt32(row["ProductId"]),
                    Barcode = row["Barcode"].ToString() ?? string.Empty,
                    ProductName = row["ProductName"].ToString() ?? string.Empty,
                    Price = Convert.ToDecimal(row["Price"]),
                    StockQuantity = Convert.ToInt32(row["StockQuantity"])
                });
            }

            return Ok(new
            {
                totalLoaded = productTable.Rows.Count,
                cachedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                data = resultList
            });
        }

        // =========================================================================
        // BÀI TẬP 2.1: TRA CỨU THEO KHOẢNG TỒN KHO
        // =========================================================================
        // GET: api/ado-products/filter-stock?minStock=50
        [HttpGet("filter-stock")]
        public IActionResult GetProductsByMinStock([FromQuery] int minStock = 50)
        {
            string connectionString = GetConnectionString();
            var resultList = new List<ProductLookupDto>();

            using (DbConnection connection = AdoDbHelper.CreateConnection(connectionString))
            {
                string query = @"SELECT ProductId, Barcode, ProductName, Price, StockQuantity 
                                 FROM products 
                                 WHERE StockQuantity <= @MinStock 
                                 ORDER BY StockQuantity ASC";

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    AdoDbHelper.AddParam(command, "@MinStock", minStock);

                    try
                    {
                        connection.Open();
                        using (DbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                resultList.Add(new ProductLookupDto
                                {
                                    ProductId = Convert.ToInt32(reader["ProductId"]),
                                    Barcode = reader["Barcode"].ToString() ?? string.Empty,
                                    ProductName = reader["ProductName"].ToString() ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    StockQuantity = Convert.ToInt32(reader["StockQuantity"])
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, new { message = "Lỗi truy vấn: " + ex.Message });
                    }
                }
            }

            return Ok(new
            {
                threshold = minStock,
                totalFound = resultList.Count,
                data = resultList
            });
        }

        // =========================================================================
        // BÀI TẬP 2.2: ĐẾM SỐ LƯỢNG SẢN PHẨM THEO NHÓM DANH MỤC (DATATABLE)
        // =========================================================================
        // GET: api/ado-products/category-summary
        [HttpGet("category-summary")]
        public IActionResult GetCategoryProductSummary()
        {
            string connectionString = GetConnectionString();
            DataTable summaryTable = new DataTable("CategorySummary");

            using (DbConnection connection = AdoDbHelper.CreateConnection(connectionString))
            {
                string query = @"SELECT CategoryId, COUNT(*) AS Total 
                                 FROM products 
                                 GROUP BY CategoryId 
                                 ORDER BY CategoryId ASC";

                using (DbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    using (DbDataAdapter adapter = AdoDbHelper.CreateDataAdapter(command, connectionString))
                    {
                        adapter.Fill(summaryTable);
                    }
                }
            }

            var result = new List<CategoryProductSummaryDto>();
            foreach (DataRow row in summaryTable.Rows)
            {
                result.Add(new CategoryProductSummaryDto
                {
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    TotalProducts = Convert.ToInt32(row["Total"])
                });
            }

            return Ok(new
            {
                totalCategories = result.Count,
                summary = result
            });
        }
    }
}
