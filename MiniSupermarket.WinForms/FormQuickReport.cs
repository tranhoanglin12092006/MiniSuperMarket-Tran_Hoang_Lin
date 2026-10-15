using MiniSupermarket.WinForms.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormQuickReport : Form
    {
        public FormQuickReport()
        {
            InitializeComponent();
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

        private async void btnToday_Click(object sender, EventArgs e)
        {
            dtpReportDate.Value = DateTime.Today;
            await LoadReportDataAsync(dtpReportDate.Value);
        }

        private async Task LoadReportDataAsync(DateTime selectedDate)
        {
            btnRunReport.Enabled = false;
            btnRunReport.Text = "⏳ Đang tải...";

            try
            {
                string dateStr = selectedDate.ToString("yyyy-MM-dd");

                // 1. Gọi API lấy báo cáo tổng hợp (KPI)
                var report = await ApiClientService.GetFromJsonWithAuthAsync<ReportDto>($"reports/daily?date={dateStr}");

                if (report != null)
                {
                    lblTotalOrders.Text = report.TotalOrders.ToString();
                    lblTotalRevenue.Text = report.TotalRevenue.ToString("N0") + " VNĐ";
                    lblBestSeller.Text = !string.IsNullOrEmpty(report.BestSellerProduct) ? report.BestSellerProduct : "Chưa có";
                }
                else
                {
                    lblTotalOrders.Text = "0";
                    lblTotalRevenue.Text = "0 VNĐ";
                    lblBestSeller.Text = "Chưa có dữ liệu";
                }

                // 2. Gọi API lấy danh sách chi tiết các hóa đơn trong ngày
                try
                {
                    var orders = await ApiClientService.GetFromJsonWithAuthAsync<List<DayOrderDto>>($"reports/orders?date={dateStr}");
                    dgvDayOrders.DataSource = null;
                    if (orders != null && orders.Count > 0)
                    {
                        dgvDayOrders.DataSource = orders;
                        ConfigureOrdersGrid();
                        lblOrdersSectionTitle.Text = $"📋 DANH SÁCH HÓA ĐƠN TRONG NGÀY ({orders.Count} đơn)";
                    }
                    else
                    {
                        lblOrdersSectionTitle.Text = $"📋 DANH SÁCH HÓA ĐƠN TRONG NGÀY (0 đơn)";
                    }
                }
                catch
                {
                    // Dự phòng nếu endpoint chưa sẵn sàng
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblTotalOrders.Text = "0";
                lblTotalRevenue.Text = "0 VNĐ";
                lblBestSeller.Text = "Lỗi kết nối";
            }
            finally
            {
                btnRunReport.Enabled = true;
                btnRunReport.Text = "⚡ Xem báo cáo";
            }
        }

        private void ConfigureOrdersGrid()
        {
            if (dgvDayOrders.Columns.Count == 0) return;

            if (dgvDayOrders.Columns["OrderId"] != null)
            {
                dgvDayOrders.Columns["OrderId"].HeaderText = "ID";
                dgvDayOrders.Columns["OrderId"].Width = 60;
                dgvDayOrders.Columns["OrderId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvDayOrders.Columns["OrderCode"] != null)
            {
                dgvDayOrders.Columns["OrderCode"].HeaderText = "Mã hóa đơn";
                dgvDayOrders.Columns["OrderCode"].Width = 160;
                dgvDayOrders.Columns["OrderCode"].DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            }
            if (dgvDayOrders.Columns["Time"] != null)
            {
                dgvDayOrders.Columns["Time"].HeaderText = "Thời gian";
                dgvDayOrders.Columns["Time"].Width = 100;
                dgvDayOrders.Columns["Time"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvDayOrders.Columns["CustomerName"] != null)
            {
                dgvDayOrders.Columns["CustomerName"].HeaderText = "Khách hàng";
                dgvDayOrders.Columns["CustomerName"].Width = 190;
            }
            if (dgvDayOrders.Columns["Cashier"] != null)
            {
                dgvDayOrders.Columns["Cashier"].HeaderText = "Thu ngân";
                dgvDayOrders.Columns["Cashier"].Width = 120;
                dgvDayOrders.Columns["Cashier"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvDayOrders.Columns["TotalItems"] != null)
            {
                dgvDayOrders.Columns["TotalItems"].HeaderText = "Số món";
                dgvDayOrders.Columns["TotalItems"].Width = 85;
                dgvDayOrders.Columns["TotalItems"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dgvDayOrders.Columns["FinalAmount"] != null)
            {
                dgvDayOrders.Columns["FinalAmount"].HeaderText = "Tổng tiền (VNĐ)";
                dgvDayOrders.Columns["FinalAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvDayOrders.Columns["FinalAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvDayOrders.Columns["FinalAmount"].DefaultCellStyle.Format = "N0";
                dgvDayOrders.Columns["FinalAmount"].DefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
                dgvDayOrders.Columns["FinalAmount"].DefaultCellStyle.ForeColor = Color.FromArgb(16, 185, 129);
            }
            if (dgvDayOrders.Columns["RewardPoints"] != null)
            {
                dgvDayOrders.Columns["RewardPoints"].HeaderText = "Điểm cộng";
                dgvDayOrders.Columns["RewardPoints"].Width = 95;
                dgvDayOrders.Columns["RewardPoints"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }

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
    }
}