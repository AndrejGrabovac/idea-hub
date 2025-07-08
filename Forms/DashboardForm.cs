using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdeaHub.Presenters.Base;
using IdeaHub.View.Interfaces;

namespace IdeaHub.Forms
{
    public partial class DashboardForm : Form, IDashboardView
    {
        private readonly IServiceProvider _serviceProvider;

        public event EventHandler ProductsClicked;
        public event EventHandler SuggestionsClicked;
        public event EventHandler UsersClicked;
        public event EventHandler LogoutClicked;

        public DashboardForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            var dashboardPresenter = new DashboardPresenter(this, _serviceProvider);

            btnProducts.Click += (s, e) => ProductsClicked?.Invoke(this, EventArgs.Empty);
            btnSuggestions.Click += (s, e) => SuggestionsClicked?.Invoke(this, EventArgs.Empty);
            btnUsers.Click += (s, e) => UsersClicked?.Invoke(this, EventArgs.Empty);
            btnLogout.Click += (s, e) => LogoutClicked?.Invoke(this, EventArgs.Empty);
        }

        public void CloseView()
        {
            this.Close();
        }

        public void SetUsersButtonVisibility(bool visible)
        {
            btnUsers.Visible = visible;
        }
    }
}
