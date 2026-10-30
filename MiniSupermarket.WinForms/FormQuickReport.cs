using MiniSupermarket.WinForms.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MiniSupermarket.WinForms
{
    public partial class FormQuickReport : Form
    {
        private List<DayOrderDto> _currentOrders = new();
        private bool _isViewingAllOrders = false;

        public FormQuickReport()
        {
            InitializeComponent();
            SetupOrdersGrid();
            SetupTopSellingGrid();
        }

        /// <summary>
        /// Khởi tạo cấu hình các cột tĩnh cho lưới Danh sách hóa đơn (AutoGenerateColumns = false)
        /// Tránh lỗi NullReferenceException do nạp style động khi chưa vẽ control
        /// </summary>
        private void SetupOrdersGrid()
        {
            dgvDayOrders.AutoGenerateColumns = false;
            dgvDayOrders.Columns.Clear();

            dgvDayOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderId",
                HeaderText = "ID",
                Width = 55,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvDayOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderCode",
                HeaderText = "Mã hóa đơn",
                Width = 155,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold)
                }
            });

            dgvDayOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Time",
                HeaderText = "Ngày giờ lập",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvDayOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerName",
                HeaderText = "Khách hàng",
                Width = 180,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

            dgvDayOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cashier",
                HeaderText = "Thu ngân",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvDayOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalItems",
                HeaderText = "Số món",
                Width = 75,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvDayOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FinalAmount",
                HeaderText = "Tổng tiền (VNĐ)",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(37, 99, 235) // Tech blue
                }
            });

            dgvDayOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "RewardPoints",
                HeaderText = "Điểm cộng",
                Width = 90,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(234, 88, 12) // Orange
                }
            });

            dgvDayOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(16, 185, 129) // Emerald
                }
            });
        }

        /// <summary>
        /// Khởi tạo cấu hình các cột tĩnh cho lưới Top 5 Sản phẩm bán chạy (AutoGenerateColumns = false)
        /// Tránh lỗi NullReferenceException khi truy cập DefaultCellStyle trên TabPage chưa render
        /// </summary>
        private void SetupTopSellingGrid()
        {
            dgvTopSelling.AutoGenerateColumns = false;
            dgvTopSelling.Columns.Clear();

            dgvTopSelling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Rank",
                HeaderText = "Hạng",
                Width = 115,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(234, 88, 12)
                }
            });

            dgvTopSelling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductId",
                HeaderText = "Mã SP",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvTopSelling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Barcode",
                HeaderText = "Mã vạch Barcode",
                Width = 160,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

            dgvTopSelling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên mặt hàng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleLeft
                }
            });

            dgvTopSelling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalSold",
                HeaderText = "Số lượng đã bán",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(37, 99, 235)
                }
            });

            dgvTopSelling.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalSalesRevenue",
                HeaderText = "Tổng doanh số",
                Width = 170,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(16, 185, 129)
                }
            });
        }

        private async void FormQuickReport_Load(object sender, EventArgs e)
        {
            UI.UIStyler.StyleDataGridView(dgvDayOrders);
            UI.UIStyler.StyleDataGridView(dgvTopSelling);

            cboStatusFilter.SelectedIndex = 0;
            UpdateTabNavButtons(0);

            dtpReportFromDate.Value = DateTime.Today;
            dtpReportToDate.Value = DateTime.Today;

            // 1. Tải chỉ số tồn kho cảnh báo
            await LoadDashboardSummaryAsync();

            // 2. Tải danh sách hóa đơn theo ngày hôm nay & cập nhật các thẻ KPI
            await LoadReportDataByRangeAsync(dtpReportFromDate.Value, dtpReportToDate.Value);

            // 3. Tải biểu đồ cột doanh thu 7 ngày gần nhất
            await LoadChartDataAsync(DateTime.Today.AddDays(-7), DateTime.Today);

            // 4. Tải Top 5 sản phẩm bán chạy nhất LINQ
            await LoadTopSellingAsync();
        }

        // =========================================================================
        // SEGMENTED TAB NAVIGATION
        // =========================================================================
        private void btnNavOrders_Click(object sender, EventArgs e)
        {
            SetSelectedTab(0);
        }

        private void btnNavChart_Click(object sender, EventArgs e)
        {
            SetSelectedTab(1);
        }

        private void btnNavTopSelling_Click(object sender, EventArgs e)
        {
            SetSelectedTab(2);
        }

        private void SetSelectedTab(int index)
        {
            tabControlReport.SelectedIndex = index;
            UpdateTabNavButtons(index);
        }

        private void UpdateTabNavButtons(int activeIndex)
        {
            Button[] navButtons = { btnNavOrders, btnNavChart, btnNavTopSelling };
            for (int i = 0; i < navButtons.Length; i++)
            {
                if (i == activeIndex)
                {
                    navButtons[i].BackColor = Color.FromArgb(37, 99, 235); // Primary Tech Blue #2563EB
                    navButtons[i].ForeColor = Color.White;
                    navButtons[i].FlatAppearance.BorderSize = 0;
                }
                else
                {
                    navButtons[i].BackColor = Color.White;
                    navButtons[i].ForeColor = Color.FromArgb(71, 85, 105); // Slate 600
                    navButtons[i].FlatAppearance.BorderSize = 1;
                    navButtons[i].FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
                }
            }
        }

        // =========================================================================
        // BỘ LỌC THỜI GIAN VÀ DỮ LIỆU TỔNG QUAN
        // =========================================================================
        private async void btnRunReport_Click(object sender, EventArgs e)
        {
            if (dtpReportFromDate.Value > dtpReportToDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn Ngày kết thúc!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _isViewingAllOrders = false;
            string fromStr = dtpReportFromDate.Value.ToString("dd/MM/yyyy");
            string toStr = dtpReportToDate.Value.ToString("dd/MM/yyyy");

            if (dtpReportFromDate.Value.Date == dtpReportToDate.Value.Date)
            {
                lblViewStatus.Text = $"🏷️ Đang xem: Ngày {fromStr}";
                lblOrdersSummaryFilter.Text = $"🏷️ Kỳ: Ngày {fromStr}";
            }
            else
            {
                lblViewStatus.Text = $"🏷️ Đang xem: {fromStr} - {toStr}";
                lblOrdersSummaryFilter.Text = $"🏷️ Kỳ: {dtpReportFromDate.Value:dd/MM} - {dtpReportToDate.Value:dd/MM}";
            }

            await LoadReportDataByRangeAsync(dtpReportFromDate.Value, dtpReportToDate.Value);
            await LoadChartDataAsync(dtpReportFromDate.Value, dtpReportToDate.Value);
            await LoadDashboardSummaryAsync();
        }

        private async void btnToday_Click(object sender, EventArgs e)
        {
            _isViewingAllOrders = false;
            dtpReportFromDate.Value = DateTime.Today;
            dtpReportToDate.Value = DateTime.Today;
            lblViewStatus.Text = "🏷️ Đang xem: Hôm nay";
            lblOrdersSummaryFilter.Text = "🏷️ Kỳ: Hôm nay";
            await LoadReportDataByRangeAsync(DateTime.Today, DateTime.Today);
            await LoadChartDataAsync(DateTime.Today.AddDays(-7), DateTime.Today);
            await LoadDashboardSummaryAsync();
        }

        private async void btnYesterday_Click(object sender, EventArgs e)
        {
            _isViewingAllOrders = false;
            var yesterday = DateTime.Today.AddDays(-1);
            dtpReportFromDate.Value = yesterday;
            dtpReportToDate.Value = yesterday;
            lblViewStatus.Text = $"🏷️ Đang xem: Hôm qua ({yesterday:dd/MM/yyyy})";
            lblOrdersSummaryFilter.Text = "🏷️ Kỳ: Hôm qua";
            await LoadReportDataByRangeAsync(yesterday, yesterday);
            await LoadChartDataAsync(DateTime.Today.AddDays(-7), DateTime.Today);
            await LoadDashboardSummaryAsync();
        }

        private async void btnChart7Days_Click(object sender, EventArgs e)
        {
            _isViewingAllOrders = false;
            dtpReportFromDate.Value = DateTime.Today.AddDays(-6);
            dtpReportToDate.Value = DateTime.Today;
            lblViewStatus.Text = $"🏷️ Đang xem: 7 ngày qua ({dtpReportFromDate.Value:dd/MM} - {dtpReportToDate.Value:dd/MM/yyyy})";
            lblOrdersSummaryFilter.Text = "🏷️ Kỳ: 7 ngày";
            await LoadReportDataByRangeAsync(dtpReportFromDate.Value, dtpReportToDate.Value);
            await LoadChartDataAsync(dtpReportFromDate.Value, dtpReportToDate.Value);
            await LoadDashboardSummaryAsync();
        }

        private async void btnChart30Days_Click(object sender, EventArgs e)
        {
            _isViewingAllOrders = false;
            dtpReportFromDate.Value = DateTime.Today.AddDays(-29);
            dtpReportToDate.Value = DateTime.Today;
            lblViewStatus.Text = $"🏷️ Đang xem: 30 ngày qua ({dtpReportFromDate.Value:dd/MM} - {dtpReportToDate.Value:dd/MM/yyyy})";
            lblOrdersSummaryFilter.Text = "🏷️ Kỳ: 30 ngày";
            await LoadReportDataByRangeAsync(dtpReportFromDate.Value, dtpReportToDate.Value);
            await LoadChartDataAsync(dtpReportFromDate.Value, dtpReportToDate.Value);
            await LoadDashboardSummaryAsync();
        }

        private async void btnChartThisMonth_Click(object sender, EventArgs e)
        {
            _isViewingAllOrders = false;
            dtpReportFromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpReportToDate.Value = DateTime.Today;
            lblViewStatus.Text = $"🏷️ Đang xem: Tháng {DateTime.Today.Month}/{DateTime.Today.Year}";
            lblOrdersSummaryFilter.Text = $"🏷️ Kỳ: Tháng {DateTime.Today.Month}";
            await LoadReportDataByRangeAsync(dtpReportFromDate.Value, dtpReportToDate.Value);
            await LoadChartDataAsync(dtpReportFromDate.Value, dtpReportToDate.Value);
            await LoadDashboardSummaryAsync();
        }

        private async void btnAllOrders_Click(object sender, EventArgs e)
        {
            await LoadAllOrdersAsync();
            await LoadDashboardSummaryAsync();
            await LoadChartDataAsync(DateTime.Today.AddDays(-30), DateTime.Today);
        }

        public async Task LoadAllOrdersAsync()
        {
            _isViewingAllOrders = true;
            btnAllOrders.Enabled = false;
            btnAllOrders.Text = "⏳...";

            try
            {
                var orders = await ApiClientService.GetFromJsonWithAuthAsync<List<DayOrderDto>>("reports/orders?all=true");
                dgvDayOrders.DataSource = null;
                _currentOrders = orders ?? new List<DayOrderDto>();

                lblViewStatus.Text = $"🌐 Đang xem: Tất cả {_currentOrders.Count:N0} hóa đơn hệ thống";
                lblOrdersSummaryFilter.Text = "🏷️ Kỳ: Toàn bộ lịch sử";
                txtSearchOrder.Clear();

                ApplyOrdersFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải toàn bộ hóa đơn: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAllOrders.Enabled = true;
                btnAllOrders.Text = "Tất cả";
            }
        }

        private async Task LoadReportDataByRangeAsync(DateTime fromDate, DateTime toDate)
        {
            btnRunReport.Enabled = false;
            btnRunReport.Text = "⏳...";

            try
            {
                string fromStr = fromDate.ToString("yyyy-MM-dd");
                string toStr = toDate.ToString("yyyy-MM-dd");

                var orders = await ApiClientService.GetFromJsonWithAuthAsync<List<DayOrderDto>>($"reports/orders?fromDate={fromStr}&toDate={toStr}");

                dgvDayOrders.DataSource = null;
                _currentOrders = orders ?? new List<DayOrderDto>();

                txtSearchOrder.Clear();
                ApplyOrdersFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách hóa đơn: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRunReport.Enabled = true;
                btnRunReport.Text = "⚡ Lọc";
            }
        }

        // =========================================================================
        // TẢI CHỈ SỐ CẢNH BÁO TỒN KHO TỪ API DASHBOARD-SUMMARY
        // =========================================================================
        private async Task LoadDashboardSummaryAsync()
        {
            try
            {
                var summary = await ApiClientService.GetFromJsonWithAuthAsync<DashboardSummaryDto>("reports/dashboard-summary");
                if (summary != null)
                {
                    lblLowStockCount.Text = $"{summary.LowStockCount:N0}";

                    // Nếu có hàng sắp hết, đổi nền thẻ để cảnh báo nổi bật hơn
                    if (summary.LowStockCount > 0)
                    {
                        panelCard6.BackColor = Color.FromArgb(254, 242, 242); // Red 50
                    }
                    else
                    {
                        panelCard6.BackColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {
                lblLowStockCount.Text = "0";
            }
        }

        // =========================================================================
        // LỌC DỮ LIỆU & TÍNH TOÁN CÁC THẺ KPI
        // =========================================================================
        private void txtSearchOrder_TextChanged(object sender, EventArgs e)
        {
            ApplyOrdersFilter();
        }

        private void cboStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyOrdersFilter();
        }

        private void ApplyOrdersFilter()
        {
            string keyword = txtSearchOrder.Text.Trim().ToLowerInvariant();
            int filterIdx = cboStatusFilter.SelectedIndex;

            IEnumerable<DayOrderDto> query = _currentOrders;

            // 1. Phân loại theo ComboBox
            if (filterIdx == 1) // Khách thành viên
            {
                query = query.Where(o => !string.IsNullOrEmpty(o.CustomerName) && 
                                         !o.CustomerName.Trim().Equals("Khách vãng lai", StringComparison.OrdinalIgnoreCase));
            }
            else if (filterIdx == 2) // Khách vãng lai
            {
                query = query.Where(o => string.IsNullOrEmpty(o.CustomerName) || 
                                         o.CustomerName.Trim().Equals("Khách vãng lai", StringComparison.OrdinalIgnoreCase));
            }
            else if (filterIdx == 3) // Có điểm tích lũy
            {
                query = query.Where(o => o.RewardPoints > 0);
            }

            // 2. Tìm kiếm theo từ khóa
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(o =>
                    (o.OrderCode != null && o.OrderCode.ToLowerInvariant().Contains(keyword)) ||
                    (o.CustomerName != null && o.CustomerName.ToLowerInvariant().Contains(keyword)) ||
                    (o.Cashier != null && o.Cashier.ToLowerInvariant().Contains(keyword))
                );
            }

            var displayList = query.ToList();

            dgvDayOrders.DataSource = null;
            if (displayList.Count > 0)
            {
                dgvDayOrders.DataSource = displayList;
            }

            // 3. Tính toán các chỉ số thống kê thực tế
            decimal totalRev = displayList.Sum(x => x.FinalAmount);
            int totalOrders = displayList.Count;
            decimal avgRev = totalOrders > 0 ? totalRev / totalOrders : 0;
            int totalItems = displayList.Sum(x => x.TotalItems);
            int totalRewardPoints = displayList.Sum(x => x.RewardPoints);

            // Số khách thành viên có phát sinh đơn
            int memberCustomers = displayList
                .Where(x => !string.IsNullOrEmpty(x.CustomerName) && !x.CustomerName.Trim().Equals("Khách vãng lai", StringComparison.OrdinalIgnoreCase))
                .Select(x => x.CustomerName.Trim())
                .Distinct()
                .Count();

            // Cập nhật 5 thẻ KPI phía trên theo dữ liệu thực
            lblTotalRevenue.Text = $"{totalRev:N0} đ";
            lblTotalOrders.Text = $"{totalOrders:N0}";
            lblAvgOrderValue.Text = $"{avgRev:N0} đ";
            lblTotalCustomers.Text = $"{memberCustomers:N0}";
            lblRewardPoints.Text = $"{totalRewardPoints:N0}";

            // Cập nhật thanh tóm tắt nhanh dưới bảng
            lblOrdersSummaryCount.Text = $"📦 Tổng: {totalOrders:N0} / {_currentOrders.Count:N0} đơn";
            lblOrdersSummaryRevenue.Text = $"💰 Doanh thu: {totalRev:N0} VNĐ";
            lblOrdersSummaryAvg.Text = $"📊 Giá trị TB: {avgRev:N0} VNĐ / đơn";
            lblOrdersSummaryItems.Text = $"🛒 Tổng số món: {totalItems:N0} SP";

            // Cập nhật biểu đồ tròn cơ cấu khách hàng
            UpdateCustomerRatioChart(displayList);
        }

        /// <summary>
        /// Cập nhật Biểu đồ Doughnut tỷ lệ Khách thành viên vs Khách vãng lai
        /// </summary>
        private void UpdateCustomerRatioChart(List<DayOrderDto> orders)
        {
            try
            {
                var series = chartCustomerRatio.Series["CustomerRatio"];
                if (series == null && chartCustomerRatio.Series.Count > 0)
                {
                    series = chartCustomerRatio.Series[0];
                }

                if (series == null) return;

                series.Points.Clear();

                int memberOrders = orders.Count(x => !string.IsNullOrEmpty(x.CustomerName) && 
                                                    !x.CustomerName.Trim().Equals("Khách vãng lai", StringComparison.OrdinalIgnoreCase));
                int walkinOrders = orders.Count - memberOrders;

                if (memberOrders == 0 && walkinOrders == 0)
                {
                    int p = series.Points.AddXY("Chưa có đơn", 1);
                    series.Points[p].Color = Color.FromArgb(226, 232, 240);
                    series.Points[p].LegendText = "Không có đơn";
                    series.Points[p].IsValueShownAsLabel = false;
                }
                else
                {
                    if (memberOrders > 0)
                    {
                        int p1 = series.Points.AddXY($"Thành viên ({memberOrders})", memberOrders);
                        series.Points[p1].Color = Color.FromArgb(37, 99, 235); // Tech blue #2563EB
                        series.Points[p1].LegendText = $"Khách thành viên: {memberOrders:N0} đơn";
                        series.Points[p1].ToolTip = $"Khách thành viên: {memberOrders:N0} đơn ({((double)memberOrders / orders.Count):P1})";
                    }

                    if (walkinOrders > 0)
                    {
                        int p2 = series.Points.AddXY($"Vãng lai ({walkinOrders})", walkinOrders);
                        series.Points[p2].Color = Color.FromArgb(148, 163, 184); // Slate 400
                        series.Points[p2].LegendText = $"Khách vãng lai: {walkinOrders:N0} đơn";
                        series.Points[p2].ToolTip = $"Khách vãng lai: {walkinOrders:N0} đơn ({((double)walkinOrders / orders.Count):P1})";
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi vẽ biểu đồ cơ cấu khách hàng: " + ex.Message);
            }
        }

        // =========================================================================
        // XEM CHI TIẾT TỪNG MÓN TRONG HÓA ĐƠN
        // =========================================================================
        private async void btnViewOrderDetails_Click(object sender, EventArgs e)
        {
            await ShowSelectedOrderDetailAsync();
        }

        private async void dgvDayOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                await ShowSelectedOrderDetailAsync();
            }
        }

        private async Task ShowSelectedOrderDetailAsync()
        {
            if (dgvDayOrders.CurrentRow == null || dgvDayOrders.CurrentRow.DataBoundItem is not DayOrderDto selectedOrder)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn từ bảng để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btnViewOrderDetails.Enabled = false;
            btnViewOrderDetails.Text = "⏳ Đang tải...";

            try
            {
                var details = await ApiClientService.GetFromJsonWithAuthAsync<List<ReportOrderDetailDto>>($"reports/orders/{selectedOrder.OrderId}/details");
                if (details == null || details.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm chi tiết của hóa đơn '{selectedOrder.OrderCode}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var dialog = new FormOrderDetailDialog(selectedOrder, details);
                dialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy chi tiết hóa đơn: {ex.Message}", "Lỗi máy chủ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnViewOrderDetails.Enabled = true;
                btnViewOrderDetails.Text = "👁️ Xem chi tiết đơn hàng";
            }
        }

        // =========================================================================
        // BIỂU ĐỒ CỘT DOANH THU THEO THỜI GIAN
        // =========================================================================
        private async Task LoadChartDataAsync(DateTime fromDate, DateTime toDate)
        {
            try
            {
                string fromStr = fromDate.ToString("yyyy-MM-dd");
                string toStr = toDate.ToString("yyyy-MM-dd");

                var response = await ApiClientService.GetFromJsonWithAuthAsync<DailyChartResponseDto>($"reports/daily-revenue-chart?fromDate={fromStr}&toDate={toStr}");

                var series = chartDailyRevenue.Series.FindByName("Doanh thu (VNĐ)") 
                             ?? chartDailyRevenue.Series.FindByName("Doanh thu (VND)");

                if (series == null && chartDailyRevenue.Series.Count > 0)
                {
                    series = chartDailyRevenue.Series[0];
                }

                if (series != null)
                {
                    series.Points.Clear();

                    if (response != null && response.Data != null && response.Data.Count > 0)
                    {
                        foreach (var item in response.Data)
                        {
                            int pIdx = series.Points.AddXY(item.OrderDate, (double)item.TotalRevenue);
                            var dp = series.Points[pIdx];
                            dp.ToolTip = $"{item.OrderDate}: {item.TotalRevenue:N0} VNĐ ({item.TotalOrders} đơn)";
                            dp.Color = Color.FromArgb(37, 99, 235); // Tech blue #2563EB
                        }
                    }
                    else
                    {
                        series.Points.AddXY("Không có dữ liệu", 0);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi vẽ biểu đồ: " + ex.Message);
            }
        }

        // =========================================================================
        // TOP 5 SẢN PHẨM BÁN CHẠY NHẤT (BEST-SELLERS)
        // =========================================================================
        private async void btnRefreshTopSelling_Click(object sender, EventArgs e)
        {
            await LoadTopSellingAsync();
        }

        private async Task LoadTopSellingAsync()
        {
            btnRefreshTopSelling.Enabled = false;

            try
            {
                var response = await ApiClientService.GetFromJsonWithAuthAsync<TopProductsResponseDto>("reports/top-selling-products-linq");
                dgvTopSelling.DataSource = null;

                if (response != null && response.Data != null && response.Data.Count > 0)
                {
                    // Tạo danh sách hiển thị có huy hiệu Top 1 🥇, Top 2 🥈, Top 3 🥉
                    var displayList = response.Data.Select((item, index) =>
                    {
                        string rankBadge = index switch
                        {
                            0 => "🥇 Top 1",
                            1 => "🥈 Top 2",
                            2 => "🥉 Top 3",
                            _ => $"Top {index + 1}"
                        };

                        return new TopSellingDisplayDto
                        {
                            Rank = rankBadge,
                            ProductId = item.ProductId,
                            Barcode = item.Barcode,
                            ProductName = item.ProductName,
                            TotalSold = $"{item.TotalSold:N0}",
                            TotalSalesRevenue = $"{item.TotalSalesRevenue:N0} đ"
                        };
                    }).ToList();

                    dgvTopSelling.DataSource = displayList;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Lỗi nạp Top sản phẩm: " + ex.Message);
            }
            finally
            {
                btnRefreshTopSelling.Enabled = true;
            }
        }

        /// <summary>
        /// Tô màu nổi bật huy hiệu cho Top 1 (vàng kim), Top 2 (bạc), Top 3 (đồng)
        /// </summary>
        private void dgvTopSelling_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvTopSelling.Rows.Count) return;

            var row = dgvTopSelling.Rows[e.RowIndex];
            if (row.DataBoundItem is TopSellingDisplayDto item)
            {
                if (item.Rank.Contains("Top 1"))
                {
                    if (e.ColumnIndex == dgvTopSelling.Columns["Rank"]?.Index && e.CellStyle != null)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(254, 243, 199); // Amber 100
                        e.CellStyle.ForeColor = Color.FromArgb(180, 83, 9);   // Amber 700
                        e.CellStyle.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
                    }
                }
                else if (item.Rank.Contains("Top 2"))
                {
                    if (e.ColumnIndex == dgvTopSelling.Columns["Rank"]?.Index && e.CellStyle != null)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(241, 245, 249); // Slate 100
                        e.CellStyle.ForeColor = Color.FromArgb(71, 85, 105);   // Slate 600
                        e.CellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    }
                }
                else if (item.Rank.Contains("Top 3"))
                {
                    if (e.ColumnIndex == dgvTopSelling.Columns["Rank"]?.Index && e.CellStyle != null)
                    {
                        e.CellStyle.BackColor = Color.FromArgb(254, 237, 213); // Orange 100
                        e.CellStyle.ForeColor = Color.FromArgb(194, 65, 12);   // Orange 700
                        e.CellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    }
                }
            }
        }

        // =========================================================================
        // XUẤT BÁO CÁO HÓA ĐƠN & DOANH THU RA EXCEL / CSV (ClosedXML)
        // =========================================================================
        private void btnExportOrders_Click(object sender, EventArgs e)
        {
            var exportList = dgvDayOrders.DataSource as List<DayOrderDto> ?? _currentOrders;

            if (exportList.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu hóa đơn nào để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                decimal totalRevenue = exportList.Sum(x => x.FinalAmount);

                string defaultName = _isViewingAllOrders 
                    ? $"BaoCaoTatCaHoaDon_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                    : $"BaoCaoDoanhThu_{dtpReportFromDate.Value:yyyyMMdd}_{dtpReportToDate.Value:yyyyMMdd}_{DateTime.Now:HHmmss}.xlsx";

                using var sfd = new SaveFileDialog
                {
                    Title = "Chọn vị trí lưu báo cáo hóa đơn",
                    Filter = "Tệp Excel (*.xlsx)|*.xlsx|Tệp CSV (*.csv)|*.csv",
                    FileName = defaultName
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExcelExportHelper.ExportOrders(exportList, totalRevenue, sfd.FileName);
                    MessageBox.Show($"Đã xuất báo cáo doanh thu thành công ra tệp:\n{sfd.FileName}\n\n(Tổng cộng: {exportList.Count:N0} hóa đơn, Doanh thu: {totalRevenue:N0} VNĐ)",
                                    "Xuất báo cáo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất tệp báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
