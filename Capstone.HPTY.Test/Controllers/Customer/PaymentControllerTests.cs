using Capstone.HPTY.API.Controllers.Customer;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Payments;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Capstone.HPTY.Test.Controllers.Customer
{
    public class PaymentControllerTests
    {
        private readonly Mock<IPaymentService> _mockPaymentService;
        private readonly Mock<ILogger<PaymentController>> _mockLogger;
        private readonly Mock<IOrderService> _mockOrderService;
        private readonly PaymentController _controller;

        public PaymentControllerTests()
        {
            _mockPaymentService = new Mock<IPaymentService>(MockBehavior.Strict);
            _mockLogger = new Mock<ILogger<PaymentController>>(MockBehavior.Loose); // Use Loose for logger to avoid having to set up all logging calls
            _mockOrderService = new Mock<IOrderService>(MockBehavior.Strict);

            _controller = new PaymentController(
                _mockPaymentService.Object,
                _mockLogger.Object,
                _mockOrderService.Object);
        }

        private void SetupUserIdentity(int userId, string name = "Test User", string phone = "1234567890", string role = "Customer")
        {
            var claims = new List<Claim>
        {
            new Claim("id", userId.ToString()),
            new Claim("name", name),
            new Claim("phone", phone),
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
        // ==================== ProcessOnlinePayment Tests ====================

        [Fact]
        public async Task ProcessOnlinePayment_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            int userId = 1;
            int orderId = 123;
            SetupUserIdentity(userId);

            var request = new ProcessOnlinePaymentRequest
            {
                OrderId = orderId,
                Description = "Test payment",
                ReturnUrl = "https://example.com/return",
                CancelUrl = "https://example.com/cancel",
                Address = "123 Test St",
                Notes = "Test notes",
                DiscountId = 0, // Will be set to null in controller
                ExpectedReturnDate = DateTime.Now.AddDays(7),
                DeliveryTime = DateTime.Now.AddHours(1)
            };

            var order = new Order
            {
                OrderId = orderId,
                TotalPrice = 100.0m
            };

            var verifyResponse = new Response(0, "Giỏ hàng hợp lệ để thanh toán", null);

            var paymentResponse = new Response(orderId, "success", null)
            {
                error = 0,
                message = "success",
                data = new
                {
                    paymentInfo = new { url = "https://payment.example.com/123" },
                    userInfo = new { UserId = userId, Name = "Test User", PhoneNumber = "1234567890" }
                }
            };

            _mockPaymentService
                .Setup(s => s.VerifyCartBeforePaymentAsync(orderId))
                .ReturnsAsync(verifyResponse);

            _mockOrderService
                .Setup(s => s.GetByIdAsync(orderId))
                .ReturnsAsync(order);

            _mockPaymentService
                .Setup(s => s.ProcessOnlinePayment(
                    orderId,
                    request.Address,
                    request.Notes,
                    null, // DiscountId should be null since it's 0
                    request.ExpectedReturnDate,
                    request.DeliveryTime,
                    It.IsAny<CreatePaymentLinkRequest>(),
                    userId))
                .ReturnsAsync(paymentResponse);

            // Act
            var result = await _controller.ProcessOnlinePayment(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response>(okResult.Value);
            Assert.Equal(0, response.error);
            Assert.Equal("success", response.message);

            _mockPaymentService.Verify(s => s.VerifyCartBeforePaymentAsync(orderId), Times.Once);
            _mockOrderService.Verify(s => s.GetByIdAsync(orderId), Times.Once);
            _mockPaymentService.Verify(s => s.ProcessOnlinePayment(
                orderId,
                request.Address,
                request.Notes,
                null,
                request.ExpectedReturnDate,
                request.DeliveryTime,
                It.IsAny<CreatePaymentLinkRequest>(),
                userId), Times.Once);
        }
        [Fact]
        public async Task ProcessOnlinePayment_WithNoUserId_ReturnsInternalServerError()
        {
            // Arrange
            // Don't set up user identity
            var request = new ProcessOnlinePaymentRequest
            {
                OrderId = 123
            };

            // Act
            var result = await _controller.ProcessOnlinePayment(request);

            // Assert
            var objectResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, objectResult.StatusCode);
            dynamic value = objectResult.Value;
            Assert.Equal("Đã xảy ra lỗi khi xử lý thanh toán trực tuyến", value.message);
        }

        [Fact]
        public async Task ProcessOnlinePayment_WithNonCustomerRole_ReturnsForbid()
        {
            // Arrange
            SetupUserIdentity(1, role: "Admin"); // Non-customer role

            var request = new ProcessOnlinePaymentRequest
            {
                OrderId = 123
            };

            // Act
            var result = await _controller.ProcessOnlinePayment(request);

            // Assert
            Assert.IsType<ForbidResult>(result);
        }

        [Fact]
        public async Task ProcessOnlinePayment_WithCartVerificationFailure_ReturnsBadRequest()
        {
            // Arrange
            int userId = 1;
            int orderId = 123;
            SetupUserIdentity(userId);

            var request = new ProcessOnlinePaymentRequest
            {
                OrderId = orderId
            };

            var verifyResponse = new Response(-1, "Giỏ hàng không hợp lệ", new { UnavailableItems = new[] { "Item 1", "Item 2" } });

            _mockPaymentService
                .Setup(s => s.VerifyCartBeforePaymentAsync(orderId))
                .ReturnsAsync(verifyResponse);

            // Act
            var result = await _controller.ProcessOnlinePayment(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            dynamic value = badRequestResult.Value;
            Assert.Equal("Giỏ hàng không hợp lệ", value.message);
            Assert.NotNull(value.details);

            _mockPaymentService.Verify(s => s.VerifyCartBeforePaymentAsync(orderId), Times.Once);
        }


        [Fact]
        public async Task ProcessOnlinePayment_WithOrderNotFound_ReturnsNotFound()
        {
            // Arrange
            int userId = 1;
            int orderId = 123;
            SetupUserIdentity(userId);

            var request = new ProcessOnlinePaymentRequest
            {
                OrderId = orderId
            };

            var verifyResponse = new Response(0, "Giỏ hàng hợp lệ để thanh toán", null);

            _mockPaymentService
                .Setup(s => s.VerifyCartBeforePaymentAsync(orderId))
                .ReturnsAsync(verifyResponse);

            _mockOrderService
                .Setup(s => s.GetByIdAsync(orderId))
                .ReturnsAsync((Order)null);

            // Act
            var result = await _controller.ProcessOnlinePayment(request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            dynamic value = notFoundResult.Value;
            Assert.Equal("Không tìm thấy đơn hàng", value.message);

            _mockPaymentService.Verify(s => s.VerifyCartBeforePaymentAsync(orderId), Times.Once);
            _mockOrderService.Verify(s => s.GetByIdAsync(orderId), Times.Once);
        }

        // ==================== CancelOrder Tests ====================

        [Fact]
        public async Task CancelOrder_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            int userId = 1;
            int orderCode = 123;
            string reason = "Changed my mind";
            SetupUserIdentity(userId);

            var payment = new Payment
            {
                PaymentId = 456,
                UserId = userId
            };

            var getResponse = new Response(0, "Ok", new PaymentOrderResult
            {
                Transaction = payment
            });

            var cancelResponse = new Response(0, "Ok", null);

            _mockPaymentService
                .Setup(s => s.GetOrder(orderCode))
                .ReturnsAsync(getResponse);

            _mockPaymentService
                .Setup(s => s.CancelOrder(orderCode, reason))
                .ReturnsAsync(cancelResponse);

            // Act
            var result = await _controller.CancelOrder(orderCode, reason);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response>(okResult.Value);
            Assert.Equal(0, response.error);
            Assert.Equal("Ok", response.message);

            _mockPaymentService.Verify(s => s.GetOrder(orderCode), Times.Once);
            _mockPaymentService.Verify(s => s.CancelOrder(orderCode, reason), Times.Once);
        }

        [Fact]
        public async Task CancelOrder_WithOrderNotFound_ReturnsBadRequest()
        {
            // Arrange
            int userId = 1;
            int orderCode = 123;
            string reason = "Changed my mind";
            SetupUserIdentity(userId);

            var getResponse = new Response(-1, "Không tìm thấy giao dịch", null);

            _mockPaymentService
                .Setup(s => s.GetOrder(orderCode))
                .ReturnsAsync(getResponse);

            // Act
            var result = await _controller.CancelOrder(orderCode, reason);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            dynamic value = badRequestResult.Value;
            Assert.Equal("Không tìm thấy giao dịch", value.message);

            _mockPaymentService.Verify(s => s.GetOrder(orderCode), Times.Once);
            _mockPaymentService.Verify(s => s.CancelOrder(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task CancelOrder_WithDifferentUser_ReturnsForbid()
        {
            // Arrange
            int userId = 1;
            int differentUserId = 2;
            int orderCode = 123;
            string reason = "Changed my mind";
            SetupUserIdentity(userId);

            var payment = new Payment
            {
                PaymentId = 456,
                UserId = differentUserId // Different user
            };

            var getResponse = new Response(0, "Ok", new PaymentOrderResult
            {
                Transaction = payment
            });

            _mockPaymentService
                .Setup(s => s.GetOrder(orderCode))
                .ReturnsAsync(getResponse);

            // Act
            var result = await _controller.CancelOrder(orderCode, reason);

            // Assert
            Assert.IsType<ForbidResult>(result);

            _mockPaymentService.Verify(s => s.GetOrder(orderCode), Times.Once);
            _mockPaymentService.Verify(s => s.CancelOrder(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }
        [Fact]
        public async Task CancelOrder_WithAdminRole_CanCancelAnyOrder()
        {
            // Arrange
            int adminId = 1;
            int customerUserId = 2;
            int orderCode = 123;
            string reason = "Admin cancellation";
            SetupUserIdentity(adminId, role: "Admin");

            var payment = new Payment
            {
                PaymentId = 456,
                UserId = customerUserId // Different user, but admin can cancel
            };

            var getResponse = new Response(0, "Ok", new PaymentOrderResult
            {
                Transaction = payment
            });

            var cancelResponse = new Response(0, "Ok", null);

            _mockPaymentService
                .Setup(s => s.GetOrder(orderCode))
                .ReturnsAsync(getResponse);

            _mockPaymentService
                .Setup(s => s.CancelOrder(orderCode, reason))
                .ReturnsAsync(cancelResponse);

            // Act
            var result = await _controller.CancelOrder(orderCode, reason);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response>(okResult.Value);
            Assert.Equal(0, response.error);

            _mockPaymentService.Verify(s => s.GetOrder(orderCode), Times.Once);
            _mockPaymentService.Verify(s => s.CancelOrder(orderCode, reason), Times.Once);
        }



        [Fact]
        public async Task CancelOrder_WithCancellationFailure_ReturnsBadRequest()
        {
            // Arrange
            int userId = 1;
            int orderCode = 123;
            string reason = "Changed my mind";
            SetupUserIdentity(userId);

            var payment = new Payment
            {
                PaymentId = 456,
                UserId = userId
            };

            var getResponse = new Response(0, "Ok", new PaymentOrderResult
            {
                Transaction = payment
            });

            var cancelResponse = new Response(-1, "Cannot cancel order in current state", null);

            _mockPaymentService
                .Setup(s => s.GetOrder(orderCode))
                .ReturnsAsync(getResponse);

            _mockPaymentService
                .Setup(s => s.CancelOrder(orderCode, reason))
                .ReturnsAsync(cancelResponse);

            // Act
            var result = await _controller.CancelOrder(orderCode, reason);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            dynamic value = badRequestResult.Value;
            Assert.Equal("Cannot cancel order in current state", value.message);

            _mockPaymentService.Verify(s => s.GetOrder(orderCode), Times.Once);
            _mockPaymentService.Verify(s => s.CancelOrder(orderCode, reason), Times.Once);
        }

        // ==================== CheckOrder Tests ====================

        [Fact]
        public async Task CheckOrder_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            int userId = 1;
            string phone = "1234567890";
            SetupUserIdentity(userId, phone: phone);

            var request = new CheckOrderRequest(123);
            var checkResponse = new Response(0, "Order found", new
            {
                orderId = 123,
                status = "Pending",
                totalAmount = 100.0
            });

            _mockPaymentService
                .Setup(s => s.CheckOrder(request, phone))
                .ReturnsAsync(checkResponse);

            // Act
            var result = await _controller.CheckOrder(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response>(okResult.Value);
            Assert.Equal(0, response.error);
            Assert.Equal("Order found", response.message);
            Assert.NotNull(response.data);

            _mockPaymentService.Verify(s => s.CheckOrder(request, phone), Times.Once);
        }

        [Fact]
        public async Task CheckOrder_WithOrderNotFound_ReturnsOkWithErrorMessage()
        {
            // Arrange
            int userId = 1;
            string phone = "1234567890";
            SetupUserIdentity(userId, phone: phone);

            var request = new CheckOrderRequest(999); // Non-existent order code

            var checkResponse = new Response(-1, "Order not found", null);

            _mockPaymentService
                .Setup(s => s.CheckOrder(request, phone))
                .ReturnsAsync(checkResponse);

            // Act
            var result = await _controller.CheckOrder(request);

            // Assert
            var badRequestResult = Assert.IsType<OkObjectResult>(result);
            dynamic value = badRequestResult.Value;
            Assert.Equal("Order not found", value.message);

            _mockPaymentService.Verify(s => s.CheckOrder(request, phone), Times.Once);
        }


        [Fact]
        public async Task CheckOrder_WithException_ReturnsInternalServerError()
        {
            // Arrange
            int userId = 1;
            string phone = "1234567890";
            SetupUserIdentity(userId, phone: phone);

            var request = new CheckOrderRequest(123);

            _mockPaymentService
                .Setup(s => s.CheckOrder(request, phone))
                .ThrowsAsync(new Exception("Unexpected error"));

            // Act
            var result = await _controller.CheckOrder(request);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            dynamic value = statusCodeResult.Value;
            Assert.Equal("Đã xảy ra lỗi khi kiểm tra trạng thái đơn hàng", value.message);

            _mockPaymentService.Verify(s => s.CheckOrder(request, phone), Times.Once);
        }

        [Fact]
        public async Task CheckOrder_WithNoUserPhone_UsesNullPhone()
        {
            // Arrange
            int userId = 1;
            // Setup user without phone claim
            var claims = new List<Claim>
                {
                    new Claim("id", userId.ToString()),
                    new Claim(ClaimTypes.Role, "Customer")
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

            var request = new CheckOrderRequest(123);

            var checkResponse = new Response(0, "Order found", new
            {
                orderId = 123,
                status = "Pending",
                totalAmount = 100.0
            });

            _mockPaymentService
                .Setup(s => s.CheckOrder(request, null))
                .ReturnsAsync(checkResponse);

            // Act
            var result = await _controller.CheckOrder(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<Response>(okResult.Value);
            Assert.Equal(0, response.error);

            _mockPaymentService.Verify(s => s.CheckOrder(request, null), Times.Once);
        }
    }
}


