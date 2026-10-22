/*
 * Họ tên sinh viên: Tran Hoang Lin
 * Mã sinh viên: 2124110134
 * Mô tả: Form Quản Lý Hàng Hóa kết nối Web API, hỗ trợ phân trang LINQ Eager Loading & CRUD hoàn chỉnh (Buổi 6)
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    // =========================================================================
    // CÁC DTO NHẬN DỮ LIỆU TỪ WEB API VỀ CLIENT WINFORMS
    // =========================================================================
    public class ProductItemViewDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class CategoryComboDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }

    public class PagedViewResult<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public List<T> Items { get; set; } = new();
    }

    public partial class FormProductManagement : Form
    {
        private int _currentPage = 1;
        private readonly int _pageSize = 5; // Mặc định mỗi trang 5 sản phẩm theo tài liệu Buổi 6
        private int _totalPages = 1;
        private bool _isLoading = false;

        public FormProductManagement()
        {
            InitializeComponent();
            txtSearchBarcode.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    btnSearch_Click(s, e);
                }
            };
        }

        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            await LoadCategoriesComboAsync(); // Nạp nhóm hàng vào ComboBox
            await LoadProductsPagedAsync();    // Nạp bảng sản phẩm phân trang
        }

        // =========================================================================
        // 1. TẢI DANH SÁCH NHÓM HÀNG LÊN COMBOBOX (EAGER COMBOBOX & FILTER)
        // =========================================================================
        private async Task LoadCategoriesComboAsync()
        {
            try
            {
                var categories = await ApiClientService.GetFromJsonWithAuthAsync<List<CategoryComboDto>>("categories");
                if (categories != null && categories.Count > 0)
                {
                    // ComboBox nhập liệu trong thẻ bên phải
                    cboCategory.DataSource = new List<CategoryComboDto>(categories);
                    cboCategory.DisplayMember = "CategoryName";
                    cboCategory.ValueMember = "CategoryId";

                    // ComboBox bộ lọc nhóm hàng ở thanh trên (Bài tập mở rộng 6.2)
                    var filterList = new List<CategoryComboDto>
                    {
                        new CategoryComboDto { CategoryId = 0, CategoryName = "-- Tất cả nhóm hàng --" }
                    };
                    filterList.AddRange(categories);

                    cboFilterCategory.DataSource = filterList;
                    cboFilterCategory.DisplayMember = "CategoryName";
                    cboFilterCategory.ValueMember = "CategoryId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // 2. GỌI API PHÂN TRANG VÀ HIỂN THỊ DỮ LIỆU LÊN DATAGRIDVIEW
        // =========================================================================
        private async Task LoadProductsPagedAsync()
        {
            _isLoading = true;
            try
            {
                string search = txtSearchBarcode.Text.Trim();
                int? categoryId = null;
                if (cboFilterCategory.SelectedValue != null &&
                    int.TryParse(cboFilterCategory.SelectedValue.ToString(), out int cId) && cId > 0)
                {
                    categoryId = cId;
                }

                // Xây dựng URL phân trang kết hợp tìm kiếm và lọc danh mục
                string url = $"products/paged?keyword={Uri.EscapeDataString(search)}&pageNumber={_currentPage}&pageSize={_pageSize}";
                if (categoryId.HasValue)
                {
                    url += $"&categoryId={categoryId.Value}";
                }

                lblNotification.Text = $"⏳ Đang tải trang {_currentPage}...";
                lblNotification.ForeColor = Color.SteelBlue;

                var result = await ApiClientService.GetFromJsonWithAuthAsync<PagedViewResult<ProductItemViewDto>>(url);
                if (result != null)
                {
                    _currentPage = result.CurrentPage;
                    _totalPages = result.TotalPages == 0 ? 1 : result.TotalPages;

                    // Hiển thị dữ liệu lên bảng
                    dgvProducts.DataSource = result.Items;
                    ConfigureGridHeaders();

                    // Cập nhật nhãn phân trang
                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems} SP)";

                    // Bật/tắt nút điều hướng
                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;

                    lblNotification.Text = $"✅ Đã tải trang {_currentPage}/{_totalPages} (Tổng {result.TotalItems} sản phẩm).";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                }
            }
            catch (Exception ex)
            {
                lblNotification.Text = "❌ Lỗi: " + ex.Message;
                lblNotification.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi lấy dữ liệu sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
            }
        }

        private void ConfigureGridHeaders()
        {
            if (dgvProducts.Columns.Count == 0) return;

            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            void SetHeader(string propName, string text, int width, DataGridViewAutoSizeColumnMode autoMode = DataGridViewAutoSizeColumnMode.NotSet, DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft, string? format = null)
            {
                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    if (col.DataPropertyName.Equals(propName, StringComparison.OrdinalIgnoreCase) ||
                        col.Name.Equals(propName, StringComparison.OrdinalIgnoreCase))
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
                        return;
                    }
                }
            }

            SetHeader("ProductId", "Mã SP", 85, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
            SetHeader("Barcode", "Mã vạch", 155, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleLeft);
            SetHeader("ProductName", "Tên sản phẩm", 240, DataGridViewAutoSizeColumnMode.Fill, DataGridViewContentAlignment.MiddleLeft);
            SetHeader("Price", "Đơn giá (VNĐ)", 135, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleRight, "N0");
            SetHeader("StockQuantity", "Tồn kho", 95, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter, "N0");
            SetHeader("CategoryName", "Nhóm hàng", 175, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleLeft);
            SetHeader("CategoryId", "Mã nhóm", 85, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
        }

        // =========================================================================
        // 3. SỰ KIỆN CHUYỂN TRANG
        // =========================================================================
        private async void btnPrev_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                await LoadProductsPagedAsync();
            }
        }

        private async void btnNext_Click(object? sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                await LoadProductsPagedAsync();
            }
        }

        // =========================================================================
        // 4. SỰ KIỆN TÌM KIẾM VÀ LỌC DANH MỤC
        // =========================================================================
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            _currentPage = 1; // Khi tìm kiếm từ khóa mới, luôn quay về trang 1
            await LoadProductsPagedAsync();
        }

        private async void cboFilterCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!_isLoading)
            {
                _currentPage = 1; // Khi đổi nhóm hàng, luôn quay về trang 1
                await LoadProductsPagedAsync();
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtSearchBarcode.Clear();
            if (cboFilterCategory.Items.Count > 0)
            {
                cboFilterCategory.SelectedIndex = 0;
            }
            _currentPage = 1;
            await LoadProductsPagedAsync();
        }

        // =========================================================================
        // 5. CHỌN SẢN PHẨM TỪ BẢNG ĐỂ HIỂN THỊ LÊN FORM
        // =========================================================================
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (_isLoading) return;
            if (e.RowIndex < 0 || e.RowIndex >= dgvProducts.Rows.Count) return;

            var row = dgvProducts.Rows[e.RowIndex];
            if (row == null || row.IsNewRow || row.DataBoundItem == null) return;

            if (row.DataBoundItem is ProductItemViewDto item)
            {
                txtId.Text = item.ProductId.ToString();
                txtBarcode.Text = item.Barcode;
                txtProductName.Text = item.ProductName;

                if (item.Price > nudPrice.Maximum) nudPrice.Maximum = item.Price;
                nudPrice.Value = Math.Max(nudPrice.Minimum, item.Price);

                if (item.StockQuantity > nudStock.Maximum) nudStock.Maximum = item.StockQuantity;
                nudStock.Value = Math.Max(nudStock.Minimum, item.StockQuantity);

                cboCategory.SelectedValue = item.CategoryId;

                lblNotification.Text = $"Đang chọn: [{item.ProductName}] - Barcode: [{item.Barcode}]";
                lblNotification.ForeColor = Color.FromArgb(30, 41, 59);
            }
        }

        // =========================================================================
        // 6. THÊM MỚI SẢN PHẨM QUA API
        // =========================================================================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string barcode = txtBarcode.Text.Trim();
            string prodName = txtProductName.Text.Trim();

            if (string.IsNullOrWhiteSpace(barcode) || string.IsNullOrWhiteSpace(prodName))
            {
                MessageBox.Show("Mã vạch và Tên sản phẩm không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcode.Focus();
                return;
            }

            int categoryId = 0;
            if (cboCategory.SelectedValue != null)
            {
                int.TryParse(cboCategory.SelectedValue.ToString(), out categoryId);
            }

            if (categoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn một Nhóm hàng hóa hợp lệ cho sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return;
            }

            var newProd = new
            {
                Barcode = barcode,
                ProductName = prodName,
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                CategoryId = categoryId
            };

            try
            {
                lblNotification.Text = "⏳ Đang thêm sản phẩm...";
                var res = await ApiClientService.PostAsJsonWithAuthAsync("products", newProd);
                if (res.IsSuccessStatusCode)
                {
                    lblNotification.Text = $"✅ Thêm sản phẩm [{prodName}] thành công!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsPagedAsync();
                    ClearInputs();
                }
                else
                {
                    var errorContent = await res.Content.ReadAsStringAsync();
                    lblNotification.Text = "❌ Thêm sản phẩm thất bại!";
                    lblNotification.ForeColor = Color.Crimson;
                    MessageBox.Show($"Thêm sản phẩm thất bại! Lỗi: {errorContent}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // 7. CẬP NHẬT SẢN PHẨM QUA API
        // =========================================================================
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần cập nhật từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);
            int categoryId = 0;
            if (cboCategory.SelectedValue != null)
            {
                int.TryParse(cboCategory.SelectedValue.ToString(), out categoryId);
            }

            if (categoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn một Nhóm hàng hóa hợp lệ cho sản phẩm!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return;
            }

            var updateProd = new
            {
                ProductId = id,
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                CategoryId = categoryId
            };

            try
            {
                lblNotification.Text = "⏳ Đang cập nhật sản phẩm...";
                var res = await ApiClientService.PutAsJsonWithAuthAsync($"products/{id}", updateProd);
                if (res.IsSuccessStatusCode)
                {
                    lblNotification.Text = $"✅ Cập nhật sản phẩm [{txtProductName.Text}] thành công!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsPagedAsync();
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

        // =========================================================================
        // 8. XÓA SẢN PHẨM QUA API
        // =========================================================================
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);

            if (MessageBox.Show($"Bạn có chắc chắn muốn xóa sản phẩm #{id} [{txtProductName.Text}]?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    lblNotification.Text = "⏳ Đang xóa sản phẩm...";
                    var res = await ApiClientService.DeleteWithAuthAsync($"products/{id}");
                    if (res.IsSuccessStatusCode)
                    {
                        lblNotification.Text = $"✅ Đã xóa sản phẩm [ID: {id}] thành công!";
                        lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                        MessageBox.Show("Đã xóa sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadProductsPagedAsync();
                        ClearInputs();
                    }
                    else
                    {
                        var errorContent = await res.Content.ReadAsStringAsync();
                        MessageBox.Show($"Xóa sản phẩm thất bại! Lỗi: {errorContent}", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtId.Clear();
            txtBarcode.Clear();
            txtProductName.Clear();
            nudPrice.Value = nudPrice.Minimum;
            nudStock.Value = nudStock.Minimum;
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
            lblNotification.Text = "Hệ thống sẵn sàng.";
            lblNotification.ForeColor = Color.FromArgb(71, 85, 105);
        }
    }
}
