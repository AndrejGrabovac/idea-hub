using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.DTOs.Product
{
    public class UpdateProductDto
    {
        [Required(ErrorMessage = "Product ID is required for update.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Product Name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
