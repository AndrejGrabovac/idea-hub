using IdeaHub.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Models
{
    public class Suggestion
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public SuggestionStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedDate { get; set; }

        public Suggestion()
        {   
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            Status = SuggestionStatus.UnderReview; // Default status is UnderReview
        }
    }
}
