using IdeaHub.DTOs.Product;
using IdeaHub.Forms.Admin;
using IdeaHub.Models;
using IdeaHub.Presenters.Base;
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

namespace IdeaHub.Forms
{
    public partial class ProductsForm : Form, IProductsView
    {
        private readonly IServiceProvider _serviceProvider;

        public event EventHandler LoadProducts;
        public event EventHandler<Guid> CreateSuggestionForProductClicked;
        public event EventHandler NewProductClicked;
        public event EventHandler LogoutClicked;
        public event EventHandler EditProductClicked;

        public ProductsForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            var productsPresenter = new ProductsPresenter(this, _serviceProvider);


            this.Load += (s, e) => LoadProducts?.Invoke(this, EventArgs.Empty);

            this.dgvProducts.CellDoubleClick += DgvProducts_CellDoubleClick;
            this.dgvProducts.CellClick += DgvProducts_CellClick;
            this.dgvProducts.SelectionChanged += DgvProducts_SelectionChanged;


            btnNewProduct.Click += (sender, e) => NewProductClicked?.Invoke(this, EventArgs.Empty);
            btnEditProduct.Click += (sender, e) => EditProductClicked?.Invoke(this, EventArgs.Empty);

            this.btnLogout.Click += (s, e) => LogoutClicked?.Invoke(this, EventArgs.Empty);

        }

        private void DgvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var product = dgvProducts.Rows[e.RowIndex].DataBoundItem as ProductViewDto;
                if (product != null)
                {
                    CreateSuggestionForProductClicked?.Invoke(this, product.Id);
                }
            }
        }

        private void DgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var product = dgvProducts.SelectedRows[0].DataBoundItem as ProductViewDto;
                if (product != null)
                {
                    SelectedProductName = product.Name;
                }
            }
        }

        private void DgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvProducts.Columns[e.ColumnIndex].Name == "Description")
            {
                var product = dgvProducts.Rows[e.RowIndex].DataBoundItem as ProductViewDto;
                if (product != null)
                {
                    MessageBox.Show(product.Description, "Full Product Description");
                }
            }
        }

        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetIsActiveColumnVisibility(bool visible)
        {
            if (dgvProducts.Columns.Contains("IsActive"))
            {
                dgvProducts.Columns["IsActive"].Visible = visible;
            }
        }

        public void ShowCreateProductForm()
        {
            var createProductForm = new CreateProductForm(_serviceProvider);
            createProductForm.ProductCreated += (s, e) => RefreshProducts();
            createProductForm.ShowDialog();
        }

        public void SetNewProductButtonVisibility(bool visible)
        {
            btnNewProduct.Visible = visible;
        }

        public void SetEditProductButtonVisibility(bool visible)
        {
            btnEditProduct.Visible = visible;
            txtSelectedProduct.Visible = visible;
        }

        public void RefreshProducts()
        {
            LoadProducts?.Invoke(this, EventArgs.Empty);
        }

        public void ShowCreateSuggestionForm(Guid productID)
        {
            var createSuggestionForm = new CreateSuggestionForm(_serviceProvider, productID);
            createSuggestionForm.ShowDialog();
        }

        public Guid GetSelectedProductId()
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                var selectedRow = dgvProducts.SelectedRows[0];
                var product = selectedRow.DataBoundItem as ProductViewDto;
                if (product != null)
                {
                    return product.Id;
                }
            }
            return Guid.Empty;
        }
        public void ShowEditProductForm(Guid productId)
        {
            var editProductForm = new EditProductForm(_serviceProvider, productId);
            editProductForm.ShowDialog();
            RefreshProducts();
        }

        public List<ProductViewDto> ProductsDataSource 
        {
            set
            {
                dgvProducts.DataSource = value;
                if (dgvProducts.Columns.Count > 0)
                {
                    dgvProducts.ReadOnly = true;

                    dgvProducts.Columns["Id"].Visible = false;
                    dgvProducts.Columns["Name"].HeaderText = "Product Name";
                    dgvProducts.Columns["CreatedDate"].HeaderText = "Created Date";
                    dgvProducts.Columns["IsActive"].HeaderText = "Active";

                    dgvProducts.Columns["Description"].FillWeight = 250;
                    dgvProducts.Columns["Name"].FillWeight = 150;

                    dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        public string SelectedProductName
        {
            set => txtSelectedProduct.Text = value;
        }
    }
}
