using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormMainShell : Form
    {
        // Biến lưu trữ Form con đang được kích hoạt hiển thị trên vùng panelMainContent
        private Form? _activeForm = null;
        private Button? _currentActiveButton = null;
        private bool _isLoggingOut = false;
        private bool _isSidebarCollapsed = false;

        public FormMainShell()
        {
            InitializeComponent();
            SetupButtonHoverEffects();
        }

        private void FormMainShell_Load(object sender, EventArgs e)
        {
            // 1. Cập nhật đồng hồ thời gian thực
            UpdateClock();

            // 2. Hiển thị thông tin phiên người dùng đăng nhập lên Header
            UpdateUserProfileHeader();

            // 3. Kích hoạt phân quyền giao diện theo vai trò (Role-Based Access)
            ApplyRolePermissions(SessionManager.CurrentRole);

            // 4. Mở màn hình mặc định tương ứng với vai trò ngay khi vừa vào hệ thống
            OpenDefaultScreenByRole(SessionManager.CurrentRole);
        }

        private void SetupButtonHoverEffects()
        {
            Button[] menuButtons = { btnPOS, btnOrders, btnProduct, btnCategory, btnCustomer, btnReports, btnUserManage };
            foreach (var btn in menuButtons)
            {
                btn.MouseEnter += (s, e) =>
                {
                    if (btn != _currentActiveButton)
                    {
                        btn.BackColor = Color.FromArgb(26, 61, 49); // Sidebar hover dark green
                        btn.ForeColor = Color.White;
                    }
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn != _currentActiveButton)
                    {
                        btn.BackColor = Color.Transparent;
                        btn.ForeColor = Color.FromArgb(167, 196, 181); // Muted sage text
                    }
                };
            }
        }

        private void btnToggleSidebar_Click(object sender, EventArgs e)
        {
            _isSidebarCollapsed = !_isSidebarCollapsed;

            if (_isSidebarCollapsed)
            {
                panelSidebar.Width = 72;
                lblLogoTitle.Visible = false;
                lblLogoSub.Visible = false;
                lblSystemStatus.Visible = false;

                btnPOS.Text = "🛒";
                btnOrders.Text = "🧾";
                btnProduct.Text = "📦";
                btnCategory.Text = "📁";
                btnCustomer.Text = "👥";
                btnReports.Text = "📊";
                btnUserManage.Text = "🛡️";
                btnLogout.Text = "🚪";

                btnPOS.Padding = new Padding(0);
                btnOrders.Padding = new Padding(0);
                btnProduct.Padding = new Padding(0);
                btnCategory.Padding = new Padding(0);
                btnCustomer.Padding = new Padding(0);
                btnReports.Padding = new Padding(0);
                btnUserManage.Padding = new Padding(0);

                btnPOS.TextAlign = ContentAlignment.MiddleCenter;
                btnOrders.TextAlign = ContentAlignment.MiddleCenter;
                btnProduct.TextAlign = ContentAlignment.MiddleCenter;
                btnCategory.TextAlign = ContentAlignment.MiddleCenter;
                btnCustomer.TextAlign = ContentAlignment.MiddleCenter;
                btnReports.TextAlign = ContentAlignment.MiddleCenter;
                btnUserManage.TextAlign = ContentAlignment.MiddleCenter;
            }
            else
            {
                panelSidebar.Width = 260;
                lblLogoTitle.Visible = true;
                lblLogoSub.Visible = true;
                lblSystemStatus.Visible = true;

                btnPOS.Text = "🛒  Bán hàng (POS)";
                btnOrders.Text = "🧾  Quản lý Đơn hàng";
                btnProduct.Text = "📦  Quản lý Sản phẩm";
                btnCategory.Text = "📁  Quản lý Danh mục";
                btnCustomer.Text = "👥  Khách hàng Thân thiết";
                btnReports.Text = "📊  Báo cáo & Thống kê";
                btnUserManage.Text = "🛡️  Quản trị Tài khoản";
                btnLogout.Text = "🚪  Đăng xuất";

                var pad = new Padding(16, 0, 0, 0);
                btnPOS.Padding = pad;
                btnOrders.Padding = pad;
                btnProduct.Padding = pad;
                btnCategory.Padding = pad;
                btnCustomer.Padding = pad;
                btnReports.Padding = pad;
                btnUserManage.Padding = pad;

                btnPOS.TextAlign = ContentAlignment.MiddleLeft;
                btnOrders.TextAlign = ContentAlignment.MiddleLeft;
                btnProduct.TextAlign = ContentAlignment.MiddleLeft;
                btnCategory.TextAlign = ContentAlignment.MiddleLeft;
                btnCustomer.TextAlign = ContentAlignment.MiddleLeft;
                btnReports.TextAlign = ContentAlignment.MiddleLeft;
                btnUserManage.TextAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void UpdateClock()
        {
            lblClock.Text = "🕐 " + DateTime.Now.ToString("HH:mm:ss  |  dd/MM/yyyy");
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateUserProfileHeader()
        {
            string displayName = !string.IsNullOrWhiteSpace(SessionManager.CurrentFullName) 
                ? SessionManager.CurrentFullName 
                : (!string.IsNullOrWhiteSpace(SessionManager.CurrentUsername) ? SessionManager.CurrentUsername : "Người dùng");

            lblUserName.Text = displayName;

            string role = SessionManager.CurrentRole?.Trim().ToUpper() ?? "USER";
            switch (role)
            {
                case "ADMIN":
                    lblRoleBadge.Text = "QUẢN TRỊ VIÊN";
                    lblRoleBadge.BackColor = Color.FromArgb(239, 68, 68); // Red
                    lblRoleBadge.ForeColor = Color.White;
                    break;
                case "CASHIER":
                    lblRoleBadge.Text = "THU NGÂN (POS)";
                    lblRoleBadge.BackColor = Color.FromArgb(22, 163, 74); // Primary Green
                    lblRoleBadge.ForeColor = Color.White;
                    break;
                case "WAREHOUSE":
                    lblRoleBadge.Text = "THỦ KHO";
                    lblRoleBadge.BackColor = Color.FromArgb(245, 158, 11); // Amber
                    lblRoleBadge.ForeColor = Color.White;
                    break;
                default:
                    lblRoleBadge.Text = role;
                    lblRoleBadge.BackColor = Color.FromArgb(100, 116, 139);
                    lblRoleBadge.ForeColor = Color.White;
                    break;
            }
        }

        /// <summary>
        /// Hàm nhúng động một Form con vào vùng panelMainContent (Single-Page App style)
        /// </summary>
        private void OpenChildForm(Form childForm, string screenTitle, string breadcrumbSub, Button senderButton)
        {
            // Nếu có form cũ đang mở, đóng nó lại để giải phóng bộ nhớ
            if (_activeForm != null)
            {
                _activeForm.Close();
                _activeForm.Dispose();
            }

            // Làm nổi bật nút Sidebar được bấm
            HighlightActiveButton(senderButton);

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMainContent.Controls.Clear();
            panelMainContent.Controls.Add(childForm);
            panelMainContent.Tag = childForm;

            lblTitle.Text = screenTitle;
            lblBreadcrumb.Text = $"HỆ THỐNG QUẢN LÝ  ›  {breadcrumbSub.ToUpper()}";

            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>
        /// Đổi màu nút Sidebar đang được chọn
        /// </summary>
        private void HighlightActiveButton(Button activeButton)
        {
            Button[] menuButtons = { btnPOS, btnOrders, btnProduct, btnCategory, btnCustomer, btnReports, btnUserManage };
            foreach (var btn in menuButtons)
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.FromArgb(167, 196, 181);
                btn.Font = new Font("Segoe UI", 10f, FontStyle.Regular);
            }

            _currentActiveButton = activeButton;
            activeButton.BackColor = Color.FromArgb(22, 163, 74); // Premium Green #16A34A
            activeButton.ForeColor = Color.White;
            activeButton.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
        }

        /// <summary>
        /// Phân định quyền truy cập hiển thị/ẩn các nút trên Sidebar theo vai trò
        /// </summary>
        private void ApplyRolePermissions(string role)
        {
            if (string.IsNullOrEmpty(role)) role = string.Empty;

            switch (role.ToUpper())
            {
                case "ADMIN":
                    btnPOS.Visible = true;
                    btnOrders.Visible = true;
                    btnProduct.Visible = true;
                    btnCategory.Visible = true;
                    btnCustomer.Visible = true;
                    btnReports.Visible = true;
                    btnUserManage.Visible = true;
                    break;

                case "CASHIER":
                    btnPOS.Visible = true;
                    btnOrders.Visible = true;
                    btnProduct.Visible = true;
                    btnCustomer.Visible = true;
                    btnCategory.Visible = false;
                    btnReports.Visible = false;
                    btnUserManage.Visible = false;
                    break;

                case "WAREHOUSE":
                    btnPOS.Visible = false;
                    btnOrders.Visible = false;
                    btnCustomer.Visible = false;
                    btnReports.Visible = false;
                    btnUserManage.Visible = false;
                    btnCategory.Visible = true;
                    btnProduct.Visible = true;
                    break;

                default:
                    MessageBox.Show("Tài khoản chưa được phân vai trò hợp lệ trong hệ thống!", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Mở màn hình làm việc mặc định theo vai trò khi vừa đăng nhập
        /// </summary>
        private void OpenDefaultScreenByRole(string role)
        {
            if (string.IsNullOrEmpty(role)) return;

            switch (role.ToUpper())
            {
                case "ADMIN":
                    OpenChildForm(new FormQuickReport(), "BÁO CÁO DOANH THU & HIỆU SUẤT", "Báo cáo", btnReports);
                    break;
                case "WAREHOUSE":
                    OpenChildForm(new FormProductManagement(), "QUẢN LÝ SẢN PHẨM & TỒN KHO", "Kho hàng", btnProduct);
                    break;
                case "CASHIER":
                    OpenChildForm(new FormPOS(), "HỆ THỐNG BÁN HÀNG POS (BARCODE)", "Bán hàng", btnPOS);
                    break;
            }
        }

        // ================= SỰ KIỆN CLICK MENU =================

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormPOS(), "HỆ THỐNG BÁN HÀNG POS (BARCODE)", "Bán hàng", btnPOS);
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormOrderManagement(), "QUẢN LÝ ĐƠN HÀNG & LỊCH SỬ THANH TOÁN", "Đơn hàng", btnOrders);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            string role = SessionManager.CurrentRole?.ToUpper() ?? string.Empty;
            if (role != "ADMIN" && role != "WAREHOUSE" && role != "CASHIER")
            {
                MessageBox.Show("Bạn không có quyền truy cập quản lý sản phẩm!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string screenTitle = role == "CASHIER" ? "QUẢN LÝ SẢN PHẨM & TỒN KHO (CHẾ ĐỘ XEM)" : "QUẢN LÝ SẢN PHẨM & TỒN KHO";
            OpenChildForm(new FormProductManagement(), screenTitle, "Sản phẩm", btnProduct);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCategoryManagement(), "QUẢN LÝ DANH MỤC SẢN PHẨM", "Danh mục", btnCategory);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCustomerManagement(), "QUẢN LÝ KHÁCH HÀNG THÂN THIẾT", "Khách hàng", btnCustomer);
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentRole?.ToUpper() != "ADMIN")
            {
                MessageBox.Show("Chỉ Quản trị viên (Admin) mới có quyền truy cập báo cáo tài chính!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm(new FormQuickReport(), "BÁO CÁO DOANH THU & HIỆU SUẤT", "Báo cáo", btnReports);
        }

        private void btnUserManage_Click(object sender, EventArgs e)
        {
            if (SessionManager.CurrentRole?.ToUpper() != "ADMIN")
            {
                MessageBox.Show("Chỉ Quản trị viên (Admin) mới có quyền quản lý tài khoản nhân viên!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            OpenChildForm(new FormUserManagement(), "QUẢN TRỊ TÀI KHOẢN & PHÂN QUYỀN", "Tài khoản", btnUserManage);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất khỏi phiên làm việc hiện tại?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                _isLoggingOut = true;

                // Xóa sạch thông tin phiên làm việc
                SessionManager.JwtToken = string.Empty;
                SessionManager.CurrentUsername = string.Empty;
                SessionManager.CurrentRole = string.Empty;
                SessionManager.CurrentFullName = string.Empty;

                // Mở lại Form đăng nhập và đóng Shell
                this.Hide();
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Close();
            }
        }

        private void FormMainShell_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isLoggingOut)
            {
                // Người dùng nhấn nút X của FormMainShell -> Thoát hẳn toàn bộ ứng dụng
                Application.Exit();
            }
        }
    }
}
