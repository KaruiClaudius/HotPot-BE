using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Services.ManagerService
{
     public class OrderManagementService : IOrderManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            // Check if shipping order already exists
            var existingShippingOrder = await _unitOfWork.Repository<ShippingOrder>()
                .FindAsync(so => so.OrderID == orderId);

            if (existingShippingOrder != null)
            {
                // Update existing shipping order
                existingShippingOrder.StaffID = staffId;
                await _unitOfWork.CommitAsync();
                return existingShippingOrder;
            }

            // Create new shipping order
            var shippingOrder = new ShippingOrder
            {
                OrderID = orderId,
                StaffID = staffId,
                IsDelivered = false,
                CreatedAt = DateTime.UtcNow
            };

            _unitOfWork.Repository<ShippingOrder>().Insert(shippingOrder);
            await _unitOfWork.CommitAsync();

            return shippingOrder;
        }

        public async Task<IEnumerable<Order>> GetUnallocatedOrders()
        {
            // Get orders that don't have a shipping order
            var orders = await _unitOfWork.Repository<Order>()
                .GetAll(o => o.ShippingOrder == null)
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
                .GetAll(so => so.StaffID == staffId)
                .Include(so => so.Order)
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
                .GetAll(o => o.Status == status)
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
                .GetAll(so => !so.IsDelivered)
                .Include(so => so.Order)
                .Include(so => so.Staff)
                .ThenInclude(s => s.User)
                .ToListAsync();

            return pendingDeliveries;
        }
    }
}
