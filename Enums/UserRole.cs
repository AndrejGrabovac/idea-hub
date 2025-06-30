using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Enums
{
    public enum UserRole
    {
        [Description("User")]
        User = 1,

        [Description("Admin")]
        Admin = 2
    }
}
