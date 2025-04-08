using Capstone.HPTY.ModelLayer.Enum;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Hubs
{
    public class EquipmentConditionHub : Hub
    {
        private static Dictionary<int, string> _adminConnections = new Dictionary<int, string>();

        public async Task RegisterAdminConnection()
        {
            try
            {
                // Extract userId from JWT claims
                var userIdClaim = Context.User.FindFirst("id");

                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int adminId))
                {
                    await Clients.Caller.SendAsync("ChatError", "Admin ID not found or invalid");
                    return;
                }

                // Verify the user is actually an admin
                var userRole = Context.User.FindFirst("role")?.Value;
                if (userRole?.ToLower() != "admin")
                {
                    await Clients.Caller.SendAsync("ChatError", "Only administrators can register as admin");
                    return;
                }

                // Store the connection ID with the admin ID
                _adminConnections[adminId] = Context.ConnectionId;

                // Add to the admin group
                await Groups.AddToGroupAsync(Context.ConnectionId, "Administrators");

                await Clients.Caller.SendAsync("AdminConnectionRegistered", adminId);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.Error.WriteLine($"Error in RegisterAdminConnection: {ex.Message}");
                Console.Error.WriteLine(ex.StackTrace);

                // Send a more detailed error to the client
                await Clients.Caller.SendAsync("ChatError", $"Admin registration error: {ex.Message}");

                // Rethrow to let SignalR handle it
                throw;
            }
        }

        public async Task NotifyConditionIssue(int conditionLogId, string equipmentType, string equipmentName, string issueName, string description, MaintenanceScheduleType scheduleType)
        {
            // Notify all administrators about the condition issue
            await Clients.Group("Administrators").SendAsync("ReceiveConditionAlert",
                conditionLogId,
                equipmentType,
                equipmentName,
                issueName,
                description,
                scheduleType.ToString(),
                DateTime.UtcNow);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Find and remove the disconnected admin
            var adminToRemove = _adminConnections.FirstOrDefault(x => x.Value == Context.ConnectionId);
            if (adminToRemove.Key != 0)
            {
                _adminConnections.Remove(adminToRemove.Key);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
