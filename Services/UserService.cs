using IdeaHub.Data;
using IdeaHub.DTOs.User;
using IdeaHub.Enums;
using IdeaHub.Services.Interfaces;
using IdeaHub.UserMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaHub.Helpers;
namespace IdeaHub.Services
{
    public class UserService : IUserService
    {
        public List<UserViewDto> GetAllUsers()
        {
            return InMemoryDatabase.Users.Select(u => UserMapper.ToViewUserDto(u)).ToList();
        }
        public UserViewDto GetUserById(Guid id)
        {
            var user = InMemoryDatabase.GetUserById(id);
            return user != null ? UserMapper.ToViewUserDto(user) : null;
        }
        public UserViewDto CreateUser(CreateUserDto createUserDto)
        {
            if (InMemoryDatabase.GetUserByUsername(createUserDto.Username) != null) 
            { 
                throw new InvalidOperationException($"Username '{createUserDto.Username}' already exists.");
            }
            var newUser = UserMapper.ToCreateUserDto(createUserDto);
            InMemoryDatabase.AddUser(newUser);
            return UserMapper.ToViewUserDto(newUser);

        }

        public UserViewDto UpdateUser(UpdateUserDto updateUserDto)
        {
            var existingUser = InMemoryDatabase.GetUserById(updateUserDto.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID '{updateUserDto.Id}' does not exist.");
            }

            if (!existingUser .Username.Equals(updateUserDto.Username, StringComparison.OrdinalIgnoreCase)) 
            {
                var userWithNewUsername = InMemoryDatabase.GetUserByUsername(updateUserDto.Username);
                if (userWithNewUsername != null && userWithNewUsername.Id != existingUser.Id)
                {
                    throw new InvalidOperationException($"Username '{updateUserDto.Username}' is already taken by another user.");
                }
            }


            existingUser.Username = updateUserDto.Username;
            existingUser.Password = updateUserDto.Password;
            existingUser.FirstName = updateUserDto.FirstName;
            existingUser.LastName = updateUserDto.LastName;
            existingUser.Email = updateUserDto.Email;
            existingUser.Role = updateUserDto.Role;
            existingUser.IsActive = updateUserDto.IsActive;

            InMemoryDatabase.UpdateUser(existingUser);
            return UserMapper.ToViewUserDto(existingUser);
        }

        public bool DeleteUser(Guid id)
        {
            var userToDelete = InMemoryDatabase.GetUserById(id);
            if (userToDelete == null)
            {
                return false;
            }

            if (userToDelete.Id == Helpers.UserSession.CurrentUser?.Id)
            {
                throw new InvalidOperationException("Cannot delete the currently logged-in user.");
            }
            InMemoryDatabase.DeleteUser(id);
            return true;
        }

        public UserRole? GetCurrentUserRole()
        {
            return Helpers.UserSession.CurrentUser?.Role;
        }

        public UserViewDto GetCurrentUser()
        {
            return UserSession.CurrentUser;
        }
    }
}
