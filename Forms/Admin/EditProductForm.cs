using IdeaHub.Presenters.Admin;
using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.Forms.Admin
{
    public partial class EditProductForm : Form, IEditProductView
    {

        public event EventHandler SaveClicked;
        public event EventHandler CancelClicked;
        public EditProductForm(IServiceProvider serviceProvider, Guid productId)
        {
            InitializeComponent();

            var editProductPresenter = new EditProductPresenter(this, serviceProvider, productId);

            btnSave.Click += (s, e) => SaveClicked?.Invoke(this, EventArgs.Empty);
            btnCancel.Click += (s, e) => CancelClicked?.Invoke(this, EventArgs.Empty);
        }
        public Guid ProductId { get; set; }

        public string ProductDescription
        {
            get => txtDescription.Text;
            set => txtDescription.Text = value;
        }
        public bool IsProductActive
        {
            get => chkIsActive.Checked;
            set => chkIsActive.Checked = value;
        }

        public string ProductName
        {
            get => txtProductName.Text;
            set => txtProductName.Text = value;
        }
        public void CloseView()
        {
            this.Close();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowView()
        {
            this.ShowDialog();
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
