using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging; // Added for ILogger
using System; // Added for Exception
using System.Threading.Tasks; // Added for Task

// Removed the large block of commented-out code that was here.

namespace Capstone.HPTY.API.Hubs // Assuming this is the correct namespace based on typical project structure
{
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
}