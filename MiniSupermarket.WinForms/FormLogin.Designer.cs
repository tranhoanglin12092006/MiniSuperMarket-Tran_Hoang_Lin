namespace MiniSupermarket.WinForms
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblBrandLogo;
        private System.Windows.Forms.Label lblBrandTitle;
        private System.Windows.Forms.Label lblBrandSub;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.Label lblLoginHeading;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.CheckBox chkShowPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelDemoHint;
        private System.Windows.Forms.Label lblDemoTitle;
        private System.Windows.Forms.Label lblDemoInfo;

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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblBrandSub = new System.Windows.Forms.Label();
            this.lblBrandTitle = new System.Windows.Forms.Label();
            this.lblBrandLogo = new System.Windows.Forms.Label();
            this.panelBody = new System.Windows.Forms.Panel();
            this.panelDemoHint = new System.Windows.Forms.Panel();
            this.lblDemoInfo = new System.Windows.Forms.Label();
            this.lblDemoTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkShowPass = new System.Windows.Forms.CheckBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblLoginHeading = new System.Windows.Forms.Label();
            this.panelTop.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panelDemoHint.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panelTop.Controls.Add(this.lblBrandSub);
            this.panelTop.Controls.Add(this.lblBrandTitle);
            this.panelTop.Controls.Add(this.lblBrandLogo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(460, 130);
            this.panelTop.TabIndex = 0;
            // 
            // lblBrandSub
            // 
            this.lblBrandSub.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBrandSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblBrandSub.Location = new System.Drawing.Point(20, 92);
            this.lblBrandSub.Name = "lblBrandSub";
            this.lblBrandSub.Size = new System.Drawing.Size(420, 22);
            this.lblBrandSub.TabIndex = 2;
            this.lblBrandSub.Text = "HỆ THỐNG BÁN LẺ POS & QUẢN KHO TẬP TRUNG";
            this.lblBrandSub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrandTitle
            // 
            this.lblBrandTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblBrandTitle.ForeColor = System.Drawing.Color.White;
            this.lblBrandTitle.Location = new System.Drawing.Point(20, 56);
            this.lblBrandTitle.Name = "lblBrandTitle";
            this.lblBrandTitle.Size = new System.Drawing.Size(420, 36);
            this.lblBrandTitle.TabIndex = 1;
            this.lblBrandTitle.Text = "MINI SUPERMARKET";
            this.lblBrandTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBrandLogo
            // 
            this.lblBrandLogo.Font = new System.Drawing.Font("Segoe UI Emoji", 26F);
            this.lblBrandLogo.ForeColor = System.Drawing.Color.White;
            this.lblBrandLogo.Location = new System.Drawing.Point(20, 10);
            this.lblBrandLogo.Name = "lblBrandLogo";
            this.lblBrandLogo.Size = new System.Drawing.Size(420, 48);
            this.lblBrandLogo.TabIndex = 0;
            this.lblBrandLogo.Text = "🛒";
            this.lblBrandLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBody
            // 
            this.panelBody.BackColor = System.Drawing.Color.White;
            this.panelBody.Controls.Add(this.panelDemoHint);
            this.panelBody.Controls.Add(this.lblStatus);
            this.panelBody.Controls.Add(this.btnLogin);
            this.panelBody.Controls.Add(this.chkShowPass);
            this.panelBody.Controls.Add(this.txtPass);
            this.panelBody.Controls.Add(this.lblPass);
            this.panelBody.Controls.Add(this.txtUser);
            this.panelBody.Controls.Add(this.lblUser);
            this.panelBody.Controls.Add(this.lblLoginHeading);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBody.Location = new System.Drawing.Point(0, 130);
            this.panelBody.Name = "panelBody";
            this.panelBody.Padding = new System.Windows.Forms.Padding(35, 20, 35, 20);
            this.panelBody.Size = new System.Drawing.Size(460, 430);
            this.panelBody.TabIndex = 1;
            // 
            // panelDemoHint
            // 
            this.panelDemoHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelDemoHint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDemoHint.Controls.Add(this.lblDemoInfo);
            this.panelDemoHint.Controls.Add(this.lblDemoTitle);
            this.panelDemoHint.Location = new System.Drawing.Point(35, 335);
            this.panelDemoHint.Name = "panelDemoHint";
            this.panelDemoHint.Size = new System.Drawing.Size(390, 75);
            this.panelDemoHint.TabIndex = 8;
            // 
            // lblDemoInfo
            // 
            this.lblDemoInfo.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDemoInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblDemoInfo.Location = new System.Drawing.Point(10, 24);
            this.lblDemoInfo.Name = "lblDemoInfo";
            this.lblDemoInfo.Size = new System.Drawing.Size(370, 44);
            this.lblDemoInfo.TabIndex = 1;
            this.lblDemoInfo.Text = "• Admin: admin / admin01 (MK: 123456)\n• Thu ngân: cashier01 | Thủ kho: ware01 (MK: 123456)";
            // 
            // lblDemoTitle
            // 
            this.lblDemoTitle.AutoSize = true;
            this.lblDemoTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblDemoTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDemoTitle.Location = new System.Drawing.Point(10, 6);
            this.lblDemoTitle.Name = "lblDemoTitle";
            this.lblDemoTitle.Size = new System.Drawing.Size(185, 19);
            this.lblDemoTitle.TabIndex = 0;
            this.lblDemoTitle.Text = "🔑 Tài khoản dùng thử:";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.lblStatus.ForeColor = System.Drawing.Color.Crimson;
            this.lblStatus.Location = new System.Drawing.Point(35, 246);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(390, 22);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(35, 275);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(390, 48);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "ĐĂNG NHẬP VÀO HỆ THỐNG";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkShowPass
            // 
            this.chkShowPass.AutoSize = true;
            this.chkShowPass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkShowPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.chkShowPass.Location = new System.Drawing.Point(35, 220);
            this.chkShowPass.Name = "chkShowPass";
            this.chkShowPass.Size = new System.Drawing.Size(149, 24);
            this.chkShowPass.TabIndex = 5;
            this.chkShowPass.Text = "Hiển thị mật khẩu";
            this.chkShowPass.UseVisualStyleBackColor = true;
            this.chkShowPass.CheckedChanged += new System.EventHandler(this.chkShowPass_CheckedChanged);
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtPass.Location = new System.Drawing.Point(35, 178);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(390, 32);
            this.txtPass.TabIndex = 4;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblPass.Location = new System.Drawing.Point(35, 150);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(86, 21);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Mật khẩu:";
            // 
            // txtUser
            // 
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUser.Location = new System.Drawing.Point(35, 102);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(390, 32);
            this.txtUser.TabIndex = 2;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblUser.Location = new System.Drawing.Point(35, 75);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(128, 21);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Tên đăng nhập:";
            // 
            // lblLoginHeading
            // 
            this.lblLoginHeading.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLoginHeading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblLoginHeading.Location = new System.Drawing.Point(35, 15);
            this.lblLoginHeading.Name = "lblLoginHeading";
            this.lblLoginHeading.Size = new System.Drawing.Size(390, 35);
            this.lblLoginHeading.TabIndex = 0;
            this.lblLoginHeading.Text = "XÁC THỰC NGƯỜI DÙNG";
            this.lblLoginHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(460, 560);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.panelTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống Mini Supermarket";
            this.panelTop.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.panelDemoHint.ResumeLayout(false);
            this.panelDemoHint.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}