using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.View.Interfaces
{
    public interface ILoginView
    {
        string Username { get; set; }
        string Password { get; set; }

        void ShowMessage(string message);
        void ShowError(string errorMessage);
        void ClearFields();
        void CloseView();
        void LoginSuccessful();

        event EventHandler LoginAttempted;
        event EventHandler LoginSuccess;
        Form LoginFormInstance { get; }

    }
}
