using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Hubs
{
    public class ScheduleHub : Hub
    {
        private static Dictionary<int, string> _userConnections = new Dictionary<int, string>();

        public async Task RegisterConnection(int userId, string userType)
        {
            // Store the connection ID with the user ID
            _userConnections[userId] = Context.ConnectionId;

            // Add to the appropriate group based on user type
            if (userType.ToLower() == "manager")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Managers");
            }
            else if (userType.ToLower() == "staff")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Staff");
            }

            await Clients.Caller.SendAsync("ConnectionRegistered", userId);
        }

        public async Task NotifyScheduleUpdate(int staffId, DateTime shiftDate)
        {
            // Notify the specific staff member about their schedule update
            if (_userConnections.TryGetValue(staffId, out string connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveScheduleUpdate",
                    staffId,
                    shiftDate);
            }
        }

        public async Task NotifyAllScheduleUpdates()
        {
            // Notify all managers about schedule updates
            await Clients.Group("Managers").SendAsync("ReceiveAllScheduleUpdates");
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
