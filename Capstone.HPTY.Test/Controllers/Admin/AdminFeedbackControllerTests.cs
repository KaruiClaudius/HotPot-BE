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
                ToDate = DateTime.UtcNow.AddHours(7),
            };

            var feedbackList = new List<FeedbackListDto>
            {
                new FeedbackListDto
                {
                    FeedbackId = 1,
                    UserName = "Test User",
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
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
            Assert.Equal("Đã lấy phản hồi thành công", apiResponse.Message);
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
                FromDate = DateTime.UtcNow.AddHours(7),
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
                Comment = "This is a test feedback", // Changed from Content to Comment
                UserName = "Test User",
                UserId = 123,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
            };

            mockFeedbackService.Setup(s => s.GetFeedbackDetailByIdAsync(id))
                .ReturnsAsync(feedbackDetail);

            // Act
            var result = await adminFeedbackController.GetFeedbackById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<FeedbackDetailDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Đã lấy phản hồi thành công", apiResponse.Message);
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
            Assert.Equal($"Không tìm thấy phản hồi với ID {id}", apiResponse.Message);

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

    }


}