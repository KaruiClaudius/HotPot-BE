using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.StaffService
{
    public class StaffOrderService : IStaffOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffAssignmentService _staffAssignmentService;
        private readonly ILogger<StaffOrderService> _logger;

        public StaffOrderService(
            IUnitOfWork unitOfWork,
            IStaffAssignmentService staffAssignmentService,
            ILogger<StaffOrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _staffAssignmentService = staffAssignmentService;
            _logger = logger;
        }

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
                        .GetAll(o => orderIds.Contains(o.OrderId) && !o.IsDelete)
                        .Include(o => o.User)
                        .Include(o => o.ShippingOrder)
                            .ThenInclude(so => so.Vehicle)
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

                // Get the order with shipping details
                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so != null ? so.Vehicle : null)
                    .FirstOrDefaultAsync(o => o.OrderId == orderId && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

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
                        // Preparation complete - find and complete the preparation assignment
                        var preparationAssignment = staffAssignments.FirstOrDefault(a => a.TaskType == StaffTaskType.Preparation);
                        if (preparationAssignment != null)
                        {
                            preparationAssignment.CompletedDate = DateTime.UtcNow;
                            preparationAssignment.SetUpdateDate();
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
                        // Complete delivery - find and complete the shipping assignment
                        var shippingCompleteAssignment = staffAssignments.FirstOrDefault(a => a.TaskType == StaffTaskType.Shipping);
                        if (shippingCompleteAssignment != null)
                        {
                            shippingCompleteAssignment.CompletedDate = DateTime.UtcNow;
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
                    assignment.CompletedDate = DateTime.UtcNow;

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

                // Preparation staff information from assignments
                //PreparationStaffId = preparationAssignment?.StaffId,
                //PreparationStaffName = preparationAssignment?.Staff?.Name,
                //PreparationAssignmentId = preparationAssignment?.StaffAssignmentId,
                //PreparationAssignedDate = preparationAssignment?.AssignedDate,
                //PreparationCompletedDate = preparationAssignment?.CompletedDate,

                // Shipping information from assignments
                //ShippingStaffId = shippingAssignment?.StaffId,
                //ShippingStaffName = shippingAssignment?.Staff?.Name,
                //ShippingAssignmentId = shippingAssignment?.StaffAssignmentId,
                //ShippingAssignedDate = shippingAssignment?.AssignedDate,
                //ShippingCompletedDate = shippingAssignment?.CompletedDate,
                //IsDelivered = order.ShippingOrder?.IsDelivered ?? false,

                // Pickup information from assignments
                //PickupStaffId = pickupAssignment?.StaffId,
                //PickupStaffName = pickupAssignment?.Staff?.Name,
                //PickupAssignmentId = pickupAssignment?.StaffAssignmentId,
                //PickupAssignedDate = pickupAssignment?.AssignedDate,
                //PickupCompletedDate = pickupAssignment?.CompletedDate,

                // Order details
                OrderDetails = order.SellOrder?.SellOrderDetails?.Select(MapToOrderDetailDto).ToList() ?? new List<OrderDetailDto>(),
                RentalDetails = order.RentOrder?.RentOrderDetails?.Select(MapToRentalDetailDto).ToList() ?? new List<RentalDetailDto>(),

                // Vehicle information
                //Vehicle = order.ShippingOrder?.Vehicle != null ? new VehicleInfoDto
                //{
                //    VehicleId = order.ShippingOrder.VehicleId ?? 0,
                //    VehicleName = order.ShippingOrder.Vehicle.Name,
                //    LicensePlate = order.ShippingOrder.Vehicle.LicensePlate,
                //    VehicleType = order.ShippingOrder.Vehicle.Type
                //} : null,
                //OrderSize = order.ShippingOrder?.OrderSize ?? OrderSize.Small,

                // Payment information
                //DiscountAmount = order.Discount?.DiscountPercentage ?? 0,
                //DiscountCode = order.Discount?.Title,
                //PaymentStatus = order.Payments?.Any(p => p.Status == PaymentStatus.Success) == true ? "Paid" : "Unpaid",

                // Assignment information
                //Assignments = assignments?.Select(a => new StaffAssignmentInfoDto
                //{
                //    AssignmentId = a.StaffAssignmentId,
                //    StaffId = a.StaffId,
                //    StaffName = a.Staff?.Name,
                //    TaskType = a.TaskType,
                //    AssignedDate = a.AssignedDate,
                //    CompletedDate = a.CompletedDate,
                //    IsActive = a.CompletedDate == null
                //}).ToList() ?? new List<StaffAssignmentInfoDto>()
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

            return new ShippingStaffOrderDto
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
                Vehicle = order.ShippingOrder?.Vehicle != null ? new VehicleInfoDto
                {
                    VehicleId = order.ShippingOrder.VehicleId ?? 0,
                    VehicleName = order.ShippingOrder.Vehicle.Name,
                    LicensePlate = order.ShippingOrder.Vehicle.LicensePlate,
                    VehicleType = order.ShippingOrder.Vehicle.Type,
                    OrderSize = order.ShippingOrder.OrderSize
                } : null
            };
        }
    }
}