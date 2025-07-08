using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IdeaHub.Data;
using IdeaHub.DTOs;
using IdeaHub.Models;
using IdeaHub.Services.Interfaces;
using IdeaHub.Helpers;
using IdeaHub.DTOs.User;
using IdeaHub.UserMappers;

namespace IdeaHub.Services
{
    public class AuthService : IAuthService
    {
        public event EventHandler LogoutCompleted;

        public bool Authenticate(LoginDto loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return false;
            }

            User user = InMemoryDatabase.GetUserByUsername(loginDto.Username);
            
            if (user == null || user.Password != loginDto.Password)
            {
                return false;
            }

            if (!user.IsActive)
            {
                throw new UnauthorizedAccessException("User account is inactive. Please contact an administrator.");
            }

            UserViewDto userViewDto = UserMapper.ToViewUserDto(user);
            Helpers.UserSession.CurrentUser = userViewDto;
            return true;
        }

        public void LogOut() 
        {
            Helpers.UserSession.CurrentUser = null;
            LogoutCompleted?.Invoke(this, EventArgs.Empty);

        }
    }
}
