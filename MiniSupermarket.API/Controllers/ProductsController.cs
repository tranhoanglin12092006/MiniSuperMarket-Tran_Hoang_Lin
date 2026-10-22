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

        // =========================================================================
        // BUỔI 6: API PHÂN TRANG LINQ & EAGER LOADING KẾT HỢP TÌM KIẾM VÀ LỌC NHÓM
        // GET: api/products/paged?keyword=sua&categoryId=1&pageNumber=1&pageSize=5
        // =========================================================================
        [AllowAnonymous]
        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedProducts(
            [FromQuery] string? keyword,
            [FromQuery] int? categoryId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 5)
        {
            try
            {
                // 1. Kiểm tra tham số trang đầu vào hợp lệ
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1 || pageSize > 50) pageSize = 5; // Mặc định 5 dòng, tối đa 50 dòng

                // 2. Khởi tạo truy vấn LINQ IQueryable kết hợp Eager Loading (.Include)
                // AsNoTracking giúp tối ưu hóa bộ nhớ RAM cho các truy vấn chỉ đọc dữ liệu
                var query = _context.Products
                    .Include(p => p.Category)
                    .AsNoTracking()
                    .AsQueryable();

                // 3. Lọc theo từ khóa tìm kiếm (nếu người dùng có nhập)
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    string search = keyword.Trim().ToLower();
                    query = query.Where(p => p.ProductName.ToLower().Contains(search)
                                          || p.Barcode.Contains(search));
                }

                // 3.1. Bổ sung bộ lọc Sản phẩm theo Nhóm hàng (Bài tập mở rộng 6.2)
                if (categoryId.HasValue && categoryId.Value > 0)
                {
                    query = query.Where(p => p.CategoryId == categoryId.Value);
                }

                // 4. Đếm tổng số lượng bản ghi thỏa mãn điều kiện
                int totalItems = await query.CountAsync();

                // 5. Tính toán tổng số trang
                int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

                // 6. Áp dụng toán tử Skip và Take để phân trang trực tiếp dưới CSDL
                var items = await query
                    .OrderBy(p => p.ProductId) // Bắt buộc phải OrderBy trước khi Skip/Take
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .Select(p => new ProductItemDto
                    {
                        ProductId = p.ProductId,
                        Barcode = p.Barcode,
                        ProductName = p.ProductName,
                        Price = p.Price,
                        StockQuantity = p.StockQuantity,
                        CategoryId = p.CategoryId,
                        CategoryName = p.Category != null ? p.Category.CategoryName : string.Empty
                    })
                    .ToListAsync();

                // 7. Đóng gói kết quả trả về cho Client
                var response = new PagedResult<ProductItemDto>
                {
                    CurrentPage = pageNumber,
                    PageSize = pageSize,
                    TotalItems = totalItems,
                    TotalPages = totalPages,
                    Items = items
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi phân trang sản phẩm: " + ex.Message });
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

        // GET: api/products/barcode/{barcode}
        [HttpGet("barcode/{barcode}")]
        public async Task<IActionResult> GetProductByBarcode(string barcode)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(barcode))
                {
                    return BadRequest(new { message = "Mã vạch không được để trống!" });
                }

                var product = await _context.Products
                    .Include(p => p.Category)
                    .Where(p => p.Barcode == barcode.Trim())
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
                    return NotFound(new { message = $"Không tìm thấy sản phẩm với mã vạch '{barcode}'!" });
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi tìm sản phẩm theo mã vạch: " + ex.Message });
            }
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

                if (string.IsNullOrWhiteSpace(dto.Barcode) || string.IsNullOrWhiteSpace(dto.ProductName))
                {
                    return BadRequest(new { message = "Mã vạch và Tên sản phẩm không được để trống!" });
                }

                // Kiểm tra trùng mã vạch
                var duplicateBarcode = await _context.Products.AnyAsync(p => p.Barcode == dto.Barcode.Trim());
                if (duplicateBarcode)
                {
                    return Conflict(new { message = $"Mã vạch '{dto.Barcode}' đã tồn tại trong hệ thống!" });
                }

                // Kiểm tra Category hợp lệ
                if (dto.CategoryId > 0)
                {
                    var catExists = await _context.Categories.AnyAsync(c => c.CategoryId == dto.CategoryId);
                    if (!catExists)
                    {
                        return BadRequest(new { message = $"Nhóm hàng có ID {dto.CategoryId} không tồn tại!" });
                    }
                }
                else
                {
                    // Lấy nhóm mặc định đầu tiên nếu chưa chọn
                    var firstCat = await _context.Categories.FirstOrDefaultAsync();
                    if (firstCat != null)
                    {
                        dto.CategoryId = firstCat.CategoryId;
                    }
                }

                var product = new Product
                {
                    Barcode = dto.Barcode.Trim(),
                    ProductName = dto.ProductName.Trim(),
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
                return StatusCode(500, new { message = "Lỗi khi thêm sản phẩm: " + (ex.InnerException?.Message ?? ex.Message) });
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