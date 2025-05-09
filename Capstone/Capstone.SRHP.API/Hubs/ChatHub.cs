//using Capstone.HPTY.ServiceLayer.DTOs.Chat;
//using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
//using Microsoft.AspNetCore.SignalR;
//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using static Capstone.HPTY.RepositoryLayer.Utils.AuthenTools;

//namespace Capstone.HPTY.API.Hubs
//{
//    public class ChatHub : Hub
//    {
//        private readonly IChatService _chatService;
//        private readonly ILogger<ChatHub> _logger;
//        private static ConcurrentDictionary<int, string> _userConnections = new ConcurrentDictionary<int, string>();

//        public ChatHub(IChatService chatService, ILogger<ChatHub> logger)
//        {
//            _chatService = chatService;
//            _logger = logger;
//        }

//        public override async Task OnConnectedAsync()
//        {
//            Console.WriteLine($"Client connected: {Context.ConnectionId}");
//            // You can also log additional information like headers
//            Console.WriteLine($"User Agent: {Context.GetHttpContext()?.Request.Headers["User-Agent"]}");
//            // Base implementation
//            await base.OnConnectedAsync();
//        }

//        public override async Task OnDisconnectedAsync(Exception exception)
//        {
//            _logger.LogInformation($"Client disconnected: {Context.ConnectionId}");
//            if (exception != null)
//            {
//                _logger.LogError(exception, "Disconnection error");
//            }

//            // Find and remove the disconnected user
//            var userToRemove = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId);
//            if (userToRemove.Key != 0)
//            {
//                // This is the correct way to remove from a ConcurrentDictionary
//                if (_userConnections.TryRemove(userToRemove.Key, out _))
//                {
//                    await Clients.All.SendAsync("UserDisconnected", userToRemove.Key);
//                    _logger.LogInformation("User {UserId} disconnected and removed from connection tracking", userToRemove.Key);
//                }
//            }

//            await base.OnDisconnectedAsync(exception);
//        }

//        public async Task RegisterUserConnection()
//        {
//            try
//            {
//                // Extract userId from JWT claims
//                var userIdClaim = Context.User.FindFirst("id");

//                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
//                {
//                    _logger.LogWarning("Failed connection attempt: User ID not found or invalid");
//                    await Clients.Caller.SendAsync("ChatError", "User ID not found or invalid");
//                    return;
//                }

//                // Store the connection ID with the user ID
//                _userConnections.AddOrUpdate(userId, Context.ConnectionId, (_, _) => Context.ConnectionId);

//                // Get the user's role through multiple fallback options
//                var roleClaim = Context.User.FindFirst("role")
//                    ?? Context.User.FindFirst(ClaimTypes.Role)
//                    ?? Context.User.Claims.FirstOrDefault(c => c.Type.Contains("role", StringComparison.OrdinalIgnoreCase));

//                var userRole = roleClaim?.Value ?? "Customer";

//                // Add to the appropriate group based on role
//                var normalizedRole = userRole.Trim().ToLowerInvariant();
//                if (normalizedRole == "manager" || normalizedRole == "admin")
//                {
//                    await Groups.AddToGroupAsync(Context.ConnectionId, "Managers");
//                    _logger.LogInformation("Manager/Admin {UserId} connected with connection {ConnectionId} and role {Role}",
//                        userId, Context.ConnectionId, userRole);
//                }
//                else
//                {
//                    await Groups.AddToGroupAsync(Context.ConnectionId, "Customers");
//                    _logger.LogInformation("Customer {UserId} connected with connection {ConnectionId} and role {Role}",
//                        userId, Context.ConnectionId, userRole);
//                }

//                await Clients.Caller.SendAsync("UserConnectionRegistered", userId);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error in RegisterConnection for connection {ConnectionId}", Context.ConnectionId);
//                await Clients.Caller.SendAsync("ChatError", $"Registration error: {ex.Message}");
//                throw;
//            }
//        }

//        public async Task SendMessage(SendMessageRequest request)
//        {
//            try
//            {
//                // Save the message to the database
//                var chatMessage = await _chatService.SaveMessageAsync(
//                    request.SenderId,
//                    request.ReceiverId,
//                    request.Message);

