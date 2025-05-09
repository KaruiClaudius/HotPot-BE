//using Microsoft.AspNetCore.SignalR;

//namespace Capstone.HPTY.API.Hubs
//{
//    public class EquipmentHub : Hub
//    {
//        private static Dictionary<int, string> _userConnections = new Dictionary<int, string>();
//        public async Task RegisterUserConnection()
//        {
//            try
//            {
//                // Extract userId from JWT claims
//                var userIdClaim = Context.User.FindFirst("id");

//                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
//                {
//                    await Clients.Caller.SendAsync("ChatError", "User ID not found or invalid");
//                    return;
//                }

//                // Store the connection ID with the user ID
//                _userConnections[userId] = Context.ConnectionId;

//                // Get the user's role from the Context
//                var userRole = Context.User.FindFirst("role")?.Value ?? "Customer";

//                // Add to the appropriate group based on role
//                if (userRole.ToLower() == "staff" || userRole.ToLower() == "manager")
//                {
//                    await Groups.AddToGroupAsync(Context.ConnectionId, "Staff");
//                }
//                else
//                {
//                    await Groups.AddToGroupAsync(Context.ConnectionId, "Customers");
//                }

//                await Clients.Caller.SendAsync("UserConnectionRegistered", userId);
//            }
//            catch (Exception ex)
//            {
//                // Log the exception
//                Console.Error.WriteLine($"Error in RegisterConnection: {ex.Message}");
//                Console.Error.WriteLine(ex.StackTrace);

//                // Send a more detailed error to the client
//                await Clients.Caller.SendAsync("ChatError", $"Registration error: {ex.Message}");

//                // Rethrow to let SignalR handle it
//                throw;
//            }
//        }

//        public async Task SendResolutionUpdate(int conditionLogId, string status, DateTime estimatedResolutionTime, string message)
//        {
//            // Send update to all staff members
//            await Clients.Group("Staff").SendAsync("ReceiveResolutionUpdate",
//                conditionLogId,
//                status,
//                estimatedResolutionTime,
//                message);
//        }

//        public async Task SendCustomerUpdate(int customerId, int conditionLogId, string equipmentName, string status, DateTime estimatedResolutionTime, string message)
//        {
//            // Send update to specific customer if they're connected
//            if (_userConnections.TryGetValue(customerId, out string connectionId))
//            {
//                await Clients.Client(connectionId).SendAsync("ReceiveEquipmentUpdate",
//                    conditionLogId,
//                    equipmentName,
//                    status,
//                    estimatedResolutionTime,
//                    message);
//            }
//        }

//        public override async Task OnDisconnectedAsync(Exception exception)
//        {
//            // Find and remove the disconnected user
//            var userToRemove = _userConnections.FirstOrDefault(x => x.Value == Context.ConnectionId);
//            if (userToRemove.Key != 0)
//            {
//                _userConnections.Remove(userToRemove.Key);
//            }

//            await base.OnDisconnectedAsync(exception);
//        }
//    }
//}
