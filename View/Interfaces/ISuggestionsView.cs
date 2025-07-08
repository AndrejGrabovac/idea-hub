using IdeaHub.DTOs.Product;
using IdeaHub.DTOs.Suggestion;
using IdeaHub.DTOs.User;
using IdeaHub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.View.Interfaces
{
    public interface ISuggestionsView
    {   
        event EventHandler LoadSuggestions;
        event EventHandler ChangeSuggestionStatusAttempted;
        event EventHandler SuggestionSelected;
        event EventHandler FilterClicked;
        event EventHandler ClearFilterClicked;
        event EventHandler LoggedOut;
        event EventHandler LogoutClicked;


        string LoggedInUserMessage { get; set; }
        List<SuggestionViewDto> SuggestionsDataSource { get; set; }
        List<UserViewDto> UserFilterDataSource { set; }
        List<ProductViewDto> ProductFilterDataSource { set; }

        DateTime? FilterStartDate { get; }
        DateTime? FilterEndDate { get; }
        Guid? FilterByUserId { get; }
        Guid? FilterByProductId { get; }
        SuggestionStatus? FilterByStatus { get;}

        Guid SelectedSuggestionId { get; }
        SuggestionStatus NewStatusToApply { get; }
        SuggestionStatus SelectedSuggestionCurrentStatus { get; }

        void SetStatusChangeControlsEnabled(bool enabled);
        void SetFilterControlsVisibility(bool visible);
        void SetStatusChangeControlsVisibility(bool visible);
        void ShowMessage(string message);
        void ShowError(string errorMessage);
        void RefreshSuggestions();
        void CloseView();
        void ClearFilters();
    }
}
