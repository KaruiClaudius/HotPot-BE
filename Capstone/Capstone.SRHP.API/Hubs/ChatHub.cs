using System.Threading.Tasks;
using Capstone.HPTY.API.SideServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using static Capstone.HPTY.RepositoryLayer.Utils.AuthenTools;

namespace Capstone.HPTY.API.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;
        private readonly IConnectionManager _connectionManager;

        public ChatHub(
            ILogger<ChatHub> logger,
            IConnectionManager connectionManager)
        {
            _logger = logger;
            _connectionManager = connectionManager;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = Context.User.FindFirst("id")?.Value;
            var userRole = Context.User.FindFirst("role")?.Value ??
                Context.User.FindFirst(ClaimTypes.Role)?.Value ??
                Context.User.Claims.FirstOrDefault(c => c.Type.Contains("role", StringComparison.OrdinalIgnoreCase))?.Value;

            if (!string.IsNullOrEmpty(userId) && int.TryParse(userId, out int userIdInt))
            {
                // Add to user-specific group
                await Groups.AddToGroupAsync(Context.ConnectionId, $"User_{userId}");

                // Add to role-based group if available
                if (!string.IsNullOrEmpty(userRole))
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, userRole);
                }

                // Register connection in the connection manager
                _connectionManager.AddConnection(userIdInt, Context.ConnectionId, userRole);

                _logger.LogInformation($"User {userId} connected with role {userRole}");
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Remove from connection manager
            _connectionManager.RemoveConnection(Context.ConnectionId);

            var userId = Context.User.FindFirst("sub")?.Value;
            _logger.LogInformation($"User {userId} disconnected");

            await base.OnDisconnectedAsync(exception);
        }

        public async Task JoinChatSession(int sessionId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"ChatSession_{sessionId}");
            _logger.LogInformation($"Connection {Context.ConnectionId} joined chat session {sessionId}");
        }

        public async Task LeaveChatSession(int sessionId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"ChatSession_{sessionId}");
            _logger.LogInformation($"Connection {Context.ConnectionId} left chat session {sessionId}");
        }
    }
}