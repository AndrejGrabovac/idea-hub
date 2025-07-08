namespace IdeaHub.Forms
{
    partial class DashboardForm
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
            this.btnProducts = new System.Windows.Forms.Button();
            this.btnSuggestions = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(13, 13);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(75, 23);
            this.btnProducts.TabIndex = 0;
            this.btnProducts.Text = "Products";
            this.btnProducts.UseVisualStyleBackColor = true;
            // 
            // btnSuggestions
            // 
            this.btnSuggestions.Location = new System.Drawing.Point(94, 12);
            this.btnSuggestions.Name = "btnSuggestions";
            this.btnSuggestions.Size = new System.Drawing.Size(75, 23);
            this.btnSuggestions.TabIndex = 1;
            this.btnSuggestions.Text = "Suggestions";
            this.btnSuggestions.UseVisualStyleBackColor = true;
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(175, 13);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(75, 23);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Location = new System.Drawing.Point(198, 182);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 217);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnUsers);
            this.Controls.Add(this.btnSuggestions);
            this.Controls.Add(this.btnProducts);
            this.Name = "DashboardForm";
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnSuggestions;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnLogout;
    }
}