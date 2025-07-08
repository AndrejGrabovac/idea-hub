namespace IdeaHub.Forms
{
    partial class SuggestionsForm
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
            this.dgvSuggestions = new System.Windows.Forms.DataGridView();
            this.lblMainMessage = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.cmbProductFilter = new System.Windows.Forms.ComboBox();
            this.cmbUserFilter = new System.Windows.Forms.ComboBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblFilterByStatus = new System.Windows.Forms.Label();
            this.lblFilterByProduct = new System.Windows.Forms.Label();
            this.lblFilterByUser = new System.Windows.Forms.Label();
            this.lblFilterByDate = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuggestions)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSuggestions
            // 
            this.dgvSuggestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuggestions.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSuggestions.Location = new System.Drawing.Point(0, 0);
            this.dgvSuggestions.Name = "dgvSuggestions";
            this.dgvSuggestions.Size = new System.Drawing.Size(873, 333);
            this.dgvSuggestions.TabIndex = 0;
            // 
            // lblMainMessage
            // 
            this.lblMainMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMainMessage.AutoSize = true;
            this.lblMainMessage.Location = new System.Drawing.Point(12, 229);
            this.lblMainMessage.Name = "lblMainMessage";
            this.lblMainMessage.Size = new System.Drawing.Size(22, 13);
            this.lblMainMessage.TabIndex = 1;
            this.lblMainMessage.Text = ".....";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(12, 9);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 2;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Enabled = false;
            this.btnUpdateStatus.Location = new System.Drawing.Point(12, 36);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(121, 23);
            this.btnUpdateStatus.TabIndex = 3;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBottom.Controls.Add(this.btnClear);
            this.pnlBottom.Controls.Add(this.btnFilter);
            this.pnlBottom.Controls.Add(this.cmbStatusFilter);
            this.pnlBottom.Controls.Add(this.cmbProductFilter);
            this.pnlBottom.Controls.Add(this.cmbUserFilter);
            this.pnlBottom.Controls.Add(this.dtpEndDate);
            this.pnlBottom.Controls.Add(this.lblToDate);
            this.pnlBottom.Controls.Add(this.lblFromDate);
            this.pnlBottom.Controls.Add(this.dtpStartDate);
            this.pnlBottom.Controls.Add(this.lblFilterByStatus);
            this.pnlBottom.Controls.Add(this.lblFilterByProduct);
            this.pnlBottom.Controls.Add(this.lblFilterByUser);
            this.pnlBottom.Controls.Add(this.lblFilterByDate);
            this.pnlBottom.Controls.Add(this.btnLogout);
            this.pnlBottom.Controls.Add(this.lblMainMessage);
            this.pnlBottom.Controls.Add(this.btnUpdateStatus);
            this.pnlBottom.Controls.Add(this.cmbStatus);
            this.pnlBottom.Location = new System.Drawing.Point(0, 330);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(873, 251);
            this.pnlBottom.TabIndex = 5;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(344, 189);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(248, 189);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
            this.btnFilter.TabIndex = 16;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            // 
            // cmbStatusFilter
            // 
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Location = new System.Drawing.Point(298, 150);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbStatusFilter.TabIndex = 15;
            // 
            // cmbProductFilter
            // 
            this.cmbProductFilter.FormattingEnabled = true;
            this.cmbProductFilter.Location = new System.Drawing.Point(298, 119);
            this.cmbProductFilter.Name = "cmbProductFilter";
            this.cmbProductFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbProductFilter.TabIndex = 14;
            // 
            // cmbUserFilter
            // 
            this.cmbUserFilter.FormattingEnabled = true;
            this.cmbUserFilter.Location = new System.Drawing.Point(298, 87);
            this.cmbUserFilter.Name = "cmbUserFilter";
            this.cmbUserFilter.Size = new System.Drawing.Size(121, 21);
            this.cmbUserFilter.TabIndex = 13;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(262, 56);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(111, 20);
            this.dtpEndDate.TabIndex = 12;
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Location = new System.Drawing.Point(233, 63);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(23, 13);
            this.lblToDate.TabIndex = 11;
            this.lblToDate.Text = "To:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Location = new System.Drawing.Point(223, 37);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(33, 13);
            this.lblFromDate.TabIndex = 10;
            this.lblFromDate.Text = "From:";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(262, 30);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(111, 20);
            this.dtpStartDate.TabIndex = 9;
            // 
            // lblFilterByStatus
            // 
            this.lblFilterByStatus.AutoSize = true;
            this.lblFilterByStatus.Location = new System.Drawing.Point(215, 153);
            this.lblFilterByStatus.Name = "lblFilterByStatus";
            this.lblFilterByStatus.Size = new System.Drawing.Size(77, 13);
            this.lblFilterByStatus.TabIndex = 8;
            this.lblFilterByStatus.Text = "Filter by status:";
            // 
            // lblFilterByProduct
            // 
            this.lblFilterByProduct.AutoSize = true;
            this.lblFilterByProduct.Location = new System.Drawing.Point(207, 122);
            this.lblFilterByProduct.Name = "lblFilterByProduct";
            this.lblFilterByProduct.Size = new System.Drawing.Size(85, 13);
            this.lblFilterByProduct.TabIndex = 7;
            this.lblFilterByProduct.Text = "Filter by product:";
            // 
            // lblFilterByUser
            // 
            this.lblFilterByUser.AutoSize = true;
            this.lblFilterByUser.Location = new System.Drawing.Point(223, 90);
            this.lblFilterByUser.Name = "lblFilterByUser";
            this.lblFilterByUser.Size = new System.Drawing.Size(69, 13);
            this.lblFilterByUser.TabIndex = 6;
            this.lblFilterByUser.Text = "Filter by user:";
            // 
            // lblFilterByDate
            // 
            this.lblFilterByDate.AutoSize = true;
            this.lblFilterByDate.Location = new System.Drawing.Point(223, 12);
            this.lblFilterByDate.Name = "lblFilterByDate";
            this.lblFilterByDate.Size = new System.Drawing.Size(63, 13);
            this.lblFilterByDate.TabIndex = 5;
            this.lblFilterByDate.Text = "Date range:";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(786, 216);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // SuggestionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 581);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvSuggestions);
            this.Name = "SuggestionsForm";
            this.Text = "Suggestions";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuggestions)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvSuggestions;
        private System.Windows.Forms.Label lblMainMessage;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblFilterByDate;
        private System.Windows.Forms.Label lblFilterByUser;
        private System.Windows.Forms.Label lblFilterByProduct;
        private System.Windows.Forms.Label lblFilterByStatus;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.ComboBox cmbUserFilter;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.ComboBox cmbProductFilter;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnFilter;
    }
}