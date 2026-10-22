/*
 * Ho ten sinh vien: Tran Hoang Lin
 * Ma sinh vien: 2124110134
 * Ngay tao: 22/10/2026
 * Mo ta: Cac lop DTO phuc vu nghiep vu thanh toan gio hang POS (Buoi 5 - Tiet 5)
 */
namespace MiniSupermarket.API.Models
{
    // DTO bieu dien tung dong san pham trong gio hang
    public class CartItemCheckoutDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    // Alias tuong thich cho cac controller khac
    public class CheckoutItemDto : CartItemCheckoutDto
    {
    }

    // DTO nhan yeu cau thanh toan tong the tu may POS
    public class CheckoutRequestDto
    {
        // Tai khoan thu ngan dang dung ca truc
        public string CashierUsername { get; set; } = string.Empty;

        // Ma dinh danh khach hang (neu la khach vang lai, truyen CustomerId = 15)
        public int CustomerId { get; set; }

        // So dien thoai khach hang (neu co truyen tu client cu)
        public string CustomerPhone { get; set; } = string.Empty;

        // Danh sach cac mon hang can thanh toan
        public List<CartItemCheckoutDto> Items { get; set; } = new();
    }
}
