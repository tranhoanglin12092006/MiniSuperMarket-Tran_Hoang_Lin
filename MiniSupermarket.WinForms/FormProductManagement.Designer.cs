namespace MiniSupermarket.WinForms
{
    partial class FormProductManagement
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

        // 4 Thẻ KPI Tồn kho & Sản phẩm
        private System.Windows.Forms.TableLayoutPanel tlpKPI;
        private System.Windows.Forms.Panel panelKpiProducts;
        private System.Windows.Forms.Panel pnlKpi1Accent;
        private System.Windows.Forms.Label lblKpiIconProducts;
        private System.Windows.Forms.Label lblKpiTitleProducts;
        private System.Windows.Forms.Label lblKpiTotalProducts;
        private System.Windows.Forms.Label lblKpiSubProducts;

        private System.Windows.Forms.Panel panelKpiCategories;
        private System.Windows.Forms.Panel pnlKpi2Accent;
        private System.Windows.Forms.Label lblKpiIconCategories;
        private System.Windows.Forms.Label lblKpiTitleCategories;
        private System.Windows.Forms.Label lblKpiTotalCategories;
        private System.Windows.Forms.Label lblKpiSubCategories;

        private System.Windows.Forms.Panel panelKpiLowStock;
        private System.Windows.Forms.Panel pnlKpi3Accent;
        private System.Windows.Forms.Label lblKpiIconLowStock;
        private System.Windows.Forms.Label lblKpiTitleLowStock;
        private System.Windows.Forms.Label lblKpiLowStock;
        private System.Windows.Forms.Label lblKpiSubLowStock;

        private System.Windows.Forms.Panel panelKpiStockValue;
        private System.Windows.Forms.Panel pnlKpi4Accent;
        private System.Windows.Forms.Label lblKpiIconStockValue;
        private System.Windows.Forms.Label lblKpiTitleStockValue;
        private System.Windows.Forms.Label lblKpiTotalStockValue;
        private System.Windows.Forms.Label lblKpiSubStockValue;

        // SplitContainer chia đôi: Trái (Bảng dữ liệu + Bộ lọc), Phải (Form nhập liệu)
        private System.Windows.Forms.SplitContainer scMain;

        // Cột Trái: Bộ lọc, DataGridView & Phân trang
        private System.Windows.Forms.Panel pnlTableWrapper;
        private System.Windows.Forms.Panel pnlTopFilter;
        private System.Windows.Forms.Label lblSearchTitle;
        private System.Windows.Forms.TextBox txtSearchBarcode;
        private System.Windows.Forms.ComboBox cboFilterCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Panel pnlPaging;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Label lblPaging;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageSizeTitle;
        private System.Windows.Forms.ComboBox cboPageSize;
        private System.Windows.Forms.Label lblLowStockBadge;

        // Cột Phải: Thẻ Chi tiết Sản phẩm & Thao tác CRUD
        private System.Windows.Forms.Panel pnlRightCard;
        private System.Windows.Forms.Label lblCardHeader;
        private System.Windows.Forms.Panel pnlCardBody;
        private System.Windows.Forms.Label lblIdTitle;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblBarcodeTitle;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCategoryTitle;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblPriceTitle;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblStockTitle;
        private System.Windows.Forms.NumericUpDown nudStock;
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
            this.panelKpiProducts = new System.Windows.Forms.Panel();
            this.pnlKpi1Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconProducts = new System.Windows.Forms.Label();
            this.lblKpiTitleProducts = new System.Windows.Forms.Label();
            this.lblKpiTotalProducts = new System.Windows.Forms.Label();
            this.lblKpiSubProducts = new System.Windows.Forms.Label();

            this.panelKpiCategories = new System.Windows.Forms.Panel();
            this.pnlKpi2Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconCategories = new System.Windows.Forms.Label();
            this.lblKpiTitleCategories = new System.Windows.Forms.Label();
            this.lblKpiTotalCategories = new System.Windows.Forms.Label();
            this.lblKpiSubCategories = new System.Windows.Forms.Label();

            this.panelKpiLowStock = new System.Windows.Forms.Panel();
            this.pnlKpi3Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconLowStock = new System.Windows.Forms.Label();
            this.lblKpiTitleLowStock = new System.Windows.Forms.Label();
            this.lblKpiLowStock = new System.Windows.Forms.Label();
            this.lblKpiSubLowStock = new System.Windows.Forms.Label();

            this.panelKpiStockValue = new System.Windows.Forms.Panel();
            this.pnlKpi4Accent = new System.Windows.Forms.Panel();
            this.lblKpiIconStockValue = new System.Windows.Forms.Label();
            this.lblKpiTitleStockValue = new System.Windows.Forms.Label();
            this.lblKpiTotalStockValue = new System.Windows.Forms.Label();
            this.lblKpiSubStockValue = new System.Windows.Forms.Label();

            // SplitContainer
            this.scMain = new System.Windows.Forms.SplitContainer();

            // Cột Trái Controls
            this.pnlTableWrapper = new System.Windows.Forms.Panel();
            this.pnlTopFilter = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtSearchBarcode = new System.Windows.Forms.TextBox();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();

            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.pnlPaging = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.Button();
            this.lblPaging = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageSizeTitle = new System.Windows.Forms.Label();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.lblLowStockBadge = new System.Windows.Forms.Label();

            // Cột Phải Controls
            this.pnlRightCard = new System.Windows.Forms.Panel();
            this.lblCardHeader = new System.Windows.Forms.Label();
            this.pnlCardBody = new System.Windows.Forms.Panel();
            this.lblIdTitle = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblBarcodeTitle = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblPriceTitle = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblStockTitle = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblNotification = new System.Windows.Forms.Label();

            this.pnlMainContainer.SuspendLayout();
            this.pnlHeaderBar.SuspendLayout();
            this.tlpKPI.SuspendLayout();

            this.panelKpiProducts.SuspendLayout();
            this.panelKpiCategories.SuspendLayout();
            this.panelKpiLowStock.SuspendLayout();
            this.panelKpiStockValue.SuspendLayout();

            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();

            this.pnlTableWrapper.SuspendLayout();
            this.pnlTopFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlPaging.SuspendLayout();

            this.pnlRightCard.SuspendLayout();
            this.pnlCardBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.SuspendLayout();

            // 
            // FormProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 245); // Soft SaaS background
            this.ClientSize = new System.Drawing.Size(1200, 780);
            this.Controls.Add(this.pnlMainContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "FormProductManagement";
            this.Text = "QUẢN LÝ SẢN PHẨM & TỒN KHO";
            this.Load += new System.EventHandler(this.FormProductManagement_Load);

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
            this.pnlMainContainer.Size = new System.Drawing.Size(1200, 780);
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
            this.pnlHeaderBar.Size = new System.Drawing.Size(1172, 70);
            this.pnlHeaderBar.TabIndex = 0;

            // lblBreadcrumb
            this.lblBreadcrumb.AutoSize = true;
            this.lblBreadcrumb.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBreadcrumb.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblBreadcrumb.Location = new System.Drawing.Point(12, 6);
            this.lblBreadcrumb.Name = "lblBreadcrumb";
            this.lblBreadcrumb.Size = new System.Drawing.Size(260, 19);
            this.lblBreadcrumb.Text = "Hệ thống quản lý / Quản lý kho & Sản phẩm";

            // lblHeaderTitle
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(16, 42, 33); // Dark Green
            this.lblHeaderTitle.Location = new System.Drawing.Point(11, 25);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(380, 30);
            this.lblHeaderTitle.Text = "QUẢN LÝ DANH MỤC & TỒN KHO";
            this.lblHeaderTitle.UseMnemonic = false;

            // lblHeaderSubtitle
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(12, 48);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(385, 20);
            this.lblHeaderSubtitle.Text = "Theo dõi hàng hóa, mã vạch, giá niêm yết và mức tồn an toàn";

            // lblLiveSyncBadge
            this.lblLiveSyncBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLiveSyncBadge.BackColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.lblLiveSyncBadge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblLiveSyncBadge.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblLiveSyncBadge.Location = new System.Drawing.Point(1035, 20);
            this.lblLiveSyncBadge.Name = "lblLiveSyncBadge";
            this.lblLiveSyncBadge.Size = new System.Drawing.Size(120, 26);
            this.lblLiveSyncBadge.Text = "● Đã kết nối API";
            this.lblLiveSyncBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // =============================================================
            // 4 THẺ KPI CHỈ SỐ KHO HÀNG (TABLELAYOUTPANEL 4 CỘT 25%)
            // =============================================================
            this.tlpKPI.ColumnCount = 4;
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpKPI.Controls.Add(this.panelKpiProducts, 0, 0);
            this.tlpKPI.Controls.Add(this.panelKpiCategories, 1, 0);
            this.tlpKPI.Controls.Add(this.panelKpiLowStock, 2, 0);
            this.tlpKPI.Controls.Add(this.panelKpiStockValue, 3, 0);
            this.tlpKPI.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpKPI.Location = new System.Drawing.Point(14, 80);
            this.tlpKPI.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.tlpKPI.Name = "tlpKPI";
            this.tlpKPI.RowCount = 1;
            this.tlpKPI.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpKPI.Size = new System.Drawing.Size(1172, 78);
            this.tlpKPI.TabIndex = 1;

            // Card 1: Tổng Mặt Hàng
            this.panelKpiProducts.BackColor = System.Drawing.Color.White;
            this.panelKpiProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiProducts.Controls.Add(this.lblKpiSubProducts);
            this.panelKpiProducts.Controls.Add(this.lblKpiTotalProducts);
            this.panelKpiProducts.Controls.Add(this.lblKpiTitleProducts);
            this.panelKpiProducts.Controls.Add(this.lblKpiIconProducts);
            this.panelKpiProducts.Controls.Add(this.pnlKpi1Accent);
            this.panelKpiProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiProducts.Location = new System.Drawing.Point(0, 4);
            this.panelKpiProducts.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiProducts.Name = "panelKpiProducts";
            this.panelKpiProducts.Size = new System.Drawing.Size(287, 70);
            this.panelKpiProducts.TabIndex = 0;

            this.pnlKpi1Accent.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.pnlKpi1Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi1Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi1Accent.Name = "pnlKpi1Accent";
            this.pnlKpi1Accent.Size = new System.Drawing.Size(285, 3);
            this.pnlKpi1Accent.TabIndex = 0;

            this.lblKpiIconProducts.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconProducts.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconProducts.Name = "lblKpiIconProducts";
            this.lblKpiIconProducts.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconProducts.Text = "📦";
            this.lblKpiIconProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleProducts.AutoSize = true;
            this.lblKpiTitleProducts.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleProducts.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleProducts.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleProducts.Name = "lblKpiTitleProducts";
            this.lblKpiTitleProducts.Size = new System.Drawing.Size(125, 17);
            this.lblKpiTitleProducts.Text = "TỔNG SỐ MẶT HÀNG";

            this.lblKpiTotalProducts.AutoSize = true;
            this.lblKpiTotalProducts.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotalProducts.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblKpiTotalProducts.Location = new System.Drawing.Point(40, 24);
            this.lblKpiTotalProducts.Name = "lblKpiTotalProducts";
            this.lblKpiTotalProducts.Size = new System.Drawing.Size(58, 30);
            this.lblKpiTotalProducts.Text = "0 SP";

            this.lblKpiSubProducts.AutoSize = true;
            this.lblKpiSubProducts.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubProducts.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubProducts.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubProducts.Name = "lblKpiSubProducts";
            this.lblKpiSubProducts.Size = new System.Drawing.Size(130, 17);
            this.lblKpiSubProducts.Text = "Đang kinh doanh";

            // Card 2: Tổng Nhóm Hàng
            this.panelKpiCategories.BackColor = System.Drawing.Color.White;
            this.panelKpiCategories.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiCategories.Controls.Add(this.lblKpiSubCategories);
            this.panelKpiCategories.Controls.Add(this.lblKpiTotalCategories);
            this.panelKpiCategories.Controls.Add(this.lblKpiTitleCategories);
            this.panelKpiCategories.Controls.Add(this.lblKpiIconCategories);
            this.panelKpiCategories.Controls.Add(this.pnlKpi2Accent);
            this.panelKpiCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiCategories.Location = new System.Drawing.Point(293, 4);
            this.panelKpiCategories.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiCategories.Name = "panelKpiCategories";
            this.panelKpiCategories.Size = new System.Drawing.Size(287, 70);
            this.panelKpiCategories.TabIndex = 1;

            this.pnlKpi2Accent.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.pnlKpi2Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi2Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi2Accent.Name = "pnlKpi2Accent";
            this.pnlKpi2Accent.Size = new System.Drawing.Size(285, 3);
            this.pnlKpi2Accent.TabIndex = 0;

            this.lblKpiIconCategories.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconCategories.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconCategories.Name = "lblKpiIconCategories";
            this.lblKpiIconCategories.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconCategories.Text = "🏷️";
            this.lblKpiIconCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleCategories.AutoSize = true;
            this.lblKpiTitleCategories.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleCategories.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleCategories.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleCategories.Name = "lblKpiTitleCategories";
            this.lblKpiTitleCategories.Size = new System.Drawing.Size(126, 17);
            this.lblKpiTitleCategories.Text = "NHÓM HÀNG HÓA";

            this.lblKpiTotalCategories.AutoSize = true;
            this.lblKpiTotalCategories.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotalCategories.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblKpiTotalCategories.Location = new System.Drawing.Point(40, 24);
            this.lblKpiTotalCategories.Name = "lblKpiTotalCategories";
            this.lblKpiTotalCategories.Size = new System.Drawing.Size(83, 30);
            this.lblKpiTotalCategories.Text = "0 nhóm";

            this.lblKpiSubCategories.AutoSize = true;
            this.lblKpiSubCategories.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubCategories.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubCategories.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubCategories.Name = "lblKpiSubCategories";
            this.lblKpiSubCategories.Size = new System.Drawing.Size(115, 17);
            this.lblKpiSubCategories.Text = "Danh mục quản lý";

            // Card 3: Cảnh Báo Tồn Kho Thấp
            this.panelKpiLowStock.BackColor = System.Drawing.Color.White;
            this.panelKpiLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiLowStock.Controls.Add(this.lblKpiSubLowStock);
            this.panelKpiLowStock.Controls.Add(this.lblKpiLowStock);
            this.panelKpiLowStock.Controls.Add(this.lblKpiTitleLowStock);
            this.panelKpiLowStock.Controls.Add(this.lblKpiIconLowStock);
            this.panelKpiLowStock.Controls.Add(this.pnlKpi3Accent);
            this.panelKpiLowStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiLowStock.Location = new System.Drawing.Point(586, 4);
            this.panelKpiLowStock.Margin = new System.Windows.Forms.Padding(0, 4, 6, 4);
            this.panelKpiLowStock.Name = "panelKpiLowStock";
            this.panelKpiLowStock.Size = new System.Drawing.Size(287, 70);
            this.panelKpiLowStock.TabIndex = 2;

            this.pnlKpi3Accent.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.pnlKpi3Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi3Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi3Accent.Name = "pnlKpi3Accent";
            this.pnlKpi3Accent.Size = new System.Drawing.Size(285, 3);
            this.pnlKpi3Accent.TabIndex = 0;

            this.lblKpiIconLowStock.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconLowStock.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconLowStock.Name = "lblKpiIconLowStock";
            this.lblKpiIconLowStock.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconLowStock.Text = "⚠️";
            this.lblKpiIconLowStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleLowStock.AutoSize = true;
            this.lblKpiTitleLowStock.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleLowStock.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleLowStock.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleLowStock.Name = "lblKpiTitleLowStock";
            this.lblKpiTitleLowStock.Size = new System.Drawing.Size(126, 17);
            this.lblKpiTitleLowStock.Text = "CẢNH BÁO TỒN KHO";

            this.lblKpiLowStock.AutoSize = true;
            this.lblKpiLowStock.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiLowStock.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblKpiLowStock.Location = new System.Drawing.Point(40, 24);
            this.lblKpiLowStock.Name = "lblKpiLowStock";
            this.lblKpiLowStock.Size = new System.Drawing.Size(58, 30);
            this.lblKpiLowStock.Text = "0 SP";

            this.lblKpiSubLowStock.AutoSize = true;
            this.lblKpiSubLowStock.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubLowStock.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubLowStock.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubLowStock.Name = "lblKpiSubLowStock";
            this.lblKpiSubLowStock.Size = new System.Drawing.Size(115, 17);
            this.lblKpiSubLowStock.Text = "Tồn kho an toàn ≤ 10";

            // Card 4: Tổng Giá Trị Tồn Kho
            this.panelKpiStockValue.BackColor = System.Drawing.Color.White;
            this.panelKpiStockValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelKpiStockValue.Controls.Add(this.lblKpiSubStockValue);
            this.panelKpiStockValue.Controls.Add(this.lblKpiTotalStockValue);
            this.panelKpiStockValue.Controls.Add(this.lblKpiTitleStockValue);
            this.panelKpiStockValue.Controls.Add(this.lblKpiIconStockValue);
            this.panelKpiStockValue.Controls.Add(this.pnlKpi4Accent);
            this.panelKpiStockValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelKpiStockValue.Location = new System.Drawing.Point(879, 4);
            this.panelKpiStockValue.Margin = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.panelKpiStockValue.Name = "panelKpiStockValue";
            this.panelKpiStockValue.Size = new System.Drawing.Size(293, 70);
            this.panelKpiStockValue.TabIndex = 3;

            this.pnlKpi4Accent.BackColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.pnlKpi4Accent.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlKpi4Accent.Location = new System.Drawing.Point(0, 0);
            this.pnlKpi4Accent.Name = "pnlKpi4Accent";
            this.pnlKpi4Accent.Size = new System.Drawing.Size(291, 3);
            this.pnlKpi4Accent.TabIndex = 0;

            this.lblKpiIconStockValue.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblKpiIconStockValue.Location = new System.Drawing.Point(6, 12);
            this.lblKpiIconStockValue.Name = "lblKpiIconStockValue";
            this.lblKpiIconStockValue.Size = new System.Drawing.Size(32, 30);
            this.lblKpiIconStockValue.Text = "💰";
            this.lblKpiIconStockValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            this.lblKpiTitleStockValue.AutoSize = true;
            this.lblKpiTitleStockValue.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTitleStockValue.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiTitleStockValue.Location = new System.Drawing.Point(40, 9);
            this.lblKpiTitleStockValue.Name = "lblKpiTitleStockValue";
            this.lblKpiTitleStockValue.Size = new System.Drawing.Size(145, 17);
            this.lblKpiTitleStockValue.Text = "GIÁ TRỊ ƯỚC TÍNH KHO";

            this.lblKpiTotalStockValue.AutoSize = true;
            this.lblKpiTotalStockValue.Font = new System.Drawing.Font("Segoe UI", 12.5F, System.Drawing.FontStyle.Bold);
            this.lblKpiTotalStockValue.ForeColor = System.Drawing.Color.FromArgb(124, 58, 237);
            this.lblKpiTotalStockValue.Location = new System.Drawing.Point(40, 24);
            this.lblKpiTotalStockValue.Name = "lblKpiTotalStockValue";
            this.lblKpiTotalStockValue.Size = new System.Drawing.Size(46, 30);
            this.lblKpiTotalStockValue.Text = "0 đ";

            this.lblKpiSubStockValue.AutoSize = true;
            this.lblKpiSubStockValue.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblKpiSubStockValue.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblKpiSubStockValue.Location = new System.Drawing.Point(40, 50);
            this.lblKpiSubStockValue.Name = "lblKpiSubStockValue";
            this.lblKpiSubStockValue.Size = new System.Drawing.Size(130, 17);
            this.lblKpiSubStockValue.Text = "Tổng giá trị tồn kho";

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
            this.scMain.Size = new System.Drawing.Size(1172, 612);
            this.scMain.SplitterDistance = 800;
            this.scMain.SplitterWidth = 8;
            this.scMain.TabIndex = 2;

            // =============================================================
            // CỘT TRÁI: BỘ LỌC, DATAGRIDVIEW & PHÂN TRANG
            // =============================================================
            this.pnlTableWrapper.BackColor = System.Drawing.Color.White;
            this.pnlTableWrapper.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTableWrapper.Controls.Add(this.dgvProducts);
            this.pnlTableWrapper.Controls.Add(this.pnlPaging);
            this.pnlTableWrapper.Controls.Add(this.pnlTopFilter);
            this.pnlTableWrapper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTableWrapper.Location = new System.Drawing.Point(0, 0);
            this.pnlTableWrapper.Name = "pnlTableWrapper";
            this.pnlTableWrapper.Size = new System.Drawing.Size(800, 612);
            this.pnlTableWrapper.TabIndex = 0;

            // pnlTopFilter (Thanh tìm kiếm & lọc nhóm hàng)
            this.pnlTopFilter.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlTopFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopFilter.Controls.Add(this.btnExportExcel);
            this.pnlTopFilter.Controls.Add(this.btnLoad);
            this.pnlTopFilter.Controls.Add(this.btnSearch);
            this.pnlTopFilter.Controls.Add(this.cboFilterCategory);
            this.pnlTopFilter.Controls.Add(this.txtSearchBarcode);
            this.pnlTopFilter.Controls.Add(this.lblSearchTitle);
            this.pnlTopFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlTopFilter.Name = "pnlTopFilter";
            this.pnlTopFilter.Padding = new System.Windows.Forms.Padding(10, 8, 10, 8);
            this.pnlTopFilter.Size = new System.Drawing.Size(798, 52);
            this.pnlTopFilter.TabIndex = 0;

            // lblSearchTitle
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblSearchTitle.Location = new System.Drawing.Point(10, 15);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(78, 20);
            this.lblSearchTitle.Text = "🔍 Bộ lọc:";

            // txtSearchBarcode
            this.txtSearchBarcode.BackColor = System.Drawing.Color.White;
            this.txtSearchBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBarcode.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtSearchBarcode.Location = new System.Drawing.Point(92, 11);
            this.txtSearchBarcode.Name = "txtSearchBarcode";
            this.txtSearchBarcode.PlaceholderText = "Tên mặt hàng hoặc mã vạch barcode...";
            this.txtSearchBarcode.Size = new System.Drawing.Size(250, 29);
            this.txtSearchBarcode.TabIndex = 0;

            // cboFilterCategory
            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboFilterCategory.FormattingEnabled = true;
            this.cboFilterCategory.Location = new System.Drawing.Point(348, 11);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(180, 29);
            this.cboFilterCategory.TabIndex = 1;
            this.cboFilterCategory.SelectedIndexChanged += new System.EventHandler(this.cboFilterCategory_SelectedIndexChanged);

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(534, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(80, 31);
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
            this.btnLoad.Location = new System.Drawing.Point(620, 10);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(78, 31);
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
            this.btnExportExcel.Location = new System.Drawing.Point(704, 10);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(95, 31);
            this.btnExportExcel.TabIndex = 4;
            this.btnExportExcel.Text = "📥 Xuất Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);

            // dgvProducts (Bảng dữ liệu hàng hóa)
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AllowUserToResizeRows = false;
            this.dgvProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProducts.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvProducts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(16, 42, 33); // Dark Green Header
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(16, 42, 33);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProducts.ColumnHeadersHeight = 38;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(220, 252, 231); // Green 100
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(20, 83, 45);   // Dark Green
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProducts.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.EnableHeadersVisualStyles = false;
            this.dgvProducts.GridColor = System.Drawing.Color.FromArgb(229, 234, 231);
            this.dgvProducts.Location = new System.Drawing.Point(0, 52);
            this.dgvProducts.MultiSelect = false;
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowTemplate.Height = 36;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(798, 514);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);
            this.dgvProducts.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvProducts_CellFormatting);

            // pnlPaging (Thanh phân trang phía dưới)
            this.pnlPaging.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlPaging.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPaging.Controls.Add(this.lblLowStockBadge);
            this.pnlPaging.Controls.Add(this.cboPageSize);
            this.pnlPaging.Controls.Add(this.lblPageSizeTitle);
            this.pnlPaging.Controls.Add(this.btnNext);
            this.pnlPaging.Controls.Add(this.lblPaging);
            this.pnlPaging.Controls.Add(this.btnPrev);
            this.pnlPaging.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPaging.Location = new System.Drawing.Point(0, 566);
            this.pnlPaging.Name = "pnlPaging";
            this.pnlPaging.Padding = new System.Windows.Forms.Padding(8, 4, 8, 4);
            this.pnlPaging.Size = new System.Drawing.Size(798, 44);
            this.pnlPaging.TabIndex = 2;

            // btnPrev
            this.btnPrev.BackColor = System.Drawing.Color.White;
            this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrev.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnPrev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrev.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnPrev.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnPrev.Location = new System.Drawing.Point(8, 6);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(105, 30);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "◀ Trước";
            this.btnPrev.UseVisualStyleBackColor = false;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);

            // lblPaging
            this.lblPaging.AutoSize = true;
            this.lblPaging.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPaging.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblPaging.Location = new System.Drawing.Point(120, 11);
            this.lblPaging.Name = "lblPaging";
            this.lblPaging.Size = new System.Drawing.Size(170, 20);
            this.lblPaging.TabIndex = 1;
            this.lblPaging.Text = "Trang 1 / 1 (Tổng: 0 SP)";

            // btnNext
            this.btnNext.BackColor = System.Drawing.Color.White;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnNext.Location = new System.Drawing.Point(300, 6);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(105, 30);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Sau ▶";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);

            // lblPageSizeTitle
            this.lblPageSizeTitle.AutoSize = true;
            this.lblPageSizeTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPageSizeTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPageSizeTitle.Location = new System.Drawing.Point(420, 11);
            this.lblPageSizeTitle.Name = "lblPageSizeTitle";
            this.lblPageSizeTitle.Size = new System.Drawing.Size(65, 20);
            this.lblPageSizeTitle.Text = "Hiển thị:";

            // cboPageSize
            this.cboPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPageSize.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.cboPageSize.FormattingEnabled = true;
            this.cboPageSize.Items.AddRange(new object[] { "10 SP/trang", "20 SP/trang", "50 SP/trang" });
            this.cboPageSize.Location = new System.Drawing.Point(488, 8);
            this.cboPageSize.Name = "cboPageSize";
            this.cboPageSize.Size = new System.Drawing.Size(105, 27);
            this.cboPageSize.TabIndex = 3;
            this.cboPageSize.SelectedIndexChanged += new System.EventHandler(this.cboPageSize_SelectedIndexChanged);

            // lblLowStockBadge
            this.lblLowStockBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLowStockBadge.AutoSize = true;
            this.lblLowStockBadge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblLowStockBadge.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.lblLowStockBadge.Location = new System.Drawing.Point(600, 12);
            this.lblLowStockBadge.Name = "lblLowStockBadge";
            this.lblLowStockBadge.Size = new System.Drawing.Size(190, 19);
            this.lblLowStockBadge.Text = "⚠️ Có sản phẩm tồn kho ≤ 10";
            this.lblLowStockBadge.Visible = false;

            // =============================================================
            // CỘT PHẢI: FORM CHI TIẾT SẢN PHẨM & CRUD
            // =============================================================
            this.pnlRightCard.BackColor = System.Drawing.Color.White;
            this.pnlRightCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightCard.Controls.Add(this.pnlCardBody);
            this.pnlRightCard.Controls.Add(this.lblCardHeader);
            this.pnlRightCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightCard.Location = new System.Drawing.Point(0, 0);
            this.pnlRightCard.Name = "pnlRightCard";
            this.pnlRightCard.Size = new System.Drawing.Size(364, 612);
            this.pnlRightCard.TabIndex = 0;

            // lblCardHeader
            this.lblCardHeader.BackColor = System.Drawing.Color.FromArgb(16, 42, 33);
            this.lblCardHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCardHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCardHeader.ForeColor = System.Drawing.Color.White;
            this.lblCardHeader.Location = new System.Drawing.Point(0, 0);
            this.lblCardHeader.Name = "lblCardHeader";
            this.lblCardHeader.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblCardHeader.Size = new System.Drawing.Size(362, 40);
            this.lblCardHeader.Text = "📦 THÔNG TIN SẢN PHẨM";
            this.lblCardHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlCardBody
            this.pnlCardBody.AutoScroll = true;
            this.pnlCardBody.BackColor = System.Drawing.Color.White;
            this.pnlCardBody.Controls.Add(this.lblNotification);
            this.pnlCardBody.Controls.Add(this.btnClear);
            this.pnlCardBody.Controls.Add(this.btnDelete);
            this.pnlCardBody.Controls.Add(this.btnUpdate);
            this.pnlCardBody.Controls.Add(this.btnAdd);
            this.pnlCardBody.Controls.Add(this.nudStock);
            this.pnlCardBody.Controls.Add(this.lblStockTitle);
            this.pnlCardBody.Controls.Add(this.nudPrice);
            this.pnlCardBody.Controls.Add(this.lblPriceTitle);
            this.pnlCardBody.Controls.Add(this.cboCategory);
            this.pnlCardBody.Controls.Add(this.lblCategoryTitle);
            this.pnlCardBody.Controls.Add(this.txtProductName);
            this.pnlCardBody.Controls.Add(this.lblNameTitle);
            this.pnlCardBody.Controls.Add(this.txtBarcode);
            this.pnlCardBody.Controls.Add(this.lblBarcodeTitle);
            this.pnlCardBody.Controls.Add(this.txtId);
            this.pnlCardBody.Controls.Add(this.lblIdTitle);
            this.pnlCardBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCardBody.Location = new System.Drawing.Point(0, 40);
            this.pnlCardBody.Name = "pnlCardBody";
            this.pnlCardBody.Padding = new System.Windows.Forms.Padding(14, 10, 14, 10);
            this.pnlCardBody.Size = new System.Drawing.Size(362, 570);
            this.pnlCardBody.TabIndex = 1;

            // lblIdTitle
            this.lblIdTitle.AutoSize = true;
            this.lblIdTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblIdTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblIdTitle.Location = new System.Drawing.Point(14, 8);
            this.lblIdTitle.Name = "lblIdTitle";
            this.lblIdTitle.Size = new System.Drawing.Size(126, 20);
            this.lblIdTitle.TabIndex = 0;
            this.lblIdTitle.Text = "Mã sản phẩm ID:";

            // txtId
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.txtId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtId.Location = new System.Drawing.Point(14, 28);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(332, 29);
            this.txtId.TabIndex = 1;

            // lblBarcodeTitle
            this.lblBarcodeTitle.AutoSize = true;
            this.lblBarcodeTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblBarcodeTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblBarcodeTitle.Location = new System.Drawing.Point(14, 62);
            this.lblBarcodeTitle.Name = "lblBarcodeTitle";
            this.lblBarcodeTitle.Size = new System.Drawing.Size(130, 20);
            this.lblBarcodeTitle.Text = "Mã vạch Barcode:";

            // txtBarcode
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.BackColor = System.Drawing.Color.White;
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtBarcode.Location = new System.Drawing.Point(14, 82);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(332, 29);
            this.txtBarcode.TabIndex = 2;

            // lblNameTitle
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblNameTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblNameTitle.Location = new System.Drawing.Point(14, 116);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(110, 20);
            this.lblNameTitle.TabIndex = 3;
            this.lblNameTitle.Text = "Tên sản phẩm:";

            // txtProductName
            this.txtProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProductName.BackColor = System.Drawing.Color.White;
            this.txtProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtProductName.Location = new System.Drawing.Point(14, 136);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(332, 29);
            this.txtProductName.TabIndex = 4;

            // lblCategoryTitle
            this.lblCategoryTitle.AutoSize = true;
            this.lblCategoryTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCategoryTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCategoryTitle.Location = new System.Drawing.Point(14, 170);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(121, 20);
            this.lblCategoryTitle.TabIndex = 5;
            this.lblCategoryTitle.Text = "Nhóm hàng hóa:";

            // cboCategory
            this.cboCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(14, 190);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(332, 29);
            this.cboCategory.TabIndex = 6;

            // lblPriceTitle
            this.lblPriceTitle.AutoSize = true;
            this.lblPriceTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPriceTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPriceTitle.Location = new System.Drawing.Point(14, 226);
            this.lblPriceTitle.Name = "lblPriceTitle";
            this.lblPriceTitle.Size = new System.Drawing.Size(94, 20);
            this.lblPriceTitle.TabIndex = 7;
            this.lblPriceTitle.Text = "Đơn giá bán:";

            // nudPrice
            this.nudPrice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudPrice.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudPrice.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.nudPrice.Location = new System.Drawing.Point(14, 246);
            this.nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(332, 29);
            this.nudPrice.TabIndex = 8;
            this.nudPrice.ThousandsSeparator = true;

            // lblStockTitle
            this.lblStockTitle.AutoSize = true;
            this.lblStockTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblStockTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblStockTitle.Location = new System.Drawing.Point(14, 280);
            this.lblStockTitle.Name = "lblStockTitle";
            this.lblStockTitle.Size = new System.Drawing.Size(100, 20);
            this.lblStockTitle.TabIndex = 9;
            this.lblStockTitle.Text = "Số lượng tồn:";

            // nudStock
            this.nudStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudStock.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.nudStock.Location = new System.Drawing.Point(14, 300);
            this.nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(332, 29);
            this.nudStock.TabIndex = 10;

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(22, 163, 74); // Primary Green
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(14, 344);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(160, 36);
            this.btnAdd.TabIndex = 11;
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
            this.btnUpdate.Location = new System.Drawing.Point(186, 344);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(160, 36);
            this.btnUpdate.TabIndex = 12;
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
            this.btnDelete.Location = new System.Drawing.Point(14, 386);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(332, 34);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "🗑️ Xóa sản phẩm";
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
            this.btnClear.Size = new System.Drawing.Size(332, 34);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "🔄 Làm mới biểu mẫu";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // lblNotification
            this.lblNotification.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNotification.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblNotification.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblNotification.Location = new System.Drawing.Point(14, 468);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(332, 28);
            this.lblNotification.TabIndex = 15;
            this.lblNotification.Text = "● Hệ thống sẵn sàng.";
            this.lblNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // Finalize FormProductManagement
            // 
            this.pnlMainContainer.ResumeLayout(false);
            this.pnlHeaderBar.ResumeLayout(false);
            this.pnlHeaderBar.PerformLayout();
            this.tlpKPI.ResumeLayout(false);

            this.panelKpiProducts.ResumeLayout(false);
            this.panelKpiProducts.PerformLayout();
            this.panelKpiCategories.ResumeLayout(false);
            this.panelKpiCategories.PerformLayout();
            this.panelKpiLowStock.ResumeLayout(false);
            this.panelKpiLowStock.PerformLayout();
            this.panelKpiStockValue.ResumeLayout(false);
            this.panelKpiStockValue.PerformLayout();

            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);

            this.pnlTableWrapper.ResumeLayout(false);
            this.pnlTopFilter.ResumeLayout(false);
            this.pnlTopFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlPaging.ResumeLayout(false);
            this.pnlPaging.PerformLayout();

            this.pnlRightCard.ResumeLayout(false);
            this.pnlCardBody.ResumeLayout(false);
            this.pnlCardBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();

            this.ResumeLayout(false);
        }

        #endregion
    }
}
