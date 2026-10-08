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
            // FORM (Đồng bộ kích thước với panelMainContent: 1050x660)
            // =====================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 660);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None; // Không viền để nhúng vừa vặn vào FormMainShell
            this.Name = "FormCategoryManagement";
            this.Text = "QUẢN LÝ DANH MỤC NHÓM HÀNG";

            // =====================================================
            // GROUP: THÔNG TIN NHÓM HÀNG (Phía trên)
            // =====================================================
            this.grpCategoryInfo.Location = new System.Drawing.Point(12, 12);
            this.grpCategoryInfo.Name = "grpCategoryInfo";
            this.grpCategoryInfo.Size = new System.Drawing.Size(1026, 175);
            this.grpCategoryInfo.TabIndex = 1;
            this.grpCategoryInfo.TabStop = false;
            this.grpCategoryInfo.Text = "Thông tin chi tiết nhóm hàng";

            // -- Mã ID --
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 35);
            this.lblId.Size = new System.Drawing.Size(48, 16);
            this.lblId.Text = "Mã ID:";

            this.txtId.Location = new System.Drawing.Point(130, 32);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(320, 22);
            this.txtId.ReadOnly = true;
            this.txtId.BackColor = System.Drawing.SystemColors.Control;

            // -- Tên nhóm hàng --
            this.lblCategoryName.AutoSize = true;
            this.lblCategoryName.Location = new System.Drawing.Point(20, 80);
            this.lblCategoryName.Size = new System.Drawing.Size(98, 16);
            this.lblCategoryName.Text = "Tên nhóm hàng:";

            this.txtCategoryName.Location = new System.Drawing.Point(130, 77);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(320, 22);

            // -- Mô tả --
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(485, 35);
            this.lblDescription.Size = new System.Drawing.Size(43, 16);
            this.lblDescription.Text = "Mô tả:";

            this.txtDescription.Location = new System.Drawing.Point(555, 32);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(445, 67);
            this.txtDescription.Multiline = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

            // =====================================================
            // THANH CÔNG CỤ & CHỨC NĂNG (Nằm trong grpCategoryInfo)
            // =====================================================
            this.btnAdd.Location = new System.Drawing.Point(130, 125);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 32);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            this.btnUpdate.Location = new System.Drawing.Point(225, 125);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(95, 32);
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            this.btnDelete.Location = new System.Drawing.Point(330, 125);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 32);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            this.btnLoad.Location = new System.Drawing.Point(415, 125);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(90, 32);
            this.btnLoad.Text = "Làm mới";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);

            // -- Tìm kiếm nhanh --
            this.txtKeyword.Location = new System.Drawing.Point(670, 128);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(215, 22);

            this.btnSearch.Location = new System.Drawing.Point(895, 125);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(105, 32);
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // Gắn các control vào grpCategoryInfo
            this.grpCategoryInfo.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblId, this.txtId,
                this.lblCategoryName, this.txtCategoryName,
                this.lblDescription, this.txtDescription,
                this.btnAdd, this.btnUpdate, this.btnDelete, this.btnLoad,
                this.txtKeyword, this.btnSearch
            });

            // =====================================================
            // GROUP: DANH SÁCH NHÓM HÀNG (Phía dưới)
            // =====================================================
            this.grpCategoryList.Location = new System.Drawing.Point(12, 200);
            this.grpCategoryList.Name = "grpCategoryList";
            this.grpCategoryList.Size = new System.Drawing.Size(1026, 425);
            this.grpCategoryList.TabIndex = 2;
            this.grpCategoryList.TabStop = false;
            this.grpCategoryList.Text = "Danh sách nhóm hàng";

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================
            this.dgvCategories.Location = new System.Drawing.Point(15, 25);
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.Size = new System.Drawing.Size(996, 385);
            this.dgvCategories.TabIndex = 0;
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToResizeRows = false;
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCategories_CellClick);

            this.grpCategoryList.Controls.Add(this.dgvCategories);

            // =====================================================
            // STATUS STRIP
            // =====================================================
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.lblStatus });
            this.statusStrip.Location = new System.Drawing.Point(0, 638);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1050, 22);
            this.statusStrip.TabIndex = 3;

            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(63, 17);
            this.lblStatus.Text = "Sẵn sàng";

            // =====================================================
            // ADD CONTROLS VÀO FORM
            // =====================================================
            this.Controls.Add(this.grpCategoryInfo);
            this.Controls.Add(this.grpCategoryList);
            this.Controls.Add(this.statusStrip);

            // =====================================================
            // FINALIZE
            // =====================================================
            this.Load += new System.EventHandler(this.FormCategoryManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.grpCategoryInfo.ResumeLayout(false);
            this.grpCategoryInfo.PerformLayout();
            this.grpCategoryList.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}