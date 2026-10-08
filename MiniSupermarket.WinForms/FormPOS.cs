using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormPOS : Form
    {
        private readonly List<CartItemDto> _cart = new();

        public FormPOS()
        {
            InitializeComponent();
            SetupCartGrid();
            SetupQuickCashButtons();
        }

        private void SetupCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductId",
                HeaderText = "Mã SP",
                Width = 70
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Barcode",
                HeaderText = "Mã vạch",
                Width = 150
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên Sản Phẩm",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPriceFormatted",
                HeaderText = "Đơn Giá",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "SL",
                Width = 55,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPriceFormatted",
                HeaderText = "Thành Tiền",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font("Segoe UI", 9.5f, FontStyle.Bold) }
            });
        }

        private void SetupQuickCashButtons()
        {
            flpQuickCash.Controls.Clear();

            var quickValues = new[] { 0m, 50000m, 100000m, 200000m, 500000m };
            var labels = new[] { "Vừa đủ", "50k", "100k", "200k", "500k" };

            for (int i = 0; i < quickValues.Length; i++)
            {
                var val = quickValues[i];
                var btn = new Button
                {
                    Text = labels[i],
                    Width = 57,
                    Height = 28,
                    Margin = new Padding(2),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(241, 245, 249),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);

                btn.Click += (s, e) =>
                {
                    if (val == 0m)
                    {
                        decimal total = _cart.Sum(x => x.TotalPrice);
                        txtCashReceived.Text = total > 0 ? total.ToString("0") : "0";
                    }
                    else
                    {
                        txtCashReceived.Text = val.ToString("0");
                    }
                };

                flpQuickCash.Controls.Add(btn);
            }
        }

        // Bắt sự kiện phím tắt toàn màn hình (F2: về ô quét, F9: thanh toán)
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                txtBarcode.Focus();
                txtBarcode.SelectAll();
                return true;
            }
            if (keyData == Keys.F9)
            {
                btnCheckout.PerformClick();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Bắt sự kiện quét mã Barcode bằng phím Enter
        private async void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtBarcode.Text))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                await ProcessAddBarcodeAsync();
            }
        }

        private async void btnAddBarcode_Click(object sender, EventArgs e)
        {
            await ProcessAddBarcodeAsync();
        }

        private async Task ProcessAddBarcodeAsync()
        {
            string barcode = txtBarcode.Text.Trim();
            if (string.IsNullOrWhiteSpace(barcode))
            {
                txtBarcode.Focus();
                return;
            }

            txtBarcode.Clear();
            await AddProductToCartByBarcodeAsync(barcode);
            txtBarcode.Focus();
        }

        // Quét barcode và thêm vào giỏ hàng
        private async Task AddProductToCartByBarcodeAsync(string barcode)
        {
            try
            {
                lblStatusMsg.Text = $"⏳ Đang tìm sản phẩm [{barcode}]...";
                lblStatusMsg.ForeColor = Color.SteelBlue;

                var product = await ApiClientService.GetFromJsonWithAuthAsync<ProductDto>($"products/barcode/{Uri.EscapeDataString(barcode)}");
                if (product == null)
                {
                    lblStatusMsg.Text = $"❌ Không tìm thấy mã vạch: {barcode}";
                    lblStatusMsg.ForeColor = Color.Crimson;
                    MessageBox.Show($"Không tìm thấy sản phẩm có mã vạch '{barcode}' trong hệ thống!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingItem = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);
                if (existingItem != null)
                {
                    if (existingItem.Quantity + 1 > product.StockQuantity && product.StockQuantity > 0)
                    {
                        MessageBox.Show($"Số lượng yêu cầu vượt quá tồn kho (Hiện có: {product.StockQuantity})!", "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    existingItem.Quantity++;
                }
                else
                {
                    _cart.Add(new CartItemDto
                    {
                        ProductId = product.ProductId,
                        Barcode = product.Barcode,
                        ProductName = product.ProductName,
                        UnitPrice = product.Price,
                        Quantity = 1
                    });
                }

                UpdateCartDisplay();
                lblStatusMsg.Text = $"✅ Đã thêm: {product.ProductName}";
                lblStatusMsg.ForeColor = Color.FromArgb(22, 163, 74);
            }
            catch (Exception ex)
            {
                lblStatusMsg.Text = "❌ Lỗi: " + ex.Message;
                lblStatusMsg.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi lấy dữ liệu sản phẩm: " + ex.Message, "Lỗi máy chủ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Bắt sự kiện tìm khách hàng
        private async void txtCustomerPhone_KeyDown(object? sender, KeyEventArgs? e)
        {
            if (e?.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(txtCustomerPhone.Text))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                await SearchCustomerAsync();
            }
        }

        private async void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            await SearchCustomerAsync();
        }

        private async Task SearchCustomerAsync()
        {
            string phone = txtCustomerPhone.Text.Trim();
            if (string.IsNullOrWhiteSpace(phone))
            {
                lblCustomerName.Text = "Khách vãng lai";
                lblCustomerRank.Text = "Hạng: Chuẩn";
                return;
            }

            try
            {
                var customer = await ApiClientService.GetFromJsonWithAuthAsync<CustomerDto>($"customers/phone/{Uri.EscapeDataString(phone)}");
                if (customer != null)
                {
                    lblCustomerName.Text = customer.CustomerName;
                    lblCustomerRank.Text = $"Hạng: {customer.MembershipRank} ({customer.RewardPoints} điểm)";
                    lblStatusMsg.Text = $"✅ Khách hàng: {customer.CustomerName}";
                    lblStatusMsg.ForeColor = Color.FromArgb(22, 163, 74);
                }
                else
                {
                    lblCustomerName.Text = "Khách mới";
                    lblCustomerRank.Text = "Hạng: Chuẩn";
                }
            }
            catch
            {
                lblCustomerName.Text = "Khách mới (chưa đăng ký)";
                lblCustomerRank.Text = "Hạng: Chuẩn";
            }
        }

        private void UpdateCartDisplay()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart;
            SetupCartGrid();

            decimal total = _cart.Sum(x => x.TotalPrice);
            lblTotalAmount.Text = $"{total:N0} đ";
            lblItemCount.Text = $"Số loại mặt hàng: {_cart.Count} | Tổng số lượng: {_cart.Sum(x => x.Quantity)}";

            CalculateChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            decimal total = _cart.Sum(x => x.TotalPrice);
            string rawCash = txtCashReceived.Text.Replace(",", "").Replace(".", "").Trim();

            if (decimal.TryParse(rawCash, out decimal cashReceived))
            {
                decimal change = cashReceived - total;
                if (change >= 0)
                {
                    lblChange.Text = $"{change:N0} đ";
                    lblChange.ForeColor = Color.FromArgb(22, 163, 74);
                    lblChange.BackColor = Color.FromArgb(240, 253, 244);
                }
                else
                {
                    lblChange.Text = $"Thiếu: {Math.Abs(change):N0} đ";
                    lblChange.ForeColor = Color.FromArgb(220, 38, 38);
                    lblChange.BackColor = Color.FromArgb(254, 242, 242);
                }
            }
            else
            {
                lblChange.Text = "0 đ";
                lblChange.ForeColor = Color.FromArgb(71, 85, 105);
                lblChange.BackColor = Color.FromArgb(248, 250, 252);
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow?.DataBoundItem is CartItemDto selectedItem)
            {
                _cart.Remove(selectedItem);
                UpdateCartDisplay();
                lblStatusMsg.Text = $"🗑️ Đã xóa '{selectedItem.ProductName}' khỏi giỏ";
                lblStatusMsg.ForeColor = Color.SlateGray;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0) return;

            var dr = MessageBox.Show("Bạn có chắc chắn muốn hủy toàn bộ giỏ hàng hiện tại?", "Xác nhận hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                _cart.Clear();
                UpdateCartDisplay();
                txtCashReceived.Clear();
                txtCustomerPhone.Clear();
                lblCustomerName.Text = "Khách vãng lai";
                lblCustomerRank.Text = "Hạng: Chuẩn";
                lblStatusMsg.Text = "Đã làm trống giỏ hàng.";
                lblStatusMsg.ForeColor = Color.SlateGray;
                txtBarcode.Focus();
            }
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng quét ít nhất một sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcode.Focus();
                return;
            }

            decimal total = _cart.Sum(x => x.TotalPrice);
            string rawCash = txtCashReceived.Text.Replace(",", "").Replace(".", "").Trim();
            if (decimal.TryParse(rawCash, out decimal cashReceived) && cashReceived < total)
            {
                MessageBox.Show($"Tiền khách đưa ({cashReceived:N0} đ) chưa đủ để thanh toán ({total:N0} đ)!", "Chưa đủ tiền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashReceived.Focus();
                return;
            }

            var orderRequest = new
            {
                CashierUsername = SessionManager.CurrentUsername,
                CustomerPhone = txtCustomerPhone.Text.Trim(),
                Items = _cart.Select(i => new { i.ProductId, i.Quantity, i.UnitPrice }).ToList()
            };

            btnCheckout.Enabled = false;
            btnCheckout.Text = "⏳ ĐANG XỬ LÝ...";
            lblStatusMsg.Text = "Đang gửi giao dịch lên hệ thống...";
            lblStatusMsg.ForeColor = Color.SteelBlue;

            try
            {
                var response = await ApiClientService.PostAsJsonWithAuthAsync("orders/checkout", orderRequest);
                if (response.IsSuccessStatusCode)
                {
                    decimal change = (decimal.TryParse(rawCash, out decimal cash) ? cash : total) - total;
                    string changeMsg = change > 0 ? $"\nTiền thừa gửi lại khách: {change:N0} đ" : "";

                    MessageBox.Show($"🎉 THANH TOÁN THÀNH CÔNG!\n\nTổng tiền: {total:N0} đ\nKhách hàng: {lblCustomerName.Text}{changeMsg}\n\nHóa đơn đã được lưu và trừ kho thành công.", 
                                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _cart.Clear();
                    UpdateCartDisplay();
                    txtCashReceived.Clear();
                    txtCustomerPhone.Clear();
                    lblCustomerName.Text = "Khách vãng lai";
                    lblCustomerRank.Text = "Hạng: Chuẩn";
                    lblStatusMsg.Text = "✅ Giao dịch hoàn tất! Sẵn sàng lượt mới.";
                    lblStatusMsg.ForeColor = Color.FromArgb(22, 163, 74);
                    txtBarcode.Focus();
                }
                else
                {
                    var errorMsg = await response.Content.ReadAsStringAsync();
                    lblStatusMsg.Text = "❌ Lỗi thanh toán!";
                    lblStatusMsg.ForeColor = Color.Crimson;
                    MessageBox.Show($"Thanh toán thất bại từ máy chủ: {errorMsg}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                lblStatusMsg.Text = "❌ Lỗi kết nối!";
                lblStatusMsg.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi kết nối khi thanh toán: " + ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCheckout.Enabled = true;
                btnCheckout.Text = "⚡ THANH TOÁN (F9)";
            }
        }
    }

    public class CartItemDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => UnitPrice * Quantity;
        public string UnitPriceFormatted => $"{UnitPrice:N0} đ";
        public string TotalPriceFormatted => $"{TotalPrice:N0} đ";
    }

    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}