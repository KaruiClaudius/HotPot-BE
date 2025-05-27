using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Enum;

namespace Capstone.HPTY.ServiceLayer.DTOs.Feedback
{
    public class FeedbackListDto
    {
        public int FeedbackId { get; set; }
        public string UserName { get; set; }
        public int OrderId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Comment { get; set; }
    }
    public class FeedbackDetailDto : FeedbackListDto
    {
        public string Comment { get; set; }
        public string[] ImageURLs { get; set; }
        public string Response { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public int UserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
