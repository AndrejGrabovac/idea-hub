using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.View.Interfaces
{
    public interface IEditProductView
    {
        Guid ProductId { get; set; }
        string ProductName { get; set; }
        string ProductDescription { get; set; }
        bool IsProductActive { get; set; }

        event EventHandler SaveClicked;
        event EventHandler CancelClicked;

        void ShowView();
        void CloseView();
        void ShowError(string message);
        void ShowMessage(string message);
    }
}
