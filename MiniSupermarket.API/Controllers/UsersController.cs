using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models; // Namespace chứa model User của bạn
using MiniSupermarket.API.Data;   // Namespace chứa SupermarketDbContext

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Yêu cầu xác thực JWT Token
    public class UsersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public UsersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // GET: api/users
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _context.Users
                    .Select(u => new
                    {
                        userId = u.UserId,
                        username = u.Username,
                        fullName = u.FullName,
                        role = u.Role,
                        functionScope = u.FunctionScope
                    })
                    .ToListAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy danh sách người dùng: " + ex.Message });
            }
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _context.Users
                    .Where(u => u.UserId == id)
                    .Select(u => new
                    {
                        userId = u.UserId,
                        username = u.Username,
                        fullName = u.FullName,
                        role = u.Role,
                        functionScope = u.FunctionScope
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound(new { message = "Không tìm thấy người dùng." });
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi lấy thông tin người dùng: " + ex.Message });
            }
        }

        // POST: api/users
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Kiểm tra xem Username đã tồn tại chưa
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
                if (existingUser != null)
                {
                    return BadRequest(new { message = "Tên đăng nhập này đã tồn tại!" });
                }

                var user = new User
                {
                    Username = dto.Username,
                    Password = dto.Password, // Khớp trực tiếp với thuộc tính Password trong model mới
                    FullName = dto.FullName,
                    Role = dto.Role,
                    FunctionScope = dto.FunctionScope ?? string.Empty
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Thêm người dùng thành công!", userId = user.UserId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi thêm người dùng: " + ex.Message });
            }
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto dto)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound(new { message = "Không tìm thấy người dùng cần cập nhật." });
                }

                user.FullName = dto.FullName;
                user.Role = dto.Role;
                user.FunctionScope = dto.FunctionScope ?? string.Empty;

                // Nếu có truyền mật khẩu mới thì cập nhật
                if (!string.IsNullOrEmpty(dto.Password))
                {
                    user.Password = dto.Password;
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "Cập nhật thông tin người dùng thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật người dùng: " + ex.Message });
            }
        }

        // DELETE: api/users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound(new { message = "Không tìm thấy người dùng cần xóa." });
                }

                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Xóa người dùng thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi xóa người dùng: " + ex.Message });
            }
        }
    }

    // Các DTO hỗ trợ nhận dữ liệu cho User phù hợp hoàn toàn với Model mới
    public class UserCreateDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // ADMIN, CASHIER, WAREHOUSE,...
        public string FunctionScope { get; set; } = string.Empty;
    }

    public class UserUpdateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string FunctionScope { get; set; } = string.Empty;
        public string? Password { get; set; } // Để trống nếu không muốn đổi mật khẩu
    }
}