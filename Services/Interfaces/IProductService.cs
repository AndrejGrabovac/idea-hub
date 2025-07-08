using IdeaHub.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductViewDto> GetAllProducts();
        List<ProductViewDto> GetActiveProducts();
        ProductViewDto GetProductById(Guid id);
        ProductViewDto CreateProduct(CreateProductDto createProductDto);
        ProductViewDto UpdateProduct(UpdateProductDto updateProductDto);
        bool DeleteProduct(Guid id);
    }
}
