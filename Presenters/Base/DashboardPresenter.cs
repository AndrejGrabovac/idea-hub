using IdeaHub.Enums;
using IdeaHub.Forms;
using IdeaHub.Forms.Admin;
using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Presenters.Base
{
    public class DashboardPresenter
    {
        private readonly IDashboardView _dashboardView;
        private readonly IServiceProvider _serviceProvider;
        private readonly IAuthService _authService;

        public DashboardPresenter(IDashboardView dashboardView, IServiceProvider serviceProvider)
        {
            _dashboardView = dashboardView ?? throw new ArgumentNullException(nameof(dashboardView));
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            _authService = (IAuthService)_serviceProvider.GetService(typeof(IAuthService));

            var userService = (IUserService)_serviceProvider.GetService(typeof(IUserService));

            var currentUser = userService.GetCurrentUser();

            _dashboardView.SetUsersButtonVisibility(currentUser?.Role == UserRole.Admin);
            
            _dashboardView.ProductsClicked += OnProductsClicked;
            _dashboardView.SuggestionsClicked += OnSuggestionsClicked;
            _dashboardView.UsersClicked += OnUsersClicked;
            _dashboardView.LogoutClicked += OnLogoutClicked;
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            _authService.LogOut();  
        }

        private void OnProductsClicked(object sender, EventArgs e)
        {
            var productsForm = new ProductsForm(_serviceProvider);
            productsForm.Show();
        }

        private void OnSuggestionsClicked(object sender, EventArgs e)
        {
            var suggestionsForm = new SuggestionsForm(_serviceProvider);
            suggestionsForm.Show();

        }

        private void OnUsersClicked(object sender, EventArgs e)
        {
            var usersForm = new UsersForm(_serviceProvider);
            usersForm.Show();
        }

    }
}
