using MiniSupermarket.WinForms.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    /// <summary>
    /// Dialog hiển thị chi tiết các sản phẩm trong một hóa đơn bán hàng
    /// Phục vụ kiểm tra đối soát và bảo vệ đồ án chuyên nghiệp (Tiêu chí 49, 50)
    /// </summary>
    public class FormOrderDetailDialog : Form
    {
        private readonly DayOrderDto _order;
        private readonly List<ReportOrderDetailDto> _details;
        private DataGridView _dgvDetails = null!;

        public FormOrderDetailDialog(DayOrderDto order, List<ReportOrderDetailDto> details)
        {
            _order = order;
            _details = details;
            InitializeComponentCustom();
        }

        private void InitializeComponentCustom()
        {
            this.Text = $"CHI TIẾT HÓA ĐƠN: {_order.OrderCode}";
            this.Size = new Size(820, 520);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.FromArgb(244, 247, 245);
            this.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);

            // 1. Header thông tin đơn hàng
            Panel pnlHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 110,
                BackColor = Color.White,
                Padding = new Padding(20, 14, 20, 14)
            };

            Label lblTitle = new Label
            {
                Text = $"🧾 HÓA ĐƠN BÁN HÀNG: {_order.OrderCode}",
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                ForeColor = Color.FromArgb(23, 33, 27),
                Location = new Point(18, 12),
                AutoSize = true
            };

            Label lblInfoLeft = new Label
            {
                Text = $"👤 Khách hàng: {_order.CustomerName}\n💳 Thu ngân: {_order.Cashier}",
                Location = new Point(20, 48),
                Size = new Size(350, 48),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(71, 85, 105)
            };

            Label lblInfoRight = new Label
            {
                Text = $"📅 Thời gian: {_order.Time}\n🎁 Điểm tích lũy cộng: +{_order.RewardPoints} điểm",
                Location = new Point(440, 48),
                Size = new Size(350, 48),
                Font = new Font("Segoe UI", 9.5f, FontStyle.Regular),
                ForeColor = Color.FromArgb(71, 85, 105)
            };

            Panel pnlDivider = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 1,
                BackColor = Color.FromArgb(229, 234, 231)
            };
            pnlHeader.Controls.AddRange(new Control[] { lblTitle, lblInfoLeft, lblInfoRight, pnlDivider });

            // 2. Footer tổng kết & Nút đóng
            Panel pnlFooter = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 65,
                BackColor = Color.White,
                Padding = new Padding(20, 12, 20, 12)
            };

            Label lblTotal = new Label
            {
                Text = $"TỔNG THANH TOÁN: {_order.FinalAmount:N0} VNĐ",
                Font = new Font("Segoe UI", 12f, FontStyle.Bold),
                ForeColor = Color.FromArgb(22, 163, 74),
                Location = new Point(20, 18),
                AutoSize = true
            };

            Button btnClose = new Button
            {
                Text = "Đóng",
                DialogResult = DialogResult.OK,
                Size = new Size(110, 36),
                Location = new Point(680, 14),
                BackColor = Color.FromArgb(22, 163, 74),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            pnlFooter.Controls.AddRange(new Control[] { lblTotal, btnClose });

            // 3. Gridview chi tiết sản phẩm
            _dgvDetails = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                RowHeadersVisible = false,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowTemplate = { Height = 36 },
                EnableHeadersVisualStyles = false,
                GridColor = Color.FromArgb(241, 245, 249)
            };

            _dgvDetails.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(15, 23, 42),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Padding = new Padding(6, 0, 6, 0),
                Alignment = DataGridViewContentAlignment.MiddleLeft
            };
            _dgvDetails.ColumnHeadersHeight = 38;

            _dgvDetails.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(30, 41, 59),
                SelectionBackColor = Color.FromArgb(239, 246, 255),
                SelectionForeColor = Color.FromArgb(30, 58, 138),
                Padding = new Padding(6, 0, 6, 0)
            };

            _dgvDetails.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 250, 252),
                ForeColor = Color.FromArgb(30, 41, 59),
                SelectionBackColor = Color.FromArgb(239, 246, 255),
                SelectionForeColor = Color.FromArgb(30, 58, 138)
            };

            // Thêm các cột
            _dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductId",
                HeaderText = "Mã SP",
                Width = 75,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            _dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Barcode",
                HeaderText = "Mã vạch Barcode",
                Width = 145,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleLeft }
            });

            _dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductName",
                HeaderText = "Tên mặt hàng",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold)
                }
            });

            _dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Số lượng",
                Width = 95,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            _dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Đơn giá",
                Width = 115,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0"
                }
            });

            _dgvDetails.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LineTotal",
                HeaderText = "Thành tiền (VNĐ)",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Format = "N0",
                    Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                    ForeColor = Color.FromArgb(22, 163, 74)
                }
            });

            _dgvDetails.DataSource = _details;
            UI.UIStyler.StyleDataGridView(_dgvDetails);

            Panel pnlCenter = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(16, 12, 16, 12)
            };
            pnlCenter.Controls.Add(_dgvDetails);

            this.Controls.Add(pnlCenter);
            this.Controls.Add(pnlFooter);
            this.Controls.Add(pnlHeader);
        }
    }
}
