using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniSupermarket.API.Data; // Thêm namespace chứa DbContext của bạn
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SupermarketDbContext _context; // Khai báo DbContext

        // Inject SupermarketDbContext thông qua constructor
        public AuthController(IConfiguration configuration, SupermarketDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        // Endpoint Đăng nhập: POST /api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest(new { success = false, message = "Vui lòng nhập đầy đủ tài khoản và mật khẩu!" });
            }

            // Truy vấn trực tiếp từ cơ sở dữ liệu thông qua EF Core
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == request.Username && u.Password == request.Password);

            if (user == null)
            {
                return Unauthorized(new { success = false, message = "Sai tài khoản hoặc mật khẩu!" });
            }

            // Tạo Token dựa trên Role thực tế của user lấy từ database
            var token = GenerateJwtToken(user.Username, user.Role);

            return Ok(new
            {
                success = true,
                token = token,
                role = user.Role,
                fullName = user.FullName
            });
        }

        private string GenerateJwtToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"] ?? "SupermarketSecretKeyDoAnMonHoc2026SecureString!!");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}