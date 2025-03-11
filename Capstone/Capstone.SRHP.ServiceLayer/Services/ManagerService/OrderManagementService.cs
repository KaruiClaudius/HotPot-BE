using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
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

        public OrderManagementService(IUnitOfWork unitOfWork, ILogger<OrderManagementService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // Order allocation
        public async Task<ShippingOrder> AllocateOrderToStaff(int orderId, int staffId)
        {
            // Check if order exists
            var order = await _unitOfWork.Repository<Order>()
                .FindAsync(o => o.OrderId == orderId);

            if (order == null)
                throw new KeyNotFoundException($"Order with ID {orderId} not found");

            // Check if staff exists
            var staff = await _unitOfWork.Repository<Staff>()
                .FindAsync(s => s.StaffId == staffId);

            if (staff == null)
                throw new KeyNotFoundException($"Staff with ID {staffId} not found");

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
                throw new InvalidOperationException($"Staff with ID {staffId} is not available on {today}. Staff works on: {staff.WorkDays}");
            }

            // Get staff workload
            var workload = await GetStaffWorkloadById(staffId);

            // Log warning if staff is overloaded
            if (workload.ActiveDeliveries >= 5)
            {
                _logger.LogWarning($"Staff {staffId} ({workload.StaffName}) is already handling {workload.ActiveDeliveries} active deliveries. Consider assigning to someone else.");
            }

            // Check if shipping order already exists
            var existingShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                .FindAsync(so => so.OrderID == orderId);

            if (existingShippingOrder != null)
            {
                // Update existing shipping order
                existingShippingOrder.StaffID = staffId;
                existingShippingOrder.UpdatedAt = DateTime.UtcNow;
                await _unitOfWork.CommitAsync();
                return existingShippingOrder;
            }

            // Create new shipping order
            var shippingOrder = new ShippingOrder
            {
                OrderID = orderId,
                StaffID = staffId,
                IsDelivered = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _unitOfWork.Repository<ShippingOrder>().Insert(shippingOrder);
            await _unitOfWork.CommitAsync();

            return shippingOrder;
        }       

        public async Task<IEnumerable<Order>> GetUnallocatedOrders()
        {
            // Get orders that don't have a shipping order
            var orders = await _unitOfWork.Repository<Order>()
                .GetAll(o => o.ShippingOrder == null && !o.IsDelete)
                .Include(o => o.User)
                .ToListAsync();

            return orders;
        }

        public async Task<IEnumerable<ShippingOrder>> GetOrdersByStaff(int staffId)
        {
            // Check if staff exists
            var staff = await _unitOfWork.Repository<Staff>()
                .FindAsync(s => s.StaffId == staffId);

            if (staff == null)
                throw new KeyNotFoundException($"Staff with ID {staffId} not found");

            // Get all shipping orders for this staff
            var shippingOrders = await _unitOfWork.Repository<ShippingOrder>()
                .GetAll(so => so.StaffID == staffId && !so.IsDelete)
                .Include(so => so.Order)
                .Include(so => so.Staff)
                .ThenInclude(s => s.User)
                .ToListAsync();

            return shippingOrders;
        }

        // Order status tracking
        public async Task<Order> UpdateOrderStatus(int orderId, OrderStatus status)
        {
            var order = await _unitOfWork.Repository<Order>()
                .FindAsync(o => o.OrderId == orderId);

            if (order == null)
                throw new KeyNotFoundException($"Order with ID {orderId} not found");

            order.Status = status;
            order.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();
            return order;
        }

        public async Task<Order> GetOrderWithDetails(int orderId)
        {
            var order = await _unitOfWork.Repository<Order>()
                .AsQueryable(o => o.OrderId == orderId)
                .Include(o => o.User)
                .Include(o => o.ShippingOrder)
                .ThenInclude(so => so.Staff)
                .ThenInclude(s => s.User)
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync();

            if (order == null)
                throw new KeyNotFoundException($"Order with ID {orderId} not found");

            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatus(OrderStatus status)
        {
            var orders = await _unitOfWork.Repository<Order>()
                .GetAll(o => o.Status == status && !o.IsDelete)
                .Include(o => o.User)
                .Include(o => o.ShippingOrder)
                .ToListAsync();

            return orders;
        }

        // Delivery progress monitoring
        public async Task<ShippingOrder> UpdateDeliveryStatus(int shippingOrderId, bool isDelivered, string notes = null)
        {
            var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                .FindAsync(so => so.ShippingOrderId == shippingOrderId);

            if (shippingOrder == null)
                throw new KeyNotFoundException($"Shipping Order with ID {shippingOrderId} not found");

            shippingOrder.IsDelivered = isDelivered;

            if (isDelivered && !shippingOrder.DeliveryTime.HasValue)
                shippingOrder.DeliveryTime = DateTime.UtcNow;

            if (notes != null)
                shippingOrder.DeliveryNotes = notes;

            shippingOrder.UpdatedAt = DateTime.UtcNow;

            // If delivered, update order status as well
            if (isDelivered)
            {
                var order = await _unitOfWork.Repository<Order>()
                    .FindAsync(o => o.OrderId == shippingOrder.OrderID);

                if (order != null)
                {
                    order.Status = OrderStatus.Delivered;
                    order.UpdatedAt = DateTime.UtcNow;
                }
            }

            await _unitOfWork.CommitAsync();
            return shippingOrder;
        }

        public async Task<ShippingOrder> UpdateDeliveryTime(int shippingOrderId, DateTime deliveryTime)
        {
            var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                .FindAsync(so => so.ShippingOrderId == shippingOrderId);

            if (shippingOrder == null)
                throw new KeyNotFoundException($"Shipping Order with ID {shippingOrderId} not found");

            shippingOrder.DeliveryTime = deliveryTime;
            shippingOrder.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitAsync();
            return shippingOrder;
        }

        public async Task<IEnumerable<ShippingOrder>> GetPendingDeliveries()
        {
            var pendingDeliveries = await _unitOfWork.Repository<ShippingOrder>()
                .GetAll(so => !so.IsDelivered && !so.IsDelete)
                .Include(so => so.Order)
                .Include(so => so.Staff)
                .ThenInclude(s => s.User)
                .ToListAsync();

            return pendingDeliveries;
        }

        // Staff workload management
        public async Task<IEnumerable<StaffWorkloadDto>> GetStaffWorkloads()
        {
            // Get all active staff with their user information
            var activeStaffQuery = _unitOfWork.Repository<Staff>()
                .GetAll(s => !s.IsDelete);

            var activeStaff = await activeStaffQuery
                .Include(s => s.User)
                .ToListAsync();

            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);

            var workloads = new List<StaffWorkloadDto>();

            foreach (var staff in activeStaff)
            {
                // Skip if user is deleted
                if (staff.User == null || staff.User.IsDelete)
                    continue;

                // Get active (non-delivered) orders for this staff
                var activeDeliveries = await _unitOfWork.Repository<ShippingOrder>()
                    .CountAsync(so => so.StaffID == staff.StaffId && !so.IsDelivered && !so.IsDelete);

                // Get total deliveries assigned today
                var totalDeliveriesToday = await _unitOfWork.Repository<ShippingOrder>()
                    .CountAsync(so => so.StaffID == staff.StaffId &&
                                     so.CreatedAt >= today &&
                                     so.CreatedAt < tomorrow &&
                                     !so.IsDelete);

                // Get total completed deliveries (historical data)
                var totalCompletedDeliveries = await _unitOfWork.Repository<ShippingOrder>()
                    .CountAsync(so => so.StaffID == staff.StaffId &&
                                     so.IsDelivered &&
                                     !so.IsDelete);

                workloads.Add(new StaffWorkloadDto
                {
                    StaffId = staff.StaffId,
                    StaffName = staff.User?.Name ?? "Unknown",
                    Email = staff.User?.Email ?? "Unknown",
                    PhoneNumber = staff.User?.PhoneNumber ?? "Unknown",
                    ActiveDeliveries = activeDeliveries,
                    TotalDeliveriesToday = totalDeliveriesToday,
                    TotalCompletedDeliveries = totalCompletedDeliveries
                });
            }

            return workloads;
        }

        private async Task<StaffWorkloadDto> GetStaffWorkloadById(int staffId)
        {
            var staff = await _unitOfWork.Repository<Staff>()
                .GetAll(s => s.StaffId == staffId)
                .Include(s => s.User)
                .FirstOrDefaultAsync();

            if (staff == null)
                throw new KeyNotFoundException($"Staff with ID {staffId} not found");

            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);

            // Get active (non-delivered) orders for this staff
            var activeDeliveries = await _unitOfWork.Repository<ShippingOrder>()
                .CountAsync(so => so.StaffID == staffId && !so.IsDelivered && !so.IsDelete);

            // Get total deliveries assigned today
            var totalDeliveriesToday = await _unitOfWork.Repository<ShippingOrder>()
                .CountAsync(so => so.StaffID == staffId &&
                                 so.CreatedAt >= today &&
                                 so.CreatedAt < tomorrow &&
                                 !so.IsDelete);

            // Get total completed deliveries (historical data)
            var totalCompletedDeliveries = await _unitOfWork.Repository<ShippingOrder>()
                .CountAsync(so => so.StaffID == staffId &&
                                 so.IsDelivered &&
                                 !so.IsDelete);

            return new StaffWorkloadDto
            {
                StaffId = staffId,
                StaffName = staff.User?.Name ?? "Unknown",
                Email = staff.User?.Email ?? "Unknown",
                PhoneNumber = staff.User?.PhoneNumber ?? "Unknown",
                ActiveDeliveries = activeDeliveries,
                TotalDeliveriesToday = totalDeliveriesToday,
                TotalCompletedDeliveries = totalCompletedDeliveries
            };
        }

        public async Task<StaffAllocationStatsDto> GetStaffAllocationStats(int staffId)
        {
            // Check if staff exists
            var staff = await _unitOfWork.Repository<Staff>()
                .GetAll(s => s.StaffId == staffId)
                .Include(s => s.User)
                .FirstOrDefaultAsync();

            if (staff == null)
                throw new KeyNotFoundException($"Staff with ID {staffId} not found");

            // Calculate date ranges
            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);
            var weekStart = today.AddDays(-(int)today.DayOfWeek);
            var monthStart = new DateTime(today.Year, today.Month, 1);

            // Get all shipping orders for this staff
            var allShippingOrders = await _unitOfWork.Repository<ShippingOrder>()
                .GetAll(so => so.StaffID == staffId && !so.IsDelete)
                .ToListAsync();

            // Calculate statistics
            var stats = new StaffAllocationStatsDto
            {
                StaffId = staffId,
                StaffName = staff.User?.Name ?? "Unknown",
                Email = staff.User?.Email ?? "Unknown",

                // Current workload
                ActiveDeliveries = allShippingOrders.Count(so => !so.IsDelivered),

                // Historical allocations
                AllocationsToday = allShippingOrders.Count(so => so.CreatedAt >= today && so.CreatedAt < tomorrow),
                AllocationsThisWeek = allShippingOrders.Count(so => so.CreatedAt >= weekStart && so.CreatedAt < tomorrow),
                AllocationsThisMonth = allShippingOrders.Count(so => so.CreatedAt >= monthStart && so.CreatedAt < tomorrow),
                TotalAllocations = allShippingOrders.Count,

                // Completed deliveries
                CompletedToday = allShippingOrders.Count(so => so.IsDelivered && so.DeliveryTime >= today && so.DeliveryTime < tomorrow),
                CompletedThisWeek = allShippingOrders.Count(so => so.IsDelivered && so.DeliveryTime >= weekStart && so.DeliveryTime < tomorrow),
                CompletedThisMonth = allShippingOrders.Count(so => so.IsDelivered && so.DeliveryTime >= monthStart && so.DeliveryTime < tomorrow),
                TotalCompleted = allShippingOrders.Count(so => so.IsDelivered)
            };

            return stats;
        }
        public async Task<IEnumerable<StaffAllocationStatsDto>> GetAllStaffAllocationStats()
        {
            // Get all active staff
            var activeStaff = await _unitOfWork.Repository<Staff>()
                .GetAll(s => !s.IsDelete)
                .Include(s => s.User)
                .ToListAsync();

            var result = new List<StaffAllocationStatsDto>();

            // Calculate date ranges
            var today = DateTime.UtcNow.Date;
            var tomorrow = today.AddDays(1);
            var weekStart = today.AddDays(-(int)today.DayOfWeek);
            var monthStart = new DateTime(today.Year, today.Month, 1);

            // Get all shipping orders (to avoid multiple database queries)
            var allShippingOrders = await _unitOfWork.Repository<ShippingOrder>()
                .GetAll(so => !so.IsDelete)
                .ToListAsync();

            foreach (var staff in activeStaff)
            {
                // Skip if user is deleted
                if (staff.User == null || staff.User.IsDelete)
                    continue;

                // Filter shipping orders for this staff
                var staffOrders = allShippingOrders.Where(so => so.StaffID == staff.StaffId).ToList();

                // Calculate statistics
                var stats = new StaffAllocationStatsDto
                {
                    StaffId = staff.StaffId,
                    StaffName = staff.User?.Name ?? "Unknown",
                    Email = staff.User?.Email ?? "Unknown",

                    // Current workload
                    ActiveDeliveries = staffOrders.Count(so => !so.IsDelivered),

                    // Historical allocations
                    AllocationsToday = staffOrders.Count(so => so.CreatedAt >= today && so.CreatedAt < tomorrow),
                    AllocationsThisWeek = staffOrders.Count(so => so.CreatedAt >= weekStart && so.CreatedAt < tomorrow),
                    AllocationsThisMonth = staffOrders.Count(so => so.CreatedAt >= monthStart && so.CreatedAt < tomorrow),
                    TotalAllocations = staffOrders.Count,

                    // Completed deliveries
                    CompletedToday = staffOrders.Count(so => so.IsDelivered && so.DeliveryTime.HasValue && so.DeliveryTime >= today && so.DeliveryTime < tomorrow),
                    CompletedThisWeek = staffOrders.Count(so => so.IsDelivered && so.DeliveryTime.HasValue && so.DeliveryTime >= weekStart && so.DeliveryTime < tomorrow),
                    CompletedThisMonth = staffOrders.Count(so => so.IsDelivered && so.DeliveryTime.HasValue && so.DeliveryTime >= monthStart && so.DeliveryTime < tomorrow),
                    TotalCompleted = staffOrders.Count(so => so.IsDelivered)
                };

                result.Add(stats);
            }

            return result;
        }
    }
}