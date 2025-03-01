using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task JoinManagerGroup()
        {
            if (Context.User.IsInRole("Manager"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Managers");
            }
        }

        public async Task LeaveManagerGroup()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Managers");
        }

        public override async Task OnConnectedAsync()
        {
            // Automatically add managers to the manager group
            if (Context.User.IsInRole("Manager"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Managers");
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (Context.User.IsInRole("Manager"))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Managers");
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
