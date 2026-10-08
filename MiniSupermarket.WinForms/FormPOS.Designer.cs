namespace MiniSupermarket.WinForms
{
    partial class FormPOS
    {
        private System.ComponentModel.IContainer components = null;

        // Khu vực Trái (Giỏ hàng & Quét Barcode)
        private System.Windows.Forms.GroupBox grpCartSection;
        private System.Windows.Forms.Label lblBarcodeTitle;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.DataGridView dgvCart;

        // Khu vực Phải (Khách hàng & Thanh toán)
        private System.Windows.Forms.GroupBox grpCheckoutSection;
        private System.Windows.Forms.Label lblPhoneTitle;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.Label lblCustomerNameTitle;
        private System.Windows.Forms.Label lblCustomerName;

        private System.Windows.Forms.Label lblTotalTitle;
        private System.Windows.Forms.Label lblTotalAmount;

        private System.Windows.Forms.Label lblCashTitle;
        private System.Windows.Forms.TextBox txtCashReceived;
        private System.Windows.Forms.Label lblChangeTitle;
        private System.Windows.Forms.Label lblChange;

        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnClearCart;

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
            this.grpCartSection = new System.Windows.Forms.GroupBox();
            this.lblBarcodeTitle = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.dgvCart = new System.Windows.Forms.DataGridView();

            this.grpCheckoutSection = new System.Windows.Forms.GroupBox();
            this.lblPhoneTitle = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.lblCustomerNameTitle = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();

            this.lblTotalTitle = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();

            this.lblCashTitle = new System.Windows.Forms.Label();
            this.txtCashReceived = new System.Windows.Forms.TextBox();
            this.lblChangeTitle = new System.Windows.Forms.Label();
            this.lblChange = new System.Windows.Forms.Label();

            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnClearCart = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.grpCartSection.SuspendLayout();
            this.grpCheckoutSection.SuspendLayout();
            this.SuspendLayout();

            // 
            // FormPOS (Đồng bộ kích thước vùng panelMainContent: 1050x660)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1050, 660);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPOS";
            this.Text = "HỆ THỐNG BÁN HÀNG POS (BARCODE)";

            // 
            // grpCartSection (Khu vực Trái - Chiếm khoảng 65% width: 660px)
            // 
            this.grpCartSection.Controls.Add(this.dgvCart);
            this.grpCartSection.Controls.Add(this.txtBarcode);
            this.grpCartSection.Controls.Add(this.lblBarcodeTitle);
            this.grpCartSection.Location = new System.Drawing.Point(20, 15);
            this.grpCartSection.Name = "grpCartSection";
            this.grpCartSection.Size = new System.Drawing.Size(660, 630);
            this.grpCartSection.TabStop = false;
            this.grpCartSection.Text = "Giỏ hàng thanh toán";

            // lblBarcodeTitle
            this.lblBarcodeTitle.AutoSize = true;
            this.lblBarcodeTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBarcodeTitle.Location = new System.Drawing.Point(20, 30);
            this.lblBarcodeTitle.Name = "lblBarcodeTitle";
            this.lblBarcodeTitle.Size = new System.Drawing.Size(175, 23);
            this.lblBarcodeTitle.Text = "Quét mã vạch sản phẩm:";

            // txtBarcode
            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtBarcode.Location = new System.Drawing.Point(20, 60);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(620, 34);
            this.txtBarcode.TabIndex = 0;
            this.txtBarcode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBarcode_KeyDown);

            // dgvCart
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(20, 110);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.RowHeadersVisible = false;
            this.dgvCart.RowHeadersWidth = 51;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(620, 500);
            this.dgvCart.TabIndex = 1;

            // 
            // grpCheckoutSection (Khu vực Phải - Chiếm khoảng 35% width: 325px)
            // 
            this.grpCheckoutSection.Controls.Add(this.btnClearCart);
            this.grpCheckoutSection.Controls.Add(this.btnCheckout);
            this.grpCheckoutSection.Controls.Add(this.lblChange);
            this.grpCheckoutSection.Controls.Add(this.lblChangeTitle);
            this.grpCheckoutSection.Controls.Add(this.txtCashReceived);
            this.grpCheckoutSection.Controls.Add(this.lblCashTitle);
            this.grpCheckoutSection.Controls.Add(this.lblTotalAmount);
            this.grpCheckoutSection.Controls.Add(this.lblTotalTitle);
            this.grpCheckoutSection.Controls.Add(this.lblCustomerName);
            this.grpCheckoutSection.Controls.Add(this.lblCustomerNameTitle);
            this.grpCheckoutSection.Controls.Add(this.txtCustomerPhone);
            this.grpCheckoutSection.Controls.Add(this.lblPhoneTitle);
            this.grpCheckoutSection.Location = new System.Drawing.Point(700, 15);
            this.grpCheckoutSection.Name = "grpCheckoutSection";
            this.grpCheckoutSection.Size = new System.Drawing.Size(330, 630);
            this.grpCheckoutSection.TabStop = false;
            this.grpCheckoutSection.Text = "Thông tin thanh toán";

            // lblPhoneTitle
            this.lblPhoneTitle.AutoSize = true;
            this.lblPhoneTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhoneTitle.Location = new System.Drawing.Point(20, 35);
            this.lblPhoneTitle.Name = "lblPhoneTitle";
            this.lblPhoneTitle.Size = new System.Drawing.Size(102, 20);
            this.lblPhoneTitle.Text = "SĐT Khách hàng:";

            // txtCustomerPhone
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCustomerPhone.Location = new System.Drawing.Point(20, 60);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(290, 30);
            this.txtCustomerPhone.TabIndex = 2;

            // lblCustomerNameTitle
            this.lblCustomerNameTitle.AutoSize = true;
            this.lblCustomerNameTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCustomerNameTitle.Location = new System.Drawing.Point(20, 105);
            this.lblCustomerNameTitle.Name = "lblCustomerNameTitle";
            this.lblCustomerNameTitle.Size = new System.Drawing.Size(115, 20);
            this.lblCustomerNameTitle.Text = "Khách hàng thẻ:";

            // lblCustomerName
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCustomerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.lblCustomerName.Location = new System.Drawing.Point(140, 104);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(124, 23);
            this.lblCustomerName.Text = "Khách vãng lai";

            // lblTotalTitle
            this.lblTotalTitle.AutoSize = true;
            this.lblTotalTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalTitle.Location = new System.Drawing.Point(20, 155);
            this.lblTotalTitle.Name = "lblTotalTitle";
            this.lblTotalTitle.Size = new System.Drawing.Size(117, 25);
            this.lblTotalTitle.Text = "TỔNG TIỀN:";

            // lblTotalAmount
            this.lblTotalAmount.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTotalAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblTotalAmount.Location = new System.Drawing.Point(20, 190);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(290, 55);
            this.lblTotalAmount.Text = "0 đ";
            this.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // lblCashTitle
            this.lblCashTitle.AutoSize = true;
            this.lblCashTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCashTitle.Location = new System.Drawing.Point(20, 270);
            this.lblCashTitle.Name = "lblCashTitle";
            this.lblCashTitle.Size = new System.Drawing.Size(116, 23);
            this.lblCashTitle.Text = "Tiền khách đưa:";

            // txtCashReceived
            this.txtCashReceived.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtCashReceived.Location = new System.Drawing.Point(20, 300);
            this.txtCashReceived.Name = "txtCashReceived";
            this.txtCashReceived.Size = new System.Drawing.Size(290, 34);
            this.txtCashReceived.TabIndex = 3;
            this.txtCashReceived.TextChanged += new System.EventHandler(this.txtCashReceived_TextChanged);

            // lblChangeTitle
            this.lblChangeTitle.AutoSize = true;
            this.lblChangeTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblChangeTitle.Location = new System.Drawing.Point(20, 360);
            this.lblChangeTitle.Name = "lblChangeTitle";
            this.lblChangeTitle.Size = new System.Drawing.Size(130, 23);
            this.lblChangeTitle.Text = "Tiền thừa trả lại:";

            // lblChange
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblChange.Location = new System.Drawing.Point(20, 395);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(290, 45);
            this.lblChange.Text = "0 đ";
            this.lblChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            // btnCheckout (Nút Thanh toán màu xanh lá đậm)
            this.btnCheckout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnCheckout.FlatAppearance.BorderSize = 0;
            this.btnCheckout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnCheckout.ForeColor = System.Drawing.Color.White;
            this.btnCheckout.Location = new System.Drawing.Point(20, 475);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(290, 50);
            this.btnCheckout.TabIndex = 4;
            this.btnCheckout.Text = "THANH TOÁN (F9)";
            this.btnCheckout.UseVisualStyleBackColor = false;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);

            // btnClearCart (Nút Hủy giỏ hàng màu đỏ)
            this.btnClearCart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnClearCart.FlatAppearance.BorderSize = 0;
            this.btnClearCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCart.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnClearCart.ForeColor = System.Drawing.Color.White;
            this.btnClearCart.Location = new System.Drawing.Point(20, 545);
            this.btnClearCart.Name = "btnClearCart";
            this.btnClearCart.Size = new System.Drawing.Size(290, 45);
            this.btnClearCart.TabIndex = 5;
            this.btnClearCart.Text = "HỦY GIỎ HÀNG";
            this.btnClearCart.UseVisualStyleBackColor = false;
            // (Bạn có thể thêm sự kiện click xóa giỏ hàng nếu muốn, ví dụ: this.btnClearCart.Click += ...);

            // 
            // FormPOS Finalize
            // 
            this.Controls.Add(this.grpCheckoutSection);
            this.Controls.Add(this.grpCartSection);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.grpCartSection.ResumeLayout(false);
            this.grpCartSection.PerformLayout();
            this.grpCheckoutSection.ResumeLayout(false);
            this.grpCheckoutSection.PerformLayout();
            this.ResumeLayout(false);
        }
        private void StyleDataGridView()
        {
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvCart.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCart.DefaultCellStyle.SelectionBackColor = Color.FromArgb(41, 100, 180);
            dgvCart.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvCart.RowTemplate.Height = 38; // Tăng chiều cao giúp thoáng mắt và dễ nhìn

            // Tùy chỉnh phần Header của bảng
            dgvCart.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
            dgvCart.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvCart.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvCart.ColumnHeadersHeight = 42;
        }
        #endregion
    }
}