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
        private const int CUSTOMER_ROLE_ID = 4;
        private const int MANAGER_ROLE_ID = 2;

        public ChatService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ChatSessionDto> CreateChatSessionAsync(int customerId, string topic)
        {
            // Verify customer exists
            var customer = await _unitOfWork.Repository<User>()
                .AsQueryable()
                .Where(u => u.UserId == customerId && u.RoleId == CUSTOMER_ROLE_ID && !u.IsDelete)
                .FirstOrDefaultAsync();

            if (customer == null)
                throw new NotFoundException($"Customer not found");

            var chatSession = new ChatSession
            {
                CustomerId = customerId,
                Topic = topic,
                IsActive = true,
                CreatedAt = DateTime.UtcNow.AddHours(7)
            };

            _unitOfWork.Repository<ChatSession>().Insert(chatSession);
            await _unitOfWork.CommitAsync();

            chatSession.Customer = customer;

            return chatSession.ToDto();
        }

        public async Task<ChatSessionDto> JoinChatSessionAsync(int sessionId, int managerId)
        {
            // Verify manager exists
            var manager = await _unitOfWork.Repository<User>()
                .AsQueryable()
                .Where(u => u.UserId == managerId && u.RoleId == MANAGER_ROLE_ID && !u.IsDelete)
                .FirstOrDefaultAsync();

            if (manager == null)
                throw new NotFoundException($"Manager not found");

            var chatSession = await _unitOfWork.Repository<ChatSession>()
                .AsQueryable()
                .Where(s => s.ChatSessionId == sessionId && s.IsActive)
                .FirstOrDefaultAsync();

            if (chatSession == null)
                throw new NotFoundException($"Active chat session not found");

            if (chatSession.ManagerId.HasValue)
                throw new InvalidOperationException("This chat session already has a manager assigned");

            chatSession.ManagerId = managerId;
            chatSession.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            chatSession.Manager = manager;
            chatSession.Customer = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == chatSession.CustomerId);

            return chatSession.ToDto();
        }

        public async Task<ChatMessageDto> SaveMessageAsync(int senderId, int chatSessionId, string message)
        {
            var session = await _unitOfWork.Repository<ChatSession>()
                .AsQueryable()
                .Where(s => s.ChatSessionId == chatSessionId && s.IsActive)
                .Include(s => s.Customer)
                .Include(s => s.Manager)
                .FirstOrDefaultAsync();

            if (session == null)
                throw new NotFoundException("Active chat session not found");

            // Determine receiver based on sender
            int receiverId;
            bool hasSpecificReceiver = true;

            if (senderId == session.CustomerId)
            {
                // Customer is sending a message
                if (session.ManagerId.HasValue)
                {
                    // If a manager has joined, set them as the receiver
                    receiverId = session.ManagerId.Value;
                }
                else
                {
                    // If no manager has joined, set the receiver as the customer (self)
                    // This indicates a broadcast message waiting for a manager
                    receiverId = senderId;
                    hasSpecificReceiver = false;
                }
            }
            else if (senderId == session.ManagerId)
            {
                // Manager is sending a message, customer is always the receiver
                receiverId = session.CustomerId;
            }
            else
            {
                throw new InvalidOperationException("Sender is not part of this chat session");
            }

            var chatMessage = new ChatMessage
            {
                SenderUserId = senderId,
                ReceiverUserId = receiverId,
                ChatSessionId = chatSessionId,
                Message = message,
                CreatedAt = DateTime.UtcNow.AddHours(7),
                IsBroadcast = !hasSpecificReceiver
            };

            _unitOfWork.Repository<ChatMessage>().Insert(chatMessage);
            await _unitOfWork.CommitAsync();

            // Load sender details for the DTO
            chatMessage.SenderUser = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == senderId);

            // Load receiver details
            if (hasSpecificReceiver)
            {
                chatMessage.ReceiverUser = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == receiverId);
            }
            else
            {
                // For broadcast messages, we don't load a specific receiver
                // or we could set it to the sender for consistency
                chatMessage.ReceiverUser = chatMessage.SenderUser;
            }

            return chatMessage.ToDto();
        }

        public async Task<ChatSessionDto> EndChatSessionAsync(int sessionId)
        {
            var chatSession = await _unitOfWork.Repository<ChatSession>()
                .AsQueryable()
                .Where(s => s.ChatSessionId == sessionId && s.IsActive)
                .Include(s => s.Customer)
                .Include(s => s.Manager)
                .FirstOrDefaultAsync();

            if (chatSession == null)
                throw new NotFoundException($"Active chat session not found");

            chatSession.IsActive = false;
            chatSession.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            return chatSession.ToDto();
        }

        public async Task<List<ChatMessageDto>> GetSessionMessagesAsync(int sessionId, int pageNumber = 1, int pageSize = 20)
        {
            var session = await _unitOfWork.Repository<ChatSession>()
                .FindAsync(s => s.ChatSessionId == sessionId);

            if (session == null)
                throw new NotFoundException($"Chat session not found");

            var messages = await _unitOfWork.Repository<ChatMessage>()
                .GetAll(m => m.ChatSessionId == sessionId)
                .Include(m => m.SenderUser)
                .Include(m => m.ReceiverUser)
                .OrderBy(m => m.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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

        public async Task<List<ChatSessionDto>> GetUserChatSessionsAsync(int userId, bool activeOnly = false)
        {
            var sessions = await _unitOfWork.Repository<ChatSession>()
                .AsQueryable()
                .Where(s => (s.CustomerId == userId || s.ManagerId == userId) &&
                            (!activeOnly || s.IsActive))
                .Include(s => s.Customer)
                .Include(s => s.Manager)
                .OrderByDescending(s => s.CreatedAt)
                .ToListAsync();

            return sessions.ToDtoList();
        }

        public async Task<List<ChatSessionDto>> GetUnassignedChatSessionsAsync()
        {
            var sessions = await _unitOfWork.Repository<ChatSession>()
                .AsQueryable()
                .Where(s => s.IsActive && !s.ManagerId.HasValue)
                .Include(s => s.Customer)
                .OrderBy(s => s.CreatedAt)
                .ToListAsync();

            return sessions.ToDtoList();
        }
    }
}