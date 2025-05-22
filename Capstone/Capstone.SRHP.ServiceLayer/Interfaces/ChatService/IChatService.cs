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
        Task<ChatSessionDto> CreateChatSessionAsync(int customerId, string topic);
        Task<ChatSessionDto> JoinChatSessionAsync(int sessionId, int managerId);
        Task<ChatMessageDto> SaveMessageAsync(int senderId, int chatSessionId, string message);
        Task<ChatSessionDto> EndChatSessionAsync(int sessionId);
        Task<List<ChatMessageDto>> GetSessionMessagesAsync(int sessionId, int pageNumber = 1, int pageSize = 20);
        Task<ChatSessionDetailDto> GetChatSessionAsync(int sessionId);
        Task<List<ChatSessionDto>> GetUserChatSessionsAsync(int userId, bool activeOnly = false);
        Task<List<ChatSessionDto>> GetUnassignedChatSessionsAsync();
    }
}
