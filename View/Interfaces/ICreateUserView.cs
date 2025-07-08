using IdeaHub.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.View.Interfaces
{
    public interface ICreateUserView
    {
        event EventHandler Save;
        event EventHandler Cancel;

        CreateUserDto NewUser { get; }

        void ShowMessage(string message);
        void ShowError(string message);
        void CloseView();

    }
}
