﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeaHub.Enums;

namespace IdeaHub.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public User()
        {   
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            Role = UserRole.User; //Default role is User
        }

        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
