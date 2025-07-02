using IdeaHub.DTOs.Suggestion;
using IdeaHub.Enums;
using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Presenters.Base
{
    public class SuggestionsPresenter
    {
        private readonly IMainView _mainView;
        private readonly ISuggestionService _suggestionService;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public event EventHandler LoggedOut;

        public SuggestionsPresenter(IMainView mainView, ISuggestionService suggestionService, IUserService userService, IAuthService authService)
        {
            _mainView = mainView ?? throw new ArgumentNullException(nameof(mainView));
            _suggestionService = suggestionService ?? throw new ArgumentNullException(nameof(suggestionService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));

            _mainView.LoadSuggestions += OnLoadSuggestions;
            _mainView.ChangeSuggestionStatusAttempted += OnChangeSuggestionStatusAttempted;
            _mainView.LogoutClicked += OnLogoutClicked;

            OnLoadSuggestions(this, EventArgs.Empty);
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            _authService.LogOut();
            LoggedOut?.Invoke(this, EventArgs.Empty);
        }

        private void OnLoadSuggestions(Object sender, EventArgs e)
        {
            try
            {
                var currentUser = _userService.GetCurrentUser();
                if (currentUser == null)
                {
                    _mainView.ShowError("User not logged in. Please log in again.");
                    _mainView.CloseView();
                    return;
                }
                if (currentUser.Role == UserRole.Admin)
                {
                    _mainView.SuggestionsDataSource = _suggestionService.GetAllSuggestions();
                    _mainView.SetStatusChangeControlsEnabled(true);
                }
                else if (currentUser.Role == UserRole.User)
                {
                    _mainView.SuggestionsDataSource = _suggestionService.GetSuggestionsByUserId(currentUser.Id);
                    _mainView.SetStatusChangeControlsEnabled(false);
                }
                else
                {
                    _mainView.ShowError("Unknown user role. Contact support.");
                    _mainView.SetStatusChangeControlsEnabled(false);
                }
                _mainView.LoggedInUserMessage = $"Logged in as {currentUser.Username} ({currentUser.Role}).";

            }
            catch (Exception ex)
            {
                _mainView.ShowError($"Error loading suggestions: {ex.Message}");
                Console.WriteLine($"Error in MainPresenter.OnLoadSuggestions: {ex}");
            }
        }


        private void OnChangeSuggestionStatusAttempted(object sender, EventArgs e)
        {
            try
            {
                var currentUser = _userService.GetCurrentUser();
                if (currentUser == null || currentUser.Role != UserRole.Admin)
                {
                    _mainView.ShowError("You do not have permission to change suggestion status.");
                    return;
                }

                Guid selectedId = _mainView.SelectedSuggestionId;
                SuggestionStatus newStatus = _mainView.NewStatusToApply;

                if (selectedId == Guid.Empty)
                {
                    _mainView.ShowError("Please select a suggestion to update.");
                    return;
                }

                var updateDto = new UpdateSuggestionStatusDto
                {
                    SuggestionId = selectedId,
                    NewStatus = newStatus
                };

                SuggestionViewDto updatedSuggestion = _suggestionService.UpdateSuggestionStatus(updateDto);

                if (updatedSuggestion != null)
                {
                    _mainView.ShowMessage($"Suggestion '{updatedSuggestion.Title}' status updated to: {updatedSuggestion.Status}");
                    _mainView.RefreshSuggestions();
                }
                else
                {
                    _mainView.ShowError("Failed to update suggestion status. Suggestion not found.");
                }
            }
            catch (InvalidOperationException ex)
            {
                _mainView.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                _mainView.ShowError($"An error occurred while updating status: {ex.Message}");
                Console.WriteLine($"Error in MainPresenter.OnChangeSuggestionStatusAttempted: {ex}");
            }
        }
    }
}
