using IdeaHub.DTOs.Suggestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Services.Interfaces
{
    public interface ISuggestionService
    {
        List<SuggestionViewDto> GetAllSuggestions();
        SuggestionViewDto GetSuggestionById(Guid id);
        SuggestionViewDto CreateSuggestion(CreateSuggestionDto createSuggestionDto);
        SuggestionViewDto UpdateSuggestionStatus(UpdateSuggestionStatusDto updateStatusDto);
        List<SuggestionViewDto> GetSuggestionsByUserId(Guid userId);
        List<SuggestionViewDto> GetFilteredSuggestions(SuggestionFilterDto filterDto);

        bool DeleteSuggestion(Guid id);
    }
}
