using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Order.Customer;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Capstone.HPTY.ServiceLayer.Interfaces.UtensilService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;

namespace Capstone.HPTY.API.Controllers.Customer
{
//    [Route("api/customer/orders")]
//    [ApiController]
//    [Authorize]
//    public class CustomerOrderController : ControllerBase
//    {
//        private readonly IOrderService _orderService;
//        private readonly IDiscountService _discountService;
//        private readonly IPaymentService _paymentService;
//        private readonly IUtensilService _utensilService;
//        private readonly IIngredientService _ingredientService;
//        private readonly IHotpotService _hotpotService;
//        private readonly ICustomizationService _customizationService;
//        private readonly IComboService _comboService;
//        private readonly IUserService _userService;
//        private readonly ILogger<CustomerOrderController> _logger;

//        public CustomerOrderController(
//            IOrderService orderService,
//            IDiscountService discountService,
//            IPaymentService paymentService,
//            IUtensilService utensilService,
//            IIngredientService ingredientService,
//            IHotpotService hotpotService,
//            ICustomizationService customizationService,
//            IComboService comboService,
//            IUserService userService,
//            ILogger<CustomerOrderController> logger)
//        {
//            _orderService = orderService;
//            _discountService = discountService;
//            _paymentService = paymentService;
//            _utensilService = utensilService;
//            _ingredientService = ingredientService;
//            _hotpotService = hotpotService;
//            _customizationService = customizationService;
//            _comboService = comboService;
//            _userService = userService;
//            _logger = logger;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<OrderResponse>>> GetUserOrders()
//        {
//            try
//            {
//                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
//                var orders = await _orderService.GetUserOrdersAsync(userId);
//                var orderResponses = orders.Select(MapOrderToResponse).ToList();
//                return Ok(orderResponses);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error retrieving user orders");
//                return StatusCode(500, new { message = "An error occurred while retrieving orders" });
//            }
//        }

//        [HttpGet("paged")]
//        public async Task<ActionResult<PagedResult<OrderResponse>>> GetUserOrdersPaged(
//            [FromQuery] int pageNumber = 1,
//            [FromQuery] int pageSize = 10)
//        {
//            try
//            {
//                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

//                if (pageNumber < 1) pageNumber = 1;
//                if (pageSize < 1) pageSize = 10;
//                if (pageSize > 50) pageSize = 50;

//                var pagedResult = await _orderService.GetUserOrdersPagedAsync(userId, pageNumber, pageSize);

//                var orderResponses = pagedResult.Items.Select(MapOrderToResponse).ToList();

//                return Ok(new PagedResult<OrderResponse>
//                {
//                    Items = orderResponses,
//                    TotalCount = pagedResult.TotalCount,
//                    PageNumber = pagedResult.PageNumber,
//                    PageSize = pagedResult.PageSize
//                });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error retrieving paged user orders");
//                return StatusCode(500, new { message = "An error occurred while retrieving orders" });
//            }
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<OrderResponse>> GetOrderById(int id)
//        {
//            try
//            {
//                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
//                var order = await _orderService.GetByIdAsync(id);

//                if (order == null)
//                    return NotFound(new { message = $"Order with ID {id} not found" });

//                // Verify the order belongs to the current user
//                if (order.UserID != userId)
//                    return Forbid();

//                var orderResponse = MapOrderToResponse(order);
//                return Ok(orderResponse);
//            }
//            catch (NotFoundException ex)
//            {
//                return NotFound(new { message = ex.Message });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error retrieving order {OrderId}", id);
//                return StatusCode(500, new { message = "An error occurred while retrieving the order" });
//            }
//        }

//        [HttpPost]
//        public async Task<ActionResult<OrderResponse>> CreateOrder([FromBody] CreateOrderRequest request)
//        {
//            try
//            {
//                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

//                // Validate items
//                if (request.Items == null || !request.Items.Any())
//                    return BadRequest(new { message = "Order must contain at least one item" });

//                // Create order details
//                var orderDetails = new List<OrderDetail>();
//                decimal totalPrice = 0;

//                foreach (var item in request.Items)
//                {
//                    // Validate that only one item type is specified
//                    int itemTypeCount = 0;
//                    if (item.UtensilID.HasValue) itemTypeCount++;
//                    if (item.IngredientID.HasValue) itemTypeCount++;
//                    if (item.HotpotID.HasValue) itemTypeCount++;
//                    if (item.CustomizationID.HasValue) itemTypeCount++;
//                    if (item.ComboID.HasValue) itemTypeCount++;

//                    if (itemTypeCount != 1)
//                        return BadRequest(new { message = "Each order item must specify exactly one item type" });

//                    // Get unit price based on item type
//                    decimal unitPrice = 0;

//                    if (item.UtensilID.HasValue)
//                    {
//                        var utensil = await _utensilService.GetByIdAsync(item.UtensilID.Value);
//                        if (utensil == null || !utensil.Status || utensil.Quantity < item.Quantity)
//                            return BadRequest(new { message = $"Utensil with ID {item.UtensilID} is not available in the requested quantity" });

//                        unitPrice = utensil.Price;
//                    }
//                    else if (item.IngredientID.HasValue)
//                    {
//                        var ingredient = await _ingredientService.GetByIdAsync(item.IngredientID.Value);
//                        if (ingredient == null || ingredient.Quantity < item.Quantity)
//                            return BadRequest(new { message = $"Ingredient with ID {item.IngredientID} is not available in the requested quantity" });

//                        var currentPrices = await _ingredientService.GetCurrentPricesAsync(new List<int> { item.IngredientID.Value });
//                        unitPrice = currentPrices[item.IngredientID.Value];
//                    }
//                    else if (item.HotpotID.HasValue)
//                    {
//                        var hotpot = await _hotpotService.GetByIdAsync(item.HotpotID.Value);
//                        if (hotpot == null || !hotpot.Status || hotpot.Quantity < item.Quantity)
//                            return BadRequest(new { message = $"Hotpot with ID {item.HotpotID} is not available in the requested quantity" });

//                        unitPrice = hotpot.Price;
//                    }
//                    else if (item.CustomizationID.HasValue)
//                    {
//                        var customization = await _customizationService.GetByIdAsync(item.CustomizationID.Value);
//                        if (customization == null)
//                            return BadRequest(new { message = $"Customization with ID {item.CustomizationID} not found" });

//                        // Verify the customization belongs to the current user
//                        if (customization.UserID != userId)
//                            return BadRequest(new { message = $"Customization with ID {item.CustomizationID} does not belong to the current user" });

//                        unitPrice = customization.TotalPrice;
//                    }
//                    else if (item.ComboID.HasValue)
//                    {
//                        var combo = await _comboService.GetByIdAsync(item.ComboID.Value);
//                        if (combo == null)
//                            return BadRequest(new { message = $"Combo with ID {item.ComboID} not found" });

//                        // Combo price already includes any combo-specific discounts
//                        unitPrice = combo.BasePrice;
//                    }

//                    // Create order detail
//                    var orderDetail = new OrderDetail
//                    {
//                        Quantity = item.Quantity,
//                        UnitPrice = unitPrice,
//                        UtensilID = item.UtensilID,
//                        IngredientID = item.IngredientID,
//                        HotpotID = item.HotpotID,
//                        CustomizationID = item.CustomizationID,
//                        ComboID = item.ComboID
//                    };

//                    orderDetails.Add(orderDetail);
//                    totalPrice += unitPrice * item.Quantity;
//                }

//                // Apply discount if provided
//                if (request.DiscountId.HasValue)
//                {
//                    var discount = await _discountService.GetByIdAsync(request.DiscountId.Value);
//                    if (discount == null)
//                        return BadRequest(new { message = $"Discount with ID {request.DiscountId} not found" });

//                    // Validate discount is still valid
//                    if (!await _discountService.IsDiscountValidAsync(request.DiscountId.Value))
//                        return BadRequest(new { message = "The selected discount is not valid or has expired" });

//                    // Apply discount to total price
//                    totalPrice -= (decimal)(totalPrice * discount.DiscountPercentage / 100);
//                }

//                // Create order
//                var order = new Order
//                {
//                    UserID = userId,
//                    Address = request.Address,
//                    Notes = request.Notes,
//                    TotalPrice = totalPrice,
//                    Status = OrderStatus.Pending,
//                    DiscountID = request.DiscountId,
//                    OrderDetails = orderDetails
//                };

//                var createdOrder = await _orderService.CreateAsync(order);

//                // Create payment based on payment type
//                if (request.PaymentType == PaymentType.Cash)
//                {
//                    // Create cash payment
//                    await _paymentService.CreateCashPaymentAsync(userId, createdOrder.OrderId, totalPrice);
//                }
//                else if (request.PaymentType == PaymentType.Online)
//                {
//                    // For online payment, we'll create a payment record but the actual payment link
//                    // will be generated separately when the user proceeds to payment
//                    var payment = new Payment
//                    {
//                        UserID = userId,
//                        OrderID = createdOrder.OrderId,
//                        Price = totalPrice,
//                        Type = PaymentType.Online,
//                        Status = PaymentStatus.Pending,
//                        TransactionCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"))
//                    };

//                    await _unitOfWork.Repository<Payment>().InsertAsync(payment);
//                    await _unitOfWork.CommitAsync();
//                }

//                // Update inventory quantities
//                foreach (var item in request.Items)
//                {
//                    if (item.UtensilID.HasValue)
//                    {
//                        await _utensilService.UpdateQuantityAsync(item.UtensilID.Value, -item.Quantity);
//                    }
//                    else if (item.IngredientID.HasValue)
//                    {
//                        await _ingredientService.UpdateQuantityAsync(item.IngredientID.Value, -item.Quantity);
//                    }
//                    else if (item.HotpotID.HasValue)
//                    {
//                        await _hotpotService.UpdateQuantityAsync(item.HotpotID.Value, -item.Quantity);
//                    }
//                }

//                var orderResponse = MapOrderToResponse(createdOrder);
//                return CreatedAtAction(nameof(GetOrderById), new { id = createdOrder.OrderId }, orderResponse);
//            }
//            catch (ValidationException ex)
//            {
//                return BadRequest(new { message = ex.Message });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error creating order");
//                return StatusCode(500, new { message = "An error occurred while creating the order" });
//            }
//        }

//        [HttpPost("{orderId}/payment")]
//        public async Task<ActionResult<PaymentLinkResponse>> CreatePaymentLink(int orderId)
//        {
//            try
//            {
//                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

//                // Get the order
//                var order = await _orderService.GetByIdAsync(orderId);
//                if (order == null)
//                    return NotFound(new { message = $"Order with ID {orderId} not found" });

//                // Verify the order belongs to the current user
//                if (order.UserID != userId)
//                    return Forbid();

//                // Check if order is in a valid state for payment
//                if (order.Status != OrderStatus.Pending)
//                    return BadRequest(new { message = "Only pending orders can be paid" });

//                // Get existing payment or create a new one
//                var payment = await _paymentService.GetPaymentByOrderIdAsync(orderId);
//                if (payment == null)
//                {
//                    return BadRequest(new { message = "No payment record found for this order" });
//                }

//                // Check if payment is already completed
//                if (payment.Status == PaymentStatus.Success)
//                    return BadRequest(new { message = "This order has already been paid" });

//                // Check if payment type is online
//                if (payment.Type != PaymentType.Online)
//                    return BadRequest(new { message = "This order is not set for online payment" });

//                // Get user information
//                var user = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == userId);
//                if (user == null)
//                    return BadRequest(new { message = "User not found" });

//                // Create payment link request
//                var createPaymentLinkRequest = new CreatePaymentLinkRequest
//                {
//                    productName = $"Order #{orderId}",
//                    price = payment.Price,
//                    description = $"Payment for order #{orderId}",
//                    returnUrl = $"{Request.Scheme}://{Request.Host}/payment/success",
//                    cancelUrl = $"{Request.Scheme}://{Request.Host}/payment/cancel",
//                    buyerName = user.Name,
//                    buyerPhone = user.PhoneNumber
//                };

//                // Create payment link
//                var response = await _paymentService.CreatePaymentLink(
//                    createPaymentLinkRequest,
//                    user.PhoneNumber,
//                    orderId,
//                    payment.PaymentId);

//                if (response.error != 0)
//                    return BadRequest(new { message = response.message });

//                // Extract payment link from response
//                string paymentLink = "";
//                try
//                {
//                    dynamic paymentInfo = response.data.paymentInfo;
//                    paymentLink = paymentInfo.checkoutUrl;
//                }
//                catch (Exception ex)
//                {
//                    _logger.LogError(ex, "Error extracting payment link from response");
//                    return StatusCode(500, new { message = "Error processing payment link" });
//                }

//                return Ok(new PaymentLinkResponse
//                {
//                    PaymentLink = paymentLink,
//                    OrderId = orderId,
//                    PaymentId = payment.PaymentId,
//                    Amount = payment.Price,
//                    ExpiresAt = DateTime.UtcNow.AddHours(24) // Assuming 24-hour expiry
//                });
//            }
//            catch (NotFoundException ex)
//            {
//                return NotFound(new { message = ex.Message });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error creating payment link for order {OrderId}", orderId);
//                return StatusCode(500, new { message = "An error occurred while creating the payment link" });
//            }
//        }

//        [HttpGet("{orderId}/payment-status")]
//        public async Task<ActionResult> CheckPaymentStatus(int orderId)
//        {
//            try
//            {
//                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

//                // Get the order
//                var order = await _orderService.GetByIdAsync(orderId);
//                if (order == null)
//                    return NotFound(new { message = $"Order with ID {orderId} not found" });

//                // Verify the order belongs to the current user
//                if (order.UserID != userId)
//                    return Forbid();

//                // Get payment
//                var payment = await _paymentService.GetPaymentByOrderIdAsync(orderId);
//                if (payment == null)
//                    return NotFound(new { message = "No payment found for this order" });

//                // For online payments, check the actual payment status
//                if (payment.Type == PaymentType.Online)
//                {
//                    // Get user information
//                    var user = await _unitOfWork.Repository<User>().FindAsync(u => u.UserId == userId);
//                    if (user == null)
//                        return BadRequest(new { message = "User not found" });

//                    // Create check order request
//                    var checkOrderRequest = new CheckOrderRequest
//                    {
//                        OrderCode = payment.TransactionCode
//                    };

//                    // Check payment status
//                    var response = await _paymentService.CheckOrder(checkOrderRequest, user.PhoneNumber);

//                    if (response.error != 0)
//                        return BadRequest(new { message = response.message });

//                    // If payment is successful, update order status
//                    if (response.message == "Transaction Complete" && payment.Status != PaymentStatus.Success)
//                    {
//                        await _orderService.UpdateStatusAsync(orderId, OrderStatus.Processing);
//                    }

//                    return Ok(new
//                    {
//                        orderId = orderId,
//                        paymentId = payment.PaymentId,
//                        status = payment.Status.ToString(),
//                        message = response.message
//                    });
//                }

//                // For cash payments, just return the current status
//                return Ok(new
//                {
//                    orderId = orderId,
//                    paymentId = payment.PaymentId,
//                    status = payment.Status.ToString(),
//                    message = payment.Status == PaymentStatus.Pending ? "Awaiting cash payment on delivery" :
//                              payment.Status == PaymentStatus.Success ? "Payment completed" :
//                              payment.Status == PaymentStatus.Cancelled ? "Payment cancelled" :
//                              "Payment status unknown"
//                });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error checking payment status for order {OrderId}", orderId);
//                return StatusCode(500, new { message = "An error occurred while checking the payment status" });
//            }
//        }

//        [HttpPut("{orderId}/cancel")]
//        public async Task<ActionResult> CancelOrder(int orderId)
//        {
//            try
//            {
//                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

//                // Get the order
//                var order = await _orderService.GetByIdAsync(orderId);
//                if (order == null)
//                    return NotFound(new { message = $"Order with ID {orderId} not found" });

//                // Verify the order belongs to the current user
//                if (order.UserID != userId)
//                    return Forbid();

//                // Check if order can be cancelled
//                if (order.Status != OrderStatus.Pending && order.Status != OrderStatus.Processing)
//                    return BadRequest(new { message = "Only pending or processing orders can be cancelled" });

//                // Get payment
//                var payment = await _paymentService.GetPaymentByOrderIdAsync(orderId);

//                // If payment exists and is online, cancel the payment
//                if (payment != null && payment.Type == PaymentType.Online && payment.Status == PaymentStatus.Pending)
//                {
//                    await _paymentService.CancelOrder(payment.TransactionCode, "Cancelled by customer");
//                }

//                // Update order status
//                await _orderService.UpdateStatusAsync(orderId, OrderStatus.Cancelled);

//                // Return inventory quantities
//                foreach (var detail in order.OrderDetails.Where(d => !d.IsDelete))
//                {
//                    if (detail.UtensilID.HasValue)
//                    {
//                        await _utensilService.UpdateQuantityAsync(detail.UtensilID.Value, detail.Quantity);
//                    }
//                    else if (detail.IngredientID.HasValue)
//                    {
//                        await _ingredientService.UpdateQuantityAsync(detail.IngredientID.Value, detail.Quantity);
//                    }
//                    else if (detail.HotpotID.HasValue)
//                    {
//                        await _hotpotService.UpdateQuantityAsync(detail.HotpotID.Value, detail.Quantity);
//                    }
//                }

//                return Ok(new { message = "Order cancelled successfully" });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error cancelling order {OrderId}", orderId);
//                return StatusCode(500, new { message = "An error occurred while cancelling the order" });
//            }
//        }

//        [HttpGet("{orderId}/tracking")]
//        public async Task<ActionResult<OrderTrackingResponse>> TrackOrder(int orderId)
//        {
//            try
//            {
//                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

//                // Get the order
//                var order = await _orderService.GetByIdAsync(orderId);
//                if (order == null)
//                    return NotFound(new { message = $"Order with ID {orderId} not found" });

//                // Verify the order belongs to the current user
//                if (order.UserID != userId)
//                    return Forbid();

//                // Get shipping information if available
//                ShippingOrder? shippingOrder = null;
//                if (order.Status == OrderStatus.Shipping || order.Status == OrderStatus.Delivered)
//                {
//                    shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
//                        .FindAsync(so => so.OrderID == orderId);

//                    if (shippingOrder != null)
//                    {
//                        // Get staff information
//                        var staff = await _unitOfWork.Repository<Staff>()
//                            .FindAsync(s => s.StaffId == shippingOrder.StaffID);

//                        // Create tracking response
//                        var trackingResponse = new OrderTrackingResponse
//                        {
//                            OrderId = orderId,
//                            Status = order.Status.ToString(),
//                            CreatedAt = order.CreatedAt,
//                            ProcessedAt = order.Status >= OrderStatus.Processing ? order.UpdatedAt : null,
//                            ShippedAt = order.Status >= OrderStatus.Shipping ? shippingOrder.CreatedAt : null,
//                            DeliveredAt = shippingOrder.IsDelivered ? shippingOrder.UpdatedAt : null,
//                            ShippingInfo = new ShippingInfo
//                            {
//                                ShippingOrderId = shippingOrder.ShippingOrderId,
//                                StaffName = staff?.Name,
//                                StaffPhone = staff?.PhoneNumber,
//                                EstimatedDeliveryTime = shippingOrder.DeliveryTime,
//                                IsDelivered = shippingOrder.IsDelivered,
//                                DeliveryNotes = shippingOrder.DeliveryNotes
//                            },
//                            StatusHistory = await GetOrderStatusHistory(orderId)
//                        };

//                        return Ok(trackingResponse);
//                    }
//                }

//                // If no shipping info, return basic tracking
//                return Ok(new OrderTrackingResponse
//                {
//                    OrderId = orderId,
//                    Status = order.Status.ToString(),
//                    CreatedAt = order.CreatedAt,
//                    ProcessedAt = order.Status >= OrderStatus.Processing ? order.UpdatedAt : null,
//                    StatusHistory = await GetOrderStatusHistory(orderId)
//                });
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error tracking order {OrderId}", orderId);
//                return StatusCode(500, new { message = "An error occurred while tracking the order" });
//            }
//        }

//        [HttpGet("summary")]
//        public async Task<ActionResult<OrderSummaryResponse>> GetOrderSummary()
//        {
//            try
//            {
//                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

//                // Get all user orders
//                var orders = await _orderService.GetUserOrdersAsync(userId);

//                // Calculate summary
//                var summary = new OrderSummaryResponse
//                {
//                    TotalOrders = orders.Count,
//                    PendingOrders = orders.Count(o => o.Status == OrderStatus.Pending),
//                    ProcessingOrders = orders.Count(o => o.Status == OrderStatus.Processing),
//                    ShippingOrders = orders.Count(o => o.Status == OrderStatus.Shipping),
//                    DeliveredOrders = orders.Count(o => o.Status == OrderStatus.Delivered),
//                    CancelledOrders = orders.Count(o => o.Status == OrderStatus.Cancelled),
//                    TotalSpent = orders.Where(o => o.Status == OrderStatus.Delivered).Sum(o => o.TotalPrice)
//                };

//                return Ok(summary);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "Error getting order summary");
//                return StatusCode(500, new { message = "An error occurred while getting the order summary" });
//            }
//        }

//        [HttpPost("{orderId}/confirm-delivery")]
//        public async Task<ActionResult> ConfirmDelivery(int orderId)
//        {
//            try
//            {
//                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

//                // Get the order
//                var order = await _orderService.GetByIdAsync(orderId);
//                if (order == null)
//                    return NotFound(new { message = $"Order with ID {orderId} not found" });

//                // Verify the order belongs to the current user
//                if (order.UserID != userId)
//                    return Forbid();

//                // Check if order is in shipping status
//                if (order.Status != OrderStatus.Shipping)
//                    return BadRequest(new { message = "Only orders in shipping status can be confirmed as delivered" });

//                // Get shipping order
//                var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
//                    .FindAsync(so => so.OrderID == orderId);

//                if (shippingOrder == null)
//                    return NotFound(new { message = "Shipping information not found for this order" });

//                // Check if already delivered
//                if (shippingOrder.IsDelivered)
//                    return BadRequest(new { message = "This order has already been marked as delivered" });

//                // Update shipping order
//                shippingOrder.IsDelivered = true;
//                shippingOrder.UpdatedAt = DateTime.UtcNow;
//                await _unitOfWork.Repository<ShippingOrder>().Update(shippingOrder, shippingOrder.ShippingOrderId);

//                // Update order status
//                await _orderService.UpdateStatusAsync(orderId, OrderStatus.Delivered);

//                // If payment is cash, update payment status to success
//                var payment = await _paymentService.GetPaymentByOrderIdAsync(orderId);
//                if (payment != null && payment.Type == PaymentType.Cash && payment.Status == PaymentStatus.Pending)
//                {
//                    await _paymentService.UpdatePaymentStatusAsync(payment.PaymentId, PaymentStatus.Success);
//                }

//                await _unitOfWork.CommitAsync();
            
//            return Ok(new { message = "Delivery confirmed successfully" });
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "Error confirming delivery for order {OrderId}", orderId);
//            return StatusCode(500, new { message = "An error occurred while confirming delivery" });
//        }
//    }

