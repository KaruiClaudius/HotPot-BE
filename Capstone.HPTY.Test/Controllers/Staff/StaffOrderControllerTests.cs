using Capstone.HPTY.API.Controllers.Staff;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Staff
{
    public class StaffOrderControllerTests
    {
        private MockRepository mockRepository;
        private Mock<IStaffOrderService> mockStaffOrderService;
        private Mock<ILogger<StaffOrderController>> mockLogger;

        public StaffOrderControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockStaffOrderService = this.mockRepository.Create<IStaffOrderService>();

            // Create logger with loose behavior instead of strict
            this.mockLogger = new Mock<ILogger<StaffOrderController>>(MockBehavior.Loose);
        }

        private StaffOrderController CreateStaffOrderController()
        {
            var controller = new StaffOrderController(
                this.mockStaffOrderService.Object,
                this.mockLogger.Object);

            // Setup controller context
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim("id", "123"),
            }, "mock"));

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            return controller;
        }

        #region GetAssignedOrders Tests

        [Fact]
        public async Task GetAssignedOrders_WithValidTaskType_ReturnsOkResult()
        {
            // Arrange
            var staffOrderController = this.CreateStaffOrderController();
            var taskType = StaffTaskType.Preparation;
            var expectedOrders = new List<StaffAssignedOrderBaseDto>
            {
                new StaffAssignedOrderBaseDto
                {
                    OrderId = 1,
                    OrderCode = "ORD-001",
                    Status = "Pending",
                    CustomerName = "John Doe",
                    CreatedAt = DateTime.Now.AddHours(-1),
                    AssignedAt = DateTime.Now
                }
            };

            this.mockStaffOrderService
                .Setup(s => s.GetAssignedOrdersAsync(123, taskType))
                .ReturnsAsync(expectedOrders);

            // Act
            var result = await staffOrderController.GetAssignedOrders(taskType);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<IEnumerable<StaffAssignedOrderBaseDto>>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Equal(expectedOrders, response.Data);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetAssignedOrders_WhenServiceThrowsException_ReturnsBadRequest()
        {
            // Arrange
            var staffOrderController = this.CreateStaffOrderController();
            var taskType = StaffTaskType.Preparation;

            this.mockStaffOrderService
                .Setup(s => s.GetAssignedOrdersAsync(123, taskType))
                .ThrowsAsync(new Exception("Service error"));

            // Act
            var result = await staffOrderController.GetAssignedOrders(taskType);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Error", response.Status);
            Assert.Equal("Failed to retrieve Preparation orders", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetAssignedOrders_WithMissingUserIdClaim_ReturnsUnauthorized()
        {
            // Arrange
            var controller = new StaffOrderController(
                this.mockStaffOrderService.Object,
                this.mockLogger.Object);

            // Setup controller context with no id claim
            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] { }, "mock"));
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            var taskType = StaffTaskType.Preparation;

            // Act
            var result = await controller.GetAssignedOrders(taskType);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result.Result);
            Assert.NotNull(unauthorizedResult.Value);
            Assert.Equal("User ID not found in token", ((dynamic)unauthorizedResult.Value).message);

            // Only verify the service mock, not the logger
            this.mockStaffOrderService.VerifyAll();
        }

        #endregion

        #region UpdateOrderStatus Tests

        [Fact]
        public async Task UpdateOrderStatus_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var staffOrderController = this.CreateStaffOrderController();
            var orderId = 1;
            var request = new UpdateOrderStatusRequest { Status = OrderStatus.Completed };
            var updatedOrder = new StaffOrderDto
            {
                OrderId = orderId,
                Status = OrderStatus.Completed.ToString(),
                OrderCode = "ORD-001"
            };

            this.mockStaffOrderService
                .Setup(s => s.UpdateOrderStatusAsync(orderId, request.Status, 123))
                .ReturnsAsync(updatedOrder);

            // Act
            var result = await staffOrderController.UpdateOrderStatus(orderId, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<StaffOrderDto>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Equal(updatedOrder, response.Data);
            Assert.Equal($"Order status updated to {request.Status} successfully", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task UpdateOrderStatus_WhenOrderNotFound_ReturnsNotFound()
        {
            // Arrange
            var staffOrderController = this.CreateStaffOrderController();
            var orderId = 999;
            var request = new UpdateOrderStatusRequest { Status = OrderStatus.Completed };

            this.mockStaffOrderService
                .Setup(s => s.UpdateOrderStatusAsync(orderId, request.Status, 123))
                .ThrowsAsync(new NotFoundException($"Order with ID {orderId} not found"));

            // Act
            var result = await staffOrderController.UpdateOrderStatus(orderId, request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Error", response.Status);
            Assert.Equal($"Order with ID {orderId} not found", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task UpdateOrderStatus_WithInvalidStatusTransition_ReturnsBadRequest()
        {
            // Arrange
            var staffOrderController = this.CreateStaffOrderController();
            var orderId = 1;
            var request = new UpdateOrderStatusRequest { Status = OrderStatus.Completed };

            this.mockStaffOrderService
                .Setup(s => s.UpdateOrderStatusAsync(orderId, request.Status, 123))
                .ThrowsAsync(new ValidationException("Cannot transition from current status to Completed"));

            // Act
            var result = await staffOrderController.UpdateOrderStatus(orderId, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Validation Error", response.Status);
            Assert.Equal("Cannot transition from current status to Completed", response.Message);
            this.mockRepository.VerifyAll();
        }

        #endregion
    }
}