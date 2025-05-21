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
        public int CustomerId { get; set; }

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
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Message { get; set; }
    }

    // Basic DTO for chat session list view

    public class ChatSessionDto
    {
        public int ChatSessionId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public bool IsActive { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // Detailed DTO for chat session with messages
    public class ChatSessionDetailDto : ChatSessionDto
    {
        public List<ChatMessageDto> Messages { get; set; } = new List<ChatMessageDto>();
    }

    // DTO for chat messages
    public class ChatMessageDto
    {
        public int ChatMessageId { get; set; }
        public int SenderUserId { get; set; }
        public string SenderName { get; set; }
        public int ReceiverUserId { get; set; }
        public string ReceiverName { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
