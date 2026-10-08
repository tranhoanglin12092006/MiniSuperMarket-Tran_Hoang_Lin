using MiniSupermarket.WinForms.Models;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks; // 1. Thêm thư viện này để nhận diện kiểu Task
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormQuickReport : Form
    {
        // Khuyên dùng: Nên dùng chung ApiClientService nếu toàn bộ app của bạn dùng chung cấu hình này,
        // ở đây giữ nguyên HttpClient theo code của bạn nhưng cần tối ưu BaseAddress.
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7167/api/")
        };

        public FormQuickReport()
        {
            InitializeComponent();
            SetupHeaderToken();
        }

        private void SetupHeaderToken()
        {
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
        }

        private async void FormQuickReport_Load(object sender, EventArgs e)
        {
            dtpReportDate.Value = DateTime.Today;
            await LoadReportDataAsync(dtpReportDate.Value);
        }

        private async void btnRunReport_Click(object sender, EventArgs e)
        {
            await LoadReportDataAsync(dtpReportDate.Value);
        }

        private async Task LoadReportDataAsync(DateTime selectedDate)
        {
            try
            {
                SetupHeaderToken();
                string dateStr = selectedDate.ToString("yyyy-MM-dd");

                // Gọi API lấy báo cáo theo ngày
                var report = await client.GetFromJsonAsync<ReportDto>($"reports/daily?date={dateStr}");

                if (report != null)
                {
                    // Hiển thị dữ liệu THẬT từ API trả về
                    lblTotalOrders.Text = report.TotalOrders.ToString();
                    lblTotalRevenue.Text = report.TotalRevenue.ToString("N0") + " VNĐ";
                    lblBestSeller.Text = !string.IsNullOrEmpty(report.BestSellerProduct) ? report.BestSellerProduct : "Không có";
                }
                else
                {
                    // Nếu không có dữ liệu trong ngày, hiển thị giá trị mặc định 0
                    lblTotalOrders.Text = "0";
                    lblTotalRevenue.Text = "0 VNĐ";
                    lblBestSeller.Text = "Chưa có dữ liệu";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Gán giá trị an toàn khi gọi API lỗi
                lblTotalOrders.Text = "0";
                lblTotalRevenue.Text = "0 VNĐ";
                lblBestSeller.Text = "Lỗi kết nối";
            }
        }
    }
}