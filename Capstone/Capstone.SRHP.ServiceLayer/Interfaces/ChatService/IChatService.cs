using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;

namespace Capstone.HPTY.ServiceLayer.Interfaces.ChatService
{
    public interface IChatService
    {
        Task<ChatMessage> SaveMessageAsync(int senderId, int receiverId, string message);
        Task<ChatMessage> GetMessageByIdAsync(int messageId);
        Task<ChatSession> CreateChatSessionAsync(int customerId, string topic);
        Task<ChatSession> AssignManagerToChatSessionAsync(int sessionId, int managerId);
        Task<ChatSession> EndChatSessionAsync(int sessionId);
        Task<IEnumerable<ChatSession>> GetActiveChatSessionsAsync();
        Task<IEnumerable<ChatSession>> GetManagerChatHistoryAsync(int managerId);
        Task<int> GetUnreadMessageCountAsync(int userId);
        Task<IEnumerable<ChatMessage>> GetUnreadMessagesAsync(int userId);
        Task<ChatSession> GetChatSessionAsync(int sessionId);
        Task<IEnumerable<ChatMessage>> GetSessionMessagesAsync(int sessionId, int pageNumber = 1, int pageSize = 20);
        Task<bool> MarkMessageAsReadAsync(int messageId);
        Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(int userId1, int userId2, int pageNumber = 1, int pageSize = 20);
        Task<ChatSession> UpdateChatSessionAsync(int sessionId, ChatSession sessionUpdate);
        Task<IEnumerable<ChatSession>> GetCustomerChatHistoryAsync(int customerId);
    }
}
