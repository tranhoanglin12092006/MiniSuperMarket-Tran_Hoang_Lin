using System;
using System.Collections.Generic;

namespace MiniSupermarket.WinForms.Models
{
    public class ReportDto
    {
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
        public string? BestSellerProduct { get; set; }
    }

    // Chi tiết hóa đơn trong ngày
    public class DayOrderDto
    {
        public int OrderId { get; set; }
        public string OrderCode { get; set; } = string.Empty;
        public string Time { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Cashier { get; set; } = string.Empty;
        public int TotalItems { get; set; }
        public decimal FinalAmount { get; set; }
        public int RewardPoints { get; set; }
        public string Status { get; set; } = "✓ Hoàn tất";
    }

    // Item 44: DTO Thống kê Dashboard 4 chỉ số tổng quan
    public class DashboardSummaryDto
    {
        public bool Success { get; set; }
        public decimal TodayRevenue { get; set; }
        public int TotalOrders { get; set; }
        public int TodayOrders { get; set; }
        public int NewCustomers { get; set; }
        public int LowStockCount { get; set; }
    }

    // Item 45: DTO Doanh thu theo ngày cho Biểu đồ cột Bar Chart
    public class DailyChartItemDto
    {
        public string OrderDate { get; set; } = string.Empty;
        public string DateKey { get; set; } = string.Empty;
        public int TotalOrders { get; set; }
        public decimal TotalRevenue { get; set; }
    }

    public class DailyChartResponseDto
    {
        public bool Success { get; set; }
        public string FromDate { get; set; } = string.Empty;
        public string ToDate { get; set; } = string.Empty;
        public List<DailyChartItemDto> Data { get; set; } = new();
    }

    // Item 46: DTO Top 5 sản phẩm bán chạy nhất LINQ
    public class TopProductDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public int TotalSold { get; set; }
        public decimal TotalSalesRevenue { get; set; }
    }

    public class TopProductsResponseDto
    {
        public bool Success { get; set; }
        public List<TopProductDto> Data { get; set; } = new();
    }

    public class TopSellingDisplayDto
    {
        public string Rank { get; set; } = string.Empty;
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string TotalSold { get; set; } = string.Empty;
        public string TotalSalesRevenue { get; set; } = string.Empty;
    }

    // Chi tiết từng mặt hàng trong hóa đơn khi xem chi tiết
    public class ReportOrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}
