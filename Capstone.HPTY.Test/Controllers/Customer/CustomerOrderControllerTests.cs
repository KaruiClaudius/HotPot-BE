using Capstone.HPTY.API.Controllers.Customer;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders.Customer;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Customer
{
    public class CustomerOrderControllerTests
    {
        private readonly Mock<IOrderService> _mockOrderService;
        private readonly Mock<IHotpotService> _mockHotpotService;
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<ILogger<CustomerOrderController>> _mockLogger;
        private readonly CustomerOrderController _controller;

        public CustomerOrderControllerTests()
        {
            _mockOrderService = new Mock<IOrderService>(MockBehavior.Strict);
            _mockHotpotService = new Mock<IHotpotService>(MockBehavior.Strict);
            _mockUserService = new Mock<IUserService>(MockBehavior.Strict);
            _mockLogger = new Mock<ILogger<CustomerOrderController>>(MockBehavior.Strict);

            // Setup logger to accept any calls since we don't want to test logging
            _mockLogger.Setup(x => x.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()))
                .Callback(() => { });

            _controller = new CustomerOrderController(
                _mockOrderService.Object,
                _mockHotpotService.Object,
                _mockUserService.Object,
                _mockLogger.Object);
        }

        private void SetupUserIdentity(int userId, string role = "Customer")
        {
            var claims = new List<Claim>
        {
            new Claim("id", userId.ToString()),
            new Claim(ClaimTypes.Role, role)
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = claimsPrincipal
                }
            };
        }

        // ==================== GET ORDERS TESTS ====================

        [Fact]
        public async Task GetUserOrders_WithInvalidUser_ReturnsUnauthorized()
        {
            // Arrange
            // Set up an invalid user identity (no id claim)
            var claims = new List<Claim>(); // Empty claims list - no "id" claim
            var identity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(identity);

            // Set the controller's User property
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            // Act
            var result = await _controller.GetUserOrders(
                pageNumber: 1,
                pageSize: 10);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result.Result);

            // Instead of asserting the exact type, just check if the value has a message property
            dynamic responseObj = unauthorizedResult.Value;
            Assert.NotNull(responseObj);
            Assert.Equal("Thông tin xác thực người dùng không hợp lệ", responseObj.message);

            // Verify that the service method was never called
            _mockOrderService.Verify(
                service => service.GetOrdersAsync(
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<bool?>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()),
                Times.Never);
        }

        [Fact]
        public async Task GetUserOrders_WithComplexFiltering_CallsServiceWithCorrectParameters()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var orders = new List<Order>();
            var pagedResult = new PagedResult<Order>
            {
                Items = orders,
                TotalCount = 0,
                PageNumber = 2,
                PageSize = 5
            };

            DateTime fromDate = new DateTime(2023, 1, 1);
            DateTime toDate = new DateTime(2023, 12, 31);
            decimal minPrice = 50.0m;
            decimal maxPrice = 500.0m;
            bool hasHotpot = true;
            string status = "Processing";
            string paymentStatus = "Paid";
            string searchTerm = "special order";
            string sortBy = "TotalPrice";
            bool ascending = true;

            _mockOrderService
                .Setup(service => service.GetOrdersAsync(
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<bool?>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await _controller.GetUserOrders(
                pageNumber: 2,
                pageSize: 5,
                searchTerm: searchTerm,
                status: status,
                fromDate: fromDate,
                toDate: toDate,
                minPrice: minPrice,
                maxPrice: maxPrice,
                hasHotpot: hasHotpot,
                paymentStatus: paymentStatus,
                sortBy: sortBy,
                ascending: ascending);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            _mockOrderService.Verify(
                service => service.GetOrdersAsync(
                    It.Is<string>(s => s == searchTerm),
                    It.Is<int>(id => id == userId),
                    It.Is<string>(s => s == status),
                    It.Is<DateTime?>(d => d == fromDate),
                    It.Is<DateTime?>(d => d == toDate),
                    It.Is<decimal?>(p => p == minPrice),
                    It.Is<decimal?>(p => p == maxPrice),
                    It.Is<bool?>(h => h == hasHotpot),
                    It.Is<string>(p => p == paymentStatus),
                    It.Is<int>(p => p == 2),
                    It.Is<int>(p => p == 5),
                    It.Is<string>(s => s == sortBy),
                    It.Is<bool>(a => a == ascending)),
                Times.Once);
        }

        // ==================== GET ORDER BY ID TESTS ====================

        [Fact]
        public async Task GetOrderById_WithValidIdAndUser_ReturnsOrder()
        {
            // Arrange
            int userId = 1;
            int orderId = 1;
            SetupUserIdentity(userId);

            var order = new Order
            {
                OrderId = orderId,
                OrderCode = "ORD-001",
                UserId = userId,
                TotalPrice = 100.0m,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now,
                User = new User { UserId = userId, Name = "Test User" }
            };

            _mockOrderService
                .Setup(service => service.GetByIdAsync(orderId))
                .ReturnsAsync(order);

            // Act
            var result = await _controller.GetOrderById(orderId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<OrderResponse>(okResult.Value);
            Assert.Equal(orderId, returnValue.OrderId);
            Assert.Equal("ORD-001", returnValue.OrderCode);
            Assert.Equal("Pending", returnValue.Status);

            _mockOrderService.Verify(service => service.GetByIdAsync(orderId), Times.Once);
        }

        [Fact]
        public async Task GetOrderById_WithNonExistentOrder_ReturnsNotFound()
        {
            // Arrange
            int userId = 1;
            int orderId = 999;
            SetupUserIdentity(userId);

            _mockOrderService
                .Setup(service => service.GetByIdAsync(orderId))
                .ThrowsAsync(new NotFoundException($"Order with ID {orderId} not found"));

            // Act
            var result = await _controller.GetOrderById(orderId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"Order with ID {orderId} not found", ((dynamic)notFoundResult.Value).message);

            _mockOrderService.Verify(service => service.GetByIdAsync(orderId), Times.Once);
        }


        [Fact]
        public async Task GetOrderById_WithOrderBelongingToAnotherUser_ReturnsForbid()
        {
            // Arrange
            int userId = 1;
            int anotherUserId = 2;
            int orderId = 1;
            SetupUserIdentity(userId);

            var order = new Order
            {
                OrderId = orderId,
                OrderCode = "ORD-001",
                UserId = anotherUserId, // Order belongs to another user
                TotalPrice = 100.0m,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now,
                User = new User { UserId = anotherUserId, Name = "Another User" }
            };

            _mockOrderService
                .Setup(service => service.GetByIdAsync(orderId))
                .ReturnsAsync(order);

            // Act
            var result = await _controller.GetOrderById(orderId);

            // Assert
            Assert.IsType<ForbidResult>(result.Result);

            _mockOrderService.Verify(service => service.GetByIdAsync(orderId), Times.Once);
        }

        [Fact]
        public async Task GetOrderById_WithAdminUser_ReturnsOrderEvenIfBelongsToAnotherUser()
        {
            // Arrange
            int adminUserId = 1;
            int customerUserId = 2;
            int orderId = 1;
            SetupUserIdentity(adminUserId, "Admin"); // Set up as Admin

            var order = new Order
            {
                OrderId = orderId,
                OrderCode = "ORD-001",
                UserId = customerUserId, // Order belongs to another user
                TotalPrice = 100.0m,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now,
                User = new User { UserId = customerUserId, Name = "Customer User" }
            };

            _mockOrderService
                .Setup(service => service.GetByIdAsync(orderId))
                .ReturnsAsync(order);

            // Act
            var result = await _controller.GetOrderById(orderId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<OrderResponse>(okResult.Value);
            Assert.Equal(orderId, returnValue.OrderId);
            Assert.Equal("ORD-001", returnValue.OrderCode);

            _mockOrderService.Verify(service => service.GetByIdAsync(orderId), Times.Once);
        }
        // ==================== CREATE ORDER TESTS ====================

        [Fact]
        public async Task CreateOrder_WithValidRequest_ReturnsCreatedOrder()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var createOrderRequest = new CreateOrderRequest
            {
                Items = new List<OrderItemRequest>
        {
            new OrderItemRequest
            {
                IngredientID = 1,
                Quantity = 2
            }
        }
            };

            var createdOrder = new Order
            {
                OrderId = 1,
                OrderCode = "CART-001",
                UserId = userId,
                TotalPrice = 50.0m,
                Status = OrderStatus.Cart,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                User = new User { UserId = userId, Name = "Test User" },
                SellOrder = new SellOrder
                {
                    SellOrderDetails = new List<SellOrderDetail>
            {
                new SellOrderDetail
                {
                    SellOrderDetailId = 1,
                    IngredientId = 1,
                    Quantity = 2,
                    UnitPrice = 25.0m,
                    Ingredient = new Ingredient { IngredientId = 1, Name = "Test Ingredient" }
                }
            }
                }
            };

            _mockOrderService
                .Setup(service => service.CreateAsync(It.IsAny<CreateOrderRequest>(), userId))
                .ReturnsAsync(createdOrder);

            // Act
            var result = await _controller.CreateOrder(createOrderRequest);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<OrderResponse>(createdResult.Value);
            Assert.Equal(1, returnValue.OrderId);
            Assert.Equal("CART-001", returnValue.OrderCode);
            Assert.Equal("Cart", returnValue.Status);
            Assert.Equal(50.0m, returnValue.TotalPrice);
            Assert.Single(returnValue.Items);

            _mockOrderService.Verify(service => service.CreateAsync(createOrderRequest, userId), Times.Once);
        }


        [Fact]
        public async Task CreateOrder_WithNoAuthenticatedUser_ReturnsUnauthorized()
        {
            // Arrange - no user identity setup
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            var createOrderRequest = new CreateOrderRequest
            {
                Items = new List<OrderItemRequest>
                {
                    new OrderItemRequest
                    {
                        IngredientID = 1,
                        Quantity = 2
                    }
                }
            };

            // Act
            var result = await _controller.CreateOrder(createOrderRequest);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result.Result);
            var message = unauthorizedResult.Value;
            Assert.Equal("Không tìm thấy ID người dùng trong token", ((dynamic)message).message);
        }

        [Fact]
        public async Task CreateOrder_WithValidationError_ReturnsBadRequest()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var createOrderRequest = new CreateOrderRequest
            {
                Items = new List<OrderItemRequest>()
            };

            _mockOrderService
                .Setup(service => service.CreateAsync(It.IsAny<CreateOrderRequest>(), userId))
                .ThrowsAsync(new ValidationException("Đơn hàng phải chứa ít nhất một mặt hàng"));

            // Act
            var result = await _controller.CreateOrder(createOrderRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            // Instead of Assert.IsType<object>, just use dynamic or cast to the expected anonymous type
            var messageObj = badRequestResult.Value;
            Assert.Equal("Đơn hàng phải chứa ít nhất một mặt hàng", ((dynamic)messageObj).message);

            _mockOrderService.Verify(service => service.CreateAsync(createOrderRequest, userId), Times.Once);
        }

        // ==================== UPDATE CART TESTS ====================

        [Fact]
        public async Task UpdateCartItems_WithValidRequest_ReturnsUpdatedCart()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var updateCartRequest = new UpdateCartItemsRequest
            {
                Items =
                [
                new CartItemUpdate
                    {
                        OrderDetailId = 1,
                        IsSellItem = true,
                        NewQuantity = 3
                    }
                ]
            };

            var updatedCart = new Order
            {
                OrderId = 1,
                OrderCode = "CART-001",
                UserId = userId,
                TotalPrice = 75.0m,
                Status = OrderStatus.Cart,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                User = new User { UserId = userId, Name = "Test User" },
                SellOrder = new SellOrder
                {
                    SellOrderDetails = new List<SellOrderDetail>
                {
                    new SellOrderDetail
                    {
                        SellOrderDetailId = 1,
                        IngredientId = 1,
                        Quantity = 3, // Updated quantity
                        UnitPrice = 25.0m,
                        Ingredient = new Ingredient { IngredientId = 1, Name = "Test Ingredient" }
                    }
                }
                }
            };

            _mockOrderService
                .Setup(service => service.UpdateCartItemsQuantityAsync(userId, It.IsAny<CartItemUpdate[]>()))
                .ReturnsAsync(updatedCart);

            // Act
            var result = await _controller.UpdateCartItems(updateCartRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<OrderResponse>(okResult.Value);
            Assert.Equal(1, returnValue.OrderId);
            Assert.Equal("CART-001", returnValue.OrderCode);
            Assert.Equal("Cart", returnValue.Status);
            Assert.Equal(75.0m, returnValue.TotalPrice);
            Assert.Single(returnValue.Items);
            Assert.Equal(3, returnValue.Items.First().Quantity);

            _mockOrderService.Verify(service => service.UpdateCartItemsQuantityAsync(
                userId,
                It.Is<CartItemUpdate[]>(items =>
                    items.Length == 1 &&
                    items[0].OrderDetailId == 1 &&
                    items[0].IsSellItem == true &&
                    items[0].NewQuantity == 3)),
                Times.Once);
        }
        [Fact]
        public async Task UpdateCartItems_WithEmptyItems_ReturnsBadRequest()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var updateCartRequest = new UpdateCartItemsRequest
            {
                Items = Array.Empty<CartItemUpdate>()
            };

            // Act
            var result = await _controller.UpdateCartItems(updateCartRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var messageObj = badRequestResult.Value;
            Assert.Equal("Không có sản phẩm nào để cập nhật", ((dynamic)messageObj).message);
        }


        [Fact]
        public async Task UpdateCartItems_WithNoCart_ReturnsOkWithMessage()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var updateCartRequest = new UpdateCartItemsRequest
            {
                Items =
                [
                    new CartItemUpdate
            {
                OrderDetailId = 1,
                IsSellItem = true,
                NewQuantity = 0 // Remove item
            }
                ]
            };

            _mockOrderService
                .Setup(service => service.UpdateCartItemsQuantityAsync(userId, It.IsAny<CartItemUpdate[]>()))
                .ThrowsAsync(new NotFoundException("Không tìm thấy giỏ hàng"));

            // Act
            var result = await _controller.UpdateCartItems(updateCartRequest);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            // Don't assert the exact type, just check the message property
            Assert.Equal("Không tìm thấy giỏ hàng", ((dynamic)notFoundResult.Value).message);

            _mockOrderService.Verify(service => service.UpdateCartItemsQuantityAsync(
                userId,
                It.Is<CartItemUpdate[]>(items =>
                    items.Length == 1 &&
                    items[0].OrderDetailId == 1 &&
                    items[0].IsSellItem == true &&
                    items[0].NewQuantity == 0)),
                Times.Once);
        }

        // ==================== UPDATE ORDER STATUS TESTS ====================

        [Fact]
        public async Task UpdateOrderStatus_WithValidRequest_ReturnsUpdatedOrder()
        {
            // Arrange
            int orderId = 1;
            SetupUserIdentity(1);

            var updateStatusRequest = new UpdateOrderStatusRequest
            {
                Status = OrderStatus.Completed
            };

            var updatedOrder = new Order
            {
                OrderId = orderId,
                OrderCode = "ORD-001",
                UserId = 1,
                Address = "123 Test St",
                Notes = "Test order",
                TotalPrice = 50.0m,
                Status = OrderStatus.Completed,
                CreatedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now,
                User = new User { UserId = 1, Name = "Test User" }
            };

            _mockOrderService
                .Setup(service => service.UpdateStatusAsync(orderId, updateStatusRequest.Status))
                .ReturnsAsync(updatedOrder);

            // Act
            var result = await _controller.UpdateOrderStatus(orderId, updateStatusRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<OrderResponse>(okResult.Value);
            Assert.Equal(orderId, returnValue.OrderId);
            Assert.Equal("Completed", returnValue.Status);

            _mockOrderService.Verify(service => service.UpdateStatusAsync(orderId, updateStatusRequest.Status), Times.Once);
        }

        [Fact]
        public async Task UpdateOrderStatus_WithInvalidStatus_ReturnsBadRequest()
        {
            // Arrange
            int orderId = 1;
            SetupUserIdentity(1);

            var updateStatusRequest = new UpdateOrderStatusRequest
            {
                Status = (OrderStatus)999 // Use an invalid enum value
            };

            _mockOrderService
                .Setup(service => service.UpdateStatusAsync(orderId, updateStatusRequest.Status))
                .ThrowsAsync(new ValidationException("Trạng thái đơn hàng không hợp lệ"));

            // Act
            var result = await _controller.UpdateOrderStatus(orderId, updateStatusRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var message = badRequestResult.Value;
            Assert.Equal("Trạng thái đơn hàng không hợp lệ", ((dynamic)message).message);

            _mockOrderService.Verify(service => service.UpdateStatusAsync(orderId, updateStatusRequest.Status), Times.Once);
        }



        // ==================== DELETE ORDER TESTS ====================

        [Fact]
        public async Task DeleteOrder_WithValidIdAndUser_ReturnsNoContent()
        {
            // Arrange
            int userId = 1;
            int orderId = 1;
            SetupUserIdentity(userId);

            var existingOrder = new Order
            {
                OrderId = orderId,
                OrderCode = "ORD-001",
                UserId = userId,
                Address = "123 Test St",
                Notes = "Test order",
                TotalPrice = 50.0m,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now.AddDays(-1),
                User = new User { UserId = userId, Name = "Test User" }
            };

            _mockOrderService
                .Setup(service => service.GetByIdAsync(orderId))
                .ReturnsAsync(existingOrder);

            _mockOrderService
                .Setup(service => service.DeleteAsync(orderId))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.DeleteOrder(orderId);

            // Assert
            Assert.IsType<NoContentResult>(result);

            _mockOrderService.Verify(service => service.GetByIdAsync(orderId), Times.Once);
            _mockOrderService.Verify(service => service.DeleteAsync(orderId), Times.Once);
        }

        [Fact]
        public async Task DeleteOrder_WithOrderBelongingToAnotherUser_ReturnsForbid()
        {
            // Arrange
            int userId = 1;
            int anotherUserId = 2;
            int orderId = 1;
            SetupUserIdentity(userId);

            var existingOrder = new Order
            {
                OrderId = orderId,
                OrderCode = "ORD-001",
                UserId = anotherUserId, // Order belongs to another user
                Address = "123 Test St",
                Notes = "Test order",
                TotalPrice = 50.0m,
                Status = OrderStatus.Pending,
                CreatedAt = DateTime.Now.AddDays(-1),
                UpdatedAt = DateTime.Now.AddDays(-1),
                User = new User { UserId = anotherUserId, Name = "Another User" }
            };

            _mockOrderService
                .Setup(service => service.GetByIdAsync(orderId))
                .ReturnsAsync(existingOrder);

            // Act
            var result = await _controller.DeleteOrder(orderId);

            // Assert
            Assert.IsType<ForbidResult>(result);

            _mockOrderService.Verify(service => service.GetByIdAsync(orderId), Times.Once);
            _mockOrderService.Verify(service => service.DeleteAsync(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task DeleteOrder_WithNonExistentOrder_ReturnsNotFound()
        {
            // Arrange
            int userId = 1;
            int orderId = 999;
            SetupUserIdentity(userId);

            _mockOrderService
                .Setup(service => service.GetByIdAsync(orderId))
                .ThrowsAsync(new NotFoundException($"Order with ID {orderId} not found"));

            // Act
            var result = await _controller.DeleteOrder(orderId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var message = notFoundResult.Value;
            Assert.Equal($"Order with ID {orderId} not found", ((dynamic)message).message);

            _mockOrderService.Verify(service => service.GetByIdAsync(orderId), Times.Once);
            _mockOrderService.Verify(service => service.DeleteAsync(It.IsAny<int>()), Times.Never);
        }


        // ==================== ERROR HANDLING TESTS ====================

        [Fact]
        public async Task GetUserOrders_WithServerError_ReturnsInternalServerError()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            _mockOrderService
                .Setup(service => service.GetOrdersAsync(
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<bool?>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await _controller.GetUserOrders();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            var message = statusCodeResult.Value; // No IsType<object> here
            Assert.Equal("Đã xảy ra lỗi khi lấy danh sách đơn hàng", ((dynamic)message).message);
        }


        [Fact]
        public async Task UpdateCartItems_WithNotFoundException_ReturnsNotFound()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var updateCartRequest = new UpdateCartItemsRequest
            {
                Items =
                [
                    new CartItemUpdate
            {
                OrderDetailId = 999, // Non-existent order detail
                IsSellItem = true,
                NewQuantity = 3
            }
                ]
            };

            _mockOrderService
                .Setup(service => service.UpdateCartItemsQuantityAsync(userId, It.IsAny<CartItemUpdate[]>()))
                .ThrowsAsync(new NotFoundException("Không tìm thấy chi tiết đơn hàng với ID 999"));

            // Act
            var result = await _controller.UpdateCartItems(updateCartRequest);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            // Don't assert the exact type, just check the message property
            Assert.Equal("Không tìm thấy chi tiết đơn hàng với ID 999", ((dynamic)notFoundResult.Value).message);

            _mockOrderService.Verify(service => service.UpdateCartItemsQuantityAsync(
                userId,
                It.Is<CartItemUpdate[]>(items =>
                    items.Length == 1 &&
                    items[0].OrderDetailId == 999 &&
                    items[0].IsSellItem == true &&
                    items[0].NewQuantity == 3)),
                Times.Once);
        }

        // ==================== ADMIN ROLE TESTS ====================

        //[Fact]
        //public async Task DeleteOrder_WithAdminUser_CanDeleteAnyOrder()
        //{
        //    // Arrange
        //    int adminUserId = 1;
        //    int customerUserId = 2;
        //    int orderId = 1;
        //    SetupUserIdentity(adminUserId, "Admin"); // Set up as Admin

        //    var existingOrder = new Order
        //    {
        //        OrderId = orderId,
        //        OrderCode = "ORD-001",
        //        UserId = customerUserId, // Order belongs to another user
        //        Address = "123 Test St",
        //        Notes = "Test order",
        //        TotalPrice = 50.0m,
        //        Status = OrderStatus.Pending,
        //        CreatedAt = DateTime.Now.AddDays(-1),
        //        UpdatedAt = DateTime.Now.AddDays(-1),
        //        User = new User { UserId = customerUserId, Name = "Customer User" }
        //    };

        //    _mockOrderService
        //        .Setup(service => service.GetByIdAsync(orderId))
        //        .ReturnsAsync(existingOrder);

        //    _mockOrderService
        //        .Setup(service => service.DeleteAsync(orderId))
        //        .Returns(Task.CompletedTask);

        //    // Act
        //    var result = await _controller.DeleteOrder(orderId);

        //    // Assert
        //    Assert.IsType<NoContentResult>(result);

        //    _mockOrderService.Verify(service => service.GetByIdAsync(orderId), Times.Once);
        //    _mockOrderService.Verify(service => service.DeleteAsync(orderId), Times.Once);
        //}

        // ==================== EDGE CASES TESTS ====================

        [Fact]
        public async Task GetUserOrders_WithInvalidPageNumber_UsesDefaultValue()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var orders = new List<Order>();
            var pagedResult = new PagedResult<Order>
            {
                Items = orders,
                TotalCount = 0,
                PageNumber = 1, // Default value
                PageSize = 10
            };

            _mockOrderService
                .Setup(service => service.GetOrdersAsync(
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<bool?>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await _controller.GetUserOrders(
                pageNumber: -1, // Invalid page number
                pageSize: 10);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            _mockOrderService.Verify(
                service => service.GetOrdersAsync(
                    It.IsAny<string>(),
                    It.Is<int>(id => id == userId),
                    It.IsAny<string>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<bool?>(),
                    It.IsAny<string>(),
                    It.Is<int>(p => p == 1), // Should use default value 1
                    It.Is<int>(p => p == 10),
                    It.Is<string>(s => s == "CreatedAt"),
                    It.Is<bool>(a => a == false)),
                Times.Once);
        }

        [Fact]
        public async Task GetUserOrders_WithInvalidPageSize_UsesDefaultValue()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var orders = new List<Order>();
            var pagedResult = new PagedResult<Order>
            {
                Items = orders,
                TotalCount = 0,
                PageNumber = 1,
                PageSize = 10 // Default value
            };

            _mockOrderService
                .Setup(service => service.GetOrdersAsync(
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<bool?>(),
                    It.IsAny<string>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<bool>()))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await _controller.GetUserOrders(
                pageNumber: 1,
                pageSize: -5); // Invalid page size

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            _mockOrderService.Verify(
                service => service.GetOrdersAsync(
                    It.IsAny<string>(),
                    It.Is<int>(id => id == userId),
                    It.IsAny<string>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<DateTime?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<decimal?>(),
                    It.IsAny<bool?>(),
                    It.IsAny<string>(),
                    It.Is<int>(p => p == 1),
                    It.Is<int>(p => p == 10), // Should use default value 10
                    It.Is<string>(s => s == "CreatedAt"),
                    It.Is<bool>(a => a == false)),
                Times.Once);
        }
    }
}
