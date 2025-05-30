using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Extensions;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderManagementService> _logger;
        private readonly IStaffAssignmentService _staffAssignmentService;
        private readonly ICurrentUserService _currentUserService;


        private const int MANAGER_ROLE_ID = 2; // Manager role ID
        private const int STAFF_ROLE_ID = 3; // Staff role ID
        public OrderManagementService(
       IUnitOfWork unitOfWork,
       ILogger<OrderManagementService> logger,
       IStaffAssignmentService staffAssignmentService,
       ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _staffAssignmentService = staffAssignmentService;
            _currentUserService = currentUserService;
        }

        // Order allocation
        public async Task<MultiStaffAssignmentResponse> AssignMultipleStaffToOrderAsync(
            string orderCode,
            List<int>? preparationStaffIds,
            int? shippingStaffId,
            int? vehicleId = null)
        {
            try
            {
                _logger.LogInformation("Assigning staff to order {OrderCode}: Preparation staff {PrepStaffIds}, Shipping staff {ShipStaffId}",
                    orderCode, preparationStaffIds != null ? string.Join(",", preparationStaffIds) : "none", shippingStaffId);

                // Use the ExecuteInTransactionAsync method which properly handles the execution strategy
                return await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    // Check if order exists
                    var order = await _unitOfWork.Repository<Order>()
                        .AsQueryable()
                        .Where(o => o.OrderCode == orderCode && !o.IsDelete)
                        .FirstOrDefaultAsync();

                    if (order == null)
                        throw new NotFoundException($"Order with ID {orderCode} not found");

                    // Get the current manager ID
                    int managerId = await GetCurrentManagerIdAsync();

                    // Initialize variables to store assignment results
                    List<StaffAssignmentResponse> preparationAssignmentResponses = new List<StaffAssignmentResponse>();
                    StaffAssignmentResponse shippingAssignmentResponse = null;

                    // Get existing staff assignments for this order
                    var existingAssignments = await _unitOfWork.Repository<StaffAssignment>()
                        .GetAll(sa => sa.OrderId == order.OrderId && !sa.IsDelete)
                        .Include(sa => sa.Staff)
                        .ToListAsync();

                    // 1. Assign preparation staff if provided
                    if (preparationStaffIds != null && preparationStaffIds.Any())
                    {
                        // Get existing preparation assignments
                        var existingPrepAssignments = existingAssignments
                            .Where(a => a.TaskType == StaffTaskType.Preparation)
                            .ToList();

                        // Get IDs of staff already assigned to preparation
                        var existingPrepStaffIds = existingPrepAssignments
                            .Select(a => a.StaffId)
                            .ToHashSet();

                        // Assign each preparation staff that isn't already assigned
                        foreach (var prepStaffId in preparationStaffIds.Where(id => id > 0))
                        {
                            // Skip if staff is already assigned to preparation
                            if (existingPrepStaffIds.Contains(prepStaffId))
                            {
                                _logger.LogInformation("Staff {StaffId} is already assigned to preparation for order {OrderId}, skipping",
                                    prepStaffId, order.OrderId);

                                // Add the existing assignment to our response
                                var existingAssignment = existingPrepAssignments
                                    .FirstOrDefault(a => a.StaffId == prepStaffId);

                                if (existingAssignment != null)
                                {
                                    preparationAssignmentResponses.Add(new StaffAssignmentResponse
                                    {
                                        AssignmentId = existingAssignment.StaffAssignmentId,
                                        OrderId = order.OrderId,
                                        OrderCode = order.OrderCode,
                                        StaffId = existingAssignment.StaffId,
                                        StaffName = existingAssignment.Staff?.Name,
                                        Status = order.Status,
                                        AssignedAt = existingAssignment.AssignedDate,
                                        TaskType = StaffTaskType.Preparation
                                    });
                                }

                                continue;
                            }

                            try
                            {
                                var response = await AssignStaffToTaskAsync(
                                    orderCode,
                                    prepStaffId,
                                    StaffTaskType.Preparation);

                                preparationAssignmentResponses.Add(response);
                            }
                            catch (BusinessException ex) when (ex.Message.Contains("already actively assigned"))
                            {
                                // Log the exception but continue with other staff
                                _logger.LogWarning(ex, "Staff {StaffId} is already assigned to preparation for order {OrderId}",
                                    prepStaffId, order.OrderId);

                                // Add the existing assignment to our response if we can find it
                                var existingAssignment = existingPrepAssignments
                                    .FirstOrDefault(a => a.StaffId == prepStaffId);

                                if (existingAssignment != null)
                                {
                                    preparationAssignmentResponses.Add(new StaffAssignmentResponse
                                    {
                                        AssignmentId = existingAssignment.StaffAssignmentId,
                                        OrderId = order.OrderId,
                                        OrderCode = order.OrderCode,
                                        StaffId = existingAssignment.StaffId,
                                        StaffName = existingAssignment.Staff?.Name,
                                        Status = order.Status,
                                        AssignedAt = existingAssignment.AssignedDate,
                                        TaskType = StaffTaskType.Preparation
                                    });
                                }
                            }
                        }
                    }
                    else
                    {
                        // Get existing preparation assignments if any
                        var existingPrepAssignments = existingAssignments
                            .Where(a => a.TaskType == StaffTaskType.Preparation)
                            .OrderByDescending(a => a.CreatedAt)
                            .ToList();

                        if (existingPrepAssignments.Any())
                        {
                            foreach (var assignment in existingPrepAssignments)
                            {
                                preparationAssignmentResponses.Add(new StaffAssignmentResponse
                                {
                                    AssignmentId = assignment.StaffAssignmentId,
                                    OrderId = order.OrderId,
                                    OrderCode = order.OrderCode,
                                    StaffId = assignment.StaffId,
                                    StaffName = assignment.Staff?.Name,
                                    Status = order.Status,
                                    AssignedAt = assignment.CreatedAt,
                                    TaskType = StaffTaskType.Preparation
                                });
                            }
                        }
                    }

                    // 2. Assign shipping staff if provided
                    if (shippingStaffId.HasValue && shippingStaffId.Value > 0)
                    {
                        // Check if shipping staff is already assigned
                        var existingShippingAssignment = existingAssignments
                            .FirstOrDefault(a => a.TaskType == StaffTaskType.Shipping && a.StaffId == shippingStaffId.Value);

                        if (existingShippingAssignment != null)
                        {
                            _logger.LogInformation("Staff {StaffId} is already assigned to shipping for order {OrderId}, skipping",
                                shippingStaffId.Value, order.OrderId);

                            // Use existing shipping assignment
                            var existingShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                                .AsQueryable()
                                .Include(so => so.Staff)
                                .Include(so => so.Vehicle)
                                .Where(so => so.OrderId == order.OrderId && !so.IsDelete)
                                .OrderByDescending(so => so.CreatedAt)
                                .FirstOrDefaultAsync();

                            if (existingShippingOrder != null)
                            {
                                shippingAssignmentResponse = new StaffAssignmentResponse
                                {
                                    AssignmentId = existingShippingAssignment.StaffAssignmentId,
                                    OrderId = order.OrderId,
                                    OrderCode = order.OrderCode,
                                    StaffId = existingShippingAssignment.StaffId,
                                    StaffName = existingShippingAssignment.Staff?.Name,
                                    Status = order.Status,
                                    AssignedAt = existingShippingAssignment.AssignedDate,
                                    TaskType = StaffTaskType.Shipping,
                                    ShippingOrderId = existingShippingOrder.ShippingOrderId,
                                    IsDelivered = existingShippingOrder.IsDelivered,
                                    VehicleId = existingShippingOrder.VehicleId,
                                    VehicleName = existingShippingOrder.Vehicle?.Name,
                                    VehicleType = existingShippingOrder.Vehicle?.Type,
                                    OrderSize = existingShippingOrder.OrderSize
                                };
                            }
                        }
                        else
                        {
                            try
                            {
                                // Create a request object for the shipping assignment
                                var shippingRequest = new StaffAssignmentRequest
                                {
                                    OrderCode = orderCode,
                                    StaffId = shippingStaffId.Value,
                                    TaskType = StaffTaskType.Shipping,
                                    VehicleId = vehicleId
                                };
                                shippingAssignmentResponse = await AssignShippingStaffAsync(shippingRequest);
                            }
                            catch (BusinessException ex) when (ex.Message.Contains("already actively assigned"))
                            {
                                // Log the exception but continue
                                _logger.LogWarning(ex, "Staff {StaffId} is already assigned to shipping for order {OrderId}",
                                    shippingStaffId.Value, order.OrderId);

                                // Try to get the existing shipping assignment
                                var existingShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                                    .AsQueryable()
                                    .Include(so => so.Staff)
                                    .Include(so => so.Vehicle)
                                    .Where(so => so.OrderId == order.OrderId && !so.IsDelete)
                                    .OrderByDescending(so => so.CreatedAt)
                                    .FirstOrDefaultAsync();

                                if (existingShippingOrder != null)
                                {
                                    var existingShippingAssign = existingAssignments
                                        .FirstOrDefault(a => a.TaskType == StaffTaskType.Shipping && a.StaffId == shippingStaffId.Value);

                                    if (existingShippingAssign != null)
                                    {
                                        shippingAssignmentResponse = new StaffAssignmentResponse
                                        {
                                            AssignmentId = existingShippingAssign.StaffAssignmentId,
                                            OrderId = order.OrderId,
                                            OrderCode = order.OrderCode,
                                            StaffId = existingShippingAssign.StaffId,
                                            StaffName = existingShippingAssign.Staff?.Name,
                                            Status = order.Status,
                                            AssignedAt = existingShippingAssign.AssignedDate,
                                            TaskType = StaffTaskType.Shipping,
                                            ShippingOrderId = existingShippingOrder.ShippingOrderId,
                                            IsDelivered = existingShippingOrder.IsDelivered,
                                            VehicleId = existingShippingOrder.VehicleId,
                                            VehicleName = existingShippingOrder.Vehicle?.Name,
                                            VehicleType = existingShippingOrder.Vehicle?.Type,
                                            OrderSize = existingShippingOrder.OrderSize
                                        };
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // Get existing shipping assignment if any
                        var existingShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                            .AsQueryable()
                            .Include(so => so.Staff)
                            .Include(so => so.Vehicle)
                            .Where(so => so.OrderId == order.OrderId && !so.IsDelete)
                            .OrderByDescending(so => so.CreatedAt)
                            .FirstOrDefaultAsync();

                        if (existingShippingOrder != null)
                        {
                            var existingShippingAssignment = existingAssignments
                                .FirstOrDefault(a => a.TaskType == StaffTaskType.Shipping && a.StaffId == existingShippingOrder.StaffId);

                            if (existingShippingAssignment != null)
                            {
                                shippingAssignmentResponse = new StaffAssignmentResponse
                                {
                                    AssignmentId = existingShippingAssignment.StaffAssignmentId,
                                    OrderId = order.OrderId,
                                    OrderCode = order.OrderCode,
                                    StaffId = existingShippingOrder.StaffId,
                                    StaffName = existingShippingOrder.Staff?.Name,
                                    Status = order.Status,
                                    AssignedAt = existingShippingAssignment.AssignedDate,
                                    TaskType = StaffTaskType.Shipping,
                                    ShippingOrderId = existingShippingOrder.ShippingOrderId,
                                    IsDelivered = existingShippingOrder.IsDelivered,
                                    VehicleId = existingShippingOrder.VehicleId,
                                    VehicleName = existingShippingOrder.Vehicle?.Name,
                                    VehicleType = existingShippingOrder.Vehicle?.Type,
                                    OrderSize = existingShippingOrder.OrderSize
                                };
                            }
                        }
                    }

                    // Explicitly ensure the order status is updated to Processing if we assigned preparation staff
                    order = await _unitOfWork.Repository<Order>()
                        .GetAll(o => o.OrderId == order.OrderId)
                        .FirstOrDefaultAsync();

                    if (order.Status == OrderStatus.Pending && preparationAssignmentResponses.Any())
                    {
                        order.Status = OrderStatus.Processing;
                        order.SetUpdateDate();
                        await _unitOfWork.CommitAsync();
                    }

                    // Create the response with multiple preparation staff assignments
                    return new MultiStaffAssignmentResponse
                    {
                        OrderId = order.OrderId,
                        OrderCode = order.OrderCode,
                        Status = order.Status,

                        // Preparation details - now a collection
                        PreparationStaffAssignments = preparationAssignmentResponses.Select(pa => new StaffAssignmentSummaryDTO
                        {
                            StaffId = pa.StaffId,
                            StaffName = pa.StaffName,
                            AssignedDate = pa.AssignedAt
                        }).ToList(),

                        // Shipping details (unchanged)
                        ShippingStaffId = shippingAssignmentResponse?.StaffId,
                        ShippingStaffName = shippingAssignmentResponse?.StaffName,
                        ShippingAssignmentId = shippingAssignmentResponse?.AssignmentId,
                        ShippingAssignedAt = shippingAssignmentResponse?.AssignedAt,
                        ShippingOrderId = shippingAssignmentResponse?.ShippingOrderId,
                        IsDelivered = shippingAssignmentResponse?.IsDelivered ?? false,
                        VehicleId = shippingAssignmentResponse?.VehicleId,
                        VehicleName = shippingAssignmentResponse?.VehicleName,
                        VehicleType = shippingAssignmentResponse?.VehicleType,
                        OrderSize = shippingAssignmentResponse?.OrderSize ?? OrderSize.Small
                    };
                }, ex =>
                {
                    _logger.LogError(ex, "Error in transaction while assigning staff to order {OrderCode}", orderCode);
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning staff to order {OrderCode}", orderCode);
                throw;
            }
        }

        public async Task<OrderStatusUpdateDTO> UpdateOrderStatus(string orderId, OrderStatus status)
        {
            try
            {
                _logger.LogInformation("Updating order {OrderId} status to {Status}", orderId, status);

                var order = await _unitOfWork.Repository<Order>()
                    .FindAsync(o => o.OrderCode.Equals(orderId) && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                order.Status = status;
                order.SetUpdateDate();

                await _unitOfWork.CommitAsync();

                // Map to DTO
                return new OrderStatusUpdateDTO
                {
                    OrderCode = order.OrderCode,
                    OrderId = order.OrderId,
                    Status = order.Status,
                    UpdatedAt = order.UpdatedAt ?? DateTime.UtcNow.AddHours(7)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order {OrderId} status to {Status}", orderId, status);
                throw;
            }
        }

        public async Task<OrderDetailDTO> GetOrderWithDetails(string orderId)
        {
            try
            {
                _logger.LogInformation("Getting order details for order {OrderId}", orderId);

                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderCode.Equals(orderId) && !o.IsDelete)
                    .Include(o => o.User)
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so.Staff)
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so.Vehicle)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails)
                    .AsSplitQuery()
                    .FirstOrDefaultAsync();

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                // Get staff assignments for this order
                var staffAssignments = await _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(sa => sa.OrderId == order.OrderId && !sa.IsDelete)
                    .Include(sa => sa.Staff)
                    .OrderByDescending(sa => sa.AssignedDate)
                    .ToListAsync();

                // Get all preparation assignments
                var preparationAssignments = staffAssignments
                    .Where(sa => sa.TaskType == StaffTaskType.Preparation)
                    .OrderByDescending(sa => sa.AssignedDate)
                    .ToList();

                // Get the most recent shipping assignment
                var shippingAssignment = staffAssignments
                    .Where(sa => sa.TaskType == StaffTaskType.Shipping)
                    .OrderByDescending(sa => sa.AssignedDate)
                    .FirstOrDefault();

                // Then load the details separately if needed
                if (order?.SellOrder != null)
                {
                    await _unitOfWork.Repository<SellOrderDetail>()
                        .AsQueryable()
                        .Where(d => d.OrderId == order.OrderId)
                        .Include(d => d.Ingredient)
                        .Include(d => d.Customization)
                        .Include(d => d.Combo)
                        .Include(d => d.Utensil)
                        .LoadAsync();
                }

                if (order?.RentOrder != null)
                {
                    await _unitOfWork.Repository<RentOrderDetail>()
                        .AsQueryable()
                        .Where(d => d.OrderId == order.OrderId)
                        .Include(d => d.HotpotInventory)
                            .ThenInclude(hi => hi.Hotpot)
                        .LoadAsync();
                }

                // Map to DTO
                var orderDetailDTO = new OrderDetailDTO
                {
                    OrderCode = order.OrderCode,
                    OrderId = order.OrderId,
                    Address = order.Address,
                    Notes = order.Notes ?? string.Empty,
                    TotalPrice = order.TotalPrice,
                    Status = order.Status,
                    CreatedAt = order.CreatedAt,
                    UpdatedAt = order.UpdatedAt,
                    HasSellItems = order.HasSellItems,
                    HasRentItems = order.HasRentItems,

                    // User information
                    UserId = order.UserId,
                    UserName = order.User?.Name ?? string.Empty,
                    UserPhone = order.User.PhoneNumber ?? string.Empty,

                    // Multiple preparation staff assignments
                    PreparationAssignments = preparationAssignments.Select(pa => new StaffAssignmentDTO
                    {
                        AssignmentId = pa.StaffAssignmentId,
                        StaffId = pa.StaffId,
                        StaffName = pa.Staff?.Name ?? string.Empty,
                        TaskType = pa.TaskType,
                        AssignedDate = pa.AssignedDate,
                        CompletedDate = pa.CompletedDate
                    }).ToList(),

                    // Shipping assignment
                    ShippingAssignment = shippingAssignment != null ? new StaffAssignmentDTO
                    {
                        AssignmentId = shippingAssignment.StaffAssignmentId,
                        StaffId = shippingAssignment.StaffId,
                        StaffName = shippingAssignment.Staff?.Name ?? string.Empty,
                        TaskType = shippingAssignment.TaskType,
                        AssignedDate = shippingAssignment.AssignedDate,
                        CompletedDate = shippingAssignment.CompletedDate
                    } : null,

                    // Shipping information
                    ShippingInfo = order.ShippingOrder != null ? new ShippingDetailDTO
                    {
                        ShippingOrderId = order.ShippingOrder.ShippingOrderId,
                        StaffId = order.ShippingOrder.StaffId,
                        StaffName = order.ShippingOrder.Staff?.Name ?? string.Empty,
                        DeliveryTime = order.DeliveryTime,
                        DeliveryNotes = order.ShippingOrder.DeliveryNotes ?? string.Empty,
                        IsDelivered = order.ShippingOrder.IsDelivered
                    } : null,

                    // Vehicle information
                    VehicleInfo = order.ShippingOrder?.Vehicle != null ? new VehicleInfoDto
                    {
                        VehicleId = order.ShippingOrder.Vehicle.VehicleId,
                        VehicleName = order.ShippingOrder.Vehicle.Name,
                        LicensePlate = order.ShippingOrder.Vehicle.LicensePlate,
                        VehicleType = order.ShippingOrder.Vehicle.Type,
                        OrderSize = order.ShippingOrder.OrderSize
                    } : null,

                    // Order items
                    OrderItems = new List<OrderItemDTO>()
                };

                // Add sell order items if they exist
                if (order.SellOrder != null && order.SellOrder.SellOrderDetails.Any())
                {
                    foreach (var detail in order.SellOrder.SellOrderDetails)
                    {
                        var orderItem = new OrderItemDTO
                        {
                            OrderDetailId = detail.SellOrderDetailId,
                            Quantity = detail.Quantity,
                        };

                        // Determine item type and set properties accordingly
                        if (detail.Ingredient != null)
                        {
                            orderItem.ItemType = "Ingredient";
                            orderItem.ItemName = detail.Ingredient.Name;
                            orderItem.ItemId = detail.IngredientId;
                        }
                        else if (detail.Customization != null)
                        {
                            orderItem.ItemType = "Customization";
                            orderItem.ItemName = detail.Customization.Name;
                            orderItem.ItemId = detail.CustomizationId;
                        }
                        else if (detail.Combo != null)
                        {
                            orderItem.ItemType = "Combo";
                            orderItem.ItemName = detail.Combo.Name;
                            orderItem.ItemId = detail.ComboId;
                        }
                        else if (detail.Utensil != null)
                        {
                            orderItem.ItemType = "Utensil";
                            orderItem.ItemName = detail.Utensil.Name;
                            orderItem.ItemId = detail.UtensilId;
                        }

                        orderDetailDTO.OrderItems.Add(orderItem);
                    }
                }

                // Add rent order items if they exist
                if (order.RentOrder != null && order.RentOrder.RentOrderDetails.Any())
                {
                    // Add rental information
                    orderDetailDTO.RentalInfo = new RentalInfoDTO
                    {
                        RentalStartDate = order.RentOrder.RentalStartDate,
                        ExpectedReturnDate = order.RentOrder.ExpectedReturnDate,
                    };

                    foreach (var detail in order.RentOrder.RentOrderDetails)
                    {
                        if (detail.HotpotInventory != null)
                        {
                            var orderItem = new OrderItemDTO
                            {
                                OrderDetailId = detail.RentOrderDetailId,
                                Quantity = detail.Quantity,
                                ItemType = "Hotpot",
                                ItemName = detail.HotpotInventory.Hotpot?.Name ?? "Unknown Hotpot",
                                ItemId = detail.HotpotInventoryId
                            };

                            orderDetailDTO.OrderItems.Add(orderItem);
                        }
                    }
                }

                return orderDetailDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting order details for order {OrderId}", orderId);
                throw;
            }
        }

        // Delivery progress monitoring
        public async Task<DeliveryStatusUpdateDTO> UpdateDeliveryStatus(int shippingOrderId, bool isDelivered, string notes = null)
        {
            try
            {
                _logger.LogInformation("Updating delivery status for shipping order {ShippingOrderId} to {IsDelivered}", shippingOrderId, isDelivered);

                var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                    .FindAsync(so => so.ShippingOrderId == shippingOrderId && !so.IsDelete);

                if (shippingOrder == null)
                    throw new NotFoundException($"Shipping Order with ID {shippingOrderId} not found");

                shippingOrder.IsDelivered = isDelivered;

                if (notes != null)
                    shippingOrder.DeliveryNotes = notes;

                shippingOrder.SetUpdateDate();

                // If delivered, update order status as well
                if (isDelivered)
                {
                    var order = await _unitOfWork.Repository<Order>()
                        .FindAsync(o => o.OrderId == shippingOrder.OrderId && !o.IsDelete);

                    if (order != null)
                    {
                        order.Status = OrderStatus.Delivered;
                        order.SetUpdateDate();
                    }
                }

                await _unitOfWork.CommitAsync();

                // Map to DTO
                return new DeliveryStatusUpdateDTO
                {
                    ShippingOrderId = shippingOrder.ShippingOrderId,
                    OrderCode = shippingOrder.Order.OrderCode,
                    OrderId = shippingOrder.OrderId,
                    IsDelivered = shippingOrder.IsDelivered,
                    DeliveryTime = shippingOrder.Order?.DeliveryTime,
                    DeliveryNotes = shippingOrder.DeliveryNotes ?? string.Empty,
                    UpdatedAt = shippingOrder.UpdatedAt ?? DateTime.UtcNow.AddHours(7)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating delivery status for shipping order {ShippingOrderId}", shippingOrderId);
                throw;
            }
        }

        public async Task<DeliveryTimeUpdateDTO> UpdateDeliveryTime(int shippingOrderId, DateTime deliveryTime)
        {
            try
            {
                _logger.LogInformation("Updating delivery time for shipping order {ShippingOrderId} to {DeliveryTime}", shippingOrderId, deliveryTime);

                // Use AsQueryable and Include to load the Order navigation property
                var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                    .AsQueryable()
                    .Where(so => so.ShippingOrderId == shippingOrderId && !so.IsDelete)
                    .Include(so => so.Order)  // Include the Order navigation property
                    .FirstOrDefaultAsync();

                if (shippingOrder == null)
                    throw new NotFoundException($"Shipping Order with ID {shippingOrderId} not found");

                if (shippingOrder.Order != null)
                {
                    shippingOrder.Order.DeliveryTime = deliveryTime;
                    shippingOrder.Order.SetUpdateDate();
                }

                await _unitOfWork.CommitAsync();

                // Check if Order is null before accessing its properties
                string orderCode = shippingOrder.Order?.OrderCode ?? "N/A";

                // Map to DTO
                return new DeliveryTimeUpdateDTO
                {
                    ShippingOrderId = shippingOrder.ShippingOrderId,
                    OrderId = shippingOrder.OrderId,
                    OrderCode = orderCode,
                    DeliveryTime = shippingOrder.Order?.DeliveryTime ?? DateTime.UtcNow.AddHours(7),
                    UpdatedAt = shippingOrder.UpdatedAt ?? DateTime.UtcNow.AddHours(7)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating delivery time for shipping order {ShippingOrderId}", shippingOrderId);
                throw;
            }
        }


        public async Task<PagedResult<OrderWithDetailsDTO>> GetOrdersByStatusPaged(OrderQueryParams queryParams)
        {
            try
            {
                _logger.LogInformation("Getting orders with status {Status}, page {Page}, size {Size}",
                    queryParams.Status, queryParams.PageNumber, queryParams.PageSize);

                IQueryable<Order> query = _unitOfWork.Repository<Order>()
                    .GetAll(o => !o.IsDelete)
                    .Include(o => o.User)
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so.Staff)
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so.Vehicle)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails);

                // Apply filters
                query = query.ApplyFilters(queryParams);

                // Apply sorting
                query = query.ApplySorting(queryParams);

                // Get paged result with entities
                var pagedResult = await query.ToPagedResultAsync(queryParams);

                // Get all order IDs in the current page
                var orderIds = pagedResult.Items.Select(o => o.OrderId).ToList();

                // Get all staff assignments for these orders
                var staffAssignments = await _unitOfWork.Repository<StaffAssignment>()
                    .GetAll(sa => orderIds.Contains(sa.OrderId) && !sa.IsDelete)
                    .Include(sa => sa.Staff)
                    .ToListAsync();

                // Group assignments by order ID and task type, but keep all preparation assignments
                var assignmentsByOrder = new Dictionary<int, Dictionary<StaffTaskType, List<StaffAssignment>>>();

                foreach (var assignment in staffAssignments)
                {
                    if (!assignmentsByOrder.ContainsKey(assignment.OrderId))
                    {
                        assignmentsByOrder[assignment.OrderId] = new Dictionary<StaffTaskType, List<StaffAssignment>>();
                    }

                    if (!assignmentsByOrder[assignment.OrderId].ContainsKey(assignment.TaskType))
                    {
                        assignmentsByOrder[assignment.OrderId][assignment.TaskType] = new List<StaffAssignment>();
                    }

                    assignmentsByOrder[assignment.OrderId][assignment.TaskType].Add(assignment);
                }

                // Map to DTOs
                var dtoPagedResult = new PagedResult<OrderWithDetailsDTO>
                {
                    Items = pagedResult.Items.Select(o =>
                    {
                        // Get assignments for this order
                        var orderAssignments = assignmentsByOrder.GetValueOrDefault(o.OrderId,
                            new Dictionary<StaffTaskType, List<StaffAssignment>>());

                        // Get all preparation assignments
                        var preparationAssignments = orderAssignments.GetValueOrDefault(StaffTaskType.Preparation,
                            new List<StaffAssignment>());

                        // Get the most recent shipping assignment
                        var shippingAssignments = orderAssignments.GetValueOrDefault(StaffTaskType.Shipping,
                            new List<StaffAssignment>());
                        var shippingAssignment = shippingAssignments.OrderByDescending(sa => sa.AssignedDate).FirstOrDefault();

                        // Create the DTO
                        var dto = new OrderWithDetailsDTO
                        {
                            OrderId = o.OrderCode,
                            Address = o.Address,
                            Notes = o.Notes ?? string.Empty,
                            TotalPrice = o.TotalPrice,
                            Status = o.Status,
                            HasSellItems = o.HasSellItems,
                            HasRentItems = o.HasRentItems,

                            // User information
                            UserId = o.UserId,
                            UserName = o.User?.Name ?? string.Empty,

                            // Staff assignment status
                            IsPreparationStaffAssigned = preparationAssignments.Any(),
                            IsShippingStaffAssigned = shippingAssignment != null,

                            // Multiple preparation assignments
                            PreparationAssignments = preparationAssignments
                                .OrderByDescending(pa => pa.AssignedDate)
                                .Select(pa => new StaffAssignmentSummaryDTO
                                {
                                    StaffId = pa.StaffId,
                                    StaffName = pa.Staff?.Name ?? string.Empty,
                                    AssignedDate = pa.AssignedDate
                                })
                                .ToList(),

                            // Shipping assignment
                            ShippingAssignment = shippingAssignment != null
                                ? new StaffAssignmentSummaryDTO
                                {
                                    StaffId = shippingAssignment.StaffId,
                                    StaffName = shippingAssignment.Staff?.Name ?? string.Empty,
                                    AssignedDate = shippingAssignment.AssignedDate
                                }
                                : null,

                            // Shipping information
                            ShippingInfo = o.ShippingOrder != null
                                ? new ShippingInfoDTO
                                {
                                    ShippingOrderId = o.ShippingOrder.ShippingOrderId,
                                    DeliveryTime = o.DeliveryTime,
                                    IsDelivered = o.ShippingOrder.IsDelivered,
                                    DeliveryNotes = o.ShippingOrder.DeliveryNotes ?? string.Empty,
                                    Staff = o.ShippingOrder.Staff != null
                                        ? new StaffDTO
                                        {
                                            StaffId = o.ShippingOrder.Staff.UserId,
                                            Name = o.ShippingOrder.Staff.Name
                                        }
                                        : null
                                }
                                : null,

                            // Vehicle information
                            VehicleInfo = o.ShippingOrder?.Vehicle != null
                                ? new VehicleInfoDto
                                {
                                    VehicleId = o.ShippingOrder.Vehicle.VehicleId,
                                    VehicleName = o.ShippingOrder.Vehicle.Name,
                                    LicensePlate = o.ShippingOrder.Vehicle.LicensePlate,
                                    VehicleType = o.ShippingOrder.Vehicle.Type,
                                    OrderSize = o.ShippingOrder.OrderSize
                                }
                                : null
                        };

                        return dto;
                    }).ToList(),
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize,
                    TotalCount = pagedResult.TotalCount
                };

                return dtoPagedResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting paged orders with status {Status}", queryParams.Status);
                throw;
            }
        }

        public async Task<OrderSize> EstimateOrderSizeAsync(string orderCode)
        {
            try
            {
                _logger.LogInformation("Estimating size for order {OrderId}", orderCode);

                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderCode == orderCode && !o.IsDelete)
                    .Include(o => o.SellOrder.SellOrderDetails)
                    .Include(o => o.RentOrder.RentOrderDetails)
                    .FirstOrDefaultAsync();

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderCode} not found");

                // Define business rules for order size estimation
                bool isLarge = false;

                // Rule 1: If order has more than 2 rental items, it's considered large
                if (order.HasRentItems &&
                    order.RentOrder?.RentOrderDetails?.Any() == true &&
                    order.RentOrder.RentOrderDetails.Count() > 5)
                {
                    isLarge = true;
                }

                // Rule 2: If order has at least 10 total sell items AND at least 2 combo items, it's considered large
                const int LARGE_ORDER_ITEM_THRESHOLD = 10;

                if (order.HasSellItems &&
                    order.SellOrder?.SellOrderDetails != null)
                {
                    // Check if total quantity is at least 10
                    int totalQuantity = order.SellOrder.SellOrderDetails.Sum(d => d.Quantity);

                    // Check if there are at least 2 combo items
                    int comboItemCount = order.SellOrder.SellOrderDetails
                        .Where(d => d.ComboId.HasValue)
                        .Sum(d => d.Quantity);

                    if (totalQuantity >= LARGE_ORDER_ITEM_THRESHOLD && comboItemCount >= 4)
                    {
                        isLarge = true;
                    }
                }

                return isLarge ? OrderSize.Large : OrderSize.Small;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error estimating size for order {OrderId}", orderCode);
                throw;
            }
        }

        public async Task<VehicleType> SuggestVehicleTypeAsync(string orderCode)
        {
            try
            {
                _logger.LogInformation("Suggesting vehicle type for order {OrderId}", orderCode);

                // Estimate order size
                var orderSize = await EstimateOrderSizeAsync(orderCode);

                // Suggest vehicle type based on order size
                return orderSize == OrderSize.Large ? VehicleType.Car : VehicleType.Scooter;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error suggesting vehicle type for order {OrderId}", orderCode);
                throw;
            }
        }

        private async Task<int> GetCurrentManagerIdAsync()
        {
            try
            {
                // Get the current user
                var currentUser = await _currentUserService.GetCurrentUserAsync();

                // Verify the user is a manager
                if (currentUser.RoleId != MANAGER_ROLE_ID)
                {
                    throw new UnauthorizedException("Current user is not authorized to make staff assignments");
                }

                return currentUser.UserId;
            }
            catch (UnauthorizedException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting current manager ID");
                throw new UnauthorizedException("Failed to authenticate manager");
            }
        }

        private async Task<StaffAssignmentResponse> AssignShippingStaffWithoutStatusCheckAsync(
            int orderId,
            int staffId,
            int managerId,
            int? vehicleId = null)
        {
            // Get the order
            var order = await _unitOfWork.Repository<Order>()
                .GetAll(o => o.OrderId == orderId && !o.IsDelete)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                throw new NotFoundException($"Order with ID {orderId} not found.");
            }

            // Get the staff member
            var staff = await _unitOfWork.Repository<User>()
                .GetAll(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete)
                .Include(u => u.Role)
                .FirstOrDefaultAsync();

            if (staff == null)
            {
                throw new NotFoundException($"Staff with ID {staffId} not found or is not a staff member.");
            }

            // Check staff eligibility for shipping
            if (staff.StaffType != StaffType.Preparation && staff.StaffType != StaffType.Shipping)
            {
                throw new ValidationException($"Staff with ID {staffId} is not authorized for shipping. Staff type: {staff.StaffType}");
            }

            // Check staff availability on current day
            var today = DateTime.UtcNow.AddHours(7).DayOfWeek;
            var currentDay = MapDayOfWeekToWorkDays(today);

            // Check if staff is available on the current day
            if ((staff.WorkDays & currentDay) == 0)
            {
                throw new ValidationException($"Staff with ID {staffId} is not available on {today}. Staff works on: {staff.WorkDays}");
            }

            // Check for existing active assignment
            var existingAssignment = await _unitOfWork.Repository<StaffAssignment>()
                .GetAll(sa => sa.OrderId == orderId && sa.StaffId == staffId &&
                             sa.TaskType == StaffTaskType.Shipping && sa.CompletedDate == null)
                .FirstOrDefaultAsync();

            if (existingAssignment != null)
            {
                throw new BusinessException($"Staff {staffId} is already actively assigned to shipping for order {orderId}.");
            }

            // Create the new assignment
            var newAssignment = new StaffAssignment
            {
                OrderId = orderId,
                StaffId = staffId,
                ManagerId = managerId,
                TaskType = StaffTaskType.Shipping,
                AssignedDate = DateTime.UtcNow.AddHours(7),
            };

            await _unitOfWork.Repository<StaffAssignment>().InsertAsync(newAssignment);

            // Handle shipping assignment
            ShippingOrder shippingOrder;

            // Check if shipping order already exists
            var existingShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                .FindAsync(so => so.OrderId == orderId && !so.IsDelete);

            if (existingShippingOrder != null)
            {
                _logger.LogInformation("Updating existing shipping order {ShippingOrderId} for order {OrderId}",
                    existingShippingOrder.ShippingOrderId, orderId);

                // Update existing shipping order
                existingShippingOrder.StaffId = staffId;

                if (vehicleId.HasValue)
                {
                    // Validate vehicle if provided
                    var vehicle = await _unitOfWork.Repository<Vehicle>()
                        .FindAsync(v => v.VehicleId == vehicleId.Value && !v.IsDelete);

                    if (vehicle == null)
                        throw new NotFoundException($"Vehicle with ID {vehicleId.Value} not found");

                    if (vehicle.Status != VehicleStatus.Available)
                        throw new ValidationException($"Vehicle with ID {vehicleId.Value} is not available (current status: {vehicle.Status})");

                    existingShippingOrder.VehicleId = vehicleId;

                    // Update vehicle status
                    vehicle.Status = VehicleStatus.InUse;
                    vehicle.SetUpdateDate();
                }

                existingShippingOrder.SetUpdateDate();
                await _unitOfWork.CommitAsync();
                shippingOrder = existingShippingOrder;
            }
            else
            {
                _logger.LogInformation("Creating new shipping order for order {OrderId}", orderId);

                // Estimate order size
                var orderSize = await EstimateOrderSizeAsync(order.OrderCode);

                // Create new shipping order
                shippingOrder = new ShippingOrder
                {
                    OrderId = order.OrderId,
                    StaffId = staffId,
                    VehicleId = vehicleId,
                    OrderSize = orderSize,
                    IsDelivered = false,
                    CreatedAt = DateTime.UtcNow.AddHours(7)
                };

                if (vehicleId.HasValue)
                {
                    // Validate vehicle if provided
                    var vehicle = await _unitOfWork.Repository<Vehicle>()
                        .FindAsync(v => v.VehicleId == vehicleId.Value && !v.IsDelete);

                    if (vehicle == null)
                        throw new NotFoundException($"Vehicle with ID {vehicleId.Value} not found");

                    if (vehicle.Status != VehicleStatus.Available)
                        throw new ValidationException($"Vehicle with ID {vehicleId.Value} is not available (current status: {vehicle.Status})");

                    // Update vehicle status
                    vehicle.Status = VehicleStatus.InUse;
                    vehicle.SetUpdateDate();
                }

                _unitOfWork.Repository<ShippingOrder>().Insert(shippingOrder);

                // Make sure to commit the changes
                await _unitOfWork.CommitAsync();
            }

            // Create the response
            var response = new StaffAssignmentResponse
            {
                OrderId = order.OrderId,
                OrderCode = order.OrderCode,
                StaffId = staffId,
                StaffName = staff.Name,
                AssignedAt = DateTime.UtcNow.AddHours(7),
                TaskType = StaffTaskType.Shipping,
                AssignmentId = newAssignment.StaffAssignmentId,
                Status = order.Status,
                ShippingOrderId = shippingOrder.ShippingOrderId,
                IsDelivered = shippingOrder.IsDelivered,
                OrderSize = shippingOrder.OrderSize
            };

            // Add vehicle details if applicable
            if (vehicleId.HasValue)
            {
                var vehicle = await _unitOfWork.Repository<Vehicle>()
                    .FindAsync(v => v.VehicleId == vehicleId.Value);

                if (vehicle != null)
                {
                    response.VehicleId = vehicle.VehicleId;
                    response.VehicleName = vehicle.Name;
                    response.VehicleType = vehicle.Type;
                }
            }

            return response;
        }

        // Helper method to assign staff to a task (internal version)
        private async Task<StaffAssignmentResponse> AssignStaffToTaskInternalAsync(
            int orderId,
            int staffId,
            int managerId,
            StaffTaskType taskType,
            int? vehicleId = null)
        {

            // Get the order
            var order = await _unitOfWork.Repository<Order>()
                .GetAll(o => o.OrderId == orderId && !o.IsDelete)
                .FirstOrDefaultAsync();

            if (order == null)
            {
                throw new NotFoundException($"Order with ID {orderId} not found.");
            }

            // Get the staff member
            var staff = await _unitOfWork.Repository<User>()
                .GetAll(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete)
                .Include(u => u.Role)
                .FirstOrDefaultAsync();

            if (staff == null)
            {
                throw new NotFoundException($"Staff with ID {staffId} not found or is not a staff member.");
            }

            // Check staff eligibility based on task type
            if (taskType == StaffTaskType.Preparation && staff.StaffType != StaffType.Preparation)
            {
                throw new ValidationException($"Staff with ID {staffId} is not authorized for order preparation. Only preparation staff can prepare orders.");
            }

            // Check staff availability on current day
            var today = DateTime.UtcNow.AddHours(7).DayOfWeek;
            var currentDay = MapDayOfWeekToWorkDays(today);

            // Check if staff is available on the current day
            if ((staff.WorkDays & currentDay) == 0)
            {
                throw new ValidationException($"Staff with ID {staffId} is not available on {today}. Staff works on: {staff.WorkDays}");
            }

            // Check for existing active assignment
            var existingAssignment = await _unitOfWork.Repository<StaffAssignment>()
                .GetAll(sa => sa.OrderId == orderId && sa.StaffId == staffId &&
                             sa.TaskType == taskType && sa.CompletedDate == null)
                .FirstOrDefaultAsync();

            if (existingAssignment != null)
            {
                throw new BusinessException($"Staff {staffId} is already actively assigned to task {taskType} for order {orderId}.");
            }

            // Create the new assignment
            var newAssignment = new StaffAssignment
            {
                OrderId = orderId,
                StaffId = staffId,
                ManagerId = managerId,
                TaskType = taskType,
                AssignedDate = DateTime.UtcNow.AddHours(7),
            };

            await _unitOfWork.Repository<StaffAssignment>().InsertAsync(newAssignment);

            // Handle task-specific logic
            StaffAssignmentResponse response = new StaffAssignmentResponse
            {
                OrderId = order.OrderId,
                OrderCode = order.OrderCode,
                StaffId = staffId,
                StaffName = staff.Name,
                AssignedAt = DateTime.UtcNow.AddHours(7),
                TaskType = taskType,
                AssignmentId = newAssignment.StaffAssignmentId
            };

            if (taskType == StaffTaskType.Preparation)
            {
                // Update order with preparation staff
                order.PreparationStaffId = staffId;
                order.Status = OrderStatus.Processing;
                order.SetUpdateDate();

                await _unitOfWork.CommitAsync();
                response.Status = order.Status;
            }

            return response;
        }
        private WorkDays MapDayOfWeekToWorkDays(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Monday => WorkDays.Monday,
                DayOfWeek.Tuesday => WorkDays.Tuesday,
                DayOfWeek.Wednesday => WorkDays.Wednesday,
                DayOfWeek.Thursday => WorkDays.Thursday,
                DayOfWeek.Friday => WorkDays.Friday,
                DayOfWeek.Saturday => WorkDays.Saturday,
                DayOfWeek.Sunday => WorkDays.Sunday,
                _ => throw new ArgumentOutOfRangeException(nameof(dayOfWeek), dayOfWeek, null)
            };
        }

        // Helper method to assign shipping staff
        private async Task<StaffAssignmentResponse> AssignShippingStaffAsync(StaffAssignmentRequest request)
        {
            try
            {
                _logger.LogInformation("Assigning shipping staff {StaffId} to order {OrderCode}",
                    request.StaffId, request.OrderCode);

                // Get the order
                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderCode == request.OrderCode && !o.IsDelete)
                    .FirstOrDefaultAsync();

                if (order == null)
                    throw new NotFoundException($"Order with ID {request.OrderCode} not found");

                // Get the current manager ID
                int managerId = await GetCurrentManagerIdAsync();

                // Call the internal method to handle the assignment
                return await AssignShippingStaffWithoutStatusCheckAsync(
                    order.OrderId,
                    request.StaffId,
                    managerId,
                    request.VehicleId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning shipping staff {StaffId} to order {OrderCode}",
                    request.StaffId, request.OrderCode);
                throw;
            }
        }

        // Helper method to assign staff to a task
        private async Task<StaffAssignmentResponse> AssignStaffToTaskAsync(
            string orderCode,
            int staffId,
            StaffTaskType taskType,
            int? vehicleId = null)
        {
            try
            {
                _logger.LogInformation("Assigning staff {StaffId} to {TaskType} task for order {OrderCode}",
                    staffId, taskType, orderCode);

                // Get the order
                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderCode == orderCode && !o.IsDelete)
                    .FirstOrDefaultAsync();

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderCode} not found");

                // Get the current manager ID
                int managerId = await GetCurrentManagerIdAsync();

                // Call the appropriate internal method based on task type
                if (taskType == StaffTaskType.Shipping)
                {
                    return await AssignShippingStaffWithoutStatusCheckAsync(
                        order.OrderId,
                        staffId,
                        managerId,
                        vehicleId);
                }
                else
                {
                    return await AssignStaffToTaskInternalAsync(
                        order.OrderId,
                        staffId,
                        managerId,
                        taskType,
                        vehicleId);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning staff {StaffId} to {TaskType} task for order {OrderCode}",
                    staffId, taskType, orderCode);
                throw;
            }
        }

    }
}