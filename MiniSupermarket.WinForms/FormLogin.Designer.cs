namespace MiniSupermarket.WinForms
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox grpLogin;
        private Label lblUser;
        private Label lblPass;
        private TextBox txtUser;
        private TextBox txtPass;
        private Button btnLogin;

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
            this.grpLogin = new GroupBox();
            this.lblUser = new Label();
            this.lblPass = new Label();
            this.txtUser = new TextBox();
            this.txtPass = new TextBox();
            this.btnLogin = new Button();

            this.grpLogin.SuspendLayout();
            this.SuspendLayout();

            // 
            // grpLogin
            // 
            this.grpLogin.Controls.Add(this.lblUser);
            this.grpLogin.Controls.Add(this.txtUser);
            this.grpLogin.Controls.Add(this.lblPass);
            this.grpLogin.Controls.Add(this.txtPass);
            this.grpLogin.Controls.Add(this.btnLogin);

            this.grpLogin.Location = new Point(45, 35);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new Size(310, 190);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.TabStop = false;
            this.grpLogin.Text = "Đăng nhập";

            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new Point(20, 40);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new Size(65, 15);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Tài khoản:";

            // 
            // txtUser
            // 
            this.txtUser.Location = new Point(95, 36);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new Size(190, 23);
            this.txtUser.TabIndex = 1;

            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new Point(20, 80);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new Size(62, 15);
            this.lblPass.TabIndex = 2;
            this.lblPass.Text = "Mật khẩu:";

            // 
            // txtPass
            // 
            this.txtPass.Location = new Point(95, 76);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new Size(190, 23);
            this.txtPass.TabIndex = 3;
            this.txtPass.UseSystemPasswordChar = true;

            // 
            // btnLogin
            // 
            this.btnLogin.Location = new Point(70, 120);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(170, 35);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng nhập hệ thống";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // 
            // FormLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(400, 270);
            this.Controls.Add(this.grpLogin);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập hệ thống";

            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}