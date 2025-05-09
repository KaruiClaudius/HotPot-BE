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
        Task<ChatMessageDto> SaveMessageAsync(int senderId, int receiverId, string message);
        Task<ChatMessageDto> GetMessageByIdAsync(int messageId);
        Task<ChatSessionDto> CreateChatSessionAsync(int customerId, string topic);
        Task<ChatSessionDto> AssignManagerToChatSessionAsync(int sessionId, int managerId);
        Task<ChatSessionDto> EndChatSessionAsync(int sessionId);
        Task<List<ChatSessionDto>> GetActiveChatSessionsAsync();
        Task<List<ChatSessionDto>> GetManagerChatHistoryAsync(int managerId);
        Task<int> GetUnreadMessageCountAsync(int userId);
        Task<List<ChatMessageDto>> GetUnreadMessagesAsync(int userId);
        Task<ChatSessionDetailDto> GetChatSessionAsync(int sessionId);
        Task<List<ChatMessageDto>> GetSessionMessagesAsync(int sessionId, int pageNumber = 1, int pageSize = 20);
        Task<bool> MarkMessageAsReadAsync(int messageId);
        Task<List<ChatMessageDto>> GetChatHistoryAsync(int userId1, int userId2, int pageNumber = 1, int pageSize = 20);
        Task<ChatSessionDto> UpdateChatSessionAsync(int sessionId, ChatSession sessionUpdate);
        Task<List<ChatSessionDto>> GetCustomerChatHistoryAsync(int customerId);
        Task<ChatSessionDto> GetChatSessionForUsersAsync(int userId1, int userId2);
    }
}
