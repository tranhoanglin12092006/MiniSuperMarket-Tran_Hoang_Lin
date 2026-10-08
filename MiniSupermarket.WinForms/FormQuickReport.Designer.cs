namespace MiniSupermarket.WinForms
{
    partial class FormQuickReport
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các điều khiển
        private System.Windows.Forms.DateTimePicker dtpReportDate;
        private System.Windows.Forms.Button btnRunReport;
        private System.Windows.Forms.Label lblTitleReport;

        // 3 Thẻ Panel tóm tắt
        private System.Windows.Forms.Panel panelCard1;
        private System.Windows.Forms.Label lblTitleOrders;
        private System.Windows.Forms.Label lblTotalOrders;

        private System.Windows.Forms.Panel panelCard2;
        private System.Windows.Forms.Label lblTitleRevenue;
        private System.Windows.Forms.Label lblTotalRevenue;

        private System.Windows.Forms.Panel panelCard3;
        private System.Windows.Forms.Label lblTitleBestSeller;
        private System.Windows.Forms.Label lblBestSeller;

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
            this.dtpReportDate = new System.Windows.Forms.DateTimePicker();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.lblTitleReport = new System.Windows.Forms.Label();
            
            this.panelCard1 = new System.Windows.Forms.Panel();
            this.lblTitleOrders = new System.Windows.Forms.Label();
            this.lblTotalOrders = new System.Windows.Forms.Label();

            this.panelCard2 = new System.Windows.Forms.Panel();
            this.lblTitleRevenue = new System.Windows.Forms.Label();
            this.lblTotalRevenue = new System.Windows.Forms.Label();

            this.panelCard3 = new System.Windows.Forms.Panel();
            this.lblTitleBestSeller = new System.Windows.Forms.Label();
            this.lblBestSeller = new System.Windows.Forms.Label();

            this.panelCard1.SuspendLayout();
            this.panelCard2.SuspendLayout();
            this.panelCard3.SuspendLayout();
            this.SuspendLayout();

            // 
            // FormQuickReport (Đồng bộ kích thước với panelMainContent: 1050x660)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1050, 660);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormQuickReport";
            this.Text = "BÁO CÁO DOANH THU & HIỆU SUẤT";

            // 
            // lblTitleReport
            // 
            this.lblTitleReport.AutoSize = true;
            this.lblTitleReport.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleReport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(48)))));
            this.lblTitleReport.Location = new System.Drawing.Point(30, 25);
            this.lblTitleReport.Name = "lblTitleReport";
            this.lblTitleReport.Size = new System.Drawing.Size(370, 32);
            this.lblTitleReport.Text = "THỐNG KÊ DOANH THU NHANH";

            // 
            // dtpReportDate
            // 
            this.dtpReportDate.CustomFormat = "dd/MM/yyyy";
            this.dtpReportDate.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpReportDate.Location = new System.Drawing.Point(30, 80);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(220, 32);

            // 
            // btnRunReport
            // 
            this.btnRunReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnRunReport.FlatAppearance.BorderSize = 0;
            this.btnRunReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunReport.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRunReport.ForeColor = System.Drawing.Color.White;
            this.btnRunReport.Location = new System.Drawing.Point(270, 80);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(150, 35);
            this.btnRunReport.Text = "Xem báo cáo";
            this.btnRunReport.UseVisualStyleBackColor = false;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);

            // 
            // panelCard1 (Tổng số hóa đơn)
            // 
            this.panelCard1.BackColor = System.Drawing.Color.White;
            this.panelCard1.Controls.Add(this.lblTotalOrders);
            this.panelCard1.Controls.Add(this.lblTitleOrders);
            this.panelCard1.Location = new System.Drawing.Point(30, 150);
            this.panelCard1.Name = "panelCard1";
            this.panelCard1.Size = new System.Drawing.Size(310, 160);
            
            this.lblTitleOrders.AutoSize = true;
            this.lblTitleOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleOrders.ForeColor = System.Drawing.Color.Gray;
            this.lblTitleOrders.Location = new System.Drawing.Point(20, 20);
            this.lblTitleOrders.Text = "TỔNG SỐ HÓA ĐƠN";

            this.lblTotalOrders.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblTotalOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblTotalOrders.Location = new System.Drawing.Point(20, 70);
            this.lblTotalOrders.Name = "lblTotalOrders";
            this.lblTotalOrders.Size = new System.Drawing.Size(270, 60);
            this.lblTotalOrders.Text = "0";

            // 
            // panelCard2 (Tổng doanh thu)
            // 
            this.panelCard2.BackColor = System.Drawing.Color.White;
            this.panelCard2.Controls.Add(this.lblTotalRevenue);
            this.panelCard2.Controls.Add(this.lblTitleRevenue);
            this.panelCard2.Location = new System.Drawing.Point(370, 150);
            this.panelCard2.Name = "panelCard2";
            this.panelCard2.Size = new System.Drawing.Size(310, 160);

            this.lblTitleRevenue.AutoSize = true;
            this.lblTitleRevenue.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleRevenue.ForeColor = System.Drawing.Color.Gray;
            this.lblTitleRevenue.Location = new System.Drawing.Point(20, 20);
            this.lblTitleRevenue.Text = "TỔNG DOANH THU";

            this.lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblTotalRevenue.Location = new System.Drawing.Point(20, 70);
            this.lblTotalRevenue.Name = "lblTotalRevenue";
            this.lblTotalRevenue.Size = new System.Drawing.Size(270, 60);
            this.lblTotalRevenue.Text = "0 VNĐ";

            // 
            // panelCard3 (Mặt hàng bán chạy nhất)
            // 
            this.panelCard3.BackColor = System.Drawing.Color.White;
            this.panelCard3.Controls.Add(this.lblBestSeller);
            this.panelCard3.Controls.Add(this.lblTitleBestSeller);
            this.panelCard3.Location = new System.Drawing.Point(710, 150);
            this.panelCard3.Name = "panelCard3";
            this.panelCard3.Size = new System.Drawing.Size(310, 160);

            this.lblTitleBestSeller.AutoSize = true;
            this.lblTitleBestSeller.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            //this.lblTitleBestSpacer = true;
            this.lblTitleBestSeller.ForeColor = System.Drawing.Color.Gray;
            this.lblTitleBestSeller.Location = new System.Drawing.Point(20, 20);
            this.lblTitleBestSeller.Text = "MẶT HÀNG BÁN CHẠY";

            this.lblBestSeller.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBestSeller.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblBestSeller.Location = new System.Drawing.Point(20, 70);
            this.lblBestSeller.Name = "lblBestSeller";
            this.lblBestSeller.Size = new System.Drawing.Size(270, 70);
            this.lblBestSeller.Text = "Đang cập nhật";

            // 
            // FormQuickReport Finalize
            // 
            this.Controls.Add(this.lblTitleReport);
            this.Controls.Add(this.dtpReportDate);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.panelCard1);
            this.Controls.Add(this.panelCard2);
            this.Controls.Add(this.panelCard3);

            this.panelCard1.ResumeLayout(false);
            this.panelCard1.PerformLayout();
            this.panelCard2.ResumeLayout(false);
            this.panelCard2.PerformLayout();
            this.panelCard3.ResumeLayout(false);
            this.panelCard3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}