using IdeaHub.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Services.Interfaces
{
    public interface IAuthService
    {
        bool Authenticate(LoginDto loginDto);
        void LogOut();
    }
}
