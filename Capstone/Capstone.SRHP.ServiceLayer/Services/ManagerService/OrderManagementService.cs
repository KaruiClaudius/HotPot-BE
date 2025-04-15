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
        public async Task<ShippingOrderAllocationDTO> AllocateOrderToStaff(int orderId, int staffId)
        {
            try
            {
                _logger.LogInformation("Allocating order {OrderId} to staff {StaffId}", orderId, staffId);

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

                // Get current day of week and convert to WorkDays enum value
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

                // Check if staff is available on the current day
                if ((staff.WorkDays & currentDay) == 0)
                {
                    throw new ValidationException($"Staff with ID {staffId} is not available on {today}. Staff works on: {staff.WorkDays}");
                }

                // Check if shipping order already exists
                var existingShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                    .FindAsync(so => so.OrderId == orderId && !so.IsDelete);

                ShippingOrder shippingOrder;

                if (existingShippingOrder != null)
                {
                    _logger.LogInformation("Updating existing shipping order {ShippingOrderId} for order {OrderId}", existingShippingOrder.ShippingOrderId, orderId);

                    // Update existing shipping order
                    existingShippingOrder.StaffId = staffId;
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
                        IsDelivered = false,
                        CreatedAt = DateTime.UtcNow
                    };

                    _unitOfWork.Repository<ShippingOrder>().Insert(shippingOrder);
                }

                // Update order status to Processing
                order.Status = OrderStatus.Processing;
                order.SetUpdateDate();

                // Save all changes
                await _unitOfWork.CommitAsync();

                // Map to DTO
                return new ShippingOrderAllocationDTO
                {
                    ShippingOrderId = shippingOrder.ShippingOrderId,
                    OrderId = shippingOrder.OrderId,
                    OrderCode = shippingOrder.Order.OrderCode,
                    StaffId = shippingOrder.StaffId,
                    StaffName = staff.Name,
                    IsDelivered = shippingOrder.IsDelivered,
                    CreatedAt = shippingOrder.CreatedAt
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error allocating order {OrderId} to staff {StaffId}", orderId, staffId);
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
                    DeliveryTime = so.DeliveryTime,
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

                //var order = await _unitOfWork.Repository<Order>()
                //    .AsQueryable()
                //    .Where(o => o.OrderCode.Equals(orderId) && !o.IsDelete)
                //    .Include(o => o.User)
                //    .Include(o => o.ShippingOrder)
                //        .ThenInclude(so => so.Staff)
                //    .Include(o => o.SellOrder.SellOrderDetails)
                //        .ThenInclude(od => od.Ingredient)
                //    .Include(o => o.SellOrder.SellOrderDetails)
                //        .ThenInclude(od => od.Customization)
                //    .Include(o => o.SellOrder.SellOrderDetails)
                //        .ThenInclude(od => od.Combo)
                //    .Include(o => o.SellOrder.SellOrderDetails)
                //        .ThenInclude(rd => rd.Utensil)
                //    .Include(o => o.RentOrder.RentOrderDetails)
                //        .ThenInclude(rd => rd.HotpotInventory)
                //            .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                //    .FirstOrDefaultAsync();

                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderCode.Equals(orderId) && !o.IsDelete)
                    .Include(o => o.User)
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so.Staff)
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

                    // Shipping information
                    ShippingInfo = order.ShippingOrder != null ? new ShippingDetailDTO
                    {
                        ShippingOrderId = order.ShippingOrder.ShippingOrderId,
                        StaffId = order.ShippingOrder.StaffId,
                        StaffName = order.ShippingOrder.Staff?.Name ?? string.Empty,
                        DeliveryTime = order.ShippingOrder.DeliveryTime,
                        DeliveryNotes = order.ShippingOrder.DeliveryNotes ?? string.Empty,
                        IsDelivered = order.ShippingOrder.IsDelivered
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
                            //UnitPrice = detail.UnitPrice,
                            //TotalPrice = detail.UnitPrice * detail.Quantity
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
                        ActualReturnDate = order.RentOrder.ActualReturnDate,
                        LateFee = order.RentOrder.LateFee,
                        DamageFee = order.RentOrder.DamageFee,
                        RentalNotes = order.RentOrder.RentalNotes,
                        ReturnCondition = order.RentOrder.ReturnCondition
                    };

                    foreach (var detail in order.RentOrder.RentOrderDetails)
                    {
                        if (detail.HotpotInventory != null)
                        {
                            var orderItem = new OrderItemDTO
                            {
                                OrderDetailId = detail.RentOrderDetailId,
                                Quantity = detail.Quantity,
                                //UnitPrice = detail.RentalPrice,
                                //TotalPrice = detail.RentalPrice * detail.Quantity,
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

                if (isDelivered && !shippingOrder.DeliveryTime.HasValue)
                    shippingOrder.DeliveryTime = DateTime.UtcNow;

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
                    DeliveryTime = shippingOrder.DeliveryTime,
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

                shippingOrder.DeliveryTime = deliveryTime;
                shippingOrder.SetUpdateDate();

                await _unitOfWork.CommitAsync();

                // Check if Order is null before accessing its properties
                string orderCode = shippingOrder.Order?.OrderCode ?? "N/A";

                // Map to DTO
                return new DeliveryTimeUpdateDTO
                {
                    ShippingOrderId = shippingOrder.ShippingOrderId,
                    OrderId = shippingOrder.OrderId,
                    OrderCode = orderCode,
                    DeliveryTime = shippingOrder.DeliveryTime ?? DateTime.UtcNow,
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
                    .GetAll(o => o.ShippingOrder == null && !o.IsDelete)
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
                        OrderCode= o.OrderCode,
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
                        .ThenInclude(o => o.User);

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
                        DeliveryTime = so.DeliveryTime,
                        DeliveryNotes = so.DeliveryNotes ?? string.Empty,

                        // Order information
                        Address = so.Order?.Address ?? string.Empty,
                        Notes = so.Order?.Notes ?? string.Empty,
                        TotalPrice = so.Order?.TotalPrice ?? 0,
                        Status = so.Order?.Status ?? OrderStatus.Pending, // Assuming OrderStatus.Pending is the default

                        // Customer information
                        UserId = so.Order?.UserId ?? 0,
                        UserName = so.Order?.User?.Name ?? string.Empty
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
                            DeliveryTime = o.ShippingOrder.DeliveryTime,
                            IsDelivered = o.ShippingOrder.IsDelivered,
                            DeliveryNotes = o.ShippingOrder.DeliveryNotes ?? string.Empty,
                            Staff = o.ShippingOrder.Staff != null ? new StaffDTO
                            {
                                StaffId = o.ShippingOrder.Staff.UserId,
                                Name = o.ShippingOrder.Staff.Name
                            } : null
                        } : null,                      
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

        public async Task<OrderCountsDTO> GetOrderCountsByStatus()
        {
            try
            {
                _logger.LogInformation("Getting order counts by status");

                // Get repository for orders
                var orderRepository = _unitOfWork.Repository<Order>();

                // Query to count orders grouped by status
                var statusCounts = await orderRepository.AsQueryable()
                    .Where(o => !o.IsDelete)
                    .GroupBy(o => o.Status)
                    .Select(g => new { Status = g.Key, Count = g.Count() })
                    .ToDictionaryAsync(x => x.Status, x => x.Count);

                // Create the DTO with counts for each status
                var result = new OrderCountsDTO
                {
                    PendingCount = statusCounts.GetValueOrDefault(OrderStatus.Pending, 0),
                    ProcessingCount = statusCounts.GetValueOrDefault(OrderStatus.Processing, 0),
                    ShippedCount = statusCounts.GetValueOrDefault(OrderStatus.Shipping, 0),
                    DeliveredCount = statusCounts.GetValueOrDefault(OrderStatus.Delivered, 0),
                    CancelledCount = statusCounts.GetValueOrDefault(OrderStatus.Cancelled, 0),
                    ReturningCount = statusCounts.GetValueOrDefault(OrderStatus.Returning, 0),
                    CompletedCount = statusCounts.GetValueOrDefault(OrderStatus.Completed, 0)
                };

                // Calculate total count
                result.TotalCount = result.PendingCount + result.ProcessingCount +
                                   result.ShippedCount + result.DeliveredCount +
                                   result.CancelledCount + result.ReturningCount +
                                   result.CompletedCount;

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting order counts by status");
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

                // Rule 1: If order has rental items, it's considered large
                if (order.HasRentItems && order.RentOrder?.RentOrderDetails?.Any() == true)
                {
                    isLarge = true;
                }

                // Rule 2: If order has more than X sell items, it's considered large
                const int LARGE_ORDER_ITEM_THRESHOLD = 10; // Adjust based on business needs
                if (order.HasSellItems &&
                    order.SellOrder?.SellOrderDetails?.Sum(d => d.Quantity) >= LARGE_ORDER_ITEM_THRESHOLD)
                {
                    isLarge = true;
                }

                //// Rule 3: If total price exceeds a threshold, consider it large
                //const decimal LARGE_ORDER_PRICE_THRESHOLD = 500; // Adjust based on business needs
                //if (order.TotalPrice >= LARGE_ORDER_PRICE_THRESHOLD)
                //{
                //    isLarge = true;
                //}

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

                // Update order status to Processing
                order.Status = OrderStatus.Processing;
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

    }
}