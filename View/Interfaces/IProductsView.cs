using IdeaHub.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.View.Interfaces
{
    public interface IProductsView
    {
        List<ProductViewDto> ProductsDataSource { set; }

        event EventHandler LoadProducts;
        event EventHandler<Guid> CreateSuggestionForProductClicked;
        event EventHandler NewProductClicked;
        event EventHandler EditProductClicked;
        event EventHandler LogoutClicked;
        string SelectedProductName { set; }
        Guid GetSelectedProductId();

        void ShowCreateProductForm();
        void ShowEditProductForm(Guid productId);
        void SetNewProductButtonVisibility(bool visible);
        void SetEditProductButtonVisibility(bool visible);
        void ShowError(string errorMessage);
        void SetIsActiveColumnVisibility(bool visible);
        void RefreshProducts();
        void ShowCreateSuggestionForm(Guid productID);
    }
}
