namespace MiniSupermarket.WinForms
{
    partial class FormQuickReport
    {
        private System.ComponentModel.IContainer components = null;

        // Container chính
        private System.Windows.Forms.Panel pnlMainContainer;

        // Header & Bộ lọc
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblHeaderSubtitle;
        private System.Windows.Forms.Label lblDateLabel;
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Button btnToday;

        // 3 Thẻ thống kê KPI Pro Max
        private System.Windows.Forms.Panel panelCard1;
        private System.Windows.Forms.Label lblIconOrders;
        private System.Windows.Forms.Label lblTitleOrders;
        private System.Windows.Forms.Label lblTotalOrders;
        private System.Windows.Forms.Label lblOrdersSubtitle;

        private System.Windows.Forms.Panel panelCard2;
        private System.Windows.Forms.Label lblIconRevenue;
        private System.Windows.Forms.Label lblTitleRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblRevenueSubtitle;

        private System.Windows.Forms.Panel panelCard3;
        private System.Windows.Forms.Label lblIconBestSeller;
        private System.Windows.Forms.Label lblTitleBestSeller;
        private System.Windows.Forms.Label lblBestSeller;
        private System.Windows.Forms.Label lblBestSellerSubtitle;

        // Bảng chi tiết hóa đơn trong ngày
        private System.Windows.Forms.Panel pnlOrdersSection;
        private System.Windows.Forms.Label lblOrdersSectionTitle;
        private System.Windows.Forms.DataGridView dgvDayOrders;

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

            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.lblHeaderTitle = new System.Windows.Forms.Label();
            this.lblHeaderSubtitle = new System.Windows.Forms.Label();
            this.lblDateLabel = new System.Windows.Forms.Label();
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();

            this.panelCard1 = new System.Windows.Forms.Panel();
            this.lblIconOrders = new System.Windows.Forms.Label();
            this.lblTitleOrders = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();
            this.lblOrdersSubtitle = new System.Windows.Forms.Label();

            this.panelCard2 = new System.Windows.Forms.Panel();
            this.lblIconRevenue = new System.Windows.Forms.Label();
            this.lblTitleRevenue = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();
            this.lblRevenueSubtitle = new System.Windows.Forms.Label();

            this.panelCard3 = new System.Windows.Forms.Panel();
            this.lblIconBestSeller = new System.Windows.Forms.Label();
            this.lblTitleBestSeller = new System.Windows.Forms.Label();
            this.lblBestSeller = new System.Windows.Forms.Label();
            this.lblBestSellerSubtitle = new System.Windows.Forms.Label();

            this.pnlOrdersSection = new System.Windows.Forms.Panel();
            this.lblOrdersSectionTitle = new System.Windows.Forms.Label();
            this.dgvDayOrders = new System.Windows.Forms.DataGridView();

