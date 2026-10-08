using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCategoryManagement : Form
    {
        public FormCategoryManagement()
        {
            InitializeComponent();
        }

        private async void FormCategoryManagement_Load(object sender, EventArgs e)
        {
            CheckUserRolePermissions();
            await LoadDataAsync();
        }

        private void CheckUserRolePermissions()
        {
            if (SessionManager.CurrentRole?.Equals("Cashier", StringComparison.OrdinalIgnoreCase) == true)
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private async Task LoadDataAsync()
        {
            try
            {
                lblNotification.Text = "⏳ Đang tải danh sách nhóm hàng...";
                lblNotification.ForeColor = Color.SteelBlue;

                var categories = await ApiClientService.GetFromJsonWithAuthAsync<List<CategoryDto>>("categories");
                if (categories != null)
                {
                    dgvCategories.DataSource = null;
                    dgvCategories.DataSource = categories;
                    ConfigureGridColumns();
                    lblNotification.Text = $"✅ Đã tải thành công {categories.Count} nhóm hàng.";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                }
            }
            catch (Exception ex)
            {
                lblNotification.Text = "❌ Lỗi: " + ex.Message;
                lblNotification.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi quyền truy cập hoặc mất kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureGridColumns()
        {
            if (dgvCategories.Columns.Count == 0) return;

            if (dgvCategories.Columns["CategoryId"] != null)
            {
                dgvCategories.Columns["CategoryId"].HeaderText = "Mã ID";
                dgvCategories.Columns["CategoryId"].Width = 80;
            }
            if (dgvCategories.Columns["CategoryName"] != null)
            {
                dgvCategories.Columns["CategoryName"].HeaderText = "Tên nhóm hàng";
                dgvCategories.Columns["CategoryName"].Width = 220;
            }
            if (dgvCategories.Columns["Description"] != null)
            {
                dgvCategories.Columns["Description"].HeaderText = "Mô tả chi tiết";
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            ClearInputs();
            await LoadDataAsync();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCategories.Rows.Count)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                txtId.Text = row.Cells["CategoryId"]?.Value?.ToString() ?? string.Empty;
                txtCategoryName.Text = row.Cells["CategoryName"]?.Value?.ToString() ?? string.Empty;
                txtDescription.Text = row.Cells["Description"]?.Value?.ToString() ?? string.Empty;

                lblNotification.Text = $"Đang chọn: [{txtCategoryName.Text}]";
                lblNotification.ForeColor = Color.FromArgb(30, 41, 59);
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string catName = txtCategoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(catName))
            {
                MessageBox.Show("Tên nhóm hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            var newCat = new
            {
                CategoryName = catName,
                Description = txtDescription.Text.Trim()
            };

            try
            {
                lblNotification.Text = "⏳ Đang thêm nhóm hàng...";
                var response = await ApiClientService.PostAsJsonWithAuthAsync("categories", newCat);
                if (response.IsSuccessStatusCode)
                {
                    lblNotification.Text = "✅ Thêm nhóm hàng thành công!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show("Thêm mới danh mục thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    lblNotification.Text = "❌ Thêm thất bại!";
                    lblNotification.ForeColor = Color.Crimson;
                    MessageBox.Show("Thêm thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn một nhóm hàng từ bảng để cập nhật!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string catName = txtCategoryName.Text.Trim();
            if (string.IsNullOrWhiteSpace(catName))
            {
                MessageBox.Show("Tên nhóm hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            var updateCat = new
            {
                CategoryId = id,
                CategoryName = catName,
                Description = txtDescription.Text.Trim()
            };

            try
            {
                lblNotification.Text = "⏳ Đang cập nhật...";
                var response = await ApiClientService.PutAsJsonWithAuthAsync($"categories/{id}", updateCat);
                if (response.IsSuccessStatusCode)
                {
                    lblNotification.Text = $"✅ Cập nhật nhóm hàng [ID: {id}] thành công!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                }
                else
                {
                    var err = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Cập nhật thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id) || id <= 0)
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần xóa từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhóm hàng [{txtCategoryName.Text}]?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    lblNotification.Text = "⏳ Đang xóa nhóm hàng...";
                    var response = await ApiClientService.DeleteWithAuthAsync($"categories/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        lblNotification.Text = $"✅ Đã xóa nhóm hàng [ID: {id}] thành công!";
                        lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                        MessageBox.Show("Xóa nhóm hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        var err = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Xóa thất bại: " + err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                lblNotification.Text = $"🔍 Đang tìm kiếm '{keyword}'...";
                var searchResults = await ApiClientService.GetFromJsonWithAuthAsync<List<CategoryDto>>($"categories/search?keyword={Uri.EscapeDataString(keyword)}");
                if (searchResults != null)
                {
                    dgvCategories.DataSource = null;
                    dgvCategories.DataSource = searchResults;
                    ConfigureGridColumns();
                    lblNotification.Text = $"✅ Tìm thấy {searchResults.Count} kết quả cho '{keyword}'.";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();
            txtKeyword.Clear();
            lblNotification.Text = "Hệ thống sẵn sàng.";
            lblNotification.ForeColor = Color.FromArgb(71, 85, 105);
        }
    }

    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}