//    [HttpPost("{orderId}/finish")]
//    public async Task<ActionResult> FinishOrder(int orderId)
//    {
//        try
//        {
//            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            
//            // Get the order
//            var order = await _orderService.GetByIdAsync(orderId);
//            if (order == null)
//                return NotFound(new { message = $"Order with ID {orderId} not found" });
            
//            // Verify the order belongs to the current user
//            if (order.UserID != userId)
//                return Forbid();
            
//            // Check if order is in delivered status
//            if (order.Status != OrderStatus.Delivered)
//                return BadRequest(new { message = "Only delivered orders can be marked as finished" });
            
//            // Update order status to Finished
//            await _orderService.UpdateStatusAsync(orderId, OrderStatus.Finished);
            
//            return Ok(new { message = "Order marked as finished successfully" });
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "Error finishing order {OrderId}", orderId);
//            return StatusCode(500, new { message = "An error occurred while finishing the order" });
//        }
//    }

//    // Helper methods
//    private OrderResponse MapOrderToResponse(Order order)
//    {
//        if (order == null) return null;
        
//        var response = new OrderResponse
//        {
//            OrderId = order.OrderId,
//            Address = order.Address,
//            Notes = order.Notes,
//            TotalPrice = order.TotalPrice,
//            Status = order.Status.ToString(),
//            CreatedAt = order.CreatedAt,
//            UpdatedAt = order.UpdatedAt,
//            Items = new List<OrderItemResponse>(),
//            Discount = null,
//            Payment = null
//        };
        
