using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.Presenters.Admin
{
    public class UsersPresenter
    {
        private readonly IUsersView _usersView;
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public UsersPresenter(IUsersView usersView, IServiceProvider serviceProvider) 
        {
            _usersView = usersView ?? throw new ArgumentNullException(nameof(usersView));

            _userService = (IUserService)serviceProvider.GetService(typeof(IUserService));
            _authService = (IAuthService)serviceProvider.GetService(typeof(IAuthService));

            _usersView.LoadUsers += OnLoadUsers;
            _usersView.LogoutClicked += OnLogoutClicked;
            _usersView.NewUserClicked += OnNewUserClicked;
            _usersView.EditUserClicked += OnEditUserClicked;
        }

        private void OnEditUserClicked(object sender, EventArgs e)
        {
            var userId = _usersView.GetSelectedUserId();
            if (userId != Guid.Empty)
            {
                _usersView.ShowUpdateUserForm(userId);
            }
        }

        private void OnNewUserClicked(object sender, EventArgs e)
        {
            _usersView.ShowCreateUserForm();
            OnLoadUsers(sender, e);
        }

        private void OnLogoutClicked(object sender, EventArgs e)
        {
            _authService.LogOut();
            _usersView.CloseView();
        }

        private void OnLoadUsers(object sender, EventArgs e)
        {
            _usersView.UsersDataSource = _userService.GetAllUsers();
        }
    }
}
