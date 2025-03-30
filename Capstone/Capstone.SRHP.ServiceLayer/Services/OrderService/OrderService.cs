using Azure.Core;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
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

        public async Task<PagedResult<Order>> GetOrdersAsync(
     string searchTerm = null,
     int? userId = null,
     string status = null,
     DateTime? fromDate = null,
     DateTime? toDate = null,
     decimal? minPrice = null,
     decimal? maxPrice = null,
     bool? hasHotpot = null,
     string paymentStatus = null,
     int pageNumber = 1,
     int pageSize = 10,
     string sortBy = "CreatedAt",
     bool ascending = false)
        {
            try
            {
                // Start with base query
                var query = _unitOfWork.Repository<Order>()
                    .AsQueryable()
                    .Include(o => o.User)
                    .Include(o => o.Discount)
                    .Include(o => o.Payment)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                            .ThenInclude(od => od.Ingredient)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                            .ThenInclude(od => od.Customization)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                            .ThenInclude(od => od.Combo)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails)
                            .ThenInclude(od => od.Utensil)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails)
                            .ThenInclude(od => od.HotpotInventory)
                                .ThenInclude(hi => hi != null ? hi.Hotpot : null)
                    .Where(o => !o.IsDelete);

                // Apply filters
                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    searchTerm = searchTerm.ToLower();
                    query = query.Where(o =>
                        o.Address != null && EF.Functions.Collate(o.Address.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                        o.Notes != null && EF.Functions.Collate(o.Notes.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                        o.User != null && o.User.Name != null && EF.Functions.Collate(o.User.Name.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                        o.User != null && o.User.Email != null && EF.Functions.Collate(o.User.Email.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) ||
                        o.User != null && o.User.PhoneNumber != null && EF.Functions.Collate(o.User.PhoneNumber.ToLower(), "Latin1_General_CI_AI").Contains(searchTerm) 
                    );
                }

                if (userId.HasValue)
                {
                    query = query.Where(o => o.UserId == userId.Value);
                }

                if (!string.IsNullOrWhiteSpace(status) && Enum.TryParse<OrderStatus>(status, true, out var orderStatus))
                {
                    query = query.Where(o => o.Status == orderStatus);
                }

                if (fromDate.HasValue)
                {
                    query = query.Where(o => o.CreatedAt >= fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    query = query.Where(o => o.CreatedAt <= toDate.Value);
                }

                if (minPrice.HasValue)
                {
                    query = query.Where(o => o.TotalPrice >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(o => o.TotalPrice <= maxPrice.Value);
                }

                if (hasHotpot.HasValue)
                {
                    if (hasHotpot.Value)
                    {
                        query = query.Where(o => o.RentOrder != null &&
                            o.RentOrder.RentOrderDetails.Any(od => od.HotpotInventoryId.HasValue));
                    }
                    else
                    {
                        query = query.Where(o => o.RentOrder == null ||
                            !o.RentOrder.RentOrderDetails.Any(od => od.HotpotInventoryId.HasValue));
                    }
                }

                if (!string.IsNullOrWhiteSpace(paymentStatus) && Enum.TryParse<PaymentStatus>(paymentStatus, true, out var pmtStatus))
                {
                    query = query.Where(o => o.Payment != null && o.Payment.Status == pmtStatus);
                }

                // Get total count before applying pagination
                var totalCount = await query.CountAsync();

                // Apply sorting
                IOrderedQueryable<Order> orderedQuery;

                switch (sortBy?.ToLower())
                {
                    case "totalprice":
                        orderedQuery = ascending ? query.OrderBy(o => o.TotalPrice) : query.OrderByDescending(o => o.TotalPrice);
                        break;
                    case "status":
                        orderedQuery = ascending ? query.OrderBy(o => o.Status) : query.OrderByDescending(o => o.Status);
                        break;
                    case "username":
                        orderedQuery = ascending ? query.OrderBy(o => o.User.Name) : query.OrderByDescending(o => o.User.Name);
                        break;
                    case "updatedat":
                        orderedQuery = ascending ? query.OrderBy(o => o.UpdatedAt) : query.OrderByDescending(o => o.UpdatedAt);
                        break;
                    case "address":
                        orderedQuery = ascending ? query.OrderBy(o => o.Address) : query.OrderByDescending(o => o.Address);
                        break;
                    default: // Default to CreatedAt
                        orderedQuery = ascending ? query.OrderBy(o => o.CreatedAt) : query.OrderByDescending(o => o.CreatedAt);
                        break;
                }

                // Apply pagination
                var items = await orderedQuery
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
                _logger.LogError(ex, "Error retrieving orders with filters");
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
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                            .ThenInclude(od => od.Ingredient)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                            .ThenInclude(od => od.Customization)
                    .Include(o => o.SellOrder)
                        .ThenInclude(so => so.SellOrderDetails)
                            .ThenInclude(od => od.Combo)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails)
                            .ThenInclude(od => od.Utensil)
                    .Include(o => o.RentOrder)
                        .ThenInclude(ro => ro.RentOrderDetails)
                            .ThenInclude(od => od.HotpotInventory)
                                .ThenInclude(hi => hi != null ? hi.Hotpot : null)
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

                // Execute in transaction to ensure consistency
                return await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    // Check if user already has a pending order (cart)
                    var existingPendingOrder = await _unitOfWork.Repository<Order>()
                        .IncludeNested(query =>
                            query.Include(o => o.SellOrder)
                                 .ThenInclude(so => so.SellOrderDetails)
                                 .Include(o => o.RentOrder)
                                 .ThenInclude(ro => ro.RentOrderDetails))
                        .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == OrderStatus.Pending && !o.IsDelete);

                    if (existingPendingOrder != null)
                    {
                        // User has an existing pending order - add items to it
                        return await AddToExistingOrderAsync(existingPendingOrder, request, userId);
                    }
                    else
                    {
                        // No existing pending order - create a new one
                        return await CreateNewOrderAsync(request, userId);
                    }
                });
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating or updating order");
                throw;
            }
        }

        private async Task<Order> AddToExistingOrderAsync(Order existingOrder, CreateOrderRequest request, int userId)
        {
            // Create order details for new items
            var newSellOrderDetails = new List<SellOrderDetail>();
            var newRentOrderDetails = new List<RentOrderDetail>();
            decimal additionalTotal = 0;
            decimal additionalSellSubTotal = 0;
            decimal additionalRentSubTotal = 0;
            decimal additionalHotpotDeposit = 0;
            bool hasSellItems = existingOrder.HasSellItems;
            bool hasRentItems = existingOrder.HasRentItems;

            // Get existing rental dates if any
            DateTime? rentalStartDate = existingOrder.RentOrder?.RentalStartDate;
            DateTime? expectedReturnDate = existingOrder.RentOrder?.ExpectedReturnDate;

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

                // Process each item type
                if (item.UtensilID.HasValue)
                {
                    var utensil = await _utensilService.GetUtensilByIdAsync(item.UtensilID.Value);
                    if (utensil == null || !utensil.Status || utensil.Quantity < item.Quantity)
                        throw new ValidationException($"Utensil with ID {item.UtensilID} is not available in the requested quantity");

                    // Check if this utensil is already in the order
                    var existingDetail = existingOrder.RentOrder?.RentOrderDetails
                        .FirstOrDefault(d => d.UtensilId == item.UtensilID && !d.IsDelete);

                    if (existingDetail != null)
                    {
                        // Update existing detail
                        existingDetail.Quantity += (int)item.Quantity;
                        await _unitOfWork.Repository<RentOrderDetail>().Update(existingDetail, existingDetail.RentOrderDetailId);
                    }
                    else
                    {
                        // Add new detail
                        var orderDetail = new RentOrderDetail
                        {
                            OrderId = existingOrder.OrderId,
                            Quantity = (int)item.Quantity,
                            RentalPrice = utensil.Price,
                            UtensilId = item.UtensilID
                        };

                        newRentOrderDetails.Add(orderDetail);
                    }

                    decimal itemTotal = (decimal)(utensil.Price * item.Quantity);
                    additionalRentSubTotal += itemTotal;
                    additionalTotal += itemTotal;
                    hasRentItems = true;

                    // Set rental dates if not already set
                    if (!rentalStartDate.HasValue)
                    {
                        rentalStartDate = DateTime.Now;
                        expectedReturnDate = DateTime.Now.AddDays(7); // Default rental period
                    }
                }
                else if (item.IngredientID.HasValue)
                {
                    var ingredient = await _ingredientService.GetIngredientByIdAsync(item.IngredientID.Value);
                    if (ingredient == null)
                        throw new ValidationException($"Ingredient with ID {item.IngredientID} not found");

                    // Check if the requested quantity is available
                    if (ingredient.Quantity < item.Quantity)
                        throw new ValidationException($"Only {ingredient.Quantity} of {ingredient.Name} is available");

                    // Get the latest price
                    var latestPrice = ingredient.IngredientPrices
                        .OrderByDescending(p => p.EffectiveDate)
                        .FirstOrDefault()?.Price ?? 0;

                    // Check if this ingredient is already in the order
                    var existingDetail = existingOrder.SellOrder?.SellOrderDetails
                        .FirstOrDefault(d => d.IngredientId == item.IngredientID && !d.IsDelete);

                    if (existingDetail != null)
                    {
                        // Update existing detail
                        existingDetail.Quantity += (int)item.Quantity;
                        await _unitOfWork.Repository<SellOrderDetail>().Update(existingDetail, existingDetail.SellOrderDetailId);
                    }
                    else
                    {
                        // Add new detail
                        var orderDetail = new SellOrderDetail
                        {
                            OrderId = existingOrder.OrderId,
                            Quantity = (int)item.Quantity,
                            UnitPrice = latestPrice,
                            IngredientId = item.IngredientID
                        };

                        newSellOrderDetails.Add(orderDetail);
                    }

                    decimal itemTotal = (decimal)(latestPrice * item.Quantity);
                    additionalSellSubTotal += itemTotal;
                    additionalTotal += itemTotal;
                    hasSellItems = true;
                }
                else if (item.HotpotID.HasValue)
                {
                    var hotpot = await _hotpotService.GetByIdAsync(item.HotpotID.Value);
                    if (hotpot == null)
                        throw new ValidationException($"Hotpot with ID {item.HotpotID} is not available");

                    // Get available hotpot inventory items
                    var availableHotpots = await _unitOfWork.Repository<HotPotInventory>()
                        .AsQueryable()
                        .Where(h => h.HotpotId == item.HotpotID && h.Status == HotpotStatus.Available && !h.IsDelete)
                        .Take((int)item.Quantity)
                        .ToListAsync();

                    if (availableHotpots.Count < item.Quantity)
                        throw new ValidationException($"Only {availableHotpots.Count} hotpots of type {hotpot.Name} are available");

                    hasRentItems = true;

                    // Set rental dates if not already set
                    if (!rentalStartDate.HasValue)
                    {
                        rentalStartDate = DateTime.Now;
                        expectedReturnDate = DateTime.Now.AddDays(7); // Default rental period
                    }

                    // Create a separate order detail for each hotpot inventory item
                    foreach (var hotpotInventory in availableHotpots)
                    {
                        hotpotInventory.Hotpot.Quantity -= 1;
                        hotpotInventory.Status = HotpotStatus.Rented;
                        await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);

                        // Create rent order detail with reference to specific hotpot inventory
                        var orderDetail = new RentOrderDetail
                        {
                            OrderId = existingOrder.OrderId,
                            Quantity = 1, // Each hotpot inventory item is a single unit
                            RentalPrice = hotpot.Price,
                            HotpotInventoryId = hotpotInventory.HotPotInventoryId
                        };

                        newRentOrderDetails.Add(orderDetail);
                        decimal itemTotal = hotpot.Price;
                        additionalRentSubTotal += itemTotal;
                        additionalTotal += itemTotal;

                        // Calculate hotpot deposit (70% of hotpot price)
                        additionalHotpotDeposit += hotpot.Price * 0.7m;
                    }
                }
                else if (item.CustomizationID.HasValue)
                {
                    var customization = await _customizationService.GetByIdAsync(item.CustomizationID.Value);
                    if (customization == null)
                        throw new ValidationException($"Customization with ID {item.CustomizationID} not found");

                    // Verify the customization belongs to the current user
                    if (customization.UserId != userId)
                        throw new ValidationException($"Customization with ID {item.CustomizationID} does not belong to the current user");

                    // Check if this customization is already in the order
                    var existingDetail = existingOrder.SellOrder?.SellOrderDetails
                        .FirstOrDefault(d => d.CustomizationId == item.CustomizationID && !d.IsDelete);

                    if (existingDetail != null)
                    {
                        // Update existing detail
                        existingDetail.Quantity += (int)item.Quantity;
                        await _unitOfWork.Repository<SellOrderDetail>().Update(existingDetail, existingDetail.SellOrderDetailId);
                    }
                    else
                    {
                        // Add new detail
                        var orderDetail = new SellOrderDetail
                        {
                            OrderId = existingOrder.OrderId,
                            Quantity = (int)item.Quantity,
                            UnitPrice = customization.TotalPrice,
                            CustomizationId = item.CustomizationID
                        };

                        newSellOrderDetails.Add(orderDetail);
                    }

                    decimal itemTotal = (decimal)(customization.TotalPrice * item.Quantity);
                    additionalSellSubTotal += itemTotal;
                    additionalTotal += itemTotal;
                    hasSellItems = true;
                }
                else if (item.ComboID.HasValue)
                {
                    var combo = await _comboService.GetByIdAsync(item.ComboID.Value);
                    if (combo == null)
                        throw new ValidationException($"Combo with ID {item.ComboID} not found");

                    // Check if this combo is already in the order
                    var existingDetail = existingOrder.SellOrder?.SellOrderDetails
                        .FirstOrDefault(d => d.ComboId == item.ComboID && !d.IsDelete);

                    if (existingDetail != null)
                    {
                        // Update existing detail
                        existingDetail.Quantity += (int)item.Quantity;
                        await _unitOfWork.Repository<SellOrderDetail>().Update(existingDetail, existingDetail.SellOrderDetailId);
                    }
                    else
                    {
                        // Add new detail
                        var orderDetail = new SellOrderDetail
                        {
                            OrderId = existingOrder.OrderId,
                            Quantity = (int)item.Quantity,
                            UnitPrice = combo.BasePrice,
                            ComboId = item.ComboID
                        };

                        newSellOrderDetails.Add(orderDetail);
                    }

                    decimal itemTotal = (decimal)(combo.BasePrice * item.Quantity);
                    additionalSellSubTotal += itemTotal;
                    additionalTotal += itemTotal;
                    hasSellItems = true;
                }
            }

            // Apply discount if provided or use existing discount
            decimal discountPercentage = 0;
            if (request.DiscountId.HasValue)
            {
                var discount = await _discountService.GetByIdAsync(request.DiscountId.Value);
                if (discount == null)
                    throw new ValidationException($"Discount with ID {request.DiscountId} not found");

                // Validate discount is still valid
                if (!await _discountService.IsDiscountValidAsync(request.DiscountId.Value))
                    throw new ValidationException("The selected discount is not valid or has expired");

                discountPercentage = discount.DiscountPercentage;
                existingOrder.DiscountId = request.DiscountId;
            }
            else if (existingOrder.DiscountId.HasValue)
            {
                var existingDiscount = await _discountService.GetByIdAsync(existingOrder.DiscountId.Value);
                if (existingDiscount != null && await _discountService.IsDiscountValidAsync(existingOrder.DiscountId.Value))
                {
                    discountPercentage = existingDiscount.DiscountPercentage;
                }
            }

            // Calculate new total with discount
            decimal newTotal = existingOrder.TotalPrice + additionalTotal;
            if (discountPercentage > 0)
            {
                newTotal = newTotal * (1 - (discountPercentage / 100m));
            }

            // Update the main order
            existingOrder.TotalPrice = newTotal;
            existingOrder.HasSellItems = hasSellItems;
            existingOrder.HasRentItems = hasRentItems;

            // Update address and notes if provided
            if (!string.IsNullOrEmpty(request.Address))
            {
                existingOrder.Address = request.Address;
            }

            if (!string.IsNullOrEmpty(request.Notes))
            {
                existingOrder.Notes = request.Notes;
            }

            await _unitOfWork.Repository<Order>().Update(existingOrder, existingOrder.OrderId);

            // Update or create SellOrder if needed
            if (hasSellItems)
            {
                if (existingOrder.SellOrder != null)
                {
                    existingOrder.SellOrder.SubTotal += additionalSellSubTotal;
                    await _unitOfWork.Repository<SellOrder>().Update(existingOrder.SellOrder, existingOrder.SellOrder.OrderId);
                }
                else
                {
                    var sellOrder = new SellOrder
                    {
                        OrderId = existingOrder.OrderId,
                        SubTotal = additionalSellSubTotal
                    };
                    await _unitOfWork.Repository<SellOrder>().InsertAsync(sellOrder);
                }

                // Insert new sell order details
                foreach (var detail in newSellOrderDetails)
                {
                    await _unitOfWork.Repository<SellOrderDetail>().InsertAsync(detail);
                }
            }

            // Update or create RentOrder if needed
            if (hasRentItems)
            {
                if (existingOrder.RentOrder != null)
                {
                    existingOrder.RentOrder.SubTotal += additionalRentSubTotal;
                    existingOrder.RentOrder.HotpotDeposit += additionalHotpotDeposit;
                    await _unitOfWork.Repository<RentOrder>().Update(existingOrder.RentOrder, existingOrder.RentOrder.OrderId);
                }
                else
                {
                    var rentOrder = new RentOrder
                    {
                        OrderId = existingOrder.OrderId,
                        SubTotal = additionalRentSubTotal,
                        HotpotDeposit = additionalHotpotDeposit,
                        RentalStartDate = rentalStartDate.Value,
                        ExpectedReturnDate = expectedReturnDate.Value
                    };
                    await _unitOfWork.Repository<RentOrder>().InsertAsync(rentOrder);
                }

                // Insert new rent order details
                foreach (var detail in newRentOrderDetails)
                {
                    await _unitOfWork.Repository<RentOrderDetail>().InsertAsync(detail);
                }
            }

            await _unitOfWork.CommitAsync();

            // Update inventory quantities for non-hotpot items (hotpots are already handled)
            foreach (var item in request.Items)
            {
                if (item.UtensilID.HasValue)
                {
                    await _utensilService.UpdateUtensilQuantityAsync(item.UtensilID.Value, (int)-item.Quantity);
                }
                else if (item.IngredientID.HasValue)
                {
                    // Update ingredient quantity
                    await _ingredientService.UpdateIngredientQuantityAsync(
                        item.IngredientID.Value,
                        -(int)item.Quantity);
                }
                // Note: HotPotInventory status is already updated above
            }

            // Reload order with all related entities
            return await GetByIdAsync(existingOrder.OrderId);
        }

        private async Task<Order> CreateNewOrderAsync(CreateOrderRequest request, int userId)
        {
            // Create order details
            var sellOrderDetails = new List<SellOrderDetail>();
            var rentOrderDetails = new List<RentOrderDetail>();
            decimal totalPrice = 0;
            decimal sellSubTotal = 0;
            decimal rentSubTotal = 0;
            decimal hotpotDeposit = 0;
            bool hasSellItems = false;
            bool hasRentItems = false;

            // Rental dates for RentOrder
            DateTime? rentalStartDate = null;
            DateTime? expectedReturnDate = null;


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
                    var utensil = await _utensilService.GetUtensilByIdAsync(item.UtensilID.Value);
                    if (utensil == null || !utensil.Status || utensil.Quantity < item.Quantity)
                        throw new ValidationException($"Utensil with ID {item.UtensilID} is not available in the requested quantity");

                    unitPrice = utensil.Price;
                    hasRentItems = true;

                    // Set rental dates if not already set
                    if (!rentalStartDate.HasValue)
                    {
                        rentalStartDate = DateTime.Now;
                        expectedReturnDate = DateTime.Now.AddDays(7); // Default rental period
                    }

                    // Create rent order detail for utensil
                    var orderDetail = new RentOrderDetail
                    {
                        Quantity = (int)item.Quantity,
                        RentalPrice = unitPrice,
                        UtensilId = item.UtensilID
                    };

                    rentOrderDetails.Add(orderDetail);
                    decimal itemTotal = (decimal)(unitPrice * item.Quantity);
                    rentSubTotal += itemTotal;
                    totalPrice += itemTotal;
                }
                else if (item.IngredientID.HasValue)
                {
                    var ingredient = await _ingredientService.GetIngredientByIdAsync(item.IngredientID.Value);
                    if (ingredient == null)
                        throw new ValidationException($"Ingredient with ID {item.IngredientID} not found");

                    // Check if the requested quantity is available
                    if (ingredient.Quantity < item.Quantity)
                        throw new ValidationException($"Only {ingredient.Quantity} of {ingredient.Name} is available");

                    // Get the latest price
                    var latestPrice = ingredient.IngredientPrices
                        .OrderByDescending(p => p.EffectiveDate)
                        .FirstOrDefault()?.Price ?? 0;

                    unitPrice = latestPrice;
                    hasSellItems = true;

                    // Create sell order detail for ingredient
                    var orderDetail = new SellOrderDetail
                    {
                        Quantity = (int)item.Quantity,
                        UnitPrice = unitPrice,
                        IngredientId = item.IngredientID
                    };

                    sellOrderDetails.Add(orderDetail);
                    decimal itemTotal = (decimal)(unitPrice * item.Quantity);
                    sellSubTotal += itemTotal;
                    totalPrice += itemTotal;
                }
                else if (item.HotpotID.HasValue)
                {
                    var hotpot = await _hotpotService.GetByIdAsync(item.HotpotID.Value);
                    if (hotpot == null)
                        throw new ValidationException($"Hotpot with ID {item.HotpotID} is not available");

                    // Get available hotpot inventory items
                    var availableHotpots = await _unitOfWork.Repository<HotPotInventory>()
                        .AsQueryable()
                        .Where(h => h.HotpotId == item.HotpotID && h.Status == HotpotStatus.Available && !h.IsDelete)
                        .Take((int)item.Quantity)
                        .ToListAsync();

                    if (availableHotpots.Count < item.Quantity)
                        throw new ValidationException($"Only {availableHotpots.Count} hotpots of type {hotpot.Name} are available");

                    hasRentItems = true;

                    // Set rental dates if not already set
                    if (!rentalStartDate.HasValue)
                    {
                        rentalStartDate = DateTime.Now;
                        expectedReturnDate = DateTime.Now.AddDays(7); // Default rental period
                    }

                    // Create a separate order detail for each hotpot inventory item
                    foreach (var hotpotInventory in availableHotpots)
                    {
                        hotpotInventory.Hotpot.Quantity -= 1;
                        hotpotInventory.Status = HotpotStatus.Rented;
                        await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);

                        // Create rent order detail with reference to specific hotpot inventory
                        var orderDetail = new RentOrderDetail
                        {
                            Quantity = 1, // Each hotpot inventory item is a single unit
                            RentalPrice = hotpot.Price,
                            HotpotInventoryId = hotpotInventory.HotPotInventoryId
                        };

                        rentOrderDetails.Add(orderDetail);
                        decimal itemTotal = hotpot.Price;
                        rentSubTotal += itemTotal;
                        totalPrice += itemTotal;

                        // Calculate hotpot deposit (70% of hotpot price)
                        hotpotDeposit += hotpot.Price * 0.7m;
                    }
                }
                else if (item.CustomizationID.HasValue)
                {
                    var customization = await _customizationService.GetByIdAsync(item.CustomizationID.Value);
                    if (customization == null)
                        throw new ValidationException($"Customization with ID {item.CustomizationID} not found");

                    // Verify the customization belongs to the current user
                    if (customization.UserId != userId)
                        throw new ValidationException($"Customization with ID {item.CustomizationID} does not belong to the current user");

                    unitPrice = customization.TotalPrice;
                    hasSellItems = true;

                    // Create sell order detail for customization
                    var orderDetail = new SellOrderDetail
                    {
                        Quantity = (int)item.Quantity,
                        UnitPrice = unitPrice,
                        CustomizationId = item.CustomizationID
                    };

                    sellOrderDetails.Add(orderDetail);
                    decimal itemTotal = (decimal)(unitPrice * item.Quantity);
                    sellSubTotal += itemTotal;
                    totalPrice += itemTotal;
                }
                else if (item.ComboID.HasValue)
                {
                    var combo = await _comboService.GetByIdAsync(item.ComboID.Value);
                    if (combo == null)
                        throw new ValidationException($"Combo with ID {item.ComboID} not found");

                    // Combo price already includes any combo-specific discounts
                    unitPrice = combo.BasePrice;
                    hasSellItems = true;

                    // Create sell order detail for combo
                    var orderDetail = new SellOrderDetail
                    {
                        Quantity = (int)item.Quantity,
                        UnitPrice = unitPrice,
                        ComboId = item.ComboID
                    };

                    sellOrderDetails.Add(orderDetail);
                    decimal itemTotal = (decimal)(unitPrice * item.Quantity);
                    sellSubTotal += itemTotal;
                    totalPrice += itemTotal;
                }
            }

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



            // Create main order
            var order = new Order
            {
                UserId = userId,
                Address = request.Address,
                Notes = request.Notes,
                TotalPrice = totalPrice,
                Status = OrderStatus.Pending,
                DiscountId = request.DiscountId,
                HasSellItems = hasSellItems,
                HasRentItems = hasRentItems
            };

            // Insert the main order first to get the OrderId
            await _unitOfWork.Repository<Order>().InsertAsync(order);
            await _unitOfWork.CommitAsync();

            // Create SellOrder if there are sell items
            if (hasSellItems)
            {
                var sellOrder = new SellOrder
                {
                    OrderId = order.OrderId,
                    SubTotal = sellSubTotal
                };

                await _unitOfWork.Repository<SellOrder>().InsertAsync(sellOrder);

                // Update SellOrderDetails with the OrderId
                foreach (var detail in sellOrderDetails)
                {
                    detail.OrderId = order.OrderId;
                    await _unitOfWork.Repository<SellOrderDetail>().InsertAsync(detail);
                }
            }

            // Create RentOrder if there are rent items
            if (hasRentItems)
            {
                var rentOrder = new RentOrder
                {
                    OrderId = order.OrderId,
                    SubTotal = rentSubTotal,
                    HotpotDeposit = hotpotDeposit,
                    RentalStartDate = rentalStartDate.Value,
                    ExpectedReturnDate = expectedReturnDate.Value
                };

                await _unitOfWork.Repository<RentOrder>().InsertAsync(rentOrder);

                // Update RentOrderDetails with the OrderId
                foreach (var detail in rentOrderDetails)
                {
                    detail.OrderId = order.OrderId;
                    await _unitOfWork.Repository<RentOrderDetail>().InsertAsync(detail);
                }
            }

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
                    UserId = userId,
                    OrderId = order.OrderId,
                    Price = totalPrice,
                    Type = PaymentType.Online,
                    Status = PaymentStatus.Pending,
                    TransactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"))
                };

                await _unitOfWork.Repository<Payment>().InsertAsync(payment);
                await _unitOfWork.CommitAsync();
            }

            // Update inventory quantities for non-hotpot items (hotpots are already handled)
            foreach (var item in request.Items)
            {
                if (item.UtensilID.HasValue)
                {
                    await _utensilService.UpdateUtensilQuantityAsync(item.UtensilID.Value, (int)-item.Quantity);
                }
                else if (item.IngredientID.HasValue)
                {
                    // Update ingredient quantity
                    await _ingredientService.UpdateIngredientQuantityAsync(
                        item.IngredientID.Value,
                        -(int)item.Quantity);
                }
                // Note: HotPotInventory status is already updated above
            }

            // Reload order with all related entities
            return await GetByIdAsync(order.OrderId);
        }

        public async Task<Order> RemoveItemFromCartAsync(int userId, int orderDetailId, bool isSellItem)
        {
            try
            {
                // Find the user's pending order
                var pendingOrder = await _unitOfWork.Repository<Order>()
                    .IncludeNested(query =>
                        query.Include(o => o.SellOrder)
                             .ThenInclude(so => so.SellOrderDetails)
                             .Include(o => o.RentOrder)
                             .ThenInclude(ro => ro.RentOrderDetails))
                    .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == OrderStatus.Pending && !o.IsDelete);

                if (pendingOrder == null)
                    throw new NotFoundException("No pending order found");

                return await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    decimal priceReduction = 0;

                    if (isSellItem)
                    {
                        // Find the sell order detail
                        var detail = pendingOrder.SellOrder?.SellOrderDetails
                            .FirstOrDefault(d => d.SellOrderDetailId == orderDetailId && !d.IsDelete);

                        if (detail == null)
                            throw new NotFoundException($"Order detail with ID {orderDetailId} not found");

                        // Calculate price reduction
                        priceReduction = detail.UnitPrice * detail.Quantity;

                        // Soft delete the detail
                        detail.SoftDelete();
                        await _unitOfWork.Repository<SellOrderDetail>().Update(detail, detail.SellOrderDetailId);

                        // Update sell order subtotal
                        pendingOrder.SellOrder.SubTotal -= priceReduction;
                        await _unitOfWork.Repository<SellOrder>().Update(pendingOrder.SellOrder, pendingOrder.SellOrder.OrderId);

                        // Check if there are any remaining sell items
                        var remainingSellItems = await _unitOfWork.Repository<SellOrderDetail>()
                            .AnyAsync(d => d.OrderId == pendingOrder.OrderId && !d.IsDelete);

                        pendingOrder.HasSellItems = remainingSellItems;
                    }
                    else
                    {
                        // Find the rent order detail
                        var detail = pendingOrder.RentOrder?.RentOrderDetails
                            .FirstOrDefault(d => d.RentOrderDetailId == orderDetailId && !d.IsDelete);

                        if (detail == null)
                            throw new NotFoundException($"Order detail with ID {orderDetailId} not found");

                        // Calculate price reduction
                        priceReduction = detail.RentalPrice * detail.Quantity;

                        // Soft delete the detail
                        detail.SoftDelete();
                        await _unitOfWork.Repository<RentOrderDetail>().Update(detail, detail.RentOrderDetailId);

                        // Update rent order subtotal and deposit
                        pendingOrder.RentOrder.SubTotal -= priceReduction;

                        // Recalculate hotpot deposit if needed
                        if (detail.HotpotInventoryId.HasValue)
                        {
                            var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                .IncludeNested(q => q.Include(h => h.Hotpot))
                                .FirstOrDefaultAsync(h => h.HotPotInventoryId == detail.HotpotInventoryId && !h.IsDelete);

                            if (hotpotInventory != null)
                            {
                                pendingOrder.RentOrder.HotpotDeposit -= hotpotInventory.Hotpot.Price * 0.7m;
                            }
                        }

                        await _unitOfWork.Repository<RentOrder>().Update(pendingOrder.RentOrder, pendingOrder.RentOrder.OrderId);

                        // Check if there are any remaining rent items
                        var remainingRentItems = await _unitOfWork.Repository<RentOrderDetail>()
                            .AnyAsync(d => d.OrderId == pendingOrder.OrderId && !d.IsDelete);

                        pendingOrder.HasRentItems = remainingRentItems;
                    }

                    // Recalculate total price
                    decimal newTotal = 0;

                    if (pendingOrder.HasSellItems)
                    {
                        newTotal += pendingOrder.SellOrder.SubTotal;
                    }

                    if (pendingOrder.HasRentItems)
                    {
                        newTotal += pendingOrder.RentOrder.SubTotal;
                    }

                    // Apply discount if any
                    if (pendingOrder.DiscountId.HasValue)
                    {
                        var discount = await _discountService.GetByIdAsync(pendingOrder.DiscountId.Value);
                        if (discount != null && await _discountService.IsDiscountValidAsync(pendingOrder.DiscountId.Value))
                        {
                            newTotal = newTotal * (1 - (discount.DiscountPercentage / 100m));
                        }
                    }

                    pendingOrder.TotalPrice = newTotal;
                    await _unitOfWork.Repository<Order>().Update(pendingOrder, pendingOrder.OrderId);

                    // If there are no items left, delete the order using the existing DeleteAsync method
                    if (!pendingOrder.HasSellItems && !pendingOrder.HasRentItems)
                    {
                        // We need to commit our changes first to ensure the order is properly updated
                        await _unitOfWork.CommitAsync();

                        // Now call the existing DeleteAsync method to handle inventory returns and payment cancellation
                        await DeleteAsync(pendingOrder.OrderId);
                        return null;
                    }

                    await _unitOfWork.CommitAsync();

                    // Update payment records if needed
                    var payment = await _unitOfWork.Repository<Payment>()
                        .FindAsync(p => p.OrderId == pendingOrder.OrderId && p.Status == PaymentStatus.Pending && !p.IsDelete);

                    if (payment != null)
                    {
                        payment.Price = newTotal;
                        await _unitOfWork.Repository<Payment>().Update(payment, payment.PaymentId);
                        await _unitOfWork.CommitAsync();
                    }

                    // Reload order with all related entities
                    return await GetByIdAsync(pendingOrder.OrderId);
                });
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing item from cart");
                throw;
            }
        }

        public async Task<Order> UpdateCartItemsQuantityAsync(int userId, CartItemUpdate[] itemUpdates)
        {
            if (itemUpdates == null || !itemUpdates.Any())
                throw new ValidationException("No items to update");

            // Validate all quantities are positive
            foreach (var update in itemUpdates)
            {
                if (update.NewQuantity <= 0)
                    throw new ValidationException("Quantity must be greater than zero");
            }

            try
            {
                // Find the user's pending order
                var pendingOrder = await _unitOfWork.Repository<Order>()
                    .IncludeNested(query =>
                        query.Include(o => o.SellOrder)
                             .ThenInclude(so => so.SellOrderDetails)
                             .Include(o => o.RentOrder)
                             .ThenInclude(ro => ro.RentOrderDetails))
                    .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == OrderStatus.Pending && !o.IsDelete);

                if (pendingOrder == null)
                    throw new NotFoundException("No pending order found");

                return await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    decimal totalPriceDifference = 0;
                    decimal sellSubTotalDifference = 0;
                    decimal rentSubTotalDifference = 0;

                    // First, validate all updates to ensure we can complete the transaction
                    foreach (var update in itemUpdates)
                    {
                        if (update.IsSellItem)
                        {
                            // Find the sell order detail
                            var detail = pendingOrder.SellOrder?.SellOrderDetails
                                .FirstOrDefault(d => d.SellOrderDetailId == update.OrderDetailId && !d.IsDelete);

                            if (detail == null)
                                throw new NotFoundException($"Order detail with ID {update.OrderDetailId} not found");

                            // Check inventory if it's an ingredient
                            if (detail.IngredientId.HasValue)
                            {
                                var ingredient = await _ingredientService.GetIngredientByIdAsync(detail.IngredientId.Value);

                                // Calculate how many more we need
                                int quantityDifference = update.NewQuantity - detail.Quantity;

                                if (quantityDifference > 0 && ingredient.Quantity < quantityDifference)
                                    throw new ValidationException($"Only {ingredient.Quantity} of {ingredient.Name} is available");
                            }
                        }
                        else
                        {
                            // Find the rent order detail
                            var detail = pendingOrder.RentOrder?.RentOrderDetails
                                .FirstOrDefault(d => d.RentOrderDetailId == update.OrderDetailId && !d.IsDelete);

                            if (detail == null)
                                throw new NotFoundException($"Order detail with ID {update.OrderDetailId} not found");

                            // For utensils, check inventory
                            if (detail.UtensilId.HasValue)
                            {
                                var utensil = await _utensilService.GetUtensilByIdAsync(detail.UtensilId.Value);

                                // Calculate how many more we need
                                int quantityDifference = update.NewQuantity - detail.Quantity;

                                if (quantityDifference > 0 && utensil.Quantity < quantityDifference)
                                    throw new ValidationException($"Only {utensil.Quantity} of {utensil.Name} is available");
                            }
                            else if (detail.HotpotInventoryId.HasValue)
                            {
                                // Hotpot inventory items are individual units, so we can't change quantity
                                throw new ValidationException("Cannot change quantity for individual hotpot inventory items");
                            }
                        }
                    }

                    // Now process all updates
                    foreach (var update in itemUpdates)
                    {
                        if (update.IsSellItem)
                        {
                            // Find the sell order detail
                            var detail = pendingOrder.SellOrder?.SellOrderDetails
                                .FirstOrDefault(d => d.SellOrderDetailId == update.OrderDetailId && !d.IsDelete);

                            // Update inventory if it's an ingredient
                            if (detail.IngredientId.HasValue)
                            {
                                int quantityDifference = update.NewQuantity - detail.Quantity;

                                if (quantityDifference != 0)
                                {
                                    await _ingredientService.UpdateIngredientQuantityAsync(
                                        detail.IngredientId.Value, -quantityDifference);
                                }
                            }

                            // Calculate price difference
                            decimal priceDifference = detail.UnitPrice * (update.NewQuantity - detail.Quantity);
                            sellSubTotalDifference += priceDifference;
                            totalPriceDifference += priceDifference;

                            // Update quantity
                            detail.Quantity = update.NewQuantity;
                            await _unitOfWork.Repository<SellOrderDetail>().Update(detail, detail.SellOrderDetailId);
                        }
                        else
                        {
                            // Find the rent order detail
                            var detail = pendingOrder.RentOrder?.RentOrderDetails
                                .FirstOrDefault(d => d.RentOrderDetailId == update.OrderDetailId && !d.IsDelete);

                            // For utensils, update inventory
                            if (detail.UtensilId.HasValue)
                            {
                                int quantityDifference = update.NewQuantity - detail.Quantity;

                                if (quantityDifference != 0)
                                {
                                    await _utensilService.UpdateUtensilQuantityAsync(
                                        detail.UtensilId.Value, -quantityDifference);
                                }

                                // Calculate price difference
                                decimal priceDifference = detail.RentalPrice * (update.NewQuantity - detail.Quantity);
                                rentSubTotalDifference += priceDifference;
                                totalPriceDifference += priceDifference;

                                // Update quantity
                                detail.Quantity = update.NewQuantity;
                                await _unitOfWork.Repository<RentOrderDetail>().Update(detail, detail.RentOrderDetailId);
                            }
                        }
                    }

                    // Update subtotals
                    if (pendingOrder.HasSellItems && sellSubTotalDifference != 0)
                    {
                        pendingOrder.SellOrder.SubTotal += sellSubTotalDifference;
                        await _unitOfWork.Repository<SellOrder>().Update(pendingOrder.SellOrder, pendingOrder.SellOrder.OrderId);
                    }

                    if (pendingOrder.HasRentItems && rentSubTotalDifference != 0)
                    {
                        pendingOrder.RentOrder.SubTotal += rentSubTotalDifference;
                        await _unitOfWork.Repository<RentOrder>().Update(pendingOrder.RentOrder, pendingOrder.RentOrder.OrderId);
                    }

                    // Recalculate total price
                    decimal newTotal = 0;

                    if (pendingOrder.HasSellItems)
                    {
                        newTotal += pendingOrder.SellOrder.SubTotal;
                    }

                    if (pendingOrder.HasRentItems)
                    {
                        newTotal += pendingOrder.RentOrder.SubTotal;
                    }

                    // Apply discount if any
                    if (pendingOrder.DiscountId.HasValue)
                    {
                        var discount = await _discountService.GetByIdAsync(pendingOrder.DiscountId.Value);
                        if (discount != null && await _discountService.IsDiscountValidAsync(pendingOrder.DiscountId.Value))
                        {
                            newTotal = newTotal * (1 - (discount.DiscountPercentage / 100m));
                        }
                    }

                    pendingOrder.TotalPrice = newTotal;
                    await _unitOfWork.Repository<Order>().Update(pendingOrder, pendingOrder.OrderId);
                    await _unitOfWork.CommitAsync();

                    // Update payment records if needed
                    var payment = await _unitOfWork.Repository<Payment>()
                        .FindAsync(p => p.OrderId == pendingOrder.OrderId && p.Status == PaymentStatus.Pending && !p.IsDelete);

                    if (payment != null)
                    {
                        payment.Price = newTotal;
                        await _unitOfWork.Repository<Payment>().Update(payment, payment.PaymentId);
                        await _unitOfWork.CommitAsync();
                    }

                    // Reload order with all related entities
                    return await GetByIdAsync(pendingOrder.OrderId);
                });
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cart items quantity");
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
                if (request.DiscountId.HasValue && request.DiscountId != order.DiscountId)
                {
                    var discount = await _discountService.GetByIdAsync(request.DiscountId.Value);
                    if (discount == null)
                        throw new ValidationException($"Discount with ID {request.DiscountId} not found");

                    // Validate discount is still valid
                    if (!await _discountService.IsDiscountValidAsync(request.DiscountId.Value))
                        throw new ValidationException("The selected discount is not valid or has expired");

                    // Calculate new total price with discount
                    decimal basePrice = order.TotalPrice;
                    if (order.DiscountId.HasValue)
                    {
                        // Remove old discount first
                        var oldDiscount = await _discountService.GetByIdAsync(order.DiscountId.Value);
                        if (oldDiscount != null)
                        {
                            basePrice = basePrice / (1 - (decimal)(oldDiscount.DiscountPercentage / 100));
                        }
                    }

                    // Apply new discount
                    order.TotalPrice = basePrice - (basePrice * (decimal)(discount.DiscountPercentage / 100));
                    order.DiscountId = request.DiscountId;
                }
                else if (request.DiscountId == null && order.DiscountId.HasValue)
                {
                    // Remove discount
                    var oldDiscount = await _discountService.GetByIdAsync(order.DiscountId.Value);
                    if (oldDiscount != null)
                    {
                        // Restore original price
                        order.TotalPrice = order.TotalPrice / (1 - (decimal)(oldDiscount.DiscountPercentage / 100));
                    }

                    order.DiscountId = null;
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
                    // Handle sellable items
                    if (order.SellOrder != null)
                    {
                        foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                        {
                            if (detail.IngredientId.HasValue)
                            {
                                // Return ingredient quantity
                                await _ingredientService.UpdateIngredientQuantityAsync(
                                    detail.IngredientId.Value,
                                    detail.Quantity);
                            }
                        }
                    }

                    // Handle rentable items
                    if (order.RentOrder != null)
                    {
                        foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                        {
                            if (detail.UtensilId.HasValue)
                            {
                                await _utensilService.UpdateUtensilQuantityAsync(detail.UtensilId.Value, detail.Quantity);
                            }
                            else if (detail.HotpotInventoryId.HasValue)
                            {
                                // Update hotpot inventory status back to Available
                                var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                    .GetById(detail.HotpotInventoryId.Value);

                                if (hotpotInventory != null)
                                {
                                    hotpotInventory.Status = HotpotStatus.Available; // Set to available
                                    await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                                    await _unitOfWork.CommitAsync();
                                }
                            }
                        }
                    }

                    // Cancel payment if exists and pending
                    var payment = await _paymentService.GetPaymentByOrderIdAsync(id);
                    if (payment != null && payment.Status == PaymentStatus.Pending)
                    {
                        await _paymentService.UpdatePaymentStatusAsync(payment.PaymentId, PaymentStatus.Cancelled);
                    }
                }
                // If order is completed, update hotpot inventory status
                else if (status == OrderStatus.Completed)
                {
                    if (order.RentOrder != null)
                    {
                        // Update ActualReturnDate in RentOrder
                        order.RentOrder.ActualReturnDate = DateTime.Now;
                        await _unitOfWork.Repository<RentOrder>().Update(order.RentOrder, order.OrderId);
                        await _unitOfWork.CommitAsync();

                        foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue))
                        {
                            var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                .GetById(detail.HotpotInventoryId.Value);

                            if (hotpotInventory != null)
                            {
                                // Update hotpot status to Available after maintenance
                                hotpotInventory.Status = HotpotStatus.Available; // Set to available
                                                               // Update last maintain date on the hotpot itself
                                if (hotpotInventory.Hotpot != null)
                                {
                                    hotpotInventory.Hotpot.LastMaintainDate = DateTime.Now;
                                    await _unitOfWork.Repository<Hotpot>().Update(hotpotInventory.Hotpot, hotpotInventory.Hotpot.HotpotId);
                                }
                                await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                                await _unitOfWork.CommitAsync();
                            }
                        }
                    }
                }
                // If order is delivered, update hotpot inventory status to InUse
                else if (status == OrderStatus.Delivered)
                {
                    if (order.RentOrder != null)
                    {
                        foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue))
                        {
                            var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                .GetById(detail.HotpotInventoryId.Value);

                            if (hotpotInventory != null)
                            {
                                hotpotInventory.Status = HotpotStatus.Rented; // Set to in use
                                await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                                await _unitOfWork.CommitAsync();
                            }
                        }
                    }
                }
                // If order is returning, update hotpot inventory status to Maintenance
                else if (status == OrderStatus.Returning)
                {
                    if (order.RentOrder != null)
                    {
                        foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue))
                        {
                            var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                .GetById(detail.HotpotInventoryId.Value);

                            if (hotpotInventory != null)
                            {
                                hotpotInventory.Status = HotpotStatus.Rented; // Set to maintenance
                                await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                                await _unitOfWork.CommitAsync();
                            }
                        }
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

                // Return inventory quantities for sellable items
                if (order.SellOrder != null)
                {
                    foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                    {
                        if (detail.IngredientId.HasValue)
                        {
                            // Return ingredient quantity
                            await _ingredientService.UpdateIngredientQuantityAsync(
                                detail.IngredientId.Value,
                                detail.Quantity);
                        }
                    }
                }

                // Return inventory quantities for rentable items
                if (order.RentOrder != null)
                {
                    foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                    {
                        if (detail.UtensilId.HasValue)
                        {
                            await _utensilService.UpdateUtensilQuantityAsync(detail.UtensilId.Value, detail.Quantity);
                        }
                        else if (detail.HotpotInventoryId.HasValue)
                        {
                            // Update hotpot inventory status back to Available
                            var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                .GetById(detail.HotpotInventoryId.Value);

                            if (hotpotInventory != null)
                            {
                                hotpotInventory.Status = HotpotStatus.Available; // Set to available
                                await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                                await _unitOfWork.CommitAsync();
                            }
                        }
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

        public Task<IEnumerable<Order>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
