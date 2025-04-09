using Capstone.HPTY.API.Controllers.OrderHistory;
using Capstone.HPTY.API.SideServices;
using Capstone.HPTY.ServiceLayer.DTOs.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using static Capstone.HPTY.RepositoryLayer.Utils.AuthenTools;

namespace Capstone.HPTY.API.Hubs
{
    public class NotificationHub : Hub<INotificationClient>
    {
        private readonly IConnectionManager _connectionManager;
        private readonly ILogger<INotificationClient> _logger;

        public NotificationHub(IConnectionManager connectionManager, ILogger<INotificationClient> logger)
        {
            _connectionManager = connectionManager;
            _logger = logger;
        }

        public async Task RegisterConnection()
        {
            try
            {
                // Log all claims for debugging
                //var allClaims = Context.User.Claims.Select(c => new { c.Type, c.Value }).ToList();
                //_logger.LogInformation("Claims in token: {@Claims}", allClaims);

                // Extract userId from JWT claims
                var roleClaim = Context.User.FindFirst("role")
                    ?? Context.User.FindFirst(ClaimTypes.Role)
                    ?? Context.User.Claims.FirstOrDefault(c => c.Type.Contains("role", StringComparison.OrdinalIgnoreCase));
                var userIdClaim = Context.User.FindFirst("id");

             //   _logger.LogInformation("User ID claim: {UserIdClaim}, Role claim: {RoleClaim}",
             //userIdClaim?.Value, roleClaim?.Value);

                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                {
                    await Clients.Caller.ReceiveRentalNotification(new GeneralNotificationDto
                    {
                        Type = "Error",
                        Title = "Connection Error",
                        Message = "User ID not found or invalid"
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

                await Clients.Caller.ReceiveRentalNotification(new GeneralNotificationDto
                {
                    Type = "ConnectionRegistered",
                    Title = "Connection Established",
                    Message = $"Connected as {role}"
                });
            }
            catch (Exception ex)
            {
                await Clients.Caller.ReceiveRentalNotification(new GeneralNotificationDto
                {
                    Type = "Error",
                    Title = "Connection Error",
                    Message = $"Registration error: {ex.Message}"
                });
                throw;
            }
        }

        // Equipment condition notifications
        [Authorize(Roles = "Admin,Manager,Staff")]
        public async Task NotifyConditionIssue(EquipmentAlertDto alert)
        {
            await Clients.Group("Administrators").ReceiveConditionAlert(alert);
        }

        // Equipment status notifications
        [Authorize(Roles = "Admin,Manager")]
        public async Task NotifyStatusChange(EquipmentStatusDto status)
        {
            await Clients.Group("Administrators").ReceiveStatusChangeAlert(status);
        }

        // Stock notifications
        [Authorize(Roles = "Admin,Manager,Staff")]
        public async Task NotifyLowStock(StockAlertDto stockAlert)
        {
            await Clients.Group("Administrators").ReceiveLowStockAlert(stockAlert);
        }

        // Feedback notifications
        [Authorize(Roles = "Manager")]
        public async Task NotifyFeedbackResponse(int userId, FeedbackResponseDto response)
        {
            await Clients.Group($"User_{userId}").ReceiveFeedbackResponse(response);
        }

        [Authorize(Roles = "Customer,Staff")]
        public async Task NotifyNewFeedback(int feedbackId, string customerName, string feedbackTitle)
        {
            await Clients.Group("Admins").ReceiveNewFeedback(
                feedbackId,
                customerName,
                feedbackTitle,
                DateTime.UtcNow);
        }

        [Authorize(Roles = "Admin")]
        public async Task NotifyFeedbackApproved(int feedbackId, string adminName, string feedbackTitle)
        {
            await Clients.Group("Managers").ReceiveApprovedFeedback(
                feedbackId,
                feedbackTitle,
                adminName,
                DateTime.UtcNow);
        }

        // Schedule notifications
        [Authorize(Roles = "Manager")]
        public async Task NotifyScheduleUpdate(ScheduleUpdateDto update)
        {
            await Clients.Group($"User_{update.UserId}").ReceiveScheduleUpdate(update);
        }

        [Authorize(Roles = "Manager")]
        public async Task NotifyAllScheduleUpdates()
        {
            await Clients.Group("Staff").ReceiveAllScheduleUpdates();
        }

        // Resolution notifications
        [Authorize(Roles = "Admin,Manager")]
        public async Task SendResolutionUpdate(int conditionLogId, string status, DateTime estimatedResolutionTime, string message)
        {
            await Clients.Group("Staff").ReceiveResolutionUpdate(
                conditionLogId,
                status,
                estimatedResolutionTime,
                message);
        }

        [Authorize(Roles = "Admin,Manager")]
        public async Task SendCustomerUpdate(int customerId, int conditionLogId, string equipmentName, string status, DateTime estimatedResolutionTime, string message)
        {
            await Clients.Group($"User_{customerId}").ReceiveEquipmentUpdate(
                conditionLogId,
                equipmentName,
                status,
                estimatedResolutionTime,
                message);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            _connectionManager.RemoveConnection(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
