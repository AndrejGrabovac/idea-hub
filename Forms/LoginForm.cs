using IdeaHub.Forms;
using IdeaHub.Presenters.Base;
using IdeaHub.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub
{
    public partial class LoginForm : Form, ILoginView
    {
        public event EventHandler LoginAttempted;
        public event EventHandler LoginSuccess;
        public Form LoginFormInstance => this;

        private readonly IServiceProvider _serviceProvider;

        public LoginForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;

            var loginPresenter = new LoginPresenter(this, _serviceProvider);

            this.btnLogin.Click += (sender, e) => LoginAttempted?.Invoke(sender, e);
        }

        public string Username
        {
            get => txtUsername.Text;
            set => txtUsername.Text = value;
        }
        public string Password
        {
            get => txtPassword.Text;
            set => txtPassword.Text = value;
        }

        public void ShowMessage(string message)
        {
            lblMessage.Text = message;
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Visible = true;
        }

        public void ShowError(string errorMessage)
        {
            lblMessage.Text = errorMessage;
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Visible = true;
        }

        public async void ClearFields()
        {
            await Task.Delay(1);
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }

        public void CloseView()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void LoginSuccessful()
        {
            LoginSuccess?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
