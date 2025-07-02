using IdeaHub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.DTOs.Suggestion
{
    public class SuggestionViewDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SuggestionStatus Status { get; set; }
        public string SubmittedBy { get; set; }
        public string ProductName { get; set; }
        public DateTime SubmittedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
    }
}
