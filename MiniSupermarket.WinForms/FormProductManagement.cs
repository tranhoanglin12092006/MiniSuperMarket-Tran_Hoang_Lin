/*
 * Họ tên sinh viên: Tran Hoang Lin
 * Mã sinh viên: 2124110134
 * Mô tả: Form Quản Lý Hàng Hóa kết nối Web API, hỗ trợ phân trang LINQ Eager Loading & CRUD hoàn chỉnh (Buổi 6)
 */
using MiniSupermarket.WinForms.Models;
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
        private int _pageSize = 10; // Mặc định mỗi trang 10 sản phẩm cho giao diện hiện đại
        private int _totalPages = 1;
        private bool _isLoading = false;

        public FormProductManagement()
        {
            InitializeComponent();
            pnlTopFilter.Resize += (s, e) => RepositionExportButton();
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

        private void RepositionExportButton()
        {
            if (btnExportExcel != null && btnLoad != null && pnlTopFilter != null)
            {
                int targetLeft = pnlTopFilter.ClientSize.Width - btnExportExcel.Width - 10;
                btnExportExcel.Left = Math.Max(btnLoad.Right + 8, targetLeft);
            }
        }

        private async void FormProductManagement_Load(object sender, EventArgs e)
        {
            RepositionExportButton();
            UI.UIStyler.StyleDataGridView(dgvProducts);
            cboPageSize.SelectedIndex = 0; // 10 SP/trang

            await LoadCategoriesComboAsync(); // Nạp nhóm hàng vào ComboBox
            await LoadProductsPagedAsync();   // Nạp bảng sản phẩm phân trang
            RepositionExportButton();
            await LoadInventoryKPIsAsync();   // Nạp 4 thẻ chỉ số kho hàng

            ApplyRolePermissions();
        }

        private void ApplyRolePermissions()
        {
            bool isCashier = string.Equals(SessionManager.CurrentRole, "CASHIER", StringComparison.OrdinalIgnoreCase);
            if (isCashier)
            {
                // Vô hiệu hóa các nút Thao tác dữ liệu (Thêm, Sửa, Xóa) cho vai trò Thu ngân
                btnAdd.Enabled = false;
                btnAdd.BackColor = Color.FromArgb(226, 232, 240); // Slate 200
                btnAdd.ForeColor = Color.FromArgb(148, 163, 184); // Slate 400
                btnAdd.Cursor = Cursors.No;

                btnUpdate.Enabled = false;
                btnUpdate.BackColor = Color.FromArgb(226, 232, 240);
                btnUpdate.ForeColor = Color.FromArgb(148, 163, 184);
                btnUpdate.Cursor = Cursors.No;

                btnDelete.Enabled = false;
                btnDelete.BackColor = Color.FromArgb(226, 232, 240);
                btnDelete.ForeColor = Color.FromArgb(148, 163, 184);
                btnDelete.Cursor = Cursors.No;

                // Chuyển toàn bộ các ô nhập liệu sang chế độ chỉ đọc
                txtBarcode.ReadOnly = true;
                txtProductName.ReadOnly = true;
                nudPrice.Enabled = false;
                nudStock.Enabled = false;
                cboCategory.Enabled = false;

                // Cập nhật tiêu đề thẻ và thông báo chỉ xem
                lblCardHeader.Text = "📦 THÔNG TIN SẢN PHẨM (CHẾ ĐỘ XEM)";
                lblNotification.Text = "🔒 Tài khoản Thu ngân (Cashier) đang ở chế độ xem thông tin sản phẩm.";
                lblNotification.ForeColor = Color.FromArgb(217, 119, 6); // Amber 600
            }
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

                    // ComboBox bộ lọc nhóm hàng ở thanh trên
                    var filterList = new List<CategoryComboDto>
                    {
                        new CategoryComboDto { CategoryId = 0, CategoryName = "-- Tất cả nhóm hàng --" }
                    };
                    filterList.AddRange(categories);

                    cboFilterCategory.DataSource = filterList;
                    cboFilterCategory.DisplayMember = "CategoryName";
                    cboFilterCategory.ValueMember = "CategoryId";

                    lblKpiTotalCategories.Text = $"{categories.Count} nhóm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // 2. TẢI 4 THẺ KPI CHỈ SỐ KHO HÀNG TỔNG QUAN
        // =========================================================================
        private async Task LoadInventoryKPIsAsync()
        {
            try
            {
                // 1. Lấy dữ liệu tổng quan từ API Dashboard
                var summary = await ApiClientService.GetFromJsonWithAuthAsync<DashboardSummaryDto>("reports/dashboard-summary");
                if (summary != null)
                {
                    lblKpiLowStock.Text = $"{summary.LowStockCount} SP";

                    if (summary.LowStockCount > 0)
                    {
                        panelKpiLowStock.BackColor = Color.FromArgb(254, 242, 242); // Red 50
                    }
                    else
                    {
                        panelKpiLowStock.BackColor = Color.White;
                    }
                }

                // 2. Lấy toàn bộ sản phẩm để tính tổng giá trị kho hàng
                var allResult = await ApiClientService.GetFromJsonWithAuthAsync<PagedViewResult<ProductItemViewDto>>("products/paged?pageNumber=1&pageSize=10000");
                if (allResult != null && allResult.Items != null)
                {
                    int totalProducts = allResult.TotalItems;
                    decimal totalStockValue = allResult.Items.Sum(p => p.Price * p.StockQuantity);

                    lblKpiTotalProducts.Text = $"{totalProducts:N0} SP";
                    lblKpiTotalStockValue.Text = $"{totalStockValue:N0} đ";
                }
            }
            catch
            {
                // Fallback nếu không kết nối được KPI
            }
        }

        // =========================================================================
        // 3. GỌI API PHÂN TRANG VÀ HIỂN THỊ DỮ LIỆU LÊN DATAGRIDVIEW
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
                    lblPaging.Text = $"Trang {_currentPage} / {_totalPages} (Tổng: {result.TotalItems:N0} SP)";
                    lblKpiTotalProducts.Text = $"{result.TotalItems:N0} SP";

                    // Bật/tắt nút điều hướng
                    btnPrev.Enabled = _currentPage > 1;
                    btnNext.Enabled = _currentPage < _totalPages;

                    // Item 43: Huy hiệu & Cảnh báo tồn kho thấp (<= 10)
                    int lowStockCount = result.Items.Count(p => p.StockQuantity <= 10);
                    if (lowStockCount > 0)
                    {
                        lblLowStockBadge.Text = $"⚠️ Trang này có {lowStockCount} SP tồn kho ≤ 10!";
                        lblLowStockBadge.Visible = true;
                    }
                    else
                    {
                        lblLowStockBadge.Visible = false;
                    }

                    lblNotification.Text = $"✅ Đã tải trang {_currentPage}/{_totalPages} (Tổng {result.TotalItems:N0} sản phẩm).";
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
                    if (col != null && col.DataPropertyName != null && col.DataPropertyName.Equals(propName, StringComparison.OrdinalIgnoreCase) ||
                        col?.Name != null && col.Name.Equals(propName, StringComparison.OrdinalIgnoreCase))
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

            SetHeader("ProductId", "ID", 65, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
            SetHeader("Barcode", "Mã vạch", 145, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
            SetHeader("ProductName", "Tên sản phẩm", 240, DataGridViewAutoSizeColumnMode.Fill, DataGridViewContentAlignment.MiddleLeft);
            SetHeader("Price", "Đơn giá (VNĐ)", 135, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleRight, "N0");
            SetHeader("StockQuantity", "Tồn kho", 100, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter, "N0");
            SetHeader("CategoryName", "Nhóm hàng", 160, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleLeft);
            SetHeader("CategoryId", "Mã nhóm", 90, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
        }

        // =========================================================================
        // 4. SỰ KIỆN PHÂN TRANG & THAY ĐỔI PAGE SIZE
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

        private async void cboPageSize_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isLoading) return;

            _pageSize = cboPageSize.SelectedIndex switch
            {
                1 => 20,
                2 => 50,
                _ => 10
            };

            _currentPage = 1;
            await LoadProductsPagedAsync();
        }

        // =========================================================================
        // 5. TÌM KIẾM VÀ LỌC THEO NHÓM HÀNG
        // =========================================================================
        private async void btnSearch_Click(object? sender, EventArgs e)
        {
            _currentPage = 1;
            await LoadProductsPagedAsync();
        }

        private async void cboFilterCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!_isLoading)
            {
                _currentPage = 1;
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
            await LoadInventoryKPIsAsync();
        }

        // =========================================================================
        // 6. CHỌN SẢN PHẨM TỪ BẢNG ĐỂ HIỂN THỊ LÊN FORM
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
        // 7. THÊM MỚI SẢN PHẨM QUA API
        // =========================================================================
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.Equals(SessionManager.CurrentRole, "CASHIER", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Tài khoản Thu ngân (Cashier) chỉ có quyền XEM thông tin sản phẩm, không được phép thêm mới!", "Chỉ xem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
                    await LoadInventoryKPIsAsync();
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
        // 8. CẬP NHẬT SẢN PHẨM QUA API
        // =========================================================================
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.Equals(SessionManager.CurrentRole, "CASHIER", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Tài khoản Thu ngân (Cashier) chỉ có quyền XEM thông tin sản phẩm, không được phép cập nhật!", "Chỉ xem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
                    await LoadInventoryKPIsAsync();
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
        // 9. XÓA SẢN PHẨM QUA API
        // =========================================================================
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.Equals(SessionManager.CurrentRole, "CASHIER", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Tài khoản Thu ngân (Cashier) chỉ có quyền XEM thông tin sản phẩm, không được phép xóa!", "Chỉ xem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
                        await LoadInventoryKPIsAsync();
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

            if (string.Equals(SessionManager.CurrentRole, "CASHIER", StringComparison.OrdinalIgnoreCase))
            {
                lblNotification.Text = "🔒 Tài khoản Thu ngân (Cashier) đang ở chế độ xem thông tin sản phẩm.";
                lblNotification.ForeColor = Color.FromArgb(217, 119, 6);
            }
            else
            {
                lblNotification.Text = "● Hệ thống sẵn sàng.";
                lblNotification.ForeColor = Color.FromArgb(71, 85, 105);
            }
        }

        // =========================================================================
        // =========================================================================
        // ITEM 43: HUY HIỆU & CẢNH BÁO HÀNG SẮP HẾT KHO (LOW-STOCK ALERT <= 10)
        // =========================================================================
        private void dgvProducts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvProducts.Rows.Count || e.CellStyle == null) return;
            var row = dgvProducts.Rows[e.RowIndex];
            if (row == null || row.DataBoundItem is not ProductItemViewDto item) return;

            var col = dgvProducts.Columns[e.ColumnIndex];
            if (col == null || string.IsNullOrEmpty(col.DataPropertyName)) return;

            bool isLowStock = item.StockQuantity <= 10;
            bool isOutOfStock = item.StockQuantity <= 0;

            // 1. Nếu tồn kho <= 10: Tô màu nền cảnh báo dịu mắt cho CẢ DÒNG để dễ thấy
            if (isLowStock)
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 241, 242); // Rose/Red 50 dịu mắt
                e.CellStyle.SelectionBackColor = Color.FromArgb(254, 226, 226); // Nền khi chọn dòng cảnh báo
                e.CellStyle.SelectionForeColor = Color.FromArgb(153, 27, 27);
            }

            // 2. Định dạng riêng biệt cho từng cột
            if (col.DataPropertyName.Equals("StockQuantity", StringComparison.OrdinalIgnoreCase))
            {
                if (isOutOfStock)
                {
                    // Ô HẾT HÀNG: Nền đỏ cờ nổi bật, chữ trắng đậm
                    e.CellStyle.BackColor = Color.FromArgb(239, 68, 68); // Red 500
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(185, 28, 28);
                    e.CellStyle.SelectionForeColor = Color.White;
                    e.Value = "0 (Hết)";
                    e.FormattingApplied = true;
                }
                else if (isLowStock)
                {
                    // Ô TỒN KHO THẤP (<= 10): Nền đỏ đậm hơn 1 tông rõ nét (#FECACA), chữ đỏ thẫm đậm
                    e.CellStyle.BackColor = Color.FromArgb(254, 202, 202); // Red 200 (đậm hơn tông cũ rất nhiều)
                    e.CellStyle.ForeColor = Color.FromArgb(153, 27, 27);   // Red 800
                    e.CellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    e.CellStyle.SelectionBackColor = Color.FromArgb(220, 38, 38); // Đỏ cờ khi click vào ô
                    e.CellStyle.SelectionForeColor = Color.White;
                }
                else
                {
                    // TỒN KHO AN TOÀN (> 10): Chữ xanh lá cây thành công, đậm nét
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74); // Green 600
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                }
            }
            else if (col.DataPropertyName.Equals("Price", StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.FromArgb(37, 99, 235); // Tech Blue
                e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            }
            else if (col.DataPropertyName.Equals("ProductName", StringComparison.OrdinalIgnoreCase))
            {
                if (isLowStock)
                {
                    // Dòng cảnh báo tồn kho: Tên sản phẩm in đậm hơn cho dễ nhận diện
                    e.CellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    e.CellStyle.ForeColor = Color.FromArgb(17, 24, 39);
                }
            }
        }

        // =========================================================================
        // ITEM 48: XUẤT BÁO CÁO DANH MỤC & TỒN KHO RA EXCEL (ClosedXML)
        // =========================================================================
        private async void btnExportExcel_Click(object? sender, EventArgs e)
        {
            try
            {
                lblNotification.Text = "⏳ Đang tải toàn bộ dữ liệu để xuất file...";
                lblNotification.ForeColor = Color.SteelBlue;

                var allProducts = await ApiClientService.GetFromJsonWithAuthAsync<PagedViewResult<ProductItemViewDto>>("products/paged?pageNumber=1&pageSize=10000");
                var listToExport = allProducts?.Items ?? (dgvProducts.DataSource as List<ProductItemViewDto>) ?? new List<ProductItemViewDto>();

                if (listToExport.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu sản phẩm nào để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using var sfd = new SaveFileDialog
                {
                    Title = "Chọn vị trí lưu tệp danh mục hàng hóa",
                    Filter = "Tệp Excel (*.xlsx)|*.xlsx|Tệp CSV (*.csv)|*.csv",
                    FileName = $"DanhMucSanPham_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExcelExportHelper.ExportProducts(listToExport, sfd.FileName);
                    lblNotification.Text = $"✅ Đã xuất {listToExport.Count} sản phẩm ra file thành công!";
                    lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
                    MessageBox.Show($"Đã xuất danh mục thành công ra tệp:\n{sfd.FileName}\n\n(Tổng cộng: {listToExport.Count} mặt hàng)", "Xuất tệp thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                lblNotification.Text = "❌ Lỗi xuất file: " + ex.Message;
                lblNotification.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi khi xuất tệp Excel/CSV: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
