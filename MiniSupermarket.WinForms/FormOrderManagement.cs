using MiniSupermarket.WinForms.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    /// <summary>
    /// Màn hình Quản lý Đơn hàng & Lịch sử thanh toán chuẩn giao diện siêu thị cao cấp
    /// Tự động thích ứng mọi độ phân giải DPI, chống tràn viền, không che khuất chữ
    /// </summary>
    public class FormOrderManagement : Form
    {
        // Dữ liệu đơn hàng
        private List<DayOrderDto> _allOrders = new();
        private List<DayOrderDto> _filteredOrders = new();
        private bool _isViewingAll = false;
        private readonly ToolTip _toolTip = new();

        // Container chính
        private Panel pnlMainContainer = null!;

        // 1. Thống kê KPI (4 thẻ tỷ lệ 25%)
        private TableLayoutPanel tlpKPI = null!;
        private Label lblKpiTotalOrders = null!;
        private Label lblKpiTotalRevenue = null!;
        private Label lblKpiTotalPoints = null!;
        private Label lblKpiLatest = null!;

        // 2. Khung bảng dữ liệu
        private Panel pnlTableWrapper = null!;

        // 2.1. Toolbar tầng 1 (Tìm kiếm & Bộ lọc ngày)
        private Panel pnlFilterRow1 = null!;
        private FlowLayoutPanel flpFilterLeft = null!;
        private Label lblSearch = null!;
        private TextBox txtSearch = null!;
        private Label lblFrom = null!;
        private DateTimePicker dtpFromDate = null!;
        private Label lblTo = null!;
        private DateTimePicker dtpToDate = null!;
        private Button btnFilter = null!;
        private Button btnToday = null!;
        private Button btnAll = null!;

        // 2.2. Toolbar tầng 2 (Thao tác nhanh & Tóm tắt số liệu)
        private Panel pnlActionRow2 = null!;
        private FlowLayoutPanel flpActionsLeft = null!;
        private Button btnViewDetail = null!;
        private Button btnPrintReceipt = null!;
        private Button btnExportExcel = null!;
        private Button btnRefresh = null!;
        private Label lblSummaryCount = null!;

        // 2.3. Lưới dữ liệu DataGridView & Footer
        private DataGridView dgvOrders = null!;
        private Panel pnlTableFooter = null!;
        private Label lblFooterHint = null!;

        public FormOrderManagement()
        {
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.Text = "QUẢN LÝ ĐƠN HÀNG & LỊCH SỬ THANH TOÁN";
            this.BackColor = Color.FromArgb(244, 247, 245); // Background xám nhạt hiện đại
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
            this.KeyPreview = true;

            pnlMainContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(12, 10, 12, 10),
                BackColor = Color.FromArgb(244, 247, 245)
            };

            // =========================================================================
            // 1. 4 THẺ KPI CHỈ SỐ GIAO DỊCH (2 DÒNG THÔNG THOÁNG, TUYỆT ĐỐI KHÔNG BỊ CẮT CHỮ)
            // =========================================================================
            tlpKPI = new TableLayoutPanel
            {
                Dock = DockStyle.Top,
                Height = 82,
                ColumnCount = 4,
                RowCount = 1,
                Margin = new Padding(0),
                Padding = new Padding(0, 0, 0, 8)
            };
            tlpKPI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKPI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKPI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKPI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpKPI.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            var kpi1 = CreateCleanKpiCard("TỔNG SỐ ĐƠN HÀNG", "0 Đơn", "🧾", Color.FromArgb(22, 163, 74), out lblKpiTotalOrders);
            var kpi2 = CreateCleanKpiCard("DOANH THU TỔNG", "0 đ", "💰", Color.FromArgb(37, 99, 235), out lblKpiTotalRevenue);
            var kpi3 = CreateCleanKpiCard("ĐIỂM TÍCH LŨY", "+0 Điểm", "🎁", Color.FromArgb(217, 119, 6), out lblKpiTotalPoints);
            var kpi4 = CreateCleanKpiCard("ĐƠN GẦN NHẤT", "Chưa có đơn", "⚡", Color.FromArgb(15, 118, 110), out lblKpiLatest);

            tlpKPI.Controls.Add(kpi1, 0, 0);
            tlpKPI.Controls.Add(kpi2, 1, 0);
            tlpKPI.Controls.Add(kpi3, 2, 0);
            tlpKPI.Controls.Add(kpi4, 3, 0);

            // =========================================================================
            // 2. KHUNG CHÍNH CHỨA BẢNG VÀ CÔNG CỤ (pnlTableWrapper)
            // =========================================================================
            pnlTableWrapper = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // -------------------------------------------------------------------------
            // 2.1. TOOLBAR TẦNG 1: TÌM KIẾM & BỘ LỌC NGÀY (Height 44px)
            // -------------------------------------------------------------------------
            pnlFilterRow1 = new Panel
            {
                Dock = DockStyle.Top,
                Height = 44,
                BackColor = Color.FromArgb(248, 250, 249),
                Padding = new Padding(10, 5, 10, 5)
            };

            flpFilterLeft = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                AutoScroll = false,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            lblSearch = new Label
            {
                Text = "🔍 Tìm:",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                AutoSize = true,
                Margin = new Padding(0, 7, 5, 0)
            };

            txtSearch = new TextBox
            {
                Size = new Size(180, 27),
                Font = new Font("Segoe UI", 9.5f),
                PlaceholderText = "Mã HĐ, Khách, SĐT...",
                Margin = new Padding(0, 3, 10, 0)
            };
            txtSearch.TextChanged += (s, e) => ApplyLocalFilter();

            lblFrom = new Label
            {
                Text = "Từ ngày:",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                AutoSize = true,
                Margin = new Padding(0, 7, 5, 0)
            };

            dtpFromDate = new DateTimePicker
            {
                Size = new Size(130, 27),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Value = DateTime.Today,
                Margin = new Padding(0, 3, 10, 0)
            };

            lblTo = new Label
            {
                Text = "Đến:",
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(71, 85, 105),
                AutoSize = true,
                Margin = new Padding(0, 7, 5, 0)
            };

            dtpToDate = new DateTimePicker
            {
                Size = new Size(130, 27),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Value = DateTime.Today,
                Margin = new Padding(0, 3, 10, 0)
            };

            btnFilter = new Button
            {
                Text = "⚡ Lọc",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(12, 3, 12, 3),
                BackColor = Color.FromArgb(37, 99, 235), // Tech Blue
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 2, 6, 0)
            };
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.Click += async (s, e) =>
            {
                _isViewingAll = false;
                await LoadOrdersAsync();
            };

            btnToday = new Button
            {
                Text = "Hôm nay",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(12, 3, 12, 3),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(30, 41, 59),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 2, 6, 0)
            };
            btnToday.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnToday.Click += async (s, e) =>
            {
                dtpFromDate.Value = DateTime.Today;
                dtpToDate.Value = DateTime.Today;
                _isViewingAll = false;
                await LoadOrdersAsync();
            };

            btnAll = new Button
            {
                Text = "Tất cả",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(12, 3, 12, 3),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(30, 41, 59),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 2, 0, 0)
            };
            btnAll.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnAll.Click += async (s, e) =>
            {
                _isViewingAll = true;
                await LoadOrdersAsync();
            };

            flpFilterLeft.Controls.AddRange(new Control[]
            {
                lblSearch, txtSearch,
                lblFrom, dtpFromDate,
                lblTo, dtpToDate,
                btnFilter, btnToday, btnAll
            });
            pnlFilterRow1.Controls.Add(flpFilterLeft);

            // -------------------------------------------------------------------------
            // 2.2. TOOLBAR TẦNG 2: THAO TÁC NHANH & TÓM TẮT (Height 46px - AutoSize Buttons)
            // -------------------------------------------------------------------------
            pnlActionRow2 = new Panel
            {
                Dock = DockStyle.Top,
                Height = 46,
                BackColor = Color.FromArgb(248, 250, 249),
                Padding = new Padding(10, 5, 14, 6)
            };
            Panel pnlActionDivider = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 1,
                BackColor = Color.FromArgb(226, 232, 240)
            };

            flpActionsLeft = new FlowLayoutPanel
            {
                Dock = DockStyle.Left,
                AutoSize = true,
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = false,
                Margin = new Padding(0),
                Padding = new Padding(0)
            };

            btnViewDetail = new Button
            {
                Text = "👁️ Xem chi tiết (F2)",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(12, 4, 12, 4),
                BackColor = Color.FromArgb(16, 42, 33), // Dark Emerald
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 2, 8, 0)
            };
            btnViewDetail.FlatAppearance.BorderSize = 0;
            btnViewDetail.Click += async (s, e) => await ShowSelectedOrderDetailAsync();

            btnPrintReceipt = new Button
            {
                Text = "🖨️ In lại K80 (F3)",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(12, 4, 12, 4),
                BackColor = Color.FromArgb(22, 163, 74), // Primary Green
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 2, 8, 0)
            };
            btnPrintReceipt.FlatAppearance.BorderSize = 0;
            btnPrintReceipt.Click += async (s, e) => await ReprintSelectedReceiptAsync();

            btnExportExcel = new Button
            {
                Text = "📊 Xuất Excel (F4)",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(12, 4, 12, 4),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(30, 41, 59),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 2, 8, 0)
            };
            btnExportExcel.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnExportExcel.Click += (s, e) => ExportExcel();

            btnRefresh = new Button
            {
                Text = "🔄 Làm mới (F5)",
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Padding = new Padding(12, 4, 12, 4),
                BackColor = Color.White,
                ForeColor = Color.FromArgb(30, 41, 59),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                Cursor = Cursors.Hand,
                Margin = new Padding(0, 2, 0, 0)
            };
            btnRefresh.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            btnRefresh.Click += async (s, e) => await LoadOrdersAsync();

            flpActionsLeft.Controls.AddRange(new Control[] { btnViewDetail, btnPrintReceipt, btnExportExcel, btnRefresh });

            lblSummaryCount = new Label
            {
                Text = "Tổng cộng: 0 đơn hàng  |  Doanh thu: 0 đ",
                Dock = DockStyle.Right,
                TextAlign = ContentAlignment.MiddleRight,
                AutoSize = true,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(22, 163, 74),
                Padding = new Padding(0, 7, 8, 0)
            };

            pnlActionRow2.Controls.AddRange(new Control[] { flpActionsLeft, lblSummaryCount, pnlActionDivider });

            // -------------------------------------------------------------------------
            // 2.3. BẢNG DATAGRIDVIEW CÂN ĐỐI FULL-WIDTH (KHÔNG WRAP CHỮ, KHÔNG CHE KHUẤT)
            // -------------------------------------------------------------------------
            dgvOrders = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                EnableHeadersVisualStyles = false
            };
            dgvOrders.CellDoubleClick += async (s, e) =>
            {
                if (e.RowIndex >= 0)
                {
                    await ShowSelectedOrderDetailAsync();
                }
            };
            dgvOrders.CellFormatting += DgvOrders_CellFormatting;
            dgvOrders.DataBindingComplete += (s, e) =>
            {
                dgvOrders.ClearSelection();
            };

            SetupGridColumns();

            // -------------------------------------------------------------------------
            // 2.4. FOOTER THANH TRẠNG THÁI
            // -------------------------------------------------------------------------
            pnlTableFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Color.FromArgb(248, 250, 249),
                Padding = new Padding(12, 5, 12, 5)
            };
            Panel pnlFooterTopBorder = new Panel
            {
                Dock = DockStyle.Top,
                Height = 1,
                BackColor = Color.FromArgb(226, 232, 240)
            };
            lblFooterHint = new Label
            {
                Text = "💡 Nhấp đúp vào dòng đơn hàng hoặc bấm 'Xem chi tiết' để xem từng món hàng và in lại hóa đơn nhiệt K80.",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                TextAlign = ContentAlignment.MiddleLeft
            };
            pnlTableFooter.Controls.AddRange(new Control[] { pnlFooterTopBorder, lblFooterHint });

            // Ráp các panel vào pnlTableWrapper
            pnlTableWrapper.Controls.Add(dgvOrders);
            pnlTableWrapper.Controls.Add(pnlTableFooter);
            pnlTableWrapper.Controls.Add(pnlActionRow2);
            pnlTableWrapper.Controls.Add(pnlFilterRow1);

            // Ráp vào Container chính
            pnlMainContainer.Controls.Add(pnlTableWrapper);
            pnlMainContainer.Controls.Add(tlpKPI);

            this.Controls.Add(pnlMainContainer);

            // Phím tắt thao tác nhanh
            this.KeyDown += async (s, e) =>
            {
                if (e.KeyCode == Keys.F2)
                {
                    e.Handled = true;
                    await ShowSelectedOrderDetailAsync();
                }
                else if (e.KeyCode == Keys.F3)
                {
                    e.Handled = true;
                    await ReprintSelectedReceiptAsync();
                }
                else if (e.KeyCode == Keys.F4)
                {
                    e.Handled = true;
                    ExportExcel();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    e.Handled = true;
                    await LoadOrdersAsync();
                }
                else if (e.KeyCode == Keys.Enter && dgvOrders.Focused)
                {
                    e.Handled = true;
                    await ShowSelectedOrderDetailAsync();
                }
            };

            this.Load += async (s, e) =>
            {
                ApplyGridCustomEnhancements();
                await LoadOrdersAsync();
            };
        }

        // =========================================================================
        // HÀM TẠO THẺ KPI 2 DÒNG THÔNG THOÁNG (KHÔNG BAO GIỜ BỊ CẮT CHÂN CHỮ)
        // =========================================================================
        private Panel CreateCleanKpiCard(
            string title, 
            string initialValue, 
            string icon, 
            Color accentColor, 
            out Label lblValue)
        {
            Panel card = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(0, 0, 6, 0)
            };

            // Dải màu nhấn 3px trên đỉnh card
            Panel pnlAccent = new Panel
            {
                Dock = DockStyle.Top,
                Height = 3,
                BackColor = accentColor
            };

            TableLayoutPanel tlpContent = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 1,
                Margin = new Padding(0),
                Padding = new Padding(6, 4, 6, 4)
            };
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 46F));
            tlpContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Label lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 18f),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                Margin = new Padding(0)
            };

            Panel pnlText = new Panel
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Padding = new Padding(2, 6, 2, 2)
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(100, 116, 139),
                Dock = DockStyle.Top,
                Height = 22,
                TextAlign = ContentAlignment.BottomLeft
            };

            lblValue = new Label
            {
                Text = initialValue,
                Font = new Font("Segoe UI", 13.5f, FontStyle.Bold),
                ForeColor = accentColor,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                AutoEllipsis = true
            };

            pnlText.Controls.Add(lblValue);
            pnlText.Controls.Add(lblTitle);

            tlpContent.Controls.Add(lblIcon, 0, 0);
            tlpContent.Controls.Add(pnlText, 1, 0);

            card.Controls.Add(tlpContent);
            card.Controls.Add(pnlAccent);

            return card;
        }

        // =========================================================================
        // THIẾT LẬP CỘT BẢNG DATAGRIDVIEW CÂN ĐỐI VÀ KHÔNG BỊ WRAP CẮT CHỮ
        // =========================================================================
        private void SetupGridColumns()
        {
            dgvOrders.Columns.Clear();

            // 1. ID
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OrderId",
                DataPropertyName = "OrderId",
                HeaderText = "ID",
                Width = 50,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 2. Mã hóa đơn (Rộng 175 để chứa trọn vẹn mã HD20261105-XXXXXX)
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "OrderCode",
                DataPropertyName = "OrderCode",
                HeaderText = "Mã hóa đơn",
                Width = 175,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(16, 42, 33)
                }
            });

            // 3. Thời gian thanh toán (Rộng 155 để hiển thị ngày và giờ đầy đủ không rớt dòng)
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Time",
                DataPropertyName = "Time",
                HeaderText = "Thời gian",
                Width = 155,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 4. Khách hàng (AutoSizeMode = Fill để lấp đầy toàn bộ khoảng trống ngang)
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CustomerName",
                DataPropertyName = "CustomerName",
                HeaderText = "Khách hàng",
                MinimumWidth = 140,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

            // 5. Thu ngân
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cashier",
                DataPropertyName = "Cashier",
                HeaderText = "Thu ngân",
                Width = 100,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 6. Số lượng món
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalItems",
                DataPropertyName = "TotalItems",
                HeaderText = "Số món",
                Width = 75,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            // 7. Tổng thanh toán
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "FinalAmount",
                DataPropertyName = "FinalAmount",
                HeaderText = "Tổng thanh toán",
                Width = 145,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(22, 163, 74)
                }
            });

            // 8. Điểm cộng
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "RewardPoints",
                DataPropertyName = "RewardPoints",
                HeaderText = "Điểm cộng",
                Width = 95,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(217, 119, 6)
                }
            });

            // 9. Trạng thái (Rộng 120 để hiển thị trọn chữ ✓ Hoàn tất)
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                DataPropertyName = "Status",
                HeaderText = "Trạng thái",
                Width = 120,
                DefaultCellStyle =
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(22, 163, 74),
                    Font = new Font("Segoe UI", 9f, FontStyle.Bold)
                }
            });
        }

        private void ApplyGridCustomEnhancements()
        {
            dgvOrders.RowTemplate.Height = 38;
            dgvOrders.ColumnHeadersHeight = 42;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Tiêu đề bảng không bao giờ bị rớt dòng (No Wrap), không bị xanh khi chọn ô
            dgvOrders.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(241, 245, 249);
            dgvOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvOrders.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(241, 245, 249);
            dgvOrders.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            dgvOrders.ColumnHeadersDefaultCellStyle.Padding = new Padding(6, 0, 6, 0);
            dgvOrders.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Row selection xanh dịu mắt
            dgvOrders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(220, 252, 231);
            dgvOrders.DefaultCellStyle.SelectionForeColor = Color.FromArgb(20, 83, 45);
            dgvOrders.DefaultCellStyle.Font = new Font("Segoe UI", 9.5f);

            dgvOrders.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 252, 251);
        }

        // =========================================================================
        // TẢI DỮ LIỆU ĐƠN HÀNG TỪ MÁY CHỦ API
        // =========================================================================
        public async Task LoadOrdersAsync()
        {
            try
            {
                lblFooterHint.Text = "⏳ Đang tải danh sách đơn hàng thanh toán...";
                lblFooterHint.ForeColor = Color.SteelBlue;

                string endpoint;
                if (_isViewingAll)
                {
                    endpoint = "reports/orders?all=true";
                }
                else
                {
                    string fDate = dtpFromDate.Value.ToString("yyyy-MM-dd");
                    string tDate = dtpToDate.Value.ToString("yyyy-MM-dd");
                    endpoint = $"reports/orders?fromDate={fDate}&toDate={tDate}";
                }

                var list = await ApiClientService.GetFromJsonWithAuthAsync<List<DayOrderDto>>(endpoint);
                _allOrders = list ?? new List<DayOrderDto>();

                ApplyLocalFilter();

                lblFooterHint.Text = $"✅ Đã tải thành công {_allOrders.Count:N0} đơn hàng từ hệ thống. Nhấp đúp vào dòng đơn hàng để xem chi tiết hoặc in lại K80.";
                lblFooterHint.ForeColor = Color.FromArgb(22, 163, 74);
            }
            catch (Exception ex)
            {
                lblFooterHint.Text = "❌ Lỗi: " + ex.Message;
                lblFooterHint.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi kết nối khi tải danh sách đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyLocalFilter()
        {
            string search = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(search))
            {
                _filteredOrders = new List<DayOrderDto>(_allOrders);
            }
            else
            {
                _filteredOrders = _allOrders.Where(o =>
                    (!string.IsNullOrEmpty(o.OrderCode) && o.OrderCode.ToLower().Contains(search)) ||
                    (!string.IsNullOrEmpty(o.CustomerName) && o.CustomerName.ToLower().Contains(search)) ||
                    (!string.IsNullOrEmpty(o.Cashier) && o.Cashier.ToLower().Contains(search)) ||
                    o.OrderId.ToString().Contains(search)
                ).ToList();
            }

            dgvOrders.DataSource = null;
            dgvOrders.DataSource = _filteredOrders;

            // Bỏ chọn dòng đầu tiên để không bị tô xanh cả dòng khi vừa mở
            if (dgvOrders.Rows.Count > 0)
            {
                dgvOrders.ClearSelection();
            }

            UpdateKpiStats();
        }

        private void UpdateKpiStats()
        {
            int totalCount = _filteredOrders.Count;
            decimal totalRev = _filteredOrders.Sum(x => x.FinalAmount);
            int totalPts = _filteredOrders.Sum(x => x.RewardPoints);

            lblKpiTotalOrders.Text = $"{totalCount:N0} Đơn";
            lblKpiTotalRevenue.Text = $"{totalRev:N0} đ";
            lblKpiTotalPoints.Text = $"+{totalPts:N0} Điểm";

            if (_filteredOrders.Count > 0)
            {
                var latest = _filteredOrders[0];
                lblKpiLatest.Text = $"{latest.FinalAmount:N0} đ";
                _toolTip.SetToolTip(lblKpiLatest, $"Đơn gần nhất: {latest.OrderCode} | Lúc: {latest.Time}");
            }
            else
            {
                lblKpiLatest.Text = "0 đ";
                _toolTip.SetToolTip(lblKpiLatest, "Chưa có giao dịch");
            }

            lblSummaryCount.Text = $"Tổng cộng: {totalCount:N0} đơn hàng  |  Doanh thu: {totalRev:N0} đ";
        }

        private void DgvOrders_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvOrders.Rows.Count || e.Value == null) return;

            string colName = dgvOrders.Columns[e.ColumnIndex].Name;

            if (colName == "FinalAmount" && e.Value is decimal amount)
            {
                e.Value = $"{amount:N0} đ";
                e.FormattingApplied = true;
            }
            else if (colName == "RewardPoints" && e.Value is int pts)
            {
                e.Value = pts > 0 ? $"+{pts}" : "0";
                e.FormattingApplied = true;
            }
            else if (colName == "Status")
            {
                if (e.CellStyle != null)
                {
                    e.CellStyle.BackColor = Color.FromArgb(240, 253, 244); // Green 50
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);  // Green 600
                }
            }
        }

        // =========================================================================
        // XEM CHI TIẾT ĐƠN HÀNG (FormOrderDetailDialog)
        // =========================================================================
        private async Task ShowSelectedOrderDetailAsync()
        {
            if (dgvOrders.CurrentRow?.DataBoundItem is not DayOrderDto selectedOrder)
            {
                MessageBox.Show("Vui lòng chọn một đơn hàng từ bảng để xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                lblFooterHint.Text = $"⏳ Đang tải chi tiết đơn hàng [{selectedOrder.OrderCode}]...";
                lblFooterHint.ForeColor = Color.SteelBlue;

                var details = await ApiClientService.GetFromJsonWithAuthAsync<List<ReportOrderDetailDto>>($"reports/orders/{selectedOrder.OrderId}/details");
                if (details == null || details.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy sản phẩm chi tiết của đơn hàng '{selectedOrder.OrderCode}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                lblFooterHint.Text = $"✅ Đang xem chi tiết đơn hàng [{selectedOrder.OrderCode}].";
                lblFooterHint.ForeColor = Color.FromArgb(22, 163, 74);

                using var dialog = new FormOrderDetailDialog(selectedOrder, details);
                dialog.ShowDialog(this);
            }
            catch (Exception ex)
            {
                lblFooterHint.Text = "❌ Lỗi: " + ex.Message;
                lblFooterHint.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi khi tải chi tiết đơn hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // IN LẠI HÓA ĐƠN NHIỆT K80
        // =========================================================================
        private async Task ReprintSelectedReceiptAsync()
        {
            if (dgvOrders.CurrentRow?.DataBoundItem is not DayOrderDto selectedOrder)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng cần in lại hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var details = await ApiClientService.GetFromJsonWithAuthAsync<List<ReportOrderDetailDto>>($"reports/orders/{selectedOrder.OrderId}/details");
                if (details == null || details.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy chi tiết đơn hàng '{selectedOrder.OrderCode}'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var receiptData = new ReceiptData
                {
                    OrderCode = selectedOrder.OrderCode,
                    OrderDate = DateTime.TryParse(selectedOrder.Time, out var dt) ? dt : DateTime.Now,
                    CashierName = selectedOrder.Cashier,
                    CustomerName = selectedOrder.CustomerName,
                    RewardPointsAdded = selectedOrder.RewardPoints,
                    GrossAmount = selectedOrder.FinalAmount,
                    FinalAmount = selectedOrder.FinalAmount,
                    CashReceived = selectedOrder.FinalAmount,
                    ChangeAmount = 0,
                    PaymentMethod = "Tiền mặt / Chuyển khoản (Đã thanh toán)",
                    Items = details.Select(d => new ReceiptItemData
                    {
                        ProductName = d.ProductName,
                        Quantity = d.Quantity,
                        UnitPrice = d.UnitPrice
                    }).ToList()
                };

                using var receiptDlg = new FormReceiptDialog(receiptData);
                receiptDlg.ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi in hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // XUẤT EXCEL DANH SÁCH ĐƠN HÀNG
        // =========================================================================
        private void ExportExcel()
        {
            if (_filteredOrders.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu đơn hàng để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx|CSV file (*.csv)|*.csv",
                FileName = $"DanhSachDonHang_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    decimal totalRev = _filteredOrders.Sum(x => x.FinalAmount);
                    ExcelExportHelper.ExportOrders(_filteredOrders, totalRev, sfd.FileName);
                    MessageBox.Show($"Đã xuất thành công {_filteredOrders.Count} đơn hàng ra tệp:\n{sfd.FileName}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
