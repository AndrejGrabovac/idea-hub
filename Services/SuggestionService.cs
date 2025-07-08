using IdeaHub.Data;
using IdeaHub.DTOs.Suggestion;
using IdeaHub.Models;
using IdeaHub.Services.Interfaces;
using IdeaHub.SuggestionMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Services
{
    internal class SuggestionService : ISuggestionService
    {
        public List<SuggestionViewDto> GetAllSuggestions()
        {
            return InMemoryDatabase.Suggestions
                                   .Select(s => SuggestionMapper.ToViewSuggestionDto(s))
                                   .ToList();
        }

        public SuggestionViewDto GetSuggestionById(Guid id)
        {
            var suggestion = InMemoryDatabase.Suggestions.FirstOrDefault(s => s.Id == id);
            return SuggestionMapper.ToViewSuggestionDto(suggestion);
        }

        public SuggestionViewDto CreateSuggestion(CreateSuggestionDto createSuggestionDto)
        {
            var submittingUser = InMemoryDatabase.GetUserById(createSuggestionDto.UserId);
            if (submittingUser == null)
            {
                throw new KeyNotFoundException($"User with ID '{createSuggestionDto.UserId}' not found. Cannot create suggestion.");
            }

            var targetProduct = InMemoryDatabase.GetProductById(createSuggestionDto.ProductId);
            if (targetProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID '{createSuggestionDto.ProductId}' not found. Cannot create suggestion.");
            }
            if (!targetProduct.IsActive)
            {
                throw new InvalidOperationException($"Product '{targetProduct.Name}' is not active. Cannot submit suggestions for inactive products.");
            }

            var newSuggestion = SuggestionMapper.ToCreateSuggestionDto(createSuggestionDto);
            InMemoryDatabase.AddSuggestion(newSuggestion);
            return SuggestionMapper.ToViewSuggestionDto(newSuggestion);
        }

        public SuggestionViewDto UpdateSuggestionStatus(UpdateSuggestionStatusDto updateStatusDto)
        {
            var suggestionToUpdate = InMemoryDatabase.Suggestions.FirstOrDefault(s => s.Id == updateStatusDto.SuggestionId);

            if (suggestionToUpdate == null)
            {
                return null;
            }

            suggestionToUpdate.Status = updateStatusDto.NewStatus;
            suggestionToUpdate.LastUpdatedDate = DateTime.Now;

            return SuggestionMapper.ToViewSuggestionDto(suggestionToUpdate);
        }

        public bool DeleteSuggestion(Guid id)
        {
            var suggestionToDelete = InMemoryDatabase.GetSuggestionById(id);
            if (suggestionToDelete == null)
            {
                return false;
            }

            InMemoryDatabase.DeleteSuggestion(id);
            return true;
        }

        public List<SuggestionViewDto> GetSuggestionsByUserId(Guid userId)
        {
            return InMemoryDatabase.Suggestions
                                   .Where(s => s.UserId == userId)
                                   .Select(s => SuggestionMapper.ToViewSuggestionDto(s))
                                   .ToList();
        }

        public List<SuggestionViewDto> GetFilteredSuggestions(SuggestionFilterDto filterDto)
        {
            var query = InMemoryDatabase.Suggestions.AsQueryable();

            if (filterDto.StartDate.HasValue)
            {
                query = query.Where(s => s.CreatedAt.Date >= filterDto.StartDate.Value.Date);
            }
            if (filterDto.EndDate.HasValue)
            {
                query = query.Where(s => s.CreatedAt.Date <= filterDto.EndDate.Value.Date);
            }
            if (filterDto.UserId.HasValue)
            {
                query = query.Where(s => s.UserId == filterDto.UserId.Value);
            }
            if (filterDto.ProductId.HasValue)
            {
                query = query.Where(s => s.ProductId == filterDto.ProductId.Value);
            }
            if (filterDto.Status.HasValue)
            {
                query = query.Where(s => s.Status == filterDto.Status.Value);
            }

            return 
                query.Select(s => SuggestionMapper.ToViewSuggestionDto(s)).ToList();
        }
    }
}
