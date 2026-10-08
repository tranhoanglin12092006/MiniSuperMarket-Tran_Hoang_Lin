namespace MiniSupermarket.WinForms
{
    partial class FormUserManagement
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel pnlRightCard;
        private System.Windows.Forms.Label lblCardHeader;
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
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.pnlRightCard = new System.Windows.Forms.Panel();
            this.lblNotification = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnToggleLock = new System.Windows.Forms.Button();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.pnlQuickRole = new System.Windows.Forms.Panel();
            this.btnRoleWarehouse = new System.Windows.Forms.Button();
            this.btnRoleCashier = new System.Windows.Forms.Button();
            this.btnRoleAdmin = new System.Windows.Forms.Button();
            this.lblQuickRoleTitle = new System.Windows.Forms.Label();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRoleTitle = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordTitle = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmailTitle = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullNameTitle = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsernameTitle = new System.Windows.Forms.Label();
            this.lblCardHeader = new System.Windows.Forms.Label();
            this.pnlMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.pnlRightCard.SuspendLayout();
            this.pnlQuickRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMainContainer
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlMainContainer.Controls.Add(this.dgvUsers);
            this.pnlMainContainer.Controls.Add(this.pnlRightCard);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Padding = new System.Windows.Forms.Padding(16);
            this.pnlMainContainer.Size = new System.Drawing.Size(1074, 693);
            this.pnlMainContainer.TabIndex = 0;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.ColumnHeadersHeight = 42;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvUsers.Location = new System.Drawing.Point(16, 16);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 36;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(682, 661);
            this.dgvUsers.TabIndex = 0;
            this.dgvUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsers_CellClick);
            // 
            // pnlRightCard
            // 
            this.pnlRightCard.BackColor = System.Drawing.Color.White;
            this.pnlRightCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRightCard.Controls.Add(this.lblNotification);
            this.pnlRightCard.Controls.Add(this.btnClear);
            this.pnlRightCard.Controls.Add(this.btnToggleLock);
            this.pnlRightCard.Controls.Add(this.btnResetPassword);
            this.pnlRightCard.Controls.Add(this.btnUpdateUser);
            this.pnlRightCard.Controls.Add(this.btnAddUser);
            this.pnlRightCard.Controls.Add(this.pnlQuickRole);
            this.pnlRightCard.Controls.Add(this.cboRole);
            this.pnlRightCard.Controls.Add(this.lblRoleTitle);
            this.pnlRightCard.Controls.Add(this.txtPassword);
            this.pnlRightCard.Controls.Add(this.lblPasswordTitle);
            this.pnlRightCard.Controls.Add(this.txtEmail);
            this.pnlRightCard.Controls.Add(this.lblEmailTitle);
            this.pnlRightCard.Controls.Add(this.txtFullName);
            this.pnlRightCard.Controls.Add(this.lblFullNameTitle);
            this.pnlRightCard.Controls.Add(this.txtUsername);
            this.pnlRightCard.Controls.Add(this.lblUsernameTitle);
            this.pnlRightCard.Controls.Add(this.lblCardHeader);
            this.pnlRightCard.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRightCard.Location = new System.Drawing.Point(698, 16);
            this.pnlRightCard.Name = "pnlRightCard";
            this.pnlRightCard.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.pnlRightCard.Size = new System.Drawing.Size(360, 661);
            this.pnlRightCard.TabIndex = 1;
            // 
            // lblNotification
            // 
            this.lblNotification.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Regular);
            this.lblNotification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(163)))), ((int)(((byte)(74)))));
            this.lblNotification.Location = new System.Drawing.Point(18, 625);
            this.lblNotification.Name = "lblNotification";
            this.lblNotification.Size = new System.Drawing.Size(322, 24);
            this.lblNotification.TabIndex = 17;
            this.lblNotification.Text = "Hệ thống sẵn sàng.";
            this.lblNotification.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnClear.Location = new System.Drawing.Point(18, 584);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(322, 34);
            this.btnClear.TabIndex = 16;
            this.btnClear.Text = "🔄 Làm mới biểu mẫu";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnToggleLock
            // 
            this.btnToggleLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnToggleLock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToggleLock.FlatAppearance.BorderSize = 0;
            this.btnToggleLock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleLock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnToggleLock.ForeColor = System.Drawing.Color.White;
            this.btnToggleLock.Location = new System.Drawing.Point(183, 542);
            this.btnToggleLock.Name = "btnToggleLock";
            this.btnToggleLock.Size = new System.Drawing.Size(157, 36);
            this.btnToggleLock.TabIndex = 15;
            this.btnToggleLock.Text = "🔒 Khóa tài khoản";
            this.btnToggleLock.UseVisualStyleBackColor = false;
            this.btnToggleLock.Click += new System.EventHandler(this.btnToggleLock_Click);
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetPassword.FlatAppearance.BorderSize = 0;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.Location = new System.Drawing.Point(18, 542);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(157, 36);
            this.btnResetPassword.TabIndex = 14;
            this.btnResetPassword.Text = "🔑 Reset MK 123456";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnUpdateUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateUser.FlatAppearance.BorderSize = 0;
            this.btnUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUpdateUser.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUser.Location = new System.Drawing.Point(183, 496);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(157, 40);
            this.btnUpdateUser.TabIndex = 13;
            this.btnUpdateUser.Text = "💾 Cập nhật";
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnAddUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUser.FlatAppearance.BorderSize = 0;
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddUser.ForeColor = System.Drawing.Color.White;
            this.btnAddUser.Location = new System.Drawing.Point(18, 496);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(157, 40);
            this.btnAddUser.TabIndex = 12;
            this.btnAddUser.Text = "➕ Thêm tài khoản";
            this.btnAddUser.UseVisualStyleBackColor = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // pnlQuickRole
            // 
            this.pnlQuickRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlQuickRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlQuickRole.Controls.Add(this.btnRoleWarehouse);
            this.pnlQuickRole.Controls.Add(this.btnRoleCashier);
            this.pnlQuickRole.Controls.Add(this.btnRoleAdmin);
            this.pnlQuickRole.Controls.Add(this.lblQuickRoleTitle);
            this.pnlQuickRole.Location = new System.Drawing.Point(18, 395);
            this.pnlQuickRole.Name = "pnlQuickRole";
            this.pnlQuickRole.Padding = new System.Windows.Forms.Padding(6);
            this.pnlQuickRole.Size = new System.Drawing.Size(322, 85);
            this.pnlQuickRole.TabIndex = 11;
            // 
            // btnRoleWarehouse
            // 
            this.btnRoleWarehouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.btnRoleWarehouse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoleWarehouse.FlatAppearance.BorderSize = 0;
            this.btnRoleWarehouse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoleWarehouse.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnRoleWarehouse.ForeColor = System.Drawing.Color.White;
            this.btnRoleWarehouse.Location = new System.Drawing.Point(212, 34);
            this.btnRoleWarehouse.Name = "btnRoleWarehouse";
            this.btnRoleWarehouse.Size = new System.Drawing.Size(98, 38);
            this.btnRoleWarehouse.TabIndex = 3;
            this.btnRoleWarehouse.Text = "📦 Warehouse";
            this.btnRoleWarehouse.UseVisualStyleBackColor = false;
            this.btnRoleWarehouse.Click += new System.EventHandler(this.btnRoleWarehouse_Click);
            // 
            // btnRoleCashier
            // 
            this.btnRoleCashier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnRoleCashier.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoleCashier.FlatAppearance.BorderSize = 0;
            this.btnRoleCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoleCashier.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnRoleCashier.ForeColor = System.Drawing.Color.White;
            this.btnRoleCashier.Location = new System.Drawing.Point(109, 34);
            this.btnRoleCashier.Name = "btnRoleCashier";
            this.btnRoleCashier.Size = new System.Drawing.Size(98, 38);
            this.btnRoleCashier.TabIndex = 2;
            this.btnRoleCashier.Text = "🛒 Cashier";
            this.btnRoleCashier.UseVisualStyleBackColor = false;
            this.btnRoleCashier.Click += new System.EventHandler(this.btnRoleCashier_Click);
            // 
            // btnRoleAdmin
            // 
            this.btnRoleAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnRoleAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRoleAdmin.FlatAppearance.BorderSize = 0;
            this.btnRoleAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoleAdmin.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnRoleAdmin.ForeColor = System.Drawing.Color.White;
            this.btnRoleAdmin.Location = new System.Drawing.Point(6, 34);
            this.btnRoleAdmin.Name = "btnRoleAdmin";
            this.btnRoleAdmin.Size = new System.Drawing.Size(98, 38);
            this.btnRoleAdmin.TabIndex = 1;
            this.btnRoleAdmin.Text = "🛡️ Admin";
            this.btnRoleAdmin.UseVisualStyleBackColor = false;
            this.btnRoleAdmin.Click += new System.EventHandler(this.btnRoleAdmin_Click);
            // 
            // lblQuickRoleTitle
            // 
            this.lblQuickRoleTitle.AutoSize = true;
            this.lblQuickRoleTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblQuickRoleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblQuickRoleTitle.Location = new System.Drawing.Point(6, 9);
            this.lblQuickRoleTitle.Name = "lblQuickRoleTitle";
            this.lblQuickRoleTitle.Size = new System.Drawing.Size(262, 19);
            this.lblQuickRoleTitle.TabIndex = 0;
            this.lblQuickRoleTitle.Text = "⚡ Đổi vai trò nhanh (Tự động cập nhật):";
            // 
            // cboRole
            // 
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Location = new System.Drawing.Point(18, 348);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(322, 31);
            this.cboRole.TabIndex = 10;
            this.cboRole.SelectedIndexChanged += new System.EventHandler(this.cboRole_SelectedIndexChanged);
            // 
            // lblRoleTitle
            // 
            this.lblRoleTitle.AutoSize = true;
            this.lblRoleTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblRoleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblRoleTitle.Location = new System.Drawing.Point(18, 325);
            this.lblRoleTitle.Name = "lblRoleTitle";
            this.lblRoleTitle.Size = new System.Drawing.Size(126, 20);
            this.lblRoleTitle.TabIndex = 9;
            this.lblRoleTitle.Text = "Vai trò hệ thống:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Location = new System.Drawing.Point(18, 280);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.Size = new System.Drawing.Size(322, 30);
            this.txtPassword.TabIndex = 8;
            // 
            // lblPasswordTitle
            // 
            this.lblPasswordTitle.AutoSize = true;
            this.lblPasswordTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPasswordTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblPasswordTitle.Location = new System.Drawing.Point(18, 257);
            this.lblPasswordTitle.Name = "lblPasswordTitle";
            this.lblPasswordTitle.Size = new System.Drawing.Size(188, 20);
            this.lblPasswordTitle.TabIndex = 7;
            this.lblPasswordTitle.Text = "Mật khẩu (Khi tạo/đổi lại):";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Location = new System.Drawing.Point(18, 212);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(322, 30);
            this.txtEmail.TabIndex = 6;
            // 
            // lblEmailTitle
            // 
            this.lblEmailTitle.AutoSize = true;
            this.lblEmailTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmailTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblEmailTitle.Location = new System.Drawing.Point(18, 189);
            this.lblEmailTitle.Name = "lblEmailTitle";
            this.lblEmailTitle.Size = new System.Drawing.Size(127, 20);
            this.lblEmailTitle.TabIndex = 5;
            this.lblEmailTitle.Text = "Email nhân viên :";
            // 
            // txtFullName
            // 
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.Location = new System.Drawing.Point(18, 144);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(322, 30);
            this.txtFullName.TabIndex = 4;
            // 
            // lblFullNameTitle
            // 
            this.lblFullNameTitle.AutoSize = true;
            this.lblFullNameTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFullNameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblFullNameTitle.Location = new System.Drawing.Point(18, 121);
            this.lblFullNameTitle.Name = "lblFullNameTitle";
            this.lblFullNameTitle.Size = new System.Drawing.Size(133, 20);
            this.lblFullNameTitle.TabIndex = 3;
            this.lblFullNameTitle.Text = "Họ tên nhân viên:";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Location = new System.Drawing.Point(18, 76);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(322, 30);
            this.txtUsername.TabIndex = 2;
            // 
            // lblUsernameTitle
            // 
            this.lblUsernameTitle.AutoSize = true;
            this.lblUsernameTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsernameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblUsernameTitle.Location = new System.Drawing.Point(18, 53);
            this.lblUsernameTitle.Name = "lblUsernameTitle";
            this.lblUsernameTitle.Size = new System.Drawing.Size(116, 20);
            this.lblUsernameTitle.TabIndex = 1;
            this.lblUsernameTitle.Text = "Tên đăng nhập:";
            // 
            // lblCardHeader
            // 
            this.lblCardHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCardHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblCardHeader.Location = new System.Drawing.Point(18, 14);
            this.lblCardHeader.Name = "lblCardHeader";
            this.lblCardHeader.Size = new System.Drawing.Size(322, 30);
            this.lblCardHeader.TabIndex = 0;
            this.lblCardHeader.Text = "👤 THÔNG TIN & PHÂN QUYỀN";
            this.lblCardHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1074, 693);
            this.Controls.Add(this.pnlMainContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormUserManagement";
            this.Text = "QUẢN LÝ TÀI KHOẢN & PHÂN QUYỀN";
            this.Load += new System.EventHandler(this.FormUserManagement_Load);
            this.pnlMainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.pnlRightCard.ResumeLayout(false);
            this.pnlRightCard.PerformLayout();
            this.pnlQuickRole.ResumeLayout(false);
            this.pnlQuickRole.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}