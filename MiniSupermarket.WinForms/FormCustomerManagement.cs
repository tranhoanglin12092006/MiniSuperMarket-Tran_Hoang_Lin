using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCustomerManagement : Form
    {
        private const string endpoint = "customers";

        public FormCustomerManagement()
        {
            InitializeComponent();
            if (cboMembershipRank.Items.Count > 0) cboMembershipRank.SelectedIndex = 0;
        }

        private async void FormCustomerManagement_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                lblNotification.Text = "⏳ Đang tải danh sách khách hàng...";
                lblNotification.ForeColor = Color.SteelBlue;

                var customers = await ApiClientService.GetFromJsonWithAuthAsync<List<CustomerDto>>(endpoint);
                if (customers != null)
                {
                    dgvCustomers.DataSource = null;
                    dgvCustomers.DataSource = customers;
                    ConfigureGridColumns();
                    lblNotification.Text = $"✅ Đã tải thành công {customers.Count} khách hàng.";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                }
            }
            catch (Exception ex)
            {
                lblNotification.Text = "❌ Lỗi: " + ex.Message;
                lblNotification.ForeColor = Color.Crimson;
                MessageBox.Show($"Lỗi tải dữ liệu khách hàng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGridColumns()
        {
            if (dgvCustomers.Columns.Count == 0) return;

            if (dgvCustomers.Columns["CustomerId"] != null)
            {
                dgvCustomers.Columns["CustomerId"].HeaderText = "Mã KH";
                dgvCustomers.Columns["CustomerId"].Width = 70;
            }
            if (dgvCustomers.Columns["CustomerName"] != null)
            {
                dgvCustomers.Columns["CustomerName"].HeaderText = "Họ và tên";
                dgvCustomers.Columns["CustomerName"].Width = 160;
            }
            if (dgvCustomers.Columns["PhoneNumber"] != null)
            {
                dgvCustomers.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
                dgvCustomers.Columns["PhoneNumber"].Width = 120;
            }
            if (dgvCustomers.Columns["MembershipRank"] != null)
            {
                dgvCustomers.Columns["MembershipRank"].HeaderText = "Hạng thẻ";
                dgvCustomers.Columns["MembershipRank"].Width = 100;
            }
            if (dgvCustomers.Columns["RewardPoints"] != null)
            {
                dgvCustomers.Columns["RewardPoints"].HeaderText = "Điểm tích lũy";
                dgvCustomers.Columns["RewardPoints"].Width = 110;
            }
            if (dgvCustomers.Columns["Address"] != null)
            {
                dgvCustomers.Columns["Address"].HeaderText = "Địa chỉ liên hệ";
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            ClearInputs();
            await LoadDataAsync();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCustomers.Rows.Count)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerId.Text = row.Cells["CustomerId"]?.Value?.ToString() ?? string.Empty;
                txtCustomerName.Text = row.Cells["CustomerName"]?.Value?.ToString() ?? string.Empty;
                txtPhoneNumber.Text = row.Cells["PhoneNumber"]?.Value?.ToString() ?? string.Empty;
                txtAddress.Text = row.Cells["Address"]?.Value?.ToString() ?? string.Empty;

                string rank = row.Cells["MembershipRank"]?.Value?.ToString() ?? "Chuẩn";
                cboMembershipRank.SelectedItem = rank;

                if (decimal.TryParse(row.Cells["RewardPoints"]?.Value?.ToString(), out decimal pts))
                {
                    nudRewardPoints.Value = Math.Max(0, pts);
                }
                else
                {
                    nudRewardPoints.Value = 0;
                }

                lblNotification.Text = $"Đang chọn: [{txtCustomerName.Text}] - ĐT: [{txtPhoneNumber.Text}]";
                lblNotification.ForeColor = Color.FromArgb(30, 41, 59);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtCustomerName.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tên khách hàng và Số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return;
            }

            var newCustomer = new CustomerDto
            {
                CustomerName = name,
                PhoneNumber = phone,
                Address = txtAddress.Text.Trim(),
                RewardPoints = (int)nudRewardPoints.Value,
                MembershipRank = cboMembershipRank.SelectedItem?.ToString() ?? "Chuẩn"
            };

            try
            {
                lblNotification.Text = "⏳ Đang thêm khách hàng...";
                var response = await ApiClientService.PostAsJsonWithAuthAsync(endpoint, newCustomer);
                if (response.IsSuccessStatusCode)
                {
                    lblNotification.Text = $"✅ Thêm khách hàng [{name}] thành công!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    lblNotification.Text = "❌ Thêm khách hàng thất bại!";
                    lblNotification.ForeColor = Color.Crimson;
                    MessageBox.Show($"Thêm thất bại: {errorMsg}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string name = txtCustomerName.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Vui lòng nhập Tên khách hàng và Số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updateCustomer = new CustomerDto
            {
                CustomerId = id,
                CustomerName = name,
                PhoneNumber = phone,
                Address = txtAddress.Text.Trim(),
                RewardPoints = (int)nudRewardPoints.Value,
                MembershipRank = cboMembershipRank.SelectedItem?.ToString() ?? "Chuẩn"
            };

            try
            {
                lblNotification.Text = "⏳ Đang cập nhật...";
                var response = await ApiClientService.PutAsJsonWithAuthAsync($"{endpoint}/{id}", updateCustomer);
                if (response.IsSuccessStatusCode)
                {
                    lblNotification.Text = $"✅ Cập nhật khách hàng [{name}] thành công!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show("Cập nhật thông tin khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Cập nhật thất bại: {errorMsg}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng [{txtCustomerName.Text}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    lblNotification.Text = "⏳ Đang xóa khách hàng...";
                    var response = await ApiClientService.DeleteWithAuthAsync($"{endpoint}/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        lblNotification.Text = $"✅ Đã xóa khách hàng [ID: {id}] thành công!";
                        lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        string errorMsg = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Xóa thất bại: {errorMsg}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi kết nối API: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                lblNotification.Text = $"🔍 Đang tìm kiếm '{keyword}'...";
                var searchResults = await ApiClientService.GetFromJsonWithAuthAsync<List<CustomerDto>>($"{endpoint}/search?keyword={Uri.EscapeDataString(keyword)}");
                if (searchResults != null)
                {
                    dgvCustomers.DataSource = null;
                    dgvCustomers.DataSource = searchResults;
                    ConfigureGridColumns();
                    lblNotification.Text = $"✅ Tìm thấy {searchResults.Count} kết quả cho '{keyword}'.";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            nudRewardPoints.Value = 0;
            if (cboMembershipRank.Items.Count > 0) cboMembershipRank.SelectedIndex = 0;
            txtSearch.Clear();
            lblNotification.Text = "Hệ thống sẵn sàng.";
            lblNotification.ForeColor = Color.FromArgb(71, 85, 105);
        }
    }

    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Address { get; set; }
        public int RewardPoints { get; set; }
        public string? MembershipRank { get; set; }
    }
}