using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormProductManagement : Form
    {
        private DataTable productDataTable = new DataTable(); // Lưu DataTable gốc để lọc dữ liệu

        public FormProductManagement()
        {
            InitializeComponent();
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
                    // Thêm một mục "Tất cả" vào đầu danh mục để phục vụ việc lọc
                    var allCategory = new CategoryDto { CategoryId = 0, CategoryName = "-- Tất cả danh mục --" };
                    categories.Insert(0, allCategory);

                    cboFilterCategory.DataSource = new List<CategoryDto>(categories);
                    cboFilterCategory.DisplayMember = "CategoryName";
                    cboFilterCategory.ValueMember = "CategoryId";

                    cboCategory.DataSource = categories.FindAll(c => c.CategoryId != 0);
                    cboCategory.DisplayMember = "CategoryName";
                    cboCategory.ValueMember = "CategoryId";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isLoading = false;

        private async Task LoadProductsAsync()
        {
            isLoading = true;
            try
            {
                var products = await ApiClientService.GetFromJsonWithAuthAsync<List<Dictionary<string, object>>>("products");

                productDataTable = ToDataTable(products);
                dgvProducts.DataSource = productDataTable;

                // Gán sự kiện click nút tìm kiếm sau khi form đã sẵn sàng
                btnSearch.Click -= btnSearch_Click;
                btnSearch.Click += btnSearch_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nạp sản phẩm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isLoading = false;
            }
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

        // Chuyển JsonElement (System.Text.Json) sang kiểu dữ liệu primitives để DataTable nhận được
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

        // Hàm xử lý Tìm kiếm theo Tên / Mã vạch và Lọc theo Danh mục
        private void btnSearch_Click(object? sender, EventArgs e)
        {
            if (productDataTable == null) return;

            string keyword = txtSearchBarcode.Text.Trim().Replace("'", "''");
            int selectedCatId = 0;
            if (cboFilterCategory.SelectedValue != null)
            {
                int.TryParse(cboFilterCategory.SelectedValue.ToString(), out selectedCatId);
            }

            // Xác định tên cột tên sản phẩm và mã vạch (hỗ trợ cả chữ hoa/thường)
            string nameCol = productDataTable.Columns.Contains("ProductName") ? "ProductName" :
                             (productDataTable.Columns.Contains("productName") ? "productName" :
                             (productDataTable.Columns.Contains("Name") ? "Name" : "name"));

            string barcodeCol = productDataTable.Columns.Contains("Barcode") ? "Barcode" :
                                (productDataTable.Columns.Contains("barcode") ? "barcode" : string.Empty);

            string catIdCol = productDataTable.Columns.Contains("CategoryId") ? "CategoryId" :
                              (productDataTable.Columns.Contains("categoryId") ? "categoryId" :
                              (productDataTable.Columns.Contains("CatId") ? "CatId" : string.Empty));

            List<string> conditions = new List<string>();

            // 1. Điều kiện lọc theo từ khóa (Tên sản phẩm hoặc Mã vạch)
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

            // 2. Điều kiện lọc theo danh mục (nếu khác 0 / Tất cả)
            if (selectedCatId > 0 && !string.IsNullOrEmpty(catIdCol) && productDataTable.Columns.Contains(catIdCol))
            {
                conditions.Add($"{catIdCol} = {selectedCatId}");
            }

            // Áp dụng bộ lọc vào DataTable
            productDataTable.DefaultView.RowFilter = conditions.Count > 0 ? string.Join(" AND ", conditions) : string.Empty;
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
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            int categoryId = cboCategory.SelectedValue != null ? Convert.ToInt32(cboCategory.SelectedValue) : 0;

            var newProd = new
            {
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                CategoryId = categoryId
            };

            var res = await ApiClientService.PostAsJsonWithAuthAsync("products", newProd);
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Thêm mới sản phẩm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadProductsAsync();
                ClearInputs();
            }
            else
            {
                var errorContent = await res.Content.ReadAsStringAsync();
                MessageBox.Show($"Thêm sản phẩm thất bại! Lỗi: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            int categoryId = cboCategory.SelectedValue != null ? Convert.ToInt32(cboCategory.SelectedValue) : 0;

            var updateProd = new
            {
                ProductId = id,
                Barcode = txtBarcode.Text.Trim(),
                ProductName = txtProductName.Text.Trim(),
                Price = nudPrice.Value,
                StockQuantity = (int)nudStock.Value,
                CategoryId = categoryId
            };

            var res = await ApiClientService.PutAsJsonWithAuthAsync($"products/{id}", updateProd);
            if (res.IsSuccessStatusCode)
            {
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadProductsAsync();
            }
            else
            {
                var errorContent = await res.Content.ReadAsStringAsync();
                MessageBox.Show($"Cập nhật thất bại! Lỗi: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (MessageBox.Show($"Xác nhận xóa sản phẩm ID = {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var res = await ApiClientService.DeleteWithAuthAsync($"products/{id}");
                if (res.IsSuccessStatusCode)
                {
                    MessageBox.Show("Đã xóa sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProductsAsync();
                    ClearInputs();
                }
                else
                {
                    var errorContent = await res.Content.ReadAsStringAsync();
                    MessageBox.Show($"Xóa sản phẩm thất bại! Lỗi: {errorContent}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtBarcode.Clear();
            txtProductName.Clear();
            nudPrice.Value = nudPrice.Minimum;
            nudStock.Value = nudStock.Minimum;
            if (cboCategory.Items.Count > 0) cboCategory.SelectedIndex = 0;
        }
    }
}