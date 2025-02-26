using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(2000)]
        public string Comment { get; set; }

        public string[]? ImageURLs { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; }
    }

   

    public class FeedbackStats
    {
        public int TotalFeedbackCount { get; set; }
        public int RespondedFeedbackCount { get; set; }
        public int UnrespondedFeedbackCount { get; set; }
        public double ResponseRate { get; set; }
    }
}
