using Capstone.HPTY.API.Controllers.Admin;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Hotpot;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
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
    public class AdminHotpotControllerTests
    {
        private MockRepository mockRepository;
        private Mock<IHotpotService> mockHotpotService;
        private Mock<ILogger<AdminHotpotController>> mockLogger;

        public AdminHotpotControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockHotpotService = this.mockRepository.Create<IHotpotService>();

            // Create logger with loose behavior
            this.mockLogger = new Mock<ILogger<AdminHotpotController>>(MockBehavior.Loose);
        }

        private AdminHotpotController CreateAdminHotpotController()
        {
            return new AdminHotpotController(
                this.mockHotpotService.Object,
                this.mockLogger.Object);
        }

        [Fact]
        public async Task GetHotpots_ReturnsPagedResult_WhenParametersAreValid()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            string searchTerm = "test";
            bool? isAvailable = true;
            string material = "Ceramic";
            string size = "Medium";
            decimal? minPrice = 10;
            decimal? maxPrice = 100;
            int? minQuantity = 5;
            int pageNumber = 1;
            int pageSize = 10;
            string sortBy = "Name";
            bool ascending = true;

            var hotpots = new List<Hotpot>
            {
                new Hotpot
                {
                    HotpotId = 1,
                    Name = "Test Hotpot",
                    Material = "Ceramic",
                    Size = "Medium",
                    Description = "A test hotpot",
                    ImageURLs = new[] { "image1.jpg", "image2.jpg" },
                    Price = 50,
                    BasePrice = 30,
                    Quantity = 10,
                    LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                    CreatedAt = DateTime.UtcNow.AddDays(-60),
                    UpdatedAt = DateTime.UtcNow.AddDays(-15)
                }
            };

            var pagedResult = new PagedResult<Hotpot>
            {
                Items = hotpots,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockHotpotService.Setup(s => s.GetHotpotsAsync(
                searchTerm, isAvailable, material, size,
                minPrice, maxPrice, minQuantity,
                pageNumber, pageSize, sortBy, ascending))
                .ReturnsAsync(pagedResult);

            mockHotpotService.Setup(s => s.CountDamageDevice())
                .ReturnsAsync(5);

            // Act
            var result = await adminHotpotController.GetHotpots(
                searchTerm,
                isAvailable,
                material,
                size,
                minPrice,
                maxPrice,
                minQuantity,
                pageNumber,
                pageSize,
                sortBy,
                ascending);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var hotpotPagedResult = Assert.IsType<HotpotPagedResult>(okResult.Value);
            Assert.Equal(1, hotpotPagedResult.TotalCount);
            Assert.Equal(5, hotpotPagedResult.DamageDeviceCount);

            var items = hotpotPagedResult.Items.ToList();
            Assert.Single(items);
            Assert.Equal(1, items[0].HotpotId);
            Assert.Equal("Test Hotpot", items[0].Name);
            Assert.Equal("Ceramic", items[0].Material);
            Assert.Equal(50, items[0].Price);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task GetHotpots_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            string searchTerm = null;
            bool? isAvailable = null;
            string material = null;
            string size = null;
            decimal? minPrice = null;
            decimal? maxPrice = null;
            int? minQuantity = null;
            int pageNumber = 1;
            int pageSize = 10;
            string sortBy = "Name";
            bool ascending = true;

            mockHotpotService.Setup(s => s.GetHotpotsAsync(
                searchTerm, isAvailable, material, size,
                minPrice, maxPrice, minQuantity,
                pageNumber, pageSize, sortBy, ascending))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminHotpotController.GetHotpots(
                searchTerm,
                isAvailable,
                material,
                size,
                minPrice,
                maxPrice,
                minQuantity,
                pageNumber,
                pageSize,
                sortBy,
                ascending);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Access the property using reflection
            var responseObj = statusCodeResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task GetById_ReturnsHotpot_WhenHotpotExists()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;

            var hotpot = new Hotpot
            {
                HotpotId = id,
                Name = "Test Hotpot",
                Material = "Ceramic",
                Size = "Medium",
                Description = "A test hotpot",
                ImageURLs = new[] { "image1.jpg", "image2.jpg" },
                Price = 50,
                BasePrice = 30,
                Quantity = 10,
                LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-15),
                InventoryUnits = new List<HotPotInventory>
                {
                    new HotPotInventory
                    {
                        HotPotInventoryId = 1,
                        SeriesNumber = "HP-123456",
                        Status = HotpotStatus.Available,
                        IsDelete = false
                    },
                    new HotPotInventory
                    {
                        HotPotInventoryId = 2,
                        SeriesNumber = "HP-789012",
                        Status = HotpotStatus.Rented,
                        IsDelete = false
                    }
                }
            };

            mockHotpotService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(hotpot);

            // Act
            var result = await adminHotpotController.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<HotpotDetailDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Hotpot retrieved successfully", apiResponse.Message);
            Assert.Equal(id, apiResponse.Data.HotpotId);
            Assert.Equal("Test Hotpot", apiResponse.Data.Name);
            Assert.Equal(2, apiResponse.Data.InventoryItems.Count);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenHotpotDoesNotExist()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 999;

            mockHotpotService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync((Hotpot)null);

            // Act
            var result = await adminHotpotController.GetById(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal($"Hotpot with ID {id} not found", apiResponse.Message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task GetById_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;

            mockHotpotService.Setup(s => s.GetByIdAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminHotpotController.GetById(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Failed to retrieve hotpot", apiResponse.Message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task GetInventoryMaintenanceLogs_ReturnsInventoryItem_WhenInventoryExists()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int inventoryId = 1;

            var inventoryItem = new HotPotInventory
            {
                HotPotInventoryId = inventoryId,
                SeriesNumber = "HP-123456",
                Status = HotpotStatus.Available,
                IsDelete = false,
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-15),
                ConditionLogs = new List<DamageDevice>
                {
                    new DamageDevice
                    {
                        DamageDeviceId = 1,
                        Name = "Broken Handle",
                        Description = "Handle is broken",
                        Status = MaintenanceStatus.Completed,
                        LoggedDate = DateTime.UtcNow.AddDays(-30),
                        IsDelete = false,
                        CreatedAt = DateTime.UtcNow.AddDays(-30),
                        UpdatedAt = DateTime.UtcNow.AddDays(-15)
                    }
                }
            };

            mockHotpotService.Setup(s => s.GetByInvetoryIdAsync(inventoryId))
                .ReturnsAsync(inventoryItem);

            // Act
            var result = await adminHotpotController.GetInventoryMaintenanceLogs(inventoryId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<InventoryItemDetailDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Maintenance logs retrieved successfully", apiResponse.Message);
            Assert.Equal(inventoryId, apiResponse.Data.HotPotInventoryId);
            Assert.Equal("HP-123456", apiResponse.Data.SeriesNumber);
            Assert.Single(apiResponse.Data.ConditionLogs);
            Assert.Equal(1, apiResponse.Data.ConditionLogs[0].DamageDeviceId);
            Assert.Equal("Broken Handle", apiResponse.Data.ConditionLogs[0].Name);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task GetInventoryMaintenanceLogs_ReturnsNotFound_WhenInventoryDoesNotExist()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int inventoryId = 999;

            mockHotpotService.Setup(s => s.GetByInvetoryIdAsync(inventoryId))
                .ReturnsAsync((HotPotInventory)null);

            // Act
            var result = await adminHotpotController.GetInventoryMaintenanceLogs(inventoryId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal($"Inventory item with ID {inventoryId} not found", apiResponse.Message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task GetInventoryMaintenanceLogs_ReturnsNotFound_WhenInventoryIsDeleted()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int inventoryId = 1;

            var inventoryItem = new HotPotInventory
            {
                HotPotInventoryId = inventoryId,
                SeriesNumber = "HP-123456",
                Status = HotpotStatus.Available,
                IsDelete = true // Deleted inventory
            };

            mockHotpotService.Setup(s => s.GetByInvetoryIdAsync(inventoryId))
                .ReturnsAsync(inventoryItem);

            // Act
            var result = await adminHotpotController.GetInventoryMaintenanceLogs(inventoryId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal($"Inventory item with ID {inventoryId} not found", apiResponse.Message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task GetInventoryMaintenanceLogs_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int inventoryId = 1;

            mockHotpotService.Setup(s => s.GetByInvetoryIdAsync(inventoryId))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminHotpotController.GetInventoryMaintenanceLogs(inventoryId);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Failed to retrieve maintenance logs", apiResponse.Message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task Create_ReturnsCreatedHotpot_WhenRequestIsValid()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            var request = new CreateHotpotRequest
            {
                Name = "New Hotpot",
                Material = "Stainless Steel",
                Size = "Large",
                Description = "A new hotpot for testing",
                ImageURLs = new[] { "image1.jpg", "image2.jpg" },
                Price = 75,
                BasePrice = 50,
                Status = true,
                SeriesNumbers = new[] { "HP-123456", "HP-789012" }
            };

            var createdHotpot = new Hotpot
            {
                HotpotId = 1,
                Name = request.Name,
                Material = request.Material,
                Size = request.Size,
                Description = request.Description,
                ImageURLs = request.ImageURLs,
                Price = request.Price,
                BasePrice = request.BasePrice,
                Quantity = 2, // Based on the number of series numbers
                LastMaintainDate = DateTime.UtcNow.AddHours(7),
                CreatedAt = DateTime.UtcNow
            };

            mockHotpotService.Setup(s => s.CreateAsync(
                It.Is<Hotpot>(h =>
                    h.Name == request.Name &&
                    h.Material == request.Material &&
                    h.Size == request.Size &&
                    h.Price == request.Price),
                It.Is<string[]>(sn => sn.SequenceEqual(request.SeriesNumbers))))
                .ReturnsAsync(createdHotpot);

            // Act
            var result = await adminHotpotController.Create(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(AdminHotpotController.GetById), createdAtActionResult.ActionName);
            Assert.Equal(1, createdAtActionResult.RouteValues["id"]);

            var hotpotDto = Assert.IsType<HotpotDto>(createdAtActionResult.Value);
            Assert.Equal(1, hotpotDto.HotpotId);
            Assert.Equal(request.Name, hotpotDto.Name);
            Assert.Equal(request.Material, hotpotDto.Material);
            Assert.Equal(request.Size, hotpotDto.Size);
            Assert.Equal(request.Price, hotpotDto.Price);
            Assert.Equal(2, hotpotDto.Quantity);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            var request = new CreateHotpotRequest
            {
                Name = "New Hotpot",
                Material = "Stainless Steel",
                Size = "Large",
                Description = "A new hotpot for testing",
                ImageURLs = new[] { "image1.jpg", "image2.jpg" },
                Price = 75,
                BasePrice = 50,
                Status = true,
                SeriesNumbers = new[] { "HP-123456", "HP-789012" }
            };

            mockHotpotService.Setup(s => s.CreateAsync(
                It.IsAny<Hotpot>(),
                It.IsAny<string[]>()))
                .ThrowsAsync(new ValidationException("Series number already exists"));

            // Act
            var result = await adminHotpotController.Create(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);

            // Access the property using reflection
            var responseObj = badRequestResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal("Series number already exists", message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task Create_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            var request = new CreateHotpotRequest
            {
                Name = "New Hotpot",
                Material = "Stainless Steel",
                Size = "Large",
                Description = "A new hotpot for testing",
                ImageURLs = new[] { "image1.jpg", "image2.jpg" },
                Price = 75,
                BasePrice = 50,
                Status = true,
                SeriesNumbers = new[] { "HP-123456", "HP-789012" }
            };

            mockHotpotService.Setup(s => s.CreateAsync(
                It.IsAny<Hotpot>(),
                It.IsAny<string[]>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminHotpotController.Create(request);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Access the property using reflection
            var responseObj = statusCodeResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task Update_ReturnsNoContent_WhenUpdateSucceeds()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;
            var request = new UpdateHotpotRequest
            {
                Name = "Updated Hotpot",
                Material = "Ceramic",
                Size = "Medium",
                Description = "Updated description",
                ImageURLs = new[] { "updated1.jpg", "updated2.jpg" },
                Price = 85,
                BasePrice = 60,
                SeriesNumbers = new[] { "HP-123456", "HP-789012", "HP-345678" }
            };

            var existingHotpot = new Hotpot
            {
                HotpotId = id,
                Name = "Original Hotpot",
                Material = "Stainless Steel",
                Size = "Large",
                Description = "Original description",
                ImageURLs = new[] { "original1.jpg", "original2.jpg" },
                Price = 75,
                BasePrice = 50,
                Quantity = 2,
                LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = null
            };

            mockHotpotService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingHotpot);

            mockHotpotService.Setup(s => s.UpdateAsync(
                id,
                It.Is<Hotpot>(h =>
                    h.Name == request.Name &&
                    h.Material == request.Material &&
                    h.Size == request.Size &&
                    h.Price == request.Price),
                It.Is<string[]>(sn => sn.SequenceEqual(request.SeriesNumbers))))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminHotpotController.Update(id, request);

            // Assert
            Assert.IsType<NoContentResult>(result);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenHotpotDoesNotExist()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 999;
            var request = new UpdateHotpotRequest
            {
                Name = "Updated Hotpot",
                Price = 85,
                BasePrice = 60
            };

            mockHotpotService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync((Hotpot)null);

            // Act
            var result = await adminHotpotController.Update(id, request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);

            // Access the property using reflection
            var responseObj = notFoundResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal($"Hotpot with ID {id} not found", message);

            // Verify service calls
            mockHotpotService.Verify();
        }
        [Fact]
        public async Task Update_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;
            var request = new UpdateHotpotRequest
            {
                Name = "Updated Hotpot",
                Price = 85,
                BasePrice = 60
            };

            var existingHotpot = new Hotpot
            {
                HotpotId = id,
                Name = "Original Hotpot",
                Material = "Stainless Steel",
                Size = "Large",
                Price = 75,
                BasePrice = 50
            };

            mockHotpotService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingHotpot);

            mockHotpotService.Setup(s => s.UpdateAsync(
                id,
                It.IsAny<Hotpot>(),
                It.IsAny<string[]>()))
                .ThrowsAsync(new ValidationException("Invalid series number format"));

            // Act
            var result = await adminHotpotController.Update(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

            // Access the property using reflection
            var responseObj = badRequestResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal("Invalid series number format", message);

            // Verify service calls
            mockHotpotService.Verify();
        }
        [Fact]
        public async Task Update_ReturnsNotFound_WhenNotFoundExceptionIsThrown()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;
            var request = new UpdateHotpotRequest
            {
                Name = "Updated Hotpot",
                Price = 85,
                BasePrice = 60
            };

            var existingHotpot = new Hotpot
            {
                HotpotId = id,
                Name = "Original Hotpot",
                Material = "Stainless Steel",
                Size = "Large",
                Price = 75,
                BasePrice = 50
            };

            mockHotpotService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingHotpot);

            mockHotpotService.Setup(s => s.UpdateAsync(
                id,
                It.IsAny<Hotpot>(),
                It.IsAny<string[]>()))
                .ThrowsAsync(new NotFoundException($"Hotpot with ID {id} not found"));

            // Act
            var result = await adminHotpotController.Update(id, request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);

            // Access the property using reflection
            var responseObj = notFoundResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal($"Hotpot with ID {id} not found", message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task Update_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;
            var request = new UpdateHotpotRequest
            {
                Name = "Updated Hotpot",
                Price = 85,
                BasePrice = 60
            };

            var existingHotpot = new Hotpot
            {
                HotpotId = id,
                Name = "Original Hotpot",
                Material = "Stainless Steel",
                Size = "Large",
                Price = 75,
                BasePrice = 50
            };

            mockHotpotService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingHotpot);

            mockHotpotService.Setup(s => s.UpdateAsync(
                id,
                It.IsAny<Hotpot>(),
                It.IsAny<string[]>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminHotpotController.Update(id, request);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Access the property using reflection
            var responseObj = statusCodeResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockHotpotService.Verify();
        }


        [Fact]
        public async Task Delete_ReturnsNoContent_WhenDeleteSucceeds()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;

            mockHotpotService.Setup(s => s.DeleteAsync(id))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminHotpotController.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenHotpotDoesNotExist()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 999;

            mockHotpotService.Setup(s => s.DeleteAsync(id))
                .ThrowsAsync(new NotFoundException($"Hotpot with ID {id} not found"));

            // Act
            var result = await adminHotpotController.Delete(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);

            // Access the property using reflection
            var responseObj = notFoundResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal($"Hotpot with ID {id} not found", message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task Delete_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;

            mockHotpotService.Setup(s => s.DeleteAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminHotpotController.Delete(id);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Access the property using reflection
            var responseObj = statusCodeResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task CalculateDeposit_ReturnsDepositAmount_WhenParametersAreValid()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;
            int quantity = 3;
            decimal expectedDeposit = 150.00m;

            mockHotpotService.Setup(s => s.CalculateDepositAsync(id, quantity))
                .ReturnsAsync(expectedDeposit);

            // Act
            var result = await adminHotpotController.CalculateDeposit(id, quantity);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var depositDto = Assert.IsType<DepositDto>(okResult.Value);
            Assert.Equal(id, depositDto.HotpotId);
            Assert.Equal(quantity, depositDto.Quantity);
            Assert.Equal(expectedDeposit, depositDto.DepositAmount);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task CalculateDeposit_ReturnsBadRequest_WhenQuantityIsInvalid()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;
            int quantity = 0; // Invalid quantity

            // Act
            var result = await adminHotpotController.CalculateDeposit(id, quantity);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);

            // Instead of using dynamic, access the property using reflection or convert to dictionary
            var responseObj = badRequestResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal("Quantity must be greater than 0", message);

            // No service calls should be made
            mockHotpotService.Verify(s => s.CalculateDepositAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task CalculateDeposit_ReturnsNotFound_WhenHotpotDoesNotExist()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 999;
            int quantity = 3;

            mockHotpotService.Setup(s => s.CalculateDepositAsync(id, quantity))
                .ThrowsAsync(new NotFoundException($"Hotpot with ID {id} not found"));

            // Act
            var result = await adminHotpotController.CalculateDeposit(id, quantity);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);

            // Instead of using dynamic, access the property using reflection or convert to dictionary
            var responseObj = notFoundResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal($"Hotpot with ID {id} not found", message);

            // Verify service calls
            mockHotpotService.Verify();
        }

        [Fact]
        public async Task CalculateDeposit_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminHotpotController = this.CreateAdminHotpotController();
            int id = 1;
            int quantity = 3;

            mockHotpotService.Setup(s => s.CalculateDepositAsync(id, quantity))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminHotpotController.CalculateDeposit(id, quantity);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Instead of using dynamic, access the property using reflection or convert to dictionary
            var responseObj = statusCodeResult.Value;
            var messageProperty = responseObj.GetType().GetProperty("message");
            var message = messageProperty.GetValue(responseObj).ToString();
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockHotpotService.Verify();
        }
    }
}