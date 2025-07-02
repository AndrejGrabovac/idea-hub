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
            this.btnLogout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSuggestions)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSuggestions
            // 
            this.dgvSuggestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSuggestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSuggestions.Location = new System.Drawing.Point(0, 0);
            this.dgvSuggestions.Name = "dgvSuggestions";
            this.dgvSuggestions.Size = new System.Drawing.Size(873, 411);
            this.dgvSuggestions.TabIndex = 0;
            // 
            // lblMainMessage
            // 
            this.lblMainMessage.AutoSize = true;
            this.lblMainMessage.Location = new System.Drawing.Point(12, 62);
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
            this.pnlBottom.Controls.Add(this.btnLogout);
            this.pnlBottom.Controls.Add(this.lblMainMessage);
            this.pnlBottom.Controls.Add(this.btnUpdateStatus);
            this.pnlBottom.Controls.Add(this.cmbStatus);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 287);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(873, 124);
            this.pnlBottom.TabIndex = 5;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(786, 89);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // Suggestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 411);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvSuggestions);
            this.Name = "Suggestions";
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
    }
}