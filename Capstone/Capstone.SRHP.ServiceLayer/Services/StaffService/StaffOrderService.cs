using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.StaffService
{
    public class StaffOrderService : IStaffOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffAssignmentService _staffAssignmentService;
        private readonly ILogger<StaffOrderService> _logger;
        private readonly INotificationService _notificationService;

        public StaffOrderService(
            IUnitOfWork unitOfWork,
            IStaffAssignmentService staffAssignmentService,
            ILogger<StaffOrderService> logger,
            INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _staffAssignmentService = staffAssignmentService;
            _logger = logger;
            _notificationService = notificationService;
        }

        //    public async Task<IEnumerable<StaffAssignedOrderBaseDto>> GetAssignedOrdersAsync(
        //int staffId, StaffTaskType staffTaskType, OrderStatus? statusFilter = null)
        //    {
        //        try
        //        {
        //            _logger.LogInformation("Getting orders assigned to staff {StaffId} with task type {TaskType} and status filter {StatusFilter}",
        //                staffId, staffTaskType, statusFilter);

        //            // Get active assignments for this staff member with the specified task type
        //            var activeAssignments = await _unitOfWork.Repository<StaffAssignment>()
        //                .GetAll(a => a.StaffId == staffId &&
        //                             a.TaskType == staffTaskType &&
        //                             a.CompletedDate == null &&
        //                             !a.IsDelete)
        //                .ToListAsync();

        //            if (!activeAssignments.Any())
        //            {
        //                return Enumerable.Empty<StaffAssignedOrderBaseDto>();
        //            }

        //            // Get the order IDs from assignments
        //            var orderIds = activeAssignments.Select(a => a.OrderId).Distinct().ToList();

        //            // For preparation staff, only show orders with Processing status
        //            if (staffTaskType == StaffTaskType.Preparation)
        //            {
        //                var preparationOrders = await _unitOfWork.Repository<Order>()
        //                    .GetAll(o => orderIds.Contains(o.OrderId) &&
        //                                 o.Status == OrderStatus.Processing &&
        //                                 !o.IsDelete)
        //                    .Include(o => o.User)
        //                    .Include(o => o.SellOrder)
        //                        .ThenInclude(so => so.SellOrderDetails)
        //                            .ThenInclude(od => od.Ingredient)
        //                    // Other includes remain the same
        //                    .AsSplitQuery() // Use split query to avoid cartesian explosion
        //                    .ToListAsync();

        //                return preparationOrders.Select(o => MapToPreparationStaffOrderDto(o,
        //                    activeAssignments.FirstOrDefault(a => a.OrderId == o.OrderId))).ToList();
        //            }
        //            else if (staffTaskType == StaffTaskType.Shipping)
        //            {
        //                // For shipping staff - apply status filter if provided
        //                IQueryable<Order> shippingOrdersQuery = _unitOfWork.Repository<Order>()
        //                    .GetAll(o => orderIds.Contains(o.OrderId) && !o.IsDelete);

        //                // Apply status filter if provided, otherwise use default behavior (Processed OR Shipping)
        //                if (statusFilter.HasValue)
        //                {
        //                    shippingOrdersQuery = shippingOrdersQuery.Where(o => o.Status == statusFilter.Value);
        //                }
        //                else
        //                {
        //                    shippingOrdersQuery = shippingOrdersQuery.Where(o =>
        //                        o.Status == OrderStatus.Processed || o.Status == OrderStatus.Shipping);
        //                }

        //                var shippingOrders = await shippingOrdersQuery
        //                    .Include(o => o.User)
        //                    .Include(o => o.ShippingOrder)
        //                        .ThenInclude(so => so.Vehicle)
        //                    .Include(o => o.SellOrder)
        //                        .ThenInclude(so => so.SellOrderDetails)
        //                            .ThenInclude(od => od.Ingredient)
        //                    // Other includes remain the same
        //                    .AsSplitQuery()
        //                    .ToListAsync();

        //                return shippingOrders.Select(o => MapToShippingStaffOrderDto(o,
        //                    activeAssignments.FirstOrDefault(a => a.OrderId == o.OrderId))).ToList();
        //            }

        //            // Default case (shouldn't happen with the current implementation)
        //            return Enumerable.Empty<StaffAssignedOrderBaseDto>();
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError(ex, "Error getting orders assigned to staff {StaffId} with task type {TaskType} and status filter {StatusFilter}",
        //                staffId, staffTaskType, statusFilter);
        //            throw;
        //        }
        //    }

        public async Task<IEnumerable<StaffAssignedOrderBaseDto>> GetAssignedOrdersAsync(int staffId, StaffTaskType staffTaskType)
        {
            try
            {
                _logger.LogInformation("Getting orders assigned to staff {StaffId} with task type {TaskType}",
                    staffId, staffTaskType);

                // Get active assignments for this staff member with the specified task type
                var activeAssignments = await _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(a => a.StaffId == staffId &&
                                 a.TaskType == staffTaskType &&
                                 a.CompletedDate == null &&
                                 !a.IsDelete)
                    .ToListAsync();

                if (!activeAssignments.Any())
                {
                    return Enumerable.Empty<StaffAssignedOrderBaseDto>();
                }

                // Get the order IDs from assignments
                var orderIds = activeAssignments.Select(a => a.OrderId).Distinct().ToList();

                // For preparation staff, only show orders with Processing status
                IQueryable<Order> ordersQuery;

                if (staffTaskType == StaffTaskType.Preparation)
                {
                    // For preparation staff
                    var preparationOrders = await _unitOfWork.Repository<Order>()
                        .GetAll(o => orderIds.Contains(o.OrderId) &&
                                     o.Status == OrderStatus.Processing &&
                                     !o.IsDelete)
                        .Include(o => o.User)
                        .Include(o => o.SellOrder)
                            .ThenInclude(so => so.SellOrderDetails)
                                .ThenInclude(od => od.Ingredient)
                        .Include(o => o.SellOrder)
                            .ThenInclude(so => so.SellOrderDetails)
                                .ThenInclude(od => od.Customization)
                        .Include(o => o.SellOrder)
                            .ThenInclude(so => so.SellOrderDetails)
                                .ThenInclude(od => od.Combo)
                        .Include(o => o.SellOrder)
                            .ThenInclude(so => so.SellOrderDetails)
                                .ThenInclude(od => od.Utensil)
                        .Include(o => o.RentOrder)
                            .ThenInclude(ro => ro.RentOrderDetails)
                                .ThenInclude(rd => rd.HotpotInventory)
                                    .ThenInclude(hi => hi.Hotpot)
                        .AsSplitQuery() // Use split query to avoid cartesian explosion
                        .ToListAsync();

                    return preparationOrders.Select(o => MapToPreparationStaffOrderDto(o,
                        activeAssignments.FirstOrDefault(a => a.OrderId == o.OrderId))).ToList();
                }
                else if (staffTaskType == StaffTaskType.Shipping)
                {
                    // For shipping staff
                    var shippingOrders = await _unitOfWork.Repository<Order>()
                        .GetAll(o => orderIds.Contains(o.OrderId)
                                    && o.Status == OrderStatus.Processed
                                    || o.Status == OrderStatus.Shipping
                                    && !o.IsDelete)
                        .Include(o => o.User)
                        .Include(o => o.ShippingOrder)
                            .ThenInclude(so => so.Vehicle)
                        .Include(o => o.SellOrder)
                            .ThenInclude(so => so.SellOrderDetails)
                                .ThenInclude(od => od.Ingredient)
                        .Include(o => o.SellOrder)
                            .ThenInclude(so => so.SellOrderDetails)
                                .ThenInclude(od => od.Customization)
                        .Include(o => o.SellOrder)
                            .ThenInclude(so => so.SellOrderDetails)
                                .ThenInclude(od => od.Combo)
                        .Include(o => o.SellOrder)
                            .ThenInclude(so => so.SellOrderDetails)
                                .ThenInclude(od => od.Utensil)
                        .Include(o => o.RentOrder)
                            .ThenInclude(ro => ro.RentOrderDetails)
                                .ThenInclude(rd => rd.HotpotInventory)
                                    .ThenInclude(hi => hi.Hotpot)
                        .AsSplitQuery()
                        .ToListAsync();

                    return shippingOrders.Select(o => MapToShippingStaffOrderDto(o,
                        activeAssignments.FirstOrDefault(a => a.OrderId == o.OrderId))).ToList();
                }

                // Default case (shouldn't happen with the current implementation)
                return Enumerable.Empty<StaffAssignedOrderBaseDto>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting orders assigned to staff {StaffId} with task type {TaskType}",
                    staffId, staffTaskType);
                throw;
            }
        }
        public async Task<StaffOrderDto> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, int staffId)
        {
            try
            {
                _logger.LogInformation("Updating order {OrderId} status to {NewStatus} by staff {StaffId}", orderId, newStatus, staffId);

                // Get the order with shipping details and rental information
                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so != null ? so.Vehicle : null)
                    .FirstOrDefaultAsync(o => o.OrderId == orderId && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                // Special handling for Delivered status - auto transition to Completed if no rent order
                if (newStatus == OrderStatus.Delivered && !order.HasRentItems)
                {
                    _logger.LogInformation("Order {OrderId} has no rent order, automatically setting to Completed instead of Delivered", orderId);
                    newStatus = OrderStatus.Completed;
                }

                // Validate status transition
                ValidateStatusTransition(order.Status, newStatus);

                // Get active assignments for this order and staff
                var staffAssignments = await _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(a => a.OrderId == orderId && a.StaffId == staffId && a.CompletedDate == null && !a.IsDelete)
                    .ToListAsync();

                // Validate staff authorization based on assignments
                ValidateStaffAuthorization(staffAssignments, newStatus);

                // Update order status
                order.Status = newStatus;
                order.SetUpdateDate();

                // Handle specific status transitions
                switch (newStatus)
                {
                    case OrderStatus.Processed:
                        // Get ALL preparation assignments for this order (not just for the current staff)
                        var allPreparationAssignments = await _unitOfWork.Repository<StaffAssignment>()
                            .GetAll(a => a.OrderId == orderId &&
                                        a.TaskType == StaffTaskType.Preparation &&
                                        a.CompletedDate == null &&
                                        !a.IsDelete)
                            .ToListAsync();

                        _logger.LogInformation("Found {Count} active preparation assignments for order {OrderId}",
                            allPreparationAssignments.Count, orderId);

                        // Mark all preparation assignments as completed
                        foreach (var assignment in allPreparationAssignments)
                        {
                            assignment.CompletedDate = DateTime.UtcNow.AddHours(7);
                            assignment.SetUpdateDate();
                            _logger.LogInformation("Marked preparation assignment {AssignmentId} for staff {StaffId} as completed",
                                assignment.StaffAssignmentId, assignment.StaffId);
                        }
                        break;

                    case OrderStatus.Shipping:
                        // Start shipping - find and update the shipping assignment
                        var shippingStartAssignment = staffAssignments.FirstOrDefault(a => a.TaskType == StaffTaskType.Shipping);
                        if (shippingStartAssignment != null)
                        {
                            shippingStartAssignment.SetUpdateDate();
                        }
                        break;

                    case OrderStatus.Delivered:
                    case OrderStatus.Completed: // Handle both Delivered and Completed the same way
                                                // Complete delivery - find and complete the shipping assignment
                        var shippingCompleteAssignment = staffAssignments.FirstOrDefault(a => a.TaskType == StaffTaskType.Shipping);
                        if (shippingCompleteAssignment != null)
                        {
                            shippingCompleteAssignment.CompletedDate = DateTime.UtcNow.AddHours(7);
                            shippingCompleteAssignment.SetUpdateDate();

                            // Update shipping order
                            if (order.ShippingOrder != null)
                            {
                                order.ShippingOrder.IsDelivered = true;

                                // Update vehicle status back to Available
                                if (order.ShippingOrder.Vehicle != null)
                                {
                                    order.ShippingOrder.Vehicle.Status = VehicleStatus.Available;
                                    order.ShippingOrder.Vehicle.SetUpdateDate();
                                }
                            }
                        }
                        break;
                }

                await _unitOfWork.CommitAsync();

                // After successful commit, send notification if status is Processed
                if (newStatus == OrderStatus.Processed)
                {
                    try
                    {
                        // Get shipping staff assignment for this order
                        var shippingAssignment = await _unitOfWork.Repository<StaffAssignment>()
                            .GetAll(a => a.OrderId == orderId &&
                                       a.TaskType == StaffTaskType.Shipping &&
                                       !a.IsDelete)
                            .FirstOrDefaultAsync();

                        if (shippingAssignment != null)
                        {
                            // Get shipping staff ID
                            int shippingStaffId = shippingAssignment.StaffId;

                            // Send notification to shipping staff
                            await _notificationService.NotifyUserAsync(
                                shippingStaffId,
                                "ShipOrder",
                                "Đơn Hàng Sẵn Sàng Để Giao",
                                $"Đơn hàng #{order.OrderId} đã được xử lý và sẵn sàng để giao.",
                                new Dictionary<string, object>
                                {
                            { "OrderId", order.OrderId },
                            { "OrderCode", order.OrderCode },
                            { "ProcessedTime", DateTime.Now.ToString("dd/MM/yyyy HH:mm") },
                            { "Instructions", "Vui lòng kiểm tra đơn hàng trước khi giao và đảm bảo đầy đủ các sản phẩm." }
                                });

                            _logger.LogInformation("Shipping staff {StaffId} notified about processed order {OrderId}",
                                shippingStaffId, orderId);
                        }
                        else
                        {
                            _logger.LogWarning("No shipping staff assigned to order {OrderId}, notification skipped", orderId);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the error but don't fail the status update
                        _logger.LogError(ex, "Failed to send notification to shipping staff for order {OrderId}", orderId);
                    }
                }

                return await GetOrderWithDetailsAsync(orderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order {OrderId} status to {NewStatus} by staff {StaffId}", orderId, newStatus, staffId);
                throw;
            }
        }

        public async Task<StaffOrderDto> CancelOrderAsync(int orderId, string cancellationReason)
        {
            try
            {
                _logger.LogInformation("Cancelling order {OrderId} with reason: {Reason}", orderId, cancellationReason);

                var order = await _unitOfWork.Repository<Order>()
                    .FindAsync(o => o.OrderId == orderId && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                // Can only cancel orders that are not already delivered or completed
                if (order.Status == OrderStatus.Delivered || order.Status == OrderStatus.Completed)
                    throw new ValidationException("Cannot cancel an order that is already delivered or completed");

                // Update status to cancelled
                order.Status = OrderStatus.Cancelled;
                order.SetUpdateDate();

                // Add cancellation reason to notes
                order.Notes = string.IsNullOrWhiteSpace(order.Notes)
                    ? $"Cancelled: {cancellationReason}"
                    : $"{order.Notes}\n\nCancelled ({DateTime.UtcNow:g}): {cancellationReason}";

                // Complete all active assignments for this order
                var activeAssignments = await _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(a => a.OrderId == orderId && a.CompletedDate == null && !a.IsDelete)
                    .ToListAsync();

                foreach (var assignment in activeAssignments)
                {
                    assignment.CompletedDate = DateTime.UtcNow.AddHours(7);

                    assignment.SetUpdateDate();
                }

                await _unitOfWork.CommitAsync();
                return await GetOrderWithDetailsAsync(orderId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<PagedResult<StaffOrderDto>> GetOrderHistoryAsync(
           int pageNumber,
           int pageSize,
           OrderStatus? status = null,
           DateTime? startDate = null,
           DateTime? endDate = null)
        {
            try
            {
                _logger.LogInformation("Getting order history with filters: status={Status}, startDate={StartDate}, endDate={EndDate}, page={Page}, size={Size}",
                    status, startDate, endDate, pageNumber, pageSize);

                var query = _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so != null ? so.Vehicle : null)
                    .Include(o => o.SellOrder.SellOrderDetails)
                    .Include(o => o.RentOrder.RentOrderDetails)
                    .Where(o => !o.IsDelete);

                // Apply filters
                if (status.HasValue)
                    query = query.Where(o => o.Status == status.Value);

                if (startDate.HasValue)
                    query = query.Where(o => o.CreatedAt >= startDate.Value);

                if (endDate.HasValue)
                {
                    // Add one day to include the end date fully
                    var endDatePlusOne = endDate.Value.AddDays(1);
                    query = query.Where(o => o.CreatedAt < endDatePlusOne);
                }

                var totalCount = await query.CountAsync();

                var items = await query
                    .OrderByDescending(o => o.CreatedAt)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Get all order IDs to fetch assignments in a single query
                var orderIds = items.Select(o => o.OrderId).ToList();

                // Get assignments for these orders
                var assignments = await _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(a => orderIds.Contains(a.OrderId) && !a.IsDelete)
                    .Include(a => a.Staff)
                    .ToListAsync();

                // Group assignments by order ID for efficient lookup
                var assignmentsByOrderId = assignments.GroupBy(a => a.OrderId)
                    .ToDictionary(g => g.Key, g => g.ToList());

                // Map to DTOs with assignment information
                var orderDtos = items.Select(o => MapToStaffOrderDto(
                    o,
                    assignmentsByOrderId.ContainsKey(o.OrderId) ? assignmentsByOrderId[o.OrderId] : new List<StaffAssignment>()
                )).ToList();

                return new PagedResult<StaffOrderDto>
                {
                    Items = orderDtos,
                    TotalCount = totalCount,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting order history");
                throw;
            }
        }

        public async Task<StaffOrderDto> GetOrderWithDetailsAsync(int orderId)
        {
            try
            {
                _logger.LogInformation("Getting order details for order {OrderId}", orderId);

                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so != null ? so.Vehicle : null)
                    .Include(o => o.SellOrder.SellOrderDetails)
                        .ThenInclude(od => od.Ingredient)
                    .Include(o => o.SellOrder.SellOrderDetails)
                        .ThenInclude(od => od.Customization)
                    .Include(o => o.SellOrder.SellOrderDetails)
                        .ThenInclude(od => od.Combo)
                    .Include(o => o.SellOrder.SellOrderDetails)
                        .ThenInclude(od => od.Utensil)
                    .Include(o => o.RentOrder.RentOrderDetails)
                        .ThenInclude(rd => rd.HotpotInventory)
                            .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .Include(o => o.Discount)
                    .Include(o => o.Payments)
                    .FirstOrDefaultAsync(o => o.OrderId == orderId && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                // Get assignments for this order
                var assignments = await _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(a => a.OrderId == orderId && !a.IsDelete)
                    .Include(a => a.Staff)
                    .ToListAsync();

                return MapToStaffOrderDto(order, assignments);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting order details for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<VehicleInfoDto> GetVehicleInfoAsync(int orderId)
        {
            try
            {
                _logger.LogInformation("Getting vehicle info for order {OrderId}", orderId);

                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so != null ? so.Vehicle : null)
                    .FirstOrDefaultAsync(o => o.OrderId == orderId && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                if (order.ShippingOrder?.Vehicle == null)
                    throw new NotFoundException($"No vehicle assigned to order with ID {orderId}");

                return new VehicleInfoDto
                {
                    VehicleId = order.ShippingOrder.VehicleId ?? 0,
                    VehicleName = order.ShippingOrder.Vehicle.Name,
                    LicensePlate = order.ShippingOrder.Vehicle.LicensePlate,
                    VehicleType = order.ShippingOrder.Vehicle.Type,
                    OrderSize = order.ShippingOrder.OrderSize
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting vehicle info for order {OrderId}", orderId);
                throw;
            }
        }

        private void ValidateStatusTransition(OrderStatus currentStatus, OrderStatus newStatus)
        {
            bool isValid = (currentStatus, newStatus) switch
            {
                // Valid transitions
                (OrderStatus.Pending, OrderStatus.Processing) => true,
                (OrderStatus.Processing, OrderStatus.Processed) => true,
                (OrderStatus.Processed, OrderStatus.Shipping) => true,
                (OrderStatus.Shipping, OrderStatus.Delivered) => true,
                (OrderStatus.Shipping, OrderStatus.Completed) => true,
                (OrderStatus.Delivered, OrderStatus.Completed) => true,

                // Allow cancellation from most states
                (_, OrderStatus.Cancelled) when currentStatus != OrderStatus.Delivered
                                           && currentStatus != OrderStatus.Completed => true,

                // Invalid transitions
                _ => false
            };

            if (!isValid)
            {
                throw new ValidationException($"Invalid status transition from {currentStatus} to {newStatus}");
            }
        }

        // Updated to use StaffAssignment instead of checking PreparationStaffId and ShippingOrder.StaffId
        private void ValidateStaffAuthorization(List<StaffAssignment> staffAssignments, OrderStatus newStatus)
        {
            if (staffAssignments == null || !staffAssignments.Any())
            {
                throw new ValidationException("You are not assigned to this order");
            }

            switch (newStatus)
            {
                case OrderStatus.Processed:
                    // Only preparation staff can mark as processed
                    if (!staffAssignments.Any(a => a.TaskType == StaffTaskType.Preparation))
                    {
                        throw new ValidationException("You are not assigned as the preparation staff for this order");
                    }
                    break;

                case OrderStatus.Shipping:
                case OrderStatus.Delivered:
                    // Only shipping staff can update shipping status
                    if (!staffAssignments.Any(a => a.TaskType == StaffTaskType.Shipping))
                    {
                        throw new ValidationException("You are not assigned as the shipping staff for this order");
                    }
                    break;
            }
        }

        // Updated to include assignment information
        private StaffOrderDto MapToStaffOrderDto(Order order, List<StaffAssignment> assignments)
        {
            if (order == null) return null;

            // Find preparation and shipping assignments
            var preparationAssignment = assignments?.FirstOrDefault(a => a.TaskType == StaffTaskType.Preparation);
            var shippingAssignment = assignments?.FirstOrDefault(a => a.TaskType == StaffTaskType.Shipping);
            var pickupAssignment = assignments?.FirstOrDefault(a => a.TaskType == StaffTaskType.Pickup);

            return new StaffOrderDto
            {
                OrderId = order.OrderId,
                OrderCode = order.OrderCode,
                Address = order.Address,
                Notes = order.Notes ?? string.Empty,
                TotalPrice = order.TotalPrice,
                Status = order.Status.ToString(),
                UserID = order.UserId,
                UserName = order.User?.Name ?? "Unknown",
                UserPhone = order.User?.PhoneNumber ?? "Unknown",
                CreatedAt = order.CreatedAt,
                UpdatedAt = order.UpdatedAt,
                DeliveryTime = order.DeliveryTime,

                // Add vehicle information
                Vehicle = MapToVehicleInfoDto(order.ShippingOrder?.Vehicle),

                // Order details
                OrderDetails = order.SellOrder?.SellOrderDetails?.Select(MapToOrderDetailDto).ToList() ?? new List<OrderDetailDto>(),
                RentalDetails = order.RentOrder?.RentOrderDetails?.Select(MapToRentalDetailDto).ToList() ?? new List<RentalDetailDto>(),
            };
        }

        // Helper method to map OrderDetail to OrderDetailDto
        private OrderDetailDto MapToOrderDetailDto(SellOrderDetail detail)
        {
            if (detail == null) return null;

            string itemName = "Unknown";
            string itemType = "Unknown";
            int? itemId = null;

            if (detail.Ingredient != null)
            {
                itemName = detail.Ingredient.Name;
                itemType = "Ingredient";
                itemId = detail.IngredientId;
            }
            else if (detail.Customization != null)
            {
                itemName = detail.Customization.Name;
                itemType = "Customization";
                itemId = detail.CustomizationId;
            }
            else if (detail.Combo != null)
            {
                itemName = detail.Combo.Name;
                itemType = "Combo";
                itemId = detail.ComboId;
            }
            else if (detail.Utensil != null)
            {
                itemName = detail.Utensil.Name;
                itemType = "Utensil";
                itemId = detail.UtensilId;
            }

            return new OrderDetailDto
            {
                OrderDetailId = detail.SellOrderDetailId,
                Quantity = detail.Quantity,
                UnitPrice = detail.UnitPrice,
                ItemName = itemName,
                ItemType = itemType,
                ItemId = itemId,
                OrderId = detail.OrderId
            };
        }

        private RentalDetailDto MapToRentalDetailDto(RentOrderDetail detail)
        {
            if (detail == null) return null;

            return new RentalDetailDto
            {
                RentalDetailId = detail.RentOrderDetailId,
                Quantity = detail.Quantity,
                RentalPrice = detail.RentalPrice,
                HotpotInventoryId = detail.HotpotInventoryId,
                HotpotName = detail.HotpotInventory?.Hotpot?.Name ?? "Unknown",
                SeriesNumber = detail.HotpotInventory?.SeriesNumber ?? "Unknown",
                RentalStartDate = detail.RentOrder?.RentalStartDate,
                ExpectedReturnDate = detail.RentOrder?.ExpectedReturnDate,
                ActualReturnDate = detail.RentOrder?.ActualReturnDate,
                LateFee = detail.RentOrder?.LateFee,
                DamageFee = detail.RentOrder?.DamageFee,
                RentalNotes = detail.RentOrder?.RentalNotes,
                ReturnCondition = detail.RentOrder?.ReturnCondition
            };
        }

        private PreparationStaffOrderDto MapToPreparationStaffOrderDto(Order order, StaffAssignment assignment)
        {
            if (order == null) return null;

            var dto = new PreparationStaffOrderDto
            {
                OrderId = order.OrderId,
                OrderCode = order.OrderCode,
                Status = order.Status.ToString(),
                CustomerName = order.User?.Name ?? "Unknown",
                CreatedAt = order.CreatedAt,
                AssignedAt = assignment?.AssignedDate,
                Notes = order.Notes ?? string.Empty,
                HasSellItems = order.HasSellItems,
                HasRentItems = order.HasRentItems
            };

            // Add sell order items
            if (order.SellOrder?.SellOrderDetails != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails)
                {
                    string itemName = "Unknown";
                    string itemType = "Unknown";
                    int itemId = 0;

                    if (detail.Ingredient != null)
                    {
                        itemName = detail.Ingredient.Name;
                        itemType = "Ingredient";
                        itemId = detail.IngredientId ?? 0; // Handle nullable
                    }
                    else if (detail.Customization != null)
                    {
                        itemName = detail.Customization.Name;
                        itemType = "Customization";
                        itemId = detail.CustomizationId ?? 0; // Handle nullable
                    }
                    else if (detail.Combo != null)
                    {
                        itemName = detail.Combo.Name;
                        itemType = "Combo";
                        itemId = detail.ComboId ?? 0; // Handle nullable
                    }
                    else if (detail.Utensil != null)
                    {
                        itemName = detail.Utensil.Name;
                        itemType = "Utensil";
                        itemId = detail.UtensilId ?? 0; // Handle nullable
                    }

                    dto.OrderItems.Add(new OrderItemSummaryDto
                    {
                        ItemId = itemId,
                        ItemName = itemName,
                        ItemType = itemType,
                        Quantity = detail.Quantity
                    });
                }
            }

            // Add hotpot rental items
            if (order.RentOrder?.RentOrderDetails != null)
            {
                foreach (var detail in order.RentOrder.RentOrderDetails)
                {
                    if (detail.HotpotInventory?.Hotpot != null)
                    {
                        dto.HotpotItems.Add(new HotpotSummaryDto
                        {
                            HotpotInventoryId = detail.HotpotInventoryId.GetValueOrDefault(),
                            HotpotName = detail.HotpotInventory.Hotpot.Name,
                            SeriesNumber = detail.HotpotInventory.SeriesNumber ?? "Unknown",
                            Quantity = detail.Quantity
                        });
                    }
                }
            }

            return dto;
        }

        private ShippingStaffOrderDto MapToShippingStaffOrderDto(Order order, StaffAssignment assignment)
        {
            if (order == null) return null;

            var dto = new ShippingStaffOrderDto
            {
                OrderId = order.OrderId,
                OrderCode = order.OrderCode,
                Status = order.Status.ToString(),
                CustomerName = order.User?.Name ?? "Unknown",
                CreatedAt = order.CreatedAt,
                AssignedAt = assignment?.AssignedDate,
                CustomerPhone = order.User?.PhoneNumber ?? "Unknown",
                ShippingAddress = order.Address ?? "Unknown",
                DeliveryTime = order.DeliveryTime,
                IsDelivered = order.ShippingOrder?.IsDelivered ?? false,
                OrderSize = order.ShippingOrder?.OrderSize ?? OrderSize.Small,
                Vehicle = order.ShippingOrder?.Vehicle != null
                    ? new VehicleInfoDto
                    {
                        VehicleId = order.ShippingOrder.VehicleId ?? 0,
                        VehicleName = order.ShippingOrder.Vehicle.Name,
                        LicensePlate = order.ShippingOrder.Vehicle.LicensePlate,
                        VehicleType = order.ShippingOrder.Vehicle.Type,
                        OrderSize = order.ShippingOrder.OrderSize
                    }
                    : null,
                OrderItems = new List<OrderItemSummaryDto>(),
                HotpotItems = new List<HotpotSummaryDto>()
            };

            // Add sell order items
            if (order.SellOrder?.SellOrderDetails != null)
            {
                dto.OrderItems.AddRange(order.SellOrder.SellOrderDetails.Select(detail =>
                {
                    string itemName = "Unknown";
                    string itemType = "Unknown";
                    int itemId = 0;

                    if (detail.Ingredient != null)
                    {
                        itemName = detail.Ingredient.Name;
                        itemType = "Ingredient";
                        itemId = detail.IngredientId ?? 0;
                    }
                    else if (detail.Customization != null)
                    {
                        itemName = detail.Customization.Name;
                        itemType = "Customization";
                        itemId = detail.CustomizationId ?? 0;
                    }
                    else if (detail.Combo != null)
                    {
                        itemName = detail.Combo.Name;
                        itemType = "Combo";
                        itemId = detail.ComboId ?? 0;
                    }
                    else if (detail.Utensil != null)
                    {
                        itemName = detail.Utensil.Name;
                        itemType = "Utensil";
                        itemId = detail.UtensilId ?? 0;
                    }

                    return new OrderItemSummaryDto
                    {
                        ItemId = itemId,
                        ItemName = itemName,
                        ItemType = itemType,
                        Quantity = detail.Quantity
                    };
                }));
            }

            // Add hotpot rental items
            if (order.RentOrder?.RentOrderDetails != null)
            {
                dto.HotpotItems.AddRange(order.RentOrder.RentOrderDetails
                    .Where(detail => detail.HotpotInventory?.Hotpot != null)
                    .Select(detail => new HotpotSummaryDto
                    {
                        HotpotInventoryId = detail.HotpotInventoryId.GetValueOrDefault(),
                        HotpotName = detail.HotpotInventory.Hotpot.Name,
                        SeriesNumber = detail.HotpotInventory.SeriesNumber ?? "Unknown",
                        Quantity = detail.Quantity
                    }));
            }

            return dto;
        }

        private VehicleInfoDto MapToVehicleInfoDto(Vehicle vehicle)
        {
            if (vehicle == null) return null;

            return new VehicleInfoDto
            {
                VehicleId = vehicle.VehicleId,
                VehicleName = vehicle.Name,
                LicensePlate = vehicle.LicensePlate,
            };
        }
    }
}