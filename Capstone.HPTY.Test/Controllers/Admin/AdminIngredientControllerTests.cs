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
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Admin
{
    public class AdminIngredientControllerTests
    {
        private MockRepository mockRepository;
        private Mock<IIngredientService> mockIngredientService;
        private Mock<ILogger<AdminIngredientController>> mockLogger;

        public AdminIngredientControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockIngredientService = this.mockRepository.Create<IIngredientService>();

            // Create logger with loose behavior to avoid having to set up every log call
            this.mockLogger = new Mock<ILogger<AdminIngredientController>>(MockBehavior.Loose);

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

        private AdminIngredientController CreateAdminIngredientController()
        {
            return new AdminIngredientController(
                this.mockIngredientService.Object,
                this.mockLogger.Object);
        }

        #region GetAllIngredients Tests

        [Fact]
        public async Task GetAllIngredients_WithValidParameters_ReturnsOkResult()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            string searchTerm = "test";
            int? typeId = 1;
            bool? isLowStock = false;
            int pageNumber = 1;
            int pageSize = 10;
            decimal? minPrice = 10;
            decimal? maxPrice = 100;
            string sortBy = "Name";
            bool ascending = true;

            var ingredients = new List<Ingredient>
            {
                new Ingredient
                {
                    IngredientId = 1,
                    Name = "Test Ingredient",
                    Description = "Test Description",
                    ImageURL = "test.jpg",
                    MinStockLevel = 10,
                    Unit = "g",
                    MeasurementValue = 100,
                    IngredientTypeId = 1,
                    IngredientType = new IngredientType { Name = "Test Type" },
                    CreatedAt = DateTime.Now.AddDays(-10),
                    UpdatedAt = DateTime.Now
                }
            };

            var pagedResult = new PagedResult<Ingredient>
            {
                Items = ingredients,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            var currentPrices = new Dictionary<int, decimal>
            {
                { 1, 50.0m }
            };

            this.mockIngredientService
                .Setup(s => s.GetIngredientsAsync(
                    searchTerm, typeId, isLowStock, minPrice, maxPrice,
                    pageNumber, pageSize, sortBy, ascending))
                .ReturnsAsync(pagedResult);

            this.mockIngredientService
                .Setup(s => s.GetCurrentPricesAsync(It.Is<List<int>>(ids => ids.Contains(1))))
                .ReturnsAsync(currentPrices);

            // Act
            var result = await adminIngredientController.GetAllIngredients(
                searchTerm, typeId, isLowStock, pageNumber, pageSize,
                minPrice, maxPrice, sortBy, ascending);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<PagedResult<IngredientDto>>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Equal("Đã lấy nguyên liệu thành công", response.Message);
            Assert.Equal(1, response.Data.Items.Count());
            Assert.Equal("Test Ingredient", response.Data.Items.First().Name);
            Assert.Equal(50.0m, response.Data.Items.First().Price);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetAllIngredients_WithInvalidPageParameters_ReturnsBadRequest()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            int pageNumber = 0; // Invalid page number
            int pageSize = 0; // Invalid page size

            // Act
            var result = await adminIngredientController.GetAllIngredients(
                pageNumber: pageNumber, pageSize: pageSize);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi", response.Status);
            Assert.Equal("Số trang và kích thước trang phải lớn hơn 0", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetAllIngredients_WhenServiceThrowsException_ReturnsBadRequest()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            int pageNumber = 1;
            int pageSize = 10;

            this.mockIngredientService
                .Setup(s => s.GetIngredientsAsync(
                    null, null, null, null, null,
                    pageNumber, pageSize, "Name", true))
                .ThrowsAsync(new Exception("Service error"));

            // Act
            var result = await adminIngredientController.GetAllIngredients(
                pageNumber: pageNumber, pageSize: pageSize);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi", response.Status);
            Assert.Equal("Không thể lấy danh sách nguyên liệu", response.Message);
            this.mockRepository.VerifyAll();
        }

        #endregion

        #region GetIngredientById Tests

        [Fact]
        public async Task GetIngredientById_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            int id = 1;

            var ingredient = new Ingredient
            {
                IngredientId = id,
                Name = "Test Ingredient",
                Description = "Test Description",
                ImageURL = "test.jpg",
                MinStockLevel = 10,
                Unit = "g",
                MeasurementValue = 100,
                IngredientTypeId = 1,
                IngredientType = new IngredientType { Name = "Test Type" },
                CreatedAt = DateTime.Now.AddDays(-10),
                UpdatedAt = DateTime.Now
            };

            var batches = new List<IngredientBatch>
            {
                new IngredientBatch
                {
                    IngredientBatchId = 1,
                    IngredientId = id,
                    InitialQuantity = 20,
                    RemainingQuantity = 20,
                    ProvideCompany = "Test Company",
                    BestBeforeDate = DateTime.Now.AddDays(30),
                    BatchNumber = "BATCH-001",
                    ReceivedDate = DateTime.Now.AddDays(-10)
                }
            };

            var prices = new List<IngredientPrice>
            {
                new IngredientPrice
                {
                    IngredientId = id,
                    Price = 50.0m,
                    EffectiveDate = DateTime.Now.AddDays(-10),
                    Ingredient = ingredient
                }
            };

            this.mockIngredientService
                .Setup(s => s.GetIngredientByIdAsync(id))
                .ReturnsAsync(ingredient);

            this.mockIngredientService
                .Setup(s => s.GetCurrentPriceAsync(id))
                .ReturnsAsync(50.0m);

            this.mockIngredientService
                .Setup(s => s.GetIngredientBatchesAsync(id))
                .ReturnsAsync(batches);

            this.mockIngredientService
                .Setup(s => s.GetAllPricesAsync(id))
                .ReturnsAsync(prices);

            // Act
            var result = await adminIngredientController.GetIngredientById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<ApiResponse<IngredientDetailDto>>(okResult.Value);
            Assert.True(response.Success);
            Assert.Equal("Đã lấy nguyên liệu thành công", response.Message);
            Assert.Equal("Test Ingredient", response.Data.Name);
            Assert.Equal(50.0m, response.Data.Price);
            Assert.Single(response.Data.Batches);
            Assert.Single(response.Data.Prices);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetIngredientById_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            int id = 999; // Non-existent ID

            this.mockIngredientService
                .Setup(s => s.GetIngredientByIdAsync(id))
                .ThrowsAsync(new NotFoundException($"Không tìm thấy nguyên liệu với ID {id}"));

            // Act
            var result = await adminIngredientController.GetIngredientById(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Error", response.Status);
            Assert.Equal($"Không tìm thấy nguyên liệu với ID {id}", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetIngredientById_WhenServiceThrowsException_ReturnsBadRequest()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            int id = 1;

            this.mockIngredientService
                .Setup(s => s.GetIngredientByIdAsync(id))
                .ThrowsAsync(new Exception("Service error"));

            // Act
            var result = await adminIngredientController.GetIngredientById(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi", response.Status);
            Assert.Equal("Không thể lấy thông tin nguyên liệu", response.Message);
            this.mockRepository.VerifyAll();
        }

        #endregion

        #region CreateIngredient Tests

        [Fact]
        public async Task CreateIngredient_WithValidRequest_ReturnsCreatedResult()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            var request = new CreateIngredientRequest
            {
                Name = "New Ingredient",
                Description = "New Description",
                ImageURL = "new.jpg",
                MinStockLevel = 10,
                IngredientTypeID = 1,
                Unit = "g",
                MeasurementValue = 100,
                Price = 50.0m
            };

            var createdIngredient = new Ingredient
            {
                IngredientId = 1,
                Name = request.Name,
                Description = request.Description,
                ImageURL = request.ImageURL,
                MinStockLevel = request.MinStockLevel,
                Unit = request.Unit,
                MeasurementValue = request.MeasurementValue,
                IngredientTypeId = request.IngredientTypeID,
                IngredientType = new IngredientType { Name = "Test Type" },
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            };

            this.mockIngredientService
                .Setup(s => s.CreateIngredientAsync(
                    It.Is<Ingredient>(i => i.Name == request.Name), request.Price))
                .ReturnsAsync(createdIngredient);

            // Act
            var result = await adminIngredientController.CreateIngredient(request);

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(AdminIngredientController.GetIngredientById), createdResult.ActionName);
            Assert.Equal(1, createdResult.RouteValues["id"]);

            var response = Assert.IsType<ApiResponse<IngredientDto>>(createdResult.Value);
            Assert.True(response.Success);
            Assert.Equal("Đã tạo nguyên liệu thành công.", response.Message);
            Assert.Equal("New Ingredient", response.Data.Name);
            Assert.Equal(50.0m, response.Data.Price);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CreateIngredient_WithInvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            var request = new CreateIngredientRequest
            {
                Name = "", // Invalid: empty name
                Description = "New Description",
                ImageURL = "new.jpg",
                MinStockLevel = 10,
                IngredientTypeID = 1,
                Unit = "g",
                MeasurementValue = 100,
                Price = 50.0m
            };

            // Act
            var result = await adminIngredientController.CreateIngredient(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", response.Status);
            Assert.Equal("Tên nguyên liệu không được để trống", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CreateIngredient_WithNegativePrice_ReturnsBadRequest()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            var request = new CreateIngredientRequest
            {
                Name = "New Ingredient",
                Description = "New Description",
                ImageURL = "new.jpg",
                MinStockLevel = 10,
                IngredientTypeID = 1,
                Unit = "g",
                MeasurementValue = 100,
                Price = -10.0m // Invalid: negative price
            };

            // Act
            var result = await adminIngredientController.CreateIngredient(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", response.Status);
            Assert.Equal("Giá không thể là số âm", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CreateIngredient_WithNegativeMinStockLevel_ReturnsBadRequest()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            var request = new CreateIngredientRequest
            {
                Name = "New Ingredient",
                Description = "New Description",
                ImageURL = "new.jpg",
                MinStockLevel = -5, // Invalid: negative min stock level
                IngredientTypeID = 1,
                Unit = "g",
                MeasurementValue = 100,
                Price = 50.0m
            };

            // Act
            var result = await adminIngredientController.CreateIngredient(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", response.Status);
            Assert.Equal("Mức tồn kho tối thiểu không thể là số âm", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CreateIngredient_WithEmptyUnit_ReturnsBadRequest()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            var request = new CreateIngredientRequest
            {
                Name = "New Ingredient",
                Description = "New Description",
                ImageURL = "new.jpg",
                MinStockLevel = 10,
                IngredientTypeID = 1,
                Unit = "", // Invalid: empty unit
                MeasurementValue = 100,
                Price = 50.0m
            };

            // Act
            var result = await adminIngredientController.CreateIngredient(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", response.Status);
            Assert.Equal("Đơn vị không được để trống", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CreateIngredient_WithZeroMeasurementValue_ReturnsBadRequest()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            var request = new CreateIngredientRequest
            {
                Name = "New Ingredient",
                Description = "New Description",
                ImageURL = "new.jpg",
                MinStockLevel = 10,
                IngredientTypeID = 1,
                Unit = "g",
                MeasurementValue = 0, // Invalid: zero measurement value
                Price = 50.0m
            };

            // Act
            var result = await adminIngredientController.CreateIngredient(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", response.Status);
            Assert.Equal("Giá trị đo lường phải lớn hơn 0", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CreateIngredient_WhenServiceThrowsValidationException_ReturnsBadRequest()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            var request = new CreateIngredientRequest
            {
                Name = "New Ingredient",
                Description = "New Description",
                ImageURL = "new.jpg",
                MinStockLevel = 10,
                IngredientTypeID = 1,
                Unit = "g",
                MeasurementValue = 100,
                Price = 50.0m
            };

            this.mockIngredientService
                .Setup(s => s.CreateIngredientAsync(
                    It.Is<Ingredient>(i => i.Name == request.Name), request.Price))
                .ThrowsAsync(new ValidationException("Ingredient with this name already exists"));

            // Act
            var result = await adminIngredientController.CreateIngredient(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", response.Status);
            Assert.Equal("Ingredient with this name already exists", response.Message);
            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task CreateIngredient_WhenServiceThrowsException_ReturnsBadRequest()
        {
            // Arrange
            var adminIngredientController = this.CreateAdminIngredientController();
            var request = new CreateIngredientRequest
            {
                Name = "New Ingredient",
                Description = "New Description",
                ImageURL = "new.jpg",
                MinStockLevel = 10,
                IngredientTypeID = 1,
                Unit = "g",
                MeasurementValue = 100,
                Price = 50.0m
            };

            this.mockIngredientService
                .Setup(s => s.CreateIngredientAsync(
                    It.Is<Ingredient>(i => i.Name == request.Name), request.Price))
                .ThrowsAsync(new Exception("Service error"));

            // Act
            var result = await adminIngredientController.CreateIngredient(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var response = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi", response.Status);
            Assert.Equal("Không thể tạo nguyên liệu", response.Message);
            this.mockRepository.VerifyAll();
        }

        #endregion
    }
}