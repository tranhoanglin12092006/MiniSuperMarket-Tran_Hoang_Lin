namespace MiniSupermarket.WinForms
{
    partial class FormMainShell
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnUserManage = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelTopHeader = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelMainContent = new System.Windows.Forms.Panel();

            this.panelSidebar.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.panelTopHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(48)))));
            this.panelSidebar.Controls.Add(this.panelBottom);
            this.panelSidebar.Controls.Add(this.btnUserManage);
            this.panelSidebar.Controls.Add(this.btnReports);
            this.panelSidebar.Controls.Add(this.btnCustomer);
            this.panelSidebar.Controls.Add(this.btnProduct);
            this.panelSidebar.Controls.Add(this.btnCategory);
            this.panelSidebar.Controls.Add(this.btnPOS);
            this.panelSidebar.Controls.Add(this.lblLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(230, 720);
            this.panelSidebar.TabIndex = 0;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnLogout);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 660);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(230, 60);
            this.panelBottom.TabIndex = 7;
            // 
            // btnLogout
            // 
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(0, 0);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(230, 60);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "🚪 Đăng xuất";
            this.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnUserManage
            // 
            this.btnUserManage.FlatAppearance.BorderSize = 0;
            this.btnUserManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManage.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnUserManage.ForeColor = System.Drawing.Color.White;
            this.btnUserManage.Location = new System.Drawing.Point(0, 315);
            this.btnUserManage.Name = "btnUserManage";
            this.btnUserManage.Size = new System.Drawing.Size(230, 45);
            this.btnUserManage.TabIndex = 6;
            this.btnUserManage.Text = "🛡 Quản trị Tài khoản";
            this.btnUserManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManage.UseVisualStyleBackColor = true;

            this.btnUserManage.Click += new System.EventHandler(this.btnUserManage_Click);
            // 
            // btnReports
            // 
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(0, 270);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(230, 45);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "📊 Báo cáo Doanh thu";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = true;

            // PHẢI CÓ DÒNG NÀY THÌ NÚT BẤM MỚI NHẬN HÀM XỬ LÝ:
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Location = new System.Drawing.Point(0, 225);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(230, 45);
            this.btnCustomer.TabIndex = 4;
            this.btnCustomer.Text = "👥 Quản lý Khách hàng";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnProduct.ForeColor = System.Drawing.Color.White;
            this.btnProduct.Location = new System.Drawing.Point(0, 180);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(230, 45);
            this.btnProduct.TabIndex = 3;
            this.btnProduct.Text = "📦 Quản lý Sản phẩm";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCategory.ForeColor = System.Drawing.Color.White;
            this.btnCategory.Location = new System.Drawing.Point(0, 135);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(230, 45);
            this.btnCategory.TabIndex = 2;
            this.btnCategory.Text = "📁 Quản lý Danh mục";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnPOS.ForeColor = System.Drawing.Color.White;
            this.btnPOS.Location = new System.Drawing.Point(0, 90);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Size = new System.Drawing.Size(230, 45);
            this.btnPOS.TabIndex = 1;
            this.btnPOS.Text = "🛒 Bán hàng (POS)";
            this.btnPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.UseVisualStyleBackColor = true;
            this.btnPOS.Click += new System.EventHandler(this.BtnPOS_Click);
            // 
            // lblLogo
            // 
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(0, 0);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(230, 80);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "🛒 MiniMart POS";
            this.lblLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTopHeader
            // 
            this.panelTopHeader.BackColor = System.Drawing.Color.White;
            this.panelTopHeader.Controls.Add(this.lblUserInfo);
            this.panelTopHeader.Controls.Add(this.lblTitle);
            this.panelTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopHeader.Location = new System.Drawing.Point(230, 0);
            this.panelTopHeader.Name = "panelTopHeader";
            this.panelTopHeader.Size = new System.Drawing.Size(1050, 60);
            this.panelTopHeader.TabIndex = 1;
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)) | System.Windows.Forms.AnchorStyles.Right);
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserInfo.Location = new System.Drawing.Point(600, 0);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(438, 60);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Xin chào: ...";
            this.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(20, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(550, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÀN LÀM VIỆC HỆ THỐNG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(230, 60);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1050, 660);
            this.panelMainContent.TabIndex = 2;
            // 
            // FormMainShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelTopHeader);
            this.Controls.Add(this.panelSidebar);
            this.Name = "FormMainShell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Bán lẻ & Tồn kho Siêu thị Mini";
            this.Load += new System.EventHandler(this.FormMainShell_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelTopHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelTopHeader;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUserManage;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserInfo;
    }
}