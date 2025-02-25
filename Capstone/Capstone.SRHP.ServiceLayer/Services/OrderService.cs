
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _unitOfWork.Repository<Order>()
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .Include(o => o.Payment)
                .Where(o => !o.IsDelete)
                .ToListAsync();
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.Repository<Order>()
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                .Include(o => o.Payment)
                .Include(o => o.Discount)
                .FirstOrDefaultAsync(o => o.OrderId == id && !o.IsDelete);

            if (order == null)
                throw new NotFoundException($"Order with ID {id} not found");

            return order;
        }

        public async Task<Order> CreateAsync(Order entity)
        {
            // Validate basic properties
            if (string.IsNullOrWhiteSpace(entity.Address))
                throw new ValidationException("Delivery address cannot be empty");

            if (entity.TotalPrice < 0)
                throw new ValidationException("Total price cannot be negative");

            // Validate User exists
            var user = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.UserId == entity.UserID && !u.IsDelete);
            if (user == null)
                throw new ValidationException("User not found");

            // Validate Discount if provided
            if (entity.DiscountID.HasValue)
            {
                var discount = await _unitOfWork.Repository<Discount>()
                    .FindAsync(d => d.DiscountId == entity.DiscountID && !d.IsDelete);
                if (discount == null)
                    throw new ValidationException("Invalid discount");

                // Validate discount is still valid
                if (DateTime.UtcNow < discount.Date || DateTime.UtcNow > discount.Duration)
                    throw new ValidationException("Discount is not valid at this time");
            }

            // Check for existing pending order
            var existingOrder = await _unitOfWork.Repository<Order>()
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o =>
                    o.UserID == entity.UserID &&
                    o.Status == OrderStatus.Pending);

            if (existingOrder != null)
            {
                if (!existingOrder.IsDelete)
                {
                    throw new ValidationException("User already has a pending order");
                }
                else
                {
                    // Reactivate and update the soft-deleted order
                    existingOrder.IsDelete = false;
                    existingOrder.Address = entity.Address;
                    existingOrder.Notes = entity.Notes;
                    existingOrder.TotalPrice = entity.TotalPrice;
                    existingOrder.Status = OrderStatus.Pending;
                    existingOrder.DiscountID = entity.DiscountID;

                    // Handle OrderDetails
                    existingOrder.OrderDetails.Clear();
                    foreach (var detail in entity.OrderDetails)
                    {
                        existingOrder.OrderDetails.Add(detail);
                    }

                    existingOrder.SetUpdateDate();
                    await _unitOfWork.CommitAsync();
                    return existingOrder;
                }
            }

            // Set initial status
            entity.Status = OrderStatus.Pending;

            // Initialize collections
            entity.OrderDetails ??= new List<OrderDetail>();

            _unitOfWork.Repository<Order>().Insert(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task UpdateAsync(int id, Order entity)
        {
            var existingOrder = await GetByIdAsync(id);

            if (existingOrder == null)
                throw new NotFoundException($"Order with ID {id} not found");

            entity.SetUpdateDate();
            await _unitOfWork.Repository<Order>().Update(entity, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);

            if (order == null)
                throw new NotFoundException($"Order with ID {id} not found");

            order.SoftDelete();
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(int userId)
        {
            return await _unitOfWork.Repository<Order>()
                .Include(o => o.OrderDetails)
                .Include(o => o.Payment)
                .Where(o => o.UserID == userId && !o.IsDelete)
                .ToListAsync();
        }

        public async Task<Order> UpdateStatusAsync(int id, OrderStatus status)
        {
            var order = await GetByIdAsync(id);

            if (order == null)
                throw new NotFoundException($"Order with ID {id} not found");

            order.Status = status;
            order.SetUpdateDate();

            await _unitOfWork.CommitAsync();
            return order;
        }

        public async Task<decimal> CalculateTotalPriceAsync(ICollection<OrderDetail> orderDetails, int? discountId)
        {

            decimal total = 0;

            foreach (var detail in orderDetails)
            {
                total += detail.Quantity * detail.UnitPrice;
            }

            if (discountId.HasValue)
            {
                var discount = await _unitOfWork.Repository<Discount>()
                    .FindAsync(d => d.DiscountId == discountId && !d.IsDelete);
                if (discount != null)
                {
                    total -= total * (decimal)(discount.Percent / 100.0);
                }
            }

            return total;
        }

        public async Task UpdateOrderStatusAsync(int orderId, OrderStatus newStatus)
        {
            var order = await _unitOfWork.Repository<Order>()
                .FindAsync(o => o.OrderId == orderId && !o.IsDelete);

            if (order == null)
                throw new NotFoundException($"Order with ID {orderId} not found");

            // Validate status transition
            ValidateStatusTransition(order.Status, newStatus);

            order.Status = newStatus;
            order.SetUpdateDate();
            await _unitOfWork.CommitAsync();
        }

        private void ValidateStatusTransition(OrderStatus currentStatus, OrderStatus newStatus)
        {
            // Add your status transition rules here
            switch (currentStatus)
            {
                case OrderStatus.Pending:
                    if (newStatus != OrderStatus.Processing && newStatus != OrderStatus.Cancelled)
                        throw new ValidationException("Invalid status transition");
                    break;
                case OrderStatus.Processing:
                    if (newStatus != OrderStatus.Shipping && newStatus != OrderStatus.Cancelled)
                        throw new ValidationException("Invalid status transition");
                    break;
                case OrderStatus.Shipping:
                    if (newStatus != OrderStatus.Delivered && newStatus != OrderStatus.Cancelled)
                        throw new ValidationException("Invalid status transition");
                    break;
                case OrderStatus.Delivered:
                case OrderStatus.Cancelled:
                    throw new ValidationException("Cannot change status of completed or cancelled orders");
            }
        }
    }
}