//        // Map order details
//        if (order.OrderDetails != null)
//        {
//            foreach (var detail in order.OrderDetails.Where(d => !d.IsDelete))
//            {
//                string itemType = "";
//                string itemName = "Unknown";
//                string imageUrl = null;
//                int? itemId = null;
                
//                if (detail.Utensil != null)
//                {
//                    itemType = "Utensil";
//                    itemName = detail.Utensil.Name;
//                    imageUrl = detail.Utensil.ImageUrl;
//                    itemId = detail.UtensilID;
//                }
//                else if (detail.Ingredient != null)
//                {
//                    itemType = "Ingredient";
//                    itemName = detail.Ingredient.Name;
//                    imageUrl = detail.Ingredient.ImageUrl;
//                    itemId = detail.IngredientID;
//                }
//                else if (detail.Hotpot != null)
//                {
//                    itemType = "Hotpot";
//                    itemName = detail.Hotpot.Name;
//                    imageUrl = detail.Hotpot.ImageUrl;
//                    itemId = detail.HotpotID;
//                }
//                else if (detail.Customization != null)
//                {
//                    itemType = "Customization";
//                    itemName = detail.Customization.Name;
//                    itemId = detail.CustomizationID;
//                }
//                else if (detail.Combo != null)
//                {
//                    itemType = "Combo";
//                    itemName = detail.Combo.Name;
//                    imageUrl = detail.Combo.ImageUrl;
//                    itemId = detail.ComboID;
//                }
                
