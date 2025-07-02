using IdeaHub.DTOs.User;
using IdeaHub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewDto> GetAllUsers();
        UserViewDto GetUserById(Guid id);
        UserViewDto CreateUser(CreateUserDto createUserDto);
        UserViewDto UpdateUser(UpdateUserDto updateUserDto);
        UserViewDto GetCurrentUser();
        bool DeleteUser(Guid id);
        UserRole? GetCurrentUserRole();

    }
}
