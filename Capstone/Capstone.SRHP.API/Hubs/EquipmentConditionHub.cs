using Capstone.HPTY.ModelLayer.Enum;
using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Hubs
{
    public class EquipmentConditionHub : Hub
    {
        private static Dictionary<int, string> _adminConnections = new Dictionary<int, string>();

        public async Task RegisterAdminConnection(int adminId)
        {
            // Store the connection ID with the admin ID
            _adminConnections[adminId] = Context.ConnectionId;

            // Add to the admin group
            await Groups.AddToGroupAsync(Context.ConnectionId, "Administrators");

            await Clients.Caller.SendAsync("ConnectionRegistered", adminId);
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