//                response.Items.Add(new OrderItemResponse
//                {
//                    OrderDetailId = detail.OrderDetailId,
//                    Quantity = detail.Quantity,
//                    UnitPrice = detail.UnitPrice,
//                    TotalPrice = detail.UnitPrice * detail.Quantity,
//                    ItemType = itemType,
//                    ItemName = itemName,
//                    ImageUrl = imageUrl,
//                    ItemId = itemId
//                });
//            }
//        }
        
//        // Map discount if available
//        if (order.Discount != null)
//        {
//            response.Discount = new DiscountInfo
//            {
//                DiscountId = order.Discount.DiscountId,
//                Title = order.Discount.Title,
//                Description = order.Discount.Description,
//                Percent = order.Discount.Percent,
//                DiscountAmount = CalculateDiscountAmount(order.TotalPrice, order.Discount.Percent)
//            };
//        }
        
//        // Map payment if available
//        if (order.Payment != null)
//        {
//            response.Payment = new PaymentInfo
//            {
//                PaymentId = order.Payment.PaymentId,
//                Type = order.Payment.Type.ToString(),
//                Status = order.Payment.Status.ToString(),
//                Amount = order.Payment.Price,
//                CreatedAt = order.Payment.CreatedAt
//            };
//        }
        
//        return response;
//    }
    
