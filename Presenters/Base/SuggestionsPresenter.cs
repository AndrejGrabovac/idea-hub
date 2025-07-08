using IdeaHub.DTOs.Suggestion;
using IdeaHub.Enums;
using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.Presenters.Base
{
    public class SuggestionsPresenter
    {
        private readonly ISuggestionsView _suggestionsView;
        private readonly ISuggestionService _suggestionService;
        private readonly IUserService _userService;
        private readonly IProductService _productService;
        private readonly IAuthService _authService;

        public event EventHandler LoggedOut;

        public SuggestionsPresenter(ISuggestionsView suggestionsView, IServiceProvider serviceProvider)
        {
            _suggestionsView = suggestionsView ?? throw new ArgumentNullException(nameof(suggestionsView));
            _suggestionService = (ISuggestionService)serviceProvider.GetService(typeof(ISuggestionService));
            _userService = (IUserService)serviceProvider.GetService(typeof(IUserService));
            _productService = (IProductService)serviceProvider.GetService(typeof(IProductService));
            _authService = (IAuthService)serviceProvider.GetService(typeof(IAuthService));

            _suggestionsView.LoadSuggestions += OnLoadSuggestions;
            _suggestionsView.ChangeSuggestionStatusAttempted += OnChangeSuggestionStatusAttempted;
            _suggestionsView.SuggestionSelected += OnSuggestionSelected;
            _suggestionsView.FilterClicked += OnFilterClicked;
            _suggestionsView.ClearFilterClicked += OnClearFilterClicked;
            _suggestionsView.LogoutClicked += OnLogoutClicked;
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
                    _suggestionsView.ShowError("User not logged in. Please log in again.");
                    _suggestionsView.CloseView();
                    return;
                }

                _suggestionsView.LoggedInUserMessage = $"Logged in as {currentUser.Username} ({currentUser.Role}).";

                if (currentUser.Role == UserRole.Admin)
                {   
                    _suggestionsView.SuggestionsDataSource = _suggestionService.GetAllSuggestions();
                    _suggestionsView.SetFilterControlsVisibility(true);
                    _suggestionsView.UserFilterDataSource = _userService.GetAllUsers();
                    _suggestionsView.ProductFilterDataSource = _productService.GetAllProducts();
                    _suggestionsView.SetStatusChangeControlsVisibility(true);
                    _suggestionsView.SetStatusChangeControlsEnabled(false);
                }
                else if (currentUser.Role == UserRole.User)
                {
                    _suggestionsView.SuggestionsDataSource = _suggestionService.GetSuggestionsByUserId(currentUser.Id);
                    _suggestionsView.SetFilterControlsVisibility(false);
                    _suggestionsView.SetStatusChangeControlsVisibility(false);
                }
                else
                {
                    _suggestionsView.ShowError("Unknown user role. Contact support.");
                    _suggestionsView.SetStatusChangeControlsVisibility(false);
                }
                _suggestionsView.LoggedInUserMessage = $"Logged in as {currentUser.Username} ({currentUser.Role}).";

            }
            catch (Exception ex)
            {
                _suggestionsView.ShowError($"Error loading suggestions: {ex.Message}");
                Console.WriteLine($"Error in MainPresenter.OnLoadSuggestions: {ex}");
            }
        }


        private void OnChangeSuggestionStatusAttempted(object sender, EventArgs e)
        {
            if (_suggestionsView.SelectedSuggestionId == Guid.Empty)
            {
                _suggestionsView.ShowMessage("Please select a suggestion to update.");
                return;
            }

            if (_suggestionsView.SelectedSuggestionCurrentStatus == _suggestionsView.NewStatusToApply)
            {
                _suggestionsView.ShowMessage("The new status is the same as the current status.");
                return;
            }

            try
            {
                var updateDto = new UpdateSuggestionStatusDto
                {
                    SuggestionId = _suggestionsView.SelectedSuggestionId,
                    NewStatus = _suggestionsView.NewStatusToApply
                };

                var updatedSuggestion = _suggestionService.UpdateSuggestionStatus(updateDto);
                if (updatedSuggestion != null)
                {
                    _suggestionsView.ShowMessage("Suggestion status updated successfully.");
                    OnLoadSuggestions(sender, e);
                }
                else
                {
                    _suggestionsView.ShowError("Failed to update suggestion status.");
                }
            }
            catch (Exception ex)
            {
                _suggestionsView.ShowError($"An error occurred: {ex.Message}");
            }
        }
        private void OnSuggestionSelected(object sender, EventArgs e)
        {
            var currentUser = _userService.GetCurrentUser();
            bool isSuggestionSelected = _suggestionsView.SelectedSuggestionId != Guid.Empty;
            _suggestionsView.SetStatusChangeControlsEnabled(isSuggestionSelected && currentUser?.Role == UserRole.Admin);
        }

        private void OnFilterClicked(object sender, EventArgs e)
        {
            try
            {
                var filterDto = new SuggestionFilterDto
                {
                    StartDate = _suggestionsView.FilterStartDate,
                    EndDate = _suggestionsView.FilterEndDate,
                    UserId = _suggestionsView.FilterByUserId,
                    ProductId = _suggestionsView.FilterByProductId,
                    Status = _suggestionsView.FilterByStatus
                };

                var filteredSuggestions = _suggestionService.GetFilteredSuggestions(filterDto);
                _suggestionsView.SuggestionsDataSource = filteredSuggestions;
            }
            catch (Exception ex)
            {
                _suggestionsView.ShowError($"An error occurred while applying filters: {ex.Message}");
            }
        }

        private void OnClearFilterClicked(object sender, EventArgs e)
        {
            try
            {
                _suggestionsView.ClearFilters();
                var suggestions = _suggestionService.GetAllSuggestions();
                _suggestionsView.SuggestionsDataSource = suggestions;
            }
            catch (Exception ex)
            {
                _suggestionsView.ShowError($"An error occurred while clearing filters: {ex.Message}");
            }
        }
    }
}
