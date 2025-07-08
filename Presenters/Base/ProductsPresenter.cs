using IdeaHub.Services;
using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using System;
using IdeaHub.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdeaHub.Enums;
using Microsoft.Extensions.DependencyInjection;
using IdeaHub.Forms.Admin;

namespace IdeaHub.Presenters.Base
{
    public class ProductsPresenter
    {
        private readonly IProductsView _productsView;
        private readonly IProductService _productService;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly IServiceProvider _serviceProvider;


        public ProductsPresenter(IProductsView productsView, IServiceProvider serviceProvider) 
        {
            _productsView = productsView ?? throw new ArgumentNullException(nameof(productsView));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            _productService = (IProductService)_serviceProvider.GetService(typeof(IProductService));
            _authService = (IAuthService)_serviceProvider.GetService(typeof(IAuthService));
            _userService = (IUserService)_serviceProvider.GetService(typeof(IUserService));

            _productsView.LoadProducts += OnLoadProducts;
            _productsView.CreateSuggestionForProductClicked += OnCreateSuggestionForProductClicked;
            _productsView.NewProductClicked += OnNewProductClicked;
            _productsView.EditProductClicked += OnEditProductClicked;
            _productsView.LogoutClicked += OnLogoutClicked;
        }

        private void OnEditProductClicked(object sender, EventArgs e)
        {
            Guid selectedProductId = _productsView.GetSelectedProductId();
            if (selectedProductId != Guid.Empty)
            {
                _productsView.ShowEditProductForm(selectedProductId);
            }
            else
            {
                _productsView.ShowError("Please select a product to edit.");
            }
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            _authService.LogOut();
        }

        private void OnNewProductClicked(object sender, EventArgs e)
        {
            _productsView.ShowCreateProductForm();
        }

        private void OnCreateSuggestionForProductClicked(object sender, Guid productID)
        {
            _productsView.ShowCreateSuggestionForm(productID);

        }

        private void OnLoadProducts(object sender, EventArgs e)
        {
            try
            {
                var currentUser = _userService.GetCurrentUser();
                if (currentUser.Role == UserRole.Admin)
                {
                    _productsView.ProductsDataSource = _productService.GetAllProducts();
                    _productsView.SetIsActiveColumnVisibility(true);
                    _productsView.SetNewProductButtonVisibility(true);
                    _productsView.SetEditProductButtonVisibility(true);
                }
                else
                {
                    _productsView.ProductsDataSource = _productService.GetActiveProducts();
                    _productsView.SetIsActiveColumnVisibility(false);
                    _productsView.SetNewProductButtonVisibility(false);
                    _productsView.SetEditProductButtonVisibility(false);
                }
            }
            catch (Exception ex)
            {
                _productsView.ShowError($"An error occurred while loading products: {ex.Message}");
            }
        }
    }
}
