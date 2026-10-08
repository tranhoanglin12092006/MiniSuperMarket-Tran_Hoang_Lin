using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormProductManagement : Form
    {
        private DataTable productDataTable = new DataTable();
        private bool isLoading = false;

        public FormProductManagement()
        {
            InitializeComponent();
            txtSearchBarcode.TextChanged += (s, e) => btnSearch_Click(s, e);
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
            await LoadCategoriesToComboAsync();
            await LoadProductsAsync();
        }

        private async Task LoadCategoriesToComboAsync()
        {
            try
            {
                var categories = await ApiClientService.GetFromJsonWithAuthAsync<List<CategoryDto>>("categories");
                if (categories != null && categories.Count > 0)
                {
                    var filterList = new List<CategoryDto>();
                    filterList.Add(new CategoryDto { CategoryId = 0, CategoryName = "-- Tất cả nhóm hàng --" });
                    filterList.AddRange(categories);

                    cboFilterCategory.DataSource = filterList;
                    cboFilterCategory.DisplayMember = "CategoryName";
                    cboFilterCategory.ValueMember = "CategoryId";

                    cboCategory.DataSource = new List<CategoryDto>(categories);
                    cboCategory.DisplayMember = "CategoryName";
                    cboCategory.ValueMember = "CategoryId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadProductsAsync()
        {
            isLoading = true;
            try
            {
                lblNotification.Text = "⏳ Đang tải danh sách sản phẩm...";
                lblNotification.ForeColor = Color.SteelBlue;

                var products = await ApiClientService.GetFromJsonWithAuthAsync<List<Dictionary<string, object>>>("products");

                productDataTable = ToDataTable(products);
                dgvProducts.DataSource = productDataTable;
                ConfigureGridHeaders();

                lblNotification.Text = $"✅ Đã tải thành công {productDataTable.Rows.Count} sản phẩm.";
                lblNotification.ForeColor = Color.FromArgb(22, 163, 74);
            }
            catch (Exception ex)
            {
                lblNotification.Text = "❌ Lỗi: " + ex.Message;
                lblNotification.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi nạp sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
            }
        }

        private void ConfigureGridHeaders()
        {
            if (dgvProducts.Columns.Count == 0) return;

            // Tắt tự động co giãn toàn bộ để các cột kích thước cố định không bị bóp méo
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            void SetHeader(string colName, string text, int width, DataGridViewAutoSizeColumnMode autoMode = DataGridViewAutoSizeColumnMode.NotSet, DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft, string? format = null)
            {
                foreach (DataGridViewColumn col in dgvProducts.Columns)
                {
                    if (col.Name.Equals(colName, StringComparison.OrdinalIgnoreCase))
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

            SetHeader("productId", "Mã SP", 75, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
            SetHeader("barcode", "Mã vạch", 135, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleLeft);
            SetHeader("productName", "Tên sản phẩm", 230, DataGridViewAutoSizeColumnMode.Fill, DataGridViewContentAlignment.MiddleLeft);
            SetHeader("price", "Đơn giá (VNĐ)", 130, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleRight, "N0");
            SetHeader("stockQuantity", "Tồn kho", 90, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter, "N0");
            SetHeader("categoryName", "Nhóm hàng", 160, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleLeft);
            SetHeader("categoryId", "Mã nhóm", 80, DataGridViewAutoSizeColumnMode.None, DataGridViewContentAlignment.MiddleCenter);
        }

        private DataTable ToDataTable(List<Dictionary<string, object>>? list)
        {
            DataTable dt = new DataTable();
            if (list == null || list.Count == 0) return dt;

            foreach (var key in list[0].Keys)
            {
                dt.Columns.Add(key);
            }

            foreach (var dict in list)
            {
                var row = dt.NewRow();
                foreach (var kvp in dict)
                {
                    row[kvp.Key] = NormalizeValue(kvp.Value);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        private static object NormalizeValue(object? value)
        {
            if (value is System.Text.Json.JsonElement je)
            {
                return je.ValueKind switch
                {
                    System.Text.Json.JsonValueKind.String => je.GetString() ?? string.Empty,
                    System.Text.Json.JsonValueKind.Number => je.TryGetInt32(out int i) ? i
                        : (je.TryGetDecimal(out decimal d) ? d : (object)je.GetDouble()),
                    System.Text.Json.JsonValueKind.True => true,
                    System.Text.Json.JsonValueKind.False => false,
                    _ => DBNull.Value
                };
            }
            return value ?? DBNull.Value;
        }

        private void btnSearch_Click(object? sender, EventArgs e)
        {
            if (productDataTable == null) return;

            string keyword = txtSearchBarcode.Text.Trim().Replace("'", "''");
            int selectedCatId = 0;
            if (cboFilterCategory.SelectedValue != null)
            {
                int.TryParse(cboFilterCategory.SelectedValue.ToString(), out selectedCatId);
            }

            string nameCol = productDataTable.Columns.Contains("ProductName") ? "ProductName" :
                             (productDataTable.Columns.Contains("productName") ? "productName" : "name");

            string barcodeCol = productDataTable.Columns.Contains("Barcode") ? "Barcode" :
                                (productDataTable.Columns.Contains("barcode") ? "barcode" : string.Empty);

            string catIdCol = productDataTable.Columns.Contains("CategoryId") ? "CategoryId" :
                              (productDataTable.Columns.Contains("categoryId") ? "categoryId" : string.Empty);

            List<string> conditions = new List<string>();

            if (!string.IsNullOrEmpty(keyword))
            {
                List<string> searchParts = new List<string>();
                if (productDataTable.Columns.Contains(nameCol))
                    searchParts.Add($"{nameCol} LIKE '%{keyword}%'");
                if (!string.IsNullOrEmpty(barcodeCol) && productDataTable.Columns.Contains(barcodeCol))
                    searchParts.Add($"{barcodeCol} LIKE '%{keyword}%'");

                if (searchParts.Count > 0)
                {
                    conditions.Add($"({string.Join(" OR ", searchParts)})");
                }
            }

            if (selectedCatId > 0 && !string.IsNullOrEmpty(catIdCol) && productDataTable.Columns.Contains(catIdCol))
            {
                conditions.Add($"{catIdCol} = {selectedCatId}");
            }

            productDataTable.DefaultView.RowFilter = conditions.Count > 0 ? string.Join(" AND ", conditions) : string.Empty;
            lblNotification.Text = $"🔍 Lọc được {productDataTable.DefaultView.Count} sản phẩm.";
            lblNotification.ForeColor = Color.FromArgb(30, 41, 59);
        }

        private void cboFilterCategory_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!isLoading)
            {
                btnSearch_Click(sender, e);
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtSearchBarcode.Clear();
            if (cboFilterCategory.Items.Count > 0) cboFilterCategory.SelectedIndex = 0;
            if (productDataTable != null) productDataTable.DefaultView.RowFilter = string.Empty;
            await LoadProductsAsync();
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (isLoading) return;
            if (e.RowIndex < 0 || e.RowIndex >= dgvProducts.Rows.Count) return;

            var row = dgvProducts.Rows[e.RowIndex];
            if (row == null || row.IsNewRow || row.DataBoundItem == null) return;

            if (row.DataBoundItem is DataRowView drv)
            {
                object? GetVal(params string[] possibleKeys)
                {
                    foreach (var key in possibleKeys)
                    {
                        if (drv.Row.Table.Columns.Contains(key))
                        {
                            var val = drv[key];
                            if (val != null && val != DBNull.Value) return val;
                        }
                    }
                    return null;
                }

                var idVal = GetVal("productId", "ProductId", "id", "Id");
                if (idVal != null) txtId.Text = idVal.ToString();

                var barcodeVal = GetVal("barcode", "Barcode");
                txtBarcode.Text = barcodeVal?.ToString() ?? string.Empty;

                var nameVal = GetVal("productName", "ProductName", "name", "Name");
                txtProductName.Text = nameVal?.ToString() ?? string.Empty;

                var priceVal = GetVal("price", "Price");
                if (priceVal != null && decimal.TryParse(priceVal.ToString(), out decimal price))
                {
                    if (price > nudPrice.Maximum) nudPrice.Maximum = price;
                    nudPrice.Value = price;
                }
                else
                {
                    nudPrice.Value = nudPrice.Minimum;
                }

                var stockVal = GetVal("stockQuantity", "StockQuantity", "stock", "Stock");
                if (stockVal != null && int.TryParse(stockVal.ToString(), out int stock))
                {
                    if (stock > nudStock.Maximum) nudStock.Maximum = stock;
                    nudStock.Value = stock;
                }
                else
                {
                    nudStock.Value = nudStock.Minimum;
                }

                try
                {
                    var catIdVal = GetVal("categoryId", "CategoryId", "catId", "CatId");
                    if (catIdVal != null && int.TryParse(catIdVal.ToString(), out int catId))
                    {
                        cboCategory.SelectedValue = catId;
                    }
                }
                catch { }

                lblNotification.Text = $"Đang chọn: [{txtProductName.Text}] - Barcode: [{txtBarcode.Text}]";
                lblNotification.ForeColor = Color.FromArgb(30, 41, 59);
            }
        }

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
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    var errorContent = await res.Content.ReadAsStringAsync();
                    lblNotification.Text = "❌ Thêm sản phẩm thất bại!";
                    lblNotification.ForeColor = Color.Crimson;
                    MessageBox.Show($"Thêm sản phẩm thất bại! Lỗi: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    await LoadProductsAsync();
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtId.Text))
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa từ bảng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtId.Text);

            if (MessageBox.Show($"Xác nhận xóa sản phẩm [{txtProductName.Text}] (ID = {id})?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                        await LoadProductsAsync();
                        ClearInputs();
                    }
                    else
                    {
                        var errorContent = await res.Content.ReadAsStringAsync();
                        MessageBox.Show($"Xóa sản phẩm thất bại! Lỗi: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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