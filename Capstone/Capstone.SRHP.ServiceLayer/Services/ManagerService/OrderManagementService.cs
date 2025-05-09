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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
    public class OrderManagementService : IOrderManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderManagementService> _logger;
        private const int STAFF_ROLE_ID = 3; // Staff role ID

        public OrderManagementService(IUnitOfWork unitOfWork, ILogger<OrderManagementService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // Order allocation
        public async Task<StaffAssignmentResponse> AssignStaffToOrderAsync(int orderId, int staffId, StaffTaskType taskType, int? vehicleId = null)
        {
            try
            {
                _logger.LogInformation("Assigning staff {StaffId} to order {OrderId} for task type {TaskType}",
                    staffId, orderId, taskType);

                // Check if order exists
                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderId == orderId && !o.IsDelete)
                    .FirstOrDefaultAsync();

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                // Check if staff exists (user with staff role)
                var staff = await _unitOfWork.Repository<User>()
                    .AsQueryable()
                    .Where(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete)
                    .FirstOrDefaultAsync();

                if (staff == null)
                    throw new NotFoundException($"Staff with ID {staffId} not found");

                // Check staff eligibility based on task type
                if (taskType == StaffTaskType.Preparation && staff.StaffType != StaffType.Preparation)
                {
                    throw new ValidationException($"Staff with ID {staffId} is not authorized for order preparation. Only preparation staff can prepare orders.");
                }
                else if (taskType == StaffTaskType.Shipping &&
                         staff.StaffType != StaffType.Preparation &&
                         staff.StaffType != StaffType.Shipping)
                {
                    throw new ValidationException($"Staff with ID {staffId} is not authorized for shipping. Staff type: {staff.StaffType}");
                }

                // Check staff availability on current day
                var today = DateTime.Now.DayOfWeek;
                var currentDay = MapDayOfWeekToWorkDays(today);

                // Check if staff is available on the current day
                if ((staff.WorkDays & currentDay) == 0)
                {
                    throw new ValidationException($"Staff with ID {staffId} is not available on {today}. Staff works on: {staff.WorkDays}");
                }

                // Check for double-booking
                bool isDoubleBooked = false;

                if (taskType == StaffTaskType.Preparation)
                {
                    // Check if staff is already assigned to another preparation task
                    var activePreparationAssignment = await _unitOfWork.Repository<Order>()
                        .AsQueryable(o => o.PreparationStaffId == staffId &&
                                         o.Status == OrderStatus.Processing &&
                                         !o.IsDelete)
                        .AnyAsync();

                    isDoubleBooked = activePreparationAssignment;
                }
                else if (taskType == StaffTaskType.Shipping)
                {
                    // Special case: If this staff prepared this order and it's now Processed,
                    // they can ship it even if they have other preparation tasks
                    bool preparedThisOrder = order.PreparationStaffId == staffId &&
                                            order.Status == OrderStatus.Processed;

                    if (!preparedThisOrder)
                    {
                        // Check if staff is already assigned to another shipping task
                        var activeShippingAssignment = await _unitOfWork.Repository<ShippingOrder>()
                            .AsQueryable(so => so.StaffId == staffId &&
                                             !so.IsDelivered &&
                                             !so.IsDelete)
                            .AnyAsync();

                        // Check if staff is busy with preparation
                        var activePreparationAssignment = await _unitOfWork.Repository<Order>()
                            .AsQueryable(o => o.PreparationStaffId == staffId &&
                                            o.Status == OrderStatus.Processing &&
                                            !o.IsDelete)
                            .AnyAsync();

                        isDoubleBooked = activeShippingAssignment || activePreparationAssignment;
                    }
                }

                if (isDoubleBooked)
                {
                    throw new ValidationException($"Staff with ID {staffId} is already assigned to another task and cannot be double-booked.");
                }

                // Create the response object
                var response = new StaffAssignmentResponse
                {
                    OrderId = order.OrderId,
                    OrderCode = order.OrderCode,
                    StaffId = staffId,
                    StaffName = staff.Name,
                    AssignedAt = DateTime.UtcNow,
                    TaskType = taskType
                };

                // Handle the assignment based on task type
                if (taskType == StaffTaskType.Preparation)
                {
                    // Update order with preparation staff
                    order.PreparationStaffId = staffId;
                    order.Status = OrderStatus.Processing;
                    order.SetUpdateDate();

                    response.Status = order.Status;
                }
                else if (taskType == StaffTaskType.Shipping)
                {
                    // Validate order status for shipping
                    if (order.Status != OrderStatus.Processed)
                    {
                        throw new ValidationException($"Order with ID {orderId} is not ready for shipping. Current status: {order.Status}");
                    }

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

                            // Add vehicle details to response
                            response.VehicleId = vehicle.VehicleId;
                            response.VehicleName = vehicle.Name;
                            response.VehicleType = vehicle.Type;
                        }

                        existingShippingOrder.SetUpdateDate();
                        shippingOrder = existingShippingOrder;
                    }
                    else
                    {
                        _logger.LogInformation("Creating new shipping order for order {OrderId}", orderId);

                        // Estimate order size
                        var orderSize = await EstimateOrderSizeAsync(orderId);

                        // Create new shipping order
                        shippingOrder = new ShippingOrder
                        {
                            OrderId = orderId,
                            StaffId = staffId,
                            VehicleId = vehicleId,
                            OrderSize = orderSize,
                            IsDelivered = false,
                            CreatedAt = DateTime.UtcNow
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

                            // Add vehicle details to response
                            response.VehicleId = vehicle.VehicleId;
                            response.VehicleName = vehicle.Name;
                            response.VehicleType = vehicle.Type;
                        }

                        _unitOfWork.Repository<ShippingOrder>().Insert(shippingOrder);

                        response.OrderSize = orderSize;
                    }

                    // Add shipping details to response
                    response.Status = order.Status;
                    response.ShippingOrderId = shippingOrder.ShippingOrderId;
                    response.IsDelivered = shippingOrder.IsDelivered;
                }

                // Save all changes
                await _unitOfWork.CommitAsync();

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error assigning staff {StaffId} to order {OrderId} for task type {TaskType}",
                    staffId, orderId, taskType);
                throw;
            }
        }

        public async Task<IEnumerable<StaffShippingOrderDTO>> GetOrdersByStaff(int staffId)
        {
            try
            {
                _logger.LogInformation("Getting orders for staff {StaffId}", staffId);

                // Check if staff exists (user with staff role)
                var staff = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

                if (staff == null)
                    throw new NotFoundException($"Staff with ID {staffId} not found");

                // Get all shipping orders for this staff
                var shippingOrders = await _unitOfWork.Repository<ShippingOrder>()
                    .GetAll(so => so.StaffId == staffId && !so.IsDelete)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.User)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.SellOrder.SellOrderDetails)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.RentOrder.RentOrderDetails)
                    .Include(so => so.Staff)
                    .ToListAsync();

                // Map to DTOs
                return shippingOrders.Select(so => new StaffShippingOrderDTO
                {
                    ShippingOrderId = so.ShippingOrderId,
                    OrderId = so.Order.OrderCode,
                    DeliveryTime = so.Order?.DeliveryTime,
                    DeliveryNotes = so.DeliveryNotes,
                    IsDelivered = so.IsDelivered,

                    // Order information
                    Address = so.Order?.Address,
                    Notes = so.Order?.Notes,
                    TotalPrice = so.Order?.TotalPrice ?? 0,
                    Status = so.Order?.Status ?? OrderStatus.Pending,

                    // Customer information
                    CustomerId = so.Order?.UserId ?? 0,
                    CustomerName = so.Order?.User?.Name,

                    // Order type indicators
                    HasSellItems = so.Order?.HasSellItems ?? false,
                    HasRentItems = so.Order?.HasRentItems ?? false,
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting orders for staff {StaffId}", staffId);
                throw;
            }
        }

        // Order status tracking
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
                    UpdatedAt = order.UpdatedAt ?? DateTime.UtcNow
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
                        .ThenInclude(so => so.Vehicle) // Add this to include vehicle information
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails)
                    .AsSplitQuery() // This can help with large object graphs
                    .FirstOrDefaultAsync();

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

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

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
                    UpdatedAt = shippingOrder.UpdatedAt ?? DateTime.UtcNow
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
                    DeliveryTime = shippingOrder.Order?.DeliveryTime ?? DateTime.UtcNow,
                    UpdatedAt = shippingOrder.UpdatedAt ?? DateTime.UtcNow
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating delivery time for shipping order {ShippingOrderId}", shippingOrderId);
                throw;
            }
        }

        public async Task<PagedResult<UnallocatedOrderDTO>> GetUnallocatedOrdersPaged(OrderQueryParams queryParams)
        {
            try
            {
                _logger.LogInformation("Getting unallocated orders, page {Page}, size {Size}",
                    queryParams.PageNumber, queryParams.PageSize);

                // Explicitly declare as IQueryable<Order>
                IQueryable<Order> query = _unitOfWork.Repository<Order>()
                    .GetAll(o =>
                        o.ShippingOrder == null &&
                        !o.IsDelete &&
                        o.Status != OrderStatus.Cart) // Exclude Cart orders
                    .Include(o => o.User)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails);

                // Apply filters (except status since we're filtering by ShippingOrder == null)
                if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
                {
                    var searchTerm = queryParams.SearchTerm.ToLower();
                    query = query.Where(o =>
                        o.Address.ToLower().Contains(searchTerm) ||
                        (o.Notes != null && o.Notes.ToLower().Contains(searchTerm)) ||
                        (o.User != null && o.User.Name.ToLower().Contains(searchTerm))
                    );
                }

                // Apply sorting
                query = query.ApplySorting(queryParams);

                // Get paged result with entities
                var pagedResult = await query.ToPagedResultAsync(queryParams);

                // Map to DTOs
                var dtoPagedResult = new PagedResult<UnallocatedOrderDTO>
                {
                    Items = pagedResult.Items.Select(o => new UnallocatedOrderDTO
                    {
                        OrderId = o.OrderId,
                        OrderCode = o.OrderCode,
                        Address = o.Address,
                        Notes = o.Notes ?? string.Empty,
                        TotalPrice = o.TotalPrice,
                        Status = o.Status,
                        UserId = o.UserId,
                        UserName = o.User?.Name ?? string.Empty,
                        HasSellItems = o.HasSellItems,
                        HasRentItems = o.HasRentItems,
                    }).ToList(),
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize,
                    TotalCount = pagedResult.TotalCount,
                };

                return dtoPagedResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting unallocated orders");
                throw;
            }
        }

        public async Task<PagedResult<PendingDeliveryDTO>> GetPendingDeliveriesPaged(ShippingOrderQueryParams queryParams)
        {
            try
            {
                _logger.LogInformation("Getting pending deliveries, page {Page}, size {Size}",
                    queryParams.PageNumber, queryParams.PageSize);

                // Explicitly declare as IQueryable<ShippingOrder>
                IQueryable<ShippingOrder> query = _unitOfWork.Repository<ShippingOrder>()
                    .GetAll(so => !so.IsDelivered && !so.IsDelete)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.User)
                    .Include(so => so.Vehicle); // Add this to include vehicle information

                // Apply filters
                query = query.ApplyFilters(queryParams);

                // Apply sorting
                query = query.ApplySorting(queryParams);

                // Get paged result with entities
                var pagedResult = await query.ToPagedResultAsync(queryParams);

                // Map to DTOs
                var dtoPagedResult = new PagedResult<PendingDeliveryDTO>
                {
                    Items = pagedResult.Items.Select(so => new PendingDeliveryDTO
                    {
                        ShippingOrderId = so.ShippingOrderId,
                        OrderId = so.Order.OrderCode,
                        DeliveryTime = so.Order?.DeliveryTime,
                        DeliveryNotes = so.DeliveryNotes ?? string.Empty,

                        // Order information
                        Address = so.Order?.Address ?? string.Empty,
                        Notes = so.Order?.Notes ?? string.Empty,
                        TotalPrice = so.Order?.TotalPrice ?? 0,
                        Status = so.Order?.Status ?? OrderStatus.Pending,

                        // Customer information
                        UserId = so.Order?.UserId ?? 0,
                        UserName = so.Order?.User?.Name ?? string.Empty,

                        // Vehicle information
                        VehicleInfo = so.Vehicle != null ? new VehicleInfoDto
                        {
                            VehicleId = so.Vehicle.VehicleId,
                            VehicleName = so.Vehicle.Name,
                            LicensePlate = so.Vehicle.LicensePlate,
                            VehicleType = so.Vehicle.Type,
                            OrderSize = so.OrderSize
                        } : null
                    }).ToList(),
                    PageNumber = pagedResult.PageNumber,
                    PageSize = pagedResult.PageSize,
                    TotalCount = pagedResult.TotalCount
                };

                return dtoPagedResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting pending deliveries");
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

                // Map to DTOs
                var dtoPagedResult = new PagedResult<OrderWithDetailsDTO>
                {
                    Items = pagedResult.Items.Select(o => new OrderWithDetailsDTO
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

                        // Shipping information
                        ShippingInfo = o.ShippingOrder != null ? new ShippingInfoDTO
                        {
                            ShippingOrderId = o.ShippingOrder.ShippingOrderId,
                            DeliveryTime = o.DeliveryTime,
                            IsDelivered = o.ShippingOrder.IsDelivered,
                            DeliveryNotes = o.ShippingOrder.DeliveryNotes ?? string.Empty,
                            Staff = o.ShippingOrder.Staff != null ? new StaffDTO
                            {
                                StaffId = o.ShippingOrder.Staff.UserId,
                                Name = o.ShippingOrder.Staff.Name
                            } : null
                        } : null,

                        // Vehicle information
                        VehicleInfo = o.ShippingOrder?.Vehicle != null ? new VehicleInfoDto
                        {
                            VehicleId = o.ShippingOrder.Vehicle.VehicleId,
                            VehicleName = o.ShippingOrder.Vehicle.Name,
                            LicensePlate = o.ShippingOrder.Vehicle.LicensePlate,
                            VehicleType = o.ShippingOrder.Vehicle.Type,
                            OrderSize = o.ShippingOrder.OrderSize
                        } : null
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

        public async Task<OrderSize> EstimateOrderSizeAsync(int orderId)
        {
            try
            {
                _logger.LogInformation("Estimating size for order {OrderId}", orderId);

                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderId == orderId && !o.IsDelete)
                    .Include(o => o.SellOrder.SellOrderDetails)
                    .Include(o => o.RentOrder.RentOrderDetails)
                    .FirstOrDefaultAsync();

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                // Define business rules for order size estimation
                bool isLarge = false;

                // Rule 1: If order has more than 2 rental items, it's considered large
                if (order.HasRentItems &&
                    order.RentOrder?.RentOrderDetails?.Any() == true &&
                    order.RentOrder.RentOrderDetails.Count() > 2)
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

                    if (totalQuantity >= LARGE_ORDER_ITEM_THRESHOLD && comboItemCount >= 2)
                    {
                        isLarge = true;
                    }
                }

                return isLarge ? OrderSize.Large : OrderSize.Small;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error estimating size for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<VehicleType> SuggestVehicleTypeAsync(int orderId)
        {
            try
            {
                _logger.LogInformation("Suggesting vehicle type for order {OrderId}", orderId);

                // Estimate order size
                var orderSize = await EstimateOrderSizeAsync(orderId);

                // Suggest vehicle type based on order size
                return orderSize == OrderSize.Large ? VehicleType.Car : VehicleType.Scooter;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error suggesting vehicle type for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<ShippingOrderAllocationDTO> AllocateOrderToStaffWithVehicle(int orderId, int staffId, int? vehicleId = null)
        {
            try
            {
                _logger.LogInformation("Allocating order {OrderId} to staff {StaffId} with vehicle {VehicleId}",
                    orderId, staffId, vehicleId);

                // Check if order exists
                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderId == orderId && !o.IsDelete)
                    .FirstOrDefaultAsync();

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                // Check if staff exists (user with staff role)
                var staff = await _unitOfWork.Repository<User>()
                    .AsQueryable()
                    .Where(u => u.UserId == staffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete)
                    .FirstOrDefaultAsync();

                if (staff == null)
                    throw new NotFoundException($"Staff with ID {staffId} not found");

                // Allow both Preparation and Shipping staff types to deliver
                if (staff.StaffType != StaffType.Preparation && staff.StaffType != StaffType.Shipping)
                    throw new ValidationException($"Staff with ID {staffId} is not authorized for shipping. Staff type: {staff.StaffType}");

                // Check staff availability on current day
                var today = DateTime.Now.DayOfWeek;
                var currentDay = today switch
                {
                    DayOfWeek.Sunday => WorkDays.Sunday,
                    DayOfWeek.Monday => WorkDays.Monday,
                    DayOfWeek.Tuesday => WorkDays.Tuesday,
                    DayOfWeek.Wednesday => WorkDays.Wednesday,
                    DayOfWeek.Thursday => WorkDays.Thursday,
                    DayOfWeek.Friday => WorkDays.Friday,
                    DayOfWeek.Saturday => WorkDays.Saturday,
                    _ => WorkDays.None
                };

                if ((staff.WorkDays & currentDay) == 0)
                {
                    throw new ValidationException($"Staff with ID {staffId} is not available on {today}. Staff works on: {staff.WorkDays}");
                }

                // Estimate order size
                var orderSize = await EstimateOrderSizeAsync(orderId);

                // If no vehicle ID is provided, suggest one based on order size
                if (!vehicleId.HasValue)
                {
                    var suggestedVehicleType = await SuggestVehicleTypeAsync(orderId);

                    // Find an available vehicle of the suggested type
                    var availableVehicle = await _unitOfWork.Repository<Vehicle>()
                        .AsQueryable()
                        .Where(v => v.Type == suggestedVehicleType && v.Status == VehicleStatus.Available && !v.IsDelete)
                        .FirstOrDefaultAsync();

                    if (availableVehicle == null)
                    {
                        // If no vehicle of suggested type is available, try any available vehicle
                        availableVehicle = await _unitOfWork.Repository<Vehicle>()
                            .AsQueryable()
                            .Where(v => v.Status == VehicleStatus.Available && !v.IsDelete)
                            .FirstOrDefaultAsync();

                        if (availableVehicle == null)
                            throw new ValidationException("No vehicles are currently available for delivery");
                    }

                    vehicleId = availableVehicle.VehicleId;
                }
                else
                {
                    // If a specific vehicle ID is provided, check if it exists and is available
                    var vehicle = await _unitOfWork.Repository<Vehicle>()
                        .FindAsync(v => v.VehicleId == vehicleId.Value && !v.IsDelete);

                    if (vehicle == null)
                        throw new NotFoundException($"Vehicle with ID {vehicleId.Value} not found");

                    if (vehicle.Status != VehicleStatus.Available)
                        throw new ValidationException($"Vehicle with ID {vehicleId.Value} is not available (current status: {vehicle.Status})");
                }

                // Check if shipping order already exists
                var existingShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                    .FindAsync(so => so.OrderId == orderId && !so.IsDelete);

                ShippingOrder shippingOrder;
                if (existingShippingOrder != null)
                {
                    _logger.LogInformation("Updating existing shipping order {ShippingOrderId} for order {OrderId}",
                        existingShippingOrder.ShippingOrderId, orderId);

                    // Update existing shipping order
                    existingShippingOrder.StaffId = staffId;
                    existingShippingOrder.VehicleId = vehicleId;
                    existingShippingOrder.OrderSize = orderSize;
                    existingShippingOrder.SetUpdateDate();
                    shippingOrder = existingShippingOrder;
                }
                else
                {
                    _logger.LogInformation("Creating new shipping order for order {OrderId}", orderId);

                    // Create new shipping order
                    shippingOrder = new ShippingOrder
                    {
                        OrderId = orderId,
                        StaffId = staffId,
                        VehicleId = vehicleId,
                        OrderSize = orderSize,
                        IsDelivered = false,
                        CreatedAt = DateTime.UtcNow
                    };
                    _unitOfWork.Repository<ShippingOrder>().Insert(shippingOrder);
                }

                // Update order status to Shipping
                order.Status = OrderStatus.Shipping;
                order.SetUpdateDate();

                // Update vehicle status to InUse
                if (vehicleId.HasValue)
                {
                    var vehicle = await _unitOfWork.Repository<Vehicle>()
                        .FindAsync(v => v.VehicleId == vehicleId.Value);

                    if (vehicle != null)
                    {
                        vehicle.Status = VehicleStatus.InUse;
                        vehicle.SetUpdateDate();
                    }
                }

                // Save all changes
                await _unitOfWork.CommitAsync();

                // Get staff and vehicle details for the response
                var staffDetails = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == staffId);

                var vehicleDetails = vehicleId.HasValue
                    ? await _unitOfWork.Repository<Vehicle>().FindAsync(v => v.VehicleId == vehicleId.Value)
                    : null;

                // Map to DTO
                return new ShippingOrderAllocationDTO
                {
                    ShippingOrderId = shippingOrder.ShippingOrderId,
                    OrderId = shippingOrder.OrderId,
                    OrderCode = order.OrderCode,
                    StaffId = shippingOrder.StaffId,
                    StaffName = staffDetails?.Name ?? string.Empty,
                    VehicleId = shippingOrder.VehicleId,
                    VehicleName = vehicleDetails?.Name ?? string.Empty,
                    VehicleType = vehicleDetails?.Type ?? VehicleType.Scooter,
                    OrderSize = shippingOrder.OrderSize,
                    IsDelivered = shippingOrder.IsDelivered,
                    CreatedAt = shippingOrder.CreatedAt
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error allocating order {OrderId} to staff {StaffId} with vehicle {VehicleId}",
           orderId, staffId, vehicleId);
                throw;
            }
        }

        private WorkDays MapDayOfWeekToWorkDays(DayOfWeek dayOfWeek)
        {
            return dayOfWeek switch
            {
                DayOfWeek.Sunday => WorkDays.Sunday,
                DayOfWeek.Monday => WorkDays.Monday,
                DayOfWeek.Tuesday => WorkDays.Tuesday,
                DayOfWeek.Wednesday => WorkDays.Wednesday,
                DayOfWeek.Thursday => WorkDays.Thursday,
                DayOfWeek.Friday => WorkDays.Friday,
                DayOfWeek.Saturday => WorkDays.Saturday,
                _ => WorkDays.None
            };
        }
    }
}