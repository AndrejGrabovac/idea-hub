using IdeaHub.Forms;
using IdeaHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.Helpers
{
    public class AppContext : ApplicationContext
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;
        private bool _isLoggingOut = false;

        public AppContext(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _authService = (IAuthService)_serviceProvider.GetService(typeof(IAuthService));
            _authService.LogoutCompleted += OnLogoutCompleted;
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            var loginForm = new LoginForm(_serviceProvider);
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
            var dashboardForm = new DashboardForm(_serviceProvider);
            dashboardForm.FormClosed += OnFormClosed;

            var oldMainForm = MainForm;
            MainForm = dashboardForm;

            MainForm.Show();
            oldMainForm?.Close();
        }

        private void OnLogoutCompleted(object sender, EventArgs e)
        {
            if (_isLoggingOut) return;
            _isLoggingOut = true;

            var openForms = Application.OpenForms.Cast<Form>().Where(f => f != MainForm).ToList();
            foreach (var form in openForms)
            {
                form.Close();
            }

            var oldDashboardForm = MainForm;
            if (oldDashboardForm != null)
            {
                oldDashboardForm.FormClosed -= OnFormClosed;
            }

            ShowLoginForm();

            oldDashboardForm?.Close();

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
