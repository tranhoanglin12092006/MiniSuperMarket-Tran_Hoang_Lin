namespace MiniSupermarket.WinForms
{
    partial class FormCategoryManagement
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

        // 3 Thẻ KPI Danh mục
        private System.Windows.Forms.TableLayoutPanel tlpKPI;
        private System.Windows.Forms.Panel panelKpiCategories;
        private System.Windows.Forms.Panel pnlKpi1Accent;
        private System.Windows.Forms.Label lblKpiIconCategories;
        private System.Windows.Forms.Label lblKpiTitleCategories;
        private System.Windows.Forms.Label lblKpiTotalCategories;
        private System.Windows.Forms.Label lblKpiSubCategories;

        private System.Windows.Forms.Panel panelKpiProducts;
        private System.Windows.Forms.Panel pnlKpi2Accent;
        private System.Windows.Forms.Label lblKpiIconProducts;
        private System.Windows.Forms.Label lblKpiTitleProducts;
        private System.Windows.Forms.Label lblKpiTotalProducts;
        private System.Windows.Forms.Label lblKpiSubProducts;

        private System.Windows.Forms.Panel panelKpiStatus;
        private System.Windows.Forms.Panel pnlKpi3Accent;
        private System.Windows.Forms.Label lblKpiIconStatus;
        private System.Windows.Forms.Label lblKpiTitleStatus;
        private System.Windows.Forms.Label lblKpiStatus;
        private System.Windows.Forms.Label lblKpiSubStatus;

        // SplitContainer chia đôi: Trái (Bảng danh mục + Bộ lọc), Phải (Form chi tiết)
        private System.Windows.Forms.SplitContainer scMain;

        // Cột Trái: Bộ lọc, DataGridView & Thanh trạng thái
        private System.Windows.Forms.Panel pnlTableWrapper;
        private System.Windows.Forms.Panel pnlTopFilter;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel pnlTableFooter;
        private System.Windows.Forms.Label lblGridCount;
        private System.Windows.Forms.Label lblSelectionHint;

        // Cột Phải: Thẻ Chi tiết Nhóm hàng & Thao tác CRUD
        private System.Windows.Forms.Panel pnlRightCard;
        private System.Windows.Forms.Label lblCardHeader;
        private System.Windows.Forms.Panel pnlCardBody;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
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

            // 3 Thẻ KPI
            this.tlpKPI = new System.Windows.Forms.TableLayoutPanel();
            this.panelKpiCategories = new System.Windows.Forms.Panel();
            this.pnlKpi1Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconCategories = new System.Windows.Forms.Label();
            this.lblKpiTitleCategories = new System.Windows.Forms.Label();
            this.lblKpiTotalCategories = new System.Windows.Forms.Label();
            this.lblKpiSubCategories = new System.Windows.Forms.Label();

            this.panelKpiProducts = new System.Windows.Forms.Panel();
            this.pnlKpi2Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconProducts = new System.Windows.Forms.Label();
            this.lblKpiTitleProducts = new System.Windows.Forms.Label();
            this.lblKpiTotalProducts = new System.Windows.Forms.Label();
            this.lblKpiSubProducts = new System.Windows.Forms.Label();

            this.panelKpiStatus = new System.Windows.Forms.Panel();
            this.pnlKpi3Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconStatus = new System.Windows.Forms.Label();
            this.lblKpiTitleStatus = new System.Windows.Forms.Label();
            this.lblKpiStatus = new System.Windows.Forms.Label();
            this.lblKpiSubStatus = new System.Windows.Forms.Label();

            // SplitContainer
            this.scMain = new System.Windows.Forms.SplitContainer();

            // Cột Trái Controls
            this.pnlTableWrapper = new System.Windows.Forms.Panel();
            this.pnlTopFilter = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.pnlTableFooter = new System.Windows.Forms.Panel();
            this.lblGridCount = new System.Windows.Forms.Label();
            this.lblSelectionHint = new System.Windows.Forms.Label();

            // Cột Phải Controls
            this.pnlRightCard = new System.Windows.Forms.Panel();
            this.lblCardHeader = new System.Windows.Forms.Label();
            this.pnlCardBody = new System.Windows.Forms.Panel();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblNotification = new System.Windows.Forms.Label();

            this.pnlMainContainer.SuspendLayout();
            this.pnlHeaderBar.SuspendLayout();
            this.tlpKPI.SuspendLayout();

            this.panelKpiCategories.SuspendLayout();
            this.panelKpiProducts.SuspendLayout();
            this.panelKpiStatus.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();

            this.pnlTableWrapper.SuspendLayout();
            this.pnlTopFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.pnlTableFooter.SuspendLayout();

            this.pnlRightCard.SuspendLayout();
            this.pnlCardBody.SuspendLayout();
            this.SuspendLayout();

            // 
            // FormCategoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 245); // Soft SaaS background
            this.ClientSize = new System.Drawing.Size(1150, 750);
            this.Controls.Add(this.pnlMainContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Name = "FormCategoryManagement";
            this.Text = "QUẢN LÝ DANH MỤC NHÓM HÀNG";
            this.Load += new System.EventHandler(this.FormCategoryManagement_Load);

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
            this.pnlMainContainer.Size = new System.Drawing.Size(1150, 750);
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
            this.pnlHeaderBar.Size = new System.Drawing.Size(1122, 70);
            this.pnlHeaderBar.TabIndex = 0;

            // lblBreadcrumb
            this.lblBreadcrumb.AutoSize = true;
            this.lblBreadcrumb.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBreadcrumb.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblBreadcrumb.Location = new System.Drawing.Point(12, 6);
            this.lblBreadcrumb.Name = "lblBreadcrumb";
            this.lblBreadcrumb.Size = new System.Drawing.Size(262, 19);
            this.lblBreadcrumb.Text = "Hệ thống quản lý / Quản lý ngành hàng & Danh mục";

            // lblHeaderTitle
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(16, 42, 33); // Dark Green
            this.lblHeaderTitle.Location = new System.Drawing.Point(11, 25);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(370, 30);
            this.lblHeaderTitle.Text = "QUẢN LÝ DANH MỤC NHÓM HÀNG";
            this.lblHeaderTitle.UseMnemonic = false;

            // lblHeaderSubtitle
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(12, 48);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(395, 20);
            this.lblHeaderSubtitle.Text = "Phân loại sản phẩm, tổ chức cây ngành hàng và định danh nhóm sản phẩm";

            // lblLiveSyncBadge
            this.lblLiveSyncBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLiveSyncBadge.BackColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblLiveSyncBadge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblLiveSyncBadge.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblLiveSyncBadge.Location = new System.Drawing.Point(985, 20);
            this.lblLiveSyncBadge.Name = "lblLiveSyncBadge";
            this.lblLiveSyncBadge.Size = new System.Drawing.Size(120, 26);
            this.lblLiveSyncBadge.Text = "● Đã kết nối API";
            this.lblLiveSyncBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // =============================================================
            // 3 THẺ KPI CHỈ SỐ DANH MỤC (TABLELAYOUTPANEL 3 CỘT 33.33%)
            // =============================================================
            this.tlpKPI.ColumnCount = 3;
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlpKPI.Controls.Add(this.panelKpiCategories, 0, 0);
            this.tlpKPI.Controls.Add(this.panelKpiProducts, 1, 0);
            this.tlpKPI.Controls.Add(this.panelKpiStatus, 2, 0);
            this.tlpKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKPI.Location = new System.Drawing.Point(14, 80);
            this.tlpKPI.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.tlpKPI.Name = "tlpKPI";
            this.tlpKPI.RowCount = 1;
            this.tlpKPI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKPI.Size = new System.Drawing.Size(1122, 78);
            this.tlpKPI.TabIndex = 1;

            // Card 1: Tổng Số Nhóm Hàng
            this.panelKpiCategories.BackColor = System.Drawing.Color.White;
            this.panelKpiCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiCategories.Controls.Add(this.lblKpiSubCategories);
            this.panelKpiCategories.Controls.Add(this.lblKpiTotalCategories);
            this.panelKpiCategories.Controls.Add(this.lblKpiTitleCategories);
            this.panelKpiCategories.Controls.Add(this.lblKpiIconCategories);
            this.panelKpiCategories.Controls.Add(this.pnlKpi1Accent);
            this.panelKpiCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiCategories.Location = new System.Drawing.Point(0, 4);
            this.panelKpiCategories.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiCategories.Name = "panelKpiCategories";
            this.panelKpiCategories.Size = new System.Drawing.Size(368, 70);
            this.panelKpiCategories.TabIndex = 0;

            this.pnlKpi1Accent.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.pnlKpi1Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi1Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi1Accent.Name = "pnlKpi1Accent";
            this.pnlKpi1Accent.Size = new System.Drawing.Size(366, 3);
            this.pnlKpi1Accent.TabIndex = 0;

            this.lblKpiIconCategories.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconCategories.Location = new System.Drawing.Point(8, 12);
            this.lblKpiIconCategories.Name = "lblKpiIconCategories";
            this.lblKpiIconCategories.Size = new System.Drawing.Size(34, 30);
            this.lblKpiIconCategories.Text = "🏷️";
            this.lblKpiIconCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleCategories.AutoSize = true;
            this.lblKpiTitleCategories.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleCategories.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleCategories.Location = new System.Drawing.Point(44, 9);
            this.lblKpiTitleCategories.Name = "lblKpiTitleCategories";
            this.lblKpiTitleCategories.Size = new System.Drawing.Size(126, 17);
            this.lblKpiTitleCategories.Text = "TỔNG SỐ NHÓM HÀNG";

            this.lblKpiTotalCategories.AutoSize = true;
            this.lblKpiTotalCategories.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotalCategories.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblKpiTotalCategories.Location = new System.Drawing.Point(44, 24);
            this.lblKpiTotalCategories.Name = "lblKpiTotalCategories";
            this.lblKpiTotalCategories.Size = new System.Drawing.Size(83, 30);
            this.lblKpiTotalCategories.Text = "0 nhóm";

            this.lblKpiSubCategories.AutoSize = true;
            this.lblKpiSubCategories.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubCategories.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubCategories.Location = new System.Drawing.Point(44, 50);
            this.lblKpiSubCategories.Name = "lblKpiSubCategories";
            this.lblKpiSubCategories.Size = new System.Drawing.Size(125, 17);
            this.lblKpiSubCategories.Text = "Danh mục kinh doanh";

            // Card 2: Sản Phẩm Phân Loại
            this.panelKpiProducts.BackColor = System.Drawing.Color.White;
            this.panelKpiProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiProducts.Controls.Add(this.lblKpiSubProducts);
            this.panelKpiProducts.Controls.Add(this.lblKpiTotalProducts);
            this.panelKpiProducts.Controls.Add(this.lblKpiTitleProducts);
            this.panelKpiProducts.Controls.Add(this.lblKpiIconProducts);
            this.panelKpiProducts.Controls.Add(this.pnlKpi2Accent);
            this.panelKpiProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiProducts.Location = new System.Drawing.Point(374, 4);
            this.panelKpiProducts.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiProducts.Name = "panelKpiProducts";
            this.panelKpiProducts.Size = new System.Drawing.Size(368, 70);
            this.panelKpiProducts.TabIndex = 1;

            this.pnlKpi2Accent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlKpi2Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi2Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi2Accent.Name = "pnlKpi2Accent";
            this.pnlKpi2Accent.Size = new System.Drawing.Size(366, 3);
            this.pnlKpi2Accent.TabIndex = 0;

            this.lblKpiIconProducts.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconProducts.Location = new System.Drawing.Point(8, 12);
            this.lblKpiIconProducts.Name = "lblKpiIconProducts";
            this.lblKpiIconProducts.Size = new System.Drawing.Size(34, 30);
            this.lblKpiIconProducts.Text = "📦";
            this.lblKpiIconProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleProducts.AutoSize = true;
            this.lblKpiTitleProducts.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleProducts.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleProducts.Location = new System.Drawing.Point(44, 9);
            this.lblKpiTitleProducts.Name = "lblKpiTitleProducts";
            this.lblKpiTitleProducts.Size = new System.Drawing.Size(142, 17);
            this.lblKpiTitleProducts.Text = "SẢN PHẨM PHÂN LOẠI";

            this.lblKpiTotalProducts.AutoSize = true;
            this.lblKpiTotalProducts.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotalProducts.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblKpiTotalProducts.Location = new System.Drawing.Point(44, 24);
            this.lblKpiTotalProducts.Name = "lblKpiTotalProducts";
            this.lblKpiTotalProducts.Size = new System.Drawing.Size(58, 30);
            this.lblKpiTotalProducts.Text = "0 SP";

            this.lblKpiSubProducts.AutoSize = true;
            this.lblKpiSubProducts.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubProducts.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubProducts.Location = new System.Drawing.Point(44, 50);
            this.lblKpiSubProducts.Name = "lblKpiSubProducts";
            this.lblKpiSubProducts.Size = new System.Drawing.Size(126, 17);
            this.lblKpiSubProducts.Text = "Đang được liên kết";

            // Card 3: Trạng Thái Hệ Thống
            this.panelKpiStatus.BackColor = System.Drawing.Color.White;
            this.panelKpiStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiStatus.Controls.Add(this.lblKpiSubStatus);
            this.panelKpiStatus.Controls.Add(this.lblKpiStatus);
            this.panelKpiStatus.Controls.Add(this.lblKpiTitleStatus);
            this.panelKpiStatus.Controls.Add(this.lblKpiIconStatus);
            this.panelKpiStatus.Controls.Add(this.pnlKpi3Accent);
            this.panelKpiStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiStatus.Location = new System.Drawing.Point(748, 4);
            this.panelKpiStatus.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelKpiStatus.Name = "panelKpiStatus";
            this.panelKpiStatus.Size = new System.Drawing.Size(374, 70);
            this.panelKpiStatus.TabIndex = 2;

            this.pnlKpi3Accent.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.pnlKpi3Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi3Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi3Accent.Name = "pnlKpi3Accent";
            this.pnlKpi3Accent.Size = new System.Drawing.Size(372, 3);
            this.pnlKpi3Accent.TabIndex = 0;

            this.lblKpiIconStatus.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconStatus.Location = new System.Drawing.Point(8, 12);
            this.lblKpiIconStatus.Name = "lblKpiIconStatus";
            this.lblKpiIconStatus.Size = new System.Drawing.Size(34, 30);
            this.lblKpiIconStatus.Text = "⚡";
            this.lblKpiIconStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleStatus.AutoSize = true;
            this.lblKpiTitleStatus.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleStatus.Location = new System.Drawing.Point(44, 9);
            this.lblKpiTitleStatus.Name = "lblKpiTitleStatus";
            this.lblKpiTitleStatus.Size = new System.Drawing.Size(135, 17);
            this.lblKpiTitleStatus.Text = "TRẠNG THÁI HỆ THỐNG";

            this.lblKpiStatus.AutoSize = true;
            this.lblKpiStatus.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiStatus.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.lblKpiStatus.Location = new System.Drawing.Point(44, 24);
            this.lblKpiStatus.Name = "lblKpiStatus";
            this.lblKpiStatus.Size = new System.Drawing.Size(155, 30);
            this.lblKpiStatus.Text = "100% Sẵn sàng";

            this.lblKpiSubStatus.AutoSize = true;
            this.lblKpiSubStatus.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubStatus.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubStatus.Location = new System.Drawing.Point(44, 50);
            this.lblKpiSubStatus.Name = "lblKpiSubStatus";
            this.lblKpiSubStatus.Size = new System.Drawing.Size(150, 17);
            this.lblKpiSubStatus.Text = "Đồng bộ thời gian thực";

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
            this.scMain.Panel2MinSize = 340;
            this.scMain.Size = new System.Drawing.Size(1122, 582);
            this.scMain.SplitterDistance = 760;
            this.scMain.SplitterWidth = 8;
            this.scMain.TabIndex = 2;

            // =============================================================
            // CỘT TRÁI: BỘ LỌC, DATAGRIDVIEW & THANH TRẠNG THÁI
            // =============================================================
            this.pnlTableWrapper.BackColor = System.Drawing.Color.White;
            this.pnlTableWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTableWrapper.Controls.Add(this.dgvCategories);
            this.pnlTableWrapper.Controls.Add(this.pnlTableFooter);
            this.pnlTableWrapper.Controls.Add(this.pnlTopFilter);
            this.pnlTableWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableWrapper.Location = new System.Drawing.Point(0, 0);
            this.pnlTableWrapper.Name = "pnlTableWrapper";
            this.pnlTableWrapper.Size = new System.Drawing.Size(760, 582);
            this.pnlTableWrapper.TabIndex = 0;

            // pnlTopFilter (Thanh tìm kiếm & nút chức năng)
            this.pnlTopFilter.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlTopFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopFilter.Controls.Add(this.btnExportExcel);
            this.pnlTopFilter.Controls.Add(this.btnLoad);
            this.pnlTopFilter.Controls.Add(this.btnSearch);
            this.pnlTopFilter.Controls.Add(this.txtKeyword);
            this.pnlTopFilter.Controls.Add(this.lblSearchTitle);
            this.pnlTopFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlTopFilter.Name = "pnlTopFilter";
            this.pnlTopFilter.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlTopFilter.Size = new System.Drawing.Size(758, 52);
            this.pnlTopFilter.TabIndex = 0;

            // lblSearchTitle
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblSearchTitle.Location = new System.Drawing.Point(10, 15);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(89, 20);
            this.lblSearchTitle.Text = "🔍 Tìm kiếm:";

            // txtKeyword
            this.txtKeyword.BackColor = System.Drawing.Color.White;
            this.txtKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKeyword.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtKeyword.Location = new System.Drawing.Point(105, 11);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.PlaceholderText = "Nhập tên nhóm hàng cần tìm...";
            this.txtKeyword.Size = new System.Drawing.Size(260, 29);
            this.txtKeyword.TabIndex = 0;

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(375, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 31);
            this.btnSearch.TabIndex = 1;
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
            this.btnLoad.Location = new System.Drawing.Point(463, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(82, 31);
            this.btnLoad.TabIndex = 2;
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
            this.btnExportExcel.Location = new System.Drawing.Point(645, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(102, 31);
            this.btnExportExcel.TabIndex = 3;
            this.btnExportExcel.Text = "📥 Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // dgvCategories (Bảng danh mục nhóm hàng)
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToResizeRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.dgvCategories.BackgroundColor = System.Drawing.Color.White;
            this.dgvCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCategories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCategories.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(16, 42, 33); // Dark Green Header
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(16, 42, 33);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategories.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCategories.ColumnHeadersHeight = 38;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(220, 252, 231); // Green 100
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(20, 83, 45);   // Dark Green
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCategories.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.EnableHeadersVisualStyles = false;
            this.dgvCategories.GridColor = System.Drawing.Color.FromArgb(229, 234, 231);
            this.dgvCategories.Location = new System.Drawing.Point(0, 52);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.RowTemplate.Height = 36;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(758, 490);
            this.dgvCategories.TabIndex = 1;
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);

            // pnlTableFooter (Thanh chân bảng hiển thị tổng số và hướng dẫn)
            this.pnlTableFooter.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlTableFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTableFooter.Controls.Add(this.lblSelectionHint);
            this.pnlTableFooter.Controls.Add(this.lblGridCount);
            this.pnlTableFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTableFooter.Location = new System.Drawing.Point(0, 542);
            this.pnlTableFooter.Name = "pnlTableFooter";
            this.pnlTableFooter.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.pnlTableFooter.Size = new System.Drawing.Size(758, 38);
            this.pnlTableFooter.TabIndex = 2;

            // lblGridCount
            this.lblGridCount.AutoSize = true;
            this.lblGridCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblGridCount.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblGridCount.Location = new System.Drawing.Point(8, 8);
            this.lblGridCount.Name = "lblGridCount";
            this.lblGridCount.Size = new System.Drawing.Size(165, 20);
            this.lblGridCount.TabIndex = 0;
            this.lblGridCount.Text = "Tổng số: 0 nhóm hàng";

            // lblSelectionHint
            this.lblSelectionHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectionHint.AutoSize = true;
            this.lblSelectionHint.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSelectionHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSelectionHint.Location = new System.Drawing.Point(420, 8);
            this.lblSelectionHint.Name = "lblSelectionHint";
            this.lblSelectionHint.Size = new System.Drawing.Size(326, 20);
            this.lblSelectionHint.TabIndex = 1;
            this.lblSelectionHint.Text = "💡 Nhấp vào dòng bất kỳ để xem và sửa thông tin";

            // =============================================================
            // CỘT PHẢI: FORM CHI TIẾT NHÓM HÀNG & CRUD
            // =============================================================
            this.pnlRightCard.BackColor = System.Drawing.Color.White;
            this.pnlRightCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightCard.Controls.Add(this.pnlCardBody);
            this.pnlRightCard.Controls.Add(this.lblCardHeader);
            this.pnlRightCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightCard.Location = new System.Drawing.Point(0, 0);
            this.pnlRightCard.Name = "pnlRightCard";
            this.pnlRightCard.Size = new System.Drawing.Size(354, 582);
            this.pnlRightCard.TabIndex = 0;

            // lblCardHeader
            this.lblCardHeader.BackColor = System.Drawing.Color.FromArgb(16, 42, 33);
            this.lblCardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCardHeader.ForeColor = System.Drawing.Color.White;
            this.lblCardHeader.Location = new System.Drawing.Point(0, 0);
            this.lblCardHeader.Name = "lblCardHeader";
            this.lblCardHeader.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblCardHeader.Size = new System.Drawing.Size(352, 40);
            this.lblCardHeader.Text = "📁 THÔNG TIN NHÓM HÀNG";
            this.lblCardHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlCardBody
            this.pnlCardBody.AutoScroll = true;
            this.pnlCardBody.BackColor = System.Drawing.Color.White;
            this.pnlCardBody.Controls.Add(this.lblNotification);
            this.pnlCardBody.Controls.Add(this.btnClear);
            this.pnlCardBody.Controls.Add(this.btnDelete);
            this.pnlCardBody.Controls.Add(this.btnUpdate);
            this.pnlCardBody.Controls.Add(this.btnAdd);
            this.pnlCardBody.Controls.Add(this.txtDescription);
            this.pnlCardBody.Controls.Add(this.lblDescription);
            this.pnlCardBody.Controls.Add(this.txtCategoryName);
            this.pnlCardBody.Controls.Add(this.lblCategoryName);
            this.pnlCardBody.Controls.Add(this.txtId);
            this.pnlCardBody.Controls.Add(this.lblId);
            this.pnlCardBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardBody.Location = new System.Drawing.Point(0, 40);
            this.pnlCardBody.Name = "pnlCardBody";
            this.pnlCardBody.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardBody.Size = new System.Drawing.Size(352, 540);
            this.pnlCardBody.TabIndex = 1;

            // lblId
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblId.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblId.Location = new System.Drawing.Point(14, 8);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(142, 20);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "Mã nhóm hàng ID:";

            // txtId
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtId.Location = new System.Drawing.Point(14, 28);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(322, 29);
            this.txtId.TabIndex = 1;

            // lblCategoryName
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoryName.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCategoryName.Location = new System.Drawing.Point(14, 66);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(121, 20);
            this.lblCategoryName.TabIndex = 2;
            this.lblCategoryName.Text = "Tên nhóm hàng:";

            // txtCategoryName
            this.txtCategoryName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategoryName.BackColor = System.Drawing.Color.White;
            this.txtCategoryName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategoryName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCategoryName.Location = new System.Drawing.Point(14, 88);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.PlaceholderText = "Nhập tên nhóm hàng...";
            this.txtCategoryName.Size = new System.Drawing.Size(322, 29);
            this.txtCategoryName.TabIndex = 3;

            // lblDescription
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDescription.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDescription.Location = new System.Drawing.Point(14, 126);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(124, 20);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Mô tả / Ghi chú:";

            // txtDescription
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDescription.Location = new System.Drawing.Point(14, 148);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.PlaceholderText = "Mô tả chi tiết nhóm hàng hóa...";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(322, 130);
            this.txtDescription.TabIndex = 5;

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(22, 163, 74); // Primary Green
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(14, 295);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(155, 36);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "➕ Thêm mới";
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
            this.btnUpdate.Location = new System.Drawing.Point(181, 295);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(155, 36);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "💾 Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68); // Danger Red
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(14, 339);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(322, 34);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "🗑️ Xóa nhóm hàng";
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
            this.btnClear.Location = new System.Drawing.Point(14, 381);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(322, 34);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "🔄 Làm mới biểu mẫu";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnLoad_Click);

            // lblNotification
            this.lblNotification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotification.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNotification.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblNotification.Location = new System.Drawing.Point(14, 425);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(322, 28);
            this.lblNotification.TabIndex = 10;
            this.lblNotification.Text = "● Hệ thống sẵn sàng.";
            this.lblNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // Finalize FormCategoryManagement
            // 
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlHeaderBar.ResumeLayout(false);
            this.pnlHeaderBar.PerformLayout();
            this.tlpKPI.ResumeLayout(false);

            this.panelKpiCategories.ResumeLayout(false);
            this.panelKpiCategories.PerformLayout();
            this.panelKpiProducts.ResumeLayout(false);
            this.panelKpiProducts.PerformLayout();
            this.panelKpiStatus.ResumeLayout(false);
            this.panelKpiStatus.PerformLayout();

            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);

            this.pnlTableWrapper.ResumeLayout(false);
            this.pnlTopFilter.ResumeLayout(false);
            this.pnlTopFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.pnlTableFooter.ResumeLayout(false);
            this.pnlTableFooter.PerformLayout();

            this.pnlRightCard.ResumeLayout(false);
            this.pnlCardBody.ResumeLayout(false);
            this.pnlCardBody.PerformLayout();

            this.ResumeLayout(false);
        }

        #endregion
    }
}
