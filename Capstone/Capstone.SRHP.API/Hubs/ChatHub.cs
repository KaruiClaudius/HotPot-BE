using Capstone.HPTY.ServiceLayer.DTOs.Chat;
using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.HPTY.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;
        private static Dictionary<int, string> _userConnections = new Dictionary<int, string>();

        public ChatHub(IChatService chatService)
        {
            _chatService = chatService;
        }

        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            // You can also log additional information like headers
            Console.WriteLine($"User Agent: {Context.GetHttpContext()?.Request.Headers["User-Agent"]}");
            // Base implementation
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
            if (exception != null)
            {
                Console.WriteLine($"Disconnection reason: {exception.Message}");
                Console.WriteLine(exception.StackTrace);
            }

            // Find and remove the disconnected user
            var userToRemove = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId);
            if (userToRemove.Key != 0)
            {
                _userConnections.Remove(userToRemove.Key);
                await Clients.All.SendAsync("UserDisconnected", userToRemove.Key);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task RegisterUserConnection()
        {
            try
            {
                // Extract userId from JWT claims
                var userIdClaim = Context.User.FindFirst("id");

                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                {
                    await Clients.Caller.SendAsync("ChatError", "User ID not found or invalid");
                    return;
                }

                // Store the connection ID with the user ID
                _userConnections[userId] = Context.ConnectionId;

                // Get the user's role from the Context
                var userRole = Context.User.FindFirst("role")?.Value ?? "Customer";

                // Add to the appropriate group based on role
                if (userRole.ToLower() == "manager" || userRole.ToLower() == "admin")
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "Managers");
                }
                else
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "Customers");
                }

                await Clients.Caller.SendAsync("UserConnectionRegistered", userId);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"Error in RegisterConnection: {ex.Message}");
                Console.Error.WriteLine(ex.StackTrace);

                // Send a more detailed error to the client
                await Clients.Caller.SendAsync("ChatError", $"Registration error: {ex.Message}");

                // Rethrow to let SignalR handle it
                throw;
            }
        }

        public async Task SendMessage(SendMessageRequest request)
        {
            try
            {
                // Save the message to the database
                var chatMessage = await _chatService.SaveMessageAsync(
                    request.SenderId,
                    request.ReceiverId,
                    request.Message);

                // Send the message to the receiver if they are connected
                if (_userConnections.TryGetValue(request.ReceiverId, out string connectionId))
                {
                    await Clients.Client(connectionId).SendAsync("ReceiveMessage",
                        chatMessage.ChatMessageId,
                        chatMessage.SenderUserId,
                        chatMessage.SenderName,
                        chatMessage.ReceiverUserId,
                        chatMessage.Message,
                        chatMessage.CreatedAt);
                }

                // Also send back to the sender for confirmation
                await Clients.Caller.SendAsync("MessageSent", chatMessage.ChatMessageId);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ChatError", $"Error sending message: {ex.Message}");
                throw;
            }
        }

        public async Task InitiateChat(CreateChatSessionRequest request)
        {
            try
            {
                // Create a new chat session
                var session = await _chatService.CreateChatSessionAsync(request.CustomerId, request.Topic);

                // Notify all managers about the new chat request
                await Clients.Group("Managers").SendAsync("NewChatRequest",
                    session.ChatSessionId,
                    session.CustomerId,
                    session.CustomerName ?? "Customer",
                    session.Topic,
                    session.CreatedAt);

                // Notify the customer that their request is being processed
                if (_userConnections.TryGetValue(request.CustomerId, out string connectionId))
                {
                    await Clients.Client(connectionId).SendAsync("ChatInitiated",
                        session.ChatSessionId,
                        session.Topic);
                }
            }
            catch (Exception ex)
            {
                // Notify the customer about the error
                if (_userConnections.TryGetValue(request.CustomerId, out string connectionId))
                {
                    await Clients.Client(connectionId).SendAsync("ChatError",
                        $"Unable to initiate chat: {ex.Message}");
                }

                throw;
            }
        }

        public async Task AcceptChat(AssignManagerRequest request, int sessionId)
        {
            try
            {
                // Assign the manager to the chat session
                var session = await _chatService.AssignManagerToChatSessionAsync(sessionId, request.ManagerId);

                // Notify the customer that a manager has accepted their chat
                if (_userConnections.TryGetValue(session.CustomerId, out string customerConnectionId))
                {
                    await Clients.Client(customerConnectionId).SendAsync("ChatAccepted",
                        session.ChatSessionId,
                        request.ManagerId,
                        session.ManagerName ?? "Manager");
                }

                // Notify other managers that this chat has been taken
                await Clients.GroupExcept("Managers", Context.ConnectionId).SendAsync("ChatTaken",
                    sessionId,
                    request.ManagerId);
            }
            catch (Exception ex)
            {
                // Notify the manager about the error
                await Clients.Caller.SendAsync("ChatError",
                    $"Unable to accept chat: {ex.Message}");

                throw;
            }
        }

        public async Task EndChat(int sessionId, int userId)
        {
            try
            {
                // End the chat session
                var session = await _chatService.EndChatSessionAsync(sessionId);

                // Notify both parties that the chat has ended
                if (_userConnections.TryGetValue(session.CustomerId, out string customerConnectionId))
                {
                    await Clients.Client(customerConnectionId).SendAsync("ChatEnded", sessionId);
                }

                if (session.ManagerId.HasValue &&
                    _userConnections.TryGetValue(session.ManagerId.Value, out string managerConnectionId))
                {
                    await Clients.Client(managerConnectionId).SendAsync("ChatEnded", sessionId);
                }
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ChatError", $"Error ending chat: {ex.Message}");
                throw;
            }
        }

        public async Task MarkAsRead(int messageId, int userId)
        {
            try
            {
                var result = await _chatService.MarkMessageAsReadAsync(messageId);
                if (!result)
                {
                    await Clients.Caller.SendAsync("ChatError", $"Message with ID {messageId} not found");
                    return;
                }

                // Notify the sender that their message has been read
                var message = await _chatService.GetMessageByIdAsync(messageId);
                if (message != null && _userConnections.TryGetValue(message.SenderUserId, out string senderConnectionId))
                {
                    await Clients.Client(senderConnectionId).SendAsync("MessageRead", messageId);
                }
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ChatError", $"Error marking message as read: {ex.Message}");
                throw;
            }
        }

        public async Task GetChatSession(int sessionId)
        {
            try
            {
                var session = await _chatService.GetChatSessionAsync(sessionId);
                if (session == null)
                {
                    await Clients.Caller.SendAsync("ChatError", $"Chat session with ID {sessionId} not found");
                    return;
                }

                await Clients.Caller.SendAsync("ReceiveChatSession", session);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ChatError", $"Error retrieving chat session: {ex.Message}");
                throw;
            }
        }

        public async Task GetSessionMessages(int sessionId, int pageNumber = 1, int pageSize = 20)
        {
            try
            {
                var messages = await _chatService.GetSessionMessagesAsync(sessionId, pageNumber, pageSize);
                await Clients.Caller.SendAsync("ReceiveSessionMessages", messages);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ChatError", $"Error retrieving session messages: {ex.Message}");
                throw;
            }
        }

        public async Task GetUnreadMessages(int userId)
        {
            try
            {
                var messages = await _chatService.GetUnreadMessagesAsync(userId);
                await Clients.Caller.SendAsync("ReceiveUnreadMessages", messages);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ChatError", $"Error retrieving unread messages: {ex.Message}");
                throw;
            }
        }

        public async Task GetUnreadMessageCount(int userId)
        {
            try
            {
                var count = await _chatService.GetUnreadMessageCountAsync(userId);
                await Clients.Caller.SendAsync("ReceiveUnreadMessageCount", count);
            }
            catch (Exception ex)
            {
                await Clients.Caller.SendAsync("ChatError", $"Error retrieving unread message count: {ex.Message}");
                throw;
            }
        }
    }
}