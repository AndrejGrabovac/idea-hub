using IdeaHub.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.DTOs.Suggestion
{
    public class UpdateSuggestionStatusDto
    {
        [Required(ErrorMessage = "Suggestion ID is required.")]
        public Guid SuggestionId { get; set; }
        public SuggestionStatus NewStatus { get; set; }
    }
}
