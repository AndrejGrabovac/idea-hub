using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Enums
{
    public enum SuggestionStatus
    {
        [Description("Under review")]
        UnderReview = 1,

        [Description("Pending")]
        Pending = 2,

        [Description("Accepted")]
        Accepted = 3,

        [Description("Rejected")]
        Rejected = 4
    }
}
