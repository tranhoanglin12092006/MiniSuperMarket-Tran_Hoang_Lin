namespace MiniSupermarket.WinForms
{
    partial class FormUserManagement
    {
        private System.ComponentModel.IContainer components = null;

        // Khu vực Trái (Bảng danh sách nhân viên)
        private System.Windows.Forms.DataGridView dgvUsers;

        // Khu vực Phải (Form chi tiết & Thao tác)
        private System.Windows.Forms.GroupBox grpUserDetails;
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

        // Các nút chức năng
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.Button btnToggleLock;

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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.grpUserDetails = new System.Windows.Forms.GroupBox();
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
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnToggleLock = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.grpUserDetails.SuspendLayout();
            this.SuspendLayout();

            // 
            // FormUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1050, 660);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUserManagement";
            this.Text = "QUẢN LÝ TÀI KHOẢN & PHÂN QUYỀN";
            this.Load += new System.EventHandler(this.FormUserManagement_Load);

            // 
            // dgvUsers (Bảng hiển thị danh sách nhân viên - Chiếm bên trái)
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(20, 20);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(680, 620);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);

            // 
            // grpUserDetails (Khung thông tin chi tiết - Chiếm bên phải)
            // 
            this.grpUserDetails.Controls.Add(this.btnToggleLock);
            this.grpUserDetails.Controls.Add(this.btnResetPassword);
            this.grpUserDetails.Controls.Add(this.btnAddUser);
            this.grpUserDetails.Controls.Add(this.cboRole);
            this.grpUserDetails.Controls.Add(this.lblRoleTitle);
            this.grpUserDetails.Controls.Add(this.txtPassword);
            this.grpUserDetails.Controls.Add(this.lblPasswordTitle);
            this.grpUserDetails.Controls.Add(this.txtEmail);
            this.grpUserDetails.Controls.Add(this.lblEmailTitle);
            this.grpUserDetails.Controls.Add(this.txtFullName);
            this.grpUserDetails.Controls.Add(this.lblFullNameTitle);
            this.grpUserDetails.Controls.Add(this.txtUsername);
            this.grpUserDetails.Controls.Add(this.lblUsernameTitle);
            this.grpUserDetails.Location = new System.Drawing.Point(720, 20);
            this.grpUserDetails.Name = "grpUserDetails";
            this.grpUserDetails.Size = new System.Drawing.Size(310, 620);
            this.grpUserDetails.TabStop = false;
            this.grpUserDetails.Text = "Thông tin tài khoản";

            // lblUsernameTitle & txtUsername
            this.lblUsernameTitle.AutoSize = true;
            this.lblUsernameTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsernameTitle.Location = new System.Drawing.Point(15, 35);
            this.lblUsernameTitle.Name = "lblUsernameTitle";
            this.lblUsernameTitle.Size = new System.Drawing.Size(110, 20);
            this.lblUsernameTitle.Text = "Tên đăng nhập:";

            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(15, 58);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(280, 30);
            this.txtUsername.TabIndex = 0;

            // lblFullNameTitle & txtFullName
            this.lblFullNameTitle.AutoSize = true;
            this.lblFullNameTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFullNameTitle.Location = new System.Drawing.Point(15, 100);
            this.lblFullNameTitle.Name = "lblFullNameTitle";
            this.lblFullNameTitle.Size = new System.Drawing.Size(76, 20);
            this.lblFullNameTitle.Text = "Họ và tên:";

            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.Location = new System.Drawing.Point(15, 123);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(280, 30);
            this.txtFullName.TabIndex = 1;

            // lblEmailTitle & txtEmail
            this.lblEmailTitle.AutoSize = true;
            this.lblEmailTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmailTitle.Location = new System.Drawing.Point(15, 165);
            this.lblEmailTitle.Name = "lblEmailTitle";
            this.lblEmailTitle.Size = new System.Drawing.Size(49, 20);
            this.lblEmailTitle.Text = "Email:";

            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(15, 188);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(280, 30);
            this.txtEmail.TabIndex = 2;

            // lblPasswordTitle & txtPassword
            this.lblPasswordTitle.AutoSize = true;
            this.lblPasswordTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPasswordTitle.Location = new System.Drawing.Point(15, 230);
            this.lblPasswordTitle.Name = "lblPasswordTitle";
            this.lblPasswordTitle.Size = new System.Drawing.Size(73, 20);
            this.lblPasswordTitle.Text = "Mật khẩu:";

            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(15, 253);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(280, 30);
            this.txtPassword.TabIndex = 3;

            // lblRoleTitle & cboRole
            this.lblRoleTitle.AutoSize = true;
            this.lblRoleTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRoleTitle.Location = new System.Drawing.Point(15, 295);
            this.lblRoleTitle.Name = "lblRoleTitle";
            this.lblRoleTitle.Size = new System.Drawing.Size(54, 20);
            this.lblRoleTitle.Text = "Vai trò:";

            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(15, 318);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(280, 31);
            this.cboRole.TabIndex = 4;

            // btnAddUser (Thêm tài khoản mới)
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(15, 390);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(280, 40);
            this.btnAddUser.TabIndex = 5;
            this.btnAddUser.Text = "Thêm mới tài khoản";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);

            // btnResetPassword (Đặt lại mật khẩu)
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnResetPassword.FlatAppearance.BorderSize = 0;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnResetPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnResetPassword.Location = new System.Drawing.Point(15, 445);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(280, 40);
            this.btnResetPassword.TabIndex = 6;
            this.btnResetPassword.Text = "Đặt lại mật khẩu";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);

            // btnToggleLock (Khóa / Mở khóa tài khoản)
            this.btnToggleLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnToggleLock.FlatAppearance.BorderSize = 0;
            this.btnToggleLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleLock.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnToggleLock.ForeColor = System.Drawing.Color.White;
            this.btnToggleLock.Location = new System.Drawing.Point(15, 500);
            this.btnToggleLock.Name = "btnToggleLock";
            this.btnToggleLock.Size = new System.Drawing.Size(280, 40);
            this.btnToggleLock.TabIndex = 7;
            this.btnToggleLock.Text = "Khóa / Mở khóa tài khoản";
            this.btnToggleLock.UseVisualStyleBackColor = false;
            this.btnToggleLock.Click += new System.EventHandler(this.btnToggleLock_Click);

            // Finalize Form Setup
            this.Controls.Add(this.grpUserDetails);
            this.Controls.Add(this.dgvUsers);

            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.grpUserDetails.ResumeLayout(false);
            this.grpUserDetails.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}