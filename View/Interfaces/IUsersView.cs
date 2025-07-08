using IdeaHub.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.View.Interfaces
{
    public interface IUsersView
    {
        event EventHandler LoadUsers;
        event EventHandler LogoutClicked;
        event EventHandler NewUserClicked;
        event EventHandler EditUserClicked;

        List<UserViewDto> UsersDataSource { get; set; }
        string SelectedUserName { set; }

        void ShowCreateUserForm();
        void ShowUpdateUserForm(Guid userId);
        Guid GetSelectedUserId();
        void CloseView();

    }
}
