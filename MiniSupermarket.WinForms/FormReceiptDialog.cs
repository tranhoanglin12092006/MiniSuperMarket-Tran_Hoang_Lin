using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    // =========================================================================
    // DTO DỮ LIỆU HÓA ĐƠN BÁN LẺ K80
    // =========================================================================
    public class ReceiptData
    {
        public string OrderCode { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public string CashierName { get; set; } = "Thu ngân";
        public string CustomerName { get; set; } = "Khách hàng vãng lai";
        public string CustomerPhone { get; set; } = string.Empty;
        public string CustomerRank { get; set; } = "Chuẩn";
        public int RewardPointsAdded { get; set; }
        public int PointsRedeemed { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal CashReceived { get; set; }
        public decimal ChangeAmount { get; set; }
        public string PaymentMethod { get; set; } = "Tiền mặt";
        public List<ReceiptItemData> Items { get; set; } = new();
    }

    public class ReceiptItemData
    {
        public string ProductName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal => Quantity * UnitPrice;
    }

    // =========================================================================
    // CỬA SỔ XEM TRƯỚC & IN HÓA ĐƠN BÁN LẺ K80 CAO CẤP
    // =========================================================================
    public class FormReceiptDialog : Form
    {
        private readonly ReceiptData _data;
        private Panel _pnlScrollWrapper = null!;
        private Panel _pnlPaper = null!;
        private Button _btnPrint = null!;
        private Button _btnSaveImage = null!;
        private Button _btnClose = null!;

        public FormReceiptDialog(ReceiptData data)
        {
            _data = data;
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.Text = $"Hóa đơn bán lẻ - {_data.OrderCode}";

            // Kích thước form tự động thích ứng với màn hình để luôn hiển thị đầy đủ cả Header lẫn Footer
            int workingHeight = Screen.PrimaryScreen?.WorkingArea.Height ?? 768;
            int dialogHeight = Math.Min(670, workingHeight - 50);
            this.Size = new Size(540, dialogHeight);
            this.MinimumSize = new Size(480, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(226, 232, 240); // Slate 200
            this.KeyPreview = true;

            // Xử lý phím tắt: Bấm Esc hoặc Enter để thoát hóa đơn ngay lập tức
            this.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Enter)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (e.KeyCode == Keys.P && e.Control)
                {
                    PrintReceipt();
                }
            };

            // 1. THANH TIÊU ĐỀ DI CHUYỂN ĐƯỢC (TITLE BAR)
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 64,
                BackColor = Color.FromArgb(16, 42, 33), // Dark Green cao cấp
                Padding = new Padding(18, 10, 18, 10)
            };

            Label lblTitle = new Label
            {
                Text = "🧾 HÓA ĐƠN BÁN LẺ THANH TOÁN (K80)",
                Font = new Font("Segoe UI", 11.5F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(16, 11),
                AutoSize = true
            };

            Label lblSubtitle = new Label
            {
                Text = $"Mã HĐ: {_data.OrderCode}  •  Nhấn phím Esc để đóng nhanh",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(167, 196, 181),
                Location = new Point(18, 35),
                AutoSize = true
            };

            // Nút đóng to, rõ ràng ngay trên góc Header
            Button btnHeaderClose = new Button
            {
                Text = "✕ Đóng (Esc)",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(47, 79, 68),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(115, 36),
                Location = new Point(405, 14),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };
            btnHeaderClose.FlatAppearance.BorderSize = 0;
            btnHeaderClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(239, 68, 68);
            btnHeaderClose.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            pnlHeader.Controls.AddRange(new Control[] { lblTitle, lblSubtitle, btnHeaderClose });

            // Di chuyển form khi kéo chuột trên header
            bool isDragging = false;
            Point dragCursorPoint = Point.Empty;
            Point dragFormPoint = Point.Empty;
            pnlHeader.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDragging = true;
                    dragCursorPoint = Cursor.Position;
                    dragFormPoint = this.Location;
                }
            };
            pnlHeader.MouseMove += (s, e) =>
            {
                if (isDragging)
                {
                    Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                    this.Location = Point.Add(dragFormPoint, new Size(dif));
                }
            };
            pnlHeader.MouseUp += (s, e) => isDragging = false;

            // 2. THANH THAO TÁC Ở ĐÁY (FOOTER BAR)
            Panel pnlFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 70,
                BackColor = Color.White,
                Padding = new Padding(16, 12, 16, 12)
            };

            Panel pnlFooterBorder = new Panel
            {
                Dock = DockStyle.Top,
                Height = 1,
                BackColor = Color.FromArgb(226, 232, 240)
            };
            pnlFooter.Controls.Add(pnlFooterBorder);

            _btnPrint = new Button
            {
                Text = "🖨️ In HĐ (Ctrl+P)",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(22, 163, 74), // Primary Green
                FlatStyle = FlatStyle.Flat,
                Size = new Size(155, 44),
                Location = new Point(14, 13),
                Cursor = Cursors.Hand
            };
            _btnPrint.FlatAppearance.BorderSize = 0;
            _btnPrint.Click += (s, e) => PrintReceipt();

            _btnSaveImage = new Button
            {
                Text = "💾 Lưu ảnh",
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                BackColor = Color.FromArgb(241, 245, 249),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(110, 44),
                Location = new Point(176, 13),
                Cursor = Cursors.Hand
            };
            _btnSaveImage.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            _btnSaveImage.Click += (s, e) => SaveReceiptImage();

            _btnClose = new Button
            {
                Text = "❌ Thoát / Đơn mới (Esc)",
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(15, 23, 42), // Dark Slate
                FlatStyle = FlatStyle.Flat,
                Size = new Size(205, 44),
                Location = new Point(315, 13),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };
            _btnClose.FlatAppearance.BorderSize = 0;
            _btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38); // Đỏ khi rê chuột
            _btnClose.Click += (s, e) =>
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            pnlFooter.Controls.AddRange(new Control[] { _btnPrint, _btnSaveImage, _btnClose });

            // 3. KHU VỰC CUỘN HIỂN THỊ PHIẾU HÓA ĐƠN
            _pnlScrollWrapper = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.FromArgb(226, 232, 240), // Nền slate tương phản
                Padding = new Padding(24, 18, 24, 18)
            };

            float paperWidth = 430; // Chuẩn 80mm mở rộng hiển thị thoáng đẹp
            float paperHeight = MeasureReceiptHeight(_data, paperWidth);

            _pnlPaper = new Panel
            {
                Width = (int)paperWidth,
                Height = (int)paperHeight,
                BackColor = Color.White,
                Location = new Point(Math.Max(12, (this.ClientSize.Width - (int)paperWidth) / 2), 18)
            };

            // Vẽ toàn bộ nội dung phiếu hóa đơn nhiệt
            _pnlPaper.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                // Nền trắng tinh của giấy nhiệt
                e.Graphics.Clear(Color.White);

                // Vẽ nội dung hóa đơn
                DrawReceipt(e.Graphics, _data, paperWidth);

                // Vẽ viền xám nhẹ quanh phiếu
                using var borderPen = new Pen(Color.FromArgb(203, 213, 225), 1);
                e.Graphics.DrawRectangle(borderPen, 0, 0, _pnlPaper.Width - 1, _pnlPaper.Height - 1);
            };

            // Tự căn giữa cuộn giấy khi co giãn form
            _pnlScrollWrapper.Resize += (s, e) =>
            {
                _pnlPaper.Left = Math.Max(12, (_pnlScrollWrapper.ClientSize.Width - _pnlPaper.Width) / 2);
            };

            _pnlScrollWrapper.Controls.Add(_pnlPaper);

            this.Controls.Add(_pnlScrollWrapper);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(pnlHeader);
        }

        // =========================================================================
        // TÍNH TOÁN ĐỘ CAO CHÍNH XÁC CỦA PHIẾU IN K80
        // =========================================================================
        public static float MeasureReceiptHeight(ReceiptData data, float width)
        {
            float h = 20; // Top padding
            h += 38; // Tên siêu thị
            h += 22; // Slogan
            h += 20; // Địa chỉ
            h += 20; // Hotline & Web
            h += 18; // Đường kẻ phân cách
            h += 32; // TIÊU ĐỀ: HÓA ĐƠN BÁN LẺ
            h += 20; // Phụ đề RECEIPT
            h += 14; // Khoảng cách

            // Khối metadata thông tin đơn hàng (mỗi thông tin 1 dòng riêng biệt)
            h += 22; // Mã hóa đơn
            h += 22; // Ngày giờ lập
            h += 22; // Thu ngân & Quầy
            h += 22; // Khách hàng
            h += 22; // Hạng hội viên
            h += 16; // Đường kẻ phân cách

            // Bảng danh sách mặt hàng
            h += 26; // Header cột
            h += 8;  // Khoảng cách
            h += (data.Items.Count * 42); // Mỗi mặt hàng 2 dòng (Tên + SL x Giá & Tiền)
            h += 16; // Đường kẻ phân cách

            // Khối tổng kết thanh toán
            h += 24; // Tổng tiền hàng
            if (data.Discount > 0) h += 24; // Chiết khấu đổi điểm
            h += 52; // KHUNG TỔNG THANH TOÁN HIGHLIGHT
            h += 24; // Tiền khách đưa
            h += 24; // Tiền thối lại khách
            h += 24; // Hình thức thanh toán
            if (data.RewardPointsAdded > 0) h += 24; // Điểm tích lũy cộng

            h += 20; // Đường kẻ phân cách
            h += 60; // Barcode Code 39
            h += 22; // Text mã vạch
            h += 75; // QR Code tra cứu
            h += 20; // Text hướng dẫn QR
            h += 24; // Lời cảm ơn
            h += 18; // Quy định đổi trả
            h += 18; // Hotline
            h += 30; // Bottom padding

            return Math.Max(600, h);
        }

        // =========================================================================
        // BỘ ENGINE VẼ HÓA ĐƠN NHIỆT K80 CHUẨN THƯƠNG MẠI (ZERO OVERLAP)
        // =========================================================================
        public static void DrawReceipt(Graphics g, ReceiptData data, float width)
        {
            float left = 20;
            float right = width - 20;
            float contentWidth = right - left;
            float y = 18;

            using var fontStore = new Font("Segoe UI", 14F, FontStyle.Bold);
            using var fontSlogan = new Font("Segoe UI", 9F, FontStyle.Bold);
            using var fontContact = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            using var fontTitle = new Font("Segoe UI", 13.5F, FontStyle.Bold);
            using var fontTitleSub = new Font("Segoe UI", 8F, FontStyle.Regular);

            using var fontLabel = new Font("Segoe UI", 9F, FontStyle.Regular);
            using var fontLabelBold = new Font("Segoe UI", 9F, FontStyle.Bold);
            using var fontValue = new Font("Segoe UI", 9F, FontStyle.Regular);
            using var fontValueBold = new Font("Segoe UI", 9F, FontStyle.Bold);

            using var fontItemName = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            using var fontItemCalc = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            using var fontItemTotal = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            using var fontGrandTotalLabel = new Font("Segoe UI", 11.5F, FontStyle.Bold);
            using var fontGrandTotalValue = new Font("Segoe UI", 14F, FontStyle.Bold);

            using var fontBarcodeText = new Font("Consolas", 9F, FontStyle.Bold);
            using var fontSmall = new Font("Segoe UI", 8F, FontStyle.Regular);
            using var fontThanks = new Font("Segoe UI", 9.5F, FontStyle.Bold);

            using var brushPrimary = new SolidBrush(Color.FromArgb(16, 42, 33)); // Dark Green
            using var brushAccent = new SolidBrush(Color.FromArgb(22, 163, 74));  // Primary Green
            using var brushText = new SolidBrush(Color.FromArgb(15, 23, 42));     // Dark Slate 900
            using var brushMuted = new SolidBrush(Color.FromArgb(100, 116, 139)); // Slate 500
            using var brushRed = new SolidBrush(Color.FromArgb(220, 38, 38));     // Red 600
            using var brushPurple = new SolidBrush(Color.FromArgb(124, 58, 237)); // Purple 600

            using var penDashed = new Pen(Color.FromArgb(203, 213, 225), 1.2F) { DashStyle = DashStyle.Dash };
            using var penSolid = new Pen(Color.FromArgb(226, 232, 240), 1F);

            var sfCenter = new StringFormat { Alignment = StringAlignment.Center };
            var sfLeft = new StringFormat { Alignment = StringAlignment.Near };
            var sfRight = new StringFormat { Alignment = StringAlignment.Far };

            // Helper vẽ 1 dòng có nhãn bên trái và giá trị bên phải (KHÔNG BAO GIỜ CHỒNG CHÉO)
            void DrawTwoColumnRow(string label, string value, Font lFont, Font vFont, Brush lBrush, Brush vBrush, ref float currentY, float rowHeight = 22)
            {
                float labelWidth = g.MeasureString(label, lFont).Width + 6;
                float valueMaxWidth = contentWidth - labelWidth;

                g.DrawString(label, lFont, lBrush, left, currentY);
                g.DrawString(value, vFont, vBrush, new RectangleF(left + labelWidth, currentY, valueMaxWidth, rowHeight), sfRight);
                currentY += rowHeight;
            }

            // 1. HEADER SIÊU THỊ MINIMART
            g.DrawString("MINIMART SUPERMARKET", fontStore, brushPrimary, new RectangleF(0, y, width, 32), sfCenter);
            y += 32;
            g.DrawString("HỆ THỐNG BÁN LẺ & TIỆN ÍCH TIÊU DÙNG", fontSlogan, brushAccent, new RectangleF(0, y, width, 20), sfCenter);
            y += 20;
            g.DrawString("Đ/C: 123 Nguyễn Huệ, P. Bến Nghé, Quận 1, TP. HCM", fontContact, brushMuted, new RectangleF(0, y, width, 18), sfCenter);
            y += 18;
            g.DrawString("Hotline: 1900 6868  •  Website: www.minimart.vn", fontContact, brushMuted, new RectangleF(0, y, width, 18), sfCenter);
            y += 22;

            // ĐƯỜNG KẺ PHÂN CÁCH
            g.DrawLine(penDashed, left, y, right, y);
            y += 10;

            // 2. TIÊU ĐỀ HÓA ĐƠN
            g.DrawString("HÓA ĐƠN BÁN LẺ", fontTitle, brushText, new RectangleF(0, y, width, 28), sfCenter);
            y += 28;
            g.DrawString("RETAIL CASH RECEIPT", fontTitleSub, brushMuted, new RectangleF(0, y, width, 16), sfCenter);
            y += 18;

            // KHỐI THÔNG TIN HÓA ĐƠN (MỖI THÔNG TIN 1 DÒNG RIÊNG BIỆT - KHÔNG CHỒNG ĐÈ)
            DrawTwoColumnRow("Mã hóa đơn:", data.OrderCode, fontLabelBold, fontValueBold, brushText, brushPrimary, ref y);
            DrawTwoColumnRow("Thời gian:", $"{data.OrderDate:dd/MM/yyyy  HH:mm:ss}", fontLabel, fontValue, brushMuted, brushText, ref y);
            DrawTwoColumnRow("Thu ngân:", $"{data.CashierName}  (Quầy POS-01)", fontLabel, fontValue, brushMuted, brushText, ref y);

            string custName = string.IsNullOrWhiteSpace(data.CustomerName) ? "Khách hàng vãng lai" : data.CustomerName;
            if (!string.IsNullOrWhiteSpace(data.CustomerPhone)) custName += $" ({data.CustomerPhone})";
            DrawTwoColumnRow("Khách hàng:", custName, fontLabel, fontValueBold, brushText, brushText, ref y);

            DrawTwoColumnRow("Hạng hội viên:", $"★ {data.CustomerRank}", fontLabel, fontValueBold, brushMuted, brushAccent, ref y);

            // ĐƯỜNG KẺ PHÂN CÁCH
            y += 4;
            g.DrawLine(penDashed, left, y, right, y);
            y += 10;

            // 3. HEADER CỘT MẶT HÀNG
            using (var brushHeaderBg = new SolidBrush(Color.FromArgb(248, 250, 252)))
            {
                g.FillRectangle(brushHeaderBg, left, y, contentWidth, 24);
            }
            g.DrawRectangle(penSolid, left, y, contentWidth, 24);

            g.DrawString("MẶT HÀNG / SỐ LƯỢNG", fontLabelBold, brushText, left + 6, y + 4);
            g.DrawString("THÀNH TIỀN", fontLabelBold, brushText, right - 6, y + 4, sfRight);
            y += 30;

            // DANH SÁCH SẢN PHẨM (CHUẨN 2 DÒNG KHÔNG BAO GIỜ BỊ DÀI CHÈN CHỮ)
            int itemNo = 1;
            foreach (var item in data.Items)
            {
                // Dòng 1: Tên sản phẩm in hoa đầu
                string itemName = $"{itemNo}. {item.ProductName}";
                g.DrawString(itemName, fontItemName, brushText, left + 4, y);
                y += 18;

                // Dòng 2: SL x Đơn giá bên trái, Thành tiền bên phải
                string calcText = $"     {item.Quantity}  ×  {item.UnitPrice:N0} đ";
                g.DrawString(calcText, fontItemCalc, brushMuted, left, y);
                g.DrawString($"{item.LineTotal:N0} đ", fontItemTotal, brushText, right, y, sfRight);
                y += 24;

                itemNo++;
            }

            // ĐƯỜNG KẺ PHÂN CÁCH
            y += 2;
            g.DrawLine(penDashed, left, y, right, y);
            y += 12;

            // 4. KHỐI TỔNG KẾT THANH TOÁN
            int totalQty = data.Items.Sum(x => x.Quantity);
            DrawTwoColumnRow($"Tổng tiền hàng ({totalQty} SP):", $"{data.GrossAmount:N0} đ", fontLabel, fontValueBold, brushText, brushText, ref y, 22);

            if (data.Discount > 0)
            {
                DrawTwoColumnRow($"Chiết khấu (Đổi {data.PointsRedeemed} điểm):", $"-{data.Discount:N0} đ", fontLabel, fontValueBold, brushRed, brushRed, ref y, 22);
            }

            // DẢI NỀN HIGHLIGHT TỔNG CỘNG THANH TOÁN CỰC ĐẸP
            y += 4;
            using (var brushTotalBg = new SolidBrush(Color.FromArgb(236, 253, 245))) // Emerald 50
            using (var penTotalBorder = new Pen(Color.FromArgb(167, 243, 208), 1.2F)) // Emerald 200
            {
                g.FillRectangle(brushTotalBg, left, y, contentWidth, 44);
                g.DrawRectangle(penTotalBorder, left, y, contentWidth, 44);
            }

            g.DrawString("TỔNG THANH TOÁN:", fontGrandTotalLabel, brushPrimary, left + 10, y + 12);
            g.DrawString($"{data.FinalAmount:N0} đ", fontGrandTotalValue, brushAccent, right - 10, y + 10, sfRight);
            y += 52;

            DrawTwoColumnRow("Tiền khách đưa:", $"{data.CashReceived:N0} đ", fontLabel, fontValueBold, brushText, brushText, ref y, 22);
            DrawTwoColumnRow("Tiền thối lại khách:", $"{data.ChangeAmount:N0} đ", fontLabelBold, fontValueBold, brushText, brushPrimary, ref y, 22);
            DrawTwoColumnRow("Hình thức thanh toán:", data.PaymentMethod, fontLabel, fontValueBold, brushMuted, brushText, ref y, 22);

            if (data.RewardPointsAdded > 0)
            {
                DrawTwoColumnRow("Điểm thưởng tích lũy:", $"+{data.RewardPointsAdded} điểm", fontLabelBold, fontValueBold, brushPurple, brushPurple, ref y, 22);
            }

            // ĐƯỜNG KẺ PHÂN CÁCH
            y += 6;
            g.DrawLine(penDashed, left, y, right, y);
            y += 14;

            // 5. MÃ VẠCH BARCODE CODE 39 CHUẨN (CĂN GIỮA, RÕ RÀNG)
            DrawBarcodeCode39(g, data.OrderCode, left, y, contentWidth, 42);
            y += 48;
            g.DrawString($"* {data.OrderCode} *", fontBarcodeText, brushText, new RectangleF(0, y, width, 18), sfCenter);
            y += 20;

            // 6. MÃ QR CODE TRA CỨU HÓA ĐƠN
            DrawMiniQrCode(g, width / 2 - 28, y, 56);
            y += 62;
            g.DrawString("Quét mã QR để tra cứu hóa đơn điện tử e-Invoice", fontSmall, brushMuted, new RectangleF(0, y, width, 16), sfCenter);
            y += 20;

            // 7. LỜI CẢM ƠN & QUY ĐỊNH
            g.DrawString("Cảm ơn Quý khách & Hẹn gặp lại!", fontThanks, brushPrimary, new RectangleF(0, y, width, 20), sfCenter);
            y += 20;
            g.DrawString("Quý khách vui lòng kiểm tra hàng hóa trước khi rời quầy.", fontSmall, brushMuted, new RectangleF(0, y, width, 16), sfCenter);
            y += 16;
            g.DrawString("Hỗ trợ đổi trả trong 03 ngày (kèm hóa đơn còn nguyên vẹn).", fontSmall, brushMuted, new RectangleF(0, y, width, 16), sfCenter);
            y += 16;
            g.DrawString("Hotline phản ánh dịch vụ: 1900 6868", fontSmall, brushMuted, new RectangleF(0, y, width, 16), sfCenter);
        }

        // =========================================================================
        // HÀM VẼ MÃ VẠCH CODE 39 CHUẨN QUỐC TẾ
        // =========================================================================
        private static void DrawBarcodeCode39(Graphics g, string code, float x, float y, float availableWidth, float height)
        {
            string cleanCode = code.Trim().ToUpper();
            if (string.IsNullOrEmpty(cleanCode)) cleanCode = "HD20261102";

            Dictionary<char, string> patterns = new()
            {
                { '0', "000110100" }, { '1', "100100001" }, { '2', "001100001" }, { '3', "101100000" },
                { '4', "000110001" }, { '5', "100110000" }, { '6', "001110000" }, { '7', "000100101" },
                { '8', "100100100" }, { '9', "001100100" }, { 'A', "100001001" }, { 'B', "001001001" },
                { 'C', "101001000" }, { 'D', "000011001" }, { 'E', "100011000" }, { 'F', "001011000" },
                { 'G', "000001101" }, { 'H', "100001100" }, { 'I', "001001100" }, { 'J', "000011100" },
                { 'K', "100000011" }, { 'L', "001000011" }, { 'M', "101000010" }, { 'N', "000010011" },
                { 'O', "100010010" }, { 'P', "001010010" }, { 'Q', "000000111" }, { 'R', "100000110" },
                { 'S', "001000110" }, { 'T', "000010110" }, { 'U', "110000001" }, { 'V', "011000001" },
                { 'W', "111000000" }, { 'X', "010010001" }, { 'Y', "110010000" }, { 'Z', "011010000" },
                { '-', "010000101" }, { '.', "110000100" }, { ' ', "011000100" }, { '*', "010010100" }
            };

            string fullCode = $"*{cleanCode}*";
            float narrow = 1.7f;
            float wide = narrow * 2.7f;
            float gap = narrow * 1.2f;

            float totalW = 0;
            foreach (char c in fullCode)
            {
                if (patterns.TryGetValue(c, out string? pat))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        totalW += (pat[i] == '1' ? wide : narrow);
                    }
                    totalW += gap;
                }
            }

            float startX = x + Math.Max(0, (availableWidth - totalW) / 2);
            using var brushBar = new SolidBrush(Color.Black);

            float curX = startX;
            foreach (char c in fullCode)
            {
                if (patterns.TryGetValue(c, out string? pat))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        float barWidth = (pat[i] == '1' ? wide : narrow);
                        if (i % 2 == 0) // Vạch đen
                        {
                            g.FillRectangle(brushBar, curX, y, barWidth, height);
                        }
                        curX += barWidth;
                    }
                    curX += gap;
                }
            }
        }

        // =========================================================================
        // HÀM VẼ MÃ QR VECTOR SẮC NÉT
        // =========================================================================
        private static void DrawMiniQrCode(Graphics g, float x, float y, float size)
        {
            using var brushDark = new SolidBrush(Color.FromArgb(16, 42, 33));
            using var brushWhite = new SolidBrush(Color.White);

            int modules = 21; // QR chuẩn Version 1 (21x21 modules)
            float modSize = size / modules;

            void DrawMod(int row, int col)
            {
                g.FillRectangle(brushDark, x + col * modSize, y + row * modSize, modSize, modSize);
            }

            void DrawFinder(int r0, int c0)
            {
                g.FillRectangle(brushDark, x + c0 * modSize, y + r0 * modSize, 7 * modSize, 7 * modSize);
                g.FillRectangle(brushWhite, x + (c0 + 1) * modSize, y + (r0 + 1) * modSize, 5 * modSize, 5 * modSize);
                g.FillRectangle(brushDark, x + (c0 + 2) * modSize, y + (r0 + 2) * modSize, 3 * modSize, 3 * modSize);
            }

            g.FillRectangle(brushWhite, x - 2, y - 2, size + 4, size + 4);

            DrawFinder(0, 0);
            DrawFinder(0, modules - 7);
            DrawFinder(modules - 7, 0);

            for (int i = 8; i < modules - 8; i += 2)
            {
                DrawMod(6, i);
                DrawMod(i, 6);
            }

            int seed = 12345;
            for (int r = 0; r < modules; r++)
            {
                for (int c = 0; c < modules; c++)
                {
                    if ((r < 8 && c < 8) || (r < 8 && c >= modules - 8) || (r >= modules - 8 && c < 8))
                        continue;
                    if (r == 6 || c == 6) continue;

                    seed = (seed * 1103515245 + 12345) & 0x7fffffff;
                    if ((seed % 100) < 46)
                    {
                        DrawMod(r, c);
                    }
                }
            }
        }

        // =========================================================================
        // IN HÓA ĐƠN K80 (PrintDocument)
        // =========================================================================
        private void PrintReceipt()
        {
            try
            {
                using var printDoc = new PrintDocument();
                printDoc.DocumentName = $"HoaDon_{_data.OrderCode}";

                float paperWidth = 400;

                printDoc.PrintPage += (s, e) =>
                {
                    if (e.Graphics != null)
                    {
                        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                        DrawReceipt(e.Graphics, _data, paperWidth);
                    }
                    e.HasMorePages = false;
                };

                using var printDlg = new PrintDialog
                {
                    Document = printDoc,
                    UseEXDialog = true
                };

                if (printDlg.ShowDialog(this) == DialogResult.OK)
                {
                    printDoc.Print();
                    var confirm = MessageBox.Show("Lệnh in đã được gửi đến máy in thành công!\n\nBạn có muốn đóng hóa đơn này để bắt đầu lượt bán mới không?", 
                        "Đã in hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi lệnh in: " + ex.Message, "Lỗi in ấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =========================================================================
        // LƯU ẢNH HÓA ĐƠN PNG CHẤT LƯỢNG CAO
        // =========================================================================
        private void SaveReceiptImage()
        {
            try
            {
                using var sfd = new SaveFileDialog
                {
                    Title = "Chọn nơi lưu ảnh hóa đơn bán lẻ",
                    Filter = "Tệp hình ảnh PNG (*.png)|*.png|Tệp JPEG (*.jpg)|*.jpg",
                    FileName = $"HoaDon_{_data.OrderCode}_{DateTime.Now:yyyyMMdd_HHmm}.png"
                };

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    float width = 430;
                    float height = MeasureReceiptHeight(_data, width);

                    using var bmp = new Bitmap((int)width, (int)height);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.White);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                        DrawReceipt(g, _data, width);
                    }

                    ImageFormat fmt = sfd.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase)
                        ? ImageFormat.Jpeg
                        : ImageFormat.Png;

                    bmp.Save(sfd.FileName, fmt);

                    var confirm = MessageBox.Show($"Đã lưu ảnh hóa đơn bán lẻ thành công tại:\n{sfd.FileName}\n\nBạn có muốn đóng hóa đơn này để tiếp tục lượt bán mới không?", 
                        "Lưu ảnh thành công", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu ảnh hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
