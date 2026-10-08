using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSupermarket.API.Models
{
    [Table("Users")] // Ánh xạ rõ ràng với tên bảng Users trong SQL Server
    public class User
    {
        [Key] // Khóa chính
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Tự động tăng (Identity 1,1)
        public int UserId { get; set; }

        [Required(ErrorMessage = "Tên tài khoản không được để trống!")]
        [StringLength(50, ErrorMessage = "Tên tài khoản không vượt quá 50 ký tự")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        [StringLength(255, ErrorMessage = "Mật khẩu không vượt quá 255 ký tự")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Họ tên nhân viên không được để trống!")]
        [StringLength(100, ErrorMessage = "Họ tên không vượt quá 100 ký tự")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vai trò không được để trống!")]
        [StringLength(50)]
        public string Role { get; set; } = string.Empty; // ADMIN, CASHIER, WAREHOUSE,...

        [StringLength(255, ErrorMessage = "Phạm vi chức năng không vượt quá 255 ký tự")]
        public string FunctionScope { get; set; } = string.Empty; // Phạm vi chức năng cho phép

        [StringLength(150, ErrorMessage = "Email không vượt quá 150 ký tự")]
        public string Email { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}