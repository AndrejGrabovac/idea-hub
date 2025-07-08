using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.View.Interfaces
{
    public interface ICreateSuggestionView
    {
        string SuggestionTitle { get; }
        string SuggestionDescription { get; }
        void ShowMessage(string message);
        void ShowError(string errorMessage);
        void CloseView();
        event EventHandler CreateSuggestionAttempted;
    }
}
