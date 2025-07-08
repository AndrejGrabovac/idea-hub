using IdeaHub.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.View.Interfaces
{
    public interface IUpdateUserView
    {
        event EventHandler Save;
        event EventHandler Cancel;
        event EventHandler UserUpdated;

        UpdateUserDto UserToUpdate { get; set;  }
        string ConfirmPassword { get;}
        void OnUserUpdated();
        void ShowMessage(string message);
        void ShowError(string message);
        void CloseView();
    }
}
