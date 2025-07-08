using IdeaHub.DTOs.User;
using IdeaHub.Services.Interfaces;
using IdeaHub.View.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IdeaHub.Presenters.Admin
{
    public class UpdateUserPresenter
    {
        private readonly IUpdateUserView _updateUserView;
        private readonly IUserService _userService;
        private readonly Guid _userId;

        public UpdateUserPresenter(IUpdateUserView updateUserView, IServiceProvider serviceProvider, Guid userId) 
        {
            _updateUserView = updateUserView ?? throw new ArgumentNullException(nameof(updateUserView));
            _userService = serviceProvider.GetService<IUserService>();
            _userId = userId;

            _updateUserView.Save += OnSave;
            _updateUserView.Cancel += OnCancel;

            LoadUserDetails();
        }

        private void LoadUserDetails()
        {
            var user = _userService.GetUserById(_userId);
            if (user != null)
            {
                _updateUserView.UserToUpdate = new UpdateUserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    FirstName = user.FullName.Split(' ')[0],
                    LastName = user.FullName.Split(' ').Length > 1 ? user.FullName.Split(' ')[1] : "",
                    Email = user.Email,
                    Role = user.Role,
                    IsActive = user.IsActive
                };
            }
        }
        private void OnSave(object sender, EventArgs e)
        {
            try
            {
                var userToUpdate = _updateUserView.UserToUpdate;

                if (!ValidateUserInput(userToUpdate))
                {
                    return;
                }

                _userService.UpdateUser(userToUpdate);
                _updateUserView.ShowMessage("User updated successfully.");
                _updateUserView.OnUserUpdated();
                _updateUserView.CloseView();
            }
            catch (Exception ex)
            {
                _updateUserView.ShowError($"Failed to update user: {ex.Message}");
            }
        }

        private void OnCancel(object sender, EventArgs e)
        {
            _updateUserView.CloseView();
        }

        private bool ValidateUserInput(UpdateUserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) ||
                string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email))
            {
                _updateUserView.ShowError("All fields except password are required.");
                return false;
            }

            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                if (user.Password.Length < 6)
                {
                    _updateUserView.ShowError("Password must be at least 6 characters long.");
                    return false;
                }

                if (user.Password != _updateUserView.ConfirmPassword)
                {
                    _updateUserView.ShowError("Passwords do not match.");
                    return false;
                }
            }

            try
            {
                new MailAddress(user.Email);
            }
            catch (FormatException)
            {
                _updateUserView.ShowError("The email address is not in a valid format.");
                return false;
            }

            return true;
        }

    }
}
