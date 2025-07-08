using IdeaHub.DTOs.Product;
using IdeaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.ProductMappers
{
    public static class ProductMapper
    {
        public static Product ToCreateProductDto(CreateProductDto dto) 
        {
            return new Product
            {
                Name = dto.Name,
                Description = dto.Description
            };
        }

        public static ProductViewDto ToViewProductDto(Product product)
        {
            return new ProductViewDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                CreatedDate = product.CreatedAt,
                IsActive = product.IsActive
            };
        }

        public static Product ToUpdateProductDto(UpdateProductDto dto) 
        {
            return new Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                IsActive = dto.IsActive,
            };
        }
    }
}
