using IdeaHub.Data;
using IdeaHub.DTOs.Suggestion;
using IdeaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.SuggestionMappers
{
    public static class SuggestionMapper
    {
        public static Suggestion ToCreateSuggestionDto(CreateSuggestionDto dto) 
        {
            return new Suggestion
            {
                UserId = dto.UserId,
                ProductId = dto.ProductId,
                Title = dto.Title,
                Description = dto.Description,
                Status = Enums.SuggestionStatus.UnderReview // Default status
            };
        }

        public static SuggestionViewDto ToViewSuggestionDto(Suggestion suggestion)
        {
            var product = InMemoryDatabase.Products.FirstOrDefault(p => p.Id == suggestion.ProductId);
            var user = InMemoryDatabase.Users.FirstOrDefault(u => u.Id == suggestion.UserId);

            var dto =  new SuggestionViewDto
            {
                Id = suggestion.Id,
                Title = suggestion.Title,
                Description = suggestion.Description,
                Status = suggestion.Status,
                SubmittedDate = suggestion.CreatedAt,
                LastUpdatedDate = suggestion.LastUpdatedDate,
                UserId = suggestion.UserId
            };

            if (user != null)
            {
                dto.SubmittedBy = user.FullName();
            }
            else
            {
                dto.SubmittedBy = "Unknown User";
            }
            if (product != null)
            {
                dto.ProductName = product.Name;
            }
            else
            {
                dto.ProductName = "Unknown Product";
            }
            return dto;
        }

        public static Suggestion ToUpdateSuggestionStatusDto(UpdateSuggestionStatusDto dto)
        {
            return new Suggestion
            {
                Id = dto.SuggestionId,
                Status = dto.NewStatus,
                LastUpdatedDate = DateTime.Now // Update the last updated date
            };
        }
    }
}
