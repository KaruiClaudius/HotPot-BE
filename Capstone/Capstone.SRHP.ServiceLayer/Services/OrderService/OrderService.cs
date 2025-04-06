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
                    .Include(o => o.Payments)
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
                    query = query.Where(o => o.Payments.Any(p => p.Status == pmtStatus));
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


        public async Task<Order> GetByIdAsync(int orderId)
        {
            try
            {
                var order = await _unitOfWork.Repository<Order>()
                        .IncludeNested(query => query
                            .Include(o => o.User)
                            .Include(o => o.Discount)
                            .Include(o => o.Payments)
                            .Include(o => o.SellOrder)
                                .ThenInclude(so => so.SellOrderDetails)
                                    .ThenInclude(sod => sod.Ingredient)
                            .Include(o => o.SellOrder)
                                .ThenInclude(so => so.SellOrderDetails)
                                    .ThenInclude(sod => sod.Customization)
                            .Include(o => o.SellOrder)
                                .ThenInclude(so => so.SellOrderDetails)
                                    .ThenInclude(sod => sod.Combo)
                            .Include(o => o.RentOrder)
                                .ThenInclude(ro => ro.RentOrderDetails)
                                    .ThenInclude(rod => rod.Utensil)
                            .Include(o => o.RentOrder)
                                .ThenInclude(ro => ro.RentOrderDetails)
                                    .ThenInclude(rod => rod.HotpotInventory)
                                        .ThenInclude(hi => hi.Hotpot))
                        .FirstOrDefaultAsync(o => o.OrderId == orderId && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Order with ID {orderId} not found");

                return order;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving order {OrderId}", orderId);
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
                            query.Include(o => o.User)
                                 .Include(o => o.Discount)
                                 .Include(o => o.Payments)
                                 .Include(o => o.SellOrder)
                                     .ThenInclude(so => so.SellOrderDetails)
                                     .ThenInclude(sod => sod.Ingredient)
                                 .Include(o => o.SellOrder)
                                     .ThenInclude(so => so.SellOrderDetails)
                                     .ThenInclude(sod => sod.Customization)
                                 .Include(o => o.SellOrder)
                                     .ThenInclude(so => so.SellOrderDetails)
                                     .ThenInclude(sod => sod.Combo)
                                 .Include(o => o.RentOrder)
                                     .ThenInclude(ro => ro.RentOrderDetails)    
                                 .Include(o => o.RentOrder)
                                     .ThenInclude(ro => ro.RentOrderDetails)
                                     .ThenInclude(rod => rod.Utensil)
                                 .Include(o => o.RentOrder)
                                     .ThenInclude(ro => ro.RentOrderDetails)
                                         .ThenInclude(rod => rod.HotpotInventory)
                                            .ThenInclude(hi => hi.Hotpot))
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

        #region create helper
        private async Task<Order> AddToExistingOrderAsync(Order existingOrder, CreateOrderRequest request, int userId)
        {
            // Process items
            foreach (var item in request.Items)
            {
                // Process each item type
                if (item.HotpotID.HasValue && item.HotpotID > 0)
                {
                    await ProcessHotpotItem(existingOrder, item);
                }
                else if (item.IngredientID.HasValue && item.IngredientID > 0)
                {
                    await ProcessIngredientItem(existingOrder, item);
                }
                else if (item.UtensilID.HasValue && item.UtensilID > 0)
                {
                    await ProcessUtensilItem(existingOrder, item);
                }
                else if (item.CustomizationID.HasValue && item.CustomizationID > 0)
                {
                    await ProcessCustomizationItem(existingOrder, item);
                }
                else if (item.ComboID.HasValue && item.ComboID > 0)
                {
                    await ProcessComboItem(existingOrder, item);
                }
            }

            // Calculate total price
            await CalculateOrderTotalPrice(existingOrder);

            // Update order
            _unitOfWork.Repository<Order>().Update(existingOrder, existingOrder.OrderId);
            await _unitOfWork.CommitAsync();

            return existingOrder;
        }

        private async Task<Order> CreateNewOrderAsync(CreateOrderRequest request, int userId)
        {
            // Get user's default address
            var user = await _unitOfWork.Repository<User>().GetById(userId);
            string address = user?.Address ?? "To be provided";

            // Create new order
            var order = new Order
            {
                UserId = userId,
                Address = address, // Use user's default address
                Notes = null, // No notes initially
                Status = OrderStatus.Pending,
                DiscountId = null, // No discount initially
                SellOrder = new SellOrder
                {
                    SellOrderDetails = new List<SellOrderDetail>()
                },
                RentOrder = new RentOrder
                {
                    RentOrderDetails = new List<RentOrderDetail>()
                }
            };

            // Add order to database
            await _unitOfWork.Repository<Order>().InsertAsync(order);
            await _unitOfWork.CommitAsync();

            // Process items
            foreach (var item in request.Items)
            {
                // Process each item type
                if (item.HotpotID.HasValue && item.HotpotID > 0)
                {
                    await ProcessHotpotItem(order, item);
                }
                else if (item.IngredientID.HasValue && item.IngredientID > 0)
                {
                    await ProcessIngredientItem(order, item);
                }
                else if (item.UtensilID.HasValue && item.UtensilID > 0)
                {
                    await ProcessUtensilItem(order, item);
                }
                else if (item.CustomizationID.HasValue && item.CustomizationID > 0)
                {
                    await ProcessCustomizationItem(order, item);
                }
                else if (item.ComboID.HasValue && item.ComboID > 0)
                {
                    await ProcessComboItem(order, item);
                }
            }

            // Calculate total price
            await CalculateOrderTotalPrice(order);

            // Update order with calculated price
            _unitOfWork.Repository<Order>().Update(order, order.OrderId);
            await _unitOfWork.CommitAsync();

            return order;
        }


        private async Task ProcessHotpotItem(Order order, OrderItemRequest item)
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

            // Set rental dates if not already set
            DateTime rentalStartDate = DateTime.Now;
            DateTime expectedReturnDate = DateTime.Now.AddDays(2); // Default rental period

            // Ensure RentOrder exists
            if (order.RentOrder == null)
            {
                order.RentOrder = new RentOrder
                {
                    OrderId = order.OrderId,
                    SubTotal = 0,
                    HotpotDeposit = 0,
                    RentalStartDate = rentalStartDate,
                    ExpectedReturnDate = expectedReturnDate,
                    RentOrderDetails = new List<RentOrderDetail>()
                };
                await _unitOfWork.Repository<RentOrder>().InsertAsync(order.RentOrder);
                await _unitOfWork.CommitAsync();
            }

            decimal additionalHotpotDeposit = 0;

            // Create a separate order detail for each hotpot inventory item
            foreach (var hotpotInventory in availableHotpots)
            {
                // Update hotpot quantity
                if (hotpotInventory.Hotpot != null)
                {
                    hotpotInventory.Hotpot.Quantity -= 1;
                    // If you need to update the Hotpot entity, do it separately
                    // await _unitOfWork.Repository<Hotpot>().Update(hotpotInventory.Hotpot, hotpotInventory.Hotpot.HotpotId);
                }

                // Update hotpot inventory status
                hotpotInventory.Status = HotpotStatus.Rented;

                // Fix: Use the correct primary key (HotPotInventoryId)
                await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);

                // Create rent order detail with reference to specific hotpot inventory
                var orderDetail = new RentOrderDetail
                {
                    OrderId = order.OrderId,
                    Quantity = 1, // Each hotpot inventory item is a single unit
                    RentalPrice = hotpot.Price,
                    HotpotInventoryId = hotpotInventory.HotPotInventoryId
                };

                await _unitOfWork.Repository<RentOrderDetail>().InsertAsync(orderDetail);

                // Add to order's rent order details
                order.RentOrder.RentOrderDetails.Add(orderDetail);

                // Update subtotal
                order.RentOrder.SubTotal += hotpot.Price;

                // Calculate hotpot deposit (70% of hotpot price)
                additionalHotpotDeposit += hotpot.Price * 0.7m;
            }

            // Update hotpot deposit
            order.RentOrder.HotpotDeposit += additionalHotpotDeposit;

            // Update order flags
            order.HasRentItems = true;

            // Update rent order
            await _unitOfWork.Repository<RentOrder>().Update(order.RentOrder, order.RentOrder.OrderId);
            await _unitOfWork.CommitAsync();
        }

        private async Task ProcessIngredientItem(Order order, OrderItemRequest item)
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

            // Ensure SellOrder exists
            if (order.SellOrder == null)
            {
                order.SellOrder = new SellOrder
                {
                    OrderId = order.OrderId,
                    SubTotal = 0,
                    SellOrderDetails = new List<SellOrderDetail>()
                };
                await _unitOfWork.Repository<SellOrder>().InsertAsync(order.SellOrder);
                await _unitOfWork.CommitAsync();
            }

            // Check if this ingredient is already in the order
            var existingDetail = order.SellOrder.SellOrderDetails
                .FirstOrDefault(d => d.IngredientId == item.IngredientID && !d.IsDelete);

            if (existingDetail != null)
            {
                // Update existing detail
                existingDetail.Quantity += (int)item.Quantity;

                // Fix: Use the correct primary key (SellOrderDetailId)
                await _unitOfWork.Repository<SellOrderDetail>().Update(existingDetail, existingDetail.SellOrderDetailId);
            }
            else
            {
                // Add new detail
                var orderDetail = new SellOrderDetail
                {
                    OrderId = order.OrderId,
                    Quantity = (int)item.Quantity,
                    UnitPrice = latestPrice,
                    IngredientId = item.IngredientID
                };

                await _unitOfWork.Repository<SellOrderDetail>().InsertAsync(orderDetail);

                // Add to order's sell order details
                order.SellOrder.SellOrderDetails.Add(orderDetail);
            }

            // Update subtotal
            order.SellOrder.SubTotal += latestPrice * (int)item.Quantity;

            // Update order flags
            order.HasSellItems = true;

            // Update sell order
            await _unitOfWork.Repository<SellOrder>().Update(order.SellOrder, order.SellOrder.OrderId);
            await _unitOfWork.CommitAsync();

            // Update ingredient quantity
            await _ingredientService.UpdateIngredientQuantityAsync(
                item.IngredientID.Value,
                -(int)item.Quantity);
        }

        private async Task ProcessUtensilItem(Order order, OrderItemRequest item)
        {
            var utensil = await _utensilService.GetUtensilByIdAsync(item.UtensilID.Value);
            if (utensil == null || !utensil.Status || utensil.Quantity < item.Quantity)
                throw new ValidationException($"Utensil with ID {item.UtensilID} is not available in the requested quantity");

            // Set rental dates if not already set
            DateTime rentalStartDate = DateTime.Now;
            DateTime expectedReturnDate = DateTime.Now.AddDays(7); // Default rental period

            // Ensure RentOrder exists
            if (order.RentOrder == null)
            {
                order.RentOrder = new RentOrder
                {
                    OrderId = order.OrderId,
                    SubTotal = 0,
                    HotpotDeposit = 0,
                    RentalStartDate = rentalStartDate,
                    ExpectedReturnDate = expectedReturnDate,
                    RentOrderDetails = new List<RentOrderDetail>()
                };
                await _unitOfWork.Repository<RentOrder>().InsertAsync(order.RentOrder);
                await _unitOfWork.CommitAsync();
            }

            // Check if this utensil is already in the order
            var existingDetail = order.RentOrder.RentOrderDetails
                .FirstOrDefault(d => d.UtensilId == item.UtensilID && !d.IsDelete);

            if (existingDetail != null)
            {
                // Update existing detail
                existingDetail.Quantity += (int)item.Quantity;

                // Fix: Use the correct primary key (RentOrderDetailId)
                await _unitOfWork.Repository<RentOrderDetail>().Update(existingDetail, existingDetail.RentOrderDetailId);
            }
            else
            {
                // Add new detail
                var orderDetail = new RentOrderDetail
                {
                    OrderId = order.OrderId,
                    Quantity = (int)item.Quantity,
                    RentalPrice = utensil.Price,
                    UtensilId = item.UtensilID
                };

                await _unitOfWork.Repository<RentOrderDetail>().InsertAsync(orderDetail);

                // Add to order's rent order details
                order.RentOrder.RentOrderDetails.Add(orderDetail);
            }

            // Update subtotal
            order.RentOrder.SubTotal += utensil.Price * (int)item.Quantity;

            // Update order flags
            order.HasRentItems = true;

            // Update rent order
            await _unitOfWork.Repository<RentOrder>().Update(order.RentOrder, order.RentOrder.OrderId);
            await _unitOfWork.CommitAsync();

            // Update utensil quantity
            await _utensilService.UpdateUtensilQuantityAsync(item.UtensilID.Value, (int)-item.Quantity);
        }

        private async Task ProcessCustomizationItem(Order order, OrderItemRequest item)
        {
            var customization = await _customizationService.GetByIdAsync(item.CustomizationID.Value);
            if (customization == null)
                throw new ValidationException($"Customization with ID {item.CustomizationID} not found");

            // Verify the customization belongs to the current user
            if (customization.UserId != order.UserId)
                throw new ValidationException($"Customization with ID {item.CustomizationID} does not belong to the current user");

            // Ensure SellOrder exists
            if (order.SellOrder == null)
            {
                order.SellOrder = new SellOrder
                {
                    OrderId = order.OrderId,
                    SubTotal = 0,
                    SellOrderDetails = new List<SellOrderDetail>()
                };
                await _unitOfWork.Repository<SellOrder>().InsertAsync(order.SellOrder);
                await _unitOfWork.CommitAsync();
            }

            // Check if this customization is already in the order
            var existingDetail = order.SellOrder.SellOrderDetails
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
                    OrderId = order.OrderId,
                    Quantity = (int)item.Quantity,
                    UnitPrice = customization.TotalPrice,
                    CustomizationId = item.CustomizationID
                };

                await _unitOfWork.Repository<SellOrderDetail>().InsertAsync(orderDetail);

                // Add to order's sell order details
                order.SellOrder.SellOrderDetails.Add(orderDetail);
            }

            // Update subtotal
            order.SellOrder.SubTotal += customization.TotalPrice * (int)item.Quantity;

            // Update order flags
            order.HasSellItems = true;

            // Update sell order
            await _unitOfWork.Repository<SellOrder>().Update(order.SellOrder, order.SellOrder.OrderId);
            await _unitOfWork.CommitAsync();
        }

        private async Task ProcessComboItem(Order order, OrderItemRequest item)
        {
            var combo = await _comboService.GetByIdAsync(item.ComboID.Value);
            if (combo == null)
                throw new ValidationException($"Combo with ID {item.ComboID} not found");

            // Ensure SellOrder exists
            if (order.SellOrder == null)
            {
                order.SellOrder = new SellOrder
                {
                    OrderId = order.OrderId,
                    SubTotal = 0,
                    SellOrderDetails = new List<SellOrderDetail>()
                };
                await _unitOfWork.Repository<SellOrder>().InsertAsync(order.SellOrder);
                await _unitOfWork.CommitAsync();
            }

            // Check if this combo is already in the order
            var existingDetail = order.SellOrder.SellOrderDetails
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
                    OrderId = order.OrderId,
                    Quantity = (int)item.Quantity,
                    UnitPrice = combo.BasePrice,
                    ComboId = item.ComboID
                };

                await _unitOfWork.Repository<SellOrderDetail>().InsertAsync(orderDetail);

                // Add to order's sell order details
                order.SellOrder.SellOrderDetails.Add(orderDetail);
            }

            // Update subtotal
            order.SellOrder.SubTotal += combo.BasePrice * (int)item.Quantity;

            // Update order flags
            order.HasSellItems = true;

            // Update sell order
            await _unitOfWork.Repository<SellOrder>().Update(order.SellOrder, order.SellOrder.OrderId);
            await _unitOfWork.CommitAsync();
        }

        #endregion 

        private async Task CalculateOrderTotalPrice(Order order)
        {
            decimal totalPrice = 0;

            // Calculate sell order subtotal
            if (order.SellOrder != null)
            {
                // Recalculate sell order subtotal to ensure accuracy
                decimal sellSubTotal = 0;
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    sellSubTotal += detail.UnitPrice * detail.Quantity;
                }

                order.SellOrder.SubTotal = sellSubTotal;
                totalPrice += sellSubTotal;
            }

            // Calculate rent order subtotal
            if (order.RentOrder != null)
            {
                // Recalculate rent order subtotal to ensure accuracy
                decimal rentSubTotal = 0;
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    rentSubTotal += detail.RentalPrice * detail.Quantity;
                }

                order.RentOrder.SubTotal = rentSubTotal;
                totalPrice += rentSubTotal;

                // Add hotpot deposit to total price
                totalPrice += order.RentOrder.HotpotDeposit;
            }

            // Apply discount if applicable
            if (order.DiscountId.HasValue)
            {
                var discount = await _discountService.GetByIdAsync(order.DiscountId.Value);
                if (discount != null && await _discountService.IsDiscountValidAsync(order.DiscountId.Value))
                {
                    totalPrice = totalPrice * (1 - (discount.DiscountPercentage / 100m));
                }
            }

            // Update order total price
            order.TotalPrice = totalPrice;
        }

        public async Task<Order> UpdateCartItemsQuantityAsync(int userId, CartItemUpdate[] itemUpdates)
        {
            if (itemUpdates == null || !itemUpdates.Any())
                throw new ValidationException("No items to update");

            // Validate all quantities are non-negative (allowing 0 for removal)
            foreach (var update in itemUpdates)
            {
                if (update.NewQuantity < 0)
                    throw new ValidationException("Quantity cannot be negative");
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
                    // First, validate all updates to ensure we can complete the transaction
                    foreach (var update in itemUpdates)
                    {
                        // Skip validation for items being removed (quantity = 0)
                        if (update.NewQuantity == 0)
                            continue;

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

                            if (detail == null)
                                throw new NotFoundException($"Order detail with ID {update.OrderDetailId} not found");

                            // Handle item removal (quantity = 0)
                            if (update.NewQuantity == 0)
                            {
                                // Return inventory if it's an ingredient
                                if (detail.IngredientId.HasValue)
                                {
                                    await _ingredientService.UpdateIngredientQuantityAsync(
                                        detail.IngredientId.Value, detail.Quantity);
                                }

                                // Soft delete the detail
                                detail.SoftDelete();
                            }
                            else
                            {
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

                                // Update quantity
                                detail.Quantity = update.NewQuantity;
                            }

                            // Update the detail in the database
                            await _unitOfWork.Repository<SellOrderDetail>().Update(detail, detail.SellOrderDetailId);
                        }
                        else
                        {
                            // Find the rent order detail
                            var detail = pendingOrder.RentOrder?.RentOrderDetails
                                .FirstOrDefault(d => d.RentOrderDetailId == update.OrderDetailId && !d.IsDelete);

                            if (detail == null)
                                throw new NotFoundException($"Order detail with ID {update.OrderDetailId} not found");

                            // Handle item removal (quantity = 0)
                            if (update.NewQuantity == 0)
                            {
                                // Return inventory if it's a utensil
                                if (detail.UtensilId.HasValue)
                                {
                                    await _utensilService.UpdateUtensilQuantityAsync(
                                        detail.UtensilId.Value, detail.Quantity);
                                }
                                else if (detail.HotpotInventoryId.HasValue)
                                {
                                    // For hotpot inventory, update status back to Available
                                    var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                        .GetById(detail.HotpotInventoryId.Value);

                                    if (hotpotInventory != null)
                                    {
                                        hotpotInventory.Status = HotpotStatus.Available;
                                        await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                                    }
                                }

                                // Soft delete the detail
                                detail.SoftDelete();
                            }
                            else
                            {
                                // For utensils, update inventory
                                if (detail.UtensilId.HasValue)
                                {
                                    int quantityDifference = update.NewQuantity - detail.Quantity;

                                    if (quantityDifference != 0)
                                    {
                                        await _utensilService.UpdateUtensilQuantityAsync(
                                            detail.UtensilId.Value, -quantityDifference);
                                    }

                                    // Update quantity
                                    detail.Quantity = update.NewQuantity;
                                }
                            }

                            // Update the detail in the database
                            await _unitOfWork.Repository<RentOrderDetail>().Update(detail, detail.RentOrderDetailId);
                        }
                    }

                    // Update HasSellItems and HasRentItems flags
                    pendingOrder.HasSellItems = pendingOrder.SellOrder?.SellOrderDetails?.Any(d => !d.IsDelete) ?? false;
                    pendingOrder.HasRentItems = pendingOrder.RentOrder?.RentOrderDetails?.Any(d => !d.IsDelete) ?? false;

                    // Use the CalculateOrderTotalPrice method for consistency
                    await CalculateOrderTotalPrice(pendingOrder);

                    // Update the order
                    _unitOfWork.Repository<Order>().Update(pendingOrder, pendingOrder.OrderId);
                    await _unitOfWork.CommitAsync();

                    // Update payment records if needed
                    var payment = await _unitOfWork.Repository<Payment>()
                        .FindAsync(p => p.OrderId == pendingOrder.OrderId && p.Status == PaymentStatus.Pending && !p.IsDelete);

                    if (payment != null)
                    {
                        payment.Price = pendingOrder.TotalPrice;
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

                if (!string.IsNullOrWhiteSpace(request.Notes))
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
