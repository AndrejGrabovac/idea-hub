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
    public class CreateProductPresenter
    {
        private readonly ICreateProductView _createProductView;
        private readonly IProductService _productService;


        public CreateProductPresenter(ICreateProductView createProductView, IServiceProvider serviceProvider) 
        {
            _createProductView = createProductView;
            _productService = (IProductService)serviceProvider.GetService(typeof(IProductService));

            _createProductView.CreateProductAttempted += OnCreateProductAttempted;
        }

        private void OnCreateProductAttempted(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_createProductView.NewProductName))
            {
                _createProductView.ShowError("Product name cannot be empty.");
                return;
            }

            var createProductDto = new CreateProductDto
            {
                Name = _createProductView.NewProductName,
                Description = _createProductView.NewProductDescription
            };

            try
            {
                _productService.CreateProduct(createProductDto);
                _createProductView.ShowMessage("Product created successfully.");
                _createProductView.OnProductCreated();
                _createProductView.CloseView();
            }
            catch (Exception ex)
            {
                _createProductView.ShowError($"Failed to create product: {ex.Message}");
            }
        }
    }
}
