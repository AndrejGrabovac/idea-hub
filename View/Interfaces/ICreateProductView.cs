using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.View.Interfaces
{
    public interface ICreateProductView
    {
        string NewProductName { get; }
        string NewProductDescription { get; }

        event EventHandler CreateProductAttempted;

        void ShowMessage(string message);
        void ShowError(string message);
        void CloseView();

        void OnProductCreated();
    }
}
