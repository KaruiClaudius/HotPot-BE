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
        public int PendingFeedbackCount { get; set; }
        public int ApprovedFeedbackCount { get; set; }
        public int RejectedFeedbackCount { get; set; }
        public int UnrespondedFeedbackCount { get; set; }
        public int RespondedFeedbackCount { get; set; }
        public double ResponseRate { get; set; }
    }
    public class FeedbackStatusSummary
    {
        public int TotalFeedback { get; set; }
        public int PendingApproval { get; set; }
        public int Approved { get; set; }
        public int Rejected { get; set; }
        public int Responded { get; set; }
    }
}
