using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCustomerManagement : Form
    {
        private const string endpoint = "customers";
        private List<CustomerDto> _allCustomers = new();
        private List<CustomerDto> _displayedCustomers = new();
        private bool _isDataLoaded = false;

        public FormCustomerManagement()
        {
            InitializeComponent();
            if (cboMembershipRank.Items.Count > 0) cboMembershipRank.SelectedIndex = 0;
            if (cboFilterRank.Items.Count > 0) cboFilterRank.SelectedIndex = 0;

            pnlTopFilter.Resize += (s, e) => RepositionExportButton();

            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    btnSearch_Click(s, e);
                }
            };
        }

        private void RepositionExportButton()
        {
            if (btnExportExcel != null && btnLoad != null && pnlTopFilter != null)
            {
                int targetLeft = pnlTopFilter.ClientSize.Width - btnExportExcel.Width - 10;
                btnExportExcel.Left = Math.Max(btnLoad.Right + 8, targetLeft);
            }
        }

        private async void FormCustomerManagement_Load(object sender, EventArgs e)
        {
            RepositionExportButton();
            UI.UIStyler.StyleDataGridView(dgvCustomers);
            await LoadDataAsync();
            _isDataLoaded = true;
            RepositionExportButton();
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
                    _allCustomers = customers;
                    ApplyFilter();
                    UpdateCustomerKPIs(_allCustomers);

                    lblNotification.Text = $"✅ Đã tải thành công {_allCustomers.Count} khách hàng.";
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

        private void UpdateCustomerKPIs(List<CustomerDto> list)
        {
            int total = list.Count;
            int vipCount = list.Count(c =>
                !string.IsNullOrEmpty(c.MembershipRank) &&
                (c.MembershipRank.Contains("Vàng", StringComparison.OrdinalIgnoreCase) ||
                 c.MembershipRank.Contains("Kim cương", StringComparison.OrdinalIgnoreCase)));

            long totalPoints = list.Sum(c => (long)c.RewardPoints);
            int regularCount = total - vipCount;

            lblKpiTotalCustomers.Text = $"{total:N0} Khách";
            lblKpiVipCustomers.Text = $"{vipCount:N0} VIP";
            lblKpiTotalPoints.Text = $"{totalPoints:N0} Điểm";
            lblKpiRegularCustomers.Text = $"{regularCount:N0} Khách";
        }

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string selectedRank = cboFilterRank.SelectedItem?.ToString() ?? "-- Tất cả hạng thẻ --";

            var filtered = _allCustomers.AsEnumerable();

            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(c =>
                    (!string.IsNullOrEmpty(c.CustomerName) && c.CustomerName.ToLower().Contains(keyword)) ||
                    (!string.IsNullOrEmpty(c.PhoneNumber) && c.PhoneNumber.Contains(keyword)) ||
                    (!string.IsNullOrEmpty(c.Address) && c.Address.ToLower().Contains(keyword)));
            }

            if (!string.IsNullOrEmpty(selectedRank) && !selectedRank.StartsWith("--"))
            {
                filtered = filtered.Where(c => !string.IsNullOrEmpty(c.MembershipRank) && c.MembershipRank.Equals(selectedRank, StringComparison.OrdinalIgnoreCase));
            }

            _displayedCustomers = filtered.ToList();
            dgvCustomers.DataSource = null;
            dgvCustomers.DataSource = _displayedCustomers;
            ConfigureGridColumns();

            lblGridCount.Text = $"Tổng số: {_displayedCustomers.Count} / {_allCustomers.Count} khách hàng";
        }

        private void ConfigureGridColumns()
        {
            if (dgvCustomers.Columns.Count == 0) return;

            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            void SetCol(string propName, string text, int width, DataGridViewAutoSizeColumnMode autoMode = DataGridViewAutoSizeColumnMode.NotSet, DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft, string? format = null, bool isBold = false)
            {
                foreach (DataGridViewColumn col in dgvCustomers.Columns)
                {
                    if (col != null && ((col.DataPropertyName != null && col.DataPropertyName.Equals(propName, StringComparison.OrdinalIgnoreCase)) ||
                        (col.Name != null && col.Name.Equals(propName, StringComparison.OrdinalIgnoreCase))))
                    {
                        col.HeaderText = text;
                        col.MinimumWidth = width;
                        col.Width = width;
                        col.AutoSizeMode = autoMode;
                        col.DefaultCellStyle.Alignment = align;
                        if (!string.IsNullOrEmpty(format))
                        {
                            col.DefaultCellStyle.Format = format;
                        }
                        if (isBold)
                        {
                            col.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                        }
                        return;
                    }
                }
            }

            SetCol("CustomerId", "Mã KH", 85, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
            SetCol("CustomerName", "Họ và tên khách hàng", 190, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleLeft, null, true);
            SetCol("PhoneNumber", "Số điện thoại", 130, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
            SetCol("MembershipRank", "Hạng thẻ", 125, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
            SetCol("RewardPoints", "Điểm tích lũy", 120, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleRight, "N0");
            SetCol("Address", "Địa chỉ liên hệ", 200, DataGridViewAutoSizeColumnMode.Fill, DataGridViewContentAlignment.MiddleLeft);
        }

        private void dgvCustomers_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvCustomers.Rows.Count || e.CellStyle == null) return;

            string colName = dgvCustomers.Columns[e.ColumnIndex].Name;

            if (colName == "MembershipRank" && e.Value != null)
            {
                string rank = e.Value.ToString() ?? "";
                if (rank.Contains("Kim cương", StringComparison.OrdinalIgnoreCase))
                {
                    e.Value = "💎 Kim cương";
                    e.CellStyle.ForeColor = Color.FromArgb(124, 58, 237); // Purple
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (rank.Contains("Vàng", StringComparison.OrdinalIgnoreCase))
                {
                    e.Value = "🥇 Vàng";
                    e.CellStyle.ForeColor = Color.FromArgb(217, 119, 6); // Amber
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else if (rank.Contains("Bạc", StringComparison.OrdinalIgnoreCase))
                {
                    e.Value = "🥈 Bạc";
                    e.CellStyle.ForeColor = Color.FromArgb(71, 85, 105); // Slate
                    e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
                else
                {
                    e.Value = "🥉 Chuẩn";
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74); // Green
                }
            }
        }

        private async void btnLoad_Click(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            cboFilterRank.SelectedIndex = 0;
            ClearInputs();
            await LoadDataAsync();
        }

        private void cboFilterRank_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!_isDataLoaded) return;
            ApplyFilter();
        }

        private void dgvCustomers_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCustomers.Rows.Count)
            {
                DataGridViewRow row = dgvCustomers.Rows[e.RowIndex];
                txtCustomerId.Text = row.Cells["CustomerId"]?.Value?.ToString() ?? string.Empty;
                txtCustomerName.Text = row.Cells["CustomerName"]?.Value?.ToString() ?? string.Empty;
                txtPhoneNumber.Text = row.Cells["PhoneNumber"]?.Value?.ToString() ?? string.Empty;
                txtAddress.Text = row.Cells["Address"]?.Value?.ToString() ?? string.Empty;

                string rank = row.Cells["MembershipRank"]?.Value?.ToString() ?? "Chuẩn";
                if (rank.Contains("Kim cương")) cboMembershipRank.SelectedItem = "Kim cương";
                else if (rank.Contains("Vàng")) cboMembershipRank.SelectedItem = "Vàng";
                else if (rank.Contains("Bạc")) cboMembershipRank.SelectedItem = "Bạc";
                else cboMembershipRank.SelectedItem = "Chuẩn";

                if (decimal.TryParse(row.Cells["RewardPoints"]?.Value?.ToString(), out decimal pts))
                {
                    nudRewardPoints.Value = Math.Max(0, pts);
                }
                else
                {
                    nudRewardPoints.Value = 0;
                }

                lblNotification.Text = $"Đang chọn: [{txtCustomerName.Text}] - ĐT: [{txtPhoneNumber.Text}]";
                lblNotification.ForeColor = Color.FromArgb(16, 42, 33);
            }
        }

        private async void btnAdd_Click(object? sender, EventArgs e)
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

        private async void btnUpdate_Click(object? sender, EventArgs e)
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

        private async void btnDelete_Click(object? sender, EventArgs e)
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

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void btnExportExcel_Click(object? sender, EventArgs e)
        {
            if (_displayedCustomers == null || _displayedCustomers.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu khách hàng để xuất Excel!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using var sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx|CSV File (*.csv)|*.csv",
                FileName = $"Danh_Sach_Khach_Hang_{DateTime.Now:yyyyMMdd_HHmm}.xlsx",
                Title = "Xuất danh sách khách hàng thân thiết"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExcelExportHelper.ExportCustomers(_displayedCustomers, sfd.FileName);
                    lblNotification.Text = $"✅ Đã xuất {_displayedCustomers.Count} khách hàng ra file Excel!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show($"Xuất danh sách {_displayedCustomers.Count} khách hàng ra file thành công!\n\nĐường dẫn:\n{sfd.FileName}", "Xuất dữ liệu thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            lblNotification.Text = "● Hệ thống sẵn sàng.";
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
