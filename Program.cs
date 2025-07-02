using IdeaHub.Forms;
using IdeaHub.Presenters.Base;
using IdeaHub.Services;
using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Data.DataSeeder.Seed();

            IAuthService authService = new AuthService();
            IUserService userService = new UserService();
            ISuggestionService suggestionService = new SuggestionService();

            Application.Run(new AppContext(authService, userService, suggestionService));
        }

        public class AppContext : ApplicationContext
        {
            private readonly IAuthService _authService;
            private readonly IUserService _userService;
            private readonly ISuggestionService _suggestionService;
            private bool _isLoggingOut = false;

            public AppContext(IAuthService authService, IUserService userService, ISuggestionService suggestionService)
            {
                _authService = authService;
                _userService = userService;
                _suggestionService = suggestionService;

                ShowLoginForm();
            }

            private void ShowLoginForm()
            {
                var loginForm = new LoginForm();
                var loginPresenter = new LoginPresenter(loginForm, _authService, _userService, _suggestionService);
                loginForm.LoginSuccess += OnLoginSuccess;
                loginForm.FormClosed += OnFormClosed;
                MainForm = loginForm;
                loginForm.Show();
            }

            private void OnLoginSuccess(object sender, EventArgs e)
            {
                if (sender is LoginForm loginForm)
                {
                    loginForm.LoginSuccess -= OnLoginSuccess;
                    loginForm.FormClosed -= OnFormClosed;
                }

                var suggestions = new SuggestionsForm();
                var suggestionsPresenter = new SuggestionsPresenter(suggestions, _suggestionService, _userService, _authService);
                suggestionsPresenter.LoggedOut += OnLoggedOut;
                suggestions.FormClosed += OnFormClosed;
                MainForm = suggestions;
                suggestions.Show();
            }

            private void OnLoggedOut(object sender, EventArgs e)
            {
                _isLoggingOut = true;

                var oldMainForm = MainForm;

                if (oldMainForm is SuggestionsForm suggestionsForm)
                {
                    suggestionsForm.FormClosed -= OnFormClosed;
                }
                if (sender is SuggestionsPresenter mainPresenter)
                {
                    mainPresenter.LoggedOut -= OnLoggedOut;
                }

                ShowLoginForm();

                oldMainForm?.Close();

                _isLoggingOut = false;
            }

            private void OnFormClosed(object sender, FormClosedEventArgs e)
            {
                if (!_isLoggingOut && Application.OpenForms.Count == 0)
                {
                    ExitThread();
                }
            }
        }
    }
}
