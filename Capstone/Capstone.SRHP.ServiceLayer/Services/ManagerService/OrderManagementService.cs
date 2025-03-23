using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
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
        public async Task<ShippingOrder> AllocateOrderToStaff(int orderId, int staffId)
        {
            try
            {
                _logger.LogInformation("Allocating order {OrderId} to staff {StaffId}", orderId, staffId);

                // Check if order exists
                var order = await _unitOfWork.Repository<Order>()
                    .FindAsync(o => o.OrderId == orderId && !o.IsDelete);

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

                if (existingShippingOrder != null)
                {
                    _logger.LogInformation("Updating existing shipping order {ShippingOrderId} for order {OrderId}", existingShippingOrder.ShippingOrderId, orderId);

                    // Update existing shipping order
                    existingShippingOrder.StaffId = staffId;
                    existingShippingOrder.SetUpdateDate();
                    await _unitOfWork.CommitAsync();
                    return existingShippingOrder;
                }

                _logger.LogInformation("Creating new shipping order for order {OrderId}", orderId);

                // Create new shipping order
                var shippingOrder = new ShippingOrder
                {
                    OrderId = orderId,
                    StaffId = staffId,
                    IsDelivered = false,
                    CreatedAt = DateTime.UtcNow
                };

                _unitOfWork.Repository<ShippingOrder>().Insert(shippingOrder);
                await _unitOfWork.CommitAsync();

                return shippingOrder;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error allocating order {OrderId} to staff {StaffId}", orderId, staffId);
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetUnallocatedOrders()
        {
            try
            {
                _logger.LogInformation("Getting unallocated orders");

                // Get orders that don't have a shipping order
                var orders = await _unitOfWork.Repository<Order>()
                    .GetAll(o => o.ShippingOrder == null && !o.IsDelete)
                    .Include(o => o.User)
                    .Include(o => o.SellOrder.SellOrderDetails)
                    .Include(o => o.RentOrder.RentOrderDetails)
                    .ToListAsync();

                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting unallocated orders");
                throw;
            }
        }

        public async Task<IEnumerable<ShippingOrder>> GetOrdersByStaff(int staffId)
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

                return shippingOrders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting orders for staff {StaffId}", staffId);
                throw;
            }
        }

        // Order status tracking
        public async Task<Order> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            try
            {
                _logger.LogInformation("Updating order {OrderId} status to {Status}", orderId, status);

                var order = await _unitOfWork.Repository<Order>()
                    .FindAsync(o => o.OrderId == orderId && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                order.Status = status;
                order.SetUpdateDate();

                await _unitOfWork.CommitAsync();
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order {OrderId} status to {Status}", orderId, status);
                throw;
            }
        }

        public async Task<Order> GetOrderWithDetails(int orderId)
        {
            try
            {
                _logger.LogInformation("Getting order details for order {OrderId}", orderId);

                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.OrderId == orderId && !o.IsDelete)
                    .Include(o => o.User)
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so.Staff)
                    .Include(o => o.SellOrder.SellOrderDetails)
                        .ThenInclude(od => od.Ingredient)
                    .Include(o => o.SellOrder.SellOrderDetails)
                        .ThenInclude(od => od.Customization)
                    .Include(o => o.SellOrder.SellOrderDetails)
                        .ThenInclude(od => od.Combo)
                    .Include(o => o.RentOrder.RentOrderDetails)
                        .ThenInclude(rd => rd.Utensil)
                    .Include(o => o.RentOrder.RentOrderDetails)
                        .ThenInclude(rd => rd.HotpotInventory)
                            .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .FirstOrDefaultAsync();

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting order details for order {OrderId}", orderId);
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatus(OrderStatus status)
        {
            try
            {
                _logger.LogInformation("Getting orders with status {Status}", status);

                var orders = await _unitOfWork.Repository<Order>()
                    .GetAll(o => o.Status == status && !o.IsDelete)
                    .Include(o => o.User)
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so.Staff)
                    .Include(o => o.SellOrder.SellOrderDetails)
                    .Include(o => o.RentOrder.RentOrderDetails)
                    .ToListAsync();

                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting orders with status {Status}", status);
                throw;
            }
        }

        // Delivery progress monitoring
        public async Task<ShippingOrder> UpdateDeliveryStatus(int shippingOrderId, bool isDelivered, string notes = null)
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
                return shippingOrder;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating delivery status for shipping order {ShippingOrderId}", shippingOrderId);
                throw;
            }
        }

        public async Task<ShippingOrder> UpdateDeliveryTime(int shippingOrderId, DateTime deliveryTime)
        {
            try
            {
                _logger.LogInformation("Updating delivery time for shipping order {ShippingOrderId} to {DeliveryTime}", shippingOrderId, deliveryTime);

                var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                    .FindAsync(so => so.ShippingOrderId == shippingOrderId && !so.IsDelete);

                if (shippingOrder == null)
                    throw new NotFoundException($"Shipping Order with ID {shippingOrderId} not found");

                shippingOrder.DeliveryTime = deliveryTime;
                shippingOrder.SetUpdateDate();

                await _unitOfWork.CommitAsync();
                return shippingOrder;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating delivery time for shipping order {ShippingOrderId}", shippingOrderId);
                throw;
            }
        }

        public async Task<IEnumerable<ShippingOrder>> GetPendingDeliveries()
        {
            try
            {
                _logger.LogInformation("Getting pending deliveries");

                var pendingDeliveries = await _unitOfWork.Repository<ShippingOrder>()
                    .GetAll(so => !so.IsDelivered && !so.IsDelete)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.User)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.SellOrder.SellOrderDetails)
                    .Include(so => so.Order)
                        .ThenInclude(o => o.RentOrder.RentOrderDetails)
                    .Include(so => so.Staff)
                    .ToListAsync();

                return pendingDeliveries;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting pending deliveries");
                throw;
            }
        }

        // New method to get all staff available for delivery
        public async Task<IEnumerable<User>> GetAvailableStaffForDelivery()
        {
            try
            {
                _logger.LogInformation("Getting available staff for delivery");

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

                // Get all staff users who are available today
                var availableStaff = await _unitOfWork.Repository<User>()
                    .GetAll(u => u.RoleId == STAFF_ROLE_ID &&
                                 (u.WorkDays & currentDay) != 0 &&
                                 !u.IsDelete)
                    .ToListAsync();

                return availableStaff;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting available staff for delivery");
                throw;
            }
        }       
        // New method to get orders with both sell and rent details
        public async Task<IEnumerable<Order>> GetOrdersWithAllDetails(DateTime startDate, DateTime endDate, OrderStatus? status = null)
        {
            try
            {
                _logger.LogInformation("Getting orders with all details from {StartDate} to {EndDate} with status {Status}",
                    startDate, endDate, status);

                // Add one day to include the end date fully
                var endDatePlusOne = endDate.AddDays(1);

                // Build the query
                var query = _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Where(o => o.CreatedAt >= startDate &&
                                o.CreatedAt < endDatePlusOne &&
                                !o.IsDelete);

                // Apply status filter if provided
                if (status.HasValue)
                {
                    query = query.Where(o => o.Status == status.Value);
                }

                // Include related entities
                var orders = await query
                    .Include(o => o.User)
                    .Include(o => o.ShippingOrder)
                        .ThenInclude(so => so != null ? so.Staff : null)
                    .Include(o => o.SellOrder.SellOrderDetails)
                        .ThenInclude(od => od.Ingredient)
                    .Include(o => o.SellOrder.SellOrderDetails)
                        .ThenInclude(od => od.Customization)
                    .Include(o => o.SellOrder.SellOrderDetails)
                        .ThenInclude(od => od.Combo)
                    .Include(o => o.RentOrder.RentOrderDetails)
                        .ThenInclude(rd => rd.Utensil)
                    .Include(o => o.RentOrder.RentOrderDetails)
                        .ThenInclude(rd => rd.HotpotInventory)
                            .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .OrderByDescending(o => o.CreatedAt)
                    .ToListAsync();

                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting orders with all details");
                throw;
            }
        }

        // New method to reassign a shipping order to a different staff
        public async Task<ShippingOrder> ReassignShippingOrder(int shippingOrderId, int newStaffId)
        {
            try
            {
                _logger.LogInformation("Reassigning shipping order {ShippingOrderId} to staff {StaffId}",
                    shippingOrderId, newStaffId);

                // Check if shipping order exists
                var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                    .FindAsync(so => so.ShippingOrderId == shippingOrderId && !so.IsDelete);

                if (shippingOrder == null)
                    throw new NotFoundException($"Shipping Order with ID {shippingOrderId} not found");

                // Check if new staff exists (user with staff role)
                var newStaff = await _unitOfWork.Repository<User>()
                    .FindAsync(u => u.UserId == newStaffId && u.RoleId == STAFF_ROLE_ID && !u.IsDelete);

                if (newStaff == null)
                    throw new NotFoundException($"Staff with ID {newStaffId} not found");

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

                // Check if new staff is available on the current day
                if ((newStaff.WorkDays & currentDay) == 0)
                {
                    throw new ValidationException($"Staff with ID {newStaffId} is not available on {today}. Staff works on: {newStaff.WorkDays}");
                }

                // Update shipping order
                shippingOrder.StaffId = newStaffId;
                shippingOrder.SetUpdateDate();

                await _unitOfWork.CommitAsync();

                // Load related entities for the response
                shippingOrder.Staff = newStaff;
                shippingOrder.Order = await _unitOfWork.Repository<Order>()
                    .FindAsync(o => o.OrderId == shippingOrder.OrderId && !o.IsDelete);

                return shippingOrder;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error reassigning shipping order {ShippingOrderId} to staff {StaffId}",
                    shippingOrderId, newStaffId);
                throw;
            }
        }
    }
}