using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ChatService
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChatService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ChatMessage> SaveMessageAsync(int senderId, int receiverId, string message)
        {
            var chatMessage = new ChatMessage
            {
                SenderUserId = senderId,
                ReceiverUserId = receiverId,
                Message = message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Repository<ChatMessage>().Insert(chatMessage);
            await _unitOfWork.CommitAsync();

            return chatMessage;
        }

        public async Task<ChatMessage> GetMessageByIdAsync(int messageId)
        {
            return await _unitOfWork.Repository<ChatMessage>()
                .FindAsync(m => m.ChatMessageId == messageId);
        }

        public async Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(int userId1, int userId2, int pageNumber = 1, int pageSize = 20)
        {
            var messages = await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => m.SenderUserId == userId1 && m.ReceiverUserId == userId2 ||
                             m.SenderUserId == userId2 && m.ReceiverUserId == userId1)
                .OrderByDescending(m => m.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return messages.OrderBy(m => m.CreatedAt);
        }

        public async Task<ChatSession> CreateChatSessionAsync(int customerId, string topic)
        {
            // Verify customer exists
            var customer = await _unitOfWork.Repository<Customer>()
                .AsQueryable(c => c.CustomerId == customerId)
                .Include(c => c.User)
                .FirstOrDefaultAsync();

            if (customer == null)
                throw new KeyNotFoundException($"Customer with ID {customerId} not found");

            var chatSession = new ChatSession
            {
                CustomerId = customerId,
                Topic = topic,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Repository<ChatSession>().Insert(chatSession);
            await _unitOfWork.CommitAsync();

            // Load the customer with user details for the response
            chatSession.Customer = customer;

            return chatSession;
        }

        public async Task<ChatSession> AssignManagerToChatSessionAsync(int sessionId, int managerId)
        {
            // Verify manager exists (manager is a User with appropriate role)
            var manager = await _unitOfWork.Repository<Manager>()
                .AsQueryable(manager => manager.ManagerId == managerId)
                .Include(manager => manager.User)
                .FirstOrDefaultAsync();

            if (manager == null)
                throw new KeyNotFoundException($"Manager with ID {managerId} not found");

            var chatSession = await _unitOfWork.Repository<ChatSession>()
                .FindAsync(s => s.ChatSessionId == sessionId);

            if (chatSession == null)
                throw new KeyNotFoundException($"Chat session with ID {sessionId} not found");

            chatSession.ManagerId = managerId;
            chatSession.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            // Load the manager details for the response
            chatSession.Manager = manager;

            return chatSession;
        }

        public async Task<ChatSession> EndChatSessionAsync(int sessionId)
        {
            var chatSession = await _unitOfWork.Repository<ChatSession>()
                .FindAsync(s => s.ChatSessionId == sessionId);

            if (chatSession == null)
                throw new KeyNotFoundException($"Chat session with ID {sessionId} not found");

            chatSession.IsActive = false;
            chatSession.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();

            return chatSession;
        }

        public async Task<IEnumerable<ChatSession>> GetActiveChatSessionsAsync()
        {
            return await _unitOfWork.Repository<ChatSession>()
                .GetAll(s => s.IsActive)
                .Include(s => s.Customer)
                    .ThenInclude(c => c.User)
                .Include(s => s.Manager)
                .ThenInclude(m => m.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<ChatSession>> GetCustomerChatHistoryAsync(int customerId)
        {
            return await _unitOfWork.Repository<ChatSession>()
                .GetAll(s => s.CustomerId == customerId)
                .Include(s => s.Manager)
                    .ThenInclude(m => m.User)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<ChatSession>> GetManagerChatHistoryAsync(int managerId)
        {
            return await _unitOfWork.Repository<ChatSession>()
                .GetAll(s => s.ManagerId == managerId)
                .Include(s => s.Customer)
                    .ThenInclude(c => c.User)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }

        public async Task<int> GetUnreadMessageCountAsync(int userId)
        {
            return await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => m.ReceiverUserId == userId && !m.IsRead)
                .CountAsync();
        }

        public async Task<IEnumerable<ChatMessage>> GetUnreadMessagesAsync(int userId)
        {
            return await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => m.ReceiverUserId == userId && !m.IsRead)
                .Include(m => m.SenderUser)
                .OrderBy(m => m.CreatedAt)
                .ToListAsync();
        }

        public async Task<ChatSession> GetChatSessionAsync(int sessionId)
        {
            return await _unitOfWork.Repository<ChatSession>()
                .AsQueryable(s => s.ChatSessionId == sessionId)
                .Include(s => s.Customer)
                    .ThenInclude(c => c.User)
                .Include(s => s.Manager)
                .Include(s => s.Messages.OrderBy(m => m.CreatedAt))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ChatMessage>> GetSessionMessagesAsync(int sessionId, int pageNumber = 1, int pageSize = 20)
        {
            var session = await _unitOfWork.Repository<ChatSession>()
                .FindAsync(s => s.ChatSessionId == sessionId);

            if (session == null)
                throw new KeyNotFoundException($"Chat session with ID {sessionId} not found");

            return await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => m.SenderUserId == session.CustomerId && m.ReceiverUserId == session.ManagerId ||
                             m.SenderUserId == session.ManagerId && m.ReceiverUserId == session.CustomerId)
                .OrderByDescending(m => m.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<bool> MarkMessageAsReadAsync(int messageId)
        {
            var message = await _unitOfWork.Repository<ChatMessage>()
                .FindAsync(m => m.ChatMessageId == messageId);

            if (message == null)
                return false;

            message.IsRead = true;
            message.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();
            return true;
        }

     }
}
