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
        public bool Authenticate(LoginDto loginDto)
        {
            if (string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
            {
                return false;
            }

            User user = InMemoryDatabase.GetUserByUsername(loginDto.Username);

            if (user == null)
            {
                return false;
            }

            if (user.Password == loginDto.Password && user.IsActive)
            {   
                UserViewDto userViewDto = UserMapper.ToViewUserDto(user);
                Helpers.ApplicationContext.CurrentUser = userViewDto;
                return true;
            }
            return false;
        }

        public void LogOut() 
        {
            Helpers.ApplicationContext.CurrentUser = null;
        }
    }
}
