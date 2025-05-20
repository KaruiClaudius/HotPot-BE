using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Chat;
using Capstone.HPTY.ServiceLayer.Extensions;
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

        public async Task<ChatMessageDto> SaveMessageAsync(int senderId, int receiverId, string message)
        {
            var chatMessage = new ChatMessage
            {
                SenderUserId = senderId,
                ReceiverUserId = receiverId,
                Message = message,
                IsRead = false,
                CreatedAt = DateTime.UtcNow.AddHours(7)
            };

            _unitOfWork.Repository<ChatMessage>().Insert(chatMessage);
            await _unitOfWork.CommitAsync();

            // Load sender and receiver details for the DTO
            chatMessage.SenderUser = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == senderId);
            chatMessage.ReceiverUser = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == receiverId);

            return chatMessage.ToDto();
        }

        public async Task<ChatMessageDto> GetMessageByIdAsync(int messageId)
        {
            var message = await _unitOfWork.Repository<ChatMessage>()
                .AsQueryable()
                .Where(m => m.ChatMessageId == messageId)
                .Include(m => m.SenderUser)
                .Include(m => m.ReceiverUser)
                .FirstOrDefaultAsync();

            return message?.ToDto();
        }

        public async Task<ChatSessionDto> CreateChatSessionAsync(int customerId, string topic)
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
                CreatedAt = DateTime.UtcNow.AddHours(7)
            };

            _unitOfWork.Repository<ChatSession>().Insert(chatSession);
            await _unitOfWork.CommitAsync();

            // Load the customer details for the response
            chatSession.Customer = customer;

            return chatSession.ToDto();
        }

        public async Task<ChatSessionDto> AssignManagerToChatSessionAsync(int sessionId, int managerId)
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
            chatSession.Customer = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == chatSession.CustomerId);

            return chatSession.ToDto();
        }

        public async Task<ChatSessionDto> EndChatSessionAsync(int sessionId)
        {
            var chatSession = await _unitOfWork.Repository<ChatSession>()
                .AsQueryable()
                .Where(s => s.ChatSessionId == sessionId)
                .Include(s => s.Customer)
                .Include(s => s.Manager)
                .FirstOrDefaultAsync();

            if (chatSession == null)
                throw new NotFoundException($"Chat session with ID {sessionId} not found");

            chatSession.IsActive = false;
            chatSession.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            return chatSession.ToDto();
        }

        public async Task<List<ChatSessionDto>> GetActiveChatSessionsAsync()
        {
            var sessions = await _unitOfWork.Repository<ChatSession>()
                .GetAll(s => s.IsActive)
                .Include(s => s.Customer)
                .Include(s => s.Manager)
                .ToListAsync();

            return sessions.ToDtoList();
        }

        public async Task<List<ChatSessionDto>> GetManagerChatHistoryAsync(int managerId)
        {
            // Verify manager exists (user with manager role)
            var manager = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == managerId && u.RoleId == MANAGER_ROLE_ID && !u.IsDelete);

            if (manager == null)
                throw new NotFoundException($"Manager with ID {managerId} not found");

            var sessions = await _unitOfWork.Repository<ChatSession>()
                .GetAll(s => s.ManagerId == managerId)
                .Include(s => s.Customer)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            return sessions.ToDtoList();
        }

        public async Task<int> GetUnreadMessageCountAsync(int userId)
        {
            return await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => m.ReceiverUserId == userId && !m.IsRead)
                .CountAsync();
        }

        public async Task<List<ChatMessageDto>> GetUnreadMessagesAsync(int userId)
        {
            var messages = await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => m.ReceiverUserId == userId && !m.IsRead)
                .Include(m => m.SenderUser)
                .Include(m => m.ReceiverUser)
                .OrderBy(m => m.CreatedAt)
                .ToListAsync();

            return messages.ToDtoList();
        }

        public async Task<ChatSessionDetailDto> GetChatSessionAsync(int sessionId)
        {
            var session = await _unitOfWork.Repository<ChatSession>()
                .AsQueryable()
                .Where(s => s.ChatSessionId == sessionId)
                .Include(s => s.Customer)
                .Include(s => s.Manager)
                .Include(s => s.Messages.OrderBy(m => m.CreatedAt))
                .ThenInclude(m => m.SenderUser)
                .Include(s => s.Messages)
                .ThenInclude(m => m.ReceiverUser)
                .FirstOrDefaultAsync();

            return session?.ToDetailDto();
        }

        public async Task<List<ChatMessageDto>> GetSessionMessagesAsync(int sessionId, int pageNumber = 1, int pageSize = 20)
        {
            var session = await _unitOfWork.Repository<ChatSession>()
                .FindAsync(s => s.ChatSessionId == sessionId);

            if (session == null)
                throw new NotFoundException($"Chat session with ID {sessionId} not found");

            var messages = await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => (m.SenderUserId == session.CustomerId && m.ReceiverUserId == session.ManagerId) ||
                             (m.SenderUserId == session.ManagerId && m.ReceiverUserId == session.CustomerId))
                .Include(m => m.SenderUser)
                .Include(m => m.ReceiverUser)
                .OrderByDescending(m => m.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return messages.ToDtoList();
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
        public async Task<List<ChatMessageDto>> GetChatHistoryAsync(int userId1, int userId2, int pageNumber = 1, int pageSize = 20)
        {
            var messages = await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => (m.SenderUserId == userId1 && m.ReceiverUserId == userId2) ||
                             (m.SenderUserId == userId2 && m.ReceiverUserId == userId1))
                .Include(m => m.SenderUser)
                .Include(m => m.ReceiverUser)
                .OrderByDescending(m => m.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Return in chronological order
            return messages.OrderBy(m => m.CreatedAt).ToDtoList();
        }

        // New method to efficiently update chat session properties
        public async Task<ChatSessionDto> UpdateChatSessionAsync(int sessionId, ChatSession sessionUpdate)
        {
            var session = await _unitOfWork.Repository<ChatSession>()
                .FindAsync(s => s.ChatSessionId == sessionId);

            if (session == null)
                throw new NotFoundException($"Chat session with ID {sessionId} not found");

            // Update entity properties
            _unitOfWork.Context.Entry(session).CurrentValues.SetValues(sessionUpdate);

            // Mark the entity as updated
            session.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            // Load related entities for the DTO
            session.Customer = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == session.CustomerId);
            if (session.ManagerId.HasValue)
            {
                session.Manager = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == session.ManagerId.Value);
            }

            return session.ToDto();
        }

        // New method to get all chat sessions for a customer
        public async Task<List<ChatSessionDto>> GetCustomerChatHistoryAsync(int customerId)
        {
            // Verify customer exists (user with customer role)
            var customer = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == customerId && u.RoleId == CUSTOMER_ROLE_ID && !u.IsDelete);

            if (customer == null)
                throw new NotFoundException($"Customer with ID {customerId} not found");

            var sessions = await _unitOfWork.Repository<ChatSession>()
                .GetAll(s => s.CustomerId == customerId)
                .Include(s => s.Manager)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            return sessions.ToDtoList();
        }

        public async Task<ChatSessionDto> GetChatSessionForUsersAsync(int userId1, int userId2)
        {
            // Find a session where one user is the customer and the other is the manager
            var session = await _unitOfWork.Repository<ChatSession>()
                .AsQueryable()
                .Where(s => s.IsActive &&
                           ((s.CustomerId == userId1 && s.ManagerId == userId2) ||
                            (s.CustomerId == userId2 && s.ManagerId == userId1)))
                .Include(s => s.Customer)
                .Include(s => s.Manager)
                .OrderByDescending(s => s.CreatedAt)
                .FirstOrDefaultAsync();

            return session?.ToDto();
        }
    }
}