//    private decimal CalculateDiscountAmount(decimal totalPrice, double discountPercent)
//    {
//        return totalPrice * (decimal)(discountPercent / 100);
//    }
    
//    private async Task<List<OrderStatusHistory>> GetOrderStatusHistory(int orderId)
//    {
//        // This would ideally come from a status history table
//        // For now, we'll simulate it based on the order's current status and timestamps
        
//        var order = await _orderService.GetByIdAsync(orderId);
//        if (order == null) return new List<OrderStatusHistory>();
        
//        var history = new List<OrderStatusHistory>
//        {
//            new OrderStatusHistory
//            {
//                Status = OrderStatus.Pending.ToString(),
//                Timestamp = order.CreatedAt
//            }
//        };
        
//        // Add subsequent statuses based on current status
//        if (order.Status >= OrderStatus.Processing)
//        {
//            history.Add(new OrderStatusHistory
//            {
//                Status = OrderStatus.Processing.ToString(),
//                Timestamp = order.UpdatedAt ?? order.CreatedAt.AddMinutes(30) // Fallback if no update time
//            });
//        }
        
//        if (order.Status >= OrderStatus.Shipping)
//        {
//            // Get shipping order for timestamp
//            var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
//                .FindAsync(so => so.OrderID == orderId);
                
