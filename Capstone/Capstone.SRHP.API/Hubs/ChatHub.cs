using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Microsoft.AspNetCore.SignalR;

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

        public async Task RegisterConnection(int userId, string userType)
        {
            // Store the connection ID with the user ID
            _userConnections[userId] = Context.ConnectionId;

            // Add to the appropriate group (manager or customer)
            if (userType.ToLower() == "manager")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Managers");
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Customers");
            }

            await Clients.Caller.SendAsync("ConnectionRegistered", userId);
        }

        public async Task SendMessage(int senderId, int receiverId, string message)
        {
            // Save the message to the database
            var chatMessage = await _chatService.SaveMessageAsync(senderId, receiverId, message);

            // Send the message to the receiver if they are connected
            if (_userConnections.TryGetValue(receiverId, out string connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessage",
                    chatMessage.ChatMessageId,
                    chatMessage.SenderUserId,
                    chatMessage.ReceiverUserId,
                    chatMessage.Message,
                    chatMessage.CreatedAt);
            }

            // Also send back to the sender for confirmation
            await Clients.Caller.SendAsync("MessageSent", chatMessage.ChatMessageId);
        }

        public async Task InitiateChat(int customerId, string topic)
        {
            // Create a new chat session
            var session = await _chatService.CreateChatSessionAsync(customerId, topic);

            // Get customer name - adjust this based on your User model structure
            string customerName = "Customer";
            if (session.Customer?.User != null)
            {
                // Use whatever properties your User model has for names
                customerName = session.Customer.User.Name ?? "Customer";
            }

            // Notify all managers about the new chat request
            await Clients.Group("Managers").SendAsync("NewChatRequest",
                session.ChatSessionId,
                session.CustomerId,
                customerName,
                session.Topic,
                session.CreatedAt);

            // Notify the customer that their request is being processed
            if (_userConnections.TryGetValue(customerId, out string connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ChatInitiated",
                    session.ChatSessionId,
                    session.Topic);
            }
        }

        public async Task AcceptChat(int managerId, int sessionId)
        {
            // Assign the manager to the chat session
            var session = await _chatService.AssignManagerToChatSessionAsync(sessionId, managerId);

            // Get manager name - adjust this based on your User model structure
            string managerName = "Manager";
            if (session.Manager != null)
            {
                // Use whatever properties your User model has for names
                managerName = session.Manager.User.Name ?? "Manager";
            }

            // Notify the customer that a manager has accepted their chat
            if (session.Customer != null && _userConnections.TryGetValue(session.Customer.UserID, out string customerConnectionId))
            {
                await Clients.Client(customerConnectionId).SendAsync("ChatAccepted",
                    session.ChatSessionId,
                    managerId,
                    managerName);
            }

            // Notify other managers that this chat has been taken
            await Clients.GroupExcept("Managers", Context.ConnectionId).SendAsync("ChatTaken", sessionId, managerId);
        }

        public async Task EndChat(int sessionId, int userId)
        {
            // End the chat session
            var session = await _chatService.EndChatSessionAsync(sessionId);

            // Notify both parties that the chat has ended
            if (session.Customer != null && _userConnections.TryGetValue(session.Customer.UserID, out string customerConnectionId))
            {
                await Clients.Client(customerConnectionId).SendAsync("ChatEnded", sessionId);
            }

            if (session.Manager != null && session.ManagerId.HasValue &&
                _userConnections.TryGetValue(session.ManagerId.Value, out string managerConnectionId))
            {
                await Clients.Client(managerConnectionId).SendAsync("ChatEnded", sessionId);
            }
        }

        public async Task MarkAsRead(int messageId, int userId)
        {
            await _chatService.MarkMessageAsReadAsync(messageId);

            // Notify the sender that their message has been read
            var message = await _chatService.GetMessageByIdAsync(messageId);
            if (message != null && _userConnections.TryGetValue(message.SenderUserId, out string senderConnectionId))
            {
                await Clients.Client(senderConnectionId).SendAsync("MessageRead", messageId);
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Find and remove the disconnected user
            var userToRemove = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId);
            if (userToRemove.Key != 0)
            {
                _userConnections.Remove(userToRemove.Key);

                // Notify relevant parties about the disconnection
                // This could be used to show "user is offline" status
                await Clients.All.SendAsync("UserDisconnected", userToRemove.Key);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
