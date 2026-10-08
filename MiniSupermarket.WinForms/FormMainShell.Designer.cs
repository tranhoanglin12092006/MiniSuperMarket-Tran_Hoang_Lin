namespace MiniSupermarket.WinForms
{
    partial class FormMainShell
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogoIcon;
        private System.Windows.Forms.Label lblLogoTitle;
        private System.Windows.Forms.Label lblLogoSub;
        private System.Windows.Forms.Panel panelLogoDivider;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnPOS;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUserManage;
        private System.Windows.Forms.Panel panelSidebarBottom;
        private System.Windows.Forms.Label lblSystemStatus;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelTopHeader;
        private System.Windows.Forms.Label lblBreadcrumb;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelUserCard;
        private System.Windows.Forms.Label lblUserAvatar;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblRoleBadge;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Panel panelHeaderBottomBorder;
        private System.Windows.Forms.Panel panelMainContent;
        private System.Windows.Forms.Timer timerClock;

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
            this.components = new System.ComponentModel.Container();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnUserManage = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnPOS = new System.Windows.Forms.Button();
            this.panelSidebarBottom = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblSystemStatus = new System.Windows.Forms.Label();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panelLogoDivider = new System.Windows.Forms.Panel();
            this.lblLogoSub = new System.Windows.Forms.Label();
            this.lblLogoTitle = new System.Windows.Forms.Label();
            this.lblLogoIcon = new System.Windows.Forms.Label();
            this.panelTopHeader = new System.Windows.Forms.Panel();
            this.lblClock = new System.Windows.Forms.Label();
            this.panelUserCard = new System.Windows.Forms.Panel();
            this.lblRoleBadge = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserAvatar = new System.Windows.Forms.Label();
            this.lblBreadcrumb = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelHeaderBottomBorder = new System.Windows.Forms.Panel();
            this.panelMainContent = new System.Windows.Forms.Panel();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.panelSidebar.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelSidebarBottom.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTopHeader.SuspendLayout();
            this.panelUserCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panelSidebar.Controls.Add(this.panelMenu);
            this.panelSidebar.Controls.Add(this.panelSidebarBottom);
            this.panelSidebar.Controls.Add(this.panelLogo);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(260, 768);
            this.panelSidebar.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.Controls.Add(this.btnUserManage);
            this.panelMenu.Controls.Add(this.btnReports);
            this.panelMenu.Controls.Add(this.btnCustomer);
            this.panelMenu.Controls.Add(this.btnCategory);
            this.panelMenu.Controls.Add(this.btnProduct);
            this.panelMenu.Controls.Add(this.btnPOS);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenu.Location = new System.Drawing.Point(0, 95);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Padding = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.panelMenu.Size = new System.Drawing.Size(260, 573);
            this.panelMenu.TabIndex = 2;
            // 
            // btnUserManage
            // 
            this.btnUserManage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUserManage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUserManage.FlatAppearance.BorderSize = 0;
            this.btnUserManage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManage.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnUserManage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnUserManage.Location = new System.Drawing.Point(12, 260);
            this.btnUserManage.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnUserManage.Name = "btnUserManage";
            this.btnUserManage.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnUserManage.Size = new System.Drawing.Size(236, 50);
            this.btnUserManage.TabIndex = 5;
            this.btnUserManage.Text = "🛡️  Quản trị Tài khoản";
            this.btnUserManage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManage.UseVisualStyleBackColor = true;
            this.btnUserManage.Click += new System.EventHandler(this.btnUserManage_Click);
            // 
            // btnReports
            // 
            this.btnReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnReports.Location = new System.Drawing.Point(12, 210);
            this.btnReports.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnReports.Name = "btnReports";
            this.btnReports.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnReports.Size = new System.Drawing.Size(236, 50);
            this.btnReports.TabIndex = 4;
            this.btnReports.Text = "📊  Báo cáo Doanh thu";
            this.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.UseVisualStyleBackColor = true;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.FlatAppearance.BorderSize = 0;
            this.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCustomer.Location = new System.Drawing.Point(12, 160);
            this.btnCustomer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCustomer.Size = new System.Drawing.Size(236, 50);
            this.btnCustomer.TabIndex = 3;
            this.btnCustomer.Text = "👥  Quản lý Khách hàng";
            this.btnCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // btnCategory
            // 
            this.btnCategory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCategory.FlatAppearance.BorderSize = 0;
            this.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCategory.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCategory.Location = new System.Drawing.Point(12, 110);
            this.btnCategory.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnCategory.Size = new System.Drawing.Size(236, 50);
            this.btnCategory.TabIndex = 2;
            this.btnCategory.Text = "📁  Quản lý Danh mục";
            this.btnCategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProduct.FlatAppearance.BorderSize = 0;
            this.btnProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProduct.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnProduct.Location = new System.Drawing.Point(12, 60);
            this.btnProduct.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnProduct.Size = new System.Drawing.Size(236, 50);
            this.btnProduct.TabIndex = 1;
            this.btnProduct.Text = "📦  Quản lý Sản phẩm";
            this.btnProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnPOS
            // 
            this.btnPOS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPOS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPOS.FlatAppearance.BorderSize = 0;
            this.btnPOS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPOS.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnPOS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnPOS.Location = new System.Drawing.Point(12, 10);
            this.btnPOS.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnPOS.Name = "btnPOS";
            this.btnPOS.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.btnPOS.Size = new System.Drawing.Size(236, 50);
            this.btnPOS.TabIndex = 0;
            this.btnPOS.Text = "🛒  Bán hàng (POS)";
            this.btnPOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPOS.UseVisualStyleBackColor = true;
            this.btnPOS.Click += new System.EventHandler(this.BtnPOS_Click);
            // 
            // panelSidebarBottom
            // 
            this.panelSidebarBottom.Controls.Add(this.btnLogout);
            this.panelSidebarBottom.Controls.Add(this.lblSystemStatus);
            this.panelSidebarBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSidebarBottom.Location = new System.Drawing.Point(0, 668);
            this.panelSidebarBottom.Name = "panelSidebarBottom";
            this.panelSidebarBottom.Padding = new System.Windows.Forms.Padding(12, 0, 12, 12);
            this.panelSidebarBottom.Size = new System.Drawing.Size(260, 100);
            this.panelSidebarBottom.TabIndex = 1;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(113)))), ((int)(((byte)(113)))));
            this.btnLogout.Location = new System.Drawing.Point(12, 43);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(236, 45);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "🚪  Đăng xuất";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblSystemStatus
            // 
            this.lblSystemStatus.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSystemStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.lblSystemStatus.Location = new System.Drawing.Point(12, 10);
            this.lblSystemStatus.Name = "lblSystemStatus";
            this.lblSystemStatus.Size = new System.Drawing.Size(236, 25);
            this.lblSystemStatus.TabIndex = 1;
            this.lblSystemStatus.Text = "● Máy chủ: Sẵn sàng (Online)";
            this.lblSystemStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.panelLogoDivider);
            this.panelLogo.Controls.Add(this.lblLogoSub);
            this.panelLogo.Controls.Add(this.lblLogoTitle);
            this.panelLogo.Controls.Add(this.lblLogoIcon);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(260, 95);
            this.panelLogo.TabIndex = 0;
            // 
            // panelLogoDivider
            // 
            this.panelLogoDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.panelLogoDivider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLogoDivider.Location = new System.Drawing.Point(0, 94);
            this.panelLogoDivider.Name = "panelLogoDivider";
            this.panelLogoDivider.Size = new System.Drawing.Size(260, 1);
            this.panelLogoDivider.TabIndex = 3;
            // 
            // lblLogoSub
            // 
            this.lblLogoSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblLogoSub.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.lblLogoSub.Location = new System.Drawing.Point(75, 48);
            this.lblLogoSub.Name = "lblLogoSub";
            this.lblLogoSub.Size = new System.Drawing.Size(175, 20);
            this.lblLogoSub.TabIndex = 2;
            this.lblLogoSub.Text = "Siêu Thị Mini & Bán Lẻ";
            // 
            // lblLogoTitle
            // 
            this.lblLogoTitle.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblLogoTitle.ForeColor = System.Drawing.Color.White;
            this.lblLogoTitle.Location = new System.Drawing.Point(75, 20);
            this.lblLogoTitle.Name = "lblLogoTitle";
            this.lblLogoTitle.Size = new System.Drawing.Size(175, 28);
            this.lblLogoTitle.TabIndex = 1;
            this.lblLogoTitle.Text = "MINIMART POS";
            // 
            // lblLogoIcon
            // 
            this.lblLogoIcon.Font = new System.Drawing.Font("Segoe UI Emoji", 24F);
            this.lblLogoIcon.ForeColor = System.Drawing.Color.White;
            this.lblLogoIcon.Location = new System.Drawing.Point(12, 16);
            this.lblLogoIcon.Name = "lblLogoIcon";
            this.lblLogoIcon.Size = new System.Drawing.Size(55, 55);
            this.lblLogoIcon.TabIndex = 0;
            this.lblLogoIcon.Text = "🛒";
            this.lblLogoIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTopHeader
            // 
            this.panelTopHeader.BackColor = System.Drawing.Color.White;
            this.panelTopHeader.Controls.Add(this.panelHeaderBottomBorder);
            this.panelTopHeader.Controls.Add(this.lblClock);
            this.panelTopHeader.Controls.Add(this.panelUserCard);
            this.panelTopHeader.Controls.Add(this.lblBreadcrumb);
            this.panelTopHeader.Controls.Add(this.lblTitle);
            this.panelTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopHeader.Location = new System.Drawing.Point(260, 0);
            this.panelTopHeader.Name = "panelTopHeader";
            this.panelTopHeader.Size = new System.Drawing.Size(1074, 75);
            this.panelTopHeader.TabIndex = 1;
            // 
            // lblClock
            // 
            this.lblClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClock.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblClock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblClock.Location = new System.Drawing.Point(470, 20);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(240, 35);
            this.lblClock.TabIndex = 4;
            this.lblClock.Text = "🕐 00:00:00 - 00/00/0000";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelUserCard
            // 
            this.panelUserCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelUserCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelUserCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUserCard.Controls.Add(this.lblRoleBadge);
            this.panelUserCard.Controls.Add(this.lblUserName);
            this.panelUserCard.Controls.Add(this.lblUserAvatar);
            this.panelUserCard.Location = new System.Drawing.Point(720, 12);
            this.panelUserCard.Name = "panelUserCard";
            this.panelUserCard.Size = new System.Drawing.Size(340, 50);
            this.panelUserCard.TabIndex = 3;
            // 
            // lblRoleBadge
            // 
            this.lblRoleBadge.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblRoleBadge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblRoleBadge.ForeColor = System.Drawing.Color.White;
            this.lblRoleBadge.Location = new System.Drawing.Point(52, 26);
            this.lblRoleBadge.Name = "lblRoleBadge";
            this.lblRoleBadge.Size = new System.Drawing.Size(120, 18);
            this.lblRoleBadge.TabIndex = 2;
            this.lblRoleBadge.Text = "ADMIN";
            this.lblRoleBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblUserName.Location = new System.Drawing.Point(52, 4);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(140, 21);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Nguyễn Quản Trị";
            // 
            // lblUserAvatar
            // 
            this.lblUserAvatar.Font = new System.Drawing.Font("Segoe UI Emoji", 18F);
            this.lblUserAvatar.Location = new System.Drawing.Point(4, 2);
            this.lblUserAvatar.Name = "lblUserAvatar";
            this.lblUserAvatar.Size = new System.Drawing.Size(42, 44);
            this.lblUserAvatar.TabIndex = 0;
            this.lblUserAvatar.Text = "👤";
            this.lblUserAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBreadcrumb
            // 
            this.lblBreadcrumb.AutoSize = true;
            this.lblBreadcrumb.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblBreadcrumb.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblBreadcrumb.Location = new System.Drawing.Point(24, 12);
            this.lblBreadcrumb.Name = "lblBreadcrumb";
            this.lblBreadcrumb.Size = new System.Drawing.Size(188, 19);
            this.lblBreadcrumb.TabIndex = 2;
            this.lblBreadcrumb.Text = "HỆ THỐNG QUẢN LÝ POS  › ";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTitle.Location = new System.Drawing.Point(22, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(326, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BÀN LÀM VIỆC TỔNG QUAN";
            // 
            // panelHeaderBottomBorder
            // 
            this.panelHeaderBottomBorder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.panelHeaderBottomBorder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelHeaderBottomBorder.Location = new System.Drawing.Point(0, 74);
            this.panelHeaderBottomBorder.Name = "panelHeaderBottomBorder";
            this.panelHeaderBottomBorder.Size = new System.Drawing.Size(1074, 1);
            this.panelHeaderBottomBorder.TabIndex = 5;
            // 
            // panelMainContent
            // 
            this.panelMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMainContent.Location = new System.Drawing.Point(260, 75);
            this.panelMainContent.Name = "panelMainContent";
            this.panelMainContent.Size = new System.Drawing.Size(1074, 693);
            this.panelMainContent.TabIndex = 2;
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // FormMainShell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1334, 768);
            this.Controls.Add(this.panelMainContent);
            this.Controls.Add(this.panelTopHeader);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "FormMainShell";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Bán Lẻ & Tồn Kho Siêu Thị Mini";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMainShell_FormClosing);
            this.Load += new System.EventHandler(this.FormMainShell_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelSidebarBottom.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelTopHeader.ResumeLayout(false);
            this.panelTopHeader.PerformLayout();
            this.panelUserCard.ResumeLayout(false);
            this.panelUserCard.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}