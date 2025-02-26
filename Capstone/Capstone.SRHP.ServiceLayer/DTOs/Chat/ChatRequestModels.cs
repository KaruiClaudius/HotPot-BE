using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.DTOs.Chat
{
    public class CreateChatSessionRequest
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(500)]
        public string Topic { get; set; }
    }

    public class AssignManagerRequest
    {
        [Required]
        public int ManagerId { get; set; }
    }
    public class SendMessageRequest
    {
        [Required]
        public int SenderId { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [Required]
        [StringLength(2000)]
        public string Message { get; set; }
    }

    public class MarkAsReadRequest
    {
        [Required]
        public int UserId { get; set; }
    }
}
