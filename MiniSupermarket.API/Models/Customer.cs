using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSupermarket.API.Models
{
    public class Customer
    {
        // Khóa chính, tự tăng IDENTITY(1,1)
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        // NVARCHAR(100), bắt buộc
        [Required]
        [StringLength(100)]
        public string CustomerName { get; set; } = string.Empty;

        // VARCHAR(15), bắt buộc
        [Required]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;

        // NVARCHAR(200), có thể để trống
        [StringLength(200)]
        public string? Address { get; set; }

        // INT, mặc định = 0
        public int RewardPoints { get; set; } = 0;

        // NVARCHAR(50), mặc định = "Chuẩn"
        [StringLength(50)]
        public string MembershipRank { get; set; } = "Chuẩn";
    }
}
