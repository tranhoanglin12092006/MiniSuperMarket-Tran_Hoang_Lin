namespace MiniSupermarket.WinForms
{
    partial class FormRoleManagement
    {
        private System.ComponentModel.IContainer components = null;

        // =====================================================
        // CONTROLS
        // =====================================================


        private System.Windows.Forms.DataGridView dgvRoles;

        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.TextBox txtDescription;

        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Label lblRoleName;
        private System.Windows.Forms.Label lblDescription;

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.GroupBox grpRoleList;
        private System.Windows.Forms.GroupBox grpRoleInfo;

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;

        // =====================================================
        // DISPOSE
        // =====================================================

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

            this.dgvRoles = new System.Windows.Forms.DataGridView();

            this.txtId = new System.Windows.Forms.TextBox();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();

            this.lblId = new System.Windows.Forms.Label();
            this.lblRoleName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();

            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();

            this.grpRoleList = new System.Windows.Forms.GroupBox();
            this.grpRoleInfo = new System.Windows.Forms.GroupBox();

            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();

            this.grpRoleList.SuspendLayout();
            this.grpRoleInfo.SuspendLayout();

            this.statusStrip.SuspendLayout();

            this.SuspendLayout();

            // =====================================================
            // FORM
            // =====================================================

            this.AutoScaleDimensions =
                new System.Drawing.SizeF(7F, 15F);

            this.AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            // GIỐNG FORM CATEGORY
            this.ClientSize =
                new System.Drawing.Size(560, 360);

            this.MinimumSize =
                new System.Drawing.Size(560, 360);

            this.MaximumSize =
                new System.Drawing.Size(560, 360);

            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            this.MaximizeBox = false;

            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            this.Name =
                "FormRoleManagement";

            this.Text =
                "Quản lý Vai trò";

            // =====================================================
            // BUTTON LOAD
            // =====================================================

            this.btnLoad.Location =
                new System.Drawing.Point(20, 18);

            this.btnLoad.Name =
                "btnLoad";

            this.btnLoad.Size =
                new System.Drawing.Size(80, 27);

            this.btnLoad.TabIndex = 0;

            this.btnLoad.Text =
                "Tải lại";

            this.btnLoad.UseVisualStyleBackColor =
                true;

            this.btnLoad.Click +=
                new System.EventHandler(
                    this.btnLoad_Click);


            // =====================================================
            // GROUPBOX - DANH SÁCH ROLE
            // =====================================================

            this.grpRoleList.Location =
                new System.Drawing.Point(20, 55);

            this.grpRoleList.Name =
                "grpRoleList";

            this.grpRoleList.Size =
                new System.Drawing.Size(330, 265);

            this.grpRoleList.TabIndex = 1;

            this.grpRoleList.TabStop = false;

            this.grpRoleList.Text =
                "Danh sách vai trò";

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================

            this.dgvRoles.Location =
                new System.Drawing.Point(6, 20);

            this.dgvRoles.Name =
                "dgvRoles";

            this.dgvRoles.Size =
                new System.Drawing.Size(318, 238);

            this.dgvRoles.TabIndex = 0;

            this.dgvRoles.AllowUserToAddRows =
                false;

            this.dgvRoles.AllowUserToDeleteRows =
                false;

            this.dgvRoles.AllowUserToResizeRows =
                false;

            this.dgvRoles.ReadOnly =
                true;

            this.dgvRoles.MultiSelect =
                false;

            this.dgvRoles.RowHeadersVisible =
                false;

            this.dgvRoles.AutoGenerateColumns =
                false;

            this.dgvRoles.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            this.dgvRoles.BackgroundColor =
                System.Drawing.Color.White;

            this.dgvRoles.BorderStyle =
                System.Windows.Forms.BorderStyle.Fixed3D;

            this.dgvRoles.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvRoles.ColumnHeadersHeightSizeMode =
                System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // =====================================================
            // COLUMN ID
            // =====================================================

            var colId =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colId.Name =
                "Id";

            colId.HeaderText =
                "Mã ID";

            colId.DataPropertyName =
                "Id";

            colId.ReadOnly =
                true;

            colId.FillWeight =
                20;

            // =====================================================
            // COLUMN ROLE NAME
            // =====================================================

            var colRoleName =
                new System.Windows.Forms.DataGridViewTextBoxColumn();

            colRoleName.Name =
                "RoleName";

            colRoleName.HeaderText =
                "Tên vai trò";

            colRoleName.DataPropertyName =
                "RoleName";

            colRoleName.ReadOnly =
                true;

            colRoleName.FillWeight =
                40;

            // =====================================================
            // COLUMN DESCRIPTION
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

            this.dgvRoles.Columns.AddRange(
                new System.Windows.Forms.DataGridViewColumn[]
                {
                    colId,
                    colRoleName,
                    colDescription
                });

            // =====================================================
            // CELL CLICK
            // =====================================================

            this.dgvRoles.CellClick +=
                new System.Windows.Forms.DataGridViewCellEventHandler(
                    this.dgvRoles_CellClick);

            this.grpRoleList.Controls.Add(
                this.dgvRoles);

            // =====================================================
            // GROUPBOX - THÔNG TIN ROLE
            // =====================================================

            this.grpRoleInfo.Location =
                new System.Drawing.Point(360, 55);

            this.grpRoleInfo.Name =
                "grpRoleInfo";

            this.grpRoleInfo.Size =
                new System.Drawing.Size(180, 265);

            this.grpRoleInfo.TabIndex = 2;

            this.grpRoleInfo.TabStop = false;

            this.grpRoleInfo.Text =
                "Thông tin vai trò";

            // =====================================================
            // LABEL ID
            // =====================================================

            this.lblId.AutoSize = true;

            this.lblId.Location =
                new System.Drawing.Point(10, 30);

            this.lblId.Name =
                "lblId";

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
                new System.Drawing.Size(160, 23);

            this.txtId.ReadOnly =
                true;

            this.txtId.BackColor =
                System.Drawing.SystemColors.Control;

            this.txtId.TabIndex = 1;

            // =====================================================
            // LABEL ROLE NAME
            // =====================================================

            this.lblRoleName.AutoSize = true;

            this.lblRoleName.Location =
                new System.Drawing.Point(10, 85);

            this.lblRoleName.Name =
                "lblRoleName";

            this.lblRoleName.Text =
                "Tên vai trò";

            // =====================================================
            // TEXTBOX ROLE NAME
            // =====================================================

            this.txtRoleName.Location =
                new System.Drawing.Point(10, 103);

            this.txtRoleName.Name =
                "txtRoleName";

            this.txtRoleName.Size =
                new System.Drawing.Size(160, 23);

            this.txtRoleName.TabIndex = 2;

            // =====================================================
            // LABEL DESCRIPTION
            // =====================================================

            this.lblDescription.AutoSize = true;

            this.lblDescription.Location =
                new System.Drawing.Point(10, 140);

            this.lblDescription.Name =
                "lblDescription";

            this.lblDescription.Text =
                "Mô tả";

            // =====================================================
            // TEXTBOX DESCRIPTION
            // =====================================================

            this.txtDescription.Location =
                new System.Drawing.Point(10, 158);

            this.txtDescription.Name =
                "txtDescription";

            this.txtDescription.Size =
                new System.Drawing.Size(160, 55);

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
                new System.Drawing.Size(50, 27);

            this.btnAdd.TabIndex = 4;

            this.btnAdd.Text =
                "Thêm";

            this.btnAdd.UseVisualStyleBackColor =
                true;

            this.btnAdd.Click +=
                new System.EventHandler(
                    this.btnAdd_Click);

            // =====================================================
            // BUTTON CẬP NHẬT
            // =====================================================

            this.btnUpdate.Location =
                new System.Drawing.Point(65, 225);

            this.btnUpdate.Name =
                "btnUpdate";

            this.btnUpdate.Size =
                new System.Drawing.Size(60, 27);

            this.btnUpdate.TabIndex = 5;

            this.btnUpdate.Text =
                "Cập nhật";

            this.btnUpdate.UseVisualStyleBackColor =
                true;

            this.btnUpdate.Click +=
                new System.EventHandler(
                    this.btnUpdate_Click);

            // =====================================================
            // BUTTON XÓA
            // =====================================================

            this.btnDelete.Location =
                new System.Drawing.Point(130, 225);

            this.btnDelete.Name =
                "btnDelete";

            this.btnDelete.Size =
                new System.Drawing.Size(40, 27);

            this.btnDelete.TabIndex = 6;

            this.btnDelete.Text =
                "Xóa";

            this.btnDelete.UseVisualStyleBackColor =
                true;

            this.btnDelete.Click +=
                new System.EventHandler(
                    this.btnDelete_Click);

            // =====================================================
            // ADD CONTROLS TO INFO GROUP
            // =====================================================

            this.grpRoleInfo.Controls.Add(
                this.lblId);

            this.grpRoleInfo.Controls.Add(
                this.txtId);

            this.grpRoleInfo.Controls.Add(
                this.lblRoleName);

            this.grpRoleInfo.Controls.Add(
                this.txtRoleName);

            this.grpRoleInfo.Controls.Add(
                this.lblDescription);

            this.grpRoleInfo.Controls.Add(
                this.txtDescription);

            this.grpRoleInfo.Controls.Add(
                this.btnAdd);

            this.grpRoleInfo.Controls.Add(
                this.btnUpdate);

            this.grpRoleInfo.Controls.Add(
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
                new System.Drawing.Size(560, 22);

            this.statusStrip.TabIndex = 3;

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
            // ADD CONTROLS TO FORM
            // =====================================================

            this.Controls.Add(
                this.btnLoad);

            this.Controls.Add(
                this.grpRoleList);

            this.Controls.Add(
                this.grpRoleInfo);

            this.Controls.Add(
                this.statusStrip);

            // =====================================================
            // FORM LOAD
            // =====================================================

            this.Load +=
                new System.EventHandler(
                    this.FormRoleManagement_Load);

            // =====================================================
            // FINALIZE
            // =====================================================

            ((System.ComponentModel.ISupportInitialize)
                (this.dgvRoles)).EndInit();

            this.grpRoleList.ResumeLayout(false);

            this.grpRoleInfo.ResumeLayout(false);
            this.grpRoleInfo.PerformLayout();

            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
