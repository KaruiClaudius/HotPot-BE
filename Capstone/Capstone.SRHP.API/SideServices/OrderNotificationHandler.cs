//using Capstone.HPTY.ModelLayer.Entities;
//using Capstone.HPTY.ModelLayer.Enum;
//using Capstone.HPTY.ServiceLayer.Interfaces.Notification;

//namespace Capstone.HPTY.API.SideServices
//{
//    public class OrderNotificationHandler
//    {
//        private readonly INotificationService _notificationService;

//        public OrderNotificationHandler(INotificationService notificationService)
//        {
//            _notificationService = notificationService;
//        }

//        public async Task HandleOrderCreated(Order order)
//        {
//            // Notify customer
//            await _notificationService.NotifyUserAsync(
//                order.UserId,
//                "OrderCreated",
//                "New Order Placed",
//                $"Your order #{order.OrderId} has been placed successfully.",
//                new Dictionary<string, object> { { "orderId", order.OrderId } }
//            );

//            // Notify staff
//            await _notificationService.NotifyRoleAsync(
//                "Staff",
//                "NewOrder",
//                "New Order Received",
//                $"Order #{order.OrderId} has been placed by customer {order.User?.Name ?? "Unknown"}.",
//                new Dictionary<string, object> { { "orderId", order.OrderId } }
//            );
//        }

//        public async Task HandleOrderStatusChanged(Order order, string previousStatus)
//        {
//            string statusMessage = GetStatusChangeMessage(order.Status);

//            await _notificationService.NotifyUserAsync(
//                order.UserId,
//                "OrderStatusChanged",
//                "Order Status Updated",
//                $"Your order #{order.OrderId} has been {statusMessage}.",
//                new Dictionary<string, object>
//                {
//                    { "orderId", order.OrderId },
//                    { "status", order.Status },
//                    { "previousStatus", previousStatus }
//                }
//            );
//        }

//        private string GetStatusChangeMessage(OrderStatus status)
//        {
//            return status switch
//            {
//                OrderStatus.Processing => "is being processed",
//                OrderStatus.Shipping => "shipping",
//                OrderStatus.Delivered => "delivered",
//                OrderStatus.Cancelled => "cancelled",
//                _ => "updated"
//            };
//        }
//    }

//    public class FeedbackNotificationHandler
//    {
//        private readonly INotificationService _notificationService;

//        public FeedbackNotificationHandler(INotificationService notificationService)
//        {
//            _notificationService = notificationService;
//        }

//        public async Task HandleFeedbackCreated(Feedback feedback)
//        {
//            // Notify managers about new feedback
//            await _notificationService.NotifyRoleAsync(
//                "Manager",
//                "NewFeedback",
//                "New Feedback Received",
//                $"New feedback has been submitted by {feedback.User?.Name ?? "a customer"}.",
//                new Dictionary<string, object> { { "feedbackId", feedback.FeedbackId } }
//            );
//        }

//        public async Task HandleFeedbackApproved(Feedback feedback)
//        {
//            // Notify the user who submitted the feedback
//            await _notificationService.NotifyUserAsync(
//                feedback.UserId,
//                "FeedbackApproved",
//                "Your Feedback Was Approved",
//                "Thank you for your feedback. It has been approved and published.",
//                new Dictionary<string, object> { { "feedbackId", feedback.FeedbackId } }
//            );
//        }
//    }

//    public class ReplacementRequestNotificationHandler
//    {
//        private readonly INotificationService _notificationService;

//        public ReplacementRequestNotificationHandler(INotificationService notificationService)
//        {
//            _notificationService = notificationService;
//        }

//        public async Task HandleReplacementRequestCreated(ReplacementRequest request)
//        {
//            // Check if we have the necessary information
//            if (request == null)
//                return;

//            // Notify staff about new replacement request
//            await _notificationService.NotifyRoleAsync(
//                "Staff",
//                "NewReplacementRequest",
//                "New Replacement Request",
//                $"A customer has requested a replacement for a hotpot.",
//                new Dictionary<string, object>
//                {
//                { "requestId", request.ReplacementRequestId },
//                { "equipmentType", "HotPot" },
//                { "requestReason", request.RequestReason },
//                { "status", request.Status.ToString() },
//                { "requestDate", request.RequestDate }
//                }
//            );

//            // Notify customer that their request was received
//            if (request.CustomerId.HasValue)
//            {
//                await _notificationService.NotifyUserAsync(
//                    request.CustomerId.Value,
//                    "ReplacementRequestReceived",
//                    "Replacement Request Received",
//                    "Your replacement request has been received and is being processed.",
//                    new Dictionary<string, object>
//                    {
//                    { "requestId", request.ReplacementRequestId },
//                    { "requestReason", request.RequestReason },
//                    { "status", request.Status.ToString() },
//                    { "requestDate", request.RequestDate }
//                    }
//                );
//            }
//        }

//        public async Task HandleReplacementRequestStatusChanged(ReplacementRequest request, string previousStatus)
//        {
//            if (request == null || !request.CustomerId.HasValue)
//                return;

//            string statusMessage = GetStatusChangeMessage(request.Status);
//            string equipmentName = GetEquipmentName(request);

//            await _notificationService.NotifyUserAsync(
//                request.CustomerId.Value,
//                "ReplacementRequestStatusChanged",
//                "Replacement Request Updated",
//                $"Your replacement request for {equipmentName} has been {statusMessage}.",
//                new Dictionary<string, object>
//                {
//                { "requestId", request.ReplacementRequestId },
//                { "equipmentName", equipmentName },
//                { "status", request.Status.ToString() },
//                { "previousStatus", previousStatus },
//                { "requestDate", request.RequestDate }
//                }
//            );
//        }

//        private string GetStatusChangeMessage(ReplacementRequestStatus status)
//        {
//            return status switch
//            {
//                ReplacementRequestStatus.Approved => "approved",
//                ReplacementRequestStatus.Rejected => "rejected",
//                ReplacementRequestStatus.InProgress => "is being processed",
//                ReplacementRequestStatus.Completed => "completed",
//                ReplacementRequestStatus.Cancelled => "cancelled",
//                _ => "updated"
//            };
//        }
//        private string GetEquipmentName(ReplacementRequest request)
//        {
//            if (request.HotPotInventory?.Hotpot != null)
//            {
//                return request.HotPotInventory.Hotpot.Name;
//            }

//            return "equipment";
//        }
//    }
//}
