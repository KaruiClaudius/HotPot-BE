using Capstone.HPTY.API.Controllers.Admin;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Feedback;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.FeedbackService;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Admin
{
    public class AdminFeedbackControllerTests
    {
        private MockRepository mockRepository;
        private Mock<IFeedbackService> mockFeedbackService;
        private Mock<INotificationService> mockNotificationService;

        public AdminFeedbackControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockFeedbackService = this.mockRepository.Create<IFeedbackService>();
            this.mockNotificationService = this.mockRepository.Create<INotificationService>();
        }

        private AdminFeedbackController CreateAdminFeedbackController()
        {
            return new AdminFeedbackController(
                this.mockFeedbackService.Object,
                this.mockNotificationService.Object);
        }

        [Fact]
        public async Task GetFilteredFeedback_ReturnsPagedResult_WhenRequestIsValid()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            var request = new FeedbackFilterRequest
            {
                PageNumber = 1,
                PageSize = 10,
                SearchTerm = "test",
                FromDate = DateTime.UtcNow.AddDays(-30),
                ToDate = DateTime.UtcNow,
                ApprovalStatus = FeedbackApprovalStatus.Pending
            };

            var feedbackList = new List<FeedbackListDto>
            {
                new FeedbackListDto
                {
                    FeedbackId = 1,
                    Title = "Test Feedback",
                    UserName = "Test User",
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    ApprovalStatus = FeedbackApprovalStatus.Pending.ToString()
                }
            };

            var pagedResult = new PagedResult<FeedbackListDto>
            {
                Items = feedbackList,
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 1
            };

            mockFeedbackService.Setup(s => s.GetFilteredFeedbackAsync(It.IsAny<FeedbackFilterRequest>()))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminFeedbackController.GetFilteredFeedback(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<FeedbackListDto>>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Feedback retrieved successfully", apiResponse.Message);
            Assert.Equal(1, apiResponse.Data.TotalCount);

            var items = apiResponse.Data.Items.ToList();
            Assert.Single(items);
            Assert.Equal(1, items[0].FeedbackId);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetFilteredFeedback_FixesInvalidParameters_WhenRequestHasInvalidValues()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            var request = new FeedbackFilterRequest
            {
                PageNumber = 0, // Invalid, should be fixed to 1
                PageSize = 0,   // Invalid, should be fixed to 10
                FromDate = DateTime.UtcNow,
                ToDate = DateTime.UtcNow.AddDays(-10) // Invalid order, should be swapped
            };

            var pagedResult = new PagedResult<FeedbackListDto>
            {
                Items = new List<FeedbackListDto>(),
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 0
            };

            // Verify that the service is called with corrected parameters
            mockFeedbackService.Setup(s => s.GetFilteredFeedbackAsync(It.Is<FeedbackFilterRequest>(r =>
                r.PageNumber == 1 &&
                r.PageSize == 10 &&
                r.FromDate < r.ToDate)))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminFeedbackController.GetFilteredFeedback(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<FeedbackListDto>>>(okResult.Value);
            Assert.True(apiResponse.Success);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetFeedbackById_ReturnsFeedback_WhenFeedbackExists()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 1;

            var feedbackDetail = new FeedbackDetailDto
            {
                FeedbackId = id,
                Title = "Test Feedback",
                Comment = "This is a test feedback", // Changed from Content to Comment
                UserName = "Test User",
                UserId = 123,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                ApprovalStatus = FeedbackApprovalStatus.Pending.ToString() // Changed from Status to ApprovalStatus
            };

            mockFeedbackService.Setup(s => s.GetFeedbackDetailByIdAsync(id))
                .ReturnsAsync(feedbackDetail);

            // Act
            var result = await adminFeedbackController.GetFeedbackById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Feedback retrieved successfully", apiResponse.Message);
            Assert.Equal(id, apiResponse.Data.FeedbackId);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetFeedbackById_ReturnsNotFound_WhenFeedbackDoesNotExist()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 999;

            mockFeedbackService.Setup(s => s.GetFeedbackDetailByIdAsync(id))
                .ReturnsAsync((FeedbackDetailDto)null);

            // Act
            var result = await adminFeedbackController.GetFeedbackById(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(notFoundResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal($"Feedback with ID {id} not found", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetFeedbackById_ReturnsNotFound_WhenNotFoundExceptionIsThrown()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 999;

            mockFeedbackService.Setup(s => s.GetFeedbackDetailByIdAsync(id))
                .ThrowsAsync(new NotFoundException($"Feedback with ID {id} not found"));

            // Act
            var result = await adminFeedbackController.GetFeedbackById(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(notFoundResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal($"Feedback with ID {id} not found", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetFeedbackByStatus_ReturnsPagedResult_WhenStatusIsValid()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            var status = FeedbackApprovalStatus.Approved;
            int pageNumber = 1;
            int pageSize = 10;

            var managerFeedbackList = new List<ManagerFeedbackListDto>
            {
                new ManagerFeedbackListDto
                {
                    FeedbackId = 1,
                    Title = "Test Feedback",
                    Comment = "Test Comment",
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    ApprovalStatus = status,
                    User = new UserInfoDto { UserId = 1, Name= "User1", Email="user1@gmail.com" }, // Assuming UserInfoDto has a Name property
                    Order = new OrderInfoDto { OrderId = 123 } // Assuming OrderInfoDto has an OrderId property
                }
            };

            var pagedResult = new PagedResult<ManagerFeedbackListDto>
            {
                Items = managerFeedbackList,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockFeedbackService.Setup(s => s.GetFeedbackByStatusAsync(status, pageNumber, pageSize))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminFeedbackController.GetFeedbackByStatus(status, pageNumber, pageSize);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<ManagerFeedbackListDto>>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Approved feedback retrieved successfully", apiResponse.Message);
            Assert.Equal(1, apiResponse.Data.TotalCount);

            var items = apiResponse.Data.Items.ToList();
            Assert.Single(items);
            Assert.Equal(1, items[0].FeedbackId);
            Assert.Equal(status, items[0].ApprovalStatus);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ApproveFeedback_ReturnsFeedback_WhenFeedbackExists()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 1;
            var request = new ApproveFeedbackRequest
            {
                AdminUserId = 456
            };

            var feedbackDetail = new FeedbackDetailDto
            {
                FeedbackId = id,
                Title = "Test Feedback",
                Comment = "This is a test feedback", // Changed from Content to Comment
                UserName = "Test User",
                UserId = 123,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                ApprovalStatus = FeedbackApprovalStatus.Approved.ToString(), // Changed from Status to ApprovalStatus
                ApprovedByUserId = request.AdminUserId,
                ApprovedByUserName = "Admin User",
                ApprovalDate = DateTime.UtcNow // Changed from ApprovedAt to ApprovalDate
            };

            mockFeedbackService.Setup(s => s.ApproveFeedbackAsync(id, request.AdminUserId))
                .ReturnsAsync(feedbackDetail);

            mockNotificationService.Setup(s => s.NotifyRole(
                "Managers",
                "FeedbackApproved",
                "Feedback Approved",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            mockNotificationService.Setup(s => s.NotifyUser(
                feedbackDetail.UserId,
                "FeedbackResponse",
                "Feedback Approved",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminFeedbackController.ApproveFeedback(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Feedback approved successfully", apiResponse.Message);
            Assert.Equal(id, apiResponse.Data.FeedbackId);
            Assert.Equal(FeedbackApprovalStatus.Approved.ToString(), apiResponse.Data.ApprovalStatus);
            Assert.Equal(request.AdminUserId, apiResponse.Data.ApprovedByUserId);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ApproveFeedback_ReturnsNotFound_WhenFeedbackDoesNotExist()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 999;
            var request = new ApproveFeedbackRequest
            {
                AdminUserId = 456
            };

            mockFeedbackService.Setup(s => s.ApproveFeedbackAsync(id, request.AdminUserId))
                .ThrowsAsync(new KeyNotFoundException($"Feedback with ID {id} not found"));

            // Act
            var result = await adminFeedbackController.ApproveFeedback(id, request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(notFoundResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal($"Feedback with ID {id} not found", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task RejectFeedback_ReturnsFeedback_WhenFeedbackExists()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 1;
            var request = new RejectFeedbackRequest
            {
                AdminUserId = 456,
                RejectionReason = "Inappropriate content"
            };

            var feedbackDetail = new FeedbackDetailDto
            {
                FeedbackId = id,
                Title = "Test Feedback",
                Comment = "This is a test feedback", // Changed from Content to Comment
                UserName = "Test User",
                UserId = 123,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                ApprovalStatus = FeedbackApprovalStatus.Rejected.ToString(), // Changed from Status to ApprovalStatus
                ApprovedByUserId = request.AdminUserId,
                ApprovedByUserName = "Admin User",
                ApprovalDate = DateTime.UtcNow, // Changed from ApprovedAt to ApprovalDate
                RejectionReason = request.RejectionReason
            };

            mockFeedbackService.Setup(s => s.RejectFeedbackAsync(id, request.AdminUserId, request.RejectionReason))
                .ReturnsAsync(feedbackDetail);

            mockNotificationService.Setup(s => s.NotifyUser(
                feedbackDetail.UserId,
                "FeedbackResponse",
                "Feedback Not Approved",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminFeedbackController.RejectFeedback(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Feedback rejected successfully", apiResponse.Message);
            Assert.Equal(id, apiResponse.Data.FeedbackId);
            Assert.Equal(FeedbackApprovalStatus.Rejected.ToString(), apiResponse.Data.ApprovalStatus);
            Assert.Equal(request.AdminUserId, apiResponse.Data.ApprovedByUserId);
            Assert.Equal(request.RejectionReason, apiResponse.Data.RejectionReason);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task RejectFeedback_ReturnsNotFound_WhenFeedbackDoesNotExist()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 999;
            var request = new RejectFeedbackRequest
            {
                AdminUserId = 456,
                RejectionReason = "Inappropriate content"
            };

            mockFeedbackService.Setup(s => s.RejectFeedbackAsync(id, request.AdminUserId, request.RejectionReason))
                .ThrowsAsync(new KeyNotFoundException($"Feedback with ID {id} not found"));

            // Act
            var result = await adminFeedbackController.RejectFeedback(id, request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(notFoundResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal($"Feedback with ID {id} not found", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task RejectFeedback_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 1;
            var request = new RejectFeedbackRequest
            {
                AdminUserId = 456,
                RejectionReason = "Inappropriate content"
            };

            mockFeedbackService.Setup(s => s.RejectFeedbackAsync(id, request.AdminUserId, request.RejectionReason))
                .ThrowsAsync(new Exception("An error occurred while rejecting feedback"));

            // Act
            var result = await adminFeedbackController.RejectFeedback(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(badRequestResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while rejecting feedback", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetFeedbackStats_ReturnsStats_WhenCalled()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();

            var stats = new FeedbackStats
            {
                TotalFeedbackCount = 100,
                PendingFeedbackCount = 20,
                ApprovedFeedbackCount = 70,
                RejectedFeedbackCount = 10,
                UnrespondedFeedbackCount = 30,
                RespondedFeedbackCount = 70,
                ResponseRate = 0.7
            };

            mockFeedbackService.Setup(s => s.GetFeedbackStatsAsync())
                .ReturnsAsync(stats);

            // Act
            var result = await adminFeedbackController.GetFeedbackStats();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackStats>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Feedback statistics retrieved successfully", apiResponse.Message);
            Assert.Equal(100, apiResponse.Data.TotalFeedbackCount);
            Assert.Equal(20, apiResponse.Data.PendingFeedbackCount);
            Assert.Equal(70, apiResponse.Data.ApprovedFeedbackCount);
            Assert.Equal(10, apiResponse.Data.RejectedFeedbackCount);
            Assert.Equal(30, apiResponse.Data.UnrespondedFeedbackCount);
            Assert.Equal(70, apiResponse.Data.RespondedFeedbackCount);
            Assert.Equal(0.7, apiResponse.Data.ResponseRate);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetFilteredFeedback_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            var request = new FeedbackFilterRequest
            {
                PageNumber = 1,
                PageSize = 10
            };

            mockFeedbackService.Setup(s => s.GetFilteredFeedbackAsync(It.IsAny<FeedbackFilterRequest>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminFeedbackController.GetFilteredFeedback(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<FeedbackListDto>>>(badRequestResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("Database connection error", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetFeedbackById_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 1;

            mockFeedbackService.Setup(s => s.GetFeedbackDetailByIdAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminFeedbackController.GetFeedbackById(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(badRequestResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("Database connection error", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetFeedbackByStatus_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            var status = FeedbackApprovalStatus.Pending;
            int pageNumber = 1;
            int pageSize = 10;

            mockFeedbackService.Setup(s => s.GetFeedbackByStatusAsync(status, pageNumber, pageSize))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminFeedbackController.GetFeedbackByStatus(status, pageNumber, pageSize);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<ManagerFeedbackListDto>>>(badRequestResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("Database connection error", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ApproveFeedback_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 1;
            var request = new ApproveFeedbackRequest
            {
                AdminUserId = 456
            };

            mockFeedbackService.Setup(s => s.ApproveFeedbackAsync(id, request.AdminUserId))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminFeedbackController.ApproveFeedback(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(badRequestResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("Database connection error", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task ApproveFeedback_DoesNotNotifyUser_WhenUserIdIsZero()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 1;
            var request = new ApproveFeedbackRequest
            {
                AdminUserId = 456
            };

            var feedbackDetail = new FeedbackDetailDto
            {
                FeedbackId = id,
                Title = "Test Feedback",
                Comment = "This is a test feedback",
                UserName = "Anonymous",
                UserId = 0, // Anonymous user
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                ApprovalStatus = FeedbackApprovalStatus.Approved.ToString(),
                ApprovedByUserId = request.AdminUserId,
                ApprovedByUserName = "Admin User",
                ApprovalDate = DateTime.UtcNow
            };

            mockFeedbackService.Setup(s => s.ApproveFeedbackAsync(id, request.AdminUserId))
                .ReturnsAsync(feedbackDetail);

            mockNotificationService.Setup(s => s.NotifyRole(
                "Managers",
                "FeedbackApproved",
                "Feedback Approved",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // No setup for NotifyUser since it shouldn't be called

            // Act
            var result = await adminFeedbackController.ApproveFeedback(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Feedback approved successfully", apiResponse.Message);

            // Verify that NotifyUser was not called
            mockNotificationService.Verify(s => s.NotifyUser(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task RejectFeedback_DoesNotNotifyUser_WhenUserIdIsZero()
        {
            // Arrange
            var adminFeedbackController = this.CreateAdminFeedbackController();
            int id = 1;
            var request = new RejectFeedbackRequest
            {
                AdminUserId = 456,
                RejectionReason = "Inappropriate content"
            };

            var feedbackDetail = new FeedbackDetailDto
            {
                FeedbackId = id,
                Title = "Test Feedback",
                Comment = "This is a test feedback",
                UserName = "Anonymous",
                UserId = 0, // Anonymous user
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                ApprovalStatus = FeedbackApprovalStatus.Rejected.ToString(),
                ApprovedByUserId = request.AdminUserId,
                ApprovedByUserName = "Admin User",
                ApprovalDate = DateTime.UtcNow,
                RejectionReason = request.RejectionReason
            };

            mockFeedbackService.Setup(s => s.RejectFeedbackAsync(id, request.AdminUserId, request.RejectionReason))
                .ReturnsAsync(feedbackDetail);

            // No setup for NotifyUser since it shouldn't be called

            // Act
            var result = await adminFeedbackController.RejectFeedback(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Feedback rejected successfully", apiResponse.Message);

            // Verify that NotifyUser was not called
            mockNotificationService.Verify(s => s.NotifyUser(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);

            this.mockRepository.VerifyAll();
        }
    }

    // Define these classes if they don't exist in your test project



}