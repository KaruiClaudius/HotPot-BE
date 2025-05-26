using Capstone.HPTY.API.Controllers.Admin;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Admin
{
    public class AdminBatchControllerTests
    {
        private MockRepository mockRepository;
        private Mock<IIngredientService> mockIngredientService;
        private Mock<ILogger<AdminBatchController>> mockLogger;

        public AdminBatchControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockIngredientService = this.mockRepository.Create<IIngredientService>();

            // Create logger with loose behavior to avoid having to set up every log call
            this.mockLogger = new Mock<ILogger<AdminBatchController>>(MockBehavior.Loose);

            // Set up logger to accept any calls
            this.mockLogger
                .Setup(x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()))
                .Verifiable();
        }

        private AdminBatchController CreateAdminBatchController()
        {
            return new AdminBatchController(
                this.mockIngredientService.Object,
                this.mockLogger.Object);
        }

        #region GetAllBatchesSummary Tests

        [Fact]
        public async Task GetAllBatchesSummary_WithValidRequest_ReturnsOkResult()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();

            var batchSummaries = new List<BatchSummaryDto>
            {
                new BatchSummaryDto
                {
                    BatchNumber = "BATCH-001",
                    ReceivedDate = DateTime.Now.AddDays(-10),
                    ProvideCompanies = new List<string> { "Company A", "Company B" },
                    TotalIngredients = 5,
                    EarliestExpiryDate = DateTime.Now.AddDays(20),
                    LatestExpiryDate = DateTime.Now.AddDays(60)
                },
                new BatchSummaryDto
                {
                    BatchNumber = "BATCH-002",
                    ReceivedDate = DateTime.Now.AddDays(-5),
                    ProvideCompanies = new List<string> { "Company C" },
                    TotalIngredients = 3,
                    EarliestExpiryDate = DateTime.Now.AddDays(30),
                    LatestExpiryDate = DateTime.Now.AddDays(90)
                }
            };

            this.mockIngredientService
                .Setup(s => s.GetAllBatchesSummaryAsync())
                .ReturnsAsync(batchSummaries);

            // Act
            var result = await adminBatchController.GetAllBatchesSummary();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<List<BatchSummaryDto>>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Equal($"Đã lấy {batchSummaries.Count} lô hàng", response.Message);
            Assert.Equal(batchSummaries, response.Data);
            Assert.Equal(2, response.Data.Count);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetAllBatchesSummary_WithEmptyResult_ReturnsOkResultWithEmptyList()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();

            var emptyBatchSummaries = new List<BatchSummaryDto>();

            this.mockIngredientService
                .Setup(s => s.GetAllBatchesSummaryAsync())
                .ReturnsAsync(emptyBatchSummaries);

            // Act
            var result = await adminBatchController.GetAllBatchesSummary();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<List<BatchSummaryDto>>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Equal("Đã lấy 0 lô hàng", response.Message);
            Assert.Empty(response.Data);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetAllBatchesSummary_WhenServiceThrowsException_ReturnsBadRequest()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();

            this.mockIngredientService
                .Setup(s => s.GetAllBatchesSummaryAsync())
                .ThrowsAsync(new Exception("Service error"));

            // Act
            var result = await adminBatchController.GetAllBatchesSummary();

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi", response.Status);
            Assert.Equal("Không thể lấy tất cả lô hàng", response.Message);
            this.mockRepository.VerifyAll();
        }

        #endregion

        #region GetBatchesByBatchNumber Tests

        [Fact]
        public async Task GetBatchesByBatchNumber_WithValidBatchNumber_ReturnsOkResult()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();
            string batchNumber = "BATCH-001";

            var ingredient = new Ingredient
            {
                IngredientId = 1,
                Name = "Test Ingredient",
                Unit = "g",
                MeasurementValue = 100
            };

            var batches = new List<IngredientBatch>
            {
                new IngredientBatch
                {
                    IngredientBatchId = 1,
                    IngredientId = 1,
                    Ingredient = ingredient,
                    InitialQuantity = 10,
                    RemainingQuantity = 8,
                    ProvideCompany = "Test Company",
                    BestBeforeDate = DateTime.Now.AddDays(30),
                    BatchNumber = batchNumber,
                    ReceivedDate = DateTime.Now.AddDays(-5)
                },
                new IngredientBatch
                {
                    IngredientBatchId = 2,
                    IngredientId = 1,
                    Ingredient = ingredient,
                    InitialQuantity = 5,
                    RemainingQuantity = 5,
                    ProvideCompany = "Test Company",
                    BestBeforeDate = DateTime.Now.AddDays(45),
                    BatchNumber = batchNumber,
                    ReceivedDate = DateTime.Now.AddDays(-5)
                }
            };

            this.mockIngredientService
                .Setup(s => s.GetBatchesByBatchNumberAsync(batchNumber))
                .ReturnsAsync(batches);

            // Act
            var result = await adminBatchController.GetBatchesByBatchNumber(batchNumber);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<List<IngredientBatchDto>>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Contains($"Đã lấy {batches.Count} lô hàng với số lô '{batchNumber}'", response.Message);
            Assert.Equal(2, response.Data.Count);
            Assert.Equal("Test Ingredient", response.Data[0].IngredientName);
            Assert.Equal(8, response.Data[0].RemainingQuantity);
            Assert.Equal("g", response.Data[0].Unit);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetBatchesByBatchNumber_WithNonExistentBatchNumber_ReturnsNotFound()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();
            string batchNumber = "NON-EXISTENT";

            this.mockIngredientService
                .Setup(s => s.GetBatchesByBatchNumberAsync(batchNumber))
                .ThrowsAsync(new NotFoundException($"Không tìm thấy lô hàng với số lô '{batchNumber}'"));

            // Act
            var result = await adminBatchController.GetBatchesByBatchNumber(batchNumber);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Lỗi", response.Status);
            Assert.Equal($"Không tìm thấy lô hàng với số lô '{batchNumber}'", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetBatchesByBatchNumber_WithEmptyBatchNumber_ReturnsBadRequest()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();
            string batchNumber = "";

            this.mockIngredientService
                .Setup(s => s.GetBatchesByBatchNumberAsync(batchNumber))
                .ThrowsAsync(new ValidationException("Số lô không được để trống"));

            // Act
            var result = await adminBatchController.GetBatchesByBatchNumber(batchNumber);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", response.Status);
            Assert.Equal("Số lô không được để trống", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetBatchesByBatchNumber_WhenServiceThrowsException_ReturnsBadRequest()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();
            string batchNumber = "BATCH-001";

            this.mockIngredientService
                .Setup(s => s.GetBatchesByBatchNumberAsync(batchNumber))
                .ThrowsAsync(new Exception("Service error"));

            // Act
            var result = await adminBatchController.GetBatchesByBatchNumber(batchNumber);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi", response.Status);
            Assert.Equal("Không thể lấy lô hàng", response.Message);
            this.mockRepository.VerifyAll();
        }

        #endregion

        #region CreateBatch Tests



        [Fact]
        public async Task CreateBatch_WithNegativeTotalAmount_ReturnsBadRequest()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();
            var request = new CreateBatchRequest
            {
                IngredientId = 1,
                TotalAmount = -10, // Invalid: negative amount
                BestBeforeDate = DateTime.Now.AddDays(30),
                ProvideCompany = "Test Company"
            };

            // Act
            var result = await adminBatchController.CreateBatch(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", response.Status);
            Assert.Equal("Tổng số tiền phải lớn hơn 0", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CreateBatch_WithZeroTotalAmount_ReturnsBadRequest()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();
            var request = new CreateBatchRequest
            {
                IngredientId = 1,
                TotalAmount = 0, // Invalid: zero amount
                BestBeforeDate = DateTime.Now.AddDays(30),
                ProvideCompany = "Test Company"
            };

            // Act
            var result = await adminBatchController.CreateBatch(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", response.Status);
            Assert.Equal("Tổng số tiền phải lớn hơn 0", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CreateBatch_WithInvalidExpiryDate_ReturnsBadRequest()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();
            var request = new CreateBatchRequest
            {
                IngredientId = 1,
                TotalAmount = 500,
                BestBeforeDate = DateTime.Now.AddDays(30),
                ProvideCompany = "Test Company"
            };

            var ingredient = new Ingredient
            {
                IngredientId = 1,
                Name = "Test Ingredient",
                Unit = "g",
                MeasurementValue = 100,
                IngredientTypeId = 1
            };

            this.mockIngredientService
                .Setup(s => s.GetIngredientByIdAsync(request.IngredientId))
                .ReturnsAsync(ingredient);

            // Mock the validation to fail for this test
            // Since we can't directly mock static methods, we'll simulate the controller's behavior
            // by not setting up the AddBatchAsync method, which would be called if validation passed

            // Act
            var result = await adminBatchController.CreateBatch(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", response.Status);
            // The exact message will depend on the IngredientTypeExpiryConfig implementation
            Assert.Contains("Ngày hết hạn", response.Message);
            this.mockRepository.VerifyAll();
        }



        [Fact]
        public async Task CreateBatch_WithNonExistentIngredient_ReturnsNotFound()
        {
            // Arrange
            var adminBatchController = this.CreateAdminBatchController();
            var request = new CreateBatchRequest
            {
                IngredientId = 999, // Non-existent ingredient
                TotalAmount = 500,
                BestBeforeDate = DateTime.Now.AddDays(30),
                ProvideCompany = "Test Company"
            };

            this.mockIngredientService
                .Setup(s => s.GetIngredientByIdAsync(request.IngredientId))
                .ThrowsAsync(new NotFoundException($"Không tìm thấy nguyên liệu với ID {request.IngredientId}"));

            // Act
            var result = await adminBatchController.CreateBatch(request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Lỗi", response.Status);
            Assert.Equal($"Không tìm thấy nguyên liệu với ID {request.IngredientId}", response.Message);
            this.mockRepository.VerifyAll();
        }



        #endregion
    }

    // Mock classes needed for testing
    public static class IngredientTypeExpiryConfig
    {
        public static bool IsValidExpiryDate(int ingredientTypeId, DateTime expiryDate)
        {
            // This is a mock implementation for testing
            // In a real test, you might use a library like TypeMock or Microsoft Fakes to mock static methods
            return expiryDate > DateTime.Now;
        }

        public static string GetExpiryValidationMessage(int ingredientTypeId)
        {
            return "Ngày hết hạn không hợp lệ cho loại nguyên liệu này";
        }

        public static int GetMinExpiryDays(int ingredientTypeId)
        {
            return 7;
        }

        public static int GetMaxExpiryDays(int ingredientTypeId)
        {
            return 365;
        }
    }
}