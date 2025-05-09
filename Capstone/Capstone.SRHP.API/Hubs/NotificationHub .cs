using Capstone.HPTY.API.SideServices;
using Capstone.HPTY.ServiceLayer.DTOs.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;
using static Capstone.HPTY.RepositoryLayer.Utils.AuthenTools;

public class NotificationHub : Hub<INotificationClient>
{
    private readonly IConnectionManager _connectionManager;
    private readonly ILogger<NotificationHub> _logger;

    public NotificationHub(IConnectionManager connectionManager, ILogger<NotificationHub> logger)
    {
        _connectionManager = connectionManager;
        _logger = logger;
    }

    public async Task RegisterConnection()
    {
        try
        {
            // Extract userId from JWT claims
            var userIdClaim = Context.User.FindFirst("id");
            var roleClaim = Context.User.FindFirst("role") ??
                Context.User.FindFirst(ClaimTypes.Role) ??
                Context.User.Claims.FirstOrDefault(c => c.Type.Contains("role", StringComparison.OrdinalIgnoreCase));

            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                await Clients.Caller.ReceiveNotification(new NotificationDto
                {
                    Type = "Error",
                    Title = "Connection Error",
                    Message = "User ID not found or invalid",
                    Timestamp = DateTime.UtcNow
                });
                return;
            }

            string role = roleClaim?.Value ?? "Customer";

            // Store connection
            _connectionManager.AddConnection(userId, Context.ConnectionId, role);

            // Add to role-based group
            await Groups.AddToGroupAsync(Context.ConnectionId, role);

            // Add to user-specific group
            await Groups.AddToGroupAsync(Context.ConnectionId, $"User_{userId}");

            // Add to specialized groups based on role
            if (role.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Managers");
            }
            else if (role.Equals("Staff", StringComparison.OrdinalIgnoreCase))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Staff");
            }
            else if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Administrators");
            }

            await Clients.Caller.ReceiveNotification(new NotificationDto
            {
                Type = "ConnectionRegistered",
                Title = "Connection Established",
                Message = $"Connected as {role}",
                Timestamp = DateTime.UtcNow
            });
        }
        catch (Exception ex)
        {
            await Clients.Caller.ReceiveNotification(new NotificationDto
            {
                Type = "Error",
                Title = "Connection Error",
                Message = $"Registration error: {ex.Message}",
                Timestamp = DateTime.UtcNow
            });
            throw;
        }
    }

    // Generic method to send notification to a specific user
    [Authorize]
    public async Task SendUserNotification(int userId, NotificationDto notification)
    {
        await Clients.Group($"User_{userId}").ReceiveNotification(notification);
    }

    // Generic method to send notification to a role
    [Authorize(Roles = "Admin,Manager")]
    public async Task SendRoleNotification(string role, NotificationDto notification)
    {
        await Clients.Group(role).ReceiveNotification(notification);
    }

    public override async Task OnDisconnectedAsync(Exception exception)
    {
        _connectionManager.RemoveConnection(Context.ConnectionId);
        await base.OnDisconnectedAsync(exception);
    }
}