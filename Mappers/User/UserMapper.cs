using IdeaHub.DTOs.Suggestion;
using IdeaHub.DTOs.User;
using IdeaHub.Extensions;
using IdeaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.UserMappers
{
    public static class UserMapper
    {
        public static User ToCreateUserDto(CreateUserDto dto)
        {
            return new User
            {
                Username = dto.Username,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Role = dto.Role,
                IsActive = dto.IsActive
            };
        }

        public static UserViewDto ToViewUserDto(User user)
        {
            return new UserViewDto
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName(),
                Email = user.Email,
                Role = user.Role,
                CreatedDate = user.CreatedAt,
                IsActive = user.IsActive
            };
        }

        public static User ToUpdateUserDto(UpdateUserDto dto)
        {
            return new User
            {
                Id = dto.Id,
                Username = dto.Username,
                Password = dto.Password,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Role = dto.Role,
                IsActive = dto.IsActive
            };
        }
    }
}
