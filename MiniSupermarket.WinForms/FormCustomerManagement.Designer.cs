namespace MiniSupermarket.WinForms
{
    partial class FormCustomerManagement
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpInputs = new System.Windows.Forms.GroupBox();
            this.lblCustomerId = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.TextBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblRewardPoints = new System.Windows.Forms.Label();
            this.txtRewardPoints = new System.Windows.Forms.TextBox();
            this.lblMembershipRank = new System.Windows.Forms.Label();
            this.txtMembershipRank = new System.Windows.Forms.TextBox();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.grpInputs.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Location = new System.Drawing.Point(12, 335);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(760, 215);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomers_CellClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(235, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(328, 26);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "QUẢN LÝ THÔNG TIN KHÁCH HÀNG";
            // 
            // grpInputs
            // 
            this.grpInputs.Controls.Add(this.lblMembershipRank);
            this.grpInputs.Controls.Add(this.txtMembershipRank);
            this.grpInputs.Controls.Add(this.lblRewardPoints);
            this.grpInputs.Controls.Add(this.txtRewardPoints);
            this.grpInputs.Controls.Add(this.lblAddress);
            this.grpInputs.Controls.Add(this.txtAddress);
            this.grpInputs.Controls.Add(this.lblPhoneNumber);
            this.grpInputs.Controls.Add(this.txtPhoneNumber);
            this.grpInputs.Controls.Add(this.lblCustomerName);
            this.grpInputs.Controls.Add(this.txtCustomerName);
            this.grpInputs.Controls.Add(this.lblCustomerId);
            this.grpInputs.Controls.Add(this.txtCustomerId);
            this.grpInputs.Location = new System.Drawing.Point(12, 45);
            this.grpInputs.Name = "grpInputs";
            this.grpInputs.Size = new System.Drawing.Size(760, 195);
            this.grpInputs.TabIndex = 2;
            this.grpInputs.TabStop = false;
            this.grpInputs.Text = "Thông tin chi tiết khách hàng";
            // 
            // lblCustomerId
            // 
            this.lblCustomerId.AutoSize = true;
            this.lblCustomerId.Location = new System.Drawing.Point(20, 30);
            this.lblCustomerId.Name = "lblCustomerId";
            this.lblCustomerId.Size = new System.Drawing.Size(82, 13);
            this.lblCustomerId.TabIndex = 0;
            this.lblCustomerId.Text = "Mã Khách Hàng:";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Location = new System.Drawing.Point(120, 27);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(230, 20);
            this.txtCustomerId.TabIndex = 1;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(20, 75);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(89, 13);
            this.lblCustomerName.TabIndex = 2;
            this.lblCustomerName.Text = "Tên Khách Hàng:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(120, 72);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(230, 20);
            this.txtCustomerName.TabIndex = 3;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Location = new System.Drawing.Point(20, 120);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(78, 13);
            this.lblPhoneNumber.TabIndex = 4;
            this.lblPhoneNumber.Text = "Số Điện Thoại:";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(120, 117);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(230, 20);
            this.txtPhoneNumber.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(390, 30);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(43, 13);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Địa Chỉ:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(490, 27);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(230, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // lblRewardPoints
            // 
            this.lblRewardPoints.AutoSize = true;
            this.lblRewardPoints.Location = new System.Drawing.Point(390, 75);
            this.lblRewardPoints.Name = "lblRewardPoints";
            this.lblRewardPoints.Size = new System.Drawing.Size(68, 13);
            this.lblRewardPoints.TabIndex = 8;
            this.lblRewardPoints.Text = "Điểm Thưởng:";
            // 
            // txtRewardPoints
            // 
            this.txtRewardPoints.Location = new System.Drawing.Point(490, 72);
            this.txtRewardPoints.Name = "txtRewardPoints";
            this.txtRewardPoints.Size = new System.Drawing.Size(230, 20);
            this.txtRewardPoints.TabIndex = 9;
            // 
            // lblMembershipRank
            // 
            this.lblMembershipRank.AutoSize = true;
            this.lblMembershipRank.Location = new System.Drawing.Point(390, 120);
            this.lblMembershipRank.Name = "lblMembershipRank";
            this.lblMembershipRank.Size = new System.Drawing.Size(81, 13);
            this.lblMembershipRank.TabIndex = 10;
            this.lblMembershipRank.Text = "Hạng Thành Viên:";
            // 
            // txtMembershipRank
            // 
            this.txtMembershipRank.Location = new System.Drawing.Point(490, 117);
            this.txtMembershipRank.Name = "txtMembershipRank";
            this.txtMembershipRank.Size = new System.Drawing.Size(230, 20);
            this.txtMembershipRank.TabIndex = 11;
            // 
            // grpActions
            // 
            this.grpActions.Controls.Add(this.btnSearch);
            this.grpActions.Controls.Add(this.txtSearch);
            this.grpActions.Controls.Add(this.btnDelete);
            this.grpActions.Controls.Add(this.btnUpdate);
            this.grpActions.Controls.Add(this.btnAdd);
            this.grpActions.Controls.Add(this.btnLoad);
            this.grpActions.Location = new System.Drawing.Point(12, 250);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(760, 70);
            this.grpActions.TabIndex = 3;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Thanh công cụ & Chức năng";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(20, 25);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 30);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Làm mới";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(110, 25);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(200, 25);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 30);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(290, 25);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(400, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(180, 20);
            this.txtSearch.TabIndex = 4;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(590, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(130, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FormCustomerManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.grpActions);
            this.Controls.Add(this.grpInputs);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvCustomers);
            this.Name = "FormCustomerManagement";
            this.Text = "Quản Lý Khách Hàng - Ăn Vặt Store";
            this.Load += new System.EventHandler(this.FormCustomerManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.grpInputs.ResumeLayout(false);
            this.grpInputs.PerformLayout();
            this.grpActions.ResumeLayout(false);
            this.grpActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpInputs;
        private System.Windows.Forms.Label lblMembershipRank;
        private System.Windows.Forms.TextBox txtMembershipRank;
        private System.Windows.Forms.Label lblRewardPoints;
        private System.Windows.Forms.TextBox txtRewardPoints;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblCustomerId;
        private System.Windows.Forms.TextBox txtCustomerId;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnLoad;
    }
}