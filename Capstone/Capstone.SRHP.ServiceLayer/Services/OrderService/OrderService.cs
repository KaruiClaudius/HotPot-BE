using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.UtensilService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly IDiscountService _discountService;
        private readonly IUtensilService _utensilService;
        private readonly IIngredientService _ingredientService;
        private readonly IHotpotService _hotpotService;
        private readonly ICustomizationService _customizationService;
        private readonly IComboService _comboService;
        private readonly IPaymentService _paymentService;
        private readonly ILogger<OrderService> _logger;

        public OrderService(
            IUnitOfWork unitOfWork,
            IDiscountService discountService,
            IUtensilService utensilService,
            IIngredientService ingredientService,
            IHotpotService hotpotService,
            ICustomizationService customizationService,
            IComboService comboService,
            IPaymentService paymentService,
            ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _discountService = discountService;
            _utensilService = utensilService;
            _ingredientService = ingredientService;
            _hotpotService = hotpotService;
            _customizationService = customizationService;
            _comboService = comboService;
            _paymentService = paymentService;
            _logger = logger;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            try
            {
                return await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .Where(o => !o.IsDelete)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all orders");
                throw;
            }
        }

        public async Task<PagedResult<Order>> GetPagedAsync(int pageNumber, int pageSize)
        {
            try
            {
                var query = _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .Where(o => !o.IsDelete)
                    .OrderByDescending(o => o.CreatedAt);

                var totalCount = await query.CountAsync();
                var items = await query
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving paged orders");
                throw;
            }
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            try
            {
                var order = await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .FirstOrDefaultAsync(o => o.OrderId == id && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {id} not found");

                return order;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order {OrderId}", id);
                throw;
            }
        }

        public async Task<Order> CreateAsync(CreateOrderRequest request, int userId)
        {
            try
            {
                // Validate request
                if (request.Items == null || !request.Items.Any())
                    throw new ValidationException("Order must contain at least one item");

                // Create order details
                var orderDetails = new List<OrderDetail>();
                decimal totalPrice = 0;

                foreach (var item in request.Items)
                {
                    // Validate that only one item type is specified
                    int itemTypeCount = 0;
                    if (item.UtensilID.HasValue) itemTypeCount++;
                    if (item.IngredientID.HasValue) itemTypeCount++;
                    if (item.HotpotID.HasValue) itemTypeCount++;
                    if (item.CustomizationID.HasValue) itemTypeCount++;
                    if (item.ComboID.HasValue) itemTypeCount++;

                    if (itemTypeCount != 1)
                        throw new ValidationException("Each order item must specify exactly one item type");

                    // Get unit price based on item type
                    decimal unitPrice = 0;

                    if (item.UtensilID.HasValue)
                    {
                        var utensil = await _utensilService.GetByIdAsync(item.UtensilID.Value);
                        if (utensil == null || !utensil.Status || utensil.Quantity < item.Quantity)
                            throw new ValidationException($"Utensil with ID {item.UtensilID} is not available in the requested quantity");

                        unitPrice = utensil.Price;
                    }


                    else if (item.IngredientID.HasValue)
                    {
                        var ingredient = await _ingredientService.GetByIdAsync(item.IngredientID.Value);
                        if (ingredient == null || ingredient.Quantity < item.Quantity)
                            throw new ValidationException($"Ingredient with ID {item.IngredientID} is not available in the requested quantity");

                        // Assuming you want the latest price
                        var latestPrice = ingredient.IngredientPrices.OrderByDescending(p => p.EffectiveDate).FirstOrDefault()?.Price ?? 0;
                        unitPrice = latestPrice;
                    }


                    else if (item.HotpotID.HasValue)
                    {
                        var hotpot = await _hotpotService.GetByIdAsync(item.HotpotID.Value);
                        if (hotpot == null || !hotpot.Status || hotpot.Quantity < item.Quantity)
                            throw new ValidationException($"Hotpot with ID {item.HotpotID} is not available in the requested quantity");

                        unitPrice = hotpot.Price;
                    }
                    else if (item.CustomizationID.HasValue)
                    {
                        var customization = await _customizationService.GetByIdAsync(item.CustomizationID.Value);
                        if (customization == null)
                            throw new ValidationException($"Customization with ID {item.CustomizationID} not found");

                        // Verify the customization belongs to the current user
                        if (customization.UserID != userId)
                            throw new ValidationException($"Customization with ID {item.CustomizationID} does not belong to the current user");

                        unitPrice = customization.TotalPrice;
                    }
                    else if (item.ComboID.HasValue)
                    {
                        var combo = await _comboService.GetByIdAsync(item.ComboID.Value);
                        if (combo == null)
                            throw new ValidationException($"Combo with ID {item.ComboID} not found");

                        // Combo price already includes any combo-specific discounts
                        unitPrice = combo.BasePrice;
                    }

                    // Create order detail
                    var orderDetail = new OrderDetail
                    {
                        Quantity = item.Quantity,
                        UnitPrice = unitPrice,
                        UtensilID = item.UtensilID,
                        IngredientID = item.IngredientID,
                        HotpotID = item.HotpotID,
                        CustomizationID = item.CustomizationID,
                        ComboID = item.ComboID
                    };

                    orderDetails.Add(orderDetail);
                    totalPrice += unitPrice * item.Quantity;
                }

                // Calculate deposits
                var (ingredientsDeposit, hotpotDeposit) = await CalculateDepositsAsync(request.Items);

                // Apply discount if provided
                if (request.DiscountId.HasValue)
                {
                    var discount = await _discountService.GetByIdAsync(request.DiscountId.Value);
                    if (discount == null)
                        throw new ValidationException($"Discount with ID {request.DiscountId} not found");

                    // Validate discount is still valid
                    if (!await _discountService.IsDiscountValidAsync(request.DiscountId.Value))
                        throw new ValidationException("The selected discount is not valid or has expired");

                    // Apply discount to total price
                    totalPrice -= (decimal)(totalPrice * discount.DiscountPercentage / 100);
                }

                // Create order
                var order = new Order
                {
                    UserID = userId,
                    Address = request.Address,
                    Notes = request.Notes,
                    TotalPrice = totalPrice,
                    Status = OrderStatus.Pending,
                    DiscountID = request.DiscountId,
                    IngredientsDeposit = ingredientsDeposit,
                    HotpotDeposit = hotpotDeposit,
                    OrderDetails = orderDetails
                };

                _unitOfWork.Repository<Order>().Insert(order);
                await _unitOfWork.CommitAsync();

                // Create payment based on payment type
                if (request.PaymentType == PaymentType.Cash)
                {
                    // Create cash payment
                    await _paymentService.CreateCashPaymentAsync(userId, order.OrderId, totalPrice);
                }
                else if (request.PaymentType == PaymentType.Online)
                {
                    // For online payment, we'll create a payment record but the actual payment link
                    // will be generated separately when the user proceeds to payment
                    var payment = new Payment
                    {
                        UserID = userId,
                        OrderID = order.OrderId,
                        Price = totalPrice,
                        Type = PaymentType.Online,
                        Status = PaymentStatus.Pending,
                        TransactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"))
                    };

                    await _unitOfWork.Repository<Payment>().InsertAsync(payment);
                    await _unitOfWork.CommitAsync();
                }

                // Update inventory quantities
                foreach (var item in request.Items)
                {
                    if (item.UtensilID.HasValue)
                    {
                        await _utensilService.UpdateQuantityAsync(item.UtensilID.Value, -item.Quantity);
                    }
                    else if (item.IngredientID.HasValue)
                    {
                        await _ingredientService.UpdateQuantityAsync(item.IngredientID.Value, -item.Quantity);
                    }
                    else if (item.HotpotID.HasValue)
                    {
                        await _hotpotService.UpdateQuantityAsync(item.HotpotID.Value, -item.Quantity);
                    }
                }

                // Reload order with all related entities
                return await GetByIdAsync(order.OrderId);
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating order");
                throw;
            }
        }

        public async Task<Order> UpdateAsync(int id, UpdateOrderRequest request)
        {
            try
            {
                var order = await GetByIdAsync(id);

                // Only allow updates for pending orders
                if (order.Status != OrderStatus.Pending)
                    throw new ValidationException("Only pending orders can be updated");

                // Update order properties
                if (!string.IsNullOrWhiteSpace(request.Address))
                    order.Address = request.Address;

                order.Notes = request.Notes;

                // Update discount if provided
                if (request.DiscountId.HasValue && request.DiscountId != order.DiscountID)
                {
                    var discount = await _discountService.GetByIdAsync(request.DiscountId.Value);
                    if (discount == null)
                        throw new ValidationException($"Discount with ID {request.DiscountId} not found");

                    // Validate discount is still valid
                    if (!await _discountService.IsDiscountValidAsync(request.DiscountId.Value))
                        throw new ValidationException("The selected discount is not valid or has expired");

                    // Calculate new total price with discount
                    decimal basePrice = order.TotalPrice;
                    if (order.DiscountID.HasValue)
                    {
                        // Remove old discount first
                        var oldDiscount = await _discountService.GetByIdAsync(order.DiscountID.Value);
                        if (oldDiscount != null)
                        {
                            basePrice = basePrice / (1 - (decimal)(oldDiscount.DiscountPercentage / 100));
                        }
                    }

                    // Apply new discount
                    order.TotalPrice = basePrice - (basePrice * (decimal)(discount.DiscountPercentage / 100));
                    order.DiscountID = request.DiscountId;
                }
                else if (request.DiscountId == null && order.DiscountID.HasValue)
                {
                    // Remove discount
                    var oldDiscount = await _discountService.GetByIdAsync(order.DiscountID.Value);
                    if (oldDiscount != null)
                    {
                        // Restore original price
                        order.TotalPrice = order.TotalPrice / (1 - (decimal)(oldDiscount.DiscountPercentage / 100));
                    }

                    order.DiscountID = null;
                }

                // Update order
                order.SetUpdateDate();
                await _unitOfWork.Repository<Order>().Update(order, id);
                await _unitOfWork.CommitAsync();

                // Update payment amount if exists
                var payment = await _paymentService.GetPaymentByOrderIdAsync(id);
                if (payment != null && payment.Status == PaymentStatus.Pending)
                {
                    payment.Price = order.TotalPrice;
                    await _unitOfWork.Repository<Payment>().Update(payment, payment.PaymentId);
                    await _unitOfWork.CommitAsync();
                }

                return await GetByIdAsync(id);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating order {OrderId}", id);
                throw;
            }
        }

        public async Task<Order> UpdateStatusAsync(int id, OrderStatus status)
        {
            try
            {
                var order = await GetByIdAsync(id);

                // Validate status transition
                ValidateStatusTransition(order.Status, status);

                // Update status
                order.Status = status;
                order.SetUpdateDate();
                await _unitOfWork.Repository<Order>().Update(order, id);
                await _unitOfWork.CommitAsync();

                // If order is cancelled, return inventory quantities
                if (status == OrderStatus.Cancelled)
                {
                    foreach (var detail in order.OrderDetails.Where(d => !d.IsDelete))
                    {
                        if (detail.UtensilID.HasValue)
                        {
                            await _utensilService.UpdateQuantityAsync(detail.UtensilID.Value, detail.Quantity);
                        }
                        else if (detail.IngredientID.HasValue)
                        {
                            await _ingredientService.UpdateQuantityAsync(detail.IngredientID.Value, detail.Quantity);
                        }
                        else if (detail.HotpotID.HasValue)
                        {
                            await _hotpotService.UpdateQuantityAsync(detail.HotpotID.Value, detail.Quantity);
                        }
                    }

                    // Cancel payment if exists and pending
                    var payment = await _paymentService.GetPaymentByOrderIdAsync(id);
                    if (payment != null && payment.Status == PaymentStatus.Pending)
                    {
                        await _paymentService.UpdatePaymentStatusAsync(payment.PaymentId, PaymentStatus.Cancelled);
                    }
                }

                return await GetByIdAsync(id);
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating status for order {OrderId}", id);
                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var order = await GetByIdAsync(id);

                // Only allow deletion of pending orders
                if (order.Status != OrderStatus.Pending)
                    throw new ValidationException("Only pending orders can be deleted");

                // Soft delete order
                order.SoftDelete();
                await _unitOfWork.CommitAsync();

                // Return inventory quantities
                foreach (var detail in order.OrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.UtensilID.HasValue)
                    {
                        await _utensilService.UpdateQuantityAsync(detail.UtensilID.Value, detail.Quantity);
                    }
                    else if (detail.IngredientID.HasValue)
                    {
                        await _ingredientService.UpdateQuantityAsync(detail.IngredientID.Value, detail.Quantity);
                    }
                    else if (detail.HotpotID.HasValue)
                    {
                        await _hotpotService.UpdateQuantityAsync(detail.HotpotID.Value, detail.Quantity);
                    }
                }

                // Cancel payment if exists and pending
                var payment = await _paymentService.GetPaymentByOrderIdAsync(id);
                if (payment != null && payment.Status == PaymentStatus.Pending)
                {
                    await _paymentService.UpdatePaymentStatusAsync(payment.PaymentId, PaymentStatus.Cancelled);
                }
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting order {OrderId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(int userId)
        {
            try
            {
                return await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .Where(o => o.UserID == userId && !o.IsDelete)
                    .OrderByDescending(o => o.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders for user {UserId}", userId);
                throw;
            }
        }

        public async Task<PagedResult<Order>> GetUserOrdersPagedAsync(int userId, int pageNumber, int pageSize)
        {
            try
            {
                var query = _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .Where(o => o.UserID == userId && !o.IsDelete)
                    .OrderByDescending(o => o.CreatedAt);

                var totalCount = await query.CountAsync();
                var items = await query
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving paged orders for user {UserId}", userId);
                throw;
            }
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            try
            {
                return await _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .Where(o => o.Status == status && !o.IsDelete)
                    .OrderByDescending(o => o.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving orders with status {Status}", status);
                throw;
            }
        }

        public async Task<PagedResult<Order>> GetOrdersByStatusPagedAsync(OrderStatus status, int pageNumber, int pageSize)
        {
            try
            {
                var query = _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
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
                    .Where(o => o.Status == status && !o.IsDelete)
                    .OrderByDescending(o => o.CreatedAt);

                var totalCount = await query.CountAsync();
                var items = await query
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving paged orders with status {Status}", status);
                throw;
            }
        }

        public async Task<(decimal ingredientsDeposit, decimal hotpotDeposit)> CalculateDepositsAsync(List<OrderItemRequest> items)
        {
            decimal ingredientsDeposit = 0;
            decimal hotpotDeposit = 0;

            foreach (var item in items)
            {
                if (item.IngredientID.HasValue)
                {
                    var ingredient = await _ingredientService.GetByIdAsync(item.IngredientID.Value);
                    if (ingredient != null)
                    {
                        // Get the latest price of the ingredient
                        var latestPrice = ingredient.IngredientPrices.OrderByDescending(p => p.EffectiveDate).FirstOrDefault()?.Price ?? 0;
                        // Deposit is 50% of total ingredient price
                        ingredientsDeposit += (latestPrice * item.Quantity) * 0.5m;
                    }
                }
                else if (item.HotpotID.HasValue)
                {
                    var hotpot = await _hotpotService.GetByIdAsync(item.HotpotID.Value);
                    if (hotpot != null)
                    {
                        // Deposit is 70% of the hotpot base price
                        hotpotDeposit += (hotpot.BasePrice * item.Quantity) * 0.7m;
                    }
                }
                else if (item.ComboID.HasValue)
                {
                    // For combos, we need to check the ingredients
                    var combo = await _unitOfWork.Repository<Combo>()
                        .IncludeNested(q => q.Include(c => c.ComboIngredients)
                                             .ThenInclude(ci => ci.Ingredient))
                        .FirstOrDefaultAsync(c => c.ComboId == item.ComboID.Value && !c.IsDelete);

                    if (combo != null)
                    {
                        // Process combo ingredients (excluding the hotpot broth which is handled separately)
                        foreach (var comboIngredient in combo.ComboIngredients.Where(ci => !ci.IsDelete))
                        {
                            if (comboIngredient.Ingredient != null && comboIngredient.Ingredient.IngredientTypeID != 1)
                            {
                                // Get the latest price of the ingredient
                                var latestPrice = comboIngredient.Ingredient.IngredientPrices.OrderByDescending(p => p.EffectiveDate).FirstOrDefault()?.Price ?? 0;
                                // Deposit is 50% of total ingredient price (for non-broth ingredients)
                                ingredientsDeposit += (latestPrice * comboIngredient.Quantity * item.Quantity) * 0.5m;
                            }
                        }
                    }
                }
                else if (item.CustomizationID.HasValue)
                {
                    // For customizations, we need to check the ingredients
                    var customization = await _unitOfWork.Repository<Customization>()
                        .IncludeNested(q => q.Include(c => c.CustomizationIngredients)
                                             .ThenInclude(ci => ci.Ingredient))
                        .FirstOrDefaultAsync(c => c.CustomizationId == item.CustomizationID.Value && !c.IsDelete);

                    if (customization != null)
                    {
                        // Process customization ingredients (excluding the hotpot broth which is handled separately)
                        foreach (var customizationIngredient in customization.CustomizationIngredients.Where(ci => !ci.IsDelete))
                        {
                            if (customizationIngredient.Ingredient != null && customizationIngredient.Ingredient.IngredientTypeID != 1)
                            {
                                // Get the latest price of the ingredient
                                var latestPrice = customizationIngredient.Ingredient.IngredientPrices.OrderByDescending(p => p.EffectiveDate).FirstOrDefault()?.Price ?? 0;
                                // Deposit is 50% of total ingredient price (for non-broth ingredients)
                                ingredientsDeposit += (latestPrice * customizationIngredient.Quantity * item.Quantity) * 0.5m;
                            }
                        }
                    }
                }
            }

            // Round to 2 decimal places
            ingredientsDeposit = Math.Round(ingredientsDeposit, 2);
            hotpotDeposit = Math.Round(hotpotDeposit, 2);

            return (ingredientsDeposit, hotpotDeposit);
        }

        // Helper methods
        private void ValidateStatusTransition(OrderStatus currentStatus, OrderStatus newStatus)
        {
            // Define valid status transitions
            bool isValidTransition = (currentStatus, newStatus) switch
            {
                (OrderStatus.Pending, OrderStatus.Processing) => true,
                (OrderStatus.Pending, OrderStatus.Cancelled) => true,
                (OrderStatus.Processing, OrderStatus.Shipping) => true,
                (OrderStatus.Processing, OrderStatus.Cancelled) => true,
                (OrderStatus.Shipping, OrderStatus.Delivered) => true,
                (OrderStatus.Delivered, OrderStatus.Returning) => true,
                (OrderStatus.Returning, OrderStatus.Completed) => true,
                _ => false
            };

            if (!isValidTransition)
            {
                throw new ValidationException($"Invalid status transition from {currentStatus} to {newStatus}");
            }
        }

        public Task<Order> CreateAsync(Order entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Order entity)
        {
            throw new NotImplementedException();
        }
    }
}
