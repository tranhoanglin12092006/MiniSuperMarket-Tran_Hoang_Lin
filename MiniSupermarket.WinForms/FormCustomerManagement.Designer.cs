namespace MiniSupermarket.WinForms
{
    partial class FormCustomerManagement
    {
        private System.ComponentModel.IContainer components = null;

        // Container chính
        private System.Windows.Forms.Panel pnlMainContainer;

        // Header tiêu đề & Breadcrumb
        private System.Windows.Forms.Panel pnlHeaderBar;
        private System.Windows.Forms.Label lblBreadcrumb;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblLiveSyncBadge;

        // 4 Thẻ KPI Khách hàng & Loyalty
        private System.Windows.Forms.TableLayoutPanel tlpKPI;
        private System.Windows.Forms.Panel panelKpiCustomers;
        private System.Windows.Forms.Panel pnlKpi1Accent;
        private System.Windows.Forms.Label lblKpiIconCustomers;
        private System.Windows.Forms.Label lblKpiTitleCustomers;
        private System.Windows.Forms.Label lblKpiTotalCustomers;
        private System.Windows.Forms.Label lblKpiSubCustomers;

        private System.Windows.Forms.Panel panelKpiVip;
        private System.Windows.Forms.Panel pnlKpi2Accent;
        private System.Windows.Forms.Label lblKpiIconVip;
        private System.Windows.Forms.Label lblKpiTitleVip;
        private System.Windows.Forms.Label lblKpiVipCustomers;
        private System.Windows.Forms.Label lblKpiSubVip;

        private System.Windows.Forms.Panel panelKpiPoints;
        private System.Windows.Forms.Panel pnlKpi3Accent;
        private System.Windows.Forms.Label lblKpiIconPoints;
        private System.Windows.Forms.Label lblKpiTitlePoints;
        private System.Windows.Forms.Label lblKpiTotalPoints;
        private System.Windows.Forms.Label lblKpiSubPoints;

        private System.Windows.Forms.Panel panelKpiRegular;
        private System.Windows.Forms.Panel pnlKpi4Accent;
        private System.Windows.Forms.Label lblKpiIconRegular;
        private System.Windows.Forms.Label lblKpiTitleRegular;
        private System.Windows.Forms.Label lblKpiRegularCustomers;
        private System.Windows.Forms.Label lblKpiSubRegular;

        // SplitContainer chia đôi: Trái (Bảng khách hàng + Bộ lọc), Phải (Form chi tiết)
        private System.Windows.Forms.SplitContainer scMain;

        // Cột Trái: Bộ lọc, DataGridView & Thanh trạng thái
        private System.Windows.Forms.Panel pnlTableWrapper;
        private System.Windows.Forms.Panel pnlTopFilter;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cboFilterRank;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Panel pnlTableFooter;
        private System.Windows.Forms.Label lblGridCount;
        private System.Windows.Forms.Label lblSelectionHint;

        // Cột Phải: Thẻ Chi tiết Khách hàng & Thao tác CRUD
        private System.Windows.Forms.Panel pnlRightCard;
        private System.Windows.Forms.Label lblCardHeader;
        private System.Windows.Forms.Panel pnlCardBody;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblMembershipRank;
        private System.Windows.Forms.ComboBox cboMembershipRank;
        private System.Windows.Forms.Label lblRewardPoints;
        private System.Windows.Forms.NumericUpDown nudRewardPoints;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblNotification;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlHeaderBar = new System.Windows.Forms.Panel();
            this.lblBreadcrumb = new System.Windows.Forms.Label();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblLiveSyncBadge = new System.Windows.Forms.Label();

            // 4 Thẻ KPI
            this.tlpKPI = new System.Windows.Forms.TableLayoutPanel();
            this.panelKpiCustomers = new System.Windows.Forms.Panel();
            this.pnlKpi1Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconCustomers = new System.Windows.Forms.Label();
            this.lblKpiTitleCustomers = new System.Windows.Forms.Label();
            this.lblKpiTotalCustomers = new System.Windows.Forms.Label();
            this.lblKpiSubCustomers = new System.Windows.Forms.Label();

            this.panelKpiVip = new System.Windows.Forms.Panel();
            this.pnlKpi2Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconVip = new System.Windows.Forms.Label();
            this.lblKpiTitleVip = new System.Windows.Forms.Label();
            this.lblKpiVipCustomers = new System.Windows.Forms.Label();
            this.lblKpiSubVip = new System.Windows.Forms.Label();

            this.panelKpiPoints = new System.Windows.Forms.Panel();
            this.pnlKpi3Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconPoints = new System.Windows.Forms.Label();
            this.lblKpiTitlePoints = new System.Windows.Forms.Label();
            this.lblKpiTotalPoints = new System.Windows.Forms.Label();
            this.lblKpiSubPoints = new System.Windows.Forms.Label();

            this.panelKpiRegular = new System.Windows.Forms.Panel();
            this.pnlKpi4Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconRegular = new System.Windows.Forms.Label();
            this.lblKpiTitleRegular = new System.Windows.Forms.Label();
            this.lblKpiRegularCustomers = new System.Windows.Forms.Label();
            this.lblKpiSubRegular = new System.Windows.Forms.Label();

            // SplitContainer
            this.scMain = new System.Windows.Forms.SplitContainer();

            // Cột Trái Controls
            this.pnlTableWrapper = new System.Windows.Forms.Panel();
            this.pnlTopFilter = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cboFilterRank = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.pnlTableFooter = new System.Windows.Forms.Panel();
            this.lblGridCount = new System.Windows.Forms.Label();
            this.lblSelectionHint = new System.Windows.Forms.Label();

            // Cột Phải Controls
            this.pnlRightCard = new System.Windows.Forms.Panel();
            this.lblCardHeader = new System.Windows.Forms.Label();
            this.pnlCardBody = new System.Windows.Forms.Panel();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblMembershipRank = new System.Windows.Forms.Label();
            this.cboMembershipRank = new System.Windows.Forms.ComboBox();
            this.lblRewardPoints = new System.Windows.Forms.Label();
            this.nudRewardPoints = new System.Windows.Forms.NumericUpDown();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblNotification = new System.Windows.Forms.Label();

            this.pnlMainContainer.SuspendLayout();
            this.pnlHeaderBar.SuspendLayout();
            this.tlpKPI.SuspendLayout();

            this.panelKpiCustomers.SuspendLayout();
            this.panelKpiVip.SuspendLayout();
            this.panelKpiPoints.SuspendLayout();
            this.panelKpiRegular.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();

            this.pnlTableWrapper.SuspendLayout();
            this.pnlTopFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.pnlTableFooter.SuspendLayout();

            this.pnlRightCard.SuspendLayout();
            this.pnlCardBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRewardPoints)).BeginInit();
            this.SuspendLayout();

            // 
            // FormCustomerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 245);
            this.ClientSize = new System.Drawing.Size(1180, 780);
            this.Controls.Add(this.pnlMainContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(980, 620);
            this.Name = "FormCustomerManagement";
            this.Text = "QUẢN LÝ KHÁCH HÀNG THÂN THIẾT";
            this.Load += new System.EventHandler(this.FormCustomerManagement_Load);

            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(244, 247, 245);
            this.pnlMainContainer.Controls.Add(this.scMain);
            this.pnlMainContainer.Controls.Add(this.tlpKPI);
            this.pnlMainContainer.Controls.Add(this.pnlHeaderBar);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlMainContainer.Size = new System.Drawing.Size(1180, 780);
            this.pnlMainContainer.TabIndex = 0;

            // =============================================================
            // HEADER BAR: BREADCRUMB & TIÊU ĐỀ
            // =============================================================
            this.pnlHeaderBar.BackColor = System.Drawing.Color.White;
            this.pnlHeaderBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeaderBar.Controls.Add(this.lblLiveSyncBadge);
            this.pnlHeaderBar.Controls.Add(this.lblHeaderSubtitle);
            this.pnlHeaderBar.Controls.Add(this.lblHeaderTitle);
            this.pnlHeaderBar.Controls.Add(this.lblBreadcrumb);
            this.pnlHeaderBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeaderBar.Location = new System.Drawing.Point(14, 10);
            this.pnlHeaderBar.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnlHeaderBar.Name = "pnlHeaderBar";
            this.pnlHeaderBar.Size = new System.Drawing.Size(1152, 70);
            this.pnlHeaderBar.TabIndex = 0;

            // lblBreadcrumb
            this.lblBreadcrumb.AutoSize = true;
            this.lblBreadcrumb.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBreadcrumb.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblBreadcrumb.Location = new System.Drawing.Point(12, 6);
            this.lblBreadcrumb.Name = "lblBreadcrumb";
            this.lblBreadcrumb.Size = new System.Drawing.Size(250, 19);
            this.lblBreadcrumb.Text = "Hệ thống quản lý / Khách hàng & Loyalty";

            // lblHeaderTitle
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(16, 42, 33); // Dark Green
            this.lblHeaderTitle.Location = new System.Drawing.Point(11, 25);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(465, 30);
            this.lblHeaderTitle.Text = "QUẢN LÝ KHÁCH HÀNG & CHƯƠNG TRÌNH VIP";
            this.lblHeaderTitle.UseMnemonic = false;

            // lblHeaderSubtitle
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(12, 48);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(490, 20);
            this.lblHeaderSubtitle.Text = "Hồ sơ hội viên, phân loại hạng thẻ (Kim cương, Vàng, Bạc, Chuẩn) và tích điểm POS";

            // lblLiveSyncBadge
            this.lblLiveSyncBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLiveSyncBadge.BackColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblLiveSyncBadge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblLiveSyncBadge.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblLiveSyncBadge.Location = new System.Drawing.Point(1015, 20);
            this.lblLiveSyncBadge.Name = "lblLiveSyncBadge";
            this.lblLiveSyncBadge.Size = new System.Drawing.Size(120, 26);
            this.lblLiveSyncBadge.Text = "● Đã kết nối API";
            this.lblLiveSyncBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // =============================================================
            // 4 THẺ KPI CHỈ SỐ KHÁCH HÀNG (TABLELAYOUTPANEL 4 CỘT 25%)
            // =============================================================
            this.tlpKPI.ColumnCount = 4;
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.Controls.Add(this.panelKpiCustomers, 0, 0);
            this.tlpKPI.Controls.Add(this.panelKpiVip, 1, 0);
            this.tlpKPI.Controls.Add(this.panelKpiPoints, 2, 0);
            this.tlpKPI.Controls.Add(this.panelKpiRegular, 3, 0);
            this.tlpKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKPI.Location = new System.Drawing.Point(14, 80);
            this.tlpKPI.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.tlpKPI.Name = "tlpKPI";
            this.tlpKPI.RowCount = 1;
            this.tlpKPI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKPI.Size = new System.Drawing.Size(1152, 78);
            this.tlpKPI.TabIndex = 1;

            // Card 1: Tổng Hội Viên
            this.panelKpiCustomers.BackColor = System.Drawing.Color.White;
            this.panelKpiCustomers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiCustomers.Controls.Add(this.lblKpiSubCustomers);
            this.panelKpiCustomers.Controls.Add(this.lblKpiTotalCustomers);
            this.panelKpiCustomers.Controls.Add(this.lblKpiTitleCustomers);
            this.panelKpiCustomers.Controls.Add(this.lblKpiIconCustomers);
            this.panelKpiCustomers.Controls.Add(this.pnlKpi1Accent);
            this.panelKpiCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiCustomers.Location = new System.Drawing.Point(0, 4);
            this.panelKpiCustomers.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiCustomers.Name = "panelKpiCustomers";
            this.panelKpiCustomers.Size = new System.Drawing.Size(282, 70);
            this.panelKpiCustomers.TabIndex = 0;

            this.pnlKpi1Accent.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.pnlKpi1Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi1Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi1Accent.Name = "pnlKpi1Accent";
            this.pnlKpi1Accent.Size = new System.Drawing.Size(280, 3);
            this.pnlKpi1Accent.TabIndex = 0;

            this.lblKpiIconCustomers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconCustomers.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconCustomers.Name = "lblKpiIconCustomers";
            this.lblKpiIconCustomers.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconCustomers.Text = "👥";
            this.lblKpiIconCustomers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleCustomers.AutoSize = true;
            this.lblKpiTitleCustomers.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleCustomers.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleCustomers.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleCustomers.Name = "lblKpiTitleCustomers";
            this.lblKpiTitleCustomers.Size = new System.Drawing.Size(126, 17);
            this.lblKpiTitleCustomers.Text = "TỔNG SỐ HỘI VIÊN";

            this.lblKpiTotalCustomers.AutoSize = true;
            this.lblKpiTotalCustomers.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotalCustomers.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblKpiTotalCustomers.Location = new System.Drawing.Point(40, 24);
            this.lblKpiTotalCustomers.Name = "lblKpiTotalCustomers";
            this.lblKpiTotalCustomers.Size = new System.Drawing.Size(89, 30);
            this.lblKpiTotalCustomers.Text = "0 Khách";

            this.lblKpiSubCustomers.AutoSize = true;
            this.lblKpiSubCustomers.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubCustomers.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubCustomers.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubCustomers.Name = "lblKpiSubCustomers";
            this.lblKpiSubCustomers.Size = new System.Drawing.Size(128, 17);
            this.lblKpiSubCustomers.Text = "Khách hàng đăng ký";

            // Card 2: Hội Viên VIP (Vàng/Kim Cương)
            this.panelKpiVip.BackColor = System.Drawing.Color.White;
            this.panelKpiVip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiVip.Controls.Add(this.lblKpiSubVip);
            this.panelKpiVip.Controls.Add(this.lblKpiVipCustomers);
            this.panelKpiVip.Controls.Add(this.lblKpiTitleVip);
            this.panelKpiVip.Controls.Add(this.lblKpiIconVip);
            this.panelKpiVip.Controls.Add(this.pnlKpi2Accent);
            this.panelKpiVip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiVip.Location = new System.Drawing.Point(288, 4);
            this.panelKpiVip.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiVip.Name = "panelKpiVip";
            this.panelKpiVip.Size = new System.Drawing.Size(282, 70);
            this.panelKpiVip.TabIndex = 1;

            this.pnlKpi2Accent.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.pnlKpi2Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi2Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi2Accent.Name = "pnlKpi2Accent";
            this.pnlKpi2Accent.Size = new System.Drawing.Size(280, 3);
            this.pnlKpi2Accent.TabIndex = 0;

            this.lblKpiIconVip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconVip.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconVip.Name = "lblKpiIconVip";
            this.lblKpiIconVip.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconVip.Text = "💎";
            this.lblKpiIconVip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleVip.AutoSize = true;
            this.lblKpiTitleVip.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleVip.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleVip.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleVip.Name = "lblKpiTitleVip";
            this.lblKpiTitleVip.Size = new System.Drawing.Size(126, 17);
            this.lblKpiTitleVip.Text = "HỘI VIÊN CAO CẤP";

            this.lblKpiVipCustomers.AutoSize = true;
            this.lblKpiVipCustomers.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiVipCustomers.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.lblKpiVipCustomers.Location = new System.Drawing.Point(40, 24);
            this.lblKpiVipCustomers.Name = "lblKpiVipCustomers";
            this.lblKpiVipCustomers.Size = new System.Drawing.Size(68, 30);
            this.lblKpiVipCustomers.Text = "0 VIP";

            this.lblKpiSubVip.AutoSize = true;
            this.lblKpiSubVip.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubVip.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubVip.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubVip.Name = "lblKpiSubVip";
            this.lblKpiSubVip.Size = new System.Drawing.Size(126, 17);
            this.lblKpiSubVip.Text = "Hạng Vàng & Kim cương";

            // Card 3: Điểm Tích Lũy Toàn Hệ Thống
            this.panelKpiPoints.BackColor = System.Drawing.Color.White;
            this.panelKpiPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiPoints.Controls.Add(this.lblKpiSubPoints);
            this.panelKpiPoints.Controls.Add(this.lblKpiTotalPoints);
            this.panelKpiPoints.Controls.Add(this.lblKpiTitlePoints);
            this.panelKpiPoints.Controls.Add(this.lblKpiIconPoints);
            this.panelKpiPoints.Controls.Add(this.pnlKpi3Accent);
            this.panelKpiPoints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiPoints.Location = new System.Drawing.Point(576, 4);
            this.panelKpiPoints.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiPoints.Name = "panelKpiPoints";
            this.panelKpiPoints.Size = new System.Drawing.Size(282, 70);
            this.panelKpiPoints.TabIndex = 2;

            this.pnlKpi3Accent.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.pnlKpi3Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi3Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi3Accent.Name = "pnlKpi3Accent";
            this.pnlKpi3Accent.Size = new System.Drawing.Size(280, 3);
            this.pnlKpi3Accent.TabIndex = 0;

            this.lblKpiIconPoints.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconPoints.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconPoints.Name = "lblKpiIconPoints";
            this.lblKpiIconPoints.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconPoints.Text = "🪙";
            this.lblKpiIconPoints.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitlePoints.AutoSize = true;
            this.lblKpiTitlePoints.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitlePoints.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitlePoints.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitlePoints.Name = "lblKpiTitlePoints";
            this.lblKpiTitlePoints.Size = new System.Drawing.Size(126, 17);
            this.lblKpiTitlePoints.Text = "TỔNG ĐIỂM THƯỞNG";

            this.lblKpiTotalPoints.AutoSize = true;
            this.lblKpiTotalPoints.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotalPoints.ForeColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.lblKpiTotalPoints.Location = new System.Drawing.Point(40, 24);
            this.lblKpiTotalPoints.Name = "lblKpiTotalPoints";
            this.lblKpiTotalPoints.Size = new System.Drawing.Size(76, 30);
            this.lblKpiTotalPoints.Text = "0 Điểm";

            this.lblKpiSubPoints.AutoSize = true;
            this.lblKpiSubPoints.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubPoints.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubPoints.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubPoints.Name = "lblKpiSubPoints";
            this.lblKpiSubPoints.Size = new System.Drawing.Size(117, 17);
            this.lblKpiSubPoints.Text = "Điểm lưu trữ hiện có";

            // Card 4: Hội Viên Tiêu Chuẩn
            this.panelKpiRegular.BackColor = System.Drawing.Color.White;
            this.panelKpiRegular.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiRegular.Controls.Add(this.lblKpiSubRegular);
            this.panelKpiRegular.Controls.Add(this.lblKpiRegularCustomers);
            this.panelKpiRegular.Controls.Add(this.lblKpiTitleRegular);
            this.panelKpiRegular.Controls.Add(this.lblKpiIconRegular);
            this.panelKpiRegular.Controls.Add(this.pnlKpi4Accent);
            this.panelKpiRegular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiRegular.Location = new System.Drawing.Point(864, 4);
            this.panelKpiRegular.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelKpiRegular.Name = "panelKpiRegular";
            this.panelKpiRegular.Size = new System.Drawing.Size(288, 70);
            this.panelKpiRegular.TabIndex = 3;

            this.pnlKpi4Accent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlKpi4Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi4Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi4Accent.Name = "pnlKpi4Accent";
            this.pnlKpi4Accent.Size = new System.Drawing.Size(286, 3);
            this.pnlKpi4Accent.TabIndex = 0;

            this.lblKpiIconRegular.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconRegular.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconRegular.Name = "lblKpiIconRegular";
            this.lblKpiIconRegular.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconRegular.Text = "⭐";
            this.lblKpiIconRegular.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleRegular.AutoSize = true;
            this.lblKpiTitleRegular.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleRegular.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleRegular.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleRegular.Name = "lblKpiTitleRegular";
            this.lblKpiTitleRegular.Size = new System.Drawing.Size(130, 17);
            this.lblKpiTitleRegular.Text = "HỘI VIÊN TIÊU CHUẨN";

            this.lblKpiRegularCustomers.AutoSize = true;
            this.lblKpiRegularCustomers.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiRegularCustomers.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblKpiRegularCustomers.Location = new System.Drawing.Point(40, 24);
            this.lblKpiRegularCustomers.Name = "lblKpiRegularCustomers";
            this.lblKpiRegularCustomers.Size = new System.Drawing.Size(89, 30);
            this.lblKpiRegularCustomers.Text = "0 Khách";

            this.lblKpiSubRegular.AutoSize = true;
            this.lblKpiSubRegular.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubRegular.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubRegular.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubRegular.Name = "lblKpiSubRegular";
            this.lblKpiSubRegular.Size = new System.Drawing.Size(126, 17);
            this.lblKpiSubRegular.Text = "Hạng Chuẩn & Hạng Bạc";

            // =============================================================
            // SPLITCONTAINER (TRÁI 65% - PHẢI 35%)
            // =============================================================
            this.scMain.BackColor = System.Drawing.Color.FromArgb(244, 247, 245);
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(14, 158);
            this.scMain.Name = "scMain";
            // Panel 1 (Left)
            this.scMain.Panel1.Controls.Add(this.pnlTableWrapper);
            // Panel 2 (Right)
            this.scMain.Panel2.Controls.Add(this.pnlRightCard);
            this.scMain.Panel2MinSize = 350;
            this.scMain.Size = new System.Drawing.Size(1152, 612);
            this.scMain.SplitterDistance = 770;
            this.scMain.SplitterWidth = 8;
            this.scMain.TabIndex = 2;

            // =============================================================
            // CỘT TRÁI: BỘ LỌC, DATAGRIDVIEW & THANH TRẠNG THÁI
            // =============================================================
            this.pnlTableWrapper.BackColor = System.Drawing.Color.White;
            this.pnlTableWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTableWrapper.Controls.Add(this.dgvCustomers);
            this.pnlTableWrapper.Controls.Add(this.pnlTableFooter);
            this.pnlTableWrapper.Controls.Add(this.pnlTopFilter);
            this.pnlTableWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableWrapper.Location = new System.Drawing.Point(0, 0);
            this.pnlTableWrapper.Name = "pnlTableWrapper";
            this.pnlTableWrapper.Size = new System.Drawing.Size(770, 612);
            this.pnlTableWrapper.TabIndex = 0;

            // pnlTopFilter (Thanh tìm kiếm & lọc hạng thành viên)
            this.pnlTopFilter.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlTopFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopFilter.Controls.Add(this.btnExportExcel);
            this.pnlTopFilter.Controls.Add(this.btnLoad);
            this.pnlTopFilter.Controls.Add(this.btnSearch);
            this.pnlTopFilter.Controls.Add(this.cboFilterRank);
            this.pnlTopFilter.Controls.Add(this.txtSearch);
            this.pnlTopFilter.Controls.Add(this.lblSearchTitle);
            this.pnlTopFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlTopFilter.Name = "pnlTopFilter";
            this.pnlTopFilter.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlTopFilter.Size = new System.Drawing.Size(768, 52);
            this.pnlTopFilter.TabIndex = 0;

            // lblSearchTitle
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblSearchTitle.Location = new System.Drawing.Point(10, 15);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(74, 20);
            this.lblSearchTitle.Text = "🔍 Bộ lọc:";

            // txtSearch
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearch.Location = new System.Drawing.Point(88, 11);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tên hoặc SĐT khách...";
            this.txtSearch.Size = new System.Drawing.Size(200, 29);
            this.txtSearch.TabIndex = 0;

            // cboFilterRank
            this.cboFilterRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterRank.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilterRank.FormattingEnabled = true;
            this.cboFilterRank.Items.AddRange(new object[] { "-- Tất cả hạng thẻ --", "Chuẩn", "Bạc", "Vàng", "Kim cương" });
            this.cboFilterRank.Location = new System.Drawing.Point(296, 11);
            this.cboFilterRank.Name = "cboFilterRank";
            this.cboFilterRank.Size = new System.Drawing.Size(145, 29);
            this.cboFilterRank.TabIndex = 1;
            this.cboFilterRank.SelectedIndexChanged += new System.EventHandler(this.cboFilterRank_SelectedIndexChanged);

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(449, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 31);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "⚡ Tìm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnLoad
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLoad.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnLoad.Location = new System.Drawing.Point(523, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 31);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "🔄 Tất cả";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // btnExportExcel
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Location = new System.Drawing.Point(606, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(95, 31);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "📥 Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // dgvCustomers (Bảng dữ liệu hội viên)
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AllowUserToResizeRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCustomers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCustomers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(16, 42, 33); // Dark Green Header
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(16, 42, 33);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomers.ColumnHeadersHeight = 38;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(220, 252, 231); // Green 100
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(20, 83, 45);   // Dark Green
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.EnableHeadersVisualStyles = false;
            this.dgvCustomers.GridColor = System.Drawing.Color.FromArgb(229, 234, 231);
            this.dgvCustomers.Location = new System.Drawing.Point(0, 52);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowHeadersVisible = false;
            this.dgvCustomers.RowTemplate.Height = 36;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(768, 520);
            this.dgvCustomers.TabIndex = 1;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            this.dgvCustomers.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCustomers_CellFormatting);

            // pnlTableFooter (Thanh chân bảng hiển thị tổng số và hướng dẫn)
            this.pnlTableFooter.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlTableFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTableFooter.Controls.Add(this.lblSelectionHint);
            this.pnlTableFooter.Controls.Add(this.lblGridCount);
            this.pnlTableFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTableFooter.Location = new System.Drawing.Point(0, 572);
            this.pnlTableFooter.Name = "pnlTableFooter";
            this.pnlTableFooter.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.pnlTableFooter.Size = new System.Drawing.Size(768, 38);
            this.pnlTableFooter.TabIndex = 2;

            // lblGridCount
            this.lblGridCount.AutoSize = true;
            this.lblGridCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGridCount.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblGridCount.Location = new System.Drawing.Point(8, 8);
            this.lblGridCount.Name = "lblGridCount";
            this.lblGridCount.Size = new System.Drawing.Size(170, 20);
            this.lblGridCount.TabIndex = 0;
            this.lblGridCount.Text = "Tổng số: 0 khách hàng";

            // lblSelectionHint
            this.lblSelectionHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectionHint.AutoSize = true;
            this.lblSelectionHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSelectionHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSelectionHint.Location = new System.Drawing.Point(430, 8);
            this.lblSelectionHint.Name = "lblSelectionHint";
            this.lblSelectionHint.Size = new System.Drawing.Size(325, 20);
            this.lblSelectionHint.TabIndex = 1;
            this.lblSelectionHint.Text = "💡 Nhấp vào khách hàng để xem chi tiết & điểm";

            // =============================================================
            // CỘT PHẢI: FORM CHI TIẾT KHÁCH HÀNG & CRUD
            // =============================================================
            this.pnlRightCard.BackColor = System.Drawing.Color.White;
            this.pnlRightCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightCard.Controls.Add(this.pnlCardBody);
            this.pnlRightCard.Controls.Add(this.lblCardHeader);
            this.pnlRightCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightCard.Location = new System.Drawing.Point(0, 0);
            this.pnlRightCard.Name = "pnlRightCard";
            this.pnlRightCard.Size = new System.Drawing.Size(374, 612);
            this.pnlRightCard.TabIndex = 0;

            // lblCardHeader
            this.lblCardHeader.BackColor = System.Drawing.Color.FromArgb(16, 42, 33);
            this.lblCardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCardHeader.ForeColor = System.Drawing.Color.White;
            this.lblCardHeader.Location = new System.Drawing.Point(0, 0);
            this.lblCardHeader.Name = "lblCardHeader";
            this.lblCardHeader.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblCardHeader.Size = new System.Drawing.Size(372, 40);
            this.lblCardHeader.Text = "👥 HỒ SƠ KHÁCH HÀNG & ĐIỂM THƯỞNG";
            this.lblCardHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlCardBody
            this.pnlCardBody.AutoScroll = true;
            this.pnlCardBody.BackColor = System.Drawing.Color.White;
            this.pnlCardBody.Controls.Add(this.lblNotification);
            this.pnlCardBody.Controls.Add(this.btnClear);
            this.pnlCardBody.Controls.Add(this.btnDelete);
            this.pnlCardBody.Controls.Add(this.btnUpdate);
            this.pnlCardBody.Controls.Add(this.btnAdd);
            this.pnlCardBody.Controls.Add(this.txtAddress);
            this.pnlCardBody.Controls.Add(this.lblAddress);
            this.pnlCardBody.Controls.Add(this.nudRewardPoints);
            this.pnlCardBody.Controls.Add(this.lblRewardPoints);
            this.pnlCardBody.Controls.Add(this.cboMembershipRank);
            this.pnlCardBody.Controls.Add(this.lblMembershipRank);
            this.pnlCardBody.Controls.Add(this.txtPhoneNumber);
            this.pnlCardBody.Controls.Add(this.lblPhoneNumber);
            this.pnlCardBody.Controls.Add(this.txtCustomerName);
            this.pnlCardBody.Controls.Add(this.lblCustomerName);
            this.pnlCardBody.Controls.Add(this.txtCustomerId);
            this.pnlCardBody.Controls.Add(this.lblCustomerId);
            this.pnlCardBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardBody.Location = new System.Drawing.Point(0, 40);
            this.pnlCardBody.Name = "pnlCardBody";
            this.pnlCardBody.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardBody.Size = new System.Drawing.Size(372, 570);
            this.pnlCardBody.TabIndex = 1;

            // lblCustomerId
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomerId.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCustomerId.Location = new System.Drawing.Point(14, 8);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(121, 20);
            this.lblCustomerId.TabIndex = 0;
            this.lblCustomerId.Text = "Mã khách hàng:";

            // txtCustomerId
            this.txtCustomerId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerId.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtCustomerId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCustomerId.Location = new System.Drawing.Point(14, 28);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(342, 29);
            this.txtCustomerId.TabIndex = 1;

            // lblCustomerName
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCustomerName.Location = new System.Drawing.Point(14, 62);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(122, 20);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Tên khách hàng:";

            // txtCustomerName
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.BackColor = System.Drawing.Color.White;
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCustomerName.Location = new System.Drawing.Point(14, 82);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PlaceholderText = "Họ và tên khách hàng...";
            this.txtCustomerName.Size = new System.Drawing.Size(342, 29);
            this.txtCustomerName.TabIndex = 3;

            // lblPhoneNumber
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPhoneNumber.Location = new System.Drawing.Point(14, 116);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(104, 20);
            this.lblPhoneNumber.TabIndex = 4;
            this.lblPhoneNumber.Text = "Số điện thoại:";

            // txtPhoneNumber
            this.txtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNumber.BackColor = System.Drawing.Color.White;
            this.txtPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPhoneNumber.Location = new System.Drawing.Point(14, 136);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.PlaceholderText = "Số điện thoại liên hệ...";
            this.txtPhoneNumber.Size = new System.Drawing.Size(342, 29);
            this.txtPhoneNumber.TabIndex = 5;

            // lblMembershipRank
            this.lblMembershipRank.AutoSize = true;
            this.lblMembershipRank.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblMembershipRank.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblMembershipRank.Location = new System.Drawing.Point(14, 170);
            this.lblMembershipRank.Name = "lblMembershipRank";
            this.lblMembershipRank.Size = new System.Drawing.Size(130, 20);
            this.lblMembershipRank.TabIndex = 6;
            this.lblMembershipRank.Text = "Hạng thành viên:";

            // cboMembershipRank
            this.cboMembershipRank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMembershipRank.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboMembershipRank.FormattingEnabled = true;
            this.cboMembershipRank.Items.AddRange(new object[] { "Chuẩn", "Bạc", "Vàng", "Kim cương" });
            this.cboMembershipRank.Location = new System.Drawing.Point(14, 190);
            this.cboMembershipRank.Name = "cboMembershipRank";
            this.cboMembershipRank.Size = new System.Drawing.Size(165, 29);
            this.cboMembershipRank.TabIndex = 7;

            // lblRewardPoints
            this.lblRewardPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRewardPoints.AutoSize = true;
            this.lblRewardPoints.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRewardPoints.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblRewardPoints.Location = new System.Drawing.Point(191, 170);
            this.lblRewardPoints.Name = "lblRewardPoints";
            this.lblRewardPoints.Size = new System.Drawing.Size(109, 20);
            this.lblRewardPoints.TabIndex = 8;
            this.lblRewardPoints.Text = "Điểm tích lũy:";

            // nudRewardPoints
            this.nudRewardPoints.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRewardPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudRewardPoints.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudRewardPoints.Location = new System.Drawing.Point(191, 190);
            this.nudRewardPoints.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudRewardPoints.Name = "nudRewardPoints";
            this.nudRewardPoints.Size = new System.Drawing.Size(165, 29);
            this.nudRewardPoints.TabIndex = 9;
            this.nudRewardPoints.ThousandsSeparator = true;

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblAddress.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblAddress.Location = new System.Drawing.Point(14, 226);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(111, 20);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Địa chỉ liên hệ:";

            // txtAddress
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtAddress.Location = new System.Drawing.Point(14, 246);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "Địa chỉ liên hệ thường trú của khách hàng...";
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAddress.Size = new System.Drawing.Size(342, 80);
            this.txtAddress.TabIndex = 11;

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(22, 163, 74); // Primary Green
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(14, 340);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(165, 36);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "➕ Thêm khách";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnUpdate
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(37, 99, 235); // Tech Blue
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(191, 340);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(165, 36);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "💾 Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68); // Red
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(14, 384);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(342, 34);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "🗑️ Xóa khách hàng";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnClear
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnClear.Location = new System.Drawing.Point(14, 426);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(342, 34);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "🔄 Làm mới biểu mẫu";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnLoad_Click);

            // lblNotification
            this.lblNotification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotification.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNotification.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblNotification.Location = new System.Drawing.Point(14, 470);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(342, 28);
            this.lblNotification.TabIndex = 16;
            this.lblNotification.Text = "● Hệ thống sẵn sàng.";
            this.lblNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // Finalize FormCustomerManagement
            // 
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlHeaderBar.ResumeLayout(false);
            this.pnlHeaderBar.PerformLayout();
            this.tlpKPI.ResumeLayout(false);

            this.panelKpiCustomers.ResumeLayout(false);
            this.panelKpiCustomers.PerformLayout();
            this.panelKpiVip.ResumeLayout(false);
            this.panelKpiVip.PerformLayout();
            this.panelKpiPoints.ResumeLayout(false);
            this.panelKpiPoints.PerformLayout();
            this.panelKpiRegular.ResumeLayout(false);
            this.panelKpiRegular.PerformLayout();

            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);

            this.pnlTableWrapper.ResumeLayout(false);
            this.pnlTopFilter.ResumeLayout(false);
            this.pnlTopFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.pnlTableFooter.ResumeLayout(false);
            this.pnlTableFooter.PerformLayout();

            this.pnlRightCard.ResumeLayout(false);
            this.pnlCardBody.ResumeLayout(false);
            this.pnlCardBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRewardPoints)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion
    }
}
