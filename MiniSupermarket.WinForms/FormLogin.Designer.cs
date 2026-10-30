namespace MiniSupermarket.WinForms
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Panel pnlLogoIcon;
        private System.Windows.Forms.Label lblLogoIcon;
        private System.Windows.Forms.Label lblBrandTitle;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Label lblWelcomeTitle;
        private System.Windows.Forms.Label lblWelcomeSubtitle;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.CheckBox chkRememberMe;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlDemoHint;
        private System.Windows.Forms.Label lblDemoTitle;
        private System.Windows.Forms.Label lblDemoInfo;
        private System.Windows.Forms.Label lblFooterVersion;

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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.pnlLogoIcon = new System.Windows.Forms.Panel();
            this.lblLogoIcon = new System.Windows.Forms.Label();
            this.lblBrandTitle = new System.Windows.Forms.Label();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblWelcomeTitle = new System.Windows.Forms.Label();
            this.lblWelcomeSubtitle = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.chkRememberMe = new System.Windows.Forms.CheckBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlDemoHint = new System.Windows.Forms.Panel();
            this.lblDemoTitle = new System.Windows.Forms.Label();
            this.lblDemoInfo = new System.Windows.Forms.Label();
            this.lblFooterVersion = new System.Windows.Forms.Label();

            this.pnlCard.SuspendLayout();
            this.pnlLogoIcon.SuspendLayout();
            this.pnlDemoHint.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.pnlLogoIcon);
            this.pnlCard.Controls.Add(this.lblBrandTitle);
            this.pnlCard.Controls.Add(this.lblBrandSub);
            this.pnlCard.Controls.Add(this.lblWelcomeTitle);
            this.pnlCard.Controls.Add(this.lblWelcomeSubtitle);
            this.pnlCard.Controls.Add(this.lblUser);
            this.pnlCard.Controls.Add(this.txtUser);
            this.pnlCard.Controls.Add(this.lblPass);
            this.pnlCard.Controls.Add(this.txtPass);
            this.pnlCard.Controls.Add(this.chkShowPass);
            this.pnlCard.Controls.Add(this.chkRememberMe);
            this.pnlCard.Controls.Add(this.lblStatus);
            this.pnlCard.Controls.Add(this.btnLogin);
            this.pnlCard.Controls.Add(this.pnlDemoHint);
            this.pnlCard.Controls.Add(this.lblFooterVersion);
            this.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Padding = new System.Windows.Forms.Padding(40, 28, 40, 24);
            this.pnlCard.Size = new System.Drawing.Size(460, 620);
            this.pnlCard.TabIndex = 0;

            // 
            // pnlLogoIcon
            // 
            this.pnlLogoIcon.BackColor = System.Drawing.Color.FromArgb(220, 252, 231); // #DCFCE7
            this.pnlLogoIcon.Controls.Add(this.lblLogoIcon);
            this.pnlLogoIcon.Location = new System.Drawing.Point(204, 24);
            this.pnlLogoIcon.Name = "pnlLogoIcon";
            this.pnlLogoIcon.Size = new System.Drawing.Size(52, 52);
            this.pnlLogoIcon.TabIndex = 0;

            // 
            // lblLogoIcon
            // 
            this.lblLogoIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLogoIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 20F);
            this.lblLogoIcon.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblLogoIcon.Location = new System.Drawing.Point(0, 0);
            this.lblLogoIcon.Name = "lblLogoIcon";
            this.lblLogoIcon.Size = new System.Drawing.Size(52, 52);
            this.lblLogoIcon.TabIndex = 0;
            this.lblLogoIcon.Text = "🛒";
            this.lblLogoIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblBrandTitle
            // 
            this.lblBrandTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblBrandTitle.ForeColor = System.Drawing.Color.FromArgb(16, 42, 33); // #102A21
            this.lblBrandTitle.Location = new System.Drawing.Point(40, 80);
            this.lblBrandTitle.Name = "lblBrandTitle";
            this.lblBrandTitle.Size = new System.Drawing.Size(380, 28);
            this.lblBrandTitle.TabIndex = 1;
            this.lblBrandTitle.Text = "MINI SUPERMARKET";
            this.lblBrandTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblBrandSub
            // 
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74); // #16A34A
            this.lblBrandSub.Location = new System.Drawing.Point(40, 108);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(380, 18);
            this.lblBrandSub.TabIndex = 2;
            this.lblBrandSub.Text = "PREMIUM RETAIL POS & MANAGEMENT SYSTEM";
            this.lblBrandSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblWelcomeTitle
            // 
            this.lblWelcomeTitle.AutoSize = true;
            this.lblWelcomeTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblWelcomeTitle.ForeColor = System.Drawing.Color.FromArgb(23, 33, 27);
            this.lblWelcomeTitle.Location = new System.Drawing.Point(40, 138);
            this.lblWelcomeTitle.Name = "lblWelcomeTitle";
            this.lblWelcomeTitle.Size = new System.Drawing.Size(161, 21);
            this.lblWelcomeTitle.TabIndex = 3;
            this.lblWelcomeTitle.Text = "Chào mừng trở lại 👋";

            // 
            // lblWelcomeSubtitle
            // 
            this.lblWelcomeSubtitle.AutoSize = true;
            this.lblWelcomeSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWelcomeSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblWelcomeSubtitle.Location = new System.Drawing.Point(40, 162);
            this.lblWelcomeSubtitle.Name = "lblWelcomeSubtitle";
            this.lblWelcomeSubtitle.Size = new System.Drawing.Size(262, 15);
            this.lblWelcomeSubtitle.TabIndex = 4;
            this.lblWelcomeSubtitle.Text = "Vui lòng nhập tài khoản và mật khẩu để đăng nhập";

            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(23, 33, 27);
            this.lblUser.Location = new System.Drawing.Point(40, 192);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(121, 15);
            this.lblUser.TabIndex = 5;
            this.lblUser.Text = "Tài khoản nhân viên *";

            // 
            // txtUser
            // 
            this.txtUser.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtUser.Location = new System.Drawing.Point(40, 212);
            this.txtUser.Name = "txtUser";
            this.txtUser.PlaceholderText = "Nhập tên đăng nhập...";
            this.txtUser.Size = new System.Drawing.Size(380, 26);
            this.txtUser.TabIndex = 6;

            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(23, 33, 27);
            this.lblPass.Location = new System.Drawing.Point(40, 250);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(69, 15);
            this.lblPass.TabIndex = 7;
            this.lblPass.Text = "Mật khẩu *";

            // 
            // txtPass
            // 
            this.txtPass.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtPass.Location = new System.Drawing.Point(40, 270);
            this.txtPass.Name = "txtPass";
            this.txtPass.PlaceholderText = "Nhập mật khẩu...";
            this.txtPass.Size = new System.Drawing.Size(380, 26);
            this.txtPass.TabIndex = 8;
            this.txtPass.UseSystemPasswordChar = true;

            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkShowPass.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkShowPass.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.chkShowPass.Location = new System.Drawing.Point(40, 306);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(121, 19);
            this.chkShowPass.TabIndex = 9;
            this.chkShowPass.Text = "Hiển thị mật khẩu";
            this.chkShowPass.UseVisualStyleBackColor = true;
            this.chkShowPass.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);

            // 
            // chkRememberMe
            // 
            this.chkRememberMe.AutoSize = true;
            this.chkRememberMe.Checked = true;
            this.chkRememberMe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRememberMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRememberMe.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkRememberMe.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.chkRememberMe.Location = new System.Drawing.Point(290, 306);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.Size = new System.Drawing.Size(130, 19);
            this.chkRememberMe.TabIndex = 10;
            this.chkRememberMe.Text = "Ghi nhớ phiên làm";
            this.chkRememberMe.UseVisualStyleBackColor = true;

            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            this.lblStatus.Location = new System.Drawing.Point(40, 332);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(380, 20);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(22, 163, 74); // #16A34A
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(40, 356);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(380, 44);
            this.btnLogin.TabIndex = 12;
            this.btnLogin.Text = "🔐 ĐĂNG NHẬP VÀO HỆ THỐNG";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // 
            // pnlDemoHint
            // 
            this.pnlDemoHint.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlDemoHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDemoHint.Controls.Add(this.lblDemoTitle);
            this.pnlDemoHint.Controls.Add(this.lblDemoInfo);
            this.pnlDemoHint.Location = new System.Drawing.Point(40, 420);
            this.pnlDemoHint.Name = "pnlDemoHint";
            this.pnlDemoHint.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlDemoHint.Size = new System.Drawing.Size(380, 96);
            this.pnlDemoHint.TabIndex = 13;

            // 
            // lblDemoTitle
            // 
            this.lblDemoTitle.AutoSize = true;
            this.lblDemoTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDemoTitle.ForeColor = System.Drawing.Color.FromArgb(20, 83, 45); // #14532D
            this.lblDemoTitle.Location = new System.Drawing.Point(10, 8);
            this.lblDemoTitle.Name = "lblDemoTitle";
            this.lblDemoTitle.Size = new System.Drawing.Size(188, 15);
            this.lblDemoTitle.TabIndex = 0;
            this.lblDemoTitle.Text = "⚡ TÀI KHOẢN MẪU HỆ THỐNG:";

            // 
            // lblDemoInfo
            // 
            this.lblDemoInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDemoInfo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblDemoInfo.Location = new System.Drawing.Point(10, 28);
            this.lblDemoInfo.Name = "lblDemoInfo";
            this.lblDemoInfo.Size = new System.Drawing.Size(356, 58);
            this.lblDemoInfo.TabIndex = 1;
            this.lblDemoInfo.Text = "• Quản trị viên: admin / 123456\n• Thu ngân POS: cashier01 / 123456\n• Thủ kho: ware01 / 123456";

            // 
            // lblFooterVersion
            // 
            this.lblFooterVersion.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblFooterVersion.ForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            this.lblFooterVersion.Location = new System.Drawing.Point(40, 578);
            this.lblFooterVersion.Name = "lblFooterVersion";
            this.lblFooterVersion.Size = new System.Drawing.Size(380, 20);
            this.lblFooterVersion.TabIndex = 14;
            this.lblFooterVersion.Text = "© 2026 MiniSuperMarket • Retail POS Enterprise v2.5";
            this.lblFooterVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 245); // #F4F7F5
            this.ClientSize = new System.Drawing.Size(460, 620);
            this.Controls.Add(this.pnlCard);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống Mini Supermarket POS";
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlLogoIcon.ResumeLayout(false);
            this.pnlDemoHint.ResumeLayout(false);
            this.pnlDemoHint.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}
