using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Hubs
{
    public class EquipmentStockHub : Hub
    {
        private static Dictionary<int, string> _adminConnections = new Dictionary<int, string>();

        public async Task RegisterAdminConnection()
        {
            try
            {
                // Extract userId from JWT claims
                var userIdClaim = Context.User.FindFirst("uid");

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

                await Clients.Caller.SendAsync("ConnectionRegistered", adminId);
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

        public async Task NotifyLowStock(string equipmentType, string equipmentName, int currentQuantity, int threshold)
        {
            // Notify all administrators about low stock
            await Clients.Group("Administrators").SendAsync("ReceiveLowStockAlert",
                equipmentType,
                equipmentName,
                currentQuantity,
                threshold,
                DateTime.UtcNow);
        }

        public async Task NotifyStatusChange(string equipmentType, int equipmentId, string equipmentName, bool isAvailable, string reason)
        {
            // Notify all administrators about status change
            await Clients.Group("Administrators").SendAsync("ReceiveStatusChangeAlert",
                equipmentType,
                equipmentId,
                equipmentName,
                isAvailable,
                reason,
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
