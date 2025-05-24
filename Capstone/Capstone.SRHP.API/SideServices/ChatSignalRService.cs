using System;
using System.Threading.Tasks;
using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ServiceLayer.DTOs.Chat;
using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Services
{
    public class ChatSignalRService : IChatSignalRService
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly ILogger<ChatSignalRService> _logger;

        public ChatSignalRService(
            IHubContext<ChatHub> hubContext,
            ILogger<ChatSignalRService> logger)
        {
            _hubContext = hubContext;
            _logger = logger;
        }

        public async Task NotifyNewChat(ChatSessionDto session)
        {
            try
            {
                // Notify all managers about new chat session
                await _hubContext.Clients.Group("Manager").SendAsync("newChatSession", session);
                _logger.LogInformation($"Notified managers about new chat session {session.ChatSessionId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error notifying about new chat session {session.ChatSessionId}");
            }
        }

        public async Task NotifyChatAccepted(ChatSessionDto session)
        {
            try
            {
                // Notify customer that their chat was accepted
                await _hubContext.Clients.Group($"User_{session.CustomerId}").SendAsync("chatAccepted", session);
                _logger.LogInformation($"Notified customer {session.CustomerId} that chat {session.ChatSessionId} was accepted");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error notifying about chat acceptance {session.ChatSessionId}");
            }
        }

        public async Task NotifyNewMessage(ChatMessageDto message, int sessionId)
        {
            try
            {
                var messageData = new
                {
                    messageId = message.ChatMessageId,
                    sessionId = sessionId,
                    senderId = message.SenderUserId,
                    receiverId = message.ReceiverUserId,
                    content = message.Message,
                    timestamp = message.CreatedAt,
                    isBroadcast = message.IsBroadcast,
                    senderName = message.SenderName
                };

                // Send to everyone in the chat session
                await _hubContext.Clients.Group($"ChatSession_{sessionId}").SendAsync("newMessage", messageData);

                // If this is a broadcast message, also notify all managers
                if (message.IsBroadcast)
                {
                    await _hubContext.Clients.Group("Manager").SendAsync("newBroadcastMessage", new
                    {
                        messageId = message.ChatMessageId,
                        sessionId = sessionId,
                        senderId = message.SenderUserId,
                        content = message.Message,
                        timestamp = message.CreatedAt,
                        senderName = message.SenderName,
                        customerName = message.SenderName
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error sending message notification for message {message.ChatMessageId}");
            }
        }

        public async Task NotifyChatEnded(ChatSessionDto session)
        {
            try
            {
                var chatEndedData = new
                {
                    sessionId = session.ChatSessionId,
                    customerId = session.CustomerId,
                    managerId = session.ManagerId
                };

                // Notify everyone in the chat session that it has ended
                await _hubContext.Clients.Group($"ChatSession_{session.ChatSessionId}").SendAsync("chatEnded", chatEndedData);
                _logger.LogInformation($"Notified participants that chat session {session.ChatSessionId} has ended");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error notifying chat ended for session {session.ChatSessionId}");
            }
        }
    }
}