//                // Send the message to the receiver if they are connected
//                if (_userConnections.TryGetValue(request.ReceiverId, out string connectionId))
//                {
//                    await Clients.Client(connectionId).SendAsync("ReceiveMessage",
//                        chatMessage.ChatMessageId,
//                        chatMessage.SenderUserId,
//                        chatMessage.SenderName,
//                        chatMessage.ReceiverUserId,
//                        chatMessage.Message,
//                        chatMessage.CreatedAt);
//                }

//                // Also send back to the sender for confirmation
//                await Clients.Caller.SendAsync("MessageSent", chatMessage.ChatMessageId);
//            }
//            catch (Exception ex)
//            {
//                await Clients.Caller.SendAsync("ChatError", $"Error sending message: {ex.Message}");
//                throw;
//            }
//        }

//        public async Task InitiateChat(CreateChatSessionRequest request)
//        {
//            try
//            {
//                // Create a new chat session
//                var session = await _chatService.CreateChatSessionAsync(request.CustomerId, request.Topic);

//                // Notify all managers about the new chat request
//                await Clients.Group("Managers").SendAsync("NewChatRequest",
//                    session.ChatSessionId,
//                    session.CustomerId,
//                    session.CustomerName ?? "Customer",
//                    session.Topic,
//                    session.CreatedAt);

//                // Notify the customer that their request is being processed
//                if (_userConnections.TryGetValue(request.CustomerId, out string connectionId))
//                {
//                    await Clients.Client(connectionId).SendAsync("ChatInitiated",
//                        session.ChatSessionId,
//                        session.Topic);
//                }
//            }
//            catch (Exception ex)
//            {
//                // Notify the customer about the error
//                if (_userConnections.TryGetValue(request.CustomerId, out string connectionId))
//                {
//                    await Clients.Client(connectionId).SendAsync("ChatError",
//                        $"Unable to initiate chat: {ex.Message}");
//                }

//                throw;
//            }
//        }

//        public async Task AcceptChat(AssignManagerRequest request, int sessionId)
//        {
//            try
//            {
//                // Assign the manager to the chat session
//                var session = await _chatService.AssignManagerToChatSessionAsync(sessionId, request.ManagerId);

//                // Notify the customer that a manager has accepted their chat
//                if (_userConnections.TryGetValue(session.CustomerId, out string customerConnectionId))
//                {
//                    await Clients.Client(customerConnectionId).SendAsync("ChatAccepted",
//                        session.ChatSessionId,
//                        request.ManagerId,
//                        session.ManagerName ?? "Manager");
//                }

//                // Notify other managers that this chat has been taken
//                await Clients.GroupExcept("Managers", Context.ConnectionId).SendAsync("ChatTaken",
//                    sessionId,
//                    request.ManagerId);
//            }
//            catch (Exception ex)
//            {
//                // Notify the manager about the error
//                await Clients.Caller.SendAsync("ChatError",
//                    $"Unable to accept chat: {ex.Message}");

//                throw;
//            }
//        }

//        public async Task EndChat(int sessionId, int userId)
//        {
//            try
//            {
//                // End the chat session
//                var session = await _chatService.EndChatSessionAsync(sessionId);

//                // Notify both parties that the chat has ended
//                if (_userConnections.TryGetValue(session.CustomerId, out string customerConnectionId))
//                {
//                    await Clients.Client(customerConnectionId).SendAsync("ChatEnded", sessionId);
//                }

//                if (session.ManagerId.HasValue &&
//                    _userConnections.TryGetValue(session.ManagerId.Value, out string managerConnectionId))
//                {
//                    await Clients.Client(managerConnectionId).SendAsync("ChatEnded", sessionId);
//                }
//            }
//            catch (Exception ex)
//            {
//                await Clients.Caller.SendAsync("ChatError", $"Error ending chat: {ex.Message}");
//                throw;
//            }
//        }

//        public async Task MarkAsRead(int messageId, int userId)
//        {
//            try
//            {
//                var result = await _chatService.MarkMessageAsReadAsync(messageId);
//                if (!result)
//                {
//                    await Clients.Caller.SendAsync("ChatError", $"Message with ID {messageId} not found");
//                    return;
//                }

