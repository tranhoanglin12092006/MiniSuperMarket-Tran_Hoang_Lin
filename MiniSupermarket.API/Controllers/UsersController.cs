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
                        id = u.UserId,
                        userId = u.UserId,
                        username = u.Username,
                        fullName = u.FullName,
                        email = u.Email,
                        role = u.Role,
                        functionScope = u.FunctionScope,
                        isActive = u.IsActive
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
                        id = u.UserId,
                        userId = u.UserId,
                        username = u.Username,
                        fullName = u.FullName,
                        email = u.Email,
                        role = u.Role,
                        functionScope = u.FunctionScope,
                        isActive = u.IsActive
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
                var normalizedUsername = dto.Username.Trim();
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower() == normalizedUsername.ToLower());
                if (existingUser != null)
                {
                    return BadRequest(new { message = "Tên đăng nhập này đã tồn tại!" });
                }

                // Luôn băm mật khẩu bằng BCrypt trước khi lưu vào Database
                var hashedPassword = MiniSupermarket.API.Helpers.PasswordHelper.HashPassword(dto.Password.Trim());

                var user = new User
                {
                    Username = normalizedUsername,
                    Password = hashedPassword,
                    FullName = dto.FullName.Trim(),
                    Email = dto.Email?.Trim() ?? string.Empty,
                    Role = dto.Role.Trim(),
                    FunctionScope = dto.FunctionScope ?? string.Empty,
                    IsActive = true // Mặc định tài khoản mới tạo luôn hoạt động
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

                user.FullName = dto.FullName.Trim();
                user.Email = dto.Email?.Trim() ?? user.Email;
                user.Role = dto.Role.Trim();
                user.FunctionScope = dto.FunctionScope ?? string.Empty;

                // Nếu có truyền mật khẩu mới thì băm và cập nhật
                if (!string.IsNullOrWhiteSpace(dto.Password))
                {
                    user.Password = MiniSupermarket.API.Helpers.PasswordHelper.HashPassword(dto.Password.Trim());
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "Cập nhật thông tin người dùng thành công!" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật người dùng: " + ex.Message });
            }
        }

        // PUT: api/users/{id}/role
        [HttpPut("{id}/role")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] UserRoleUpdateDto dto)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound(new { message = "Không tìm thấy người dùng." });
                }

                if (string.IsNullOrWhiteSpace(dto.Role))
                {
                    return BadRequest(new { message = "Vai trò không được để trống!" });
                }

                user.Role = dto.Role.Trim();
                await _context.SaveChangesAsync();

                return Ok(new { message = $"Đã cập nhật vai trò của tài khoản [{user.Username}] thành [{user.Role}] thành công!", role = user.Role });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật vai trò: " + ex.Message });
            }
        }

        // PUT: api/users/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> ToggleStatus(int id, [FromBody] UserStatusDto dto)
        {
            try
            {
                var user = await _context.Users.FindAsync(id);
                if (user == null)
                {
                    return NotFound(new { message = "Không tìm thấy người dùng cần thay đổi trạng thái." });
                }

                user.IsActive = dto.IsActive;
                await _context.SaveChangesAsync();

                string statusText = user.IsActive ? "mở khóa" : "khóa";
                return Ok(new { message = $"Đã {statusText} tài khoản [{user.Username}] thành công!", isActive = user.IsActive });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Lỗi khi cập nhật trạng thái người dùng: " + ex.Message });
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
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty; // ADMIN, CASHIER, WAREHOUSE,...
        public string FunctionScope { get; set; } = string.Empty;
    }

    public class UserUpdateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string FunctionScope { get; set; } = string.Empty;
        public string? Password { get; set; } // Để trống nếu không muốn đổi mật khẩu
    }

    public class UserRoleUpdateDto
    {
        public string Role { get; set; } = string.Empty;
    }

    public class UserStatusDto
    {
        public bool IsActive { get; set; }
    }
}