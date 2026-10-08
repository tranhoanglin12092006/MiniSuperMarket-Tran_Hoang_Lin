using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models; // Namespace chứa model Product của bạn
// Lưu ý: Hãy thay đổi namespace Data dưới đây cho khớp với vị trí đặt SupermarketDbContext thực tế của bạn
using MiniSupermarket.API.Data;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Yêu cầu xác thực JWT Token khi gọi API
    public class ProductsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ProductsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = await _context.Products
                    .Include(p => p.Category)
                    .Select(p => new
                    {
                        productId = p.ProductId,
                        barcode = p.Barcode,
                        productName = p.ProductName,
                        price = p.Price,
                        stockQuantity = p.StockQuantity,
                        categoryId = p.CategoryId,
                        categoryName = p.Category != null ? p.Category.CategoryName : "Chưa phân loại"
                    })
                    .ToListAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy danh sách sản phẩm: " + ex.Message });
            }
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Where(p => p.ProductId == id)
                .Select(p => new
                {
                    productId = p.ProductId,
                    barcode = p.Barcode,
                    productName = p.ProductName,
                    price = p.Price,
                    stockQuantity = p.StockQuantity,
                    categoryId = p.CategoryId,
                    categoryName = p.Category != null ? p.Category.CategoryName : "Chưa phân loại"
                })
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm." });
            }

            return Ok(product);
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var product = new Product
                {
                    Barcode = dto.Barcode,
                    ProductName = dto.ProductName,
                    Price = dto.Price,
                    StockQuantity = dto.StockQuantity,
                    CategoryId = dto.CategoryId
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Thêm sản phẩm thành công!", productId = product.ProductId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi thêm sản phẩm: " + ex.Message });
            }
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductUpdateDto dto)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound(new { message = "Không tìm thấy sản phẩm cần cập nhật." });
                }

                product.Barcode = dto.Barcode;
                product.ProductName = dto.ProductName;
                product.Price = dto.Price;
                product.StockQuantity = dto.StockQuantity;
                product.CategoryId = dto.CategoryId;

                await _context.SaveChangesAsync();

                return Ok(new { message = "Cập nhật sản phẩm thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật sản phẩm: " + ex.Message });
            }
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound(new { message = "Không tìm thấy sản phẩm cần xóa." });
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Xóa sản phẩm thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi xóa sản phẩm: " + ex.Message });
            }
        }
    }

    // Các DTO hỗ trợ nhận dữ liệu từ phía Client (WinForms)
    public class ProductCreateDto
    {
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductUpdateDto : ProductCreateDto
    {
    }
}