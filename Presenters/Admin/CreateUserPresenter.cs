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
    public class CreateUserPresenter
    {   private readonly ICreateUserView _createUserView;
        private readonly IUserService _userService;

        public CreateUserPresenter(ICreateUserView createUserView, IServiceProvider serviceProvider) 
        {
            _createUserView = createUserView ?? throw new ArgumentNullException(nameof(createUserView));
            _userService = serviceProvider.GetService<IUserService>();

            _createUserView.Save += OnSave;
            _createUserView.Cancel += OnCancel;
        }


        private void OnSave(object sender, EventArgs e)
        {
            try
            {
                var newUser = _createUserView.NewUser;

                if (!ValidateUserInput(newUser))
                {
                    return;
                }

                _userService.CreateUser(newUser);
                _createUserView.ShowMessage("User created successfully.");
                _createUserView.CloseView();
            }
            catch (Exception ex)
            {
                _createUserView.ShowError(ex.Message);
            }
        }
        private bool ValidateUserInput(CreateUserDto user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) ||
                string.IsNullOrWhiteSpace(user.Password) ||
                string.IsNullOrWhiteSpace(user.FirstName) ||
                string.IsNullOrWhiteSpace(user.LastName) ||
                string.IsNullOrWhiteSpace(user.Email))
            {
                _createUserView.ShowError("All fields are required. Please fill out the entire form.");
                return false;
            }

            if (user.Password.Length < 6)
            {
                _createUserView.ShowError("Password must be at least 6 characters long.");
                return false;
            }

            try
            {
                var mailAddress = new MailAddress(user.Email);
            }
            catch (FormatException)
            {
                _createUserView.ShowError("The email address is not in a valid format.");
                return false;
            }

            return true;
        }

        private void OnCancel(object sender, EventArgs e)
        {
            _createUserView.CloseView();
        }
    }
}
