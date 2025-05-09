using Capstone.HPTY.API.Controllers.Admin;
using Capstone.HPTY.ServiceLayer.DTOs.Discount;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ModelLayer.Entities;
using System.Collections.Generic;

namespace Capstone.HPTY.Test.Controllers.Admin
{
    public class AdminDiscountControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IDiscountService> mockDiscountService;
        private Mock<ILogger<AdminDiscountController>> mockLogger;

        public AdminDiscountControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDiscountService = this.mockRepository.Create<IDiscountService>();
            this.mockLogger = this.mockRepository.Create<ILogger<AdminDiscountController>>();

            // Setup logger to accept any calls
            mockLogger.Setup(x => x.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()));
        }

        private AdminDiscountController CreateAdminDiscountController()
        {
            return new AdminDiscountController(
                this.mockDiscountService.Object,
                this.mockLogger.Object);
        }

        [Fact]
        public async Task GetDiscounts_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var adminDiscountController = this.CreateAdminDiscountController();
            string searchTerm = null;
            decimal? minDiscountPercentage = null;
            decimal? maxDiscountPercentage = null;
            double? minPointCost = null;
            double? maxPointCost = null;
            DateTime? startDateFrom = null;
            DateTime? startDateTo = null;
            DateTime? endDateFrom = null;
            DateTime? endDateTo = null;
            bool? isActive = null;
            bool? isUpcoming = null;
            bool? isExpired = null;
            int pageNumber = 1; // Changed from 0 to 1 (valid value)
            int pageSize = 10;  // Changed from 0 to 10 (valid value)
            string sortBy = "CreatedAt";
            bool ascending = false;

            var discounts = new List<Discount>
            {
                new Discount
                {
                    DiscountId = 1,
                    Title = "Test Discount",
                    Description = "Test Description",
                    DiscountPercentage = 10,
                    Date = DateTime.UtcNow,
                    Duration = DateTime.UtcNow.AddDays(7),
                    PointCost = 100,
                    CreatedAt = DateTime.UtcNow.AddDays(-1),
                    UpdatedAt = DateTime.UtcNow
                }
            };

            var pagedResult = new PagedResult<Discount>
            {
                Items = discounts,
                PageNumber = 1,
                PageSize = 10,
                TotalCount = 1
            };

            mockDiscountService.Setup(s => s.GetDiscountsAsync(
                searchTerm, minDiscountPercentage, maxDiscountPercentage,
                minPointCost, maxPointCost, startDateFrom, startDateTo,
                endDateFrom, endDateTo, isActive, isUpcoming, isExpired,
                pageNumber, pageSize, sortBy, ascending))
                .ReturnsAsync(pagedResult);

            mockDiscountService.Setup(s => s.GetOrderCountsByDiscountsAsync(It.IsAny<List<int>>()))
                .ReturnsAsync(new Dictionary<int, int> { { 1, 5 } });

            // Act
            var result = await adminDiscountController.GetDiscounts(
                searchTerm,
                minDiscountPercentage,
                maxDiscountPercentage,
                minPointCost,
                maxPointCost,
                startDateFrom,
                startDateTo,
                endDateFrom,
                endDateTo,
                isActive,
                isUpcoming,
                isExpired,
                pageNumber,
                pageSize,
                sortBy,
                ascending);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<DiscountDto>>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Discounts retrieved successfully", apiResponse.Message);

            var items = apiResponse.Data.Items.ToList();
            Assert.Single(items);
            Assert.Equal(1, items[0].DiscountId);
            Assert.Equal(5, items[0].OrderCount);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetDiscountById_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var adminDiscountController = this.CreateAdminDiscountController();
            int id = 1;

            var discount = new Discount
            {
                DiscountId = id,
                Title = "Test Discount",
                Description = "Test Description",
                DiscountPercentage = 10,
                Date = DateTime.UtcNow,
                Duration = DateTime.UtcNow.AddDays(7),
                PointCost = 100,
                CreatedAt = DateTime.UtcNow.AddDays(-1),
                UpdatedAt = DateTime.UtcNow
            };

            mockDiscountService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(discount);

            mockDiscountService.Setup(s => s.GetOrderCountByDiscountAsync(id))
                .ReturnsAsync(3);

            // Act
            var result = await adminDiscountController.GetDiscountById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<DiscountDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Discount retrieved successfully", apiResponse.Message);
            Assert.Equal(id, apiResponse.Data.DiscountId);
            Assert.Equal(3, apiResponse.Data.OrderCount);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CreateDiscount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var adminDiscountController = this.CreateAdminDiscountController();
            var request = new DiscountRequest
            {
                Title = "New Discount",
                Description = "New Description",
                DiscountPercentage = 15,
                Date = DateTime.UtcNow,
                Duration = DateTime.UtcNow.AddDays(10),
                PointCost = 200
            };

            var createdDiscount = new Discount
            {
                DiscountId = 1,
                Title = request.Title,
                Description = request.Description,
                DiscountPercentage = request.DiscountPercentage,
                Date = request.Date,
                Duration = request.Duration,
                PointCost = request.PointCost,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null
            };

            mockDiscountService.Setup(s => s.CreateAsync(It.IsAny<Discount>()))
                .ReturnsAsync(createdDiscount);

            // Act
            var result = await adminDiscountController.CreateDiscount(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<DiscountDto>>(createdAtActionResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Discount created successfully", apiResponse.Message);
            Assert.Equal(1, apiResponse.Data.DiscountId);
            Assert.Equal(request.Title, apiResponse.Data.Title);
            Assert.Equal(0, apiResponse.Data.OrderCount);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task UpdateDiscount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var adminDiscountController = this.CreateAdminDiscountController();
            int id = 1;
            var request = new DiscountRequest
            {
                Title = "Updated Discount",
                Description = "Updated Description",
                DiscountPercentage = 20,
                Date = DateTime.UtcNow,
                Duration = DateTime.UtcNow.AddDays(15),
                PointCost = 300
            };

            var existingDiscount = new Discount
            {
                DiscountId = id,
                Title = "Old Title",
                Description = "Old Description",
                DiscountPercentage = 10,
                Date = DateTime.UtcNow.AddDays(-1),
                Duration = DateTime.UtcNow.AddDays(5),
                PointCost = 100,
                CreatedAt = DateTime.UtcNow.AddDays(-2),
                UpdatedAt = null
            };

            mockDiscountService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingDiscount);

            mockDiscountService.Setup(s => s.UpdateAsync(id, It.IsAny<Discount>()))
                .Returns(Task.CompletedTask);

            mockDiscountService.Setup(s => s.GetOrderCountByDiscountAsync(id))
                .ReturnsAsync(2);

            // Act
            var result = await adminDiscountController.UpdateDiscount(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<DiscountDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Discount updated successfully", apiResponse.Message);
            Assert.Equal(id, apiResponse.Data.DiscountId);
            Assert.Equal(request.Title, apiResponse.Data.Title);
            Assert.Equal(2, apiResponse.Data.OrderCount);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task DeleteDiscount_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var adminDiscountController = this.CreateAdminDiscountController();
            int id = 1;

            mockDiscountService.Setup(s => s.DeleteAsync(id))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminDiscountController.DeleteDiscount(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Discount deleted successfully", apiResponse.Message);
            Assert.Equal($"Discount with ID {id} has been deleted", apiResponse.Data);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CheckSufficientPoints_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var adminDiscountController = this.CreateAdminDiscountController();
            int discountId = 1;
            double userPoints = 500;

            mockDiscountService.Setup(s => s.HasSufficientPointsAsync(discountId, userPoints))
                .ReturnsAsync(true);

            // Act
            var result = await adminDiscountController.CheckSufficientPoints(discountId, userPoints);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<bool>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("User has sufficient points for this discount", apiResponse.Message);
            Assert.True(apiResponse.Data);

            this.mockRepository.VerifyAll();
        }
    }
}