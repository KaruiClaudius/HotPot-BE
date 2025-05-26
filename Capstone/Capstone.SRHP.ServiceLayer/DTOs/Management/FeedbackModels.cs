using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Management
{
    public class RespondToFeedbackRequest
    {
        [Required]
        public int ManagerId { get; set; }

        [Required]
        [StringLength(2000)]
        public string Response { get; set; }
    }

    public class CreateFeedbackRequest
    {

        [Required]
        [StringLength(2000)]
        public string Comment { get; set; }

        public string[]? ImageURLs { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }
    }



    public class ManagerFeedbackStats
    {
        public int TotalFeedbackCount { get; set; }

    }

    public class ManagerFeedbackListDto
    {
        public int FeedbackId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public FeedbackApprovalStatus ApprovalStatus { get; set; }
        public bool HasResponse { get; set; }
        public DateTime? ResponseDate { get; set; }

        // User info
        public UserInfoDto User { get; set; }

        // Order info
        public OrderInfoDto Order { get; set; }
    }

    // Detailed DTO for single feedback view
    public class ManagerFeedbackDetailDto
    {
        public int FeedbackId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string[] ImageURLs { get; set; }
        public DateTime CreatedAt { get; set; }
        public FeedbackApprovalStatus ApprovalStatus { get; set; }
        public string Response { get; set; }
        public DateTime? ResponseDate { get; set; }

        // User info
        public UserInfoDto User { get; set; }

        // Manager info
        public UserInfoDto Manager { get; set; }

        // Order info
        public OrderInfoDto Order { get; set; }
    }

    // Basic user info needed for feedback
    public class UserInfoDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    // Basic order info needed for feedback
    public class OrderInfoDto
    {
        public int OrderId { get; set; }
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
