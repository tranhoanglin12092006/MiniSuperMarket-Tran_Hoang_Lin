namespace MiniSupermarket.WinForms
{
    partial class FormUserManagement
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

        // 4 Thẻ KPI Nhân sự & Tài khoản
        private System.Windows.Forms.TableLayoutPanel tlpKPI;
        private System.Windows.Forms.Panel panelKpiUsers;
        private System.Windows.Forms.Panel pnlKpi1Accent;
        private System.Windows.Forms.Label lblKpiIconUsers;
        private System.Windows.Forms.Label lblKpiTitleUsers;
        private System.Windows.Forms.Label lblKpiTotalUsers;
        private System.Windows.Forms.Label lblKpiSubUsers;

        private System.Windows.Forms.Panel panelKpiAdmin;
        private System.Windows.Forms.Panel pnlKpi2Accent;
        private System.Windows.Forms.Label lblKpiIconAdmin;
        private System.Windows.Forms.Label lblKpiTitleAdmin;
        private System.Windows.Forms.Label lblKpiAdminUsers;
        private System.Windows.Forms.Label lblKpiSubAdmin;

        private System.Windows.Forms.Panel panelKpiCashier;
        private System.Windows.Forms.Panel pnlKpi3Accent;
        private System.Windows.Forms.Label lblKpiIconCashier;
        private System.Windows.Forms.Label lblKpiTitleCashier;
        private System.Windows.Forms.Label lblKpiCashierUsers;
        private System.Windows.Forms.Label lblKpiSubCashier;

        private System.Windows.Forms.Panel panelKpiActive;
        private System.Windows.Forms.Panel pnlKpi4Accent;
        private System.Windows.Forms.Label lblKpiIconActive;
        private System.Windows.Forms.Label lblKpiTitleActive;
        private System.Windows.Forms.Label lblKpiActiveUsers;
        private System.Windows.Forms.Label lblKpiSubActive;

        // SplitContainer chia đôi: Trái (Bảng tài khoản + Bộ lọc), Phải (Form chi tiết)
        private System.Windows.Forms.SplitContainer scMain;

        // Cột Trái: Bộ lọc, DataGridView & Thanh trạng thái
        private System.Windows.Forms.Panel pnlTableWrapper;
        private System.Windows.Forms.Panel pnlTopFilter;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.TextBox txtSearchUser;
        private System.Windows.Forms.ComboBox cboFilterRole;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel pnlTableFooter;
        private System.Windows.Forms.Label lblGridCount;
        private System.Windows.Forms.Label lblSelectionHint;

        // Cột Phải: Thẻ Chi tiết Tài khoản & Thao tác CRUD
        private System.Windows.Forms.Panel pnlRightCard;
        private System.Windows.Forms.Label lblCardHeader;
        private System.Windows.Forms.Panel pnlCardBody;
        private System.Windows.Forms.Label lblUsernameTitle;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblFullNameTitle;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblEmailTitle;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblPasswordTitle;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRoleTitle;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Panel pnlQuickRole;
        private System.Windows.Forms.Label lblQuickRoleTitle;
        private System.Windows.Forms.Button btnRoleAdmin;
        private System.Windows.Forms.Button btnRoleCashier;
        private System.Windows.Forms.Button btnRoleWarehouse;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnToggleLock;
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
            this.panelKpiUsers = new System.Windows.Forms.Panel();
            this.pnlKpi1Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconUsers = new System.Windows.Forms.Label();
            this.lblKpiTitleUsers = new System.Windows.Forms.Label();
            this.lblKpiTotalUsers = new System.Windows.Forms.Label();
            this.lblKpiSubUsers = new System.Windows.Forms.Label();

            this.panelKpiAdmin = new System.Windows.Forms.Panel();
            this.pnlKpi2Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconAdmin = new System.Windows.Forms.Label();
            this.lblKpiTitleAdmin = new System.Windows.Forms.Label();
            this.lblKpiAdminUsers = new System.Windows.Forms.Label();
            this.lblKpiSubAdmin = new System.Windows.Forms.Label();

            this.panelKpiCashier = new System.Windows.Forms.Panel();
            this.pnlKpi3Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconCashier = new System.Windows.Forms.Label();
            this.lblKpiTitleCashier = new System.Windows.Forms.Label();
            this.lblKpiCashierUsers = new System.Windows.Forms.Label();
            this.lblKpiSubCashier = new System.Windows.Forms.Label();

            this.panelKpiActive = new System.Windows.Forms.Panel();
            this.pnlKpi4Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconActive = new System.Windows.Forms.Label();
            this.lblKpiTitleActive = new System.Windows.Forms.Label();
            this.lblKpiActiveUsers = new System.Windows.Forms.Label();
            this.lblKpiSubActive = new System.Windows.Forms.Label();

            // SplitContainer
            this.scMain = new System.Windows.Forms.SplitContainer();

            // Cột Trái Controls
            this.pnlTableWrapper = new System.Windows.Forms.Panel();
            this.pnlTopFilter = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtSearchUser = new System.Windows.Forms.TextBox();
            this.cboFilterRole = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.pnlTableFooter = new System.Windows.Forms.Panel();
            this.lblGridCount = new System.Windows.Forms.Label();
            this.lblSelectionHint = new System.Windows.Forms.Label();

            // Cột Phải Controls
            this.pnlRightCard = new System.Windows.Forms.Panel();
            this.lblCardHeader = new System.Windows.Forms.Label();
            this.pnlCardBody = new System.Windows.Forms.Panel();
            this.lblUsernameTitle = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblFullNameTitle = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblEmailTitle = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPasswordTitle = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRoleTitle = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.pnlQuickRole = new System.Windows.Forms.Panel();
            this.lblQuickRoleTitle = new System.Windows.Forms.Label();
            this.btnRoleAdmin = new System.Windows.Forms.Button();
            this.btnRoleCashier = new System.Windows.Forms.Button();
            this.btnRoleWarehouse = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnToggleLock = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblNotification = new System.Windows.Forms.Label();

            this.pnlMainContainer.SuspendLayout();
            this.pnlHeaderBar.SuspendLayout();
            this.tlpKPI.SuspendLayout();

            this.panelKpiUsers.SuspendLayout();
            this.panelKpiAdmin.SuspendLayout();
            this.panelKpiCashier.SuspendLayout();
            this.panelKpiActive.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();

            this.pnlTableWrapper.SuspendLayout();
            this.pnlTopFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlTableFooter.SuspendLayout();

            this.pnlRightCard.SuspendLayout();
            this.pnlCardBody.SuspendLayout();
            this.pnlQuickRole.SuspendLayout();
            this.SuspendLayout();

            // 
            // FormUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 245);
            this.ClientSize = new System.Drawing.Size(1180, 780);
            this.Controls.Add(this.pnlMainContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(980, 620);
            this.Name = "FormUserManagement";
            this.Text = "QUẢN LÝ TÀI KHOẢN & PHÂN QUYỀN";
            this.Load += new System.EventHandler(this.FormUserManagement_Load);

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
            this.lblBreadcrumb.Text = "Hệ thống quản lý / Phân quyền & Nhân sự";

            // lblHeaderTitle
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(16, 42, 33); // Dark Green
            this.lblHeaderTitle.Location = new System.Drawing.Point(11, 25);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(460, 30);
            this.lblHeaderTitle.Text = "QUẢN LÝ TÀI KHOẢN & PHÂN QUYỀN NHÂN SỰ";
            this.lblHeaderTitle.UseMnemonic = false;

            // lblHeaderSubtitle
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(12, 48);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(490, 20);
            this.lblHeaderSubtitle.Text = "Cấp phát tài khoản, phân quyền vai trò nhân viên và kiểm soát truy cập hệ thống";

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
            // 4 THẺ KPI CHỈ SỐ NHÂN SỰ (TABLELAYOUTPANEL 4 CỘT 25%)
            // =============================================================
            this.tlpKPI.ColumnCount = 4;
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.Controls.Add(this.panelKpiUsers, 0, 0);
            this.tlpKPI.Controls.Add(this.panelKpiAdmin, 1, 0);
            this.tlpKPI.Controls.Add(this.panelKpiCashier, 2, 0);
            this.tlpKPI.Controls.Add(this.panelKpiActive, 3, 0);
            this.tlpKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKPI.Location = new System.Drawing.Point(14, 80);
            this.tlpKPI.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.tlpKPI.Name = "tlpKPI";
            this.tlpKPI.RowCount = 1;
            this.tlpKPI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKPI.Size = new System.Drawing.Size(1152, 78);
            this.tlpKPI.TabIndex = 1;

            // Card 1: Tổng Số Tài Khoản
            this.panelKpiUsers.BackColor = System.Drawing.Color.White;
            this.panelKpiUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiUsers.Controls.Add(this.lblKpiSubUsers);
            this.panelKpiUsers.Controls.Add(this.lblKpiTotalUsers);
            this.panelKpiUsers.Controls.Add(this.lblKpiTitleUsers);
            this.panelKpiUsers.Controls.Add(this.lblKpiIconUsers);
            this.panelKpiUsers.Controls.Add(this.pnlKpi1Accent);
            this.panelKpiUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiUsers.Location = new System.Drawing.Point(0, 4);
            this.panelKpiUsers.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiUsers.Name = "panelKpiUsers";
            this.panelKpiUsers.Size = new System.Drawing.Size(282, 70);
            this.panelKpiUsers.TabIndex = 0;

            this.pnlKpi1Accent.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.pnlKpi1Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi1Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi1Accent.Name = "pnlKpi1Accent";
            this.pnlKpi1Accent.Size = new System.Drawing.Size(280, 3);
            this.pnlKpi1Accent.TabIndex = 0;

            this.lblKpiIconUsers.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconUsers.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconUsers.Name = "lblKpiIconUsers";
            this.lblKpiIconUsers.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconUsers.Text = "👥";
            this.lblKpiIconUsers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleUsers.AutoSize = true;
            this.lblKpiTitleUsers.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleUsers.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleUsers.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleUsers.Name = "lblKpiTitleUsers";
            this.lblKpiTitleUsers.Size = new System.Drawing.Size(128, 17);
            this.lblKpiTitleUsers.Text = "TỔNG SỐ TÀI KHOẢN";

            this.lblKpiTotalUsers.AutoSize = true;
            this.lblKpiTotalUsers.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotalUsers.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblKpiTotalUsers.Location = new System.Drawing.Point(40, 24);
            this.lblKpiTotalUsers.Name = "lblKpiTotalUsers";
            this.lblKpiTotalUsers.Size = new System.Drawing.Size(76, 30);
            this.lblKpiTotalUsers.Text = "0 User";

            this.lblKpiSubUsers.AutoSize = true;
            this.lblKpiSubUsers.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubUsers.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubUsers.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubUsers.Name = "lblKpiSubUsers";
            this.lblKpiSubUsers.Size = new System.Drawing.Size(120, 17);
            this.lblKpiSubUsers.Text = "Nhân sự trong hệ thống";

            // Card 2: Quản Trị Viên Admin
            this.panelKpiAdmin.BackColor = System.Drawing.Color.White;
            this.panelKpiAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiAdmin.Controls.Add(this.lblKpiSubAdmin);
            this.panelKpiAdmin.Controls.Add(this.lblKpiAdminUsers);
            this.panelKpiAdmin.Controls.Add(this.lblKpiTitleAdmin);
            this.panelKpiAdmin.Controls.Add(this.lblKpiIconAdmin);
            this.panelKpiAdmin.Controls.Add(this.pnlKpi2Accent);
            this.panelKpiAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiAdmin.Location = new System.Drawing.Point(288, 4);
            this.panelKpiAdmin.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiAdmin.Name = "panelKpiAdmin";
            this.panelKpiAdmin.Size = new System.Drawing.Size(282, 70);
            this.panelKpiAdmin.TabIndex = 1;

            this.pnlKpi2Accent.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.pnlKpi2Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi2Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi2Accent.Name = "pnlKpi2Accent";
            this.pnlKpi2Accent.Size = new System.Drawing.Size(280, 3);
            this.pnlKpi2Accent.TabIndex = 0;

            this.lblKpiIconAdmin.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconAdmin.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconAdmin.Name = "lblKpiIconAdmin";
            this.lblKpiIconAdmin.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconAdmin.Text = "🛡️";
            this.lblKpiIconAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleAdmin.AutoSize = true;
            this.lblKpiTitleAdmin.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleAdmin.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleAdmin.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleAdmin.Name = "lblKpiTitleAdmin";
            this.lblKpiTitleAdmin.Size = new System.Drawing.Size(107, 17);
            this.lblKpiTitleAdmin.Text = "QUẢN TRỊ VIÊN";

            this.lblKpiAdminUsers.AutoSize = true;
            this.lblKpiAdminUsers.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiAdminUsers.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblKpiAdminUsers.Location = new System.Drawing.Point(40, 24);
            this.lblKpiAdminUsers.Name = "lblKpiAdminUsers";
            this.lblKpiAdminUsers.Size = new System.Drawing.Size(95, 30);
            this.lblKpiAdminUsers.Text = "0 Admin";

            this.lblKpiSubAdmin.AutoSize = true;
            this.lblKpiSubAdmin.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubAdmin.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubAdmin.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubAdmin.Name = "lblKpiSubAdmin";
            this.lblKpiSubAdmin.Size = new System.Drawing.Size(106, 17);
            this.lblKpiSubAdmin.Text = "Toàn quyền hệ thống";

            // Card 3: Thu Ngân POS
            this.panelKpiCashier.BackColor = System.Drawing.Color.White;
            this.panelKpiCashier.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiCashier.Controls.Add(this.lblKpiSubCashier);
            this.panelKpiCashier.Controls.Add(this.lblKpiCashierUsers);
            this.panelKpiCashier.Controls.Add(this.lblKpiTitleCashier);
            this.panelKpiCashier.Controls.Add(this.lblKpiIconCashier);
            this.panelKpiCashier.Controls.Add(this.pnlKpi3Accent);
            this.panelKpiCashier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiCashier.Location = new System.Drawing.Point(576, 4);
            this.panelKpiCashier.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiCashier.Name = "panelKpiCashier";
            this.panelKpiCashier.Size = new System.Drawing.Size(282, 70);
            this.panelKpiCashier.TabIndex = 2;

            this.pnlKpi3Accent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlKpi3Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi3Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi3Accent.Name = "pnlKpi3Accent";
            this.pnlKpi3Accent.Size = new System.Drawing.Size(280, 3);
            this.pnlKpi3Accent.TabIndex = 0;

            this.lblKpiIconCashier.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconCashier.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconCashier.Name = "lblKpiIconCashier";
            this.lblKpiIconCashier.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconCashier.Text = "🛒";
            this.lblKpiIconCashier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleCashier.AutoSize = true;
            this.lblKpiTitleCashier.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleCashier.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleCashier.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleCashier.Name = "lblKpiTitleCashier";
            this.lblKpiTitleCashier.Size = new System.Drawing.Size(124, 17);
            this.lblKpiTitleCashier.Text = "THU NGÂN & KHO";

            this.lblKpiCashierUsers.AutoSize = true;
            this.lblKpiCashierUsers.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiCashierUsers.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblKpiCashierUsers.Location = new System.Drawing.Point(40, 24);
            this.lblKpiCashierUsers.Name = "lblKpiCashierUsers";
            this.lblKpiCashierUsers.Size = new System.Drawing.Size(95, 30);
            this.lblKpiCashierUsers.Text = "0 Nhân sự";

            this.lblKpiSubCashier.AutoSize = true;
            this.lblKpiSubCashier.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubCashier.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubCashier.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubCashier.Name = "lblKpiSubCashier";
            this.lblKpiSubCashier.Size = new System.Drawing.Size(107, 17);
            this.lblKpiSubCashier.Text = "Bán hàng POS & Kho";

            // Card 4: Trạng Thái Hoạt Động
            this.panelKpiActive.BackColor = System.Drawing.Color.White;
            this.panelKpiActive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiActive.Controls.Add(this.lblKpiSubActive);
            this.panelKpiActive.Controls.Add(this.lblKpiActiveUsers);
            this.panelKpiActive.Controls.Add(this.lblKpiTitleActive);
            this.panelKpiActive.Controls.Add(this.lblKpiIconActive);
            this.panelKpiActive.Controls.Add(this.pnlKpi4Accent);
            this.panelKpiActive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiActive.Location = new System.Drawing.Point(864, 4);
            this.panelKpiActive.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelKpiActive.Name = "panelKpiActive";
            this.panelKpiActive.Size = new System.Drawing.Size(288, 70);
            this.panelKpiActive.TabIndex = 3;

            this.pnlKpi4Accent.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.pnlKpi4Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi4Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi4Accent.Name = "pnlKpi4Accent";
            this.pnlKpi4Accent.Size = new System.Drawing.Size(286, 3);
            this.pnlKpi4Accent.TabIndex = 0;

            this.lblKpiIconActive.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconActive.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconActive.Name = "lblKpiIconActive";
            this.lblKpiIconActive.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconActive.Text = "🟢";
            this.lblKpiIconActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleActive.AutoSize = true;
            this.lblKpiTitleActive.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleActive.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleActive.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleActive.Name = "lblKpiTitleActive";
            this.lblKpiTitleActive.Size = new System.Drawing.Size(126, 17);
            this.lblKpiTitleActive.Text = "HOẠT ĐỘNG HỢP LỆ";

            this.lblKpiActiveUsers.AutoSize = true;
            this.lblKpiActiveUsers.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiActiveUsers.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.lblKpiActiveUsers.Location = new System.Drawing.Point(40, 24);
            this.lblKpiActiveUsers.Name = "lblKpiActiveUsers";
            this.lblKpiActiveUsers.Size = new System.Drawing.Size(71, 30);
            this.lblKpiActiveUsers.Text = "100%";

            this.lblKpiSubActive.AutoSize = true;
            this.lblKpiSubActive.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubActive.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubActive.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubActive.Name = "lblKpiSubActive";
            this.lblKpiSubActive.Size = new System.Drawing.Size(117, 17);
            this.lblKpiSubActive.Text = "Tài khoản mở khóa";

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
            this.pnlTableWrapper.Controls.Add(this.dgvUsers);
            this.pnlTableWrapper.Controls.Add(this.pnlTableFooter);
            this.pnlTableWrapper.Controls.Add(this.pnlTopFilter);
            this.pnlTableWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableWrapper.Location = new System.Drawing.Point(0, 0);
            this.pnlTableWrapper.Name = "pnlTableWrapper";
            this.pnlTableWrapper.Size = new System.Drawing.Size(770, 612);
            this.pnlTableWrapper.TabIndex = 0;

            // pnlTopFilter (Thanh tìm kiếm & lọc vai trò)
            this.pnlTopFilter.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlTopFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopFilter.Controls.Add(this.btnLoad);
            this.pnlTopFilter.Controls.Add(this.btnSearch);
            this.pnlTopFilter.Controls.Add(this.cboFilterRole);
            this.pnlTopFilter.Controls.Add(this.txtSearchUser);
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
            this.lblSearchTitle.Size = new System.Drawing.Size(78, 20);
            this.lblSearchTitle.Text = "🔍 Bộ lọc:";

            // txtSearchUser
            this.txtSearchUser.BackColor = System.Drawing.Color.White;
            this.txtSearchUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchUser.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearchUser.Location = new System.Drawing.Point(92, 11);
            this.txtSearchUser.Name = "txtSearchUser";
            this.txtSearchUser.PlaceholderText = "Tìm theo username, họ tên, email...";
            this.txtSearchUser.Size = new System.Drawing.Size(260, 29);
            this.txtSearchUser.TabIndex = 0;

            // cboFilterRole
            this.cboFilterRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterRole.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilterRole.FormattingEnabled = true;
            this.cboFilterRole.Items.AddRange(new object[] { "-- Tất cả vai trò --", "Admin", "Cashier", "Warehouse" });
            this.cboFilterRole.Location = new System.Drawing.Point(360, 11);
            this.cboFilterRole.Name = "cboFilterRole";
            this.cboFilterRole.Size = new System.Drawing.Size(160, 29);
            this.cboFilterRole.TabIndex = 1;

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(528, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 31);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "⚡ Tìm";
            this.btnSearch.UseVisualStyleBackColor = false;

            // btnLoad
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnLoad.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnLoad.Location = new System.Drawing.Point(616, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 31);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "🔄 Tất cả";
            this.btnLoad.UseVisualStyleBackColor = false;

            // dgvUsers (Bảng tài khoản nhân viên)
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(16, 42, 33); // Dark Green Header
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(16, 42, 33);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeight = 38;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(220, 252, 231); // Green 100
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(20, 83, 45);   // Dark Green
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(229, 234, 231);
            this.dgvUsers.Location = new System.Drawing.Point(0, 52);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Height = 36;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(768, 520);
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);

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
            this.lblGridCount.Size = new System.Drawing.Size(160, 20);
            this.lblGridCount.TabIndex = 0;
            this.lblGridCount.Text = "Tổng số: 0 tài khoản";

            // lblSelectionHint
            this.lblSelectionHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectionHint.AutoSize = true;
            this.lblSelectionHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSelectionHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSelectionHint.Location = new System.Drawing.Point(440, 8);
            this.lblSelectionHint.Name = "lblSelectionHint";
            this.lblSelectionHint.Size = new System.Drawing.Size(315, 20);
            this.lblSelectionHint.TabIndex = 1;
            this.lblSelectionHint.Text = "💡 Nhấp vào tài khoản để xem và đổi vai trò";

            // =============================================================
            // CỘT PHẢI: FORM CHI TIẾT TÀI KHOẢN & PHÂN QUYỀN
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
            this.lblCardHeader.Text = "👤 THÔNG TIN & PHÂN QUYỀN";
            this.lblCardHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlCardBody
            this.pnlCardBody.AutoScroll = true;
            this.pnlCardBody.BackColor = System.Drawing.Color.White;
            this.pnlCardBody.Controls.Add(this.lblNotification);
            this.pnlCardBody.Controls.Add(this.btnClear);
            this.pnlCardBody.Controls.Add(this.btnToggleLock);
            this.pnlCardBody.Controls.Add(this.btnResetPassword);
            this.pnlCardBody.Controls.Add(this.btnUpdateUser);
            this.pnlCardBody.Controls.Add(this.btnAddUser);
            this.pnlCardBody.Controls.Add(this.pnlQuickRole);
            this.pnlCardBody.Controls.Add(this.cboRole);
            this.pnlCardBody.Controls.Add(this.lblRoleTitle);
            this.pnlCardBody.Controls.Add(this.txtPassword);
            this.pnlCardBody.Controls.Add(this.lblPasswordTitle);
            this.pnlCardBody.Controls.Add(this.txtEmail);
            this.pnlCardBody.Controls.Add(this.lblEmailTitle);
            this.pnlCardBody.Controls.Add(this.txtFullName);
            this.pnlCardBody.Controls.Add(this.lblFullNameTitle);
            this.pnlCardBody.Controls.Add(this.txtUsername);
            this.pnlCardBody.Controls.Add(this.lblUsernameTitle);
            this.pnlCardBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardBody.Location = new System.Drawing.Point(0, 40);
            this.pnlCardBody.Name = "pnlCardBody";
            this.pnlCardBody.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardBody.Size = new System.Drawing.Size(372, 570);
            this.pnlCardBody.TabIndex = 1;

            // lblUsernameTitle
            this.lblUsernameTitle.AutoSize = true;
            this.lblUsernameTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblUsernameTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblUsernameTitle.Location = new System.Drawing.Point(14, 8);
            this.lblUsernameTitle.Name = "lblUsernameTitle";
            this.lblUsernameTitle.Size = new System.Drawing.Size(116, 20);
            this.lblUsernameTitle.TabIndex = 0;
            this.lblUsernameTitle.Text = "Tên đăng nhập:";

            // txtUsername
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.BackColor = System.Drawing.Color.White;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtUsername.Location = new System.Drawing.Point(14, 28);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Tên đăng nhập (username)...";
            this.txtUsername.Size = new System.Drawing.Size(342, 29);
            this.txtUsername.TabIndex = 1;

            // lblFullNameTitle
            this.lblFullNameTitle.AutoSize = true;
            this.lblFullNameTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblFullNameTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblFullNameTitle.Location = new System.Drawing.Point(14, 62);
            this.lblFullNameTitle.Name = "lblFullNameTitle";
            this.lblFullNameTitle.Size = new System.Drawing.Size(133, 20);
            this.lblFullNameTitle.TabIndex = 2;
            this.lblFullNameTitle.Text = "Họ tên nhân viên:";

            // txtFullName
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.BackColor = System.Drawing.Color.White;
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFullName.Location = new System.Drawing.Point(14, 82);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PlaceholderText = "Họ và tên đầy đủ...";
            this.txtFullName.Size = new System.Drawing.Size(342, 29);
            this.txtFullName.TabIndex = 3;

            // lblEmailTitle
            this.lblEmailTitle.AutoSize = true;
            this.lblEmailTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblEmailTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblEmailTitle.Location = new System.Drawing.Point(14, 116);
            this.lblEmailTitle.Name = "lblEmailTitle";
            this.lblEmailTitle.Size = new System.Drawing.Size(124, 20);
            this.lblEmailTitle.TabIndex = 4;
            this.lblEmailTitle.Text = "Email nhân viên:";

            // txtEmail
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.BackColor = System.Drawing.Color.White;
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtEmail.Location = new System.Drawing.Point(14, 136);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Email liên hệ...";
            this.txtEmail.Size = new System.Drawing.Size(342, 29);
            this.txtEmail.TabIndex = 5;

            // lblPasswordTitle
            this.lblPasswordTitle.AutoSize = true;
            this.lblPasswordTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPasswordTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPasswordTitle.Location = new System.Drawing.Point(14, 170);
            this.lblPasswordTitle.Name = "lblPasswordTitle";
            this.lblPasswordTitle.Size = new System.Drawing.Size(185, 20);
            this.lblPasswordTitle.TabIndex = 6;
            this.lblPasswordTitle.Text = "Mật khẩu (Khi tạo/đổi lại):";

            // txtPassword
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtPassword.Location = new System.Drawing.Point(14, 190);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Mật khẩu tài khoản...";
            this.txtPassword.Size = new System.Drawing.Size(342, 29);
            this.txtPassword.TabIndex = 7;

            // lblRoleTitle
            this.lblRoleTitle.AutoSize = true;
            this.lblRoleTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblRoleTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblRoleTitle.Location = new System.Drawing.Point(14, 224);
            this.lblRoleTitle.Name = "lblRoleTitle";
            this.lblRoleTitle.Size = new System.Drawing.Size(126, 20);
            this.lblRoleTitle.TabIndex = 8;
            this.lblRoleTitle.Text = "Vai trò hệ thống:";

            // cboRole
            this.cboRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(14, 244);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(342, 29);
            this.cboRole.TabIndex = 9;
            this.cboRole.SelectedIndexChanged += new System.EventHandler(this.cboRole_SelectedIndexChanged);

            // pnlQuickRole
            this.pnlQuickRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlQuickRole.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlQuickRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuickRole.Controls.Add(this.btnRoleWarehouse);
            this.pnlQuickRole.Controls.Add(this.btnRoleCashier);
            this.pnlQuickRole.Controls.Add(this.btnRoleAdmin);
            this.pnlQuickRole.Controls.Add(this.lblQuickRoleTitle);
            this.pnlQuickRole.Location = new System.Drawing.Point(14, 282);
            this.pnlQuickRole.Name = "pnlQuickRole";
            this.pnlQuickRole.Padding = new System.Windows.Forms.Padding(6);
            this.pnlQuickRole.Size = new System.Drawing.Size(342, 75);
            this.pnlQuickRole.TabIndex = 10;

            // lblQuickRoleTitle
            this.lblQuickRoleTitle.AutoSize = true;
            this.lblQuickRoleTitle.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblQuickRoleTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblQuickRoleTitle.Location = new System.Drawing.Point(6, 6);
            this.lblQuickRoleTitle.Name = "lblQuickRoleTitle";
            this.lblQuickRoleTitle.Size = new System.Drawing.Size(250, 19);
            this.lblQuickRoleTitle.TabIndex = 0;
            this.lblQuickRoleTitle.Text = "⚡ Đổi vai trò nhanh (Lưu tức thì):";

            // btnRoleAdmin
            this.btnRoleAdmin.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnRoleAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoleAdmin.FlatAppearance.BorderSize = 0;
            this.btnRoleAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoleAdmin.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnRoleAdmin.ForeColor = System.Drawing.Color.White;
            this.btnRoleAdmin.Location = new System.Drawing.Point(6, 30);
            this.btnRoleAdmin.Name = "btnRoleAdmin";
            this.btnRoleAdmin.Size = new System.Drawing.Size(102, 34);
            this.btnRoleAdmin.TabIndex = 1;
            this.btnRoleAdmin.Text = "🛡️ Admin";
            this.btnRoleAdmin.UseVisualStyleBackColor = false;
            this.btnRoleAdmin.Click += new System.EventHandler(this.btnRoleAdmin_Click);

            // btnRoleCashier
            this.btnRoleCashier.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnRoleCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoleCashier.FlatAppearance.BorderSize = 0;
            this.btnRoleCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoleCashier.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnRoleCashier.ForeColor = System.Drawing.Color.White;
            this.btnRoleCashier.Location = new System.Drawing.Point(114, 30);
            this.btnRoleCashier.Name = "btnRoleCashier";
            this.btnRoleCashier.Size = new System.Drawing.Size(108, 34);
            this.btnRoleCashier.TabIndex = 2;
            this.btnRoleCashier.Text = "🛒 Cashier";
            this.btnRoleCashier.UseVisualStyleBackColor = false;
            this.btnRoleCashier.Click += new System.EventHandler(this.btnRoleCashier_Click);

            // btnRoleWarehouse
            this.btnRoleWarehouse.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.btnRoleWarehouse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoleWarehouse.FlatAppearance.BorderSize = 0;
            this.btnRoleWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoleWarehouse.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnRoleWarehouse.ForeColor = System.Drawing.Color.White;
            this.btnRoleWarehouse.Location = new System.Drawing.Point(228, 30);
            this.btnRoleWarehouse.Name = "btnRoleWarehouse";
            this.btnRoleWarehouse.Size = new System.Drawing.Size(102, 34);
            this.btnRoleWarehouse.TabIndex = 3;
            this.btnRoleWarehouse.Text = "📦 Kho";
            this.btnRoleWarehouse.UseVisualStyleBackColor = false;
            this.btnRoleWarehouse.Click += new System.EventHandler(this.btnRoleWarehouse_Click);

            // btnAddUser
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(14, 368);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(165, 36);
            this.btnAddUser.TabIndex = 11;
            this.btnAddUser.Text = "➕ Thêm tài khoản";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);

            // btnUpdateUser
            this.btnUpdateUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateUser.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnUpdateUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateUser.FlatAppearance.BorderSize = 0;
            this.btnUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdateUser.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUser.Location = new System.Drawing.Point(191, 368);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(165, 36);
            this.btnUpdateUser.TabIndex = 12;
            this.btnUpdateUser.Text = "💾 Cập nhật";
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);

            // btnResetPassword
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            this.btnResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetPassword.FlatAppearance.BorderSize = 0;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.Location = new System.Drawing.Point(14, 412);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(165, 34);
            this.btnResetPassword.TabIndex = 13;
            this.btnResetPassword.Text = "🔑 Reset MK 123456";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);

            // btnToggleLock
            this.btnToggleLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnToggleLock.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.btnToggleLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleLock.FlatAppearance.BorderSize = 0;
            this.btnToggleLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleLock.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnToggleLock.ForeColor = System.Drawing.Color.White;
            this.btnToggleLock.Location = new System.Drawing.Point(191, 412);
            this.btnToggleLock.Name = "btnToggleLock";
            this.btnToggleLock.Size = new System.Drawing.Size(165, 34);
            this.btnToggleLock.TabIndex = 14;
            this.btnToggleLock.Text = "🔒 Khóa tài khoản";
            this.btnToggleLock.UseVisualStyleBackColor = false;
            this.btnToggleLock.Click += new System.EventHandler(this.btnToggleLock_Click);

            // btnClear
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnClear.Location = new System.Drawing.Point(14, 454);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(342, 34);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "🔄 Làm mới biểu mẫu";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // lblNotification
            this.lblNotification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotification.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNotification.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblNotification.Location = new System.Drawing.Point(14, 498);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(342, 28);
            this.lblNotification.TabIndex = 16;
            this.lblNotification.Text = "● Hệ thống sẵn sàng.";
            this.lblNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // Finalize FormUserManagement
            // 
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlHeaderBar.ResumeLayout(false);
            this.pnlHeaderBar.PerformLayout();
            this.tlpKPI.ResumeLayout(false);

            this.panelKpiUsers.ResumeLayout(false);
            this.panelKpiUsers.PerformLayout();
            this.panelKpiAdmin.ResumeLayout(false);
            this.panelKpiAdmin.PerformLayout();
            this.panelKpiCashier.ResumeLayout(false);
            this.panelKpiCashier.PerformLayout();
            this.panelKpiActive.ResumeLayout(false);
            this.panelKpiActive.PerformLayout();

            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);

            this.pnlTableWrapper.ResumeLayout(false);
            this.pnlTopFilter.ResumeLayout(false);
            this.pnlTopFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlTableFooter.ResumeLayout(false);
            this.pnlTableFooter.PerformLayout();

            this.pnlRightCard.ResumeLayout(false);
            this.pnlCardBody.ResumeLayout(false);
            this.pnlCardBody.PerformLayout();
            this.pnlQuickRole.ResumeLayout(false);
            this.pnlQuickRole.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion
    }
}
