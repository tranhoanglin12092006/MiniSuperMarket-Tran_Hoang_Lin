namespace MiniSupermarket.WinForms
{
    partial class FormProductManagement
    {
        private System.ComponentModel.IContainer components = null;

        // Thanh tìm kiếm phía trên
        private System.Windows.Forms.Panel pnlTopFilter;
        private System.Windows.Forms.TextBox txtSearchBarcode;
        private System.Windows.Forms.ComboBox cboFilterCategory;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblSearchTitle;

        // Khu vực Trái (Bảng danh sách sản phẩm - 68%)
        private System.Windows.Forms.DataGridView dgvProducts;

        // Khu vực Phải (Form chi tiết & Thao tác - 32%)
        private System.Windows.Forms.GroupBox grpProductDetails;
        private System.Windows.Forms.Label lblIdTitle;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblBarcodeTitle;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label lblNameTitle;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Label lblCategoryTitle;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Label lblPriceTitle;
        private System.Windows.Forms.NumericUpDown nudPrice;
        private System.Windows.Forms.Label lblStockTitle;
        private System.Windows.Forms.NumericUpDown nudStock;

        // Các nút chức năng
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

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
            this.pnlTopFilter = new System.Windows.Forms.Panel();
            this.lblSearchTitle = new System.Windows.Forms.Label();
            this.txtSearchBarcode = new System.Windows.Forms.TextBox();
            this.cboFilterCategory = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();

            this.dgvProducts = new System.Windows.Forms.DataGridView();

            this.grpProductDetails = new System.Windows.Forms.GroupBox();
            this.lblIdTitle = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblBarcodeTitle = new System.Windows.Forms.Label();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.lblNameTitle = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.lblCategoryTitle = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.lblPriceTitle = new System.Windows.Forms.Label();
            this.nudPrice = new System.Windows.Forms.NumericUpDown();
            this.lblStockTitle = new System.Windows.Forms.Label();
            this.nudStock = new System.Windows.Forms.NumericUpDown();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.pnlTopFilter.SuspendLayout();
            this.grpProductDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            this.SuspendLayout();

            // 
            // FormProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(245)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(1050, 660);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormProductManagement";
            this.Text = "QUẢN LÝ SẢN PHẨM & TỒN KHO";
            this.Load += new System.EventHandler(this.FormProductManagement_Load);

            // 
            // pnlTopFilter (Thanh tìm kiếm trên cùng)
            // 
            this.pnlTopFilter.BackColor = System.Drawing.Color.White;
            this.pnlTopFilter.Controls.Add(this.btnSearch);
            this.pnlTopFilter.Controls.Add(this.cboFilterCategory);
            this.pnlTopFilter.Controls.Add(this.txtSearchBarcode);
            this.pnlTopFilter.Controls.Add(this.lblSearchTitle);
            this.pnlTopFilter.Location = new System.Drawing.Point(20, 15);
            this.pnlTopFilter.Name = "pnlTopFilter";
            this.pnlTopFilter.Size = new System.Drawing.Size(1010, 65);
            this.pnlTopFilter.TabIndex = 0;

            // lblSearchTitle
            this.lblSearchTitle.AutoSize = true;
            this.lblSearchTitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSearchTitle.Location = new System.Drawing.Point(15, 21);
            this.lblSearchTitle.Name = "lblSearchTitle";
            this.lblSearchTitle.Size = new System.Drawing.Size(126, 21);
            this.lblSearchTitle.Text = "Tìm kiếm/Lọc:";

            // txtSearchBarcode
            this.txtSearchBarcode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchBarcode.Location = new System.Drawing.Point(145, 18);
            this.txtSearchBarcode.Name = "txtSearchBarcode";
            this.txtSearchBarcode.Size = new System.Drawing.Size(280, 30);
            this.txtSearchBarcode.TabIndex = 1;
            // (Bạn có thể gán placeholder hoặc sự kiện tìm kiếm nếu muốn)

            // cboFilterCategory
            this.cboFilterCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilterCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboFilterCategory.FormattingEnabled = true;
            this.cboFilterCategory.Location = new System.Drawing.Point(440, 18);
            this.cboFilterCategory.Name = "cboFilterCategory";
            this.cboFilterCategory.Size = new System.Drawing.Size(220, 31);
            this.cboFilterCategory.TabIndex = 2;

            // btnSearch
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(675, 17);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(110, 32);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;

            // 
            // dgvProducts (Khu vực Trái - Chiếm khoảng 68%: 680px)
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Location = new System.Drawing.Point(20, 95);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.RowHeadersVisible = false;
            this.dgvProducts.RowHeadersWidth = 51;
            this.dgvProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducts.Size = new System.Drawing.Size(680, 545);
            this.dgvProducts.TabIndex = 1;
            this.dgvProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducts_CellClick);

            // 
            // grpProductDetails (Khu vực Phải - Chiếm khoảng 32%: 310px)
            // 
            this.grpProductDetails.Controls.Add(this.btnDelete);
            this.grpProductDetails.Controls.Add(this.btnUpdate);
            this.grpProductDetails.Controls.Add(this.btnAdd);
            this.grpProductDetails.Controls.Add(this.nudStock);
            this.grpProductDetails.Controls.Add(this.lblStockTitle);
            this.grpProductDetails.Controls.Add(this.nudPrice);
            this.grpProductDetails.Controls.Add(this.lblPriceTitle);
            this.grpProductDetails.Controls.Add(this.cboCategory);
            this.grpProductDetails.Controls.Add(this.lblCategoryTitle);
            this.grpProductDetails.Controls.Add(this.txtProductName);
            this.grpProductDetails.Controls.Add(this.lblNameTitle);
            this.grpProductDetails.Controls.Add(this.txtBarcode);
            this.grpProductDetails.Controls.Add(this.lblBarcodeTitle);
            this.grpProductDetails.Controls.Add(this.txtId);
            this.grpProductDetails.Controls.Add(this.lblIdTitle);
            this.grpProductDetails.Location = new System.Drawing.Point(720, 95);
            this.grpProductDetails.Name = "grpProductDetails";
            this.grpProductDetails.Size = new System.Drawing.Size(310, 545);
            this.grpProductDetails.TabStop = false;
            this.grpProductDetails.Text = "Thông tin chi tiết sản phẩm";

            // lblIdTitle & txtId (ID tự sinh hoặc khóa)
            this.lblIdTitle.AutoSize = true;
            this.lblIdTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIdTitle.Location = new System.Drawing.Point(15, 30);
            this.lblIdTitle.Name = "lblIdTitle";
            this.lblIdTitle.Size = new System.Drawing.Size(27, 20);
            this.lblIdTitle.Text = "ID:";

            this.txtId.Enabled = false; // ID thường khóa không cho sửa trực tiếp
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtId.Location = new System.Drawing.Point(15, 53);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(280, 30);
            this.txtId.TabIndex = 0;

            // lblBarcodeTitle & txtBarcode
            this.lblBarcodeTitle.AutoSize = true;
            this.lblBarcodeTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBarcodeTitle.Location = new System.Drawing.Point(15, 90);
            this.lblBarcodeTitle.Name = "lblBarcodeTitle";
            this.lblBarcodeTitle.Size = new System.Drawing.Size(68, 20);
            this.lblBarcodeTitle.Text = "Mã vạch:";

            this.txtBarcode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBarcode.Location = new System.Drawing.Point(15, 113);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(280, 30);
            this.txtBarcode.TabIndex = 1;

            // lblNameTitle & txtProductName
            this.lblNameTitle.AutoSize = true;
            this.lblNameTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNameTitle.Location = new System.Drawing.Point(15, 150);
            this.lblNameTitle.Name = "lblNameTitle";
            this.lblNameTitle.Size = new System.Drawing.Size(101, 20);
            this.lblNameTitle.Text = "Tên sản phẩm:";

            this.txtProductName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtProductName.Location = new System.Drawing.Point(15, 173);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(280, 30);
            this.txtProductName.TabIndex = 2;

            // lblCategoryTitle & cboCategory
            this.lblCategoryTitle.AutoSize = true;
            this.lblCategoryTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCategoryTitle.Location = new System.Drawing.Point(15, 210);
            this.lblCategoryTitle.Name = "lblCategoryTitle";
            this.lblCategoryTitle.Size = new System.Drawing.Size(81, 20);
            this.lblCategoryTitle.Text = "Nhóm hàng:";

            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(15, 233);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(280, 31);
            this.cboCategory.TabIndex = 3;

            // lblPriceTitle & nudPrice
            this.lblPriceTitle.AutoSize = true;
            this.lblPriceTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPriceTitle.Location = new System.Drawing.Point(15, 275);
            this.lblPriceTitle.Name = "lblPriceTitle";
            this.lblPriceTitle.Size = new System.Drawing.Size(63, 20);
            this.lblPriceTitle.Text = "Đơn giá:";

            this.nudPrice.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudPrice.Location = new System.Drawing.Point(15, 298);
            this.nudPrice.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(280, 30);
            this.nudPrice.TabIndex = 4;
            this.nudPrice.ThousandsSeparator = true;

            // lblStockTitle & nudStock
            this.lblStockTitle.AutoSize = true;
            this.lblStockTitle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStockTitle.Location = new System.Drawing.Point(15, 338);
            this.lblStockTitle.Name = "lblStockTitle";
            this.lblStockTitle.Size = new System.Drawing.Size(72, 20);
            this.lblStockTitle.Text = "Tồn kho:";

            this.nudStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudStock.Location = new System.Drawing.Point(15, 361);
            this.nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(280, 30);
            this.nudStock.TabIndex = 5;

            // btnAdd (Thêm)
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(15, 415);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(280, 38);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnUpdate (Sửa)
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(15, 460);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(280, 38);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            // btnDelete (Xóa)
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(15, 505);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(280, 38);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa sản phẩm";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // Finalize Form
            this.Controls.Add(this.grpProductDetails);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.pnlTopFilter);

            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.pnlTopFilter.ResumeLayout(false);
            this.pnlTopFilter.PerformLayout();
            this.grpProductDetails.ResumeLayout(false);
            this.grpProductDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}