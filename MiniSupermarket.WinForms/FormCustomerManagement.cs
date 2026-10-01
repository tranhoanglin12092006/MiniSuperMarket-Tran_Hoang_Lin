using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MiniSupermarket.WinForms
{
    public partial class FormCustomerManagement : Form
    {
        // Khởi tạo HttpClient trỏ đến Base Address của Web API
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7167/api/")
        };

        private const string endpoint = "customers";

        public FormCustomerManagement()
        {
            InitializeComponent();
            SetupHeaderToken();
        }

        private async void FormCustomerManagement_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private void SetupHeaderToken()
        {
            if (!string.IsNullOrEmpty(SessionManager.JwtToken))
            {
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", SessionManager.JwtToken);
            }
        }

        private async Task LoadDataAsync()
        {
            try
            {
                SetupHeaderToken();
                var customers = await client.GetFromJsonAsync<List<CustomerDto>>(endpoint);
                dgvCustomers.DataSource = customers;
                ClearInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) || string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên khách hàng và Số điện thoại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var newCustomer = new CustomerDto
                {
                    CustomerName = txtCustomerName.Text.Trim(),
                    PhoneNumber = txtPhoneNumber.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    RewardPoints = int.TryParse(txtRewardPoints.Text, out var pts) ? pts : 0,
                    MembershipRank = string.IsNullOrWhiteSpace(txtMembershipRank.Text) ? "Chuẩn" : txtMembershipRank.Text.Trim()
                };

                SetupHeaderToken();
                HttpResponseMessage response = await client.PostAsJsonAsync(endpoint, newCustomer);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
                else
                {
                    string errorMsg = await response.Content.ReadAsStringAsync();
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
            if (string.IsNullOrEmpty(txtCustomerId.Text) || !int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần cập nhật từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var updatedCustomer = new CustomerDto
                {
                    CustomerId = id,
                    CustomerName = txtCustomerName.Text.Trim(),
                    PhoneNumber = txtPhoneNumber.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    RewardPoints = int.TryParse(txtRewardPoints.Text, out var pts) ? pts : 0,
                    MembershipRank = txtMembershipRank.Text.Trim()
                };

                SetupHeaderToken();
                HttpResponseMessage response = await client.PutAsJsonAsync($"{endpoint}/{id}", updatedCustomer);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrEmpty(txtCustomerId.Text) || !int.TryParse(txtCustomerId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa khách hàng có ID = {id} không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    SetupHeaderToken();
                    HttpResponseMessage response = await client.DeleteAsync($"{endpoint}/{id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
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
            if (string.IsNullOrEmpty(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                SetupHeaderToken();
                var customers = await client.GetFromJsonAsync<List<CustomerDto>>($"{endpoint}/search?keyword={Uri.EscapeDataString(keyword)}");
                dgvCustomers.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerId.Text = row.Cells["CustomerId"]?.Value?.ToString() ?? "";
                txtCustomerName.Text = row.Cells["CustomerName"]?.Value?.ToString() ?? "";
                txtPhoneNumber.Text = row.Cells["PhoneNumber"]?.Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["Address"]?.Value?.ToString() ?? "";
                txtRewardPoints.Text = row.Cells["RewardPoints"]?.Value?.ToString() ?? "0";
                txtMembershipRank.Text = row.Cells["MembershipRank"]?.Value?.ToString() ?? "";
            }
        }

        private void ClearInputs()
        {
            txtCustomerId.Clear();
            txtCustomerName.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtRewardPoints.Clear();
            txtMembershipRank.Clear();
            txtSearch.Clear();
        }
    }

    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int RewardPoints { get; set; }
        public string MembershipRank { get; set; } = string.Empty;
    }
}