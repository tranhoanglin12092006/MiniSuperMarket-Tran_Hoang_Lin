namespace MiniSupermarket.WinForms
{
    partial class FormPOS
    {
        private System.ComponentModel.IContainer components = null;

        // Container chính & SplitContainer co giãn responsive
        private System.Windows.Forms.Panel pnlMainContainer;
        private System.Windows.Forms.SplitContainer scMain;

        // Cột Trái: Quét mã vạch & Giỏ hàng
        private System.Windows.Forms.Panel pnlScanCard;
        private System.Windows.Forms.Label lblBarcodeTitle;
        private System.Windows.Forms.Label lblQtyScanTitle;
        private System.Windows.Forms.NumericUpDown nudScanQty;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnAddBarcode;
        private System.Windows.Forms.Label lblScanHint;

        private System.Windows.Forms.Panel pnlCartCard;
        private System.Windows.Forms.Panel pnlCartHeader;
        private System.Windows.Forms.Label lblCartHeader;
        private System.Windows.Forms.Label lblCartBadge;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlCartFooter;
        private System.Windows.Forms.Label lblItemCount;
        private System.Windows.Forms.Button btnIncreaseQty;
        private System.Windows.Forms.Button btnDecreaseQty;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnClearCart;

        // Cột Phải: Quầy thanh toán & Khách hàng
        private System.Windows.Forms.Panel pnlCheckoutCard;
        private System.Windows.Forms.Label lblCheckoutHeader;
        private System.Windows.Forms.Panel pnlCheckoutBody;

        // Khách hàng thành viên
        private System.Windows.Forms.Panel pnlCustomerBox;
        private System.Windows.Forms.Label lblPhoneTitle;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Label lblCustomerAvatar;
        private System.Windows.Forms.Label lblCustomerNameTitle;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerRank;

        // Đổi điểm thưởng tích lũy (Item 47)
        private System.Windows.Forms.Panel pnlLoyaltyBox;
        private System.Windows.Forms.CheckBox chkUsePoints;
        private System.Windows.Forms.NumericUpDown nudRedeemPoints;
        private System.Windows.Forms.Button btnRedeem50;
        private System.Windows.Forms.Label lblRedeemDiscount;
        private System.Windows.Forms.Label lblLoyaltyHint;

        // Chi tiết thanh toán & Tiền thừa
        private System.Windows.Forms.Panel pnlPaymentBox;
        private System.Windows.Forms.Panel pnlPriceBreakdown;
        private System.Windows.Forms.Label lblSubtotalTitle;
        private System.Windows.Forms.Label lblSubtotalAmount;
        private System.Windows.Forms.Label lblDiscountTitle;
        private System.Windows.Forms.Label lblDiscountAmount;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblCashTitle;
        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.FlowLayoutPanel flpQuickCash;
        private System.Windows.Forms.Label lblChangeTitle;
        private System.Windows.Forms.Label lblChange;

        // Nút Thanh toán cố định ở đáy (Pinned CTA) & Thanh trạng thái
        private System.Windows.Forms.Panel pnlCheckoutAction;
        private System.Windows.Forms.TableLayoutPanel tlpCheckoutButtons;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnVietQR;
        private System.Windows.Forms.Label lblStatusMsg;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dgvCellStyleHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dgvCellStyleCell = new System.Windows.Forms.DataGridViewCellStyle();

            this.pnlMainContainer = new System.Windows.Forms.Panel();
            this.scMain = new System.Windows.Forms.SplitContainer();

            // Cột Trái Controls
            this.pnlScanCard = new System.Windows.Forms.Panel();
            this.lblBarcodeTitle = new System.Windows.Forms.Label();
            this.lblQtyScanTitle = new System.Windows.Forms.Label();
            this.nudScanQty = new System.Windows.Forms.NumericUpDown();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnAddBarcode = new System.Windows.Forms.Button();
            this.lblScanHint = new System.Windows.Forms.Label();

            this.pnlCartCard = new System.Windows.Forms.Panel();
            this.pnlCartHeader = new System.Windows.Forms.Panel();
            this.lblCartHeader = new System.Windows.Forms.Label();
            this.lblCartBadge = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.pnlCartFooter = new System.Windows.Forms.Panel();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.btnIncreaseQty = new System.Windows.Forms.Button();
            this.btnDecreaseQty = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();

            // Cột Phải Controls
            this.pnlCheckoutCard = new System.Windows.Forms.Panel();
            this.lblCheckoutHeader = new System.Windows.Forms.Label();
            this.pnlCheckoutBody = new System.Windows.Forms.Panel();

            this.pnlCustomerBox = new System.Windows.Forms.Panel();
            this.lblPhoneTitle = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.lblCustomerAvatar = new System.Windows.Forms.Label();
            this.lblCustomerNameTitle = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerRank = new System.Windows.Forms.Label();

            this.pnlLoyaltyBox = new System.Windows.Forms.Panel();
            this.chkUsePoints = new System.Windows.Forms.CheckBox();
            this.nudRedeemPoints = new System.Windows.Forms.NumericUpDown();
            this.btnRedeem50 = new System.Windows.Forms.Button();
            this.lblRedeemDiscount = new System.Windows.Forms.Label();
            this.lblLoyaltyHint = new System.Windows.Forms.Label();

            this.pnlPaymentBox = new System.Windows.Forms.Panel();
            this.pnlPriceBreakdown = new System.Windows.Forms.Panel();
            this.lblSubtotalTitle = new System.Windows.Forms.Label();
            this.lblSubtotalAmount = new System.Windows.Forms.Label();
            this.lblDiscountTitle = new System.Windows.Forms.Label();
            this.lblDiscountAmount = new System.Windows.Forms.Label();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblCashTitle = new System.Windows.Forms.Label();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.flpQuickCash = new System.Windows.Forms.FlowLayoutPanel();
            this.lblChangeTitle = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();

            this.pnlCheckoutAction = new System.Windows.Forms.Panel();
            this.tlpCheckoutButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnVietQR = new System.Windows.Forms.Button();
            this.lblStatusMsg = new System.Windows.Forms.Label();

            this.pnlMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();

            this.pnlScanCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScanQty)).BeginInit();
            this.pnlCartCard.SuspendLayout();
            this.pnlCartHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlCartFooter.SuspendLayout();

            this.pnlCheckoutCard.SuspendLayout();
            this.pnlCheckoutBody.SuspendLayout();
            this.pnlCustomerBox.SuspendLayout();
            this.pnlLoyaltyBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRedeemPoints)).BeginInit();
            this.pnlPaymentBox.SuspendLayout();
            this.pnlPriceBreakdown.SuspendLayout();
            this.pnlCheckoutAction.SuspendLayout();
            this.tlpCheckoutButtons.SuspendLayout();
            this.SuspendLayout();

            // 
            // FormPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(244, 247, 245); // Light cool gray
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.pnlMainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(980, 600);
            this.Name = "FormPOS";
            this.Text = "HỆ THỐNG BÁN HÀNG POS (BARCODE)";

            // 
            // pnlMainContainer (Container chính có padding)
            // 
            this.pnlMainContainer.BackColor = System.Drawing.Color.FromArgb(244, 247, 245);
            this.pnlMainContainer.Controls.Add(this.scMain);
            this.pnlMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainContainer.Name = "pnlMainContainer";
            this.pnlMainContainer.Padding = new System.Windows.Forms.Padding(14, 12, 14, 12);
            this.pnlMainContainer.Size = new System.Drawing.Size(1200, 750);
            this.pnlMainContainer.TabIndex = 0;

            // 
            // scMain (SplitContainer chia đôi Left ~65%, Right ~35%)
            // 
            this.scMain.BackColor = System.Drawing.Color.FromArgb(244, 247, 245);
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(14, 12);
            this.scMain.Name = "scMain";
            // scMain.Panel1 (Left side)
            this.scMain.Panel1.Controls.Add(this.pnlCartCard);
            this.scMain.Panel1.Controls.Add(this.pnlScanCard);
            // scMain.Panel2 (Right side)
            this.scMain.Panel2.Controls.Add(this.pnlCheckoutCard);
            this.scMain.Panel2MinSize = 350;
            this.scMain.Size = new System.Drawing.Size(1172, 726);
            this.scMain.SplitterDistance = 795;
            this.scMain.SplitterWidth = 10;
            this.scMain.TabIndex = 0;

            // =============================================================
            // CỘT TRÁI - 1. SCAN BARCODE CARD (Thanh quét mã vạch)
            // =============================================================
            this.pnlScanCard.BackColor = System.Drawing.Color.White;
            this.pnlScanCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlScanCard.Controls.Add(this.lblScanHint);
            this.pnlScanCard.Controls.Add(this.btnAddBarcode);
            this.pnlScanCard.Controls.Add(this.txtBarcode);
            this.pnlScanCard.Controls.Add(this.nudScanQty);
            this.pnlScanCard.Controls.Add(this.lblQtyScanTitle);
            this.pnlScanCard.Controls.Add(this.lblBarcodeTitle);
            this.pnlScanCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlScanCard.Location = new System.Drawing.Point(0, 0);
            this.pnlScanCard.Margin = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.pnlScanCard.Name = "pnlScanCard";
            this.pnlScanCard.Size = new System.Drawing.Size(795, 78);
            this.pnlScanCard.TabIndex = 0;

            // lblBarcodeTitle
            this.lblBarcodeTitle.AutoSize = true;
            this.lblBarcodeTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBarcodeTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblBarcodeTitle.Location = new System.Drawing.Point(12, 9);
            this.lblBarcodeTitle.Name = "lblBarcodeTitle";
            this.lblBarcodeTitle.Size = new System.Drawing.Size(320, 20);
            this.lblBarcodeTitle.Text = "🔍 QUÉT MÃ VẠCH SẢN PHẨM / TÌM KIẾM (F2):";

            // lblQtyScanTitle
            this.lblQtyScanTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblQtyScanTitle.AutoSize = true;
            this.lblQtyScanTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblQtyScanTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblQtyScanTitle.Location = new System.Drawing.Point(495, 9);
            this.lblQtyScanTitle.Name = "lblQtyScanTitle";
            this.lblQtyScanTitle.Size = new System.Drawing.Size(30, 19);
            this.lblQtyScanTitle.Text = "SL:";

            // txtBarcode (Ô nhập mã vạch chính)
            this.txtBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBarcode.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtBarcode.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtBarcode.Location = new System.Drawing.Point(14, 32);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(465, 34);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);

            // nudScanQty (Hộp chọn số lượng quét trước)
            this.nudScanQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudScanQty.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.nudScanQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudScanQty.Font = new System.Drawing.Font("Segoe UI", 11.5F, System.Drawing.FontStyle.Bold);
            this.nudScanQty.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.nudScanQty.Location = new System.Drawing.Point(490, 33);
            this.nudScanQty.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            this.nudScanQty.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudScanQty.Name = "nudScanQty";
            this.nudScanQty.Size = new System.Drawing.Size(58, 33);
            this.nudScanQty.TabIndex = 1;
            this.nudScanQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudScanQty.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnAddBarcode
            this.btnAddBarcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBarcode.BackColor = System.Drawing.Color.FromArgb(22, 163, 74); // Primary Green
            this.btnAddBarcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBarcode.FlatAppearance.BorderSize = 0;
            this.btnAddBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBarcode.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddBarcode.ForeColor = System.Drawing.Color.White;
            this.btnAddBarcode.Location = new System.Drawing.Point(558, 31);
            this.btnAddBarcode.Name = "btnAddBarcode";
            this.btnAddBarcode.Size = new System.Drawing.Size(115, 36);
            this.btnAddBarcode.TabIndex = 2;
            this.btnAddBarcode.Text = "+ Thêm (↵)";
            this.btnAddBarcode.UseVisualStyleBackColor = false;
            this.btnAddBarcode.Click += new System.EventHandler(this.btnAddBarcode_Click);

            // lblScanHint
            this.lblScanHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblScanHint.AutoSize = true;
            this.lblScanHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblScanHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblScanHint.Location = new System.Drawing.Point(680, 41);
            this.lblScanHint.Name = "lblScanHint";
            this.lblScanHint.Size = new System.Drawing.Size(100, 19);
            this.lblScanHint.Text = "Nhấn Enter ↵";

            // =============================================================
            // CỘT TRÁI - 2. CART CARD (Bảng giỏ hàng)
            // =============================================================
            this.pnlCartCard.BackColor = System.Drawing.Color.White;
            this.pnlCartCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCartCard.Controls.Add(this.dgvCart);
            this.pnlCartCard.Controls.Add(this.pnlCartFooter);
            this.pnlCartCard.Controls.Add(this.pnlCartHeader);
            this.pnlCartCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCartCard.Location = new System.Drawing.Point(0, 78);
            this.pnlCartCard.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlCartCard.Name = "pnlCartCard";
            this.pnlCartCard.Size = new System.Drawing.Size(795, 648);
            this.pnlCartCard.TabIndex = 1;

            // pnlCartHeader
            this.pnlCartHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlCartHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCartHeader.Controls.Add(this.lblCartBadge);
            this.pnlCartHeader.Controls.Add(this.lblCartHeader);
            this.pnlCartHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCartHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlCartHeader.Name = "pnlCartHeader";
            this.pnlCartHeader.Size = new System.Drawing.Size(793, 40);
            this.pnlCartHeader.TabIndex = 0;

            // lblCartHeader
            this.lblCartHeader.AutoSize = true;
            this.lblCartHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCartHeader.ForeColor = System.Drawing.Color.FromArgb(16, 42, 33);
            this.lblCartHeader.Location = new System.Drawing.Point(10, 9);
            this.lblCartHeader.Name = "lblCartHeader";
            this.lblCartHeader.Size = new System.Drawing.Size(305, 21);
            this.lblCartHeader.Text = "🛒 GIỎ HÀNG THANH TOÁN HIỆN TẠI";

            // lblCartBadge (Pill badge hiển thị tổng số món)
            this.lblCartBadge.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCartBadge.BackColor = System.Drawing.Color.FromArgb(220, 252, 231); // Green 100
            this.lblCartBadge.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCartBadge.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblCartBadge.Location = new System.Drawing.Point(680, 8);
            this.lblCartBadge.Name = "lblCartBadge";
            this.lblCartBadge.Size = new System.Drawing.Size(100, 22);
            this.lblCartBadge.Text = "0 sản phẩm";
            this.lblCartBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // dgvCart
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.AllowUserToResizeRows = false;
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvCellStyleHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleHeader.BackColor = System.Drawing.Color.FromArgb(16, 42, 33); // Dark Green Header
            dgvCellStyleHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvCellStyleHeader.ForeColor = System.Drawing.Color.White;
            dgvCellStyleHeader.SelectionBackColor = System.Drawing.Color.FromArgb(16, 42, 33);
            dgvCellStyleHeader.SelectionForeColor = System.Drawing.Color.White;
            dgvCellStyleHeader.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            this.dgvCart.ColumnHeadersHeight = 40;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCellStyleCell.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleCell.BackColor = System.Drawing.Color.White;
            dgvCellStyleCell.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvCellStyleCell.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dgvCellStyleCell.SelectionBackColor = System.Drawing.Color.FromArgb(220, 252, 231); // Green 100
            dgvCellStyleCell.SelectionForeColor = System.Drawing.Color.FromArgb(20, 83, 45);   // Dark Green
            this.dgvCart.DefaultCellStyle = dgvCellStyleCell;
            this.dgvCart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(229, 234, 231);
            this.dgvCart.Location = new System.Drawing.Point(0, 40);
            this.dgvCart.MultiSelect = false;
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowTemplate.Height = 36;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(793, 558);
            this.dgvCart.TabIndex = 1;

            // pnlCartFooter (Thanh thao tác giỏ hàng)
            this.pnlCartFooter.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlCartFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCartFooter.Controls.Add(this.btnClearCart);
            this.pnlCartFooter.Controls.Add(this.btnRemoveItem);
            this.pnlCartFooter.Controls.Add(this.btnDecreaseQty);
            this.pnlCartFooter.Controls.Add(this.btnIncreaseQty);
            this.pnlCartFooter.Controls.Add(this.lblItemCount);
            this.pnlCartFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCartFooter.Location = new System.Drawing.Point(0, 598);
            this.pnlCartFooter.Name = "pnlCartFooter";
            this.pnlCartFooter.Size = new System.Drawing.Size(793, 48);
            this.pnlCartFooter.TabIndex = 2;

            // lblItemCount
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblItemCount.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblItemCount.Location = new System.Drawing.Point(12, 13);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(200, 20);
            this.lblItemCount.Text = "Số loại: 0 | Tổng số lượng: 0";

            // btnIncreaseQty
            this.btnIncreaseQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIncreaseQty.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnIncreaseQty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncreaseQty.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnIncreaseQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncreaseQty.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnIncreaseQty.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnIncreaseQty.Location = new System.Drawing.Point(400, 8);
            this.btnIncreaseQty.Name = "btnIncreaseQty";
            this.btnIncreaseQty.Size = new System.Drawing.Size(88, 30);
            this.btnIncreaseQty.TabIndex = 0;
            this.btnIncreaseQty.Text = "➕ Tăng (F7)";
            this.btnIncreaseQty.UseVisualStyleBackColor = false;
            this.btnIncreaseQty.Click += new System.EventHandler(this.btnIncreaseQty_Click);

            // btnDecreaseQty
            this.btnDecreaseQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDecreaseQty.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnDecreaseQty.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDecreaseQty.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnDecreaseQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecreaseQty.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnDecreaseQty.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.btnDecreaseQty.Location = new System.Drawing.Point(495, 8);
            this.btnDecreaseQty.Name = "btnDecreaseQty";
            this.btnDecreaseQty.Size = new System.Drawing.Size(88, 30);
            this.btnDecreaseQty.TabIndex = 1;
            this.btnDecreaseQty.Text = "➖ Giảm (F6)";
            this.btnDecreaseQty.UseVisualStyleBackColor = false;
            this.btnDecreaseQty.Click += new System.EventHandler(this.btnDecreaseQty_Click);

            // btnRemoveItem
            this.btnRemoveItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(254, 242, 242);
            this.btnRemoveItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveItem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(254, 202, 202);
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnRemoveItem.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnRemoveItem.Location = new System.Drawing.Point(590, 8);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(98, 30);
            this.btnRemoveItem.TabIndex = 2;
            this.btnRemoveItem.Text = "🗑️ Xóa (Del)";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);

            // btnClearCart
            this.btnClearCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.btnClearCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnClearCart.Location = new System.Drawing.Point(695, 8);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(88, 30);
            this.btnClearCart.TabIndex = 3;
            this.btnClearCart.Text = "❌ Hủy (Esc)";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);

            // =============================================================
            // CỘT PHẢI - QUẦY THANH TOÁN (CHECKOUT CARD)
            // Cấu trúc phân tầng:
            // 1. Header (Dock: Top)
            // 2. Body scrollable (Dock: Fill)
            // 3. Nút Thanh toán CTA (Dock: Bottom) -> Luôn cố định, không bao giờ bị che khuất!
            // 4. Status Bar (Dock: Bottom)
            // =============================================================
            this.pnlCheckoutCard.BackColor = System.Drawing.Color.White;
            this.pnlCheckoutCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCheckoutCard.Controls.Add(this.pnlCheckoutBody);
            this.pnlCheckoutCard.Controls.Add(this.pnlCheckoutAction);
            this.pnlCheckoutCard.Controls.Add(this.lblStatusMsg);
            this.pnlCheckoutCard.Controls.Add(this.lblCheckoutHeader);
            this.pnlCheckoutCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCheckoutCard.Location = new System.Drawing.Point(0, 0);
            this.pnlCheckoutCard.Name = "pnlCheckoutCard";
            this.pnlCheckoutCard.Size = new System.Drawing.Size(367, 726);
            this.pnlCheckoutCard.TabIndex = 0;

            // lblCheckoutHeader (Tiêu đề trên cùng cột phải)
            this.lblCheckoutHeader.BackColor = System.Drawing.Color.FromArgb(16, 42, 33); // Dark Green
            this.lblCheckoutHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckoutHeader.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblCheckoutHeader.ForeColor = System.Drawing.Color.White;
            this.lblCheckoutHeader.Location = new System.Drawing.Point(0, 0);
            this.lblCheckoutHeader.Name = "lblCheckoutHeader";
            this.lblCheckoutHeader.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.lblCheckoutHeader.Size = new System.Drawing.Size(365, 40);
            this.lblCheckoutHeader.Text = "💳 QUẦY THANH TOÁN (CHECKOUT)";
            this.lblCheckoutHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // pnlCheckoutBody (Thân giữa cuộn mượt khi màn hình nhỏ)
            this.pnlCheckoutBody.AutoScroll = true;
            this.pnlCheckoutBody.BackColor = System.Drawing.Color.White;
            this.pnlCheckoutBody.Controls.Add(this.pnlPaymentBox);
            this.pnlCheckoutBody.Controls.Add(this.pnlLoyaltyBox);
            this.pnlCheckoutBody.Controls.Add(this.pnlCustomerBox);
            this.pnlCheckoutBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCheckoutBody.Location = new System.Drawing.Point(0, 40);
            this.pnlCheckoutBody.Name = "pnlCheckoutBody";
            this.pnlCheckoutBody.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            this.pnlCheckoutBody.Size = new System.Drawing.Size(365, 598);
            this.pnlCheckoutBody.TabIndex = 0;

            // -------------------------------------------------------------
            // SECTION 1: KHÁCH HÀNG THÀNH VIÊN
            // -------------------------------------------------------------
            this.pnlCustomerBox.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.pnlCustomerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustomerBox.Controls.Add(this.lblCustomerRank);
            this.pnlCustomerBox.Controls.Add(this.lblCustomerName);
            this.pnlCustomerBox.Controls.Add(this.lblCustomerNameTitle);
            this.pnlCustomerBox.Controls.Add(this.lblCustomerAvatar);
            this.pnlCustomerBox.Controls.Add(this.btnSearchCustomer);
            this.pnlCustomerBox.Controls.Add(this.txtCustomerPhone);
            this.pnlCustomerBox.Controls.Add(this.lblPhoneTitle);
            this.pnlCustomerBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCustomerBox.Location = new System.Drawing.Point(8, 6);
            this.pnlCustomerBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.pnlCustomerBox.Name = "pnlCustomerBox";
            this.pnlCustomerBox.Size = new System.Drawing.Size(349, 108);
            this.pnlCustomerBox.TabIndex = 0;

            // lblPhoneTitle
            this.lblPhoneTitle.AutoSize = true;
            this.lblPhoneTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPhoneTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPhoneTitle.Location = new System.Drawing.Point(8, 6);
            this.lblPhoneTitle.Name = "lblPhoneTitle";
            this.lblPhoneTitle.Size = new System.Drawing.Size(160, 20);
            this.lblPhoneTitle.Text = "SĐT Khách hàng (F4):";

            // txtCustomerPhone
            this.txtCustomerPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerPhone.BackColor = System.Drawing.Color.White;
            this.txtCustomerPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(10, 26);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(235, 29);
            this.txtCustomerPhone.TabIndex = 0;
            this.txtCustomerPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerPhone_KeyDown);

            // btnSearchCustomer
            this.btnSearchCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchCustomer.BackColor = System.Drawing.Color.FromArgb(16, 42, 33);
            this.btnSearchCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchCustomer.FlatAppearance.BorderSize = 0;
            this.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSearchCustomer.Location = new System.Drawing.Point(252, 25);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(86, 31);
            this.btnSearchCustomer.TabIndex = 1;
            this.btnSearchCustomer.Text = "🔍 Tìm";
            this.btnSearchCustomer.UseVisualStyleBackColor = false;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);

            // lblCustomerAvatar
            this.lblCustomerAvatar.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.lblCustomerAvatar.Location = new System.Drawing.Point(8, 60);
            this.lblCustomerAvatar.Name = "lblCustomerAvatar";
            this.lblCustomerAvatar.Size = new System.Drawing.Size(28, 32);
            this.lblCustomerAvatar.Text = "👤";
            this.lblCustomerAvatar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblCustomerNameTitle
            this.lblCustomerNameTitle.AutoSize = true;
            this.lblCustomerNameTitle.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblCustomerNameTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCustomerNameTitle.Location = new System.Drawing.Point(38, 63);
            this.lblCustomerNameTitle.Name = "lblCustomerNameTitle";
            this.lblCustomerNameTitle.Size = new System.Drawing.Size(73, 19);
            this.lblCustomerNameTitle.Text = "Khách:";

            // lblCustomerName
            this.lblCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCustomerName.AutoEllipsis = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(16, 42, 33);
            this.lblCustomerName.Location = new System.Drawing.Point(90, 62);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(248, 20);
            this.lblCustomerName.Text = "Khách hàng vãng lai";

            // lblCustomerRank
            this.lblCustomerRank.AutoSize = true;
            this.lblCustomerRank.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.lblCustomerRank.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6); // Amber
            this.lblCustomerRank.Location = new System.Drawing.Point(38, 83);
            this.lblCustomerRank.Name = "lblCustomerRank";
            this.lblCustomerRank.Size = new System.Drawing.Size(130, 19);
            this.lblCustomerRank.Text = "Hạng: Chuẩn (0 đ)";

            // -------------------------------------------------------------
            // SECTION 2: ĐỔI ĐIỂM THƯỞNG TRỪ TIỀN (ITEM 47)
            // -------------------------------------------------------------
            this.pnlLoyaltyBox.BackColor = System.Drawing.Color.FromArgb(255, 251, 235); // Amber 50
            this.pnlLoyaltyBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLoyaltyBox.Controls.Add(this.lblLoyaltyHint);
            this.pnlLoyaltyBox.Controls.Add(this.lblRedeemDiscount);
            this.pnlLoyaltyBox.Controls.Add(this.btnRedeem50);
            this.pnlLoyaltyBox.Controls.Add(this.nudRedeemPoints);
            this.pnlLoyaltyBox.Controls.Add(this.chkUsePoints);
            this.pnlLoyaltyBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLoyaltyBox.Enabled = false;
            this.pnlLoyaltyBox.Location = new System.Drawing.Point(8, 120);
            this.pnlLoyaltyBox.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.pnlLoyaltyBox.Name = "pnlLoyaltyBox";
            this.pnlLoyaltyBox.Size = new System.Drawing.Size(349, 76);
            this.pnlLoyaltyBox.TabIndex = 1;

            // chkUsePoints
            this.chkUsePoints.AutoSize = true;
            this.chkUsePoints.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.chkUsePoints.ForeColor = System.Drawing.Color.FromArgb(146, 64, 14); // Amber 800
            this.chkUsePoints.Location = new System.Drawing.Point(10, 6);
            this.chkUsePoints.Name = "chkUsePoints";
            this.chkUsePoints.Size = new System.Drawing.Size(205, 24);
            this.chkUsePoints.TabIndex = 0;
            this.chkUsePoints.Text = "🎁 Đổi điểm thưởng trừ tiền";
            this.chkUsePoints.UseVisualStyleBackColor = true;
            this.chkUsePoints.CheckedChanged += new System.EventHandler(this.chkUsePoints_CheckedChanged);

            // nudRedeemPoints
            this.nudRedeemPoints.BackColor = System.Drawing.Color.White;
            this.nudRedeemPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudRedeemPoints.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.nudRedeemPoints.ForeColor = System.Drawing.Color.FromArgb(146, 64, 14);
            this.nudRedeemPoints.Location = new System.Drawing.Point(10, 30);
            this.nudRedeemPoints.Maximum = new decimal(new int[] { 0, 0, 0, 0 });
            this.nudRedeemPoints.Name = "nudRedeemPoints";
            this.nudRedeemPoints.Size = new System.Drawing.Size(68, 27);
            this.nudRedeemPoints.TabIndex = 1;
            this.nudRedeemPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudRedeemPoints.ValueChanged += new System.EventHandler(this.nudRedeemPoints_ValueChanged);

            // btnRedeem50
            this.btnRedeem50.BackColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.btnRedeem50.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRedeem50.FlatAppearance.BorderSize = 0;
            this.btnRedeem50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedeem50.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btnRedeem50.ForeColor = System.Drawing.Color.White;
            this.btnRedeem50.Location = new System.Drawing.Point(84, 30);
            this.btnRedeem50.Name = "btnRedeem50";
            this.btnRedeem50.Size = new System.Drawing.Size(76, 27);
            this.btnRedeem50.TabIndex = 2;
            this.btnRedeem50.Text = "⚡ 50 điểm";
            this.btnRedeem50.UseVisualStyleBackColor = false;
            this.btnRedeem50.Click += new System.EventHandler(this.btnRedeem50_Click);

            // lblRedeemDiscount
            this.lblRedeemDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRedeemDiscount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblRedeemDiscount.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblRedeemDiscount.Location = new System.Drawing.Point(165, 30);
            this.lblRedeemDiscount.Name = "lblRedeemDiscount";
            this.lblRedeemDiscount.Size = new System.Drawing.Size(175, 24);
            this.lblRedeemDiscount.Text = "-0 đ";
            this.lblRedeemDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblLoyaltyHint
            this.lblLoyaltyHint.AutoSize = true;
            this.lblLoyaltyHint.Font = new System.Drawing.Font("Segoe UI", 7.5F);
            this.lblLoyaltyHint.ForeColor = System.Drawing.Color.FromArgb(180, 83, 9);
            this.lblLoyaltyHint.Location = new System.Drawing.Point(10, 56);
            this.lblLoyaltyHint.Name = "lblLoyaltyHint";
            this.lblLoyaltyHint.Size = new System.Drawing.Size(155, 17);
            this.lblLoyaltyHint.Text = "● 1 điểm = 1.000 VNĐ";

            // -------------------------------------------------------------
            // SECTION 3: TÍNH TIỀN & THỐI TIỀN
            // -------------------------------------------------------------
            this.pnlPaymentBox.BackColor = System.Drawing.Color.White;
            this.pnlPaymentBox.Controls.Add(this.lblChange);
            this.pnlPaymentBox.Controls.Add(this.lblChangeTitle);
            this.pnlPaymentBox.Controls.Add(this.flpQuickCash);
            this.pnlPaymentBox.Controls.Add(this.txtCashReceived);
            this.pnlPaymentBox.Controls.Add(this.lblCashTitle);
            this.pnlPaymentBox.Controls.Add(this.lblTotalAmount);
            this.pnlPaymentBox.Controls.Add(this.lblTotalTitle);
            this.pnlPaymentBox.Controls.Add(this.pnlPriceBreakdown);
            this.pnlPaymentBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPaymentBox.Location = new System.Drawing.Point(8, 202);
            this.pnlPaymentBox.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlPaymentBox.Name = "pnlPaymentBox";
            this.pnlPaymentBox.Size = new System.Drawing.Size(349, 290);
            this.pnlPaymentBox.TabIndex = 2;

            // pnlPriceBreakdown (Bảng chi tiết tiền hàng & giảm giá)
            this.pnlPriceBreakdown.Controls.Add(this.lblDiscountAmount);
            this.pnlPriceBreakdown.Controls.Add(this.lblDiscountTitle);
            this.pnlPriceBreakdown.Controls.Add(this.lblSubtotalAmount);
            this.pnlPriceBreakdown.Controls.Add(this.lblSubtotalTitle);
            this.pnlPriceBreakdown.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPriceBreakdown.Location = new System.Drawing.Point(0, 0);
            this.pnlPriceBreakdown.Name = "pnlPriceBreakdown";
            this.pnlPriceBreakdown.Size = new System.Drawing.Size(349, 44);
            this.pnlPriceBreakdown.TabIndex = 0;

            // lblSubtotalTitle
            this.lblSubtotalTitle.AutoSize = true;
            this.lblSubtotalTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblSubtotalTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubtotalTitle.Location = new System.Drawing.Point(2, 2);
            this.lblSubtotalTitle.Name = "lblSubtotalTitle";
            this.lblSubtotalTitle.Size = new System.Drawing.Size(125, 20);
            this.lblSubtotalTitle.Text = "Tiền hàng tạm tính:";

            // lblSubtotalAmount
            this.lblSubtotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubtotalAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSubtotalAmount.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.lblSubtotalAmount.Location = new System.Drawing.Point(165, 2);
            this.lblSubtotalAmount.Name = "lblSubtotalAmount";
            this.lblSubtotalAmount.Size = new System.Drawing.Size(180, 18);
            this.lblSubtotalAmount.Text = "0 đ";
            this.lblSubtotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblDiscountTitle
            this.lblDiscountTitle.AutoSize = true;
            this.lblDiscountTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblDiscountTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblDiscountTitle.Location = new System.Drawing.Point(2, 22);
            this.lblDiscountTitle.Name = "lblDiscountTitle";
            this.lblDiscountTitle.Size = new System.Drawing.Size(140, 20);
            this.lblDiscountTitle.Text = "Giảm trừ điểm (F8):";

            // lblDiscountAmount
            this.lblDiscountAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDiscountAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiscountAmount.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblDiscountAmount.Location = new System.Drawing.Point(165, 22);
            this.lblDiscountAmount.Name = "lblDiscountAmount";
            this.lblDiscountAmount.Size = new System.Drawing.Size(180, 18);
            this.lblDiscountAmount.Text = "-0 đ";
            this.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblTotalTitle
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTotalTitle.Location = new System.Drawing.Point(2, 48);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(185, 20);
            this.lblTotalTitle.Text = "TỔNG CẦN THANH TOÁN:";

            // lblTotalAmount (Ô tổng tiền to nổi bật)
            this.lblTotalAmount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmount.BackColor = System.Drawing.Color.FromArgb(240, 253, 244); // Green 50
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74); // Green 600
            this.lblTotalAmount.Location = new System.Drawing.Point(2, 70);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblTotalAmount.Size = new System.Drawing.Size(345, 46);
            this.lblTotalAmount.Text = "0 đ";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblCashTitle
            this.lblCashTitle.AutoSize = true;
            this.lblCashTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblCashTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCashTitle.Location = new System.Drawing.Point(2, 122);
            this.lblCashTitle.Name = "lblCashTitle";
            this.lblCashTitle.Size = new System.Drawing.Size(121, 20);
            this.lblCashTitle.Text = "Tiền khách đưa:";

            // txtCashReceived
            this.txtCashReceived.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashReceived.BackColor = System.Drawing.Color.White;
            this.txtCashReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCashReceived.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.txtCashReceived.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtCashReceived.Location = new System.Drawing.Point(2, 142);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(345, 36);
            this.txtCashReceived.TabIndex = 1;
            this.txtCashReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);

            // flpQuickCash (Thanh phím chọn tiền nhanh)
            this.flpQuickCash.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpQuickCash.Location = new System.Drawing.Point(2, 182);
            this.flpQuickCash.Name = "flpQuickCash";
            this.flpQuickCash.Size = new System.Drawing.Size(345, 34);
            this.flpQuickCash.TabIndex = 2;
            this.flpQuickCash.WrapContents = false;

            // lblChangeTitle
            this.lblChangeTitle.AutoSize = true;
            this.lblChangeTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblChangeTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblChangeTitle.Location = new System.Drawing.Point(2, 220);
            this.lblChangeTitle.Name = "lblChangeTitle";
            this.lblChangeTitle.Size = new System.Drawing.Size(121, 20);
            this.lblChangeTitle.Text = "Tiền thừa trả lại:";

            // lblChange (Ô tiền thừa thối lại)
            this.lblChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChange.BackColor = System.Drawing.Color.FromArgb(240, 253, 244);
            this.lblChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.lblChange.Location = new System.Drawing.Point(2, 240);
            this.lblChange.Name = "lblChange";
            this.lblChange.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblChange.Size = new System.Drawing.Size(345, 40);
            this.lblChange.Text = "0 đ";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // =============================================================
            // CỘT PHẢI - NÚT THANH TOÁN PINNED (TIỀN MẶT & VIETQR DUAL CTA)
            // =============================================================
            this.pnlCheckoutAction.BackColor = System.Drawing.Color.White;
            this.pnlCheckoutAction.Controls.Add(this.tlpCheckoutButtons);
            this.pnlCheckoutAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCheckoutAction.Location = new System.Drawing.Point(0, 634);
            this.pnlCheckoutAction.Name = "pnlCheckoutAction";
            this.pnlCheckoutAction.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.pnlCheckoutAction.Size = new System.Drawing.Size(365, 66);
            this.pnlCheckoutAction.TabIndex = 1;

            // tlpCheckoutButtons
            this.tlpCheckoutButtons.ColumnCount = 2;
            this.tlpCheckoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCheckoutButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCheckoutButtons.Controls.Add(this.btnCheckout, 0, 0);
            this.tlpCheckoutButtons.Controls.Add(this.btnVietQR, 1, 0);
            this.tlpCheckoutButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCheckoutButtons.Location = new System.Drawing.Point(8, 5);
            this.tlpCheckoutButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCheckoutButtons.Name = "tlpCheckoutButtons";
            this.tlpCheckoutButtons.RowCount = 1;
            this.tlpCheckoutButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCheckoutButtons.Size = new System.Drawing.Size(349, 56);
            this.tlpCheckoutButtons.TabIndex = 0;

            // btnCheckout (Nút thanh toán tiền mặt F9)
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(22, 163, 74); // Emerald 600
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(170, 56);
            this.btnCheckout.TabIndex = 0;
            this.btnCheckout.Text = "💵 TIỀN MẶT (F9)";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // btnVietQR (Nút thanh toán chuyển khoản VietQR F10)
            this.btnVietQR.BackColor = System.Drawing.Color.FromArgb(37, 99, 235); // Blue 600
            this.btnVietQR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVietQR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnVietQR.FlatAppearance.BorderSize = 0;
            this.btnVietQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVietQR.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnVietQR.ForeColor = System.Drawing.Color.White;
            this.btnVietQR.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.btnVietQR.Name = "btnVietQR";
            this.btnVietQR.Size = new System.Drawing.Size(171, 56);
            this.btnVietQR.TabIndex = 1;
            this.btnVietQR.Text = "📱 VIETQR (F10)";
            this.btnVietQR.UseVisualStyleBackColor = false;
            this.btnVietQR.Click += new System.EventHandler(this.btnVietQR_Click);

            // lblStatusMsg (Thanh thông báo trạng thái dưới cùng)
            this.lblStatusMsg.BackColor = System.Drawing.Color.FromArgb(248, 250, 249);
            this.lblStatusMsg.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatusMsg.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatusMsg.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblStatusMsg.Location = new System.Drawing.Point(0, 700);
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(365, 24);
            this.lblStatusMsg.Text = "● Sẵn sàng quét mã sản phẩm...";
            this.lblStatusMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // Finalize FormPOS
            // 
            this.pnlMainContainer.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);

            this.pnlScanCard.ResumeLayout(false);
            this.pnlScanCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudScanQty)).EndInit();
            this.pnlCartCard.ResumeLayout(false);
            this.pnlCartHeader.ResumeLayout(false);
            this.pnlCartHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlCartFooter.ResumeLayout(false);
            this.pnlCartFooter.PerformLayout();

            this.pnlCheckoutCard.ResumeLayout(false);
            this.pnlCheckoutBody.ResumeLayout(false);
            this.pnlCustomerBox.ResumeLayout(false);
            this.pnlCustomerBox.PerformLayout();
            this.pnlLoyaltyBox.ResumeLayout(false);
            this.pnlLoyaltyBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRedeemPoints)).EndInit();
            this.pnlPaymentBox.ResumeLayout(false);
            this.pnlPaymentBox.PerformLayout();
            this.pnlPriceBreakdown.ResumeLayout(false);
            this.pnlPriceBreakdown.PerformLayout();
            this.tlpCheckoutButtons.ResumeLayout(false);
            this.pnlCheckoutAction.ResumeLayout(false);

            this.ResumeLayout(false);
        }

        #endregion
    }
}
