using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Hubs
{
    public class ScheduleHub : Hub
    {
        private static Dictionary<int, string> _userConnections = new Dictionary<int, string>();

        public async Task RegisterConnection()
        {
            try
            {
                // Extract userId from JWT claims
                var userIdClaim = Context.User.FindFirst("uid");

                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                {
                    await Clients.Caller.SendAsync("ChatError", "User ID not found or invalid");
                    return;
                }

                // Store the connection ID with the user ID
                _userConnections[userId] = Context.ConnectionId;

                // Get the user's role from the Context
                var userRole = Context.User.FindFirst("role")?.Value ?? "Customer";

                // Extract userTypeId if available (you might need to add this claim to your JWT token)
                var userTypeIdClaim = Context.User.FindFirst("userTypeId");
                int userTypeId = 0;
                if (userTypeIdClaim != null)
                {
                    int.TryParse(userTypeIdClaim.Value, out userTypeId);
                }

                // Add to the appropriate group based on role
                if (userRole.ToLower() == "manager")
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "Managers");
                    if (userTypeId > 0)
                    {
                        await Groups.AddToGroupAsync(Context.ConnectionId, $"Manager_{userTypeId}");
                    }
                }
                else if (userRole.ToLower() == "staff")
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "Staff");
                    if (userTypeId > 0)
                    {
                        await Groups.AddToGroupAsync(Context.ConnectionId, $"Staff_{userTypeId}");
                    }
                }
                else
                {
                    await Groups.AddToGroupAsync(Context.ConnectionId, "Customers");
                }

                await Clients.Caller.SendAsync("ConnectionRegistered", userId);
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

        public async Task NotifyScheduleUpdate(int userId, DateTime shiftDate)
        {
            // Notify the specific user about their schedule update
            if (_userConnections.TryGetValue(userId, out string connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveScheduleUpdate",
                    userId,
                    shiftDate);
            }
        }

        public async Task NotifyStaffScheduleUpdate(int staffId, DateTime shiftDate)
        {
            // Notify the specific staff member about their schedule update
            await Clients.Group($"Staff_{staffId}").SendAsync("ReceiveScheduleUpdate",
                staffId,
                shiftDate);
        }

        public async Task NotifyManagerScheduleUpdate(int managerId, DateTime shiftDate)
        {
            // Notify the specific manager about their schedule update
            await Clients.Group($"Manager_{managerId}").SendAsync("ReceiveScheduleUpdate",
                managerId,
                shiftDate);
        }

        public async Task NotifyAllScheduleUpdates()
        {
            // Notify all managers about schedule updates
            await Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");
        }

        public async Task NotifyAllStaffScheduleUpdates()
        {
            // Notify all staff members about schedule updates
            await Clients.Group("Staff").SendAsync("ReceiveAllScheduleUpdates");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Find and remove the disconnected user
            var userToRemove = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId);
            if (userToRemove.Key != 0)
            {
                _userConnections.Remove(userToRemove.Key);
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}