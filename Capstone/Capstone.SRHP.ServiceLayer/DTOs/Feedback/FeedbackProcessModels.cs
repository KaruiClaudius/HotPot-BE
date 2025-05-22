using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Feedback
{
    public class ApproveFeedbackRequest
    {
        [Required]
        public int AdminUserId { get; set; }
    }

    public class RejectFeedbackRequest
    {
        [Required]
        public int AdminUserId { get; set; }

        [Required]
        [StringLength(500)]
        public string RejectionReason { get; set; }
    }

    public class FeedbackStats
    {
        public int TotalFeedbackCount { get; set; }

    }

}
