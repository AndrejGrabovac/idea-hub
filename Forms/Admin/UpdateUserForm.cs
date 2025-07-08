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
    public partial class UpdateUserForm : Form, IUpdateUserView
    {
        public event EventHandler Save;
        public event EventHandler Cancel;
        public event EventHandler UserUpdated;

        public UpdateUserForm(IServiceProvider serviceProvider, Guid userId)
        {
            InitializeComponent();

            var updateUserPresenter = new UpdateUserPresenter(this, serviceProvider, userId);

            this.cmbRoles.DataSource = Enum.GetValues(typeof(UserRole));
            this.btnSave.Click += (s, e) => Save?.Invoke(this, EventArgs.Empty);
            this.btnCancel.Click += (s, e) => Cancel?.Invoke(this, EventArgs.Empty);
        }

        public UpdateUserDto UserToUpdate 
        {
            get => new UpdateUserDto
            {
                Id = new Guid(this.Tag.ToString()),
                Username = txtUsername.Text.Trim(),
                Password = txtNewPassword.Text.Trim(),
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Role = (UserRole)cmbRoles.SelectedItem,
                IsActive = chkIsActive.Checked
            };
            set
            {
                this.Tag = value.Id;
                txtUsername.Text = value.Username;
                txtFirstName.Text = value.FirstName;
                txtLastName.Text = value.LastName;
                txtEmail.Text = value.Email;
                cmbRoles.SelectedItem = value.Role;
                chkIsActive.Checked = value.IsActive;
            }
        }
        public string ConfirmPassword => txtConfirmPassword.Text.Trim();

        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void OnUserUpdated()
        {
            UserUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void CloseView()
        {
            this.Close();
        }
    }
}
