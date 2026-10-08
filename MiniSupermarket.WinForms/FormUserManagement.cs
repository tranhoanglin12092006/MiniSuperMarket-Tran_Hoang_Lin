using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormUserManagement : Form
    {
        public FormUserManagement()
        {
            InitializeComponent();
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new string[] { "Admin", "Cashier", "Warehouse" });
            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 1;
        }

        private async void FormUserManagement_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                var users = await ApiClientService.GetFromJsonWithAuthAsync<List<UserDto>>("users");
                if (users != null)
                {
                    dgvUsers.DataSource = users;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? "Cashier",
                FunctionScope = string.Empty
            };

            var res = await ApiClientService.PostAsJsonWithAuthAsync("users", newUser);
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Tạo tài khoản mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadUsersAsync();
                ClearInputs();
            }
            else
            {
                var errorContent = await res.Content.ReadAsStringAsync();
                MessageBox.Show($"Thêm tài khoản thất bại! Chi tiết: {errorContent}", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null || dgvUsers.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần đổi mật khẩu từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = (UserDto)dgvUsers.CurrentRow.DataBoundItem;
            string newPass = "123456";

            var confirm = MessageBox.Show($"Xác nhận đặt lại mật khẩu mặc định ('{newPass}') cho tài khoản [{selectedUser.Username}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var updateData = new
                {
                    FullName = selectedUser.FullName,
                    Role = selectedUser.Role,
                    FunctionScope = string.Empty,
                    Password = newPass
                };

                var res = await ApiClientService.PutAsJsonWithAuthAsync($"users/{selectedUser.Id}", updateData);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đặt lại mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var errorContent = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Đặt lại mật khẩu thất bại! Lỗi: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnToggleLock_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null || dgvUsers.CurrentRow.DataBoundItem == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần khóa/mở khóa từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = (UserDto)dgvUsers.CurrentRow.DataBoundItem;
            string actionText = selectedUser.IsActive ? "khóa" : "mở khóa";

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn {actionText} tài khoản [{selectedUser.Username}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var toggleData = new { IsActive = !selectedUser.IsActive };

                // Gọi đúng endpoint /status đã định nghĩa ở Server
                var res = await ApiClientService.PutAsJsonWithAuthAsync($"users/{selectedUser.Id}/status", toggleData);
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show($"Đã {actionText} tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                }
                else
                {
                    var errorContent = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Thao tác thất bại! Lỗi: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvUsers.Rows.Count) return;
            var row = dgvUsers.Rows[e.RowIndex];
            if (row.DataBoundItem is UserDto user)
            {
                txtUsername.Text = user.Username;
                txtFullName.Text = user.FullName;
                if (!string.IsNullOrEmpty(user.Role))
                {
                    cboRole.SelectedItem = user.Role;
                }
            }
        }

        private void ClearInputs()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtFullName.Clear();
            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 1;
        }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string FunctionScope { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}