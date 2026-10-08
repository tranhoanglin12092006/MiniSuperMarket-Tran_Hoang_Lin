using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormMainShell : Form
    {
        // Biến lưu trữ Form con đang được kích hoạt hiển thị trên vùng panelMainContent
        private Form? _activeForm = null;

        public FormMainShell()
        {
            InitializeComponent();
        }

        private void FormMainShell_Load(object sender, EventArgs e)
        {
            // 1. Hiển thị thông tin phiên người dùng đăng nhập lên Header
            lblUserInfo.Text = $"Nhân viên: {SessionManager.CurrentUsername} | Vai trò: [{SessionManager.CurrentRole}]";

            // 2. Kích hoạt phân quyền giao diện theo vai trò (Role-Based Access)
            ApplyRolePermissions(SessionManager.CurrentRole);

            // 3. Mở màn hình mặc định tương ứng với vai trò ngay khi vừa đăng nhập thành công
            OpenDefaultScreenByRole(SessionManager.CurrentRole);
        }

        /// <summary>
        /// Hàm nhúng động một Form con vào vùng panelMainContent (Single-Page App style)
        /// </summary>
        private void OpenChildForm(Form childForm, string screenTitle, Button senderButton)
        {
            // Nếu có form cũ đang mở, đóng nó lại để giải phóng bộ nhớ
            if (_activeForm != null)
            {
                _activeForm.Close();
            }

            // Đổi màu nút trên Sidebar để đánh dấu đang chọn
            HighlightActiveButton(senderButton);

            _activeForm = childForm;
            childForm.TopLevel = false;                         // Biến Form con thành điều khiển dạng Control nhúng
            childForm.FormBorderStyle = FormBorderStyle.None;     // Bỏ viền và thanh tiêu đề mặc định của Windows
            childForm.Dock = DockStyle.Fill;                    // Phủ đầy không gian của panel chứa

            panelMainContent.Controls.Clear();                    // Xóa màn hình cũ
            panelMainContent.Controls.Add(childForm);             // Thêm form mới vào panel
            panelMainContent.Tag = childForm;

            lblTitle.Text = screenTitle;                        // Cập nhật tiêu đề tương ứng trên Header
            childForm.BringToFront();
            childForm.Show();
        }

        /// <summary>
        /// Làm nổi bật nút menu bên Sidebar đang được chọn, các nút khác giữ màu gốc
        /// </summary>
        private void HighlightActiveButton(Button activeButton)
        {
            foreach (Control ctrl in panelSidebar.Controls)
            {
                if (ctrl is Button btn && btn != btnLogout)
                {
                    btn.BackColor = Color.FromArgb(24, 30, 48); // Màu nền mặc định của Sidebar
                }
            }
            activeButton.BackColor = Color.FromArgb(41, 100, 180); // Màu xanh dương nổi bật (Active)
        }

        /// <summary>
        /// Phân định quyền truy cập hiển thị/ẩn các nút trên Sidebar theo vai trò người dùng
        /// </summary>
        private void ApplyRolePermissions(string role)
        {
            // Kiểm tra an toàn tránh lỗi NullReferenceException nếu role trống
            if (string.IsNullOrEmpty(role))
            {
                role = string.Empty;
            }

            switch (role.ToUpper())
            {
                case "ADMIN":
                    // Quản trị viên: Toàn quyền sử dụng tất cả các chức năng
                    btnPOS.Visible = true;
                    btnCategory.Visible = true;
                    btnProduct.Visible = true;
                    btnCustomer.Visible = true;
                    btnReports.Visible = true;
                    btnUserManage.Visible = true;
                    break;

                case "CASHIER":
                    // Thu ngân: Chỉ truy cập màn hình Bán hàng (POS) và Khách hàng
                    btnPOS.Visible = true;
                    btnCustomer.Visible = true;
                    btnCategory.Visible = false;
                    btnProduct.Visible = true;
                    btnReports.Visible = false;
                    btnUserManage.Visible = false;
                    break;

                case "WAREHOUSE":
                    // Thủ kho: Chỉ quản lý Danh mục nhóm hàng và Sản phẩm tồn kho
                    btnPOS.Visible = false;
                    btnCustomer.Visible = false;
                    btnReports.Visible = false;
                    btnUserManage.Visible = false;
                    btnCategory.Visible = true;
                    btnProduct.Visible = true;
                    break;

                default:
                    // Vai trò lạ hoặc không hợp lệ: Cảnh báo và từ chối truy cập
                    MessageBox.Show("Tài khoản chưa được cấp quyền hạn hợp lệ hoặc chưa phân vai trò!", "Cảnh báo bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Tự động điều hướng vào màn hình làm việc chuyên môn mặc định dựa theo vai trò
        /// </summary>
        private void OpenDefaultScreenByRole(string role)
        {
            if (string.IsNullOrEmpty(role)) return;

            switch (role.ToUpper())
            {
                case "ADMIN":
                case "WAREHOUSE":
                    // Đổi từ FormCategoryManagement sang FormProductManagement để nó hiện sản phẩm luôn khi vừa vào
                    OpenChildForm(new FormProductManagement(), "QUẢN LÝ SẢN PHẨM & TỒN KHO", btnProduct);
                    break;
                case "CASHIER":
                    OpenChildForm(new FormCustomerManagement(), "QUẢN LÝ KHÁCH HÀNG THÂN THIẾT", btnCustomer);
                    break;
            }
        }

        // ================= SỰ KIỆN CLICK NÚT TRÊN SIDEBAR =================

        private void BtnPOS_Click(object sender, EventArgs e)
        {
            // Gọi OpenChildForm để nhúng FormPOS vào vùng hiển thị chính thay vì chỉ hiện MessageBox
            OpenChildForm(new FormPOS(), "HỆ THỐNG BÁN HÀNG POS (BARCODE)", btnPOS);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCategoryManagement(), "QUẢN LÝ DANH MỤC SẢN PHẨM", btnCategory);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCustomerManagement(), "QUẢN LÝ KHÁCH HÀNG THÂN THIẾT", btnCustomer);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất phiên làm việc hiện tại?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                // Xóa sạch thông tin phiên đăng nhập (Session)
                SessionManager.JwtToken = string.Empty;
                SessionManager.CurrentUsername = string.Empty; 
                SessionManager.CurrentRole = string.Empty;

                // Ẩn shell chính và mở lại màn hình đăng nhập
                this.Hide();
                FormLogin loginForm = new FormLogin();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            // Kiểm tra phân quyền cấp Action (Chỉ Admin mới được truy cập báo cáo tài chính)
            if (SessionManager.CurrentRole?.ToUpper() != "ADMIN")
            {
                MessageBox.Show("Bạn không có quyền xem dữ liệu tài chính của siêu thị!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Nếu là Admin thì mở Form báo cáo nhúng vào panelMainContent
            OpenChildForm(new FormQuickReport(), "BÁO CÁO DOANH THU & HIỆU SUẤT", btnReports);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            // Kiểm tra quyền: Admin hoặc Warehouse mới được vào quản lý sản phẩm
            string role = SessionManager.CurrentRole?.ToUpper() ?? string.Empty;
            if (role != "ADMIN" && role != "WAREHOUSE")
            {
                MessageBox.Show("Bạn không có quyền truy cập quản lý sản phẩm tồn kho!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Mở Form Product Management nhúng vào panel chính
            OpenChildForm(new FormProductManagement(), "QUẢN LÝ SẢN PHẨM & TỒN KHO", btnProduct);
        }

        private void btnUserManage_Click(object sender, EventArgs e)
        {
            // Kiểm tra phân quyền: Chỉ Admin mới được truy cập quản lý tài khoản nhân viên
            if (SessionManager.CurrentRole?.ToUpper() != "ADMIN")
            {
                MessageBox.Show("Chỉ có Quản trị viên (Admin) mới có quyền truy cập quản lý tài khoản!", "Từ chối truy cập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            // Mở FormUserManagement nhúng vào panel chính
            OpenChildForm(new FormUserManagement(), "QUẢN LÝ TÀI KHOẢN & PHÂN QUYỀN", btnUserManage);
        }
    }
}