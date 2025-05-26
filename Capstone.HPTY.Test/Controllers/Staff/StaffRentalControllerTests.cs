using Capstone.HPTY.API.Controllers.Staff;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Staff
{
    public class StaffRentalControllerTests
    {
        private MockRepository mockRepository;
        private Mock<IStaffService> mockStaffService;
        private Mock<IEquipmentReturnService> mockEquipmentReturnService;

        public StaffRentalControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockStaffService = this.mockRepository.Create<IStaffService>();
            this.mockEquipmentReturnService = this.mockRepository.Create<IEquipmentReturnService>();
        }

        private StaffRentalController CreateStaffRentalController(bool withUserClaims = true)
        {
            var controller = new StaffRentalController(
                this.mockStaffService.Object,
                this.mockEquipmentReturnService.Object);

            // Setup controller context
            var claims = new List<Claim>();
            if (withUserClaims)
            {
                claims.Add(new Claim("id", "123"));
            }

            var user = new ClaimsPrincipal(new ClaimsIdentity(claims, "mock"));
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };

            return controller;
        }

        #region GetMyAssignments Tests

        [Fact]
        public async Task GetMyAssignments_WithValidParameters_ReturnsOkResult()
        {
            // Arrange
            var staffRentalController = this.CreateStaffRentalController();
            bool pendingOnly = false;
            int pageNumber = 1;
            int pageSize = 10;

            var expectedAssignments = new PagedResult<StaffPickupAssignmentDto>
            {
                Items = new List<StaffPickupAssignmentDto>
                {
                    new StaffPickupAssignmentDto
                    {
                        AssignmentId = 1,
                        OrderId = 101,
                        OrderCode = "ORD-101",
                        StaffId = 123,
                        StaffName = "John Doe",
                        AssignedDate = DateTime.Now.AddDays(-1),
                        CustomerName = "Customer 1",
                        CustomerAddress = "123 Main St",
                        CustomerPhone = "555-1234"
                    }
                },
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 1
            };

            this.mockStaffService
                .Setup(s => s.GetStaffAssignmentsPaginatedAsync(123, pendingOnly, pageNumber, pageSize))
                .ReturnsAsync(expectedAssignments);

            // Act
            var result = await staffRentalController.GetMyAssignments(pendingOnly, pageNumber, pageSize);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<PagedResult<StaffPickupAssignmentDto>>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Equal(expectedAssignments, response.Data);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetMyAssignments_WithMissingUserIdClaim_ReturnsUnauthorized()
        {
            // Arrange
            var staffRentalController = this.CreateStaffRentalController(withUserClaims: false);
            bool pendingOnly = false;
            int pageNumber = 1;
            int pageSize = 10;

            // Act
            var result = await staffRentalController.GetMyAssignments(pendingOnly, pageNumber, pageSize);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result.Result);
            Assert.Equal("User ID not found in claims", unauthorizedResult.Value);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetMyAssignments_WhenServiceThrowsException_ReturnsInternalServerError()
        {
            // Arrange
            var staffRentalController = this.CreateStaffRentalController();
            bool pendingOnly = false;
            int pageNumber = 1;
            int pageSize = 10;

            this.mockStaffService
                .Setup(s => s.GetStaffAssignmentsPaginatedAsync(123, pendingOnly, pageNumber, pageSize))
                .ThrowsAsync(new Exception("Service error"));

            // Act
            var result = await staffRentalController.GetMyAssignments(pendingOnly, pageNumber, pageSize);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            var response = Assert.IsType<ApiResponse<PagedResult<StaffPickupAssignmentDto>>>(statusCodeResult.Value);
            Assert.False(response.Success);
            Assert.Equal("Service error", response.Message);
            this.mockRepository.VerifyAll();
        }

        #endregion

        #region RecordReturn Tests

        [Fact]
        public async Task RecordReturn_WithValidAssignmentId_ReturnsOkResult()
        {
            // Arrange
            var staffRentalController = this.CreateStaffRentalController();
            var request = new UnifiedReturnRequestDto
            {
                AssignmentId = 1,
                RentOrderId = 101,
                CompletedDate = DateTime.Now,
                ReturnCondition = "Good",
                DamageFee = 0,
                Notes = "Returned in good condition"
            };

            var staffAssignments = new List<StaffPickupAssignmentDto>
            {
                new StaffPickupAssignmentDto
                {
                    AssignmentId = 1,
                    OrderId = 101,
                    StaffId = 123
                }
            };

            this.mockStaffService
                .Setup(s => s.GetStaffAssignmentsAsync(123))
                .ReturnsAsync(staffAssignments);

            this.mockEquipmentReturnService
                .Setup(s => s.CompletePickupAssignmentAsync(1))
                .ReturnsAsync(true);

            // Act
            var result = await staffRentalController.RecordReturn(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<bool>>(okResult.Value);
            Assert.True(response.Success);
            Assert.True(response.Data);
            Assert.Equal("Return recorded successfully", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task RecordReturn_WithMissingUserIdClaim_ReturnsUnauthorized()
        {
            // Arrange
            var staffRentalController = this.CreateStaffRentalController(withUserClaims: false);
            var request = new UnifiedReturnRequestDto
            {
                AssignmentId = 1,
                RentOrderId = 101,
                CompletedDate = DateTime.Now,
                ReturnCondition = "Good"
            };

            // Act
            var result = await staffRentalController.RecordReturn(request);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result.Result);
            Assert.Equal("User ID not found in claims", unauthorizedResult.Value);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task RecordReturn_WithInvalidAssignment_ReturnsNotFound()
        {
            // Arrange
            var staffRentalController = this.CreateStaffRentalController();
            var request = new UnifiedReturnRequestDto
            {
                AssignmentId = 999, // Non-existent assignment
                RentOrderId = 101,
                CompletedDate = DateTime.Now,
                ReturnCondition = "Good"
            };

            // Return empty list to simulate no assignments found
            this.mockStaffService
                .Setup(s => s.GetStaffAssignmentsAsync(123))
                .ReturnsAsync(new List<StaffPickupAssignmentDto>());

            // Act
            var result = await staffRentalController.RecordReturn(request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<bool>>(notFoundResult.Value);
            Assert.False(response.Success);
            Assert.Equal("Assignment not found or does not belong to you", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task RecordReturn_WithMissingRequiredIds_ReturnsBadRequest()
        {
            // Arrange
            var staffRentalController = this.CreateStaffRentalController();
            var request = new UnifiedReturnRequestDto
            {
                // Missing AssignmentId, RentOrderId, and RentOrderDetailId
                CompletedDate = DateTime.Now,
                ReturnCondition = "Good"
            };

            // Act
            var result = await staffRentalController.RecordReturn(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<bool>>(badRequestResult.Value);
            Assert.False(response.Success);
            Assert.Equal("Either AssignmentId, OrderId, or RentOrderDetailId must be provided", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task RecordReturn_WhenServiceThrowsNotFoundException_ReturnsNotFound()
        {
            // Arrange
            var staffRentalController = this.CreateStaffRentalController();
            var request = new UnifiedReturnRequestDto
            {
                AssignmentId = 1,
                RentOrderId = 101,
                CompletedDate = DateTime.Now,
                ReturnCondition = "Good"
            };

            var staffAssignments = new List<StaffPickupAssignmentDto>
            {
                new StaffPickupAssignmentDto
                {
                    AssignmentId = 1,
                    OrderId = 101,
                    StaffId = 123
                }
            };

            this.mockStaffService
                .Setup(s => s.GetStaffAssignmentsAsync(123))
                .ReturnsAsync(staffAssignments);

            this.mockEquipmentReturnService
                .Setup(s => s.CompletePickupAssignmentAsync(1))
                .ThrowsAsync(new NotFoundException("Assignment not found"));

            // Act
            var result = await staffRentalController.RecordReturn(request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<bool>>(notFoundResult.Value);
            Assert.False(response.Success);
            Assert.Equal("Assignment not found", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task RecordReturn_WhenServiceThrowsValidationException_ReturnsBadRequest()
        {
            // Arrange
            var staffRentalController = this.CreateStaffRentalController();
            var request = new UnifiedReturnRequestDto
            {
                AssignmentId = 1,
                RentOrderId = 101,
                CompletedDate = DateTime.Now,
                ReturnCondition = "Good"
            };

            var staffAssignments = new List<StaffPickupAssignmentDto>
            {
                new StaffPickupAssignmentDto
                {
                    AssignmentId = 1,
                    OrderId = 101,
                    StaffId = 123
                }
            };

            this.mockStaffService
                .Setup(s => s.GetStaffAssignmentsAsync(123))
                .ReturnsAsync(staffAssignments);

            this.mockEquipmentReturnService
                .Setup(s => s.CompletePickupAssignmentAsync(1))
                .ThrowsAsync(new ValidationException("Invalid return condition"));

            // Act
            var result = await staffRentalController.RecordReturn(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<bool>>(badRequestResult.Value);
            Assert.False(response.Success);
            Assert.Equal("Invalid return condition", response.Message);
            this.mockRepository.VerifyAll();
        }

        #endregion
    }
}