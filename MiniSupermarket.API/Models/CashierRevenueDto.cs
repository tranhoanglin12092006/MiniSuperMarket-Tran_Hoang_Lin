/*
 * Ho ten sinh vien: Tran Hoang Lin
 * Ma sinh vien: 2124110134
 * Ngay tao: 22/10/2026
 * Mo ta: DTO hung du lieu ket qua thong ke tu Stored Procedure (Buoi 5 - Tiet 3)
 */
namespace MiniSupermarket.API.Models
{
    public class CashierRevenueDto
    {
        // Ten dang nhap cua thu ngan chiu trach nhiem ca ban
        public string CashierUsername { get; set; } = string.Empty;

        // Tong so luong don hang thu ngan da xu ly thanh cong
        public int TotalOrders { get; set; }

        // Tong so tien thu ve cho sieu thi (VND)
        public decimal TotalRevenue { get; set; }

        // Tong diem thuong da tich luy cho khach hang
        public int TotalPointsAwarded { get; set; }
    }

    // DTO cho Bai tap 3.1: Bao cao doanh thu theo khoang ngay
    public class DateRangeRevenueDto
    {
        public string CashierUsername { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    // DTO cho Bai tap 3.2: Top 5 san pham ban chay nhat
    public class TopSellingProductDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int TotalSold { get; set; }
        public decimal TotalSalesRevenue { get; set; }
    }
}
