using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormUserManagement : Form
    {
        private bool _isBindingUser = false;
        private List<UserDto> _allUsers = new();

        public FormUserManagement()
        {
            InitializeComponent();
            InitRoleComboBox();

            txtSearchUser.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    btnSearch_Click(s, e);
                }
            };
            btnSearch.Click += btnSearch_Click;
            btnLoad.Click += btnLoad_Click;
            cboFilterRole.SelectedIndexChanged += cboFilterRole_SelectedIndexChanged;
        }

        private void InitRoleComboBox()
        {
            cboRole.Items.Clear();
            cboRole.Items.AddRange(new string[] { "Admin", "Cashier", "Warehouse" });
            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 1;

            if (cboFilterRole.Items.Count > 0) cboFilterRole.SelectedIndex = 0;
        }

        private async void FormUserManagement_Load(object sender, EventArgs e)
        {
            UI.UIStyler.StyleDataGridView(dgvUsers);
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                lblNotification.Text = "⏳ Đang tải danh sách tài khoản...";
                lblNotification.ForeColor = Color.SteelBlue;

                var users = await ApiClientService.GetFromJsonWithAuthAsync<List<UserDto>>("users");
                if (users != null)
                {
                    _allUsers = users;
                    ApplyFilter();
                    UpdateUserKPIs(users);

                    lblNotification.Text = $"✅ Đã tải thành công {users.Count} tài khoản.";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                }
            }
            catch (Exception ex)
            {
                lblNotification.Text = "❌ Lỗi: " + ex.Message;
                lblNotification.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi lấy danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUserKPIs(List<UserDto> users)
        {
            int total = users.Count;
            int adminCount = users.Count(u => u.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase));
            int staffCount = users.Count(u => !u.Role.Equals("Admin", StringComparison.OrdinalIgnoreCase));
            int activeCount = users.Count(u => u.IsActive);

            lblKpiTotalUsers.Text = $"{total} User";
            lblKpiAdminUsers.Text = $"{adminCount} Admin";
            lblKpiCashierUsers.Text = $"{staffCount} Nhân sự";

            int percentActive = total > 0 ? (int)((double)activeCount / total * 100) : 100;
            lblKpiActiveUsers.Text = $"{percentActive}%";
        }

        private void ApplyFilter()
        {
            string keyword = txtSearchUser.Text.Trim().ToLower();
            string selectedRole = cboFilterRole.SelectedItem?.ToString() ?? "-- Tất cả vai trò --";

            var filtered = _allUsers.AsEnumerable();

            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(u =>
                    (!string.IsNullOrEmpty(u.Username) && u.Username.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(u.FullName) && u.FullName.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(u.Email) && u.Email.ToLower().Contains(keyword)));
            }

            if (!string.IsNullOrEmpty(selectedRole) && !selectedRole.StartsWith("--"))
            {
                filtered = filtered.Where(u => u.Role.Equals(selectedRole, StringComparison.OrdinalIgnoreCase));
            }

            var list = filtered.ToList();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = list;
            ConfigureGridColumns();

            lblGridCount.Text = $"Tổng số: {list.Count} / {_allUsers.Count} tài khoản";
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            ApplyFilter();
        }

        private async void btnLoad_Click(object? sender, EventArgs e)
        {
            txtSearchUser.Clear();
            cboFilterRole.SelectedIndex = 0;
            ClearInputs();
            await LoadUsersAsync();
        }

        private void cboFilterRole_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ConfigureGridColumns()
        {
            if (dgvUsers.Columns.Count == 0) return;

            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            void SetCol(string propName, string text, int width, DataGridViewAutoSizeColumnMode autoMode = DataGridViewAutoSizeColumnMode.NotSet, DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft, bool isBold = false, bool isVisible = true)
            {
                foreach (DataGridViewColumn col in dgvUsers.Columns)
                {
                    if (col != null && ((col.DataPropertyName != null && col.DataPropertyName.Equals(propName, StringComparison.OrdinalIgnoreCase)) ||
                        (col.Name != null && col.Name.Equals(propName, StringComparison.OrdinalIgnoreCase))))
                    {
                        col.Visible = isVisible;
                        if (!isVisible) return;
                        col.HeaderText = text;
                        col.MinimumWidth = width;
                        col.Width = width;
                        col.AutoSizeMode = autoMode;
                        col.DefaultCellStyle.Alignment = align;
                        if (isBold)
                        {
                            col.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        }
                        return;
                    }
                }
            }

            SetCol("Id", "Mã ID", 80, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
            SetCol("UserId", "", 0, DataGridViewAutoSizeColumnMode.NotSet, DataGridViewContentAlignment.MiddleLeft, false, false);
            SetCol("Username", "Tên đăng nhập", 140, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleLeft, true);
            SetCol("FullName", "Họ và tên nhân viên", 180, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleLeft);
            SetCol("Email", "Email", 200, DataGridViewAutoSizeColumnMode.Fill, DataGridViewContentAlignment.MiddleLeft);
            SetCol("Role", "Vai trò", 110, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
            SetCol("FunctionScope", "", 0, DataGridViewAutoSizeColumnMode.NotSet, DataGridViewContentAlignment.MiddleLeft, false, false);
            SetCol("IsActive", "", 0, DataGridViewAutoSizeColumnMode.NotSet, DataGridViewContentAlignment.MiddleLeft, false, false);
            SetCol("TrạngThái", "Trạng thái", 120, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
        }

        private UserDto? GetSelectedUser()
        {
            if (dgvUsers.CurrentRow == null || dgvUsers.CurrentRow.DataBoundItem == null)
            {
                return null;
            }
            return dgvUsers.CurrentRow.DataBoundItem as UserDto;
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvUsers.Rows.Count) return;
            var user = GetSelectedUser();
            if (user != null)
            {
                _isBindingUser = true;
                txtUsername.Text = user.Username;
                txtFullName.Text = user.FullName;
                txtEmail.Text = user.Email;
                txtPassword.Clear();

                if (!string.IsNullOrEmpty(user.Role))
                {
                    cboRole.SelectedItem = user.Role;
                }

                // Cập nhật nút Khóa / Mở khóa
                if (user.IsActive)
                {
                    btnToggleLock.Text = "🔒 Khóa tài khoản";
                    btnToggleLock.BackColor = Color.FromArgb(220, 38, 38);
                }
                else
                {
                    btnToggleLock.Text = "🔓 Mở khóa tài khoản";
                    btnToggleLock.BackColor = Color.FromArgb(16, 185, 129);
                }

                lblNotification.Text = $"Đã chọn: [{user.Username}] - Vai trò: [{user.Role}]";
                lblNotification.ForeColor = Color.FromArgb(16, 42, 33);
                _isBindingUser = false;
            }
        }

        /// <summary>
        /// THAY ĐỔI VAI TRÒ VÀ TỰ ĐỘNG CẬP NHẬT NGAY LẬP TỨC VÀO CƠ SỞ DỮ LIỆU
        /// </summary>
        private async Task ChangeRoleImmediatelyAsync(string targetRole)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản từ danh sách trước khi đổi vai trò!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedUser.Role.Equals(targetRole, StringComparison.OrdinalIgnoreCase))
            {
                lblNotification.Text = $"ℹ️ Tài khoản [{selectedUser.Username}] đã mang vai trò [{targetRole}].";
                lblNotification.ForeColor = Color.FromArgb(71, 85, 105);
                return;
            }

            try
            {
                lblNotification.Text = $"⏳ Đang cập nhật vai trò sang [{targetRole}]...";
                lblNotification.ForeColor = Color.SteelBlue;

                var roleData = new { Role = targetRole };
                var res = await ApiClientService.PutAsJsonWithAuthAsync($"users/{selectedUser.Id}/role", roleData);

                if (res.IsSuccessStatusCode)
                {
                    selectedUser.Role = targetRole;
                    _isBindingUser = true;
                    cboRole.SelectedItem = targetRole;
                    _isBindingUser = false;

                    lblNotification.Text = $"✅ Đã chuyển vai trò tài khoản [{selectedUser.Username}] sang [{targetRole}] thành công!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);

                    await LoadUsersAsync();
                }
                else
                {
                    var errorContent = await res.Content.ReadAsStringAsync();
                    lblNotification.Text = "❌ Đổi vai trò thất bại!";
                    lblNotification.ForeColor = Color.Crimson;
                    MessageBox.Show($"Cập nhật vai trò thất bại! Chi tiết: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                lblNotification.Text = "❌ Lỗi: " + ex.Message;
                lblNotification.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi kết nối khi đổi vai trò: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRoleAdmin_Click(object sender, EventArgs e)
        {
            await ChangeRoleImmediatelyAsync("Admin");
        }

        private async void btnRoleCashier_Click(object sender, EventArgs e)
        {
            await ChangeRoleImmediatelyAsync("Cashier");
        }

        private async void btnRoleWarehouse_Click(object sender, EventArgs e)
        {
            await ChangeRoleImmediatelyAsync("Warehouse");
        }

        private async void cboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isBindingUser) return;
            var selectedUser = GetSelectedUser();
            if (selectedUser != null && cboRole.SelectedItem != null)
            {
                string newRole = cboRole.SelectedItem.ToString() ?? "";
                if (!string.IsNullOrEmpty(newRole) && !newRole.Equals(selectedUser.Role, StringComparison.OrdinalIgnoreCase))
                {
                    await ChangeRoleImmediatelyAsync(newRole);
                }
            }
        }

        private async void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string role = cboRole.SelectedItem?.ToString() ?? "Cashier";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Vui lòng nhập họ và tên nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            var newUser = new
            {
                Username = username,
                Password = password,
                FullName = fullName,
                Email = email,
                Role = role,
                FunctionScope = string.Empty
            };

            try
            {
                lblNotification.Text = "⏳ Đang tạo tài khoản...";
                var res = await ApiClientService.PostAsJsonWithAuthAsync("users", newUser);
                if (res.IsSuccessStatusCode)
                {
                    lblNotification.Text = $"✅ Đã tạo tài khoản [{username}] thành công!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show($"Tạo tài khoản [{username}] thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                    ClearInputs();
                }
                else
                {
                    var errorContent = await res.Content.ReadAsStringAsync();
                    lblNotification.Text = "❌ Thêm tài khoản thất bại!";
                    lblNotification.ForeColor = Color.Crimson;
                    MessageBox.Show($"Thêm tài khoản thất bại! Chi tiết: {errorContent}", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối khi tạo tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdateUser_Click(object sender, EventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần cập nhật từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updateData = new
            {
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Role = cboRole.SelectedItem?.ToString() ?? selectedUser.Role,
                FunctionScope = string.Empty,
                Password = string.IsNullOrWhiteSpace(txtPassword.Text) ? null : txtPassword.Text.Trim()
            };

            try
            {
                lblNotification.Text = "⏳ Đang cập nhật...";
                var res = await ApiClientService.PutAsJsonWithAuthAsync($"users/{selectedUser.Id}", updateData);
                if (res.IsSuccessStatusCode)
                {
                    lblNotification.Text = $"✅ Cập nhật thông tin tài khoản [{selectedUser.Username}] thành công!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadUsersAsync();
                }
                else
                {
                    var errorContent = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Cập nhật thất bại! Lỗi: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            var selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần đặt lại mật khẩu từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newPass = "123456";
            var confirm = MessageBox.Show($"Xác nhận đặt lại mật khẩu mặc định ('{newPass}') cho tài khoản [{selectedUser.Username}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var updateData = new
                {
                    FullName = selectedUser.FullName,
                    Email = selectedUser.Email,
                    Role = selectedUser.Role,
                    FunctionScope = string.Empty,
                    Password = newPass
                };

                var res = await ApiClientService.PutAsJsonWithAuthAsync($"users/{selectedUser.Id}", updateData);
                if (res.IsSuccessStatusCode)
                {
                    lblNotification.Text = $"✅ Đã đặt lại mật khẩu về '{newPass}' cho [{selectedUser.Username}]!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show($"Đặt lại mật khẩu thành công! Mật khẩu mới là '{newPass}'", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            var selectedUser = GetSelectedUser();
            if (selectedUser == null)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần khóa/mở khóa từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string actionText = selectedUser.IsActive ? "khóa" : "mở khóa";
            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn {actionText} tài khoản [{selectedUser.Username}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    lblNotification.Text = $"⏳ Đang {actionText} tài khoản...";
                    var toggleData = new { IsActive = !selectedUser.IsActive };
                    var res = await ApiClientService.PutAsJsonWithAuthAsync($"users/{selectedUser.Id}/status", toggleData);
                    if (res.IsSuccessStatusCode)
                    {
                        lblNotification.Text = $"✅ Đã {actionText} tài khoản [{selectedUser.Username}] thành công!";
                        lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                        MessageBox.Show($"Đã {actionText} tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadUsersAsync();
                    }
                    else
                    {
                        var errorContent = await res.Content.ReadAsStringAsync();
                        MessageBox.Show($"Thao tác thất bại! Lỗi: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void ClearInputs()
        {
            _isBindingUser = true;
            txtUsername.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            if (cboRole.Items.Count > 0) cboRole.SelectedIndex = 1;
            btnToggleLock.Text = "🔒 Khóa tài khoản";
            btnToggleLock.BackColor = Color.FromArgb(220, 38, 38);
            lblNotification.Text = "● Đã làm mới biểu mẫu.";
            lblNotification.ForeColor = Color.FromArgb(71, 85, 105);
            _isBindingUser = false;
        }
    }

    public class UserDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public int UserId 
        { 
            get => Id; 
            set { if (Id == 0) Id = value; } 
        }

        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [JsonPropertyName("fullName")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("role")]
        public string Role { get; set; } = string.Empty;

        [JsonPropertyName("functionScope")]
        public string FunctionScope { get; set; } = string.Empty;

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        public string TrạngThái => IsActive ? "🟢 Hoạt động" : "🔴 Đã khóa";
    }
}
