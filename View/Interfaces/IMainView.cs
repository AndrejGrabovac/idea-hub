using IdeaHub.DTOs.Suggestion;
using IdeaHub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.View.Interfaces
{
    public interface IMainView
    {   
        string LoggedInUserMessage { get; set; }
        List<SuggestionViewDto> SuggestionsDataSource { get; set; }
        Guid SelectedSuggestionId { get; }
        SuggestionStatus SelectedSuggestionCurrentStatus { get; }
        SuggestionStatus NewStatusToApply { get; }
        void SetStatusChangeControlsEnabled(bool enabled);
        void ShowMessage(string message);
        void ShowError(string errorMessage);
        void RefreshSuggestions();
        void CloseView();

        event EventHandler LogoutClicked;
        event EventHandler LoadSuggestions;
        event EventHandler ChangeSuggestionStatusAttempted;
        event EventHandler SuggestionSelected;

        Form MainFormInstance { get; }
    }
}
