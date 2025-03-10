using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Hubs
{
    public class ScheduleHub : Hub
    {
        private static Dictionary<int, string> _userConnections = new Dictionary<int, string>();

        public async Task RegisterConnection(int userId, string userType, int userTypeId)
        {
            // Store the connection ID with the user ID
            _userConnections[userId] = Context.ConnectionId;

            // Add to the appropriate group based on user type
            if (userType.ToLower() == "manager")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Managers");
                await Groups.AddToGroupAsync(Context.ConnectionId, $"Manager_{userTypeId}");
            }
            else if (userType.ToLower() == "staff")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Staff");
                await Groups.AddToGroupAsync(Context.ConnectionId, $"Staff_{userTypeId}");
            }

            await Clients.Caller.SendAsync("ConnectionRegistered", userId);
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