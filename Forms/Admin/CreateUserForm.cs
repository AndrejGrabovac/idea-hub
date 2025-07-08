using IdeaHub.DTOs.User;
using IdeaHub.Enums;
using IdeaHub.Presenters.Admin;
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

namespace IdeaHub.Forms.Admin
{
    public partial class CreateUserForm : Form, ICreateUserView
    {
        public event EventHandler Save;
        public event EventHandler Cancel;

        public CreateUserForm(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            var createUserPresenter = new CreateUserPresenter(this, serviceProvider);

            this.cmbRoles.DataSource = Enum.GetValues(typeof(UserRole));

            this.btnSave.Click += (s, e) => Save?.Invoke(this, EventArgs.Empty);
            this.btnCancel.Click += (s, e) => Cancel?.Invoke(this, EventArgs.Empty);
        }

        public CreateUserDto NewUser 
        {
            get => new CreateUserDto
            {
                Username = txtUsername.Text.Trim(),
                Password = txtPassword.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Role = (UserRole)cmbRoles.SelectedItem,
                IsActive = chkIsActive.Checked
            };
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void CloseView()
        {
            this.Close();
        }

    }
}
