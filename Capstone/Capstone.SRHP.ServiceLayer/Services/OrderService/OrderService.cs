using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.HPTY.ServiceLayer.Services.OrderService
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
                    .ThenInclude(od => od.Utensil)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Ingredient)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Hotpot)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Customization)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Combo)
                .Include(o => o.Payment)
                .Include(o => o.Discount)
                .Where(o => !o.IsDelete)
                .ToListAsync();
        }

        public async Task<PagedResult<Order>> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            var query = _unitOfWork.Repository<Order>()
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Utensil)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Ingredient)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Hotpot)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Customization)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Combo)
                .Include(o => o.Payment)
                .Include(o => o.Discount)
                .Where(o => !o.IsDelete);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(o => o.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Order>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Order?> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.Repository<Order>()
                .Include(o => o.User)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Utensil)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Ingredient)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Hotpot)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Customization)
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Combo)
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

                    // Remove existing order details
                    var existingDetails = await _unitOfWork.Repository<OrderDetail>()
                        .FindAll(od => od.OrderID == existingOrder.OrderId)
                        .ToListAsync();

                    foreach (var detail in existingDetails)
                    {
                        detail.SoftDelete();
                    }

                    // Add new order details
                    foreach (var detail in entity.OrderDetails)
                    {
                        detail.OrderID = existingOrder.OrderId;
                        _unitOfWork.Repository<OrderDetail>().Insert(detail);
                    }

                    existingOrder.SetUpdateDate();
                    await _unitOfWork.CommitAsync();
                    return existingOrder;
                }
            }

            // Set initial status
            entity.Status = OrderStatus.Pending;

            // Create the order first
            _unitOfWork.Repository<Order>().Insert(entity);
            await _unitOfWork.CommitAsync();

            // Now add order details with the correct OrderID
            if (entity.OrderDetails != null && entity.OrderDetails.Any())
            {
                foreach (var detail in entity.OrderDetails)
                {
                    detail.OrderID = entity.OrderId;
                    _unitOfWork.Repository<OrderDetail>().Insert(detail);
                }
                await _unitOfWork.CommitAsync();
            }

            return entity;
        }

        public async Task UpdateAsync(int id, Order entity)
        {
            var existingOrder = await GetByIdAsync(id);

            if (existingOrder == null)
                throw new NotFoundException($"Order with ID {id} not found");

            // Update order properties
            existingOrder.Address = entity.Address;
            existingOrder.Notes = entity.Notes;
            existingOrder.TotalPrice = entity.TotalPrice;
            existingOrder.Status = entity.Status;
            existingOrder.DiscountID = entity.DiscountID;
            existingOrder.PaymentID = entity.PaymentID;
            existingOrder.SetUpdateDate();

            // Handle order details if they've changed
            if (entity.OrderDetails != null)
            {
                // Get existing order details
                var existingDetails = await _unitOfWork.Repository<OrderDetail>()
                    .FindAll(od => od.OrderID == id && !od.IsDelete)
                    .ToListAsync();

                // Identify details to delete (those in existing but not in updated)
                var detailsToDelete = existingDetails
                    .Where(ed => !entity.OrderDetails.Any(nd => nd.OrderDetailId == ed.OrderDetailId))
                    .ToList();

                // Soft delete removed details
                foreach (var detail in detailsToDelete)
                {
                    detail.SoftDelete();
                    await _unitOfWork.Repository<OrderDetail>().Update(detail, detail.OrderDetailId);
                }

                // Update existing details and add new ones
                foreach (var detail in entity.OrderDetails)
                {
                    if (detail.OrderDetailId > 0)
                    {
                        // Update existing detail
                        var existingDetail = existingDetails.FirstOrDefault(ed => ed.OrderDetailId == detail.OrderDetailId);
                        if (existingDetail != null)
                        {
                            existingDetail.Quantity = detail.Quantity;
                            existingDetail.UnitPrice = detail.UnitPrice;
                            existingDetail.UtensilID = detail.UtensilID;
                            existingDetail.IngredientID = detail.IngredientID;
                            existingDetail.HotpotID = detail.HotpotID;
                            existingDetail.CustomizationID = detail.CustomizationID;
                            existingDetail.ComboID = detail.ComboID;
                            existingDetail.SetUpdateDate();

                            await _unitOfWork.Repository<OrderDetail>().Update(existingDetail, existingDetail.OrderDetailId);
                        }
                    }
                    else
                    {
                        // Add new detail
                        detail.OrderID = id;
                        _unitOfWork.Repository<OrderDetail>().Insert(detail);
                    }
                }
            }

            await _unitOfWork.Repository<Order>().Update(existingOrder, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await GetByIdAsync(id);

            if (order == null)
                throw new NotFoundException($"Order with ID {id} not found");

            // Soft delete order details first
            var orderDetails = await _unitOfWork.Repository<OrderDetail>()
                .FindAll(od => od.OrderID == id && !od.IsDelete)
                .ToListAsync();

            foreach (var detail in orderDetails)
            {
                detail.SoftDelete();
                await _unitOfWork.Repository<OrderDetail>().Update(detail, detail.OrderDetailId);
            }

            // Then soft delete the order
            order.SoftDelete();
            await _unitOfWork.Repository<Order>().Update(order, id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<PagedResult<Order>> GetUserOrdersPagedAsync(int userId, int pageNumber, int pageSize)
        {
            // First get the orders with basic includes
            var query = _unitOfWork.Repository<Order>()
                .Include(o => o.OrderDetails)
                .Include(o => o.Payment)
                .Include(o => o.Discount)
                .Where(o => o.UserID == userId && !o.IsDelete);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(o => o.CreatedAt)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Then load the related entities for each order detail
            foreach (var order in items)
            {
                foreach (var detail in order.OrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.UtensilID.HasValue)
                    {
                        detail.Utensil = await _unitOfWork.Repository<Utensil>()
                            .FindAsync(u => u.UtensilId == detail.UtensilID && !u.IsDelete);
                    }
                    if (detail.IngredientID.HasValue)
                    {
                        detail.Ingredient = await _unitOfWork.Repository<Ingredient>()
                            .FindAsync(i => i.IngredientId == detail.IngredientID && !i.IsDelete);
                    }
                    if (detail.HotpotID.HasValue)
                    {
                        detail.Hotpot = await _unitOfWork.Repository<Hotpot>()
                            .FindAsync(h => h.HotpotId == detail.HotpotID && !h.IsDelete);
                    }
                    if (detail.CustomizationID.HasValue)
                    {
                        detail.Customization = await _unitOfWork.Repository<Customization>()
                            .FindAsync(c => c.CustomizationId == detail.CustomizationID && !c.IsDelete);
                    }
                    if (detail.ComboID.HasValue)
                    {
                        detail.Combo = await _unitOfWork.Repository<Combo>()
                            .FindAsync(c => c.ComboId == detail.ComboID && !c.IsDelete);
                    }
                }
            }

            return new PagedResult<Order>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(int userId)
        {
            // First get the orders
            var orders = await _unitOfWork.Repository<Order>()
                .Include(o => o.OrderDetails)
                .Include(o => o.Payment)
                .Include(o => o.Discount)
                .Where(o => o.UserID == userId && !o.IsDelete)
                .ToListAsync();

            // Then load the related entities for each order detail
            foreach (var order in orders)
            {
                foreach (var detail in order.OrderDetails)
                {
                    if (detail.UtensilID.HasValue)
                    {
                        detail.Utensil = await _unitOfWork.Repository<Utensil>()
                            .FindAsync(u => u.UtensilId == detail.UtensilID);
                    }
                    if (detail.IngredientID.HasValue)
                    {
                        detail.Ingredient = await _unitOfWork.Repository<Ingredient>()
                            .FindAsync(i => i.IngredientId == detail.IngredientID);
                    }
                    if (detail.HotpotID.HasValue)
                    {
                        detail.Hotpot = await _unitOfWork.Repository<Hotpot>()
                            .FindAsync(h => h.HotpotId == detail.HotpotID);
                    }
                    if (detail.CustomizationID.HasValue)
                    {
                        detail.Customization = await _unitOfWork.Repository<Customization>()
                            .FindAsync(c => c.CustomizationId == detail.CustomizationID);
                    }
                    if (detail.ComboID.HasValue)
                    {
                        detail.Combo = await _unitOfWork.Repository<Combo>()
                            .FindAsync(c => c.ComboId == detail.ComboID);
                    }
                }
            }

            return orders;
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

            await _unitOfWork.Repository<Order>().Update(order, orderId);
            await _unitOfWork.CommitAsync();
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

        public async Task<Order> UpdateStatusAsync(int id, OrderStatus status)
        {
            var order = await GetByIdAsync(id);

            if (order == null)
                throw new NotFoundException($"Order with ID {id} not found");

            // Validate status transition
            ValidateStatusTransition(order.Status, status);

            order.Status = status;
            order.SetUpdateDate();

            await _unitOfWork.Repository<Order>().Update(order, id);
            await _unitOfWork.CommitAsync();
            return order;
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
