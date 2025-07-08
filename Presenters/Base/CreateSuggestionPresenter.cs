using IdeaHub.DTOs.Suggestion;
using IdeaHub.Models;
using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace IdeaHub.Presenters.Base
{
    public class CreateSuggestionPresenter
    {
        private readonly ICreateSuggestionView _createSuggestionView;
        private readonly ISuggestionService _suggestionService;
        private readonly IUserService _userService;
        private readonly Guid _productId;

        public CreateSuggestionPresenter(ICreateSuggestionView createSuggestionView, IServiceProvider serviceProvider, Guid productId) 
        {
            _createSuggestionView = createSuggestionView ?? throw new ArgumentNullException(nameof(createSuggestionView));
            _suggestionService = (ISuggestionService)serviceProvider.GetService(typeof(ISuggestionService));
            _userService = (IUserService)serviceProvider.GetService(typeof(IUserService));
            _productId = productId;

            _createSuggestionView.CreateSuggestionAttempted += OnCreateSuggestionAttempted;
        }

        private void OnCreateSuggestionAttempted(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_createSuggestionView.SuggestionTitle))
            {
                _createSuggestionView.ShowError("Suggestion title cannot be empty.");
                return;
            }

            var currentUser = _userService.GetCurrentUser();
            if (currentUser == null)
            {
                _createSuggestionView.ShowError("No logged-in user found. Please log in again.");
                return;
            }

            var createSuggestionDto = new CreateSuggestionDto
            {
                Title = _createSuggestionView.SuggestionTitle,
                Description = _createSuggestionView.SuggestionDescription,
                ProductId = _productId,
                UserId = currentUser.Id
            };

            try
            {
                _suggestionService.CreateSuggestion(createSuggestionDto);
                _createSuggestionView.ShowMessage("Suggestion submitted successfully.");
                _createSuggestionView.CloseView();
            }
            catch (Exception ex)
            {
                _createSuggestionView.ShowError($"Failed to submit suggestion: {ex.Message}");
            }
        }
    }
}
