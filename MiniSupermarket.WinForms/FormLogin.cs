using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text;

            // Kiểm tra ràng buộc cơ bản phía Client
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "⚠️ Vui lòng nhập đầy đủ tài khoản và mật khẩu!";
                lblStatus.ForeColor = Color.Crimson;
                txtUser.Focus();
                return;
            }

            try
            {
                lblStatus.Text = "⏳ Đang kết nối máy chủ xác thực...";
                lblStatus.ForeColor = Color.FromArgb(37, 99, 235);
                btnLogin.Enabled = false;
                btnLogin.Text = "Đang kiểm tra...";

                // Gọi hàm login tập trung qua ApiClientService
                var (success, message) = await ApiClientService.LoginAsync(username, password);

                if (success)
                {
                    lblStatus.Text = "✅ Đăng nhập thành công! Đang tải hệ thống...";
                    lblStatus.ForeColor = Color.FromArgb(22, 163, 74);

                    // Mở Form giao diện chính Shell
                    FormMainShell shell = new FormMainShell();
                    this.Hide();
                    shell.Show();
                }
                else
                {
                    lblStatus.Text = $"❌ {message}";
                    lblStatus.ForeColor = Color.Crimson;
                    MessageBox.Show(message, "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPass.SelectAll();
                    txtPass.Focus();
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "❌ Không thể kết nối tới Server!";
                lblStatus.ForeColor = Color.Crimson;
                MessageBox.Show($"Lỗi kết nối máy chủ: {ex.Message}", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "ĐĂNG NHẬP VÀO HỆ THỐNG";
            }
        }

        private void chkShowPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = !chkShowPass.Checked;
        }
    }
}
