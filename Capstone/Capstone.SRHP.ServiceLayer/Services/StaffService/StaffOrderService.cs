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
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.StaffService
{
    public class StaffOrderService : IStaffOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderService _orderService;
        private readonly ILogger<StaffOrderService> _logger;

        public StaffOrderService(
            IUnitOfWork unitOfWork,
            IOrderService orderService,
            ILogger<StaffOrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _orderService = orderService;
            _logger = logger;
        }
        public async Task<IEnumerable<StaffOrderDto>> GetAssignedOrdersAsync(int staffId)
        {
            // Get orders assigned to this staff member either as preparation staff or shipping staff
            var query = _unitOfWork.Repository<Order>().AsQueryable()
                .Where(o => !o.IsDelete &&
                    (o.PreparationStaffId == staffId || // Staff is assigned for preparation
                     o.ShippingOrder != null && o.ShippingOrder.StaffId == staffId)) // Staff is assigned for shipping
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
                        .ThenInclude(hi => hi != null ? hi.Hotpot : null);

            var orders = await query.ToListAsync();
            return orders.Select(MapToStaffOrderDto).ToList();
        }

        public async Task<IEnumerable<StaffOrderDto>> GetOrdersByStatusAsync(OrderStatus status, int staffId)
        {
            // Get orders with the specified status that are assigned to this staff member
            var orders = await _unitOfWork.Repository<Order>()
                .AsQueryable()
                .Where(o => o.Status == status && !o.IsDelete &&
                       (o.PreparationStaffId == staffId || // Staff is assigned for preparation
                        o.ShippingOrder != null && o.ShippingOrder.StaffId == staffId)) // Staff is assigned for shipping
                .Include(o => o.User)
                .Include(o => o.PreparationStaff)
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
                .ToListAsync();

            return orders.Select(MapToStaffOrderDto).ToList();
        }

        public async Task<StaffOrderDto> UpdateOrderStatusAsync(int orderId, OrderStatus newStatus, int staffId, string? notes = null)
        {
            var order = await _unitOfWork.Repository<Order>()
                .AsQueryable()
                .Include(o => o.ShippingOrder)
                    .ThenInclude(so => so != null ? so.Vehicle : null)
                .FirstOrDefaultAsync(o => o.OrderId == orderId && !o.IsDelete);

            if (order == null)
                throw new NotFoundException($"Order with ID {orderId} not found");

            // Validate status transition
            ValidateStatusTransition(order.Status, newStatus);

            // Validate staff authorization
            ValidateStaffAuthorization(order, newStatus, staffId);

            // Update order status
            order.Status = newStatus;
            order.SetUpdateDate();

            // Handle specific status transitions
            switch (newStatus)
            {
                case OrderStatus.Processed:
                    // Preparation complete - notify shipping staff if assigned
                    if (order.ShippingOrder != null)
                    {
                        // In a real system, send notification to shipping staff
                        _logger.LogInformation("Order {OrderId} is ready for shipping. Notifying staff {StaffId}",
                            orderId, order.ShippingOrder.StaffId);

                        // Add preparation completion note if provided
                        if (!string.IsNullOrWhiteSpace(notes))
                        {
                            order.Notes = string.IsNullOrWhiteSpace(order.Notes)
                                ? $"Preparation completed: {notes}"
                                : $"{order.Notes}\n\nPreparation completed ({DateTime.UtcNow:g}): {notes}";
                        }
                    }
                    break;

                case OrderStatus.Shipping:
                    // Start shipping - update shipping order
                    if (order.ShippingOrder != null && order.ShippingOrder.StaffId == staffId)
                    {
                        // Add shipping started note if provided
                        if (!string.IsNullOrWhiteSpace(notes))
                        {
                            order.Notes = string.IsNullOrWhiteSpace(order.Notes)
                                ? $"Shipping started: {notes}"
                                : $"{order.Notes}\n\nShipping started ({DateTime.UtcNow:g}): {notes}";
                        }
                    }
                    else
                    {
                        throw new ValidationException("You are not assigned to ship this order");
                    }
                    break;

                case OrderStatus.Delivered:
                    // Complete delivery - update shipping order and vehicle status
                    if (order.ShippingOrder != null && order.ShippingOrder.StaffId == staffId)
                    {
                        order.ShippingOrder.IsDelivered = true;

                        // Update vehicle status back to Available
                        if (order.ShippingOrder.Vehicle != null)
                        {
                            order.ShippingOrder.Vehicle.Status = VehicleStatus.Available;
                            order.ShippingOrder.Vehicle.SetUpdateDate();
                        }

                        // Add delivery completion note if provided
                        if (!string.IsNullOrWhiteSpace(notes))
                        {
                            order.Notes = string.IsNullOrWhiteSpace(order.Notes)
                                ? $"Delivery completed: {notes}"
                                : $"{order.Notes}\n\nDelivery completed ({DateTime.UtcNow:g}): {notes}";
                        }
                    }
                    else
                    {
                        throw new ValidationException("You are not assigned to deliver this order");
                    }
                    break;
            }

            await _unitOfWork.CommitAsync();
            return await GetOrderWithDetailsAsync(orderId);
        }


        public async Task<StaffOrderDto> CancelOrderAsync(int orderId, string cancellationReason)
        {
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

            await _unitOfWork.CommitAsync();
            return await GetOrderWithDetailsAsync(orderId);
        }

        public async Task<PagedResult<StaffOrderDto>> GetOrderHistoryAsync(
                   int pageNumber,
                   int pageSize,
                   OrderStatus? status = null,
                   DateTime? startDate = null,
                   DateTime? endDate = null)
        {
            var query = _unitOfWork.Repository<Order>()
                .AsQueryable()
                .Include(o => o.User)
                .Include(o => o.PreparationStaff)
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

            var orderDtos = items.Select(MapToStaffOrderDto).ToList();

            return new PagedResult<StaffOrderDto>
            {
                Items = orderDtos,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<StaffOrderDto> GetOrderWithDetailsAsync(int orderId)
        {
            var order = await _unitOfWork.Repository<Order>()
                .AsQueryable()
                .Include(o => o.User)
                .Include(o => o.PreparationStaff)
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

            return MapToStaffOrderDto(order);
        }


        // New method to efficiently update order properties using EF Core's SetValues
        public async Task<StaffOrderDto> UpdateOrderPropertiesAsync(int orderId, Order orderUpdate)
        {
            var order = await _unitOfWork.Repository<Order>()
                .FindAsync(o => o.OrderId == orderId && !o.IsDelete);

            if (order == null)
                throw new NotFoundException($"Order with ID {orderId} not found");

            // Using the approach from source [0] to update entity properties
            // This is a cleaner way to update multiple properties
            _unitOfWork.Context.Entry(order).CurrentValues.SetValues(orderUpdate);

            // Mark the entity as updated
            order.SetUpdateDate();

            await _unitOfWork.CommitAsync();

            return await GetOrderWithDetailsAsync(orderId);
        }

        // New method to efficiently update multiple orders using ExecuteUpdate (EF Core 7+)
        public async Task<int> UpdateOrdersStatusAsync(OrderStatus currentStatus, OrderStatus newStatus)
        {
            // Using the approach from source [1] and [2] for bulk updates
            // This is much more efficient than loading all entities and updating them one by one
            return await _unitOfWork.Repository<Order>()
                .AsQueryable()
                .Where(o => o.Status == currentStatus && !o.IsDelete)
                .ExecuteUpdateAsync(o =>
                    o.SetProperty(x => x.Status, newStatus)
                     .SetProperty(x => x.UpdatedAt, DateTime.UtcNow));
        }

        public async Task<VehicleInfoDto> GetVehicleInfoAsync(int orderId)
        {
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

        // Helper method to map Order entity to StaffOrderDto
        private StaffOrderDto MapToStaffOrderDto(Order order)
        {
            if (order == null) return null;

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

                // Preparation staff information
                PreparationStaffId = order.PreparationStaffId,
                PreparationStaffName = order.PreparationStaff?.Name,

                // Shipping information
                ShippingStaffId = order.ShippingOrder?.StaffId,
                ShippingStaffName = order.ShippingOrder?.Staff?.Name,
                IsDelivered = order.ShippingOrder?.IsDelivered ?? false,
                DeliveryNotes = order.ShippingOrder?.DeliveryNotes,

                // Order details
                OrderDetails = order.SellOrder?.SellOrderDetails?.Select(MapToOrderDetailDto).ToList() ?? new List<OrderDetailDto>(),
                RentalDetails = order.RentOrder?.RentOrderDetails?.Select(MapToRentalDetailDto).ToList() ?? new List<RentalDetailDto>(),

                // Vehicle information
                Vehicle = order.ShippingOrder?.Vehicle != null ? new VehicleInfoDto
                {
                    VehicleId = order.ShippingOrder.VehicleId ?? 0,
                    VehicleName = order.ShippingOrder.Vehicle.Name,
                    LicensePlate = order.ShippingOrder.Vehicle.LicensePlate,
                    VehicleType = order.ShippingOrder.Vehicle.Type
                } : null,
                OrderSize = order.ShippingOrder?.OrderSize ?? OrderSize.Small,

                // Payment information
                DiscountAmount = order.Discount?.DiscountPercentage ?? 0,
                DiscountCode = order.Discount?.Title,
                PaymentStatus = order.Payments?.Any(p => p.Status == PaymentStatus.Success) == true ? "Paid" : "Unpaid"
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

        private void ValidateStaffAuthorization(Order order, OrderStatus newStatus, int staffId)
        {
            switch (newStatus)
            {
                case OrderStatus.Processed:
                    // Only preparation staff can mark as processed
                    if (order.PreparationStaffId != staffId)
                    {
                        throw new ValidationException("You are not assigned as the preparation staff for this order");
                    }
                    break;

                case OrderStatus.Shipping:
                case OrderStatus.Delivered:
                    // Only shipping staff can update shipping status
                    if (order.ShippingOrder == null || order.ShippingOrder.StaffId != staffId)
                    {
                        throw new ValidationException("You are not assigned as the shipping staff for this order");
                    }
                    break;
            }
        }
    }
}