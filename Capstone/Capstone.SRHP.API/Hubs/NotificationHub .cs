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

        public async Task JoinUserSpecificGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, $"User_{userId}");
        }

        public async Task LeaveUserSpecificGroup(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"User_{userId}");
        }
        public async Task JoinRoleGroup(string role)
        {
            if (Context.User.IsInRole(role))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, role);
            }
        }
        
        public async Task LeaveRoleGroup(string role)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, role);
        }
        public override async Task OnConnectedAsync()
        {
            // Add user to their role-based group
            if (Context.User.IsInRole("Manager"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Manager");
                await Groups.AddToGroupAsync(Context.ConnectionId, "Managers"); // Keep for backward compatibility
            }
            else if (Context.User.IsInRole("Staff"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Staff");
            }
            else if (Context.User.IsInRole("Customer"))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Customer");
            }

            // Add user to their user-specific group
            var userId = Context.User.FindFirst("id")?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, $"User_{userId}");
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            // Remove user from their role-based group
            if (Context.User.IsInRole("Manager"))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Manager");
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Managers"); // Keep for backward compatibility
            }
            else if (Context.User.IsInRole("Staff"))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Staff");
            }
            else if (Context.User.IsInRole("Customer"))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, "Customer");
            }

            // Remove user from their user-specific group
            var userId = Context.User.FindFirst("id")?.Value;
            if (!string.IsNullOrEmpty(userId))
            {
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, $"User_{userId}");
            }

            await base.OnDisconnectedAsync(exception);
        }
    }
}