            this.pnlMainContainer.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.panelCard1.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.panelCard3.SuspendLayout();
            this.pnlOrdersSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDayOrders)).BeginInit();
            this.SuspendLayout();

            // 
            // FormQuickReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(248, 250, 252); // Slate 50
            this.ClientSize = new System.Drawing.Size(1074, 693);
            this.Controls.Add(this.pnlMainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuickReport";
            this.Text = "BÁO CÁO DOANH THU & HIỆU SUẤT";
            this.Load += new System.EventHandler(this.FormQuickReport_Load);

            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlMainContainer.Controls.Add(this.pnlOrdersSection);
            this.pnlMainContainer.Controls.Add(this.panelCard3);
            this.pnlMainContainer.Controls.Add(this.panelCard2);
            this.pnlMainContainer.Controls.Add(this.panelCard1);
            this.pnlMainContainer.Controls.Add(this.pnlTopBar);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMainContainer.Size = new System.Drawing.Size(1074, 693);
            this.pnlMainContainer.TabIndex = 0;

            // 
            // pnlTopBar (Thanh điều khiển phía trên)
            // 
            this.pnlTopBar.BackColor = System.Drawing.Color.White;
            this.pnlTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTopBar.Controls.Add(this.btnToday);
            this.pnlTopBar.Controls.Add(this.btnRunReport);
            this.pnlTopBar.Controls.Add(this.dtpReportDate);
            this.pnlTopBar.Controls.Add(this.lblDateLabel);
            this.pnlTopBar.Controls.Add(this.lblHeaderSubtitle);
            this.pnlTopBar.Controls.Add(this.lblHeaderTitle);
            this.pnlTopBar.Location = new System.Drawing.Point(20, 16);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Size = new System.Drawing.Size(1034, 76);
            this.pnlTopBar.TabIndex = 0;

            // lblHeaderTitle
            this.lblHeaderTitle.AutoSize = true;
            this.lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42); // Slate 900
            this.lblHeaderTitle.Location = new System.Drawing.Point(18, 12);
            this.lblHeaderTitle.Name = "lblHeaderTitle";
            this.lblHeaderTitle.Size = new System.Drawing.Size(370, 31);
            this.lblHeaderTitle.Text = "📊 BÁO CÁO DOANH THU NGÀY";

            // lblHeaderSubtitle
            this.lblHeaderSubtitle.AutoSize = true;
            this.lblHeaderSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblHeaderSubtitle.Location = new System.Drawing.Point(20, 44);
            this.lblHeaderSubtitle.Name = "lblHeaderSubtitle";
            this.lblHeaderSubtitle.Size = new System.Drawing.Size(380, 20);
            this.lblHeaderSubtitle.Text = "Số liệu thực tế theo hóa đơn thanh toán từ database";

            // lblDateLabel
            this.lblDateLabel.AutoSize = true;
            this.lblDateLabel.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDateLabel.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDateLabel.Location = new System.Drawing.Point(475, 26);
            this.lblDateLabel.Name = "lblDateLabel";
            this.lblDateLabel.Size = new System.Drawing.Size(95, 21);
            this.lblDateLabel.Text = "📅 Xem ngày:";

            // dtpReportDate (Ô chọn ngày căn chuẩn giữa dòng Y=20, cao 34)
            this.dtpReportDate.CalendarFont = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpReportDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReportDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportDate.Location = new System.Drawing.Point(575, 20);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(170, 32);
            this.dtpReportDate.TabIndex = 0;

            // btnRunReport (Nút Xem báo cáo đặt ngay ngang hàng, Y=19, cao 36)
            this.btnRunReport.BackColor = System.Drawing.Color.FromArgb(37, 99, 235); // Blue 600
            this.btnRunReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRunReport.FlatAppearance.BorderSize = 0;
            this.btnRunReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRunReport.ForeColor = System.Drawing.Color.White;
            this.btnRunReport.Location = new System.Drawing.Point(755, 18);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(155, 36);
            this.btnRunReport.TabIndex = 1;
            this.btnRunReport.Text = "⚡ Xem báo cáo";
            this.btnRunReport.UseVisualStyleBackColor = false;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);

            // btnToday (Nút chọn nhanh Hôm nay)
            this.btnToday.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToday.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnToday.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToday.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnToday.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.btnToday.Location = new System.Drawing.Point(918, 18);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(100, 36);
            this.btnToday.TabIndex = 2;
            this.btnToday.Text = "Hôm nay";
            this.btnToday.UseVisualStyleBackColor = false;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);

            // 
            // panelCard1 (Thẻ Tổng số hóa đơn - Gradient / Indigo sang trọng)
            // 
            this.panelCard1.BackColor = System.Drawing.Color.White;
            this.panelCard1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard1.Controls.Add(this.lblOrdersSubtitle);
            this.panelCard1.Controls.Add(this.lblTotalOrders);
            this.panelCard1.Controls.Add(this.lblTitleOrders);
            this.panelCard1.Controls.Add(this.lblIconOrders);
            this.panelCard1.Location = new System.Drawing.Point(20, 104);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(330, 150);
            this.panelCard1.TabIndex = 1;

            this.lblIconOrders.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lblIconOrders.Location = new System.Drawing.Point(16, 14);
            this.lblIconOrders.Name = "lblIconOrders";
            this.lblIconOrders.Size = new System.Drawing.Size(46, 44);
            this.lblIconOrders.Text = "🧾";

            this.lblTitleOrders.AutoSize = true;
            this.lblTitleOrders.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitleOrders.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleOrders.Location = new System.Drawing.Point(68, 22);
            this.lblTitleOrders.Name = "lblTitleOrders";
            this.lblTitleOrders.Size = new System.Drawing.Size(175, 23);
            this.lblTitleOrders.Text = "TỔNG SỐ HÓA ĐƠN";

            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235); // Blue 600
            this.lblTotalOrders.Location = new System.Drawing.Point(16, 62);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(296, 52);
            this.lblTotalOrders.Text = "0";

            this.lblOrdersSubtitle.AutoSize = true;
            this.lblOrdersSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblOrdersSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblOrdersSubtitle.Location = new System.Drawing.Point(18, 118);
            this.lblOrdersSubtitle.Name = "lblOrdersSubtitle";
            this.lblOrdersSubtitle.Size = new System.Drawing.Size(200, 20);
            this.lblOrdersSubtitle.Text = "Giao dịch thanh toán tại quầy";

            // 
            // panelCard2 (Thẻ Tổng doanh thu - Emerald xanh tài lộc)
            // 
            this.panelCard2.BackColor = System.Drawing.Color.White;
            this.panelCard2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard2.Controls.Add(this.lblRevenueSubtitle);
            this.panelCard2.Controls.Add(this.lblTotalRevenue);
            this.panelCard2.Controls.Add(this.lblTitleRevenue);
            this.panelCard2.Controls.Add(this.lblIconRevenue);
            this.panelCard2.Location = new System.Drawing.Point(372, 104);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Size = new System.Drawing.Size(330, 150);
            this.panelCard2.TabIndex = 2;

            this.lblIconRevenue.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lblIconRevenue.Location = new System.Drawing.Point(16, 14);
            this.lblIconRevenue.Name = "lblIconRevenue";
            this.lblIconRevenue.Size = new System.Drawing.Size(46, 44);
            this.lblIconRevenue.Text = "💰";

            this.lblTitleRevenue.AutoSize = true;
            this.lblTitleRevenue.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitleRevenue.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleRevenue.Location = new System.Drawing.Point(68, 22);
            this.lblTitleRevenue.Name = "lblTitleRevenue";
            this.lblTitleRevenue.Size = new System.Drawing.Size(165, 23);
            this.lblTitleRevenue.Text = "TỔNG DOANH THU";

            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 21F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129); // Emerald 500
            this.lblTotalRevenue.Location = new System.Drawing.Point(16, 62);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(296, 52);
            this.lblTotalRevenue.Text = "0 VNĐ";

            this.lblRevenueSubtitle.AutoSize = true;
            this.lblRevenueSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblRevenueSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblRevenueSubtitle.Location = new System.Drawing.Point(18, 118);
            this.lblRevenueSubtitle.Name = "lblRevenueSubtitle";
            this.lblRevenueSubtitle.Size = new System.Drawing.Size(190, 20);
            this.lblRevenueSubtitle.Text = "Doanh thu thực tế sau thuế";

            // 
            // panelCard3 (Thẻ Mặt hàng bán chạy nhất - Amber cam ấm áp)
            // 
            this.panelCard3.BackColor = System.Drawing.Color.White;
            this.panelCard3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCard3.Controls.Add(this.lblBestSellerSubtitle);
            this.panelCard3.Controls.Add(this.lblBestSeller);
            this.panelCard3.Controls.Add(this.lblTitleBestSeller);
            this.panelCard3.Controls.Add(this.lblIconBestSeller);
            this.panelCard3.Location = new System.Drawing.Point(724, 104);
            this.panelCard3.Name = "panelCard3";
            this.panelCard3.Size = new System.Drawing.Size(330, 150);
            this.panelCard3.TabIndex = 3;

            this.lblIconBestSeller.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lblIconBestSeller.Location = new System.Drawing.Point(16, 14);
            this.lblIconBestSeller.Name = "lblIconBestSeller";
            this.lblIconBestSeller.Size = new System.Drawing.Size(46, 44);
            this.lblIconBestSeller.Text = "🔥";

            this.lblTitleBestSeller.AutoSize = true;
            this.lblTitleBestSeller.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitleBestSeller.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblTitleBestSeller.Location = new System.Drawing.Point(68, 22);
            this.lblTitleBestSeller.Name = "lblTitleBestSeller";
            this.lblTitleBestSeller.Size = new System.Drawing.Size(185, 23);
            this.lblTitleBestSeller.Text = "MẶT HÀNG BÁN CHẠY";

            this.lblBestSeller.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblBestSeller.ForeColor = System.Drawing.Color.FromArgb(234, 88, 12); // Orange 600
            this.lblBestSeller.Location = new System.Drawing.Point(16, 62);
            this.lblBestSeller.Name = "lblBestSeller";
            this.lblBestSeller.Size = new System.Drawing.Size(296, 52);
            this.lblBestSeller.Text = "Chưa có dữ liệu";

            this.lblBestSellerSubtitle.AutoSize = true;
            this.lblBestSellerSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBestSellerSubtitle.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblBestSellerSubtitle.Location = new System.Drawing.Point(18, 118);
            this.lblBestSellerSubtitle.Name = "lblBestSellerSubtitle";
            this.lblBestSellerSubtitle.Size = new System.Drawing.Size(210, 20);
            this.lblBestSellerSubtitle.Text = "Sản phẩm đạt số lượng cao nhất";

            // 
            // pnlOrdersSection (Bảng chi tiết giao dịch trong ngày)
            // 
            this.pnlOrdersSection.BackColor = System.Drawing.Color.White;
            this.pnlOrdersSection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOrdersSection.Controls.Add(this.dgvDayOrders);
            this.pnlOrdersSection.Controls.Add(this.lblOrdersSectionTitle);
            this.pnlOrdersSection.Location = new System.Drawing.Point(20, 268);
            this.pnlOrdersSection.Name = "pnlOrdersSection";
            this.pnlOrdersSection.Padding = new System.Windows.Forms.Padding(16);
            this.pnlOrdersSection.Size = new System.Drawing.Size(1034, 405);
            this.pnlOrdersSection.TabIndex = 4;

            // lblOrdersSectionTitle
            this.lblOrdersSectionTitle.AutoSize = true;
            this.lblOrdersSectionTitle.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.lblOrdersSectionTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblOrdersSectionTitle.Location = new System.Drawing.Point(16, 12);
            this.lblOrdersSectionTitle.Name = "lblOrdersSectionTitle";
            this.lblOrdersSectionTitle.Size = new System.Drawing.Size(370, 28);
            this.lblOrdersSectionTitle.Text = "📋 DANH SÁCH HÓA ĐƠN TRONG NGÀY";

            // dgvDayOrders
            this.dgvDayOrders.AllowUserToAddRows = false;
            this.dgvDayOrders.AllowUserToDeleteRows = false;
            this.dgvDayOrders.AllowUserToResizeRows = false;
            this.dgvDayOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDayOrders.BackgroundColor = System.Drawing.Color.White;
            this.dgvDayOrders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDayOrders.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDayOrders.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvHeaderStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvHeaderStyle.BackColor = System.Drawing.Color.FromArgb(15, 23, 42); // Slate 900
            dgvHeaderStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvHeaderStyle.ForeColor = System.Drawing.Color.White;
            dgvHeaderStyle.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dgvHeaderStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDayOrders.ColumnHeadersDefaultCellStyle = dgvHeaderStyle;
            this.dgvDayOrders.ColumnHeadersHeight = 42;
            this.dgvDayOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dgvRowStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvRowStyle.BackColor = System.Drawing.Color.White;
            dgvRowStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            dgvRowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgvRowStyle.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            dgvRowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(224, 231, 255);
            dgvRowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgvRowStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDayOrders.DefaultCellStyle = dgvRowStyle;
            this.dgvDayOrders.EnableHeadersVisualStyles = false;
            this.dgvDayOrders.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvDayOrders.Location = new System.Drawing.Point(16, 48);
            this.dgvDayOrders.MultiSelect = false;
            this.dgvDayOrders.Name = "dgvDayOrders";
            this.dgvDayOrders.ReadOnly = true;
            this.dgvDayOrders.RowHeadersVisible = false;
            this.dgvDayOrders.RowHeadersWidth = 51;
            this.dgvDayOrders.RowTemplate.Height = 36;
            this.dgvDayOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDayOrders.Size = new System.Drawing.Size(1000, 340);
            this.dgvDayOrders.TabIndex = 1;

            this.pnlTopBar.ResumeLayout(false);
            this.pnlTopBar.PerformLayout();
            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.panelCard3.ResumeLayout(false);
            this.panelCard3.PerformLayout();
            this.pnlOrdersSection.ResumeLayout(false);
            this.pnlOrdersSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDayOrders)).EndInit();
            this.pnlMainContainer.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion
    }
}