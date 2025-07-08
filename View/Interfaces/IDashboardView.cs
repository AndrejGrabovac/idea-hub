using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.View.Interfaces
{
    public interface IDashboardView
    {
        event EventHandler ProductsClicked;
        event EventHandler SuggestionsClicked;
        event EventHandler UsersClicked;
        event EventHandler LogoutClicked;
        void CloseView();
        void SetUsersButtonVisibility(bool visible);
    }
}