//            history.Add(new OrderStatusHistory
//            {
//                Status = OrderStatus.Shipping.ToString(),
//                Timestamp = shippingOrder?.CreatedAt ?? order.UpdatedAt ?? order.CreatedAt.AddHours(1)
//            });
//        }
        
//        if (order.Status >= OrderStatus.Delivered)
//        {
//            // Get shipping order for timestamp
//            var shippingOrder = await _unitOfWork.Repository<ShippingOrder>()
//                .FindAsync(so => so.OrderID == orderId);
                
//            history.Add(new OrderStatusHistory
//            {
//                Status = OrderStatus.Delivered.ToString(),
//                Timestamp = shippingOrder?.UpdatedAt ?? order.UpdatedAt ?? order.CreatedAt.AddHours(2)
//            });
//        }
        
//        if (order.Status == OrderStatus.Finished)
//        {
//            history.Add(new OrderStatusHistory
//            {
//                Status = OrderStatus.Finished.ToString(),
//                Timestamp = order.UpdatedAt ?? order.CreatedAt.AddHours(3)
//            });
//        }
        
//        if (order.Status == OrderStatus.Cancelled)
//        {
//            history.Add(new OrderStatusHistory
//            {
//                Status = OrderStatus.Cancelled.ToString(),
//                Timestamp = order.UpdatedAt ?? order.CreatedAt.AddMinutes(15)
//            });
//        }
        
//        return history;
//    }
//}
        }
