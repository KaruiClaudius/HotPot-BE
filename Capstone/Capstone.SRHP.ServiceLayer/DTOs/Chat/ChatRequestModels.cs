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
        public DateTime? UpdatedAt { get; set; }
    }

    // Detailed DTO for chat session with messages
    public class ChatSessionDetailDto
    {
        public int ChatSessionId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
        public bool IsActive { get; set; }
        public string Topic { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
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
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    // DTO for unread message count
    public class UnreadMessageCountDto
    {
        public int Count { get; set; }
    }
}
