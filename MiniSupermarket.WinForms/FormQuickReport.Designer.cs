namespace MiniSupermarket.WinForms
{
    partial class FormQuickReport
    {
        private System.ComponentModel.IContainer components = null;

        // Container chính
        private System.Windows.Forms.Panel pnlMainContainer;

        // Top Header & Bộ lọc tổng hợp
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblBreadcrumb;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblLiveBadge;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.FlowLayoutPanel pnlTopActions;
        private System.Windows.Forms.Label lblDateFromLabel;
        private System.Windows.Forms.DateTimePicker dtpReportFromDate;
        private System.Windows.Forms.Label lblDateToLabel;
        private System.Windows.Forms.DateTimePicker dtpReportToDate;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnYesterday;
        private System.Windows.Forms.Button btnChart7Days;
        private System.Windows.Forms.Button btnChart30Days;
        private System.Windows.Forms.Button btnChartThisMonth;
        private System.Windows.Forms.Button btnAllOrders;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Button btnExportOrders;

        // 6 Thẻ KPI Responsive (TableLayoutPanel 6 cột: 16.66667% mỗi cột)
        private System.Windows.Forms.TableLayoutPanel tlpCards;

        // Card 1: Doanh thu
        private System.Windows.Forms.Panel panelCard1;
        private System.Windows.Forms.Panel pnlCard1Accent;
        private System.Windows.Forms.Panel pnlIconRevenue;
        private System.Windows.Forms.Label lblIconRevenue;
        private System.Windows.Forms.Label lblTitleRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblRevenueSubtitle;

        // Card 2: Đơn hàng
        private System.Windows.Forms.Panel panelCard2;
        private System.Windows.Forms.Panel pnlCard2Accent;
        private System.Windows.Forms.Panel pnlIconOrders;
        private System.Windows.Forms.Label lblIconOrders;
        private System.Windows.Forms.Label lblTitleOrders;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblOrdersSubtitle;

        // Card 3: Giá trị TB/đơn AOV
        private System.Windows.Forms.Panel panelCard3;
        private System.Windows.Forms.Panel pnlCard3Accent;
        private System.Windows.Forms.Panel pnlIconAvg;
        private System.Windows.Forms.Label lblIconAvg;
        private System.Windows.Forms.Label lblTitleAvg;
        private System.Windows.Forms.Label lblAvgOrderValue;
        private System.Windows.Forms.Label lblAvgSubtitle;

        // Card 4: Khách hàng
        private System.Windows.Forms.Panel panelCard4;
        private System.Windows.Forms.Panel pnlCard4Accent;
        private System.Windows.Forms.Panel pnlIconCustomers;
        private System.Windows.Forms.Label lblIconCustomers;
        private System.Windows.Forms.Label lblTitleCustomers;
        private System.Windows.Forms.Label lblTotalCustomers;
        private System.Windows.Forms.Label lblCustomersSubtitle;

        // Card 5: Điểm tích lũy
        private System.Windows.Forms.Panel panelCard5;
        private System.Windows.Forms.Panel pnlCard5Accent;
        private System.Windows.Forms.Panel pnlIconPoints;
        private System.Windows.Forms.Label lblIconPoints;
        private System.Windows.Forms.Label lblTitlePoints;
        private System.Windows.Forms.Label lblRewardPoints;
        private System.Windows.Forms.Label lblPointsSubtitle;

        // Card 6: Cảnh báo kho
        private System.Windows.Forms.Panel panelCard6;
        private System.Windows.Forms.Panel pnlCard6Accent;
        private System.Windows.Forms.Panel pnlIconLowStock;
        private System.Windows.Forms.Label lblIconLowStock;
        private System.Windows.Forms.Label lblTitleLowStock;
        private System.Windows.Forms.Label lblLowStockCount;
        private System.Windows.Forms.Label lblLowStockSubtitle;

        // Segmented Control Tab Navigation
        private System.Windows.Forms.Panel pnlTabNav;
        private System.Windows.Forms.Button btnNavOrders;
        private System.Windows.Forms.Button btnNavChart;
        private System.Windows.Forms.Button btnNavTopSelling;

        // TabControl phân chia 3 chức năng báo cáo
        private System.Windows.Forms.TabControl tabControlReport;
        private System.Windows.Forms.TabPage tabOrders;
        private System.Windows.Forms.TabPage tabChart;
        private System.Windows.Forms.TabPage tabTopSelling;

        // Tab 1: Danh sách hóa đơn
        private System.Windows.Forms.Panel pnlOrdersToolbar;
        private System.Windows.Forms.Label lblSearchOrder;
        private System.Windows.Forms.TextBox txtSearchOrder;
        private System.Windows.Forms.Label lblStatusFilterLabel;
        private System.Windows.Forms.ComboBox cboStatusFilter;
        private System.Windows.Forms.Label lblViewStatus;
        private System.Windows.Forms.Button btnViewOrderDetails;
        private System.Windows.Forms.DataGridView dgvDayOrders;
        private System.Windows.Forms.Panel pnlOrdersSummary;
        private System.Windows.Forms.Label lblOrdersSummaryCount;
        private System.Windows.Forms.Label lblOrdersSummaryRevenue;
        private System.Windows.Forms.Label lblOrdersSummaryAvg;
        private System.Windows.Forms.Label lblOrdersSummaryItems;
        private System.Windows.Forms.Label lblOrdersSummaryFilter;

        // Tab 2: Biểu đồ doanh thu & cơ cấu khách hàng
        private System.Windows.Forms.SplitContainer scChartSplit;
        private System.Windows.Forms.Panel pnlRevenueHeader;
        private System.Windows.Forms.Label lblRevenueChartTitle;
        private System.Windows.Forms.Label lblRevenueChartSub;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDailyRevenue;

        private System.Windows.Forms.Panel pnlRatioHeader;
        private System.Windows.Forms.Label lblRatioChartTitle;
        private System.Windows.Forms.Label lblRatioChartSub;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCustomerRatio;

        // Tab 3: Top 5 sản phẩm bán chạy
        private System.Windows.Forms.Panel pnlTopSellingHeader;
        private System.Windows.Forms.Label lblTopSellingTitle;
        private System.Windows.Forms.Label lblTopSellingSubtitle;
        private System.Windows.Forms.Button btnRefreshTopSelling;
        private System.Windows.Forms.DataGridView dgvTopSelling;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvAltRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvTopHeaderStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvTopRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvTopAltRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();

            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblBreadcrumb = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblLiveBadge = new System.Windows.Forms.Label();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.pnlTopActions = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDateFromLabel = new System.Windows.Forms.Label();
            this.dtpReportFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblDateToLabel = new System.Windows.Forms.Label();
            this.dtpReportToDate = new System.Windows.Forms.DateTimePicker();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnYesterday = new System.Windows.Forms.Button();
            this.btnChart7Days = new System.Windows.Forms.Button();
            this.btnChart30Days = new System.Windows.Forms.Button();
            this.btnChartThisMonth = new System.Windows.Forms.Button();
            this.btnAllOrders = new System.Windows.Forms.Button();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.btnExportOrders = new System.Windows.Forms.Button();

            // 6 Thẻ KPI
            this.tlpCards = new System.Windows.Forms.TableLayoutPanel();

            // Card 1: Doanh thu
            this.panelCard1 = new System.Windows.Forms.Panel();
            this.pnlCard1Accent = new System.Windows.Forms.Panel();
            this.pnlIconRevenue = new System.Windows.Forms.Panel();
            this.lblIconRevenue = new System.Windows.Forms.Label();
            this.lblTitleRevenue = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblRevenueSubtitle = new System.Windows.Forms.Label();

            // Card 2: Đơn hàng
            this.panelCard2 = new System.Windows.Forms.Panel();
            this.pnlCard2Accent = new System.Windows.Forms.Panel();
            this.pnlIconOrders = new System.Windows.Forms.Panel();
            this.lblIconOrders = new System.Windows.Forms.Label();
            this.lblTitleOrders = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblOrdersSubtitle = new System.Windows.Forms.Label();

            // Card 3: Giá trị TB/đơn AOV
            this.panelCard3 = new System.Windows.Forms.Panel();
            this.pnlCard3Accent = new System.Windows.Forms.Panel();
            this.pnlIconAvg = new System.Windows.Forms.Panel();
            this.lblIconAvg = new System.Windows.Forms.Label();
            this.lblTitleAvg = new System.Windows.Forms.Label();
            this.lblAvgOrderValue = new System.Windows.Forms.Label();
            this.lblAvgSubtitle = new System.Windows.Forms.Label();

            // Card 4: Khách hàng
            this.panelCard4 = new System.Windows.Forms.Panel();
            this.pnlCard4Accent = new System.Windows.Forms.Panel();
            this.pnlIconCustomers = new System.Windows.Forms.Panel();
            this.lblIconCustomers = new System.Windows.Forms.Label();
            this.lblTitleCustomers = new System.Windows.Forms.Label();
            this.lblTotalCustomers = new System.Windows.Forms.Label();
            this.lblCustomersSubtitle = new System.Windows.Forms.Label();

            // Card 5: Điểm tích lũy
            this.panelCard5 = new System.Windows.Forms.Panel();
            this.pnlCard5Accent = new System.Windows.Forms.Panel();
            this.pnlIconPoints = new System.Windows.Forms.Panel();
            this.lblIconPoints = new System.Windows.Forms.Label();
            this.lblTitlePoints = new System.Windows.Forms.Label();
            this.lblRewardPoints = new System.Windows.Forms.Label();
            this.lblPointsSubtitle = new System.Windows.Forms.Label();

            // Card 6: Cảnh báo tồn kho
            this.panelCard6 = new System.Windows.Forms.Panel();
            this.pnlCard6Accent = new System.Windows.Forms.Panel();
            this.pnlIconLowStock = new System.Windows.Forms.Panel();
            this.lblIconLowStock = new System.Windows.Forms.Label();
            this.lblTitleLowStock = new System.Windows.Forms.Label();
            this.lblLowStockCount = new System.Windows.Forms.Label();
            this.lblLowStockSubtitle = new System.Windows.Forms.Label();

            // Segmented Tab Navigation
            this.pnlTabNav = new System.Windows.Forms.Panel();
            this.btnNavOrders = new System.Windows.Forms.Button();
            this.btnNavChart = new System.Windows.Forms.Button();
            this.btnNavTopSelling = new System.Windows.Forms.Button();

            // TabControl & TabPages
            this.tabControlReport = new System.Windows.Forms.TabControl();
            this.tabOrders = new System.Windows.Forms.TabPage();
            this.pnlOrdersToolbar = new System.Windows.Forms.Panel();
            this.lblSearchOrder = new System.Windows.Forms.Label();
            this.txtSearchOrder = new System.Windows.Forms.TextBox();
            this.lblStatusFilterLabel = new System.Windows.Forms.Label();
            this.cboStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblViewStatus = new System.Windows.Forms.Label();
            this.btnViewOrderDetails = new System.Windows.Forms.Button();
            this.dgvDayOrders = new System.Windows.Forms.DataGridView();
            this.pnlOrdersSummary = new System.Windows.Forms.Panel();
            this.lblOrdersSummaryCount = new System.Windows.Forms.Label();
            this.lblOrdersSummaryRevenue = new System.Windows.Forms.Label();
            this.lblOrdersSummaryAvg = new System.Windows.Forms.Label();
            this.lblOrdersSummaryItems = new System.Windows.Forms.Label();
            this.lblOrdersSummaryFilter = new System.Windows.Forms.Label();

            this.tabChart = new System.Windows.Forms.TabPage();
            this.scChartSplit = new System.Windows.Forms.SplitContainer();
            this.pnlRevenueHeader = new System.Windows.Forms.Panel();
            this.lblRevenueChartTitle = new System.Windows.Forms.Label();
            this.lblRevenueChartSub = new System.Windows.Forms.Label();
            this.chartDailyRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlRatioHeader = new System.Windows.Forms.Panel();
            this.lblRatioChartTitle = new System.Windows.Forms.Label();
            this.lblRatioChartSub = new System.Windows.Forms.Label();
            this.chartCustomerRatio = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.tabTopSelling = new System.Windows.Forms.TabPage();
            this.dgvTopSelling = new System.Windows.Forms.DataGridView();
            this.pnlTopSellingHeader = new System.Windows.Forms.Panel();
            this.lblTopSellingTitle = new System.Windows.Forms.Label();
            this.lblTopSellingSubtitle = new System.Windows.Forms.Label();
            this.btnRefreshTopSelling = new System.Windows.Forms.Button();

            this.pnlMainContainer.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.pnlTopActions.SuspendLayout();
            this.tlpCards.SuspendLayout();

            this.panelCard1.SuspendLayout();
            this.pnlIconRevenue.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.pnlIconOrders.SuspendLayout();
            this.panelCard3.SuspendLayout();
            this.pnlIconAvg.SuspendLayout();
            this.panelCard4.SuspendLayout();
            this.pnlIconCustomers.SuspendLayout();
            this.panelCard5.SuspendLayout();
            this.pnlIconPoints.SuspendLayout();
            this.panelCard6.SuspendLayout();
            this.pnlIconLowStock.SuspendLayout();

            this.pnlTabNav.SuspendLayout();
            this.tabControlReport.SuspendLayout();
            this.tabOrders.SuspendLayout();
            this.pnlOrdersToolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDayOrders)).BeginInit();
            this.pnlOrdersSummary.SuspendLayout();

            this.tabChart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scChartSplit)).BeginInit();
            this.scChartSplit.Panel1.SuspendLayout();
            this.scChartSplit.Panel2.SuspendLayout();
            this.scChartSplit.SuspendLayout();
            this.pnlRevenueHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyRevenue)).BeginInit();
            this.pnlRatioHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomerRatio)).BeginInit();

            this.tabTopSelling.SuspendLayout();
            this.pnlTopSellingHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSelling)).BeginInit();
            this.SuspendLayout();

            // 
            // FormQuickReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 251); // Clean SaaS background
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlMainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(980, 620);
            this.Name = "FormQuickReport";
            this.Text = "BÁO CÁO DOANH THU & HIỆU SUẤT";
            this.Load += new System.EventHandler(this.FormQuickReport_Load);

            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(245, 247, 251);
            this.pnlMainContainer.Controls.Add(this.tabControlReport);
            this.pnlMainContainer.Controls.Add(this.pnlTabNav);
            this.pnlMainContainer.Controls.Add(this.tlpCards);
            this.pnlMainContainer.Controls.Add(this.pnlTopBar);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Padding = new System.Windows.Forms.Padding(16, 12, 16, 12);
            this.pnlMainContainer.Size = new System.Drawing.Size(1200, 750);
            this.pnlMainContainer.TabIndex = 0;

            // 
            // pnlTopBar (Header & Bộ lọc tổng hợp)
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.pnlTopActions);
            this.pnlTopBar.Controls.Add(this.lblHeaderSubtitle);
            this.pnlTopBar.Controls.Add(this.lblLiveBadge);
            this.pnlTopBar.Controls.Add(this.lblHeaderTitle);
            this.pnlTopBar.Controls.Add(this.lblBreadcrumb);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(16, 12);
            this.pnlTopBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1168, 78);
            this.pnlTopBar.TabIndex = 0;

            // lblBreadcrumb
            this.lblBreadcrumb.AutoSize = true;
            this.lblBreadcrumb.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBreadcrumb.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblBreadcrumb.Location = new System.Drawing.Point(14, 7);
            this.lblBreadcrumb.Name = "lblBreadcrumb";
            this.lblBreadcrumb.Size = new System.Drawing.Size(210, 19);
            this.lblBreadcrumb.Text = "Hệ thống quản lý / Báo cáo thống kê";

            // lblHeaderTitle
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42); // Navy 900
            this.lblHeaderTitle.Location = new System.Drawing.Point(13, 26);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(370, 31);
            this.lblHeaderTitle.Text = "Báo cáo doanh thu & hiệu suất";
            this.lblHeaderTitle.UseMnemonic = false;

            // lblLiveBadge
            this.lblLiveBadge.BackColor = System.Drawing.Color.FromArgb(236, 253, 245); // Emerald 50
            this.lblLiveBadge.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblLiveBadge.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129); // Emerald 600
            this.lblLiveBadge.Location = new System.Drawing.Point(375, 30);
            this.lblLiveBadge.Name = "lblLiveBadge";
            this.lblLiveBadge.Size = new System.Drawing.Size(100, 22);
            this.lblLiveBadge.Text = "● Real-time Sync";
            this.lblLiveBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblHeaderSubtitle
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(14, 55);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(380, 20);
            this.lblHeaderSubtitle.Text = "Theo dõi doanh thu, đơn hàng & hiệu quả kinh doanh đa chiều";

            // pnlTopActions (Thanh bộ lọc date range & nút thao tác)
            this.pnlTopActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTopActions.Controls.Add(this.lblDateFromLabel);
            this.pnlTopActions.Controls.Add(this.dtpReportFromDate);
            this.pnlTopActions.Controls.Add(this.lblDateToLabel);
            this.pnlTopActions.Controls.Add(this.dtpReportToDate);
            this.pnlTopActions.Controls.Add(this.btnToday);
            this.pnlTopActions.Controls.Add(this.btnYesterday);
            this.pnlTopActions.Controls.Add(this.btnChart7Days);
            this.pnlTopActions.Controls.Add(this.btnChart30Days);
            this.pnlTopActions.Controls.Add(this.btnChartThisMonth);
            this.pnlTopActions.Controls.Add(this.btnAllOrders);
            this.pnlTopActions.Controls.Add(this.btnRunReport);
            this.pnlTopActions.Controls.Add(this.btnExportOrders);
            this.pnlTopActions.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
            this.pnlTopActions.Location = new System.Drawing.Point(485, 6);
            this.pnlTopActions.Name = "pnlTopActions";
            this.pnlTopActions.Size = new System.Drawing.Size(675, 66);
            this.pnlTopActions.TabIndex = 0;
            this.pnlTopActions.WrapContents = true;

            // lblDateFromLabel
            this.lblDateFromLabel.AutoSize = true;
            this.lblDateFromLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDateFromLabel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDateFromLabel.Margin = new System.Windows.Forms.Padding(0, 6, 2, 0);
            this.lblDateFromLabel.Name = "lblDateFromLabel";
            this.lblDateFromLabel.Size = new System.Drawing.Size(29, 20);
            this.lblDateFromLabel.Text = "Từ:";

            // dtpReportFromDate
            this.dtpReportFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReportFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReportFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportFromDate.Margin = new System.Windows.Forms.Padding(0, 2, 6, 2);
            this.dtpReportFromDate.Name = "dtpReportFromDate";
            this.dtpReportFromDate.Size = new System.Drawing.Size(102, 27);
            this.dtpReportFromDate.TabIndex = 1;

            // lblDateToLabel
            this.lblDateToLabel.AutoSize = true;
            this.lblDateToLabel.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDateToLabel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDateToLabel.Margin = new System.Windows.Forms.Padding(0, 6, 2, 0);
            this.lblDateToLabel.Name = "lblDateToLabel";
            this.lblDateToLabel.Size = new System.Drawing.Size(40, 20);
            this.lblDateToLabel.Text = "Đến:";

            // dtpReportToDate
            this.dtpReportToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReportToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReportToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportToDate.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this.dtpReportToDate.Name = "dtpReportToDate";
            this.dtpReportToDate.Size = new System.Drawing.Size(102, 27);
            this.dtpReportToDate.TabIndex = 2;

            // btnToday
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToday.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnToday.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnToday.Margin = new System.Windows.Forms.Padding(2, 2, 3, 2);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(68, 28);
            this.btnToday.TabIndex = 3;
            this.btnToday.Text = "Hôm nay";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);

            // btnYesterday
            this.btnYesterday.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnYesterday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYesterday.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnYesterday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYesterday.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnYesterday.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnYesterday.Margin = new System.Windows.Forms.Padding(2, 2, 3, 2);
            this.btnYesterday.Name = "btnYesterday";
            this.btnYesterday.Size = new System.Drawing.Size(66, 28);
            this.btnYesterday.TabIndex = 4;
            this.btnYesterday.Text = "Hôm qua";
            this.btnYesterday.UseVisualStyleBackColor = false;
            this.btnYesterday.Click += new System.EventHandler(this.btnYesterday_Click);

            // btnChart7Days
            this.btnChart7Days.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnChart7Days.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChart7Days.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnChart7Days.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChart7Days.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnChart7Days.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnChart7Days.Margin = new System.Windows.Forms.Padding(2, 2, 3, 2);
            this.btnChart7Days.Name = "btnChart7Days";
            this.btnChart7Days.Size = new System.Drawing.Size(56, 28);
            this.btnChart7Days.TabIndex = 5;
            this.btnChart7Days.Text = "7 ngày";
            this.btnChart7Days.UseVisualStyleBackColor = false;
            this.btnChart7Days.Click += new System.EventHandler(this.btnChart7Days_Click);

            // btnChart30Days
            this.btnChart30Days.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnChart30Days.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChart30Days.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnChart30Days.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChart30Days.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnChart30Days.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnChart30Days.Margin = new System.Windows.Forms.Padding(2, 2, 3, 2);
            this.btnChart30Days.Name = "btnChart30Days";
            this.btnChart30Days.Size = new System.Drawing.Size(62, 28);
            this.btnChart30Days.TabIndex = 6;
            this.btnChart30Days.Text = "30 ngày";
            this.btnChart30Days.UseVisualStyleBackColor = false;
            this.btnChart30Days.Click += new System.EventHandler(this.btnChart30Days_Click);

            // btnChartThisMonth
            this.btnChartThisMonth.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnChartThisMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChartThisMonth.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnChartThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChartThisMonth.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnChartThisMonth.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnChartThisMonth.Margin = new System.Windows.Forms.Padding(2, 2, 3, 2);
            this.btnChartThisMonth.Name = "btnChartThisMonth";
            this.btnChartThisMonth.Size = new System.Drawing.Size(72, 28);
            this.btnChartThisMonth.TabIndex = 7;
            this.btnChartThisMonth.Text = "Tháng này";
            this.btnChartThisMonth.UseVisualStyleBackColor = false;
            this.btnChartThisMonth.Click += new System.EventHandler(this.btnChartThisMonth_Click);

            // btnAllOrders
            this.btnAllOrders.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnAllOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAllOrders.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnAllOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAllOrders.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.btnAllOrders.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnAllOrders.Margin = new System.Windows.Forms.Padding(2, 2, 6, 2);
            this.btnAllOrders.Name = "btnAllOrders";
            this.btnAllOrders.Size = new System.Drawing.Size(56, 28);
            this.btnAllOrders.TabIndex = 8;
            this.btnAllOrders.Text = "Tất cả";
            this.btnAllOrders.UseVisualStyleBackColor = false;
            this.btnAllOrders.Click += new System.EventHandler(this.btnAllOrders_Click);

            // btnRunReport
            this.btnRunReport.BackColor = System.Drawing.Color.FromArgb(37, 99, 235); // Primary Tech Blue
            this.btnRunReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunReport.FlatAppearance.BorderSize = 0;
            this.btnRunReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunReport.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRunReport.ForeColor = System.Drawing.Color.White;
            this.btnRunReport.Margin = new System.Windows.Forms.Padding(4, 1, 4, 2);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(86, 30);
            this.btnRunReport.TabIndex = 9;
            this.btnRunReport.Text = "⚡ Lọc";
            this.btnRunReport.UseVisualStyleBackColor = false;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);

            // btnExportOrders
            this.btnExportOrders.BackColor = System.Drawing.Color.FromArgb(16, 185, 129); // Success Emerald
            this.btnExportOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportOrders.FlatAppearance.BorderSize = 0;
            this.btnExportOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportOrders.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportOrders.ForeColor = System.Drawing.Color.White;
            this.btnExportOrders.Margin = new System.Windows.Forms.Padding(4, 1, 2, 2);
            this.btnExportOrders.Name = "btnExportOrders";
            this.btnExportOrders.Size = new System.Drawing.Size(96, 30);
            this.btnExportOrders.TabIndex = 10;
            this.btnExportOrders.Text = "📥 Xuất Excel";
            this.btnExportOrders.UseVisualStyleBackColor = false;
            this.btnExportOrders.Click += new System.EventHandler(this.btnExportOrders_Click);

            // 
            // tlpCards (6 Thẻ KPI Responsive - 16.66667% mỗi cột)
            // 
            this.tlpCards.ColumnCount = 6;
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpCards.Controls.Add(this.panelCard1, 0, 0);
            this.tlpCards.Controls.Add(this.panelCard2, 1, 0);
            this.tlpCards.Controls.Add(this.panelCard3, 2, 0);
            this.tlpCards.Controls.Add(this.panelCard4, 3, 0);
            this.tlpCards.Controls.Add(this.panelCard5, 4, 0);
            this.tlpCards.Controls.Add(this.panelCard6, 5, 0);
            this.tlpCards.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpCards.Location = new System.Drawing.Point(16, 96);
            this.tlpCards.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.tlpCards.Name = "tlpCards";
            this.tlpCards.RowCount = 1;
            this.tlpCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCards.Size = new System.Drawing.Size(1168, 88);
            this.tlpCards.TabIndex = 1;

            // -------------------------------------------------------------
            // Card 1: Tổng Doanh thu (Primary Tech Blue)
            // -------------------------------------------------------------
            this.panelCard1.BackColor = System.Drawing.Color.White;
            this.panelCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard1.Controls.Add(this.lblRevenueSubtitle);
            this.panelCard1.Controls.Add(this.lblTotalRevenue);
            this.panelCard1.Controls.Add(this.lblTitleRevenue);
            this.panelCard1.Controls.Add(this.pnlIconRevenue);
            this.panelCard1.Controls.Add(this.pnlCard1Accent);
            this.panelCard1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard1.Location = new System.Drawing.Point(0, 4);
            this.panelCard1.Margin = new System.Windows.Forms.Padding(0, 4, 5, 4);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(189, 80);
            this.panelCard1.TabIndex = 0;

            this.pnlCard1Accent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlCard1Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCard1Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlCard1Accent.Name = "pnlCard1Accent";
            this.pnlCard1Accent.Size = new System.Drawing.Size(187, 3);
            this.pnlCard1Accent.TabIndex = 0;

            this.pnlIconRevenue.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.pnlIconRevenue.Controls.Add(this.lblIconRevenue);
            this.pnlIconRevenue.Location = new System.Drawing.Point(8, 12);
            this.pnlIconRevenue.Name = "pnlIconRevenue";
            this.pnlIconRevenue.Size = new System.Drawing.Size(32, 32);
            this.pnlIconRevenue.TabIndex = 1;

            this.lblIconRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconRevenue.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblIconRevenue.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblIconRevenue.Location = new System.Drawing.Point(0, 0);
            this.lblIconRevenue.Name = "lblIconRevenue";
            this.lblIconRevenue.Size = new System.Drawing.Size(32, 32);
            this.lblIconRevenue.Text = "💰";
            this.lblIconRevenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTitleRevenue.AutoSize = true;
            this.lblTitleRevenue.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleRevenue.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleRevenue.Location = new System.Drawing.Point(44, 11);
            this.lblTitleRevenue.Name = "lblTitleRevenue";
            this.lblTitleRevenue.Size = new System.Drawing.Size(115, 17);
            this.lblTitleRevenue.Text = "TỔNG DOANH THU";

            this.lblTotalRevenue.AutoEllipsis = true;
            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblTotalRevenue.Location = new System.Drawing.Point(44, 28);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(138, 28);
            this.lblTotalRevenue.Text = "0 đ";

            this.lblRevenueSubtitle.AutoSize = true;
            this.lblRevenueSubtitle.Font = new System.Drawing.Font("Segoe UI", 7.2F);
            this.lblRevenueSubtitle.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblRevenueSubtitle.Location = new System.Drawing.Point(8, 56);
            this.lblRevenueSubtitle.Name = "lblRevenueSubtitle";
            this.lblRevenueSubtitle.Size = new System.Drawing.Size(125, 15);
            this.lblRevenueSubtitle.Text = "● Thực thu kỳ đang chọn";

            // -------------------------------------------------------------
            // Card 2: Tổng Đơn hàng (Emerald Green)
            // -------------------------------------------------------------
            this.panelCard2.BackColor = System.Drawing.Color.White;
            this.panelCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard2.Controls.Add(this.lblOrdersSubtitle);
            this.panelCard2.Controls.Add(this.lblTotalOrders);
            this.panelCard2.Controls.Add(this.lblTitleOrders);
            this.panelCard2.Controls.Add(this.pnlIconOrders);
            this.panelCard2.Controls.Add(this.pnlCard2Accent);
            this.panelCard2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard2.Location = new System.Drawing.Point(194, 4);
            this.panelCard2.Margin = new System.Windows.Forms.Padding(0, 4, 5, 4);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Size = new System.Drawing.Size(189, 80);
            this.panelCard2.TabIndex = 1;

            this.pnlCard2Accent.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.pnlCard2Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCard2Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlCard2Accent.Name = "pnlCard2Accent";
            this.pnlCard2Accent.Size = new System.Drawing.Size(187, 3);
            this.pnlCard2Accent.TabIndex = 0;

            this.pnlIconOrders.BackColor = System.Drawing.Color.FromArgb(236, 253, 245);
            this.pnlIconOrders.Controls.Add(this.lblIconOrders);
            this.pnlIconOrders.Location = new System.Drawing.Point(8, 12);
            this.pnlIconOrders.Name = "pnlIconOrders";
            this.pnlIconOrders.Size = new System.Drawing.Size(32, 32);
            this.pnlIconOrders.TabIndex = 1;

            this.lblIconOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconOrders.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblIconOrders.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblIconOrders.Location = new System.Drawing.Point(0, 0);
            this.lblIconOrders.Name = "lblIconOrders";
            this.lblIconOrders.Size = new System.Drawing.Size(32, 32);
            this.lblIconOrders.Text = "🧾";
            this.lblIconOrders.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTitleOrders.AutoSize = true;
            this.lblTitleOrders.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleOrders.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleOrders.Location = new System.Drawing.Point(44, 11);
            this.lblTitleOrders.Name = "lblTitleOrders";
            this.lblTitleOrders.Size = new System.Drawing.Size(107, 17);
            this.lblTitleOrders.Text = "TỔNG ĐƠN HÀNG";

            this.lblTotalOrders.AutoEllipsis = true;
            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblTotalOrders.Location = new System.Drawing.Point(44, 28);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(138, 28);
            this.lblTotalOrders.Text = "0";

            this.lblOrdersSubtitle.AutoSize = true;
            this.lblOrdersSubtitle.Font = new System.Drawing.Font("Segoe UI", 7.2F);
            this.lblOrdersSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblOrdersSubtitle.Location = new System.Drawing.Point(8, 56);
            this.lblOrdersSubtitle.Name = "lblOrdersSubtitle";
            this.lblOrdersSubtitle.Size = new System.Drawing.Size(115, 15);
            this.lblOrdersSubtitle.Text = "✓ 100% hoàn tất chốt";

            // -------------------------------------------------------------
            // Card 3: Giá trị TB/đơn AOV (Purple)
            // -------------------------------------------------------------
            this.panelCard3.BackColor = System.Drawing.Color.White;
            this.panelCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard3.Controls.Add(this.lblAvgSubtitle);
            this.panelCard3.Controls.Add(this.lblAvgOrderValue);
            this.panelCard3.Controls.Add(this.lblTitleAvg);
            this.panelCard3.Controls.Add(this.pnlIconAvg);
            this.panelCard3.Controls.Add(this.pnlCard3Accent);
            this.panelCard3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard3.Location = new System.Drawing.Point(388, 4);
            this.panelCard3.Margin = new System.Windows.Forms.Padding(0, 4, 5, 4);
            this.panelCard3.Name = "panelCard3";
            this.panelCard3.Size = new System.Drawing.Size(189, 80);
            this.panelCard3.TabIndex = 2;

            this.pnlCard3Accent.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.pnlCard3Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCard3Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlCard3Accent.Name = "pnlCard3Accent";
            this.pnlCard3Accent.Size = new System.Drawing.Size(187, 3);
            this.pnlCard3Accent.TabIndex = 0;

            this.pnlIconAvg.BackColor = System.Drawing.Color.FromArgb(245, 243, 255);
            this.pnlIconAvg.Controls.Add(this.lblIconAvg);
            this.pnlIconAvg.Location = new System.Drawing.Point(8, 12);
            this.pnlIconAvg.Name = "pnlIconAvg";
            this.pnlIconAvg.Size = new System.Drawing.Size(32, 32);
            this.pnlIconAvg.TabIndex = 1;

            this.lblIconAvg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconAvg.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblIconAvg.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.lblIconAvg.Location = new System.Drawing.Point(0, 0);
            this.lblIconAvg.Name = "lblIconAvg";
            this.lblIconAvg.Size = new System.Drawing.Size(32, 32);
            this.lblIconAvg.Text = "📊";
            this.lblIconAvg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTitleAvg.AutoSize = true;
            this.lblTitleAvg.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleAvg.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleAvg.Location = new System.Drawing.Point(44, 11);
            this.lblTitleAvg.Name = "lblTitleAvg";
            this.lblTitleAvg.Size = new System.Drawing.Size(117, 17);
            this.lblTitleAvg.Text = "GIÁ TRỊ TB / ĐƠN";

            this.lblAvgOrderValue.AutoEllipsis = true;
            this.lblAvgOrderValue.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblAvgOrderValue.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.lblAvgOrderValue.Location = new System.Drawing.Point(44, 28);
            this.lblAvgOrderValue.Name = "lblAvgOrderValue";
            this.lblAvgOrderValue.Size = new System.Drawing.Size(138, 28);
            this.lblAvgOrderValue.Text = "0 đ";

            this.lblAvgSubtitle.AutoSize = true;
            this.lblAvgSubtitle.Font = new System.Drawing.Font("Segoe UI", 7.2F);
            this.lblAvgSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblAvgSubtitle.Location = new System.Drawing.Point(8, 56);
            this.lblAvgSubtitle.Name = "lblAvgSubtitle";
            this.lblAvgSubtitle.Size = new System.Drawing.Size(126, 15);
            this.lblAvgSubtitle.Text = "Doanh thu / Tổng đơn";

            // -------------------------------------------------------------
            // Card 4: Khách hàng (Teal)
            // -------------------------------------------------------------
            this.panelCard4.BackColor = System.Drawing.Color.White;
            this.panelCard4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard4.Controls.Add(this.lblCustomersSubtitle);
            this.panelCard4.Controls.Add(this.lblTotalCustomers);
            this.panelCard4.Controls.Add(this.lblTitleCustomers);
            this.panelCard4.Controls.Add(this.pnlIconCustomers);
            this.panelCard4.Controls.Add(this.pnlCard4Accent);
            this.panelCard4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard4.Location = new System.Drawing.Point(582, 4);
            this.panelCard4.Margin = new System.Windows.Forms.Padding(0, 4, 5, 4);
            this.panelCard4.Name = "panelCard4";
            this.panelCard4.Size = new System.Drawing.Size(189, 80);
            this.panelCard4.TabIndex = 3;

            this.pnlCard4Accent.BackColor = System.Drawing.Color.FromArgb(13, 148, 136);
            this.pnlCard4Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCard4Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlCard4Accent.Name = "pnlCard4Accent";
            this.pnlCard4Accent.Size = new System.Drawing.Size(187, 3);
            this.pnlCard4Accent.TabIndex = 0;

            this.pnlIconCustomers.BackColor = System.Drawing.Color.FromArgb(240, 253, 250);
            this.pnlIconCustomers.Controls.Add(this.lblIconCustomers);
            this.pnlIconCustomers.Location = new System.Drawing.Point(8, 12);
            this.pnlIconCustomers.Name = "pnlIconCustomers";
            this.pnlIconCustomers.Size = new System.Drawing.Size(32, 32);
            this.pnlIconCustomers.TabIndex = 1;

            this.lblIconCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconCustomers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblIconCustomers.ForeColor = System.Drawing.Color.FromArgb(13, 148, 136);
            this.lblIconCustomers.Location = new System.Drawing.Point(0, 0);
            this.lblIconCustomers.Name = "lblIconCustomers";
            this.lblIconCustomers.Size = new System.Drawing.Size(32, 32);
            this.lblIconCustomers.Text = "👥";
            this.lblIconCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTitleCustomers.AutoSize = true;
            this.lblTitleCustomers.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleCustomers.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleCustomers.Location = new System.Drawing.Point(44, 11);
            this.lblTitleCustomers.Name = "lblTitleCustomers";
            this.lblTitleCustomers.Size = new System.Drawing.Size(130, 17);
            this.lblTitleCustomers.Text = "KHÁCH THÀNH VIÊN";

            this.lblTotalCustomers.AutoEllipsis = true;
            this.lblTotalCustomers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalCustomers.ForeColor = System.Drawing.Color.FromArgb(13, 148, 136);
            this.lblTotalCustomers.Location = new System.Drawing.Point(44, 28);
            this.lblTotalCustomers.Name = "lblTotalCustomers";
            this.lblTotalCustomers.Size = new System.Drawing.Size(138, 28);
            this.lblTotalCustomers.Text = "0";

            this.lblCustomersSubtitle.AutoSize = true;
            this.lblCustomersSubtitle.Font = new System.Drawing.Font("Segoe UI", 7.2F);
            this.lblCustomersSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCustomersSubtitle.Location = new System.Drawing.Point(8, 56);
            this.lblCustomersSubtitle.Name = "lblCustomersSubtitle";
            this.lblCustomersSubtitle.Size = new System.Drawing.Size(124, 15);
            this.lblCustomersSubtitle.Text = "Hội viên có tích điểm";

            // -------------------------------------------------------------
            // Card 5: Điểm thưởng tích lũy (Orange)
            // -------------------------------------------------------------
            this.panelCard5.BackColor = System.Drawing.Color.White;
            this.panelCard5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard5.Controls.Add(this.lblPointsSubtitle);
            this.panelCard5.Controls.Add(this.lblRewardPoints);
            this.panelCard5.Controls.Add(this.lblTitlePoints);
            this.panelCard5.Controls.Add(this.pnlIconPoints);
            this.panelCard5.Controls.Add(this.pnlCard5Accent);
            this.panelCard5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard5.Location = new System.Drawing.Point(776, 4);
            this.panelCard5.Margin = new System.Windows.Forms.Padding(0, 4, 5, 4);
            this.panelCard5.Name = "panelCard5";
            this.panelCard5.Size = new System.Drawing.Size(189, 80);
            this.panelCard5.TabIndex = 4;

            this.pnlCard5Accent.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.pnlCard5Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCard5Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlCard5Accent.Name = "pnlCard5Accent";
            this.pnlCard5Accent.Size = new System.Drawing.Size(187, 3);
            this.pnlCard5Accent.TabIndex = 0;

            this.pnlIconPoints.BackColor = System.Drawing.Color.FromArgb(255, 247, 237);
            this.pnlIconPoints.Controls.Add(this.lblIconPoints);
            this.pnlIconPoints.Location = new System.Drawing.Point(8, 12);
            this.pnlIconPoints.Name = "pnlIconPoints";
            this.pnlIconPoints.Size = new System.Drawing.Size(32, 32);
            this.pnlIconPoints.TabIndex = 1;

            this.lblIconPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconPoints.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblIconPoints.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblIconPoints.Location = new System.Drawing.Point(0, 0);
            this.lblIconPoints.Name = "lblIconPoints";
            this.lblIconPoints.Size = new System.Drawing.Size(32, 32);
            this.lblIconPoints.Text = "🎁";
            this.lblIconPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTitlePoints.AutoSize = true;
            this.lblTitlePoints.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTitlePoints.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitlePoints.Location = new System.Drawing.Point(44, 11);
            this.lblTitlePoints.Name = "lblTitlePoints";
            this.lblTitlePoints.Size = new System.Drawing.Size(123, 17);
            this.lblTitlePoints.Text = "ĐIỂM TÍCH LŨY";

            this.lblRewardPoints.AutoEllipsis = true;
            this.lblRewardPoints.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblRewardPoints.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.lblRewardPoints.Location = new System.Drawing.Point(44, 28);
            this.lblRewardPoints.Name = "lblRewardPoints";
            this.lblRewardPoints.Size = new System.Drawing.Size(138, 28);
            this.lblRewardPoints.Text = "0";

            this.lblPointsSubtitle.AutoSize = true;
            this.lblPointsSubtitle.Font = new System.Drawing.Font("Segoe UI", 7.2F);
            this.lblPointsSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPointsSubtitle.Location = new System.Drawing.Point(8, 56);
            this.lblPointsSubtitle.Name = "lblPointsSubtitle";
            this.lblPointsSubtitle.Size = new System.Drawing.Size(126, 15);
            this.lblPointsSubtitle.Text = "Phát sinh từ đơn hàng";

            // -------------------------------------------------------------
            // Card 6: Cảnh báo tồn kho (Danger Red)
            // -------------------------------------------------------------
            this.panelCard6.BackColor = System.Drawing.Color.White;
            this.panelCard6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard6.Controls.Add(this.lblLowStockSubtitle);
            this.panelCard6.Controls.Add(this.lblLowStockCount);
            this.panelCard6.Controls.Add(this.lblTitleLowStock);
            this.panelCard6.Controls.Add(this.pnlIconLowStock);
            this.panelCard6.Controls.Add(this.pnlCard6Accent);
            this.panelCard6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard6.Location = new System.Drawing.Point(970, 4);
            this.panelCard6.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelCard6.Name = "panelCard6";
            this.panelCard6.Size = new System.Drawing.Size(198, 80);
            this.panelCard6.TabIndex = 5;

            this.pnlCard6Accent.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.pnlCard6Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCard6Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlCard6Accent.Name = "pnlCard6Accent";
            this.pnlCard6Accent.Size = new System.Drawing.Size(196, 3);
            this.pnlCard6Accent.TabIndex = 0;

            this.pnlIconLowStock.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            this.pnlIconLowStock.Controls.Add(this.lblIconLowStock);
            this.pnlIconLowStock.Location = new System.Drawing.Point(8, 12);
            this.pnlIconLowStock.Name = "pnlIconLowStock";
            this.pnlIconLowStock.Size = new System.Drawing.Size(32, 32);
            this.pnlIconLowStock.TabIndex = 1;

            this.lblIconLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIconLowStock.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblIconLowStock.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblIconLowStock.Location = new System.Drawing.Point(0, 0);
            this.lblIconLowStock.Name = "lblIconLowStock";
            this.lblIconLowStock.Size = new System.Drawing.Size(32, 32);
            this.lblIconLowStock.Text = "⚠️";
            this.lblIconLowStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblTitleLowStock.AutoSize = true;
            this.lblTitleLowStock.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblTitleLowStock.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleLowStock.Location = new System.Drawing.Point(44, 11);
            this.lblTitleLowStock.Name = "lblTitleLowStock";
            this.lblTitleLowStock.Size = new System.Drawing.Size(116, 17);
            this.lblTitleLowStock.Text = "CẢNH BÁO KHO";

            this.lblLowStockCount.AutoEllipsis = true;
            this.lblLowStockCount.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLowStockCount.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblLowStockCount.Location = new System.Drawing.Point(44, 28);
            this.lblLowStockCount.Name = "lblLowStockCount";
            this.lblLowStockCount.Size = new System.Drawing.Size(146, 28);
            this.lblLowStockCount.Text = "0";

            this.lblLowStockSubtitle.AutoSize = true;
            this.lblLowStockSubtitle.Font = new System.Drawing.Font("Segoe UI", 7.2F);
            this.lblLowStockSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblLowStockSubtitle.Location = new System.Drawing.Point(8, 56);
            this.lblLowStockSubtitle.Name = "lblLowStockSubtitle";
            this.lblLowStockSubtitle.Size = new System.Drawing.Size(124, 15);
            this.lblLowStockSubtitle.Text = "Mặt hàng có tồn ≤ 10";

            // 
            // pnlTabNav (Segmented Control Nav Bar)
            // 
            this.pnlTabNav.Controls.Add(this.btnNavTopSelling);
            this.pnlTabNav.Controls.Add(this.btnNavChart);
            this.pnlTabNav.Controls.Add(this.btnNavOrders);
            this.pnlTabNav.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabNav.Location = new System.Drawing.Point(16, 184);
            this.pnlTabNav.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlTabNav.Name = "pnlTabNav";
            this.pnlTabNav.Size = new System.Drawing.Size(1168, 42);
            this.pnlTabNav.TabIndex = 2;

            // btnNavOrders
            this.btnNavOrders.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnNavOrders.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavOrders.FlatAppearance.BorderSize = 0;
            this.btnNavOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavOrders.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavOrders.ForeColor = System.Drawing.Color.White;
            this.btnNavOrders.Location = new System.Drawing.Point(0, 4);
            this.btnNavOrders.Name = "btnNavOrders";
            this.btnNavOrders.Size = new System.Drawing.Size(200, 34);
            this.btnNavOrders.TabIndex = 0;
            this.btnNavOrders.Text = "📋 Danh sách Hóa đơn";
            this.btnNavOrders.UseVisualStyleBackColor = false;
            this.btnNavOrders.Click += new System.EventHandler(this.btnNavOrders_Click);

            // btnNavChart
            this.btnNavChart.BackColor = System.Drawing.Color.White;
            this.btnNavChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavChart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnNavChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavChart.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavChart.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNavChart.Location = new System.Drawing.Point(208, 4);
            this.btnNavChart.Name = "btnNavChart";
            this.btnNavChart.Size = new System.Drawing.Size(240, 34);
            this.btnNavChart.TabIndex = 1;
            this.btnNavChart.Text = "📈 Biểu đồ Doanh thu & Cơ cấu";
            this.btnNavChart.UseVisualStyleBackColor = false;
            this.btnNavChart.Click += new System.EventHandler(this.btnNavChart_Click);

            // btnNavTopSelling
            this.btnNavTopSelling.BackColor = System.Drawing.Color.White;
            this.btnNavTopSelling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNavTopSelling.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.btnNavTopSelling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTopSelling.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnNavTopSelling.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnNavTopSelling.Location = new System.Drawing.Point(456, 4);
            this.btnNavTopSelling.Name = "btnNavTopSelling";
            this.btnNavTopSelling.Size = new System.Drawing.Size(220, 34);
            this.btnNavTopSelling.TabIndex = 2;
            this.btnNavTopSelling.Text = "🏆 Top Mặt hàng Bán chạy";
            this.btnNavTopSelling.UseVisualStyleBackColor = false;
            this.btnNavTopSelling.Click += new System.EventHandler(this.btnNavTopSelling_Click);

            // 
            // tabControlReport
            // 
            this.tabControlReport.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlReport.Controls.Add(this.tabOrders);
            this.tabControlReport.Controls.Add(this.tabChart);
            this.tabControlReport.Controls.Add(this.tabTopSelling);
            this.tabControlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlReport.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlReport.Location = new System.Drawing.Point(16, 226);
            this.tabControlReport.Name = "tabControlReport";
            this.tabControlReport.SelectedIndex = 0;
            this.tabControlReport.Size = new System.Drawing.Size(1168, 512);
            this.tabControlReport.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlReport.TabIndex = 3;

            // =============================================================
            // TAB 1: DANH SÁCH HÓA ĐƠN
            // =============================================================
            this.tabOrders.BackColor = System.Drawing.Color.White;
            this.tabOrders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabOrders.Controls.Add(this.dgvDayOrders);
            this.tabOrders.Controls.Add(this.pnlOrdersSummary);
            this.tabOrders.Controls.Add(this.pnlOrdersToolbar);
            this.tabOrders.Location = new System.Drawing.Point(4, 5);
            this.tabOrders.Name = "tabOrders";
            this.tabOrders.Padding = new System.Windows.Forms.Padding(1);
            this.tabOrders.Size = new System.Drawing.Size(1160, 503);
            this.tabOrders.TabIndex = 0;

            // pnlOrdersToolbar
            this.pnlOrdersToolbar.BackColor = System.Drawing.Color.White;
            this.pnlOrdersToolbar.Controls.Add(this.btnViewOrderDetails);
            this.pnlOrdersToolbar.Controls.Add(this.lblViewStatus);
            this.pnlOrdersToolbar.Controls.Add(this.cboStatusFilter);
            this.pnlOrdersToolbar.Controls.Add(this.lblStatusFilterLabel);
            this.pnlOrdersToolbar.Controls.Add(this.txtSearchOrder);
            this.pnlOrdersToolbar.Controls.Add(this.lblSearchOrder);
            this.pnlOrdersToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOrdersToolbar.Location = new System.Drawing.Point(1, 1);
            this.pnlOrdersToolbar.Name = "pnlOrdersToolbar";
            this.pnlOrdersToolbar.Size = new System.Drawing.Size(1156, 44);
            this.pnlOrdersToolbar.TabIndex = 0;

            // lblSearchOrder
            this.lblSearchOrder.AutoSize = true;
            this.lblSearchOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchOrder.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblSearchOrder.Location = new System.Drawing.Point(10, 12);
            this.lblSearchOrder.Name = "lblSearchOrder";
            this.lblSearchOrder.Size = new System.Drawing.Size(95, 20);
            this.lblSearchOrder.Text = "🔍 Tìm kiếm:";

            // txtSearchOrder
            this.txtSearchOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchOrder.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearchOrder.Location = new System.Drawing.Point(108, 8);
            this.txtSearchOrder.Name = "txtSearchOrder";
            this.txtSearchOrder.Size = new System.Drawing.Size(220, 29);
            this.txtSearchOrder.TabIndex = 1;
            this.txtSearchOrder.TextChanged += new System.EventHandler(this.txtSearchOrder_TextChanged);

            // lblStatusFilterLabel
            this.lblStatusFilterLabel.AutoSize = true;
            this.lblStatusFilterLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatusFilterLabel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblStatusFilterLabel.Location = new System.Drawing.Point(344, 12);
            this.lblStatusFilterLabel.Name = "lblStatusFilterLabel";
            this.lblStatusFilterLabel.Size = new System.Drawing.Size(73, 20);
            this.lblStatusFilterLabel.Text = "Phân loại:";

            // cboStatusFilter
            this.cboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cboStatusFilter.FormattingEnabled = true;
            this.cboStatusFilter.Items.AddRange(new object[] {
            "Tất cả hóa đơn",
            "Khách thành viên",
            "Khách vãng lai",
            "Có tích lũy điểm"});
            this.cboStatusFilter.Location = new System.Drawing.Point(422, 9);
            this.cboStatusFilter.Name = "cboStatusFilter";
            this.cboStatusFilter.Size = new System.Drawing.Size(160, 28);
            this.cboStatusFilter.TabIndex = 2;
            this.cboStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cboStatusFilter_SelectedIndexChanged);

            // lblViewStatus
            this.lblViewStatus.AutoSize = true;
            this.lblViewStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblViewStatus.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblViewStatus.Location = new System.Drawing.Point(595, 12);
            this.lblViewStatus.Name = "lblViewStatus";
            this.lblViewStatus.Size = new System.Drawing.Size(160, 20);
            this.lblViewStatus.Text = "🏷️ Đang xem: Hôm nay";

            // btnViewOrderDetails
            this.btnViewOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewOrderDetails.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnViewOrderDetails.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewOrderDetails.FlatAppearance.BorderSize = 0;
            this.btnViewOrderDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewOrderDetails.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnViewOrderDetails.ForeColor = System.Drawing.Color.White;
            this.btnViewOrderDetails.Location = new System.Drawing.Point(960, 7);
            this.btnViewOrderDetails.Name = "btnViewOrderDetails";
            this.btnViewOrderDetails.Size = new System.Drawing.Size(185, 30);
            this.btnViewOrderDetails.TabIndex = 3;
            this.btnViewOrderDetails.Text = "👁️ Xem chi tiết đơn hàng";
            this.btnViewOrderDetails.UseVisualStyleBackColor = false;
            this.btnViewOrderDetails.Click += new System.EventHandler(this.btnViewOrderDetails_Click);

            // dgvDayOrders
            this.dgvDayOrders.AllowUserToAddRows = false;
            this.dgvDayOrders.AllowUserToDeleteRows = false;
            this.dgvDayOrders.AllowUserToResizeRows = false;
            this.dgvDayOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvDayOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDayOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDayOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgvHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvHeaderStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvDayOrders.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvDayOrders.ColumnHeadersHeight = 36;
            this.dgvDayOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvRowStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.dgvDayOrders.DefaultCellStyle = dgvRowStyle;
            this.dgvDayOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDayOrders.EnableHeadersVisualStyles = false;
            this.dgvDayOrders.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvDayOrders.Location = new System.Drawing.Point(1, 45);
            this.dgvDayOrders.MultiSelect = false;
            this.dgvDayOrders.Name = "dgvDayOrders";
            this.dgvDayOrders.ReadOnly = true;
            this.dgvDayOrders.RowHeadersVisible = false;
            this.dgvDayOrders.RowTemplate.Height = 34;
            this.dgvDayOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDayOrders.Size = new System.Drawing.Size(1156, 417);
            this.dgvDayOrders.TabIndex = 1;
            this.dgvDayOrders.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDayOrders_CellDoubleClick);

            // pnlOrdersSummary (Thanh thống kê chi tiết phía dưới)
            this.pnlOrdersSummary.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlOrdersSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrdersSummary.Controls.Add(this.lblOrdersSummaryFilter);
            this.pnlOrdersSummary.Controls.Add(this.lblOrdersSummaryItems);
            this.pnlOrdersSummary.Controls.Add(this.lblOrdersSummaryAvg);
            this.pnlOrdersSummary.Controls.Add(this.lblOrdersSummaryRevenue);
            this.pnlOrdersSummary.Controls.Add(this.lblOrdersSummaryCount);
            this.pnlOrdersSummary.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOrdersSummary.Location = new System.Drawing.Point(1, 462);
            this.pnlOrdersSummary.Name = "pnlOrdersSummary";
            this.pnlOrdersSummary.Size = new System.Drawing.Size(1156, 38);
            this.pnlOrdersSummary.TabIndex = 2;

            // lblOrdersSummaryCount
            this.lblOrdersSummaryCount.AutoSize = true;
            this.lblOrdersSummaryCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdersSummaryCount.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblOrdersSummaryCount.Location = new System.Drawing.Point(12, 9);
            this.lblOrdersSummaryCount.Name = "lblOrdersSummaryCount";
            this.lblOrdersSummaryCount.Size = new System.Drawing.Size(130, 20);
            this.lblOrdersSummaryCount.Text = "📦 Tổng số: 0 đơn";

            // lblOrdersSummaryRevenue
            this.lblOrdersSummaryRevenue.AutoSize = true;
            this.lblOrdersSummaryRevenue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdersSummaryRevenue.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblOrdersSummaryRevenue.Location = new System.Drawing.Point(210, 9);
            this.lblOrdersSummaryRevenue.Name = "lblOrdersSummaryRevenue";
            this.lblOrdersSummaryRevenue.Size = new System.Drawing.Size(155, 20);
            this.lblOrdersSummaryRevenue.Text = "💰 Doanh thu: 0 VNĐ";

            // lblOrdersSummaryAvg
            this.lblOrdersSummaryAvg.AutoSize = true;
            this.lblOrdersSummaryAvg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdersSummaryAvg.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.lblOrdersSummaryAvg.Location = new System.Drawing.Point(440, 9);
            this.lblOrdersSummaryAvg.Name = "lblOrdersSummaryAvg";
            this.lblOrdersSummaryAvg.Size = new System.Drawing.Size(185, 20);
            this.lblOrdersSummaryAvg.Text = "📊 Giá trị TB: 0 VNĐ / đơn";

            // lblOrdersSummaryItems
            this.lblOrdersSummaryItems.AutoSize = true;
            this.lblOrdersSummaryItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrdersSummaryItems.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            this.lblOrdersSummaryItems.Location = new System.Drawing.Point(700, 9);
            this.lblOrdersSummaryItems.Name = "lblOrdersSummaryItems";
            this.lblOrdersSummaryItems.Size = new System.Drawing.Size(145, 20);
            this.lblOrdersSummaryItems.Text = "🛒 Tổng số món: 0 SP";

            // lblOrdersSummaryFilter
            this.lblOrdersSummaryFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrdersSummaryFilter.AutoSize = true;
            this.lblOrdersSummaryFilter.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblOrdersSummaryFilter.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblOrdersSummaryFilter.Location = new System.Drawing.Point(950, 9);
            this.lblOrdersSummaryFilter.Name = "lblOrdersSummaryFilter";
            this.lblOrdersSummaryFilter.Size = new System.Drawing.Size(110, 20);
            this.lblOrdersSummaryFilter.Text = "🏷️ Kỳ: Hôm nay";

            // =============================================================
            // TAB 2: BIỂU ĐỒ DOANH THU & CƠ CẤU KHÁCH HÀNG
            // =============================================================
            this.tabChart.BackColor = System.Drawing.Color.White;
            this.tabChart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabChart.Controls.Add(this.scChartSplit);
            this.tabChart.Location = new System.Drawing.Point(4, 5);
            this.tabChart.Name = "tabChart";
            this.tabChart.Padding = new System.Windows.Forms.Padding(1);
            this.tabChart.Size = new System.Drawing.Size(1160, 503);
            this.tabChart.TabIndex = 1;

            // scChartSplit (Chia đôi: 65% Biểu đồ cột Doanh thu, 35% Biểu đồ tròn Cơ cấu)
            this.scChartSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scChartSplit.Location = new System.Drawing.Point(1, 1);
            this.scChartSplit.Name = "scChartSplit";
            this.scChartSplit.SplitterDistance = 740;
            this.scChartSplit.SplitterWidth = 6;
            this.scChartSplit.TabIndex = 0;

            // scChartSplit.Panel1 (Biểu đồ cột)
            this.scChartSplit.Panel1.Controls.Add(this.chartDailyRevenue);
            this.scChartSplit.Panel1.Controls.Add(this.pnlRevenueHeader);

            // pnlRevenueHeader
            this.pnlRevenueHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlRevenueHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRevenueHeader.Controls.Add(this.lblRevenueChartSub);
            this.pnlRevenueHeader.Controls.Add(this.lblRevenueChartTitle);
            this.pnlRevenueHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRevenueHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlRevenueHeader.Name = "pnlRevenueHeader";
            this.pnlRevenueHeader.Size = new System.Drawing.Size(740, 42);
            this.pnlRevenueHeader.TabIndex = 0;

            this.lblRevenueChartTitle.AutoSize = true;
            this.lblRevenueChartTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRevenueChartTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblRevenueChartTitle.Location = new System.Drawing.Point(10, 4);
            this.lblRevenueChartTitle.Name = "lblRevenueChartTitle";
            this.lblRevenueChartTitle.Size = new System.Drawing.Size(325, 21);
            this.lblRevenueChartTitle.Text = "📈 BIỂU ĐỒ DOANH THU THEO THỜI GIAN";

            this.lblRevenueChartSub.AutoSize = true;
            this.lblRevenueChartSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRevenueChartSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblRevenueChartSub.Location = new System.Drawing.Point(11, 23);
            this.lblRevenueChartSub.Name = "lblRevenueChartSub";
            this.lblRevenueChartSub.Size = new System.Drawing.Size(240, 19);
            this.lblRevenueChartSub.Text = "Dữ liệu doanh thu thực tế ghi nhận";

            // chartDailyRevenue
            chartArea1.Name = "ChartArea1";
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(241, 245, 249);
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(241, 245, 249);
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.chartDailyRevenue.ChartAreas.Add(chartArea1);
            this.chartDailyRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chartDailyRevenue.Legends.Add(legend1);
            this.chartDailyRevenue.Location = new System.Drawing.Point(0, 42);
            this.chartDailyRevenue.Name = "chartDailyRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(37, 99, 235); // Tech blue
            series1.Legend = "Legend1";
            series1.Name = "Doanh thu (VNĐ)";
            series1.IsValueShownAsLabel = false;
            this.chartDailyRevenue.Series.Add(series1);
            this.chartDailyRevenue.Size = new System.Drawing.Size(740, 459);
            this.chartDailyRevenue.TabIndex = 1;

            // scChartSplit.Panel2 (Biểu đồ tròn Doughnut)
            this.scChartSplit.Panel2.Controls.Add(this.chartCustomerRatio);
            this.scChartSplit.Panel2.Controls.Add(this.pnlRatioHeader);

            // pnlRatioHeader
            this.pnlRatioHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlRatioHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRatioHeader.Controls.Add(this.lblRatioChartSub);
            this.pnlRatioHeader.Controls.Add(this.lblRatioChartTitle);
            this.pnlRatioHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRatioHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlRatioHeader.Name = "pnlRatioHeader";
            this.pnlRatioHeader.Size = new System.Drawing.Size(414, 42);
            this.pnlRatioHeader.TabIndex = 0;

            this.lblRatioChartTitle.AutoSize = true;
            this.lblRatioChartTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRatioChartTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblRatioChartTitle.Location = new System.Drawing.Point(10, 4);
            this.lblRatioChartTitle.Name = "lblRatioChartTitle";
            this.lblRatioChartTitle.Size = new System.Drawing.Size(225, 21);
            this.lblRatioChartTitle.Text = "🍩 CƠ CẤU KHÁCH HÀNG";

            this.lblRatioChartSub.AutoSize = true;
            this.lblRatioChartSub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblRatioChartSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblRatioChartSub.Location = new System.Drawing.Point(11, 23);
            this.lblRatioChartSub.Name = "lblRatioChartSub";
            this.lblRatioChartSub.Size = new System.Drawing.Size(235, 19);
            this.lblRatioChartSub.Text = "Khách thành viên vs Khách vãng lai";

            // chartCustomerRatio
            chartArea2.Name = "ChartArea2";
            this.chartCustomerRatio.ChartAreas.Add(chartArea2);
            this.chartCustomerRatio.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Alignment = System.Drawing.StringAlignment.Center;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend2.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            legend2.Name = "Legend2";
            this.chartCustomerRatio.Legends.Add(legend2);
            this.chartCustomerRatio.Location = new System.Drawing.Point(0, 42);
            this.chartCustomerRatio.Name = "chartCustomerRatio";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series2.Legend = "Legend2";
            series2.Name = "CustomerRatio";
            series2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.chartCustomerRatio.Series.Add(series2);
            this.chartCustomerRatio.Size = new System.Drawing.Size(414, 459);
            this.chartCustomerRatio.TabIndex = 1;

            // =============================================================
            // TAB 3: TOP 5 SẢN PHẨM BÁN CHẠY NHẤT
            // =============================================================
            this.tabTopSelling.BackColor = System.Drawing.Color.White;
            this.tabTopSelling.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabTopSelling.Controls.Add(this.dgvTopSelling);
            this.tabTopSelling.Controls.Add(this.pnlTopSellingHeader);
            this.tabTopSelling.Location = new System.Drawing.Point(4, 5);
            this.tabTopSelling.Name = "tabTopSelling";
            this.tabTopSelling.Padding = new System.Windows.Forms.Padding(1);
            this.tabTopSelling.Size = new System.Drawing.Size(1160, 503);
            this.tabTopSelling.TabIndex = 2;

            // pnlTopSellingHeader
            this.pnlTopSellingHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlTopSellingHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopSellingHeader.Controls.Add(this.btnRefreshTopSelling);
            this.pnlTopSellingHeader.Controls.Add(this.lblTopSellingSubtitle);
            this.pnlTopSellingHeader.Controls.Add(this.lblTopSellingTitle);
            this.pnlTopSellingHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopSellingHeader.Location = new System.Drawing.Point(1, 1);
            this.pnlTopSellingHeader.Name = "pnlTopSellingHeader";
            this.pnlTopSellingHeader.Size = new System.Drawing.Size(1156, 46);
            this.pnlTopSellingHeader.TabIndex = 0;

            // lblTopSellingTitle
            this.lblTopSellingTitle.AutoSize = true;
            this.lblTopSellingTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTopSellingTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblTopSellingTitle.Location = new System.Drawing.Point(12, 4);
            this.lblTopSellingTitle.Name = "lblTopSellingTitle";
            this.lblTopSellingTitle.Size = new System.Drawing.Size(465, 23);
            this.lblTopSellingTitle.Text = "🏆 BẢNG XẾP HẠNG TOP SẢN PHẨM BÁN CHẠY NHẤT";

            // lblTopSellingSubtitle
            this.lblTopSellingSubtitle.AutoSize = true;
            this.lblTopSellingSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblTopSellingSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTopSellingSubtitle.Location = new System.Drawing.Point(13, 24);
            this.lblTopSellingSubtitle.Name = "lblTopSellingSubtitle";
            this.lblTopSellingSubtitle.Size = new System.Drawing.Size(415, 20);
            this.lblTopSellingSubtitle.Text = "Thống kê 5 sản phẩm đạt doanh số và sản lượng cao nhất";

            // btnRefreshTopSelling
            this.btnRefreshTopSelling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshTopSelling.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnRefreshTopSelling.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefreshTopSelling.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnRefreshTopSelling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTopSelling.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRefreshTopSelling.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnRefreshTopSelling.Location = new System.Drawing.Point(995, 8);
            this.btnRefreshTopSelling.Name = "btnRefreshTopSelling";
            this.btnRefreshTopSelling.Size = new System.Drawing.Size(150, 30);
            this.btnRefreshTopSelling.TabIndex = 1;
            this.btnRefreshTopSelling.Text = "🔄 Làm mới BXH";
            this.btnRefreshTopSelling.UseVisualStyleBackColor = false;
            this.btnRefreshTopSelling.Click += new System.EventHandler(this.btnRefreshTopSelling_Click);

            // dgvTopSelling
            this.dgvTopSelling.AllowUserToAddRows = false;
            this.dgvTopSelling.AllowUserToDeleteRows = false;
            this.dgvTopSelling.AllowUserToResizeRows = false;
            this.dgvTopSelling.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopSelling.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTopSelling.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTopSelling.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvTopHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvTopHeaderStyle.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvTopHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvTopHeaderStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgvTopHeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            dgvTopHeaderStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvTopSelling.ColumnHeadersDefaultCellStyle = dgvTopHeaderStyle;
            this.dgvTopSelling.ColumnHeadersHeight = 36;
            this.dgvTopSelling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTopRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvTopRowStyle.BackColor = System.Drawing.Color.White;
            dgvTopRowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvTopRowStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgvTopRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            dgvTopRowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 64, 175);
            this.dgvTopSelling.DefaultCellStyle = dgvTopRowStyle;
            this.dgvTopSelling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopSelling.EnableHeadersVisualStyles = false;
            this.dgvTopSelling.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvTopSelling.Location = new System.Drawing.Point(1, 47);
            this.dgvTopSelling.MultiSelect = false;
            this.dgvTopSelling.Name = "dgvTopSelling";
            this.dgvTopSelling.ReadOnly = true;
            this.dgvTopSelling.RowHeadersVisible = false;
            this.dgvTopSelling.RowTemplate.Height = 36;
            this.dgvTopSelling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopSelling.Size = new System.Drawing.Size(1156, 453);
            this.dgvTopSelling.TabIndex = 1;
            this.dgvTopSelling.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvTopSelling_CellFormatting);

            // 
            // Finalize FormQuickReport
            // 
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.pnlTopActions.ResumeLayout(false);
            this.pnlTopActions.PerformLayout();
            this.tlpCards.ResumeLayout(false);

            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            this.pnlIconRevenue.ResumeLayout(false);
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.pnlIconOrders.ResumeLayout(false);
            this.panelCard3.ResumeLayout(false);
            this.panelCard3.PerformLayout();
            this.pnlIconAvg.ResumeLayout(false);
            this.panelCard4.ResumeLayout(false);
            this.panelCard4.PerformLayout();
            this.pnlIconCustomers.ResumeLayout(false);
            this.panelCard5.ResumeLayout(false);
            this.panelCard5.PerformLayout();
            this.pnlIconPoints.ResumeLayout(false);
            this.panelCard6.ResumeLayout(false);
            this.panelCard6.PerformLayout();
            this.pnlIconLowStock.ResumeLayout(false);

            this.pnlTabNav.ResumeLayout(false);
            this.tabControlReport.ResumeLayout(false);
            this.tabOrders.ResumeLayout(false);
            this.pnlOrdersToolbar.ResumeLayout(false);
            this.pnlOrdersToolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDayOrders)).EndInit();
            this.pnlOrdersSummary.ResumeLayout(false);
            this.pnlOrdersSummary.PerformLayout();

            this.tabChart.ResumeLayout(false);
            this.scChartSplit.Panel1.ResumeLayout(false);
            this.scChartSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scChartSplit)).EndInit();
            this.scChartSplit.ResumeLayout(false);
            this.pnlRevenueHeader.ResumeLayout(false);
            this.pnlRevenueHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDailyRevenue)).EndInit();
            this.pnlRatioHeader.ResumeLayout(false);
            this.pnlRatioHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCustomerRatio)).EndInit();

            this.tabTopSelling.ResumeLayout(false);
            this.pnlTopSellingHeader.ResumeLayout(false);
            this.pnlTopSellingHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopSelling)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
