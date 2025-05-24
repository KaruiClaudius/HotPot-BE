using Azure.Core;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.RepositoryLayer.UnitOfWork;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
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
        private readonly INotificationService _notificationService;


        public OrderService(
            IUnitOfWork unitOfWork,
            IDiscountService discountService,
            IUtensilService utensilService,
            IIngredientService ingredientService,
            IHotpotService hotpotService,
            ICustomizationService customizationService,
            IComboService comboService,
            IPaymentService paymentService,
            ILogger<OrderService> logger,
            INotificationService notificationService)
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
            _notificationService = notificationService;
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
                    .Include(o => o.SellOrder)
                        .ThenInclude(ro => ro.SellOrderDetails)
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
                            .Include(o => o.SellOrder)
                                .ThenInclude(ro => ro.SellOrderDetails)
                                    .ThenInclude(od => od.Utensil)
                            .Include(o => o.RentOrder)
                                .ThenInclude(ro => ro.RentOrderDetails)
                                    .ThenInclude(rod => rod.HotpotInventory)
                                        .ThenInclude(hi => hi.Hotpot))
                        .FirstOrDefaultAsync(o => o.OrderId == orderId && !o.IsDelete);

                if (order == null)
                    throw new NotFoundException($"Không tìm thấy đơn hàng với ID {orderId}");

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
                    throw new ValidationException("Đơn hàng phải chứa ít nhất một mặt hàng");

                // Execute in transaction to ensure consistency
                return await _unitOfWork.ExecuteInTransactionAsync<Order>(async () =>
                {
                    // Check if user already has a pending order (cart)
                    // Use a simpler query to avoid duplicate entries
                    var existingPendingOrder = await _unitOfWork.Repository<Order>()
                        .Include(o => o.User)
                        .Include(o => o.Discount)
                        .Include(o => o.Payments)
                        .Include(o => o.SellOrder)
                        .Include(o => o.RentOrder)
                        .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == OrderStatus.Cart && !o.IsDelete);

                    if (existingPendingOrder != null)
                    {
                        // Load the details separately to avoid duplicates
                        if (existingPendingOrder.SellOrder != null)
                        {
                            // Load SellOrderDetails with a single query
                            var sellOrderDetails = await _unitOfWork.Repository<SellOrderDetail>()
                                .AsQueryable()
                                .Include(d => d.Ingredient)
                                .Include(d => d.Utensil)
                                .Include(d => d.Customization)
                                .Include(d => d.Combo)
                                .Where(d => d.OrderId == existingPendingOrder.OrderId && !d.IsDelete)
                                .ToListAsync();

                            // Assign the loaded details to the order
                            existingPendingOrder.SellOrder.SellOrderDetails = sellOrderDetails;
                        }

                        if (existingPendingOrder.RentOrder != null)
                        {
                            // Load RentOrderDetails with a single query
                            var rentOrderDetails = await _unitOfWork.Repository<RentOrderDetail>()
                                .AsQueryable()
                                .Include(d => d.HotpotInventory)
                                    .ThenInclude(hi => hi.Hotpot)
                                .Where(d => d.OrderId == existingPendingOrder.OrderId && !d.IsDelete)
                                .ToListAsync();

                            // Assign the loaded details to the order
                            existingPendingOrder.RentOrder.RentOrderDetails = rentOrderDetails;
                        }

                        // User has an existing pending order - add items to it
                        return await AddToExistingOrderAsync(existingPendingOrder, request, userId);
                    }
                    else
                    {
                        // No existing pending order - create a new one
                        return await CreateNewOrderAsync(request, userId);
                    }
                },
                ex =>
                {
                    // Only log non-validation exceptions
                    if (!(ex is ValidationException))
                    {
                        _logger.LogError(ex, "Error in transaction while creating or updating order for user {UserId}", userId);
                    }
                });
            }
            catch (ValidationException)
            {
                // Re-throw validation exceptions without additional logging
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating or updating order for user {UserId}", userId);
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
            string address = user?.Address ?? "Sẽ Cung Cấp Sau";

            // Create new order
            var order = new Order
            {
                UserId = userId,
                Address = address, // Use user's default address
                Notes = null, // No notes initially
                Status = OrderStatus.Cart,
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
                throw new ValidationException($"Lẩu với ID {item.HotpotID} hiện không có sẵn");

            // Get all hotpot inventory items of this type
            var allHotpots = await _unitOfWork.Repository<HotPotInventory>()
                .AsQueryable()
                .Where(h => h.HotpotId == item.HotpotID && !h.IsDelete)
                .OrderBy(h => h.Status) // Available first, then Reserved
                .ThenBy(h => h.Status == HotpotStatus.Reserved ? h.UpdatedAt : DateTime.MinValue) // Oldest reservations first
                .ToListAsync();

            // Filter to get available and oldest reserved hotpots
            var availableHotpots = allHotpots
                .Where(h => h.Status == HotpotStatus.Available)
                .ToList();

            var reservedHotpots = allHotpots
                .Where(h => h.Status == HotpotStatus.Reserved)
                .OrderBy(h => h.UpdatedAt) // Oldest reservations first
                .ToList();

            // Determine how many we need from each category
            int neededFromAvailable = Math.Min((int)item.Quantity, availableHotpots.Count);
            int neededFromReserved = (int)item.Quantity - neededFromAvailable;

            // Check if we have enough total hotpots
            if (neededFromAvailable + Math.Min(neededFromReserved, reservedHotpots.Count) < item.Quantity)
                throw new ValidationException($"Chỉ còn {availableHotpots.Count + reservedHotpots.Count} lẩu loại {hotpot.Name} có sẵn");

            // Select the hotpots to use
            var selectedHotpots = availableHotpots.Take(neededFromAvailable)
                .Concat(reservedHotpots.Take(neededFromReserved))
                .ToList();

            // Set rental dates if not already set
            DateTime rentalStartDate = DateTime.UtcNow.AddHours(7);
            DateTime expectedReturnDate = DateTime.UtcNow.AddHours(7).AddDays(3); // Default 3-day rental period

            // Ensure RentOrder exists
            if (order.RentOrder == null)
            {
                order.RentOrder = new RentOrder
                {
                    OrderId = order.OrderId,
                    SubTotal = 0,
                    RentalStartDate = rentalStartDate,
                    ExpectedReturnDate = expectedReturnDate,
                    RentOrderDetails = new List<RentOrderDetail>()
                };
                await _unitOfWork.Repository<RentOrder>().InsertAsync(order.RentOrder);
                await _unitOfWork.CommitAsync();
            }

            decimal additionalHotpotDeposit = 0;

            // Create a separate order detail for each hotpot inventory item
            foreach (var hotpotInventory in selectedHotpots)
            {
                // Update hotpot inventory status to Reserved
                hotpotInventory.Status = HotpotStatus.Reserved;
                hotpotInventory.SetUpdateDate(); // Update the timestamp for reservation age tracking
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

                // Calculate hotpot deposit (70% of hotpot price)
                additionalHotpotDeposit += hotpot.Price * 0.7m;
            }

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
                throw new ValidationException($"Không tìm thấy nguyên liệu với ID {item.IngredientID}");

            // Kiểm tra số lượng yêu cầu có sẵn hay không
            if (ingredient.Quantity < item.Quantity)
                throw new ValidationException($"Chỉ còn {ingredient.Quantity} {ingredient.Name} có sẵn");

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

            // Update order flags
            order.HasSellItems = true;

            // Update sell order
            await _unitOfWork.Repository<SellOrder>().Update(order.SellOrder, order.SellOrder.OrderId);
            await _unitOfWork.CommitAsync();

            // Reserve the ingredient instead of deducting it
            await ReserveInventoryItem(item.IngredientID.Value, (int)item.Quantity, ItemType.Ingredient);
        }

        private async Task ProcessUtensilItem(Order order, OrderItemRequest item)
        {
            var utensil = await _utensilService.GetUtensilByIdAsync(item.UtensilID.Value);
            if (utensil == null || !utensil.Status || utensil.Quantity < item.Quantity)
                throw new ValidationException($"Dụng cụ với ID {item.UtensilID} không có sẵn với số lượng yêu cầu");

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

            // Check if this utensil is already in the order
            var existingDetail = order.SellOrder.SellOrderDetails
                .FirstOrDefault(d => d.UtensilId == item.UtensilID && !d.IsDelete);

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
                    UnitPrice = utensil.Price,
                    UtensilId = item.UtensilID
                };

                await _unitOfWork.Repository<SellOrderDetail>().InsertAsync(orderDetail);

                // Add to order's sell order details
                order.SellOrder.SellOrderDetails.Add(orderDetail);
            }


            // Update order flags
            order.HasSellItems = true;

            // Update sell order
            await _unitOfWork.Repository<SellOrder>().Update(order.SellOrder, order.SellOrder.OrderId);
            await _unitOfWork.CommitAsync();

            // Reserve the utensil instead of deducting it
            await ReserveInventoryItem(item.UtensilID.Value, (int)item.Quantity, ItemType.Utensil);
        }

        private async Task ProcessCustomizationItem(Order order, OrderItemRequest item)
        {
            var customization = await _customizationService.GetByIdAsync(item.CustomizationID.Value);
            if (customization == null)
                throw new ValidationException($"Không tìm thấy tuỳ chỉnh với ID {item.CustomizationID}");

            // Kiểm tra tuỳ chỉnh có thuộc về người dùng hiện tại không
            if (customization.UserId != order.UserId)
                throw new ValidationException($"Tuỳ chỉnh với ID {item.CustomizationID} không thuộc về người dùng hiện tại");


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
                throw new ValidationException($"Không tìm thấy combo với ID {item.ComboID}");

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
                    UnitPrice = combo.TotalPrice,
                    ComboId = item.ComboID
                };

                await _unitOfWork.Repository<SellOrderDetail>().InsertAsync(orderDetail);

                // Add to order's sell order details
                order.SellOrder.SellOrderDetails.Add(orderDetail);
            }


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
                // Get distinct details to avoid counting duplicates
                var distinctDetails = order.SellOrder.SellOrderDetails
                    .Where(d => !d.IsDelete)
                    .GroupBy(d => d.SellOrderDetailId)
                    .Select(g => g.First())
                    .ToList();

                // Log the details for debugging
                _logger.LogInformation($"Order {order.OrderId} has {distinctDetails.Count} distinct sell order details");

                // Check for duplicates
                var duplicateIds = order.SellOrder.SellOrderDetails
                    .Where(d => !d.IsDelete)
                    .GroupBy(d => d.SellOrderDetailId)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToList();

                if (duplicateIds.Any())
                {
                    _logger.LogWarning($"Found {duplicateIds.Count} duplicate sell detail IDs in order {order.OrderId}: {string.Join(", ", duplicateIds)}");
                }

                // Recalculate sell order subtotal using distinct details
                decimal sellSubTotal = 0;
                foreach (var detail in distinctDetails)
                {
                    sellSubTotal += detail.UnitPrice * detail.Quantity;
                }

                order.SellOrder.SubTotal = sellSubTotal;
                totalPrice += sellSubTotal;
            }

            // Calculate rent order subtotal
            if (order.RentOrder != null)
            {
                // Get distinct details to avoid counting duplicates
                var distinctDetails = order.RentOrder.RentOrderDetails
                    .Where(d => !d.IsDelete)
                    .GroupBy(d => d.RentOrderDetailId)
                    .Select(g => g.First())
                    .ToList();

                // Recalculate rent order subtotal using distinct details
                decimal rentSubTotal = 0;
                foreach (var detail in distinctDetails)
                {
                    rentSubTotal += detail.RentalPrice * detail.Quantity;
                }

                order.RentOrder.SubTotal = rentSubTotal;
                totalPrice += rentSubTotal;
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
            // Validate input
            ValidateCartItemUpdates(itemUpdates);

            try
            {
                // Find the user's cart order
                var pendingOrder = await GetUserCartOrder(userId);

                return await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    // Validate all updates first
                    await ValidateAllUpdates(pendingOrder, itemUpdates);

                    // Process all updates
                    await ProcessAllUpdates(pendingOrder, itemUpdates);

                    // Update order flags and total price
                    await UpdateOrderFlagsAndPrice(pendingOrder);

                    // Update payment if needed
                    await UpdatePaymentIfNeeded(pendingOrder);

                    // Reload order with all related entities
                    return await GetByIdAsync(pendingOrder.OrderId);
                },
                ex =>
                {
                    // Only log non-validation exceptions
                    if (!(ex is ValidationException) && !(ex is NotFoundException))
                    {
                        _logger.LogError(ex, "Error in transaction while updating cart items quantity for user {UserId}", userId);
                    }
                });
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (NotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating cart items quantity for user {UserId}", userId);
                throw;
            }
        }

        #region edit quantity helper
        private void ValidateCartItemUpdates(CartItemUpdate[] itemUpdates)
        {
            if (itemUpdates == null || !itemUpdates.Any())
                throw new ValidationException("Không có mặt hàng nào để cập nhật");

            // Kiểm tra tất cả số lượng đều không âm (cho phép 0 để xóa)
            foreach (var update in itemUpdates)
            {
                if (update.NewQuantity < 0)
                    throw new ValidationException("Số lượng không được là số âm");
            }
        }

        private async Task<Order> GetUserCartOrder(int userId)
        {
            var pendingOrder = await _unitOfWork.Repository<Order>()
                .IncludeNested(query =>
                    query.Include(o => o.SellOrder)
                         .ThenInclude(so => so.SellOrderDetails)
                         .Include(o => o.RentOrder)
                         .ThenInclude(ro => ro.RentOrderDetails))
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == OrderStatus.Cart && !o.IsDelete);

            if (pendingOrder == null)
                throw new NotFoundException("Không tìm thấy giỏ hàng");

            return pendingOrder;
        }

        private async Task ValidateAllUpdates(Order pendingOrder, CartItemUpdate[] itemUpdates)
        {
            foreach (var update in itemUpdates)
            {
                // Skip validation for items being removed (quantity = 0)
                if (update.NewQuantity == 0)
                    continue;

                if (update.IsSellItem)
                {
                    await ValidateSellItemUpdate(pendingOrder, update);
                }
                else
                {
                    await ValidateRentItemUpdate(pendingOrder, update);
                }
            }
        }
        private async Task ValidateSellItemUpdate(Order pendingOrder, CartItemUpdate update)
        {
            // Find the sell order detail
            var detail = pendingOrder.SellOrder?.SellOrderDetails
                .FirstOrDefault(d => d.SellOrderDetailId == update.OrderDetailId && !d.IsDelete);

            if (detail == null)
                throw new NotFoundException($"Không tìm thấy chi tiết đơn hàng với ID {update.OrderDetailId}");

            // Check inventory if it's an ingredient
            if (detail.IngredientId.HasValue)
            {
                var ingredient = await _ingredientService.GetIngredientByIdAsync(detail.IngredientId.Value);

                // Get items of this type in other active carts
                var itemsInOtherCarts = await _unitOfWork.Repository<SellOrderDetail>()
                    .FindAll(d => d.IngredientId == detail.IngredientId &&
                                 d.SellOrder.Order.Status == OrderStatus.Cart &&
                                 d.SellOrder.Order.OrderId != pendingOrder.OrderId &&
                                 !d.IsDelete)
                    .SumAsync(d => d.Quantity);

                // Calculate available inventory
                var availableForThisCart = ingredient.Quantity - itemsInOtherCarts;

                // Check if requested quantity exceeds available inventory
                if (update.NewQuantity > availableForThisCart)
                    throw new ValidationException($"Chỉ còn {availableForThisCart} {ingredient.Name} có sẵn");
            }
            // Add check for utensil inventory
            else if (detail.UtensilId.HasValue)
            {
                var utensil = await _utensilService.GetUtensilByIdAsync(detail.UtensilId.Value);

                // Calculate how many more we need
                int quantityDifference = update.NewQuantity - detail.Quantity;

                if (quantityDifference > 0 && utensil.Quantity < quantityDifference)
                    throw new ValidationException($"Chỉ còn {utensil.Quantity} {utensil.Name} có sẵn");
            }
        }

        private async Task ValidateRentItemUpdate(Order pendingOrder, CartItemUpdate update)
        {
            // Find the rent order detail
            var detail = pendingOrder.RentOrder?.RentOrderDetails
                .FirstOrDefault(d => d.RentOrderDetailId == update.OrderDetailId && !d.IsDelete);

            if (detail == null)
                throw new NotFoundException($"Không tìm thấy chi tiết đơn hàng với ID {update.OrderDetailId}");

            if (detail.HotpotInventoryId.HasValue)
            {
                // For hotpot inventory, we need special handling
                var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                    .GetById(detail.HotpotInventoryId.Value);

                if (hotpotInventory == null)
                    throw new NotFoundException($"Không tìm thấy tồn kho lẩu với ID {detail.HotpotInventoryId.Value}");

                // Find all hotpots of the same type in the order
                var allHotpotDetails = pendingOrder.RentOrder.RentOrderDetails
                    .Where(d => d.HotpotInventoryId.HasValue && !d.IsDelete)
                    .ToList();

                var hotpotInventoryIds = allHotpotDetails
                    .Select(d => d.HotpotInventoryId.Value)
                    .ToList();

                var hotpotInventories = await _unitOfWork.Repository<HotPotInventory>()
                    .FindAll(h => hotpotInventoryIds.Contains(h.HotPotInventoryId) && !h.IsDelete)
                    .ToListAsync();

                var sameTypeDetails = allHotpotDetails
                    .Where(d => hotpotInventories.Any(h => h.HotPotInventoryId == d.HotpotInventoryId &&
                                                          h.HotpotId == hotpotInventory.HotpotId))
                    .ToList();

                // Calculate current quantity and how many more we need
                int currentQuantity = sameTypeDetails.Count;
                int quantityDifference = update.NewQuantity - currentQuantity;

                if (quantityDifference > 0)
                {
                    // Check if we have enough available hotpots of the same type
                    var availableHotpots = await _unitOfWork.Repository<HotPotInventory>()
                        .FindAll(h => h.HotpotId == hotpotInventory.HotpotId &&
                                      h.Status == HotpotStatus.Available &&
                                      !h.IsDelete)
                        .Take(quantityDifference)
                        .ToListAsync();

                    if (availableHotpots.Count < quantityDifference)
                        throw new ValidationException($"Chỉ còn {availableHotpots.Count} lẩu loại này có sẵn thêm");
                }
            }
        }

        private async Task ProcessAllUpdates(Order pendingOrder, CartItemUpdate[] itemUpdates)
        {
            foreach (var update in itemUpdates)
            {
                if (update.IsSellItem)
                {
                    // Process sell items
                    await ProcessSellItemUpdate(pendingOrder, update);
                }
                else
                {
                    // Find the rent order detail
                    var detail = pendingOrder.RentOrder?.RentOrderDetails
                        .FirstOrDefault(d => d.RentOrderDetailId == update.OrderDetailId && !d.IsDelete);

                    if (detail == null)
                        throw new NotFoundException($"Không tìm thấy chi tiết đơn hàng với ID {update.OrderDetailId}");

                    if (detail.HotpotInventoryId.HasValue)
                    {
                        // Process hotpot items with special handling
                        await ProcessHotpotUpdate(pendingOrder, update, detail);
                    }
                }
            }
        }

        private async Task UpdateOrderFlagsAndPrice(Order pendingOrder)
        {
            // Update HasSellItems and HasRentItems flags
            pendingOrder.HasSellItems = pendingOrder.SellOrder?.SellOrderDetails?.Any(d => !d.IsDelete) ?? false;
            pendingOrder.HasRentItems = pendingOrder.RentOrder?.RentOrderDetails?.Any(d => !d.IsDelete) ?? false;

            // Use the CalculateOrderTotalPrice method for consistency
            await CalculateOrderTotalPrice(pendingOrder);

            // Update the order
            _unitOfWork.Repository<Order>().Update(pendingOrder, pendingOrder.OrderId);
            await _unitOfWork.CommitAsync();
        }

        private async Task UpdatePaymentIfNeeded(Order pendingOrder)
        {
            // Update payment records if needed
            var payment = await _unitOfWork.Repository<Payment>()
                .FindAsync(p => p.OrderId == pendingOrder.OrderId && p.Status == PaymentStatus.Pending && !p.IsDelete);

            if (payment != null)
            {
                payment.Price = pendingOrder.TotalPrice;
                await _unitOfWork.Repository<Payment>().Update(payment, payment.PaymentId);
                await _unitOfWork.CommitAsync();
            }
        }

        // Helper method for processing hotpot updates
        private async Task ProcessHotpotUpdate(Order pendingOrder, CartItemUpdate update, RentOrderDetail detail)
        {
            // Get the hotpot inventory for the primary detail
            var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                .IncludeNested(query => query.Include(h => h.Hotpot))
                .FirstOrDefaultAsync(h => h.HotPotInventoryId == detail.HotpotInventoryId && !h.IsDelete);

            if (hotpotInventory == null)
                throw new NotFoundException($"Không tìm thấy tồn kho lẩu với ID {detail.HotpotInventoryId.Value}");

            // Step 1: Find all hotpot details of the same type in the order
            var allHotpotDetails = pendingOrder.RentOrder.RentOrderDetails
                .Where(d => d.HotpotInventoryId.HasValue && !d.IsDelete)
                .ToList();

            // Get the hotpot IDs for all details
            var hotpotInventoryIds = allHotpotDetails
                .Select(d => d.HotpotInventoryId.Value)
                .ToList();

            // Get the actual hotpot inventories to check their hotpot type
            var hotpotInventories = await _unitOfWork.Repository<HotPotInventory>()
                .FindAll(h => hotpotInventoryIds.Contains(h.HotPotInventoryId) && !h.IsDelete)
                .ToListAsync();

            // Find all details with the same hotpot type as the one being updated
            var sameTypeDetails = allHotpotDetails
                .Where(d => hotpotInventories.Any(h => h.HotPotInventoryId == d.HotpotInventoryId &&
                                                      h.HotpotId == hotpotInventory.HotpotId))
                .ToList();

            // Step 2: Calculate current quantity (number of same type hotpots)
            int currentQuantity = sameTypeDetails.Count;

            // Step 3: Compare with requested quantity and adjust
            int quantityDifference = update.NewQuantity - currentQuantity;

            if (quantityDifference == 0)
            {
                // No change needed
                return;
            }
            else if (quantityDifference > 0)
            {
                // Need to add more hotpots
                // Get all hotpot inventory items of this type
                var allHotpots = await _unitOfWork.Repository<HotPotInventory>()
                    .AsQueryable()
                    .Where(h => h.HotpotId == hotpotInventory.HotpotId && !h.IsDelete)
                    .OrderBy(h => h.Status) // Available first, then Reserved
                    .ThenBy(h => h.Status == HotpotStatus.Reserved ? h.UpdatedAt : DateTime.MinValue) // Oldest reservations first
                    .ToListAsync();

                // Filter to get available and oldest reserved hotpots
                var availableHotpots = allHotpots
                    .Where(h => h.Status == HotpotStatus.Available)
                    .ToList();

                var reservedHotpots = allHotpots
                    .Where(h => h.Status == HotpotStatus.Reserved &&
                          !pendingOrder.RentOrder.RentOrderDetails.Any(d => d.HotpotInventoryId == h.HotPotInventoryId))
                    .OrderBy(h => h.UpdatedAt) // Oldest reservations first
                    .ToList();

                // Determine how many we need from each category
                int neededFromAvailable = Math.Min(quantityDifference, availableHotpots.Count);
                int neededFromReserved = quantityDifference - neededFromAvailable;

                // Check if we have enough total hotpots
                if (neededFromAvailable + Math.Min(neededFromReserved, reservedHotpots.Count) < quantityDifference)
                    throw new ValidationException($"Chỉ còn {availableHotpots.Count + reservedHotpots.Count} lẩu loại này có sẵn thêm");

                // Select the hotpots to use
                var selectedHotpots = availableHotpots.Take(neededFromAvailable)
                    .Concat(reservedHotpots.Take(neededFromReserved))
                    .ToList();

                // Add each selected hotpot as a new rent order detail
                foreach (var selectedHotpot in selectedHotpots)
                {
                    var newDetail = new RentOrderDetail
                    {
                        OrderId = pendingOrder.OrderId,
                        HotpotInventoryId = selectedHotpot.HotPotInventoryId,
                        Quantity = 1, // Always 1 for hotpot inventory items
                        RentalPrice = hotpotInventory.Hotpot.Price // Use the same price as the original
                    };

                    // Update hotpot status to Reserved
                    selectedHotpot.Status = HotpotStatus.Reserved;
                    selectedHotpot.SetUpdateDate(); // Update the timestamp for reservation age tracking
                    await _unitOfWork.Repository<HotPotInventory>().Update(selectedHotpot, selectedHotpot.HotPotInventoryId);

                    // Add the new detail
                    await _unitOfWork.Repository<RentOrderDetail>().InsertAsync(newDetail);
                    pendingOrder.RentOrder.RentOrderDetails.Add(newDetail);
                }
            }
            else // quantityDifference < 0
            {
                // Need to remove some hotpots
                // Sort by most recently added first (to remove newest ones first)
                var detailsToRemove = sameTypeDetails
                    .OrderByDescending(d => d.CreatedAt)
                    .Take(-quantityDifference)
                    .ToList();

                // Remove the details
                foreach (var detailToRemove in detailsToRemove)
                {
                    // Update hotpot status back to Available
                    var hotpotToRemove = await _unitOfWork.Repository<HotPotInventory>()
                        .GetById(detailToRemove.HotpotInventoryId.Value);

                    if (hotpotToRemove != null)
                    {
                        hotpotToRemove.Status = HotpotStatus.Available;
                        await _unitOfWork.Repository<HotPotInventory>().Update(hotpotToRemove, hotpotToRemove.HotPotInventoryId);
                    }

                    // Soft delete the detail
                    detailToRemove.SoftDelete();
                    await _unitOfWork.Repository<RentOrderDetail>().Update(detailToRemove, detailToRemove.RentOrderDetailId);
                }
            }
        }

        // Helper method for processing sell item updates
        private async Task ProcessSellItemUpdate(Order pendingOrder, CartItemUpdate update)
        {
            // Find the sell order detail
            var detail = pendingOrder.SellOrder?.SellOrderDetails
                .FirstOrDefault(d => d.SellOrderDetailId == update.OrderDetailId && !d.IsDelete);

            if (detail == null)
                throw new NotFoundException($"Không tìm thấy chi tiết đơn hàng với ID {update.OrderDetailId}");

            // Handle item removal (quantity = 0)
            if (update.NewQuantity == 0)
            {
                // No need to return inventory since we're just using reservations
                // Soft delete the detail
                detail.SoftDelete();
            }
            else
            {
                // Check if we need to update reservations
                int quantityDifference = update.NewQuantity - detail.Quantity;

                if (quantityDifference > 0)
                {
                    // Need to reserve more items
                    if (detail.IngredientId.HasValue)
                    {
                        await ReserveInventoryItem(detail.IngredientId.Value, quantityDifference, ItemType.Ingredient);
                    }
                    else if (detail.UtensilId.HasValue)
                    {
                        await ReserveInventoryItem(detail.UtensilId.Value, quantityDifference, ItemType.Utensil);
                    }
                }

                // Update quantity
                detail.Quantity = update.NewQuantity;
            }

            // Update the detail in the database
            await _unitOfWork.Repository<SellOrderDetail>().Update(detail, detail.SellOrderDetailId);
        }
        #endregion

        // Helper method for processing utensil updates
        //private async Task ProcessUtensilUpdate(Order pendingOrder, CartItemUpdate update, RentOrderDetail detail)
        //{
        //    // Handle item removal (quantity = 0)
        //    if (update.NewQuantity == 0)
        //    {
        //        // Return inventory
        //        await _utensilService.UpdateUtensilQuantityAsync(
        //            detail.UtensilId.Value, detail.Quantity);

        //        // Soft delete the detail
        //        detail.SoftDelete();
        //    }
        //    else
        //    {
        //        // Update inventory
        //        int quantityDifference = update.NewQuantity - detail.Quantity;

        //        if (quantityDifference != 0)
        //        {
        //            await _utensilService.UpdateUtensilQuantityAsync(
        //                detail.UtensilId.Value, -quantityDifference);
        //        }

        //        // Update quantity
        //        detail.Quantity = update.NewQuantity;
        //    }

        //    // Update the detail in the database
        //    await _unitOfWork.Repository<RentOrderDetail>().Update(detail, detail.RentOrderDetailId);
        //}


        public async Task<Order> UpdateAsync(int id, UpdateOrderRequest request)
        {
            try
            {
                var order = await GetByIdAsync(id);

                // Only allow updates for pending orders
                if (order.Status != OrderStatus.Cart)
                    throw new ValidationException("Chỉ các giỏ hàng mới có thể được cập nhật");

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
                        throw new ValidationException($"Không tìm thấy mã giảm giá với ID {request.DiscountId}");

                    if (!await _discountService.IsDiscountValidAsync(request.DiscountId.Value))
                        throw new ValidationException("Mã giảm giá đã chọn không hợp lệ hoặc đã hết hạn");


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

                // If order is cancelled, release inventory reservations
                if (status == OrderStatus.Cancelled)
                {
                    // Release all inventory reservations
                    await ReleaseInventoryReservation(order);

                    // Cancel payment if exists and pending
                    var payment = await _paymentService.GetPaymentByOrderIdAsync(id);
                    if (payment != null && payment.Status == PaymentStatus.Pending)
                    {
                        await _paymentService.UpdatePaymentStatusAsync(payment.PaymentId, PaymentStatus.Cancelled);
                    }
                }
                else if (order.Status == OrderStatus.Pending)
                {
                    // Finalize inventory deduction
                    await FinalizeInventoryDeduction(order);
                }
                // If order is completed, update hotpot inventory status
                else if (status == OrderStatus.Completed)
                {
                    if (order.RentOrder != null)
                    {
                        // Update ActualReturnDate in RentOrder
                        order.RentOrder.ActualReturnDate = DateTime.UtcNow.AddHours(7);
                        await _unitOfWork.Repository<RentOrder>().Update(order.RentOrder, order.OrderId);
                        await _unitOfWork.CommitAsync();

                        foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue))
                        {
                            var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                .GetById(detail.HotpotInventoryId.Value);

                            if (hotpotInventory != null)
                            {
                                // Update hotpot status to Available after maintenance
                                hotpotInventory.Status = HotpotStatus.Available;
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
                        order.RentOrder.ExpectedReturnDate = DateTime.UtcNow.AddHours(7);
                        foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue))
                        {
                            
                            var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                .GetById(detail.HotpotInventoryId.Value);

                            if (hotpotInventory != null)
                            {
                                hotpotInventory.Status = HotpotStatus.Preparing; 
                                await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                                await _unitOfWork.CommitAsync();
                            }
                        }

                        // Get user information
                        var user = await _unitOfWork.Repository<User>().GetById(order.UserId);
                        if (user != null)
                        {
                            // Count the number of hotpot items being returned
                            int hotpotCount = order.RentOrder.RentOrderDetails
                                .Count(d => !d.IsDelete && d.HotpotInventoryId.HasValue);

                            // Get hotpot types information
                            var hotpotTypes = new List<string>();
                            foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete && d.HotpotInventoryId.HasValue))
                            {
                                var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                                    .GetById(detail.HotpotInventoryId.Value);

                                if (hotpotInventory?.Hotpot != null && !hotpotTypes.Contains(hotpotInventory.Hotpot.Name))
                                {
                                    hotpotTypes.Add(hotpotInventory.Hotpot.Name);
                                }
                            }

                            // Format expected return date
                            string expectedReturnDate = order.RentOrder.ExpectedReturnDate == DateTime.MinValue
                                ? "Không có"
                                : order.RentOrder.ExpectedReturnDate.ToString("dd/MM/yyyy HH:mm");

                            // Format rental duration
                            TimeSpan? rentalDuration = null;
                            if (order.RentOrder.RentalStartDate != DateTime.MinValue)
                            {
                                rentalDuration = DateTime.UtcNow.AddHours(7) - order.RentOrder.RentalStartDate;
                            }

                            string rentalDurationText = rentalDuration.HasValue
                                ? $"{Math.Round(rentalDuration.Value.TotalDays, 1)} ngày"
                                : "Không xác định";

                            // Notify managers about the returning order
                            await _notificationService.NotifyRoleAsync(
                                "Manager",
                                "Order",
                                "Đơn Hàng Đang Được Trả",
                                $"Khách hàng {user.Name} đang trả lại {hotpotCount} nồi lẩu từ đơn hàng #{order.OrderCode}",
                                new Dictionary<string, object>
                                {
                                    { "OrderId", order.OrderId },
                                    { "CustomerName", user.Name },
                                    { "CustomerPhone", user.PhoneNumber },
                                    { "HotpotCount", hotpotCount },
                                    { "HotpotTypes", string.Join(", ", hotpotTypes) },
                                    { "ExpectedReturnDate", expectedReturnDate },
                                    { "ActualReturnDate", DateTime.UtcNow.AddHours(7).ToString("dd/MM/yyyy HH:mm") },
                                    { "RentalDuration", rentalDurationText },
                                    { "RequiredAction", "Cần phân công nhân viên kiểm tra và bảo trì nồi lẩu" }
                                });

                            // Also notify the customer
                            await _notificationService.NotifyUserAsync(
                                order.UserId,
                                "Order",
                                "Đơn Hàng Đang Được Trả",
                                $"Cảm ơn bạn đã trả lại nồi lẩu. Chúng tôi đang xử lý việc trả hàng của bạn.",
                                new Dictionary<string, object>
                                {
                                    { "OrderId", order.OrderId },
                                    { "HotpotCount", hotpotCount },
                                    { "HotpotTypes", string.Join(", ", hotpotTypes) },
                                    { "ReturnDate", DateTime.UtcNow.AddHours(7).ToString("dd/MM/yyyy HH:mm") },
                                    { "NextSteps", "Chúng tôi sẽ kiểm tra nồi lẩu và hoàn tất quá trình trả hàng. Cảm ơn bạn đã sử dụng dịch vụ của chúng tôi!" }
                                });
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
                if (order.Status != OrderStatus.Cart)
                    throw new ValidationException("Chỉ các đơn hàng trong giỏ hàng mới có thể bị xóa");

                // Soft delete order
                order.SoftDelete();

                // Release all inventory reservations
                await ReleaseInventoryReservation(order);

                await _unitOfWork.CommitAsync();

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

        public async Task<Order> ConfirmPaymentAsync(int orderId)
        {
            try
            {
                var order = await GetByIdAsync(orderId);

                // Only allow confirmation for pending orders
                if (order.Status != OrderStatus.Cart)
                    throw new ValidationException("Chỉ các đơn hàng chờ xử lý mới có thể được xác nhận thanh toán");

                // Execute in transaction to ensure consistency
                return await _unitOfWork.ExecuteInTransactionAsync(async () =>
                {
                    // Finalize inventory deduction
                    await FinalizeInventoryDeduction(order);

                    // Update order status to Processing
                    order.Status = OrderStatus.Pending;
                    order.SetUpdateDate();
                    await _unitOfWork.Repository<Order>().Update(order, orderId);
                    await _unitOfWork.CommitAsync();

                    return await GetByIdAsync(orderId);
                });
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
                _logger.LogError(ex, "Error confirming payment for order {OrderId}", orderId);
                throw;
            }
        }

        //public async Task CleanupAbandonedCartsAsync(TimeSpan abandonThreshold)
        //{
        //    try
        //    {
        //        // Find all pending orders older than the threshold
        //        var cutoffDate = DateTime.Now.Subtract(abandonThreshold);

        //        var abandonedOrders = await _unitOfWork.Repository<Order>()
        //            .IncludeNested(query =>
        //                query.Include(o => o.SellOrder)
        //                     .ThenInclude(so => so.SellOrderDetails)
        //                     .Include(o => o.RentOrder)
        //                     .ThenInclude(ro => ro.RentOrderDetails))
        //            .Where(o => o.Status == OrderStatus.Pending &&
        //                          o.CreatedAt < cutoffDate &&
        //                          !o.IsDelete)
        //            .ToListAsync();

        //        foreach (var order in abandonedOrders)
        //        {
        //            // Release all inventory reservations
        //            await ReleaseInventoryReservation(order);

        //            // Soft delete the order
        //            order.SoftDelete();
        //            await _unitOfWork.Repository<Order>().Update(order, order.OrderId);

        //            // Cancel any pending payments
        //            var payment = await _paymentService.GetPaymentByOrderIdAsync(order.OrderId);
        //            if (payment != null && payment.Status == PaymentStatus.Pending)
        //            {
        //                await _paymentService.UpdatePaymentStatusAsync(payment.PaymentId, PaymentStatus.Cancelled);
        //            }
        //        }

        //        await _unitOfWork.CommitAsync();

        //        _logger.LogInformation("Cleaned up {Count} abandoned carts", abandonedOrders.Count);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, "Error cleaning up abandoned carts");
        //        throw;
        //    }
        //}

        // Helper methods
        private void ValidateStatusTransition(OrderStatus currentStatus, OrderStatus newStatus)
        {
            // Define valid status transitions
            bool isValidTransition = (currentStatus, newStatus) switch
            {
                (OrderStatus.Cart, OrderStatus.Processing) => true,
                (OrderStatus.Cart, OrderStatus.Cancelled) => true,
                (OrderStatus.Pending, OrderStatus.Processing) => true,
                (OrderStatus.Processing, OrderStatus.Shipping) => true,
                (OrderStatus.Processing, OrderStatus.Cancelled) => true,
                (OrderStatus.Shipping, OrderStatus.Delivered) => true,
                (OrderStatus.Delivered, OrderStatus.Returning) => true,
                (OrderStatus.Returning, OrderStatus.Completed) => true,
                _ => false
            };

            if (!isValidTransition)
            {
                throw new ValidationException($"Chuyển trạng thái không hợp lệ từ {currentStatus} sang {newStatus}");
            }
        }

        // Add these methods to the OrderService class

        private async Task ReserveInventoryItem(int itemId, int quantity, ItemType itemType)
        {
            // This method marks items as reserved without actually deducting from inventory
            switch (itemType)
            {
                case ItemType.Ingredient:
                    // Kiểm tra tính sẵn có mà không cập nhật số lượng
                    var ingredient = await _ingredientService.GetIngredientByIdAsync(itemId);
                    if (ingredient.Quantity < quantity)
                        throw new ValidationException($"Chỉ còn {ingredient.Quantity} {ingredient.Name} có sẵn");
                    break;

                case ItemType.Utensil:
                    // Kiểm tra tính sẵn có mà không cập nhật số lượng
                    var utensil = await _utensilService.GetUtensilByIdAsync(itemId);
                    if (utensil.Quantity < quantity)
                        throw new ValidationException($"Chỉ còn {utensil.Quantity} {utensil.Name} có sẵn");
                    break;
                case ItemType.Hotpot:
                    // For hotpots, we'll continue to mark them as Reserved in the database
                    // This is already handled in the ProcessHotpotItem method
                    break;
            }
        }

        private async Task ReleaseInventoryReservation(Order order)
        {
            // This method releases all reservations for an order
            // For hotpots, we need to update their status back to Available
            if (order.RentOrder != null)
            {
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.HotpotInventoryId.HasValue)
                    {
                        var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                            .GetById(detail.HotpotInventoryId.Value);

                        if (hotpotInventory != null)
                        {
                            hotpotInventory.Status = HotpotStatus.Available;
                            await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                        }
                    }
                }
            }

            // For ingredients and utensils, we don't need to do anything since we didn't deduct them yet
        }

        private async Task FinalizeInventoryDeduction(Order order)
        {
            // This method actually deducts inventory quantities after payment is confirmed
            if (order.SellOrder != null)
            {
                foreach (var detail in order.SellOrder.SellOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.IngredientId.HasValue)
                    {
                        await _ingredientService.UpdateIngredientQuantityAsync(
                            detail.IngredientId.Value, -detail.Quantity);
                    }
                    else if (detail.UtensilId.HasValue)
                    {
                        await _utensilService.UpdateUtensilQuantityAsync(
                            detail.UtensilId.Value, -detail.Quantity);
                    }
                }
            }

            // For hotpots, we just need to update their status to Rented
            if (order.RentOrder != null)
            {
                foreach (var detail in order.RentOrder.RentOrderDetails.Where(d => !d.IsDelete))
                {
                    if (detail.HotpotInventoryId.HasValue)
                    {
                        var hotpotInventory = await _unitOfWork.Repository<HotPotInventory>()
                            .GetById(detail.HotpotInventoryId.Value);

                        if (hotpotInventory != null)
                        {
                            hotpotInventory.Status = HotpotStatus.Rented;
                            await _unitOfWork.Repository<HotPotInventory>().Update(hotpotInventory, hotpotInventory.HotPotInventoryId);
                        }
                    }
                }
            }
        }

        // Add an enum for item types
        private enum ItemType
        {
            Ingredient,
            Utensil,
            Hotpot
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
