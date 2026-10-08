namespace MiniSupermarket.WinForms
{
    partial class FormPOS
    {
        private System.ComponentModel.IContainer components = null;

        // Header / Barcode Scanner Card
        private System.Windows.Forms.Panel pnlScanCard;
        private System.Windows.Forms.Label lblBarcodeTitle;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button btnAddBarcode;
        private System.Windows.Forms.Label lblScanHint;

        // Left Content (Cart DataGridView & Action buttons)
        private System.Windows.Forms.Panel pnlCartCard;
        private System.Windows.Forms.Label lblCartHeader;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Panel pnlCartFooter;
        private System.Windows.Forms.Button btnClearCart;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Label lblItemCount;

        // Right Content (Checkout info card)
        private System.Windows.Forms.Panel pnlCheckoutCard;
        private System.Windows.Forms.Label lblCheckoutHeader;
        
        // Customer section
        private System.Windows.Forms.Panel pnlCustomerBox;
        private System.Windows.Forms.Label lblPhoneTitle;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Label lblCustomerNameTitle;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblCustomerRank;

        // Payment section
        private System.Windows.Forms.Panel pnlPaymentBox;
        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.Label lblCashTitle;
        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.FlowLayoutPanel flpQuickCash;
        private System.Windows.Forms.Label lblChangeTitle;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Button btnCheckout;
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

            this.pnlScanCard = new System.Windows.Forms.Panel();
            this.lblBarcodeTitle = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.btnAddBarcode = new System.Windows.Forms.Button();
            this.lblScanHint = new System.Windows.Forms.Label();

            this.pnlCartCard = new System.Windows.Forms.Panel();
            this.lblCartHeader = new System.Windows.Forms.Label();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.pnlCartFooter = new System.Windows.Forms.Panel();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();

            this.pnlCheckoutCard = new System.Windows.Forms.Panel();
            this.lblCheckoutHeader = new System.Windows.Forms.Label();
            
            this.pnlCustomerBox = new System.Windows.Forms.Panel();
            this.lblPhoneTitle = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.lblCustomerNameTitle = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblCustomerRank = new System.Windows.Forms.Label();

            this.pnlPaymentBox = new System.Windows.Forms.Panel();
            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblCashTitle = new System.Windows.Forms.Label();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.flpQuickCash = new System.Windows.Forms.FlowLayoutPanel();
            this.lblChangeTitle = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.lblStatusMsg = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.pnlScanCard.SuspendLayout();
            this.pnlCartCard.SuspendLayout();
            this.pnlCartFooter.SuspendLayout();
            this.pnlCheckoutCard.SuspendLayout();
            this.pnlCustomerBox.SuspendLayout();
            this.pnlPaymentBox.SuspendLayout();
            this.SuspendLayout();

            // 
            // FormPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249); // Slate 100
            this.ClientSize = new System.Drawing.Size(1050, 660);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPOS";
            this.Text = "HỆ THỐNG BÁN HÀNG POS (BARCODE)";

            // 
            // pnlScanCard (Thanh quét mã vạch trên cùng bên trái)
            // 
            this.pnlScanCard.BackColor = System.Drawing.Color.White;
            this.pnlScanCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlScanCard.Location = new System.Drawing.Point(16, 12);
            this.pnlScanCard.Name = "pnlScanCard";
            this.pnlScanCard.Size = new System.Drawing.Size(664, 76);
            this.pnlScanCard.TabIndex = 0;
            this.pnlScanCard.Controls.Add(this.lblBarcodeTitle);
            this.pnlScanCard.Controls.Add(this.txtBarcode);
            this.pnlScanCard.Controls.Add(this.btnAddBarcode);
            this.pnlScanCard.Controls.Add(this.lblScanHint);

            // lblBarcodeTitle
            this.lblBarcodeTitle.AutoSize = true;
            this.lblBarcodeTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblBarcodeTitle.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblBarcodeTitle.Location = new System.Drawing.Point(12, 10);
            this.lblBarcodeTitle.Name = "lblBarcodeTitle";
            this.lblBarcodeTitle.Size = new System.Drawing.Size(200, 20);
            this.lblBarcodeTitle.Text = "🔍 Quét mã vạch sản phẩm (F2):";

            // txtBarcode
            this.txtBarcode.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.txtBarcode.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtBarcode.Location = new System.Drawing.Point(14, 34);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(430, 34);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);

            // btnAddBarcode
            this.btnAddBarcode.BackColor = System.Drawing.Color.FromArgb(37, 99, 235); // Blue 600
            this.btnAddBarcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBarcode.FlatAppearance.BorderSize = 0;
            this.btnAddBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBarcode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddBarcode.ForeColor = System.Drawing.Color.White;
            this.btnAddBarcode.Location = new System.Drawing.Point(452, 34);
            this.btnAddBarcode.Name = "btnAddBarcode";
            this.btnAddBarcode.Size = new System.Drawing.Size(100, 34);
            this.btnAddBarcode.TabIndex = 1;
            this.btnAddBarcode.Text = "+ Thêm";
            this.btnAddBarcode.UseVisualStyleBackColor = false;
            this.btnAddBarcode.Click += new System.EventHandler(this.btnAddBarcode_Click);

            // lblScanHint
            this.lblScanHint.AutoSize = true;
            this.lblScanHint.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblScanHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblScanHint.Location = new System.Drawing.Point(558, 42);
            this.lblScanHint.Name = "lblScanHint";
            this.lblScanHint.Size = new System.Drawing.Size(95, 19);
            this.lblScanHint.Text = "Nhấn Enter ↵";

            // 
            // pnlCartCard (Khu vực giỏ hàng)
            // 
            this.pnlCartCard.BackColor = System.Drawing.Color.White;
            this.pnlCartCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCartCard.Location = new System.Drawing.Point(16, 96);
            this.pnlCartCard.Name = "pnlCartCard";
            this.pnlCartCard.Size = new System.Drawing.Size(664, 552);
            this.pnlCartCard.TabIndex = 1;
            this.pnlCartCard.Controls.Add(this.dgvCart);
            this.pnlCartCard.Controls.Add(this.lblCartHeader);
            this.pnlCartCard.Controls.Add(this.pnlCartFooter);

            // lblCartHeader
            this.lblCartHeader.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.lblCartHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCartHeader.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCartHeader.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblCartHeader.Location = new System.Drawing.Point(0, 0);
            this.lblCartHeader.Name = "lblCartHeader";
            this.lblCartHeader.Padding = new System.Windows.Forms.Padding(14, 0, 0, 0);
            this.lblCartHeader.Size = new System.Drawing.Size(662, 40);
            this.lblCartHeader.Text = "🛒 GIỎ HÀNG THANH TOÁN HIỆN TẠI";
            this.lblCartHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // dgvCart
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.AllowUserToDeleteRows = false;
            this.dgvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCart.BackgroundColor = System.Drawing.Color.White;
            this.dgvCart.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCart.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCart.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dgvCellStyleHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleHeader.BackColor = System.Drawing.Color.FromArgb(15, 23, 42); // Slate 900
            dgvCellStyleHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dgvCellStyleHeader.ForeColor = System.Drawing.Color.White;
            dgvCellStyleHeader.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            dgvCellStyleHeader.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCart.ColumnHeadersDefaultCellStyle = dgvCellStyleHeader;
            this.dgvCart.ColumnHeadersHeight = 38;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCellStyleCell.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dgvCellStyleCell.BackColor = System.Drawing.Color.White;
            dgvCellStyleCell.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dgvCellStyleCell.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgvCellStyleCell.SelectionBackColor = System.Drawing.Color.FromArgb(224, 231, 255); // Indigo 100
            dgvCellStyleCell.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dgvCellStyleCell.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.dgvCart.DefaultCellStyle = dgvCellStyleCell;
            this.dgvCart.EnableHeadersVisualStyles = false;
            this.dgvCart.GridColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.dgvCart.Location = new System.Drawing.Point(0, 42);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.RowTemplate.Height = 36;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(662, 456);
            this.dgvCart.TabIndex = 0;

            // pnlCartFooter
            this.pnlCartFooter.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlCartFooter.Controls.Add(this.lblItemCount);
            this.pnlCartFooter.Controls.Add(this.btnRemoveItem);
            this.pnlCartFooter.Controls.Add(this.btnClearCart);
            this.pnlCartFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlCartFooter.Location = new System.Drawing.Point(0, 498);
            this.pnlCartFooter.Name = "pnlCartFooter";
            this.pnlCartFooter.Size = new System.Drawing.Size(662, 52);
            this.pnlCartFooter.TabIndex = 2;

            // lblItemCount
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblItemCount.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblItemCount.Location = new System.Drawing.Point(14, 16);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(155, 21);
            this.lblItemCount.Text = "Số loại mặt hàng: 0";

            // btnRemoveItem
            this.btnRemoveItem.BackColor = System.Drawing.Color.FromArgb(239, 68, 68); // Red 500
            this.btnRemoveItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemoveItem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveItem.ForeColor = System.Drawing.Color.White;
            this.btnRemoveItem.Location = new System.Drawing.Point(400, 10);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(120, 32);
            this.btnRemoveItem.TabIndex = 1;
            this.btnRemoveItem.Text = "🗑️ Xóa dòng";
            this.btnRemoveItem.UseVisualStyleBackColor = false;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);

            // btnClearCart
            this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(148, 163, 184); // Slate 400
            this.btnClearCart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClearCart.FlatAppearance.BorderSize = 0;
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(528, 10);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(120, 32);
            this.btnClearCart.TabIndex = 0;
            this.btnClearCart.Text = "❌ Hủy giỏ";
            this.btnClearCart.UseVisualStyleBackColor = false;
            this.btnClearCart.Click += new System.EventHandler(this.btnClearCart_Click);

            // 
            // pnlCheckoutCard (Cột Phải - Thanh toán & Khách hàng)
            // 
            this.pnlCheckoutCard.BackColor = System.Drawing.Color.White;
            this.pnlCheckoutCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCheckoutCard.Location = new System.Drawing.Point(692, 12);
            this.pnlCheckoutCard.Name = "pnlCheckoutCard";
            this.pnlCheckoutCard.Size = new System.Drawing.Size(344, 636);
            this.pnlCheckoutCard.TabIndex = 2;
            this.pnlCheckoutCard.Controls.Add(this.lblCheckoutHeader);
            this.pnlCheckoutCard.Controls.Add(this.pnlCustomerBox);
            this.pnlCheckoutCard.Controls.Add(this.pnlPaymentBox);
            this.pnlCheckoutCard.Controls.Add(this.lblStatusMsg);

            // lblCheckoutHeader
            this.lblCheckoutHeader.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblCheckoutHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCheckoutHeader.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCheckoutHeader.ForeColor = System.Drawing.Color.White;
            this.lblCheckoutHeader.Location = new System.Drawing.Point(0, 0);
            this.lblCheckoutHeader.Name = "lblCheckoutHeader";
            this.lblCheckoutHeader.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.lblCheckoutHeader.Size = new System.Drawing.Size(342, 45);
            this.lblCheckoutHeader.Text = "💳 QUẦY THANH TOÁN";
            this.lblCheckoutHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // 
            // pnlCustomerBox (Hộp thông tin thành viên / khách hàng)
            // 
            this.pnlCustomerBox.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.pnlCustomerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCustomerBox.Controls.Add(this.lblPhoneTitle);
            this.pnlCustomerBox.Controls.Add(this.txtCustomerPhone);
            this.pnlCustomerBox.Controls.Add(this.btnSearchCustomer);
            this.pnlCustomerBox.Controls.Add(this.lblCustomerNameTitle);
            this.pnlCustomerBox.Controls.Add(this.lblCustomerName);
            this.pnlCustomerBox.Controls.Add(this.lblCustomerRank);
            this.pnlCustomerBox.Location = new System.Drawing.Point(14, 55);
            this.pnlCustomerBox.Name = "pnlCustomerBox";
            this.pnlCustomerBox.Size = new System.Drawing.Size(314, 115);
            this.pnlCustomerBox.TabIndex = 0;

            // lblPhoneTitle
            this.lblPhoneTitle.AutoSize = true;
            this.lblPhoneTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Bold);
            this.lblPhoneTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblPhoneTitle.Location = new System.Drawing.Point(10, 8);
            this.lblPhoneTitle.Name = "lblPhoneTitle";
            this.lblPhoneTitle.Size = new System.Drawing.Size(126, 20);
            this.lblPhoneTitle.Text = "SĐT Khách hàng:";

            // txtCustomerPhone
            this.txtCustomerPhone.BackColor = System.Drawing.Color.White;
            this.txtCustomerPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(12, 30);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(210, 30);
            this.txtCustomerPhone.TabIndex = 0;
            this.txtCustomerPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerPhone_KeyDown);

            // btnSearchCustomer
            this.btnSearchCustomer.BackColor = System.Drawing.Color.FromArgb(79, 70, 229); // Indigo 600
            this.btnSearchCustomer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearchCustomer.FlatAppearance.BorderSize = 0;
            this.btnSearchCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearchCustomer.ForeColor = System.Drawing.Color.White;
            this.btnSearchCustomer.Location = new System.Drawing.Point(228, 30);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(72, 30);
            this.btnSearchCustomer.TabIndex = 1;
            this.btnSearchCustomer.Text = "Tìm";
            this.btnSearchCustomer.UseVisualStyleBackColor = false;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);

            // lblCustomerNameTitle
            this.lblCustomerNameTitle.AutoSize = true;
            this.lblCustomerNameTitle.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblCustomerNameTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblCustomerNameTitle.Location = new System.Drawing.Point(10, 68);
            this.lblCustomerNameTitle.Name = "lblCustomerNameTitle";
            this.lblCustomerNameTitle.Size = new System.Drawing.Size(79, 20);
            this.lblCustomerNameTitle.Text = "Tên khách:";

            // lblCustomerName
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblCustomerName.Location = new System.Drawing.Point(92, 67);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(117, 21);
            this.lblCustomerName.Text = "Khách vãng lai";

            // lblCustomerRank
            this.lblCustomerRank.AutoSize = true;
            this.lblCustomerRank.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblCustomerRank.ForeColor = System.Drawing.Color.FromArgb(217, 119, 6);
            this.lblCustomerRank.Location = new System.Drawing.Point(10, 89);
            this.lblCustomerRank.Name = "lblCustomerRank";
            this.lblCustomerRank.Size = new System.Drawing.Size(95, 19);
            this.lblCustomerRank.Text = "Hạng: Chuẩn";

            // 
            // pnlPaymentBox (Hộp tính tiền, số tiền trả và thối)
            // 
            this.pnlPaymentBox.Controls.Add(this.lblTotalTitle);
            this.pnlPaymentBox.Controls.Add(this.lblTotalAmount);
            this.pnlPaymentBox.Controls.Add(this.lblCashTitle);
            this.pnlPaymentBox.Controls.Add(this.txtCashReceived);
            this.pnlPaymentBox.Controls.Add(this.flpQuickCash);
            this.pnlPaymentBox.Controls.Add(this.lblChangeTitle);
            this.pnlPaymentBox.Controls.Add(this.lblChange);
            this.pnlPaymentBox.Controls.Add(this.btnCheckout);
            this.pnlPaymentBox.Location = new System.Drawing.Point(14, 180);
            this.pnlPaymentBox.Name = "pnlPaymentBox";
            this.pnlPaymentBox.Size = new System.Drawing.Size(314, 410);
            this.pnlPaymentBox.TabIndex = 1;

            // lblTotalTitle
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblTotalTitle.Location = new System.Drawing.Point(4, 4);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(161, 21);
            this.lblTotalTitle.Text = "TỔNG THANH TOÁN:";

            // lblTotalAmount
            this.lblTotalAmount.BackColor = System.Drawing.Color.FromArgb(254, 242, 242); // Red 50
            this.lblTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38); // Red 600
            this.lblTotalAmount.Location = new System.Drawing.Point(4, 28);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblTotalAmount.Size = new System.Drawing.Size(306, 50);
            this.lblTotalAmount.Text = "0 đ";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblCashTitle
            this.lblCashTitle.AutoSize = true;
            this.lblCashTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCashTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblCashTitle.Location = new System.Drawing.Point(4, 90);
            this.lblCashTitle.Name = "lblCashTitle";
            this.lblCashTitle.Size = new System.Drawing.Size(121, 20);
            this.lblCashTitle.Text = "Tiền khách đưa:";

            // txtCashReceived
            this.txtCashReceived.BackColor = System.Drawing.Color.White;
            this.txtCashReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCashReceived.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.txtCashReceived.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.txtCashReceived.Location = new System.Drawing.Point(4, 114);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(306, 36);
            this.txtCashReceived.TabIndex = 0;
            this.txtCashReceived.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);

            // flpQuickCash (Các nút bấm tiền nhanh: Đủ tiền, 50k, 100k, 200k, 500k)
            this.flpQuickCash.Location = new System.Drawing.Point(4, 156);
            this.flpQuickCash.Name = "flpQuickCash";
            this.flpQuickCash.Size = new System.Drawing.Size(306, 68);
            this.flpQuickCash.TabIndex = 1;

            // lblChangeTitle
            this.lblChangeTitle.AutoSize = true;
            this.lblChangeTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblChangeTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblChangeTitle.Location = new System.Drawing.Point(4, 230);
            this.lblChangeTitle.Name = "lblChangeTitle";
            this.lblChangeTitle.Size = new System.Drawing.Size(121, 20);
            this.lblChangeTitle.Text = "Tiền thừa trả lại:";

            // lblChange
            this.lblChange.BackColor = System.Drawing.Color.FromArgb(240, 253, 244); // Green 50
            this.lblChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(22, 163, 74); // Green 600
            this.lblChange.Location = new System.Drawing.Point(4, 254);
            this.lblChange.Name = "lblChange";
            this.lblChange.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.lblChange.Size = new System.Drawing.Size(306, 44);
            this.lblChange.Text = "0 đ";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnCheckout
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(16, 185, 129); // Emerald 500
            this.btnCheckout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(4, 318);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(306, 52);
            this.btnCheckout.TabIndex = 2;
            this.btnCheckout.Text = "⚡ THANH TOÁN (F9)";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // lblStatusMsg
            this.lblStatusMsg.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblStatusMsg.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblStatusMsg.Location = new System.Drawing.Point(14, 595);
            this.lblStatusMsg.Name = "lblStatusMsg";
            this.lblStatusMsg.Size = new System.Drawing.Size(314, 30);
            this.lblStatusMsg.Text = "Sẵn sàng quét mã sản phẩm...";
            this.lblStatusMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // Finalize
            // 
            this.Controls.Add(this.pnlCheckoutCard);
            this.Controls.Add(this.pnlCartCard);
            this.Controls.Add(this.pnlScanCard);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.pnlScanCard.ResumeLayout(false);
            this.pnlScanCard.PerformLayout();
            this.pnlCartCard.ResumeLayout(false);
            this.pnlCartFooter.ResumeLayout(false);
            this.pnlCartFooter.PerformLayout();
            this.pnlCheckoutCard.ResumeLayout(false);
            this.pnlCustomerBox.ResumeLayout(false);
            this.pnlCustomerBox.PerformLayout();
            this.pnlPaymentBox.ResumeLayout(false);
            this.pnlPaymentBox.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion
    }
}