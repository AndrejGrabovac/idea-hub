using IdeaHub.Data;
using IdeaHub.DTOs.Product;
using IdeaHub.ProductMappers;
using IdeaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Services
{
    public class ProductService : IProductService
    {
        public List<ProductViewDto> GetAllProducts()
        {
            return InMemoryDatabase.Products.Select(p => ProductMapper.ToViewProductDto(p)).ToList();
        }

        public ProductViewDto GetProductById(Guid id)
        {
            var product = InMemoryDatabase.GetProductById(id);
            return product != null ? ProductMapper.ToViewProductDto(product) : null;
        }

        public ProductViewDto CreateProduct(CreateProductDto createProductDto)
        {
            if (InMemoryDatabase.Products.Any(p => p.Name.Equals(createProductDto.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"Product with name '{createProductDto.Name}' already exists.");
            }

            var newProduct = ProductMapper.ToCreateProductDto(createProductDto);
            InMemoryDatabase.AddProduct(newProduct);
            return ProductMapper.ToViewProductDto(newProduct);
        }

        public ProductViewDto UpdateProduct(UpdateProductDto updateProductDto)
        {
            var existingProduct = InMemoryDatabase.GetProductById(updateProductDto.Id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID '{updateProductDto.Id}' not found.");
            }

            if (!existingProduct.Name.Equals(updateProductDto.Name, StringComparison.OrdinalIgnoreCase))
            {
                var productWithNewName = InMemoryDatabase.Products.FirstOrDefault(p => p.Name.Equals(updateProductDto.Name, StringComparison.OrdinalIgnoreCase));
                if (productWithNewName != null && productWithNewName.Id != existingProduct.Id)
                {
                    throw new InvalidOperationException($"Product name '{updateProductDto.Name}' is already taken by another product.");
                }
            }

            ProductMapper.ToUpdateProductDto(updateProductDto);
            InMemoryDatabase.UpdateProduct(existingProduct);
            return ProductMapper.ToViewProductDto(existingProduct);
        }

        public bool DeleteProduct(Guid id)
        {
            var productToDelete = InMemoryDatabase.GetProductById(id);
            if (productToDelete == null)
            {
                return false;
            }

            if (InMemoryDatabase.Suggestions.Any(s => s.ProductId == id))
            {
                throw new InvalidOperationException($"Cannot delete product '{productToDelete.Name}' as it has associated suggestions.");
            }
            InMemoryDatabase.DeleteProduct(id);
            return true;
        }
    }
}
