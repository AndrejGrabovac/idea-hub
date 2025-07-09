using IdeaHub.Presenters.Admin;
using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using System;
using System.Windows.Forms;

namespace IdeaHub.Forms.Admin
{
    public partial class CreateProductForm : Form, ICreateProductView
    {
        private readonly IServiceProvider _serviceProvider;

        public event EventHandler ProductCreated;
        public event EventHandler CreateProductAttempted;
        public string NewProductName => txtName.Text;
        public string NewProductDescription => txtDescription.Text;


        public CreateProductForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            var createProductPresenter = new CreateProductPresenter(this, _serviceProvider);
            btnCreate.Click += (sender, e) => CreateProductAttempted?.Invoke(this, EventArgs.Empty);
        }

        public void CloseView()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void OnProductCreated()
        {
            ProductCreated?.Invoke(this, EventArgs.Empty);
        }
    }
}
