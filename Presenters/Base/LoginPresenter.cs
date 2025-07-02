using IdeaHub.DTOs;
using IdeaHub.Enums;
using IdeaHub.Forms;
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
    public class LoginPresenter
    {
        private readonly ILoginView _loginView;
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ISuggestionService _suggestionService;

        public LoginPresenter(ILoginView loginView, IAuthService authService, IUserService userService, ISuggestionService suggestionService) 
        {
            _loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _suggestionService = suggestionService ?? throw new ArgumentNullException(nameof(suggestionService));

            _loginView.LoginAttempted += OnLoginAttempted;
        }

        public void OnLoginAttempted(object sender, EventArgs e) 
        {
            string username = _loginView.Username;
            string password = _loginView.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                _loginView.ShowError("Username and password cannot be empty.");
                _loginView.ClearFields();
                return;
            }

            var loginDto = new LoginDto 
            { 
                Username = username,
                Password = password 
            };

            try
            {
                if (_authService.Authenticate(loginDto))
                {
                    _loginView.LoginSuccessful();
                    _loginView.CloseView();
                }
                else
                {
                    _loginView.ShowError("Invalid username or password.");
                    _loginView.ClearFields();
                }
            }
            catch (Exception ex)
            {
                _loginView.ShowError($"An error occurred during login: {ex.Message}");
                Console.WriteLine($"Login Error: {ex}");
            }
        }
    }
}
