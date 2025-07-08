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

        public LoginPresenter(ILoginView loginView, IServiceProvider serviceProvider) 
        {
            _loginView = loginView ?? throw new ArgumentNullException(nameof(loginView));
            _authService = (IAuthService)serviceProvider.GetService(typeof(IAuthService));

            _loginView.LoginAttempted += OnLoginAttempted;
        }

        public void OnLoginAttempted(object sender, EventArgs e) 
        {
            try
            {
                string username = _loginView.Username;
                string password = _loginView.Password;

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    _loginView.ShowError("Username or password cannot be empty.");
                    return;
                }

                var loginDto = new LoginDto
                {
                    Username = username,
                    Password = password
                };

                if (_authService.Authenticate(loginDto))
                {
                    _loginView.LoginSuccessful();
                }
                else
                {
                    _loginView.ShowError("Invalid username or password.");
                    _loginView.ClearFields();
                }
            }
            catch (UnauthorizedAccessException ex) 
            {
                _loginView.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                _loginView.ShowError($"An error occurred during login: {ex.Message}");
            }
        }
    }
}
