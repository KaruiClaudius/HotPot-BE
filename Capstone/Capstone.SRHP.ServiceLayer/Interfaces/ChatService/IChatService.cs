using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Chat;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ChatService
{
    public interface IChatService
    {
        // Session management
        Task<ChatSessionDto> CreateChatSessionAsync(int customerId, string topic);
        Task<ChatSessionDto> AssignManagerToChatSessionAsync(int sessionId, int managerId);
        Task<ChatSessionDto> EndChatSessionAsync(int sessionId);
        Task<ChatSessionDetailDto> GetChatSessionAsync(int sessionId);

        // Message handling
        Task<ChatMessageDto> SaveMessageAsync(int senderId, int receiverId, string message);
        Task<List<ChatMessageDto>> GetSessionMessagesAsync(int sessionId, int pageNumber = 1, int pageSize = 20);
        Task<ChatMessageDto> GetMessageByIdAsync(int messageId);

        // Session queries
        Task<List<ChatSessionDto>> GetActiveChatSessionsAsync();
        Task<List<ChatSessionDto>> GetManagerChatHistoryAsync(int managerId);
    }
}