//                // Notify the sender that their message has been read
//                var message = await _chatService.GetMessageByIdAsync(messageId);
//                if (message != null && _userConnections.TryGetValue(message.SenderUserId, out string senderConnectionId))
//                {
//                    await Clients.Client(senderConnectionId).SendAsync("MessageRead", messageId);
//                }
//            }
//            catch (Exception ex)
//            {
//                await Clients.Caller.SendAsync("ChatError", $"Error marking message as read: {ex.Message}");
//                throw;
//            }
//        }

//        public async Task GetChatSession(int sessionId)
//        {
//            try
//            {
//                var session = await _chatService.GetChatSessionAsync(sessionId);
//                if (session == null)
//                {
//                    await Clients.Caller.SendAsync("ChatError", $"Chat session with ID {sessionId} not found");
//                    return;
//                }

//                await Clients.Caller.SendAsync("ReceiveChatSession", session);
//            }
//            catch (Exception ex)
//            {
//                await Clients.Caller.SendAsync("ChatError", $"Error retrieving chat session: {ex.Message}");
//                throw;
//            }
//        }

//        public async Task GetSessionMessages(int sessionId, int pageNumber = 1, int pageSize = 20)
//        {
//            try
//            {
//                var messages = await _chatService.GetSessionMessagesAsync(sessionId, pageNumber, pageSize);
//                await Clients.Caller.SendAsync("ReceiveSessionMessages", messages);
//            }
//            catch (Exception ex)
//            {
//                await Clients.Caller.SendAsync("ChatError", $"Error retrieving session messages: {ex.Message}");
//                throw;
//            }
//        }

//        public async Task GetUnreadMessages(int userId)
//        {
//            try
//            {
//                var messages = await _chatService.GetUnreadMessagesAsync(userId);
//                await Clients.Caller.SendAsync("ReceiveUnreadMessages", messages);
//            }
//            catch (Exception ex)
//            {
//                await Clients.Caller.SendAsync("ChatError", $"Error retrieving unread messages: {ex.Message}");
//                throw;
//            }
//        }

//        public async Task GetUnreadMessageCount(int userId)
//        {
//            try
//            {
//                var count = await _chatService.GetUnreadMessageCountAsync(userId);
//                await Clients.Caller.SendAsync("ReceiveUnreadMessageCount", count);
//            }
//            catch (Exception ex)
//            {
//                await Clients.Caller.SendAsync("ChatError", $"Error retrieving unread message count: {ex.Message}");
//                throw;
//            }
//        }
//    }
//}

using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

public class ChatHub : Hub
{
    private readonly ILogger<ChatHub> _logger;

    public ChatHub(ILogger<ChatHub> logger)
    {
        _logger = logger;
    }

    public override async Task OnConnectedAsync()
    {
        _logger.LogInformation("Client connected: {ConnectionId}", Context.ConnectionId);
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        _logger.LogInformation("Client disconnected: {ConnectionId}", Context.ConnectionId);
        if (exception != null)
        {
            _logger.LogError(exception, "Client disconnected with error");
        }
        await base.OnDisconnectedAsync(exception);
    }

    // Add a method to notify others when a user joins a chat session
    public async Task NotifyUserJoinedSession(string sessionId, string userName, string userRole)
    {
        await Clients.OthersInGroup($"session_{sessionId}")
            .SendAsync("UserJoinedSession", sessionId, userName, userRole);
        _logger.LogInformation("User {UserName} ({UserRole}) joined session {SessionId}", userName, userRole, sessionId);
    }

    // Add typing indicator functionality
    public async Task SendTypingIndicator(string sessionId, int userId, string userName)
    {
        await Clients.OthersInGroup($"session_{sessionId}")
            .SendAsync("UserTyping", sessionId, userId, userName);
    }

    // Enhanced version of JoinChatSessionGroup with notification
    public async Task JoinChatSessionGroup(string sessionId, string userName, string userRole)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, $"session_{sessionId}");
        _logger.LogInformation("User {UserName} added to session_{SessionId} group", userName, sessionId);

        // Notify others in the group
        await NotifyUserJoinedSession(sessionId, userName, userRole);
    }
}