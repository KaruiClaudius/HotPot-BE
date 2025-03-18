using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ChatService
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private const int CUSTOMER_ROLE_ID = 4; // Customer role ID
        private const int MANAGER_ROLE_ID = 2;  // Manager role ID

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

        public async Task<ChatSession> CreateChatSessionAsync(int customerId, string topic)
        {
            // Verify customer exists (user with customer role)
            var customer = await _unitOfWork.Repository<User>()
                .AsQueryable()
                .Where(u => u.UserId == customerId && u.RoleId == CUSTOMER_ROLE_ID && !u.IsDelete)
                .FirstOrDefaultAsync();

            if (customer == null)
                throw new NotFoundException($"Customer with ID {customerId} not found");

            var chatSession = new ChatSession
            {
                CustomerId = customerId,
                Topic = topic,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Repository<ChatSession>().Insert(chatSession);
            await _unitOfWork.CommitAsync();

            // Load the customer details for the response
            chatSession.Customer = customer;

            return chatSession;
        }

        public async Task<ChatSession> AssignManagerToChatSessionAsync(int sessionId, int managerId)
        {
            // Verify manager exists (user with manager role)
            var manager = await _unitOfWork.Repository<User>()
                .AsQueryable()
                .Where(u => u.UserId == managerId && u.RoleId == MANAGER_ROLE_ID && !u.IsDelete)
                .FirstOrDefaultAsync();

            if (manager == null)
                throw new NotFoundException($"Manager with ID {managerId} not found");

            var chatSession = await _unitOfWork.Repository<ChatSession>()
                .FindAsync(s => s.ChatSessionId == sessionId);

            if (chatSession == null)
                throw new NotFoundException($"Chat session with ID {sessionId} not found");

            chatSession.ManagerId = managerId;
            chatSession.SetUpdateDate();

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
                throw new NotFoundException($"Chat session with ID {sessionId} not found");

            chatSession.IsActive = false;
            chatSession.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            return chatSession;
        }

        public async Task<IEnumerable<ChatSession>> GetActiveChatSessionsAsync()
        {
            return await _unitOfWork.Repository<ChatSession>()
                .GetAll(s => s.IsActive)
                .Include(s => s.Customer)
                .Include(s => s.Manager)
                .ToListAsync();
        }

        public async Task<IEnumerable<ChatSession>> GetManagerChatHistoryAsync(int managerId)
        {
            // Verify manager exists (user with manager role)
            var manager = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == managerId && u.RoleId == MANAGER_ROLE_ID && !u.IsDelete);

            if (manager == null)
                throw new NotFoundException($"Manager with ID {managerId} not found");

            return await _unitOfWork.Repository<ChatSession>()
                .GetAll(s => s.ManagerId == managerId)
                .Include(s => s.Customer)
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
                .AsQueryable()
                .Where(s => s.ChatSessionId == sessionId)
                .Include(s => s.Customer)
                .Include(s => s.Manager)
                .Include(s => s.Messages.OrderBy(m => m.CreatedAt))
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ChatMessage>> GetSessionMessagesAsync(int sessionId, int pageNumber = 1, int pageSize = 20)
        {
            var session = await _unitOfWork.Repository<ChatSession>()
                .FindAsync(s => s.ChatSessionId == sessionId);

            if (session == null)
                throw new NotFoundException($"Chat session with ID {sessionId} not found");

            return await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => (m.SenderUserId == session.CustomerId && m.ReceiverUserId == session.ManagerId) ||
                             (m.SenderUserId == session.ManagerId && m.ReceiverUserId == session.CustomerId))
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
            message.SetUpdateDate();

            await _unitOfWork.CommitAsync();
            return true;
        }

        // New method to get chat history between two users
        public async Task<IEnumerable<ChatMessage>> GetChatHistoryAsync(int userId1, int userId2, int pageNumber = 1, int pageSize = 20)
        {
            var messages = await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => (m.SenderUserId == userId1 && m.ReceiverUserId == userId2) ||
                             (m.SenderUserId == userId2 && m.ReceiverUserId == userId1))
                .OrderByDescending(m => m.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return in chronological order
            return messages.OrderBy(m => m.CreatedAt);
        }

        // New method to efficiently update chat session properties
        public async Task<ChatSession> UpdateChatSessionAsync(int sessionId, ChatSession sessionUpdate)
        {
            var session = await _unitOfWork.Repository<ChatSession>()
                .FindAsync(s => s.ChatSessionId == sessionId);

            if (session == null)
                throw new NotFoundException($"Chat session with ID {sessionId} not found");

            // Using the approach from source [0] to update entity properties
            // This is a cleaner way to update multiple properties
            _unitOfWork.Context.Entry(session).CurrentValues.SetValues(sessionUpdate);

            // Mark the entity as updated
            session.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            return await GetChatSessionAsync(sessionId);
        }

        // New method to get all chat sessions for a customer
        public async Task<IEnumerable<ChatSession>> GetCustomerChatHistoryAsync(int customerId)
        {
            // Verify customer exists (user with customer role)
            var customer = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == customerId && u.RoleId == CUSTOMER_ROLE_ID && !u.IsDelete);

            if (customer == null)
                throw new NotFoundException($"Customer with ID {customerId} not found");

            return await _unitOfWork.Repository<ChatSession>()
                .GetAll(s => s.CustomerId == customerId)
                .Include(s => s.Manager)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();
        }
    }
}