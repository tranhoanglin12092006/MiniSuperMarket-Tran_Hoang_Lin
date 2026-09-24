namespace MiniSupermarket.WinForms
{
    partial class FormCategoryManagement
    {
        private System.ComponentModel.IContainer components = null;

        // Search
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnLoad;

        // Danh sách
        private System.Windows.Forms.GroupBox grpCategoryList;
        private System.Windows.Forms.DataGridView dgvCategories;

        // Thông tin
        private System.Windows.Forms.GroupBox grpCategoryInfo;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;

        // CRUD
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        // Status
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

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
            this.components = new System.ComponentModel.Container();

            // =====================================================
            // KHAI BÁO CONTROL
            // =====================================================

            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();

            this.grpCategoryList = new System.Windows.Forms.GroupBox();
            this.dgvCategories = new System.Windows.Forms.DataGridView();

            this.grpCategoryInfo = new System.Windows.Forms.GroupBox();

            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();

            this.lblCategoryName = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();

            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();

            this.grpCategoryList.SuspendLayout();
            this.grpCategoryInfo.SuspendLayout();

            this.statusStrip.SuspendLayout();

            this.SuspendLayout();

            // =====================================================
            // FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize =
                new System.Drawing.Size(700, 360);

            this.MinimumSize =
                new System.Drawing.Size(700, 360);

            this.MaximumSize =
                new System.Drawing.Size(700, 360);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Name =
                "FormCategoryManagement";

            this.Text =
                "Quản lý Danh mục Nhóm hàng - FormCategoryManagement";

            // =====================================================
            // TEXTBOX SEARCH
            // =====================================================

            this.txtKeyword.Location =
                new System.Drawing.Point(20, 18);

            this.txtKeyword.Name =
                "txtKeyword";

            this.txtKeyword.Size =
                new System.Drawing.Size(400, 23);

            this.txtKeyword.TabIndex = 0;

            // =====================================================
            // BUTTON SEARCH
            // =====================================================

            this.btnSearch.Location =
                new System.Drawing.Point(430, 17);

            this.btnSearch.Name =
                "btnSearch";

            this.btnSearch.Size =
                new System.Drawing.Size(90, 27);

            this.btnSearch.TabIndex = 1;

            this.btnSearch.Text =
                "Tìm kiếm";

            this.btnSearch.UseVisualStyleBackColor =
                true;

            this.btnSearch.Click +=
                new System.EventHandler(
                    this.btnSearch_Click);

            // =====================================================
            // BUTTON LOAD
            // =====================================================

            this.btnLoad.Location =
                new System.Drawing.Point(525, 17);

            this.btnLoad.Name =
                "btnLoad";

            this.btnLoad.Size =
                new System.Drawing.Size(80, 27);

            this.btnLoad.TabIndex = 2;

            this.btnLoad.Text =
                "Tải lại";

            this.btnLoad.UseVisualStyleBackColor =
                true;

            this.btnLoad.Click +=
                new System.EventHandler(
                    this.btnLoad_Click);

            // =====================================================
            // GROUP: DANH SÁCH NHÓM HÀNG
            // =====================================================

            this.grpCategoryList.Location =
                new System.Drawing.Point(20, 55);

            this.grpCategoryList.Name =
                "grpCategoryList";

            this.grpCategoryList.Size =
                new System.Drawing.Size(430, 265);

            this.grpCategoryList.TabIndex = 3;

            this.grpCategoryList.TabStop = false;

            this.grpCategoryList.Text =
                "Danh sách nhóm hàng";

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================

            this.dgvCategories.Location =
                new System.Drawing.Point(6, 20);

            this.dgvCategories.Name =
                "dgvCategories";

            this.dgvCategories.Size =
                new System.Drawing.Size(418, 238);

            this.dgvCategories.TabIndex = 0;

            this.dgvCategories.AllowUserToAddRows =
                false;

            this.dgvCategories.AllowUserToDeleteRows =
                false;

            this.dgvCategories.AllowUserToResizeRows =
                false;

            this.dgvCategories.ReadOnly =
                true;

            this.dgvCategories.MultiSelect =
                false;

            this.dgvCategories.RowHeadersVisible =
                false;

            this.dgvCategories.AutoGenerateColumns =
                false;

            this.dgvCategories.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvCategories.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvCategories.BorderStyle =
                System.Windows.Forms.BorderStyle.Fixed3D;

            this.dgvCategories.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvCategories.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // =====================================================
            // COLUMN: CategoryId
            // =====================================================

            var colCategoryId =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colCategoryId.Name =
                "CategoryId";

            colCategoryId.HeaderText =
                "Mã ID";

            colCategoryId.DataPropertyName =
                "CategoryId";

            colCategoryId.ReadOnly =
                true;

            colCategoryId.FillWeight =
                20;

            // =====================================================
            // COLUMN: CategoryName
            // =====================================================

            var colCategoryName =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colCategoryName.Name =
                "CategoryName";

            colCategoryName.HeaderText =
                "Tên nhóm hàng";

            colCategoryName.DataPropertyName =
                "CategoryName";

            colCategoryName.ReadOnly =
                true;

            colCategoryName.FillWeight =
                40;

            // =====================================================
            // COLUMN: Description
            // =====================================================

            var colDescription =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colDescription.Name =
                "Description";

            colDescription.HeaderText =
                "Mô tả";

            colDescription.DataPropertyName =
                "Description";

            colDescription.ReadOnly =
                true;

            colDescription.FillWeight =
                40;

            // =====================================================
            // ADD COLUMNS
            // =====================================================

            this.dgvCategories.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    colCategoryId,
                    colCategoryName,
                    colDescription
                });

            // =====================================================
            // CELL CLICK
            // =====================================================

            this.dgvCategories.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvCategories_CellClick);

            // Add DataGridView vào GroupBox

            this.grpCategoryList.Controls.Add(
                this.dgvCategories);

            // =====================================================
            // GROUP: THÔNG TIN NHÓM HÀNG
            // =====================================================

            this.grpCategoryInfo.Location =
                new System.Drawing.Point(465, 55);

            this.grpCategoryInfo.Name =
                "grpCategoryInfo";

            this.grpCategoryInfo.Size =
                new System.Drawing.Size(210, 265);

            this.grpCategoryInfo.TabIndex = 4;

            this.grpCategoryInfo.TabStop = false;

            this.grpCategoryInfo.Text =
                "Thông tin Nhóm hàng";

            // =====================================================
            // LABEL ID
            // =====================================================

            this.lblId.AutoSize =
                true;

            this.lblId.Location =
                new System.Drawing.Point(10, 30);

            this.lblId.Name =
                "lblId";

            this.lblId.Size =
                new System.Drawing.Size(37, 15);

            this.lblId.Text =
                "Mã ID";

            // =====================================================
            // TEXTBOX ID
            // =====================================================

            this.txtId.Location =
                new System.Drawing.Point(10, 48);

            this.txtId.Name =
                "txtId";

            this.txtId.Size =
                new System.Drawing.Size(190, 23);

            this.txtId.ReadOnly =
                true;

            this.txtId.BackColor =
                System.Drawing.SystemColors.Control;

            this.txtId.TabIndex = 1;

            // =====================================================
            // LABEL TÊN
            // =====================================================

            this.lblCategoryName.AutoSize =
                true;

            this.lblCategoryName.Location =
                new System.Drawing.Point(10, 85);

            this.lblCategoryName.Name =
                "lblCategoryName";

            this.lblCategoryName.Size =
                new System.Drawing.Size(87, 15);

            this.lblCategoryName.Text =
                "Tên nhóm hàng";

            // =====================================================
            // TEXTBOX TÊN
            // =====================================================

            this.txtCategoryName.Location =
                new System.Drawing.Point(10, 103);

            this.txtCategoryName.Name =
                "txtCategoryName";

            this.txtCategoryName.Size =
                new System.Drawing.Size(190, 23);

            this.txtCategoryName.TabIndex = 2;

            // =====================================================
            // LABEL MÔ TẢ
            // =====================================================

            this.lblDescription.AutoSize =
                true;

            this.lblDescription.Location =
                new System.Drawing.Point(10, 140);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.Size =
                new System.Drawing.Size(38, 15);

            this.lblDescription.Text =
                "Mô tả";

            // =====================================================
            // TEXTBOX MÔ TẢ
            // =====================================================

            this.txtDescription.Location =
                new System.Drawing.Point(10, 158);

            this.txtDescription.Name =
                "txtDescription";

            this.txtDescription.Size =
                new System.Drawing.Size(190, 55);

            this.txtDescription.Multiline =
                true;

            this.txtDescription.ScrollBars =
                System.Windows.Forms.ScrollBars.Vertical;

            this.txtDescription.TabIndex = 3;

            // =====================================================
            // BUTTON THÊM
            // =====================================================

            this.btnAdd.Location =
                new System.Drawing.Point(10, 225);

            this.btnAdd.Name =
                "btnAdd";

            this.btnAdd.Size =
                new System.Drawing.Size(55, 27);

            this.btnAdd.Text =
                "Thêm";

            this.btnAdd.TabIndex = 4;

            this.btnAdd.UseVisualStyleBackColor =
                true;

            this.btnAdd.Click +=
                new System.EventHandler(
                    this.btnAdd_Click);

            // =====================================================
            // BUTTON CẬP NHẬT
            // =====================================================

            this.btnUpdate.Location =
                new System.Drawing.Point(70, 225);

            this.btnUpdate.Name =
                "btnUpdate";

            this.btnUpdate.Size =
                new System.Drawing.Size(70, 27);

            this.btnUpdate.Text =
                "Cập nhật";

            this.btnUpdate.TabIndex = 5;

            this.btnUpdate.UseVisualStyleBackColor =
                true;

            this.btnUpdate.Click +=
                new System.EventHandler(
                    this.btnUpdate_Click);

            // =====================================================
            // BUTTON XÓA
            // =====================================================

            this.btnDelete.Location =
                new System.Drawing.Point(145, 225);

            this.btnDelete.Name =
                "btnDelete";

            this.btnDelete.Size =
                new System.Drawing.Size(50, 27);

            this.btnDelete.Text =
                "Xóa";

            this.btnDelete.TabIndex = 6;

            this.btnDelete.UseVisualStyleBackColor =
                true;

            this.btnDelete.Click +=
                new System.EventHandler(
                    this.btnDelete_Click);

            // =====================================================
            // ADD CONTROLS VÀO GROUPBOX THÔNG TIN
            // =====================================================

            this.grpCategoryInfo.Controls.Add(
                this.lblId);

            this.grpCategoryInfo.Controls.Add(
                this.txtId);

            this.grpCategoryInfo.Controls.Add(
                this.lblCategoryName);

            this.grpCategoryInfo.Controls.Add(
                this.txtCategoryName);

            this.grpCategoryInfo.Controls.Add(
                this.lblDescription);

            this.grpCategoryInfo.Controls.Add(
                this.txtDescription);

            this.grpCategoryInfo.Controls.Add(
                this.btnAdd);

            this.grpCategoryInfo.Controls.Add(
                this.btnUpdate);

            this.grpCategoryInfo.Controls.Add(
                this.btnDelete);

            // =====================================================
            // STATUS STRIP
            // =====================================================

            this.statusStrip.Items.AddRange(
                new System.Windows.Forms.ToolStripItem[]
                {
                    this.lblStatus
                });

            this.statusStrip.Location =
                new System.Drawing.Point(0, 338);

            this.statusStrip.Name =
                "statusStrip";

            this.statusStrip.Size =
                new System.Drawing.Size(700, 22);

            this.statusStrip.TabIndex = 5;

            // =====================================================
            // STATUS LABEL
            // =====================================================

            this.lblStatus.Name =
                "lblStatus";

            this.lblStatus.Size =
                new System.Drawing.Size(42, 17);

            this.lblStatus.Text =
                "Ready";

            // =====================================================
            // ADD CONTROL VÀO FORM
            // =====================================================

            this.Controls.Add(
                this.txtKeyword);

            this.Controls.Add(
                this.btnSearch);

            this.Controls.Add(
                this.btnLoad);

            this.Controls.Add(
                this.grpCategoryList);

            this.Controls.Add(
                this.grpCategoryInfo);

            this.Controls.Add(
                this.statusStrip);

            // =====================================================
            // FORM LOAD
            // =====================================================

            this.Load +=
                new System.EventHandler(
                    this.FormCategoryManagement_Load);

            // =====================================================
            // FINALIZE
            // =====================================================

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvCategories)).EndInit();

            this.grpCategoryList.ResumeLayout(false);

            this.grpCategoryInfo.ResumeLayout(false);
            this.grpCategoryInfo.PerformLayout();

            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}