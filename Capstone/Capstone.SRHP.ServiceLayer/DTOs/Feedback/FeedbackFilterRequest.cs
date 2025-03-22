using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Feedback
{
    public class FeedbackFilterRequest
    {
        // Pagination (non-nullable with defaults)
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        // Filtering (all nullable)
        public FeedbackApprovalStatus? ApprovalStatus { get; set; }
        public int? UserId { get; set; }
        public int? OrderId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? HasResponse { get; set; }

        // Sorting (non-nullable with defaults)
        public string SortBy { get; set; } = "CreatedAt";
        public bool Ascending { get; set; } = false;  // Default descending (newest first)

        // Searching (nullable)
        public string? SearchTerm { get; set; }
    }
}
