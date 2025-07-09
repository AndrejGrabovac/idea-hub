using IdeaHub.DTOs.Product;
using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.Presenters.Admin
{
    public class EditProductPresenter
    {
        private readonly IEditProductView _editProductView;
        private readonly IProductService _productService;
        private readonly Guid _productId;

        public EditProductPresenter(IEditProductView editProductView, IServiceProvider serviceProvider, Guid productId) 
        {
            _editProductView = editProductView;
            _productId = productId;

            _productService = (IProductService)serviceProvider.GetService(typeof(IProductService));

            _editProductView.SaveClicked += OnSaveClicked;
            _editProductView.CancelClicked += OnCancelClicked;

            LoadProductDetails();
        }

        private void LoadProductDetails()
        {
            var product = _productService.GetProductById(_productId);
            if (product != null)
            {
                _editProductView.ProductId = product.Id;
                _editProductView.ProductName = product.Name;
                _editProductView.ProductDescription = product.Description;
                _editProductView.IsProductActive = product.IsActive;
            }
            else
            {
                _editProductView.ShowMessage("Product not found.");
                _editProductView.CloseView();
            }
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            _editProductView.CloseView();
        }

        private void OnSaveClicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(_editProductView.ProductName))
                {
                    _editProductView.ShowError("Product Name is required.");
                    return;
                }

                var updateDto = new UpdateProductDto
                {
                    Id = _editProductView.ProductId,
                    Name = _editProductView.ProductName,
                    Description = _editProductView.ProductDescription,
                    IsActive = _editProductView.IsProductActive
                };

                _productService.UpdateProduct(updateDto);
                _editProductView.CloseView();
            }
            catch (Exception ex)
            {
                _editProductView.ShowMessage($"Error: {ex.Message }");
            }
        }
    }
}
