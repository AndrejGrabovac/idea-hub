using IdeaHub.DTOs.User;
using IdeaHub.Enums;
using IdeaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Helpers
{
    public static class ApplicationContext
    {
        public static UserViewDto CurrentUser { get; internal set; }
        public static bool IsLoggedIn => CurrentUser != null;
        public static bool IsAdmin => CurrentUser?.Role == UserRole.Admin;
        public static void ClearCurrentUser()
        {
            CurrentUser = null;
        }
    }
}
