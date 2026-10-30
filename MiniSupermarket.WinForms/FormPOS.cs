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
    public partial class FormPOS : Form
    {
        private readonly List<CartItemDto> _cart = new();
        private CustomerDto? _currentCustomer = null;

        public FormPOS()
        {
            InitializeComponent();
            SetupCartGrid();
            SetupQuickCashButtons();
        }

        /// <summary>
        /// Khởi tạo cấu hình DataGridView giỏ hàng theo chuẩn giao diện bán lẻ chuyên nghiệp
        /// </summary>
        private void SetupCartGrid()
        {
            dgvCart.AutoGenerateColumns = false;
            dgvCart.Columns.Clear();

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductId",
                HeaderText = "Mã SP",
                Width = 75,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Barcode",
                HeaderText = "Mã vạch Barcode",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên Sản Phẩm",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                MinimumWidth = 160,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(15, 23, 42)
                }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPriceFormatted",
                HeaderText = "Đơn Giá",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 9.5f)
                }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "SL",
                Width = 65,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(37, 99, 235) // Tech Blue
                }
            });

            dgvCart.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalPriceFormatted",
                HeaderText = "Thành Tiền",
                Width = 140,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(22, 163, 74) // Emerald Green
                }
            });
        }

        /// <summary>
        /// Tạo các nút chọn mệnh giá tiền nhanh (Quick Cash Pills)
        /// </summary>
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
                    Width = 62,
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
                    var breakdown = GetPaymentBreakdown();
                    decimal total = breakdown.FinalTotal;
                    if (val == 0m)
                    {
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

        // =========================================================================
        // PHÍM TẮT TOÀN MÀN HÌNH (HOTKEYS)
        // F2: Ô quét mã | F4: Tìm khách | F6/F7: Giảm/Tăng SL | F8: Đổi điểm | F9: Thanh toán | Del: Xóa | Esc: Hủy
        // =========================================================================
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                txtBarcode.Focus();
                txtBarcode.SelectAll();
                return true;
            }
            if (keyData == Keys.F4)
            {
                txtCustomerPhone.Focus();
                txtCustomerPhone.SelectAll();
                return true;
            }
            if (keyData == Keys.F6)
            {
                btnDecreaseQty.PerformClick();
                return true;
            }
            if (keyData == Keys.F7)
            {
                btnIncreaseQty.PerformClick();
                return true;
            }
            if (keyData == Keys.F8 && pnlLoyaltyBox.Enabled)
            {
                chkUsePoints.Checked = !chkUsePoints.Checked;
                return true;
            }
            if (keyData == Keys.F9)
            {
                btnCheckout.PerformClick();
                return true;
            }
            if (keyData == Keys.Delete && dgvCart.Focused)
            {
                btnRemoveItem.PerformClick();
                return true;
            }
            if (keyData == Keys.Escape)
            {
                btnClearCart.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // =========================================================================
        // QUÉT MÃ VẠCH & THÊM VÀO GIỎ HÀNG
        // =========================================================================
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

            int qtyToAdd = (int)nudScanQty.Value;
            if (qtyToAdd < 1) qtyToAdd = 1;
            nudScanQty.Value = 1; // Reset số lượng sau khi quét

            txtBarcode.Clear();
            await AddProductToCartByBarcodeAsync(barcode, qtyToAdd);
            txtBarcode.Focus();
        }

        private async Task AddProductToCartByBarcodeAsync(string barcode, int scanQty)
        {
            try
            {
                lblStatusMsg.Text = $"⏳ Đang tra cứu sản phẩm [{barcode}]...";
                lblStatusMsg.ForeColor = Color.SteelBlue;

                var product = await ApiClientService.GetFromJsonWithAuthAsync<ProductDto>($"products/barcode/{Uri.EscapeDataString(barcode)}");
                if (product == null)
                {
                    lblStatusMsg.Text = $"❌ Không tìm thấy mã vạch: {barcode}";
                    lblStatusMsg.ForeColor = Color.Crimson;
                    MessageBox.Show($"Không tìm thấy sản phẩm có mã vạch '{barcode}' trong hệ thống siêu thị!", "Không tìm thấy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var existingItem = _cart.FirstOrDefault(c => c.ProductId == product.ProductId);
                if (existingItem != null)
                {
                    if (existingItem.Quantity + scanQty > product.StockQuantity && product.StockQuantity > 0)
                    {
                        MessageBox.Show($"Số lượng yêu cầu ({existingItem.Quantity + scanQty}) vượt quá tồn kho (Hiện có: {product.StockQuantity})!", 
                                        "Cảnh báo tồn kho", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    existingItem.Quantity += scanQty;
                }
                else
                {
                    _cart.Add(new CartItemDto
                    {
                        ProductId = product.ProductId,
                        Barcode = product.Barcode,
                        ProductName = product.ProductName,
                        UnitPrice = product.Price,
                        Quantity = scanQty
                    });
                }

                UpdateCartDisplay();
                lblStatusMsg.Text = $"✅ Đã thêm (+{scanQty}): {product.ProductName}";
                lblStatusMsg.ForeColor = Color.FromArgb(22, 163, 74);
            }
            catch (Exception ex)
            {
                lblStatusMsg.Text = "❌ Lỗi: " + ex.Message;
                lblStatusMsg.ForeColor = Color.Crimson;
                MessageBox.Show("Lỗi lấy dữ liệu sản phẩm: " + ex.Message, "Lỗi máy chủ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // THAO TÁC SỐ LƯỢNG VÀ XÓA MẶT HÀNG TRÊN GIỎ
        // =========================================================================
        private void btnIncreaseQty_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow?.DataBoundItem is CartItemDto item)
            {
                item.Quantity++;
                UpdateCartDisplay();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm trong giỏ để tăng số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDecreaseQty_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow?.DataBoundItem is CartItemDto item)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity--;
                    UpdateCartDisplay();
                }
                else
                {
                    var dr = MessageBox.Show($"Số lượng của '{item.ProductName}' đang là 1. Bạn có muốn xóa sản phẩm này khỏi giỏ hàng?", 
                                             "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        _cart.Remove(item);
                        UpdateCartDisplay();
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng sản phẩm trong giỏ để giảm số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _currentCustomer = null;
                chkUsePoints.Checked = false;
                nudRedeemPoints.Value = 0;
                pnlLoyaltyBox.Enabled = false;
                UpdateCartDisplay();
                txtCashReceived.Clear();
                txtCustomerPhone.Clear();
                lblCustomerName.Text = "Khách hàng vãng lai";
                lblCustomerRank.Text = "Hạng: Chuẩn (0 đ)";
                lblStatusMsg.Text = "● Đã làm trống giỏ hàng.";
                lblStatusMsg.ForeColor = Color.SlateGray;
                txtBarcode.Focus();
            }
        }

        // =========================================================================
        // TRA CỨU KHÁCH HÀNG THÀNH VIÊN
        // =========================================================================
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
                _currentCustomer = null;
                lblCustomerName.Text = "Khách hàng vãng lai";
                lblCustomerRank.Text = "Hạng: Chuẩn (0 đ)";
                chkUsePoints.Checked = false;
                nudRedeemPoints.Value = 0;
                nudRedeemPoints.Maximum = 0;
                pnlLoyaltyBox.Enabled = false;
                UpdateCartDisplay();
                return;
            }

            try
            {
                var customer = await ApiClientService.GetFromJsonWithAuthAsync<CustomerDto>($"customers/phone/{Uri.EscapeDataString(phone)}");
                if (customer != null)
                {
                    _currentCustomer = customer;
                    lblCustomerName.Text = customer.CustomerName;
                    lblCustomerRank.Text = $"Hạng: {customer.MembershipRank} ({customer.RewardPoints} điểm)";
                    nudRedeemPoints.Maximum = customer.RewardPoints;
                    pnlLoyaltyBox.Enabled = customer.RewardPoints > 0;
                    lblStatusMsg.Text = $"✅ Khách hàng: {customer.CustomerName} ({customer.RewardPoints} điểm)";
                    lblStatusMsg.ForeColor = Color.FromArgb(22, 163, 74);
                }
                else
                {
                    _currentCustomer = null;
                    lblCustomerName.Text = "Khách mới (chưa đăng ký)";
                    lblCustomerRank.Text = "Hạng: Chuẩn (0 đ)";
                    pnlLoyaltyBox.Enabled = false;
                }
            }
            catch
            {
                _currentCustomer = null;
                lblCustomerName.Text = "Khách mới (chưa đăng ký)";
                lblCustomerRank.Text = "Hạng: Chuẩn (0 đ)";
                pnlLoyaltyBox.Enabled = false;
            }
            UpdateCartDisplay();
        }

        // =========================================================================
        // ITEM 47: ĐỔI ĐIỂM THƯỞNG TRỪ TIỀN HÓA ĐƠN (LOYALTY POINTS REDEMPTION)
        // =========================================================================
        private (decimal GrossTotal, decimal Discount, decimal FinalTotal, int PointsRedeemed) GetPaymentBreakdown()
        {
            decimal gross = _cart.Sum(x => x.TotalPrice);
            int points = (chkUsePoints.Checked && _currentCustomer != null) ? (int)nudRedeemPoints.Value : 0;
            if (_currentCustomer != null && points > _currentCustomer.RewardPoints)
            {
                points = _currentCustomer.RewardPoints;
            }

            decimal discount = points * 1000m; // 1 điểm = 1.000 VNĐ
            if (discount > gross) discount = gross;
            decimal finalPayable = Math.Max(0, gross - discount);

            return (gross, discount, finalPayable, points);
        }

        private void chkUsePoints_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkUsePoints.Checked)
            {
                if (nudRedeemPoints.Value == 0 && _currentCustomer != null && _currentCustomer.RewardPoints > 0)
                {
                    decimal gross = _cart.Sum(x => x.TotalPrice);
                    int maxAffordable = (int)(gross / 1000m);
                    int defaultPts = Math.Min(_currentCustomer.RewardPoints, Math.Min(50, maxAffordable));
                    nudRedeemPoints.Value = defaultPts > 0 ? defaultPts : 0;
                }
            }
            else
            {
                nudRedeemPoints.Value = 0;
            }
            UpdateCartDisplay();
        }

        private void nudRedeemPoints_ValueChanged(object? sender, EventArgs e)
        {
            if (nudRedeemPoints.Value > 0 && !chkUsePoints.Checked)
            {
                chkUsePoints.Checked = true;
            }
            UpdateCartDisplay();
        }

        private void btnRedeem50_Click(object? sender, EventArgs e)
        {
            if (_currentCustomer == null)
            {
                MessageBox.Show("Vui lòng tìm kiếm khách hàng thành viên có điểm trước khi đổi điểm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_currentCustomer.RewardPoints < 50)
            {
                MessageBox.Show($"Khách hàng hiện có {_currentCustomer.RewardPoints} điểm, không đủ 50 điểm để đổi!", "Không đủ điểm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chkUsePoints.Checked = true;
            nudRedeemPoints.Value = 50;
            UpdateCartDisplay();
        }

        // =========================================================================
        // CẬP NHẬT GIAO DIỆN GIỎ HÀNG & TÍNH TIỀN THỪA
        // =========================================================================
        private void UpdateCartDisplay()
        {
            dgvCart.DataSource = null;
            dgvCart.DataSource = _cart;
            SetupCartGrid();

            var breakdown = GetPaymentBreakdown();
            lblCartBadge.Text = $"{_cart.Sum(x => x.Quantity)} sản phẩm";
            lblItemCount.Text = $"Số loại: {_cart.Count} | Tổng số lượng: {_cart.Sum(x => x.Quantity)}";

            lblSubtotalAmount.Text = $"{breakdown.GrossTotal:N0} đ";
            lblDiscountAmount.Text = $"-{breakdown.Discount:N0} đ";
            lblRedeemDiscount.Text = $"-{breakdown.Discount:N0} đ";
            lblTotalAmount.Text = $"{breakdown.FinalTotal:N0} đ";

            CalculateChange();
        }

        private void txtCashReceived_TextChanged(object sender, EventArgs e)
        {
            CalculateChange();
        }

        private void CalculateChange()
        {
            var breakdown = GetPaymentBreakdown();
            decimal total = breakdown.FinalTotal;
            string rawCash = txtCashReceived.Text.Replace(",", "").Replace(".", "").Trim();

            if (decimal.TryParse(rawCash, out decimal cashReceived))
            {
                decimal change = cashReceived - total;
                if (change >= 0)
                {
                    lblChange.Text = $"{change:N0} đ";
                    lblChange.ForeColor = Color.FromArgb(22, 163, 74); // Green 600
                    lblChange.BackColor = Color.FromArgb(240, 253, 244); // Green 50
                }
                else
                {
                    lblChange.Text = $"Thiếu: {Math.Abs(change):N0} đ";
                    lblChange.ForeColor = Color.FromArgb(220, 38, 38); // Red 600
                    lblChange.BackColor = Color.FromArgb(254, 242, 242); // Red 50
                }
            }
            else
            {
                lblChange.Text = "0 đ";
                lblChange.ForeColor = Color.FromArgb(71, 85, 105);
                lblChange.BackColor = Color.FromArgb(248, 250, 252);
            }
        }

        // =========================================================================
        // XỬ LÝ THANH TOÁN (CHECKOUT) & IN HÓA ĐƠN
        // =========================================================================
        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống! Vui lòng quét ít nhất một sản phẩm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcode.Focus();
                return;
            }

            var breakdown = GetPaymentBreakdown();
            decimal total = breakdown.FinalTotal;
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
                CustomerId = _currentCustomer?.CustomerId ?? 1,
                CustomerPhone = txtCustomerPhone.Text.Trim(),
                PointsToRedeem = breakdown.PointsRedeemed,
                Items = _cart.Select(i => new { i.ProductId, i.Quantity, i.UnitPrice }).ToList()
            };

            btnCheckout.Enabled = false;
            btnCheckout.Text = "⏳ ĐANG XỬ LÝ...";
            lblStatusMsg.Text = "Đang gửi giao dịch thanh toán lên hệ thống...";
            lblStatusMsg.ForeColor = Color.SteelBlue;

            try
            {
                var response = await ApiClientService.PostAsJsonWithAuthAsync("orders/checkout", orderRequest);
                if (response.IsSuccessStatusCode)
                {
                    decimal change = (decimal.TryParse(rawCash, out decimal cash) ? cash : total) - total;
                    string changeMsg = change > 0 ? $"\nTiền thừa gửi lại khách: {change:N0} đ" : "";
                    string discountMsg = breakdown.Discount > 0 ? $"\nĐổi điểm thưởng: Dùng {breakdown.PointsRedeemed} điểm (-{breakdown.Discount:N0} đ)" : "";

                    string receiptSummary = 
                        "=========================================\n" +
                        "          MINI SUPERMARKET POS           \n" +
                        "       HÓA ĐƠN BÁN LẺ THANH TOÁN         \n" +
                        "=========================================\n" +
                        $"Thu ngân: {SessionManager.CurrentUsername ?? "Thu ngân"}\n" +
                        $"Thời gian: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n" +
                        $"Khách hàng: {lblCustomerName.Text}\n" +
                        "-----------------------------------------\n" +
                        $"Tổng số món: {_cart.Sum(x => x.Quantity)} SP ({_cart.Count} loại)\n" +
                        $"Tổng tiền hàng: {breakdown.GrossTotal:N0} đ" + discountMsg + "\n" +
                        $"THANH TOÁN THỰC TẾ: {breakdown.FinalTotal:N0} đ\n" +
                        $"Tiền khách đưa: {(cashReceived > 0 ? cashReceived : total):N0} đ" + changeMsg + "\n" +
                        "=========================================\n" +
                        "  Cảm ơn Quý khách & Hẹn gặp lại!\n" +
                        "=========================================";

                    MessageBox.Show(receiptSummary, "🎉 THANH TOÁN THÀNH CÔNG", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _cart.Clear();
                    _currentCustomer = null;
                    chkUsePoints.Checked = false;
                    nudRedeemPoints.Value = 0;
                    pnlLoyaltyBox.Enabled = false;
                    UpdateCartDisplay();
                    txtCashReceived.Clear();
                    txtCustomerPhone.Clear();
                    lblCustomerName.Text = "Khách hàng vãng lai";
                    lblCustomerRank.Text = "Hạng: Chuẩn (0 đ)";
                    lblStatusMsg.Text = "✅ Giao dịch hoàn tất! Sẵn sàng lượt quét mới.";
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
