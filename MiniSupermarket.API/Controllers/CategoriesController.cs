using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Phải có JWT Token mới gọi được API
    public class CategoriesController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        // Dependency Injection: tiêm SupermarketDbContext
        public CategoriesController(SupermarketDbContext context)
        {
            _context = context;
        }

        // =========================================================
        // 1. READ: Lấy toàn bộ danh mục
        // GET: /api/categories
        // =========================================================
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _context.Categories
                .AsNoTracking()
                .ToListAsync();

            return Ok(list);
        }

        // =========================================================
        // 2. READ: Lấy danh mục theo ID
        // GET: /api/categories/1
        // =========================================================
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _context.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy nhóm hàng trong CSDL!"
                });
            }

            return Ok(category);
        }

        // =========================================================
        // 3. SEARCH: Tìm kiếm danh mục
        // GET: /api/categories/search?keyword=banh
        // =========================================================
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new
                {
                    message = "Vui lòng nhập từ khóa tìm kiếm!"
                });
            }

            var result = await _context.Categories
                .AsNoTracking()
                .Where(c => c.CategoryName.Contains(keyword))
                .ToListAsync();

            return Ok(result);
        }

        // =========================================================
        // 4. CREATE: Thêm danh mục
        // POST: /api/categories
        // =========================================================
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category newCat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Categories.Add(newCat);

            // Lưu vào SQL Server
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = newCat.CategoryId },
                newCat
            );
        }

        // =========================================================
        // 5. UPDATE: Cập nhật danh mục
        // PUT: /api/categories/1
        // =========================================================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] Category updateCat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cat = await _context.Categories.FindAsync(id);

            if (cat == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy nhóm hàng cần sửa!"
                });
            }

            cat.CategoryName = updateCat.CategoryName;
            cat.Description = updateCat.Description;

            // Lưu thay đổi vào SQL Server
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // =========================================================
        // 6. DELETE: Xóa danh mục
        // DELETE: /api/categories/1
        // =========================================================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _context.Categories.FindAsync(id);

            if (cat == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy nhóm hàng cần xóa!"
                });
            }

            _context.Categories.Remove(cat);

            // Lưu thay đổi vào SQL Server
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // =========================================================
        // 7. ADMIN: Kiểm tra quyền Admin
        // GET: /api/categories/admin-dashboard
        // =========================================================
        [HttpGet("admin-dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminDashboard()
        {
            return Ok(new
            {
                message = "Chào mừng Admin! Bạn có toàn quyền quản trị hệ thống siêu thị mini."
            });
        }

        // =========================================================
        // 8. STAFF: Admin và Cashier đều được phép
        // GET: /api/categories/staff-pos
        // =========================================================
        [HttpGet("staff-pos")]
        [Authorize(Roles = "Admin,Cashier")]
        public IActionResult GetStaffPos()
        {
            return Ok(new
            {
                message = "Màn hình POS Thu ngân sẵn sàng phục vụ bán hàng."
            });
        }
    }
}
