using Microsoft.AspNetCore.SignalR;

namespace Capstone.HPTY.API.Hubs
{
    public class FeedbackHub : Hub
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
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "Customers");
            }

            await Clients.Caller.SendAsync("ConnectionRegistered", userId);
        }

        public async Task NotifyFeedbackResponse(int userId, int feedbackId, string responseMessage, string managerName)
        {
            // Send notification to the specific user if they're connected
            if (_userConnections.TryGetValue(userId, out string connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveFeedbackResponse",
                    feedbackId,
                    responseMessage,
                    managerName,
                    DateTime.UtcNow);
            }
        }

        public async Task NotifyNewFeedback(int feedbackId, string customerName, string feedbackTitle)
        {
            // Notify all managers about new feedback
            await Clients.Group("Managers").SendAsync("ReceiveNewFeedback",
                feedbackId,
                customerName,
                feedbackTitle,
                DateTime.UtcNow);
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
