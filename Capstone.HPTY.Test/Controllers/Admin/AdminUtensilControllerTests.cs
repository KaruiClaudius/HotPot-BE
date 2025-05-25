using Capstone.HPTY.API.Controllers.Admin;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Utensil;
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
    public class AdminUtensilControllerTests
    {
        private readonly MockRepository mockRepository;
        private readonly Mock<IUtensilService> mockUtensilService;
        private readonly Mock<ILogger<AdminUtensilController>> mockLogger;

        public AdminUtensilControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockUtensilService = this.mockRepository.Create<IUtensilService>();

            // Create logger with loose behavior to avoid having to set up every log call
            this.mockLogger = new Mock<ILogger<AdminUtensilController>>(MockBehavior.Loose);
        }

        private AdminUtensilController CreateAdminUtensilController()
        {
            return new AdminUtensilController(
                this.mockUtensilService.Object,
                this.mockLogger.Object);
        }

        #region GetUtensils Tests

        [Fact]
        public async Task GetUtensils_ReturnsPagedResult_WhenParametersAreValid()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            string searchTerm = "pot";
            int? typeId = 1;
            bool? isAvailable = true;
            int pageNumber = 1;
            int pageSize = 10;
            string sortBy = "Name";
            bool ascending = true;

            var utensilType = new UtensilType { UtensilTypeId = 1, Name = "Cooking" };
            var utensils = new List<Utensil>
            {
                new Utensil
                {
                    UtensilId = 1,
                    Name = "Hot Pot",
                    Material = "Stainless Steel",
                    Description = "A large pot for cooking hot pot",
                    ImageURL = "hotpot.jpg",
                    Price = 50.00m,
                    Status = true,
                    Quantity = 10,
                    UtensilTypeId = 1,
                    UtensilType = utensilType,
                    LastMaintainDate = DateTime.UtcNow.AddHours(7).AddHours(7).AddDays(-30),
                    CreatedAt = DateTime.UtcNow.AddDays(-60),
                    UpdatedAt = DateTime.UtcNow.AddDays(-15)
                }
            };

            var pagedResult = new PagedResult<Utensil>
            {
                Items = utensils,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockUtensilService.Setup(s => s.GetUtensilsAsync(
                searchTerm, typeId, isAvailable, pageNumber, pageSize, sortBy, ascending))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminUtensilController.GetUtensils(
                searchTerm, typeId, isAvailable, pageNumber, pageSize, sortBy, ascending);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<UtensilDto>>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Lấy danh sách dụng cụ thành công", apiResponse.Message);

            var returnedPagedResult = apiResponse.Data;
            Assert.Equal(1, returnedPagedResult.TotalCount);
            Assert.Equal(pageNumber, returnedPagedResult.PageNumber);
            Assert.Equal(pageSize, returnedPagedResult.PageSize);

            var items = returnedPagedResult.Items.ToList();
            Assert.Single(items);
            Assert.Equal(1, items[0].UtensilId);
            Assert.Equal("Hot Pot", items[0].Name);
            Assert.Equal("Cooking", items[0].UtensilTypeName);
            Assert.True(items[0].IsAvailable);

            // Verify service calls
            mockUtensilService.Verify();
        }

        [Fact]
        public async Task GetUtensils_ReturnsBadRequest_WhenPaginationParametersAreInvalid()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int pageNumber = 0; // Invalid
            int pageSize = 0;   // Invalid

            // Act
            var result = await adminUtensilController.GetUtensils(
                null, null, null, pageNumber, pageSize, "Name", true);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("Số trang và size trang phải lớn hơn 0", apiErrorResponse.Message);

            // No service calls should be made
            mockUtensilService.Verify(s => s.GetUtensilsAsync(
                It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<bool?>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>()),
                Times.Never);
        }

        [Fact]
        public async Task GetUtensils_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int pageNumber = 1;
            int pageSize = 10;

            mockUtensilService.Setup(s => s.GetUtensilsAsync(
                null, null, null, pageNumber, pageSize, "Name", true))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminUtensilController.GetUtensils(
                null, null, null, pageNumber, pageSize, "Name", true);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("Danh sách gặp trục trặc", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify();
        }

        #endregion

        #region GetUtensilById Tests

        [Fact]
        public async Task GetUtensilById_ReturnsUtensil_WhenUtensilExists()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;

            var utensilType = new UtensilType { UtensilTypeId = 1, Name = "Cooking" };
            var utensil = new Utensil
            {
                UtensilId = id,
                Name = "Hot Pot",
                Material = "Stainless Steel",
                Description = "A large pot for cooking hot pot",
                ImageURL = "hotpot.jpg",
                Price = 50.00m,
                Status = true,
                Quantity = 10,
                UtensilTypeId = 1,
                UtensilType = utensilType,
                LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-15)
            };

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ReturnsAsync(utensil);

            // Act
            var result = await adminUtensilController.GetUtensilById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UtensilDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Lấy được dụng cụ thành công", apiResponse.Message);

            var utensilDto = apiResponse.Data;
            Assert.Equal(id, utensilDto.UtensilId);
            Assert.Equal("Hot Pot", utensilDto.Name);
            Assert.Equal("Cooking", utensilDto.UtensilTypeName);
            Assert.True(utensilDto.IsAvailable);

            // Verify service calls
            mockUtensilService.Verify();
        }

        [Fact]
        public async Task GetUtensilById_ReturnsNotFound_WhenUtensilDoesNotExist()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 999;

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ThrowsAsync(new NotFoundException($"Utensil with ID {id} not found"));

            // Act
            var result = await adminUtensilController.GetUtensilById(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal($"Utensil with ID {id} not found", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify();
        }

        [Fact]
        public async Task GetUtensilById_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminUtensilController.GetUtensilById(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("Không thể lấy dụng cụ", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify();
        }

        #endregion

        #region CreateUtensil Tests

        [Fact]
        public async Task CreateUtensil_ReturnsCreatedUtensil_WhenRequestIsValid()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            var request = new CreateUtensilRequest
            {
                Name = "New Hot Pot",
                Material = "Ceramic",
                Description = "A new ceramic hot pot",
                ImageURL = "newhotpot.jpg",
                Price = 75.00m,
                Status = true,
                Quantity = 5,
                UtensilTypeID = 1
            };

            var utensilType = new UtensilType { UtensilTypeId = 1, Name = "Cooking" };
            var createdUtensil = new Utensil
            {
                UtensilId = 2,
                Name = request.Name,
                Material = request.Material,
                Description = request.Description,
                ImageURL = request.ImageURL,
                Price = request.Price,
                Status = request.Status,
                Quantity = request.Quantity,
                UtensilTypeId = request.UtensilTypeID,
                UtensilType = utensilType,
                LastMaintainDate = DateTime.UtcNow.AddHours(7),
                CreatedAt = DateTime.UtcNow.AddHours(7),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            mockUtensilService.Setup(s => s.CreateUtensilAsync(It.IsAny<Utensil>()))
                .ReturnsAsync(createdUtensil);

            // Act
            var result = await adminUtensilController.CreateUtensil(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(AdminUtensilController.GetUtensilById), createdAtActionResult.ActionName);
            Assert.Equal(2, createdAtActionResult.RouteValues["id"]);

            var apiResponse = Assert.IsType<ApiResponse<UtensilDto>>(createdAtActionResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Tạo dụng cụ thành công", apiResponse.Message);

            var utensilDto = apiResponse.Data;
            Assert.Equal(2, utensilDto.UtensilId);
            Assert.Equal("New Hot Pot", utensilDto.Name);
            Assert.Equal("Cooking", utensilDto.UtensilTypeName);
            Assert.True(utensilDto.IsAvailable);

            // Verify service calls
            mockUtensilService.Verify();
        }

        [Fact]
        public async Task CreateUtensil_CreatesNewUtensilType_WhenTypeNameIsProvided()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            var request = new CreateUtensilRequest
            {
                Name = "New Hot Pot",
                Material = "Ceramic",
                Description = "A new ceramic hot pot",
                ImageURL = "newhotpot.jpg",
                Price = 75.00m,
                Status = true,
                Quantity = 5,
                UtensilTypeID = 0, // Invalid ID, should create new type
                UtensilTypeName = "New Type"
            };

            var newUtensilType = new UtensilType { UtensilTypeId = 3, Name = "New Type" };
            var createdUtensil = new Utensil
            {
                UtensilId = 2,
                Name = request.Name,
                Material = request.Material,
                Description = request.Description,
                ImageURL = request.ImageURL,
                Price = request.Price,
                Status = request.Status,
                Quantity = request.Quantity,
                UtensilTypeId = 3, // New type ID
                UtensilType = newUtensilType,
                LastMaintainDate = DateTime.UtcNow.AddHours(7),
                CreatedAt = DateTime.UtcNow.AddHours(7),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            mockUtensilService.Setup(s => s.CreateUtensilTypeAsync("New Type"))
                .ReturnsAsync(newUtensilType);

            mockUtensilService.Setup(s => s.CreateUtensilAsync(It.Is<Utensil>(u =>
                u.Name == request.Name &&
                u.UtensilTypeId == 3)))
                .ReturnsAsync(createdUtensil);

            // Act
            var result = await adminUtensilController.CreateUtensil(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UtensilDto>>(createdAtActionResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Tạo dụng cụ thành công", apiResponse.Message);

            var utensilDto = apiResponse.Data;
            Assert.Equal(2, utensilDto.UtensilId);
            Assert.Equal("New Hot Pot", utensilDto.Name);
            Assert.Equal("New Type", utensilDto.UtensilTypeName);
            Assert.Equal(3, utensilDto.UtensilTypeId);

            // Verify service calls
            mockUtensilService.Verify(s => s.CreateUtensilTypeAsync("New Type"), Times.Once);
            mockUtensilService.Verify(s => s.CreateUtensilAsync(It.IsAny<Utensil>()), Times.Once);
        }

        [Fact]
        public async Task CreateUtensil_UsesExistingType_WhenTypeCreationFails()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            var request = new CreateUtensilRequest
            {
                Name = "New Hot Pot",
                Material = "Ceramic",
                Description = "A new ceramic hot pot",
                ImageURL = "newhotpot.jpg",
                Price = 75.00m,
                Status = true,
                Quantity = 5,
                UtensilTypeID = 0, // Invalid ID, should try to create new type
                UtensilTypeName = "Existing Type"
            };

            var existingTypes = new List<UtensilType>
            {
                new UtensilType { UtensilTypeId = 1, Name = "Cooking" },
                new UtensilType { UtensilTypeId = 2, Name = "Existing Type" }
            };

            var createdUtensil = new Utensil
            {
                UtensilId = 2,
                Name = request.Name,
                Material = request.Material,
                Description = request.Description,
                ImageURL = request.ImageURL,
                Price = request.Price,
                Status = request.Status,
                Quantity = request.Quantity,
                UtensilTypeId = 2, // Existing type ID
                UtensilType = existingTypes[1],
                LastMaintainDate = DateTime.UtcNow.AddHours(7),
                CreatedAt = DateTime.UtcNow.AddHours(7),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            mockUtensilService.Setup(s => s.CreateUtensilTypeAsync("Existing Type"))
                .ThrowsAsync(new ValidationException("Type name already exists"));

            mockUtensilService.Setup(s => s.GetAllUtensilTypesAsync())
                .ReturnsAsync(existingTypes);

            mockUtensilService.Setup(s => s.CreateUtensilAsync(It.Is<Utensil>(u =>
                u.Name == request.Name &&
                u.UtensilTypeId == 2)))
                .ReturnsAsync(createdUtensil);

            // Act
            var result = await adminUtensilController.CreateUtensil(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UtensilDto>>(createdAtActionResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Tạo dụng cụ thành công", apiResponse.Message);

            var utensilDto = apiResponse.Data;
            Assert.Equal(2, utensilDto.UtensilId);
            Assert.Equal("New Hot Pot", utensilDto.Name);
            Assert.Equal("Existing Type", utensilDto.UtensilTypeName);
            Assert.Equal(2, utensilDto.UtensilTypeId);

            // Verify service calls
            mockUtensilService.Verify(s => s.CreateUtensilTypeAsync("Existing Type"), Times.Once);
            mockUtensilService.Verify(s => s.GetAllUtensilTypesAsync(), Times.Once);
            mockUtensilService.Verify(s => s.CreateUtensilAsync(It.IsAny<Utensil>()), Times.Once);
        }

        [Fact]
        public async Task CreateUtensil_ReturnsBadRequest_WhenValidationExceptionOccurs()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            var request = new CreateUtensilRequest
            {
                Name = "New Hot Pot",
                Material = "Ceramic",
                Description = "A new ceramic hot pot",
                ImageURL = "newhotpot.jpg",
                Price = 75.00m,
                Status = true,
                Quantity = 5,
                UtensilTypeID = 1
            };

            mockUtensilService.Setup(s => s.CreateUtensilAsync(It.IsAny<Utensil>()))
                .ThrowsAsync(new ValidationException("Dụng cụ này đã tồn tại"));

            // Act
            var result = await adminUtensilController.CreateUtensil(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Lỗi xác thực thông tin", apiErrorResponse.Status);
            Assert.Equal("Dụng cụ này đã tồn tại", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify();
        }

        [Fact]
        public async Task CreateUtensil_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            var request = new CreateUtensilRequest
            {
                Name = "New Hot Pot",
                Material = "Ceramic",
                Description = "A new ceramic hot pot",
                ImageURL = "newhotpot.jpg",
                Price = 75.00m,
                Status = true,
                Quantity = 5,
                UtensilTypeID = 1
            };

            mockUtensilService.Setup(s => s.CreateUtensilAsync(It.IsAny<Utensil>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminUtensilController.CreateUtensil(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("Tạo dụng cụ gặp trục trặc", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify();
        }

        #endregion

        #region UpdateUtensil Tests

        [Fact]
        public async Task UpdateUtensil_ReturnsUpdatedUtensil_WhenRequestIsValid()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            var request = new UpdateUtensilRequest
            {
                Name = "Updated Hot Pot",
                Material = "Stainless Steel",
                Description = "An updated hot pot",
                ImageURL = "updatedhotpot.jpg",
                Price = 60.00m,
                Status = true,
                Quantity = 15,
                UtensilTypeID = 1
            };

            var utensilType = new UtensilType { UtensilTypeId = 1, Name = "Cooking" };
            var existingUtensil = new Utensil
            {
                UtensilId = id,
                Name = "Hot Pot",
                Material = "Ceramic",
                Description = "A ceramic hot pot",
                ImageURL = "hotpot.jpg",
                Price = 50.00m,
                Status = true,
                Quantity = 10,
                UtensilTypeId = 1,
                UtensilType = utensilType,
                LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-15)
            };

            var updatedUtensil = new Utensil
            {
                UtensilId = id,
                Name = request.Name,
                Material = request.Material,
                Description = request.Description,
                ImageURL = request.ImageURL,
                Price = request.Price.Value,
                Status = request.Status.Value,
                Quantity = request.Quantity.Value,
                UtensilTypeId = request.UtensilTypeID.Value,
                UtensilType = utensilType,
                LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ReturnsAsync(existingUtensil);

            mockUtensilService.Setup(s => s.UpdateUtensilAsync(id, It.IsAny<Utensil>()))
                .Returns(Task.CompletedTask);

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ReturnsAsync(updatedUtensil);

            // Act
            var result = await adminUtensilController.UpdateUtensil(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UtensilDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Cập nhật dụng cụ thành công", apiResponse.Message);

            var utensilDto = apiResponse.Data;
            Assert.Equal(id, utensilDto.UtensilId);
            Assert.Equal("Updated Hot Pot", utensilDto.Name);
            Assert.Equal("Stainless Steel", utensilDto.Material);
            Assert.Equal(60.00m, utensilDto.Price);
            Assert.Equal(15, utensilDto.Quantity);
            Assert.Equal("Cooking", utensilDto.UtensilTypeName);

            // Verify service calls
            mockUtensilService.Verify(s => s.GetUtensilByIdAsync(id), Times.Exactly(2));
            mockUtensilService.Verify(s => s.UpdateUtensilAsync(id, It.IsAny<Utensil>()), Times.Once);
        }

        [Fact]
        public async Task UpdateUtensil_CreatesNewUtensilType_WhenTypeNameIsProvided()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            var request = new UpdateUtensilRequest
            {
                Name = "Updated Hot Pot",
                UtensilTypeID = 0, // Invalid ID, should create new type
                UtensilTypeName = "New Type"
            };

            var utensilType = new UtensilType { UtensilTypeId = 1, Name = "Cooking" };
            var existingUtensil = new Utensil
            {
                UtensilId = id,
                Name = "Hot Pot",
                Material = "Ceramic",
                Description = "A ceramic hot pot",
                ImageURL = "hotpot.jpg",
                Price = 50.00m,
                Status = true,
                Quantity = 10,
                UtensilTypeId = 1,
                UtensilType = utensilType,
                LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-15)
            };

            var newUtensilType = new UtensilType { UtensilTypeId = 3, Name = "New Type" };
            var updatedUtensil = new Utensil
            {
                UtensilId = id,
                Name = request.Name,
                Material = existingUtensil.Material,
                Description = existingUtensil.Description,
                ImageURL = existingUtensil.ImageURL,
                Price = existingUtensil.Price,
                Status = existingUtensil.Status,
                Quantity = existingUtensil.Quantity,
                UtensilTypeId = 3, // New type ID
                UtensilType = newUtensilType,
                LastMaintainDate = existingUtensil.LastMaintainDate,
                CreatedAt = existingUtensil.CreatedAt,
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ReturnsAsync(existingUtensil);

            mockUtensilService.Setup(s => s.CreateUtensilTypeAsync("New Type"))
                .ReturnsAsync(newUtensilType);

            mockUtensilService.Setup(s => s.UpdateUtensilAsync(id, It.Is<Utensil>(u =>
                u.Name == request.Name &&
                u.UtensilTypeId == 3)))
                .Returns(Task.CompletedTask);

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ReturnsAsync(updatedUtensil);

            // Act
            var result = await adminUtensilController.UpdateUtensil(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UtensilDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Cập nhật dụng cụ thành công", apiResponse.Message);

            var utensilDto = apiResponse.Data;
            Assert.Equal(id, utensilDto.UtensilId);
            Assert.Equal("Updated Hot Pot", utensilDto.Name);
            Assert.Equal("New Type", utensilDto.UtensilTypeName);
            Assert.Equal(3, utensilDto.UtensilTypeId);

            // Verify service calls
            mockUtensilService.Verify(s => s.GetUtensilByIdAsync(id), Times.Exactly(2));
            mockUtensilService.Verify(s => s.CreateUtensilTypeAsync("New Type"), Times.Once);
            mockUtensilService.Verify(s => s.UpdateUtensilAsync(id, It.IsAny<Utensil>()), Times.Once);
        }

        [Fact]
        public async Task UpdateUtensil_ReturnsNotFound_WhenUtensilDoesNotExist()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 999;
            var request = new UpdateUtensilRequest
            {
                Name = "Updated Hot Pot"
            };

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ThrowsAsync(new NotFoundException($"Utensil with ID {id} not found"));

            // Act
            var result = await adminUtensilController.UpdateUtensil(id, request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal($"Utensil with ID {id} not found", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify(s => s.GetUtensilByIdAsync(id), Times.Once);
            mockUtensilService.Verify(s => s.UpdateUtensilAsync(It.IsAny<int>(), It.IsAny<Utensil>()), Times.Never);
        }

        [Fact]
        public async Task UpdateUtensil_ReturnsBadRequest_WhenValidationExceptionOccurs()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            var request = new UpdateUtensilRequest
            {
                Name = "Updated Hot Pot"
            };

            var existingUtensil = new Utensil
            {
                UtensilId = id,
                Name = "Hot Pot",
                Material = "Ceramic",
                Description = "A ceramic hot pot",
                ImageURL = "hotpot.jpg",
                Price = 50.00m,
                Status = true,
                Quantity = 10,
                UtensilTypeId = 1,
                UtensilType = new UtensilType { UtensilTypeId = 1, Name = "Cooking" },
                LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-15)
            };

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ReturnsAsync(existingUtensil);

            mockUtensilService.Setup(s => s.UpdateUtensilAsync(id, It.IsAny<Utensil>()))
                .ThrowsAsync(new ValidationException("Name already exists"));

            // Act
            var result = await adminUtensilController.UpdateUtensil(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Lỗi xác thực thông tin", apiErrorResponse.Status);
            Assert.Equal("Name already exists", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify(s => s.GetUtensilByIdAsync(id), Times.Once);
            mockUtensilService.Verify(s => s.UpdateUtensilAsync(id, It.IsAny<Utensil>()), Times.Once);
        }

        [Fact]
        public async Task UpdateUtensil_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            var request = new UpdateUtensilRequest
            {
                Name = "Updated Hot Pot"
            };

            var existingUtensil = new Utensil
            {
                UtensilId = id,
                Name = "Hot Pot",
                Material = "Ceramic",
                Description = "A ceramic hot pot",
                ImageURL = "hotpot.jpg",
                Price = 50.00m,
                Status = true,
                Quantity = 10,
                UtensilTypeId = 1,
                UtensilType = new UtensilType { UtensilTypeId = 1, Name = "Cooking" },
                LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-15)
            };

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ReturnsAsync(existingUtensil);

            mockUtensilService.Setup(s => s.UpdateUtensilAsync(id, It.IsAny<Utensil>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminUtensilController.UpdateUtensil(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("Cập nhật dụng cụ gặp trục trặc", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify(s => s.GetUtensilByIdAsync(id), Times.Once);
            mockUtensilService.Verify(s => s.UpdateUtensilAsync(id, It.IsAny<Utensil>()), Times.Once);
        }

        #endregion

        #region DeleteUtensil Tests

        [Fact]
        public async Task DeleteUtensil_ReturnsSuccess_WhenUtensilExists()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;

            mockUtensilService.Setup(s => s.DeleteUtensilAsync(id))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminUtensilController.DeleteUtensil(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Xoá dụng cụ thành công", apiResponse.Message);
            Assert.Equal($"Dụng cụ có ID {id} đã bị xoá", apiResponse.Data);

            // Verify service calls
            mockUtensilService.Verify(s => s.DeleteUtensilAsync(id), Times.Once);
        }

        [Fact]
        public async Task DeleteUtensil_ReturnsNotFound_WhenUtensilDoesNotExist()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 999;

            mockUtensilService.Setup(s => s.DeleteUtensilAsync(id))
                .ThrowsAsync(new NotFoundException($"Utensil with ID {id} not found"));

            // Act
            var result = await adminUtensilController.DeleteUtensil(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);

            Assert.Equal("không tìm thấy dụng cụ", apiErrorResponse.Status);
            Assert.Equal($"Utensil with ID {id} not found", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify(s => s.DeleteUtensilAsync(id), Times.Once);
        }

        [Fact]
        public async Task DeleteUtensil_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;

            mockUtensilService.Setup(s => s.DeleteUtensilAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminUtensilController.DeleteUtensil(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("Xoá dụng cụ gặp sự cố", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify(s => s.DeleteUtensilAsync(id), Times.Once);
        }

        #endregion

        #region UpdateUtensilStatus Tests

        [Fact]
        public async Task UpdateUtensilStatus_ReturnsSuccess_WhenUtensilExists()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            bool status = false;

            mockUtensilService.Setup(s => s.UpdateUtensilStatusAsync(id, status))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminUtensilController.UpdateUtensilStatus(id, status);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Cập nhật trạng thái thành công", apiResponse.Message);
            Assert.Equal($"Dụng cụ với ID: {id} được đổi trạng thái thành {status}", apiResponse.Data);

            // Verify service calls
            mockUtensilService.Verify(s => s.UpdateUtensilStatusAsync(id, status), Times.Once);
        }

        [Fact]
        public async Task UpdateUtensilStatus_ReturnsNotFound_WhenUtensilDoesNotExist()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 999;
            bool status = false;

            mockUtensilService.Setup(s => s.UpdateUtensilStatusAsync(id, status))
                .ThrowsAsync(new NotFoundException($"Utensil with ID {id} not found"));

            // Act
            var result = await adminUtensilController.UpdateUtensilStatus(id, status);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal($"Utensil with ID {id} not found", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify(s => s.UpdateUtensilStatusAsync(id, status), Times.Once);
        }

        [Fact]
        public async Task UpdateUtensilStatus_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            bool status = false;

            mockUtensilService.Setup(s => s.UpdateUtensilStatusAsync(id, status))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminUtensilController.UpdateUtensilStatus(id, status);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("Cập nhật trạng thái gặp trục trặc", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify(s => s.UpdateUtensilStatusAsync(id, status), Times.Once);
        }

        #endregion

        #region UpdateUtensilQuantity Tests

        [Fact]
        public async Task UpdateUtensilQuantity_ReturnsSuccess_WhenUtensilExists()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            int quantityChange = 5;

            mockUtensilService.Setup(s => s.UpdateUtensilQuantityAsync(id, quantityChange))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminUtensilController.UpdateUtensilQuantity(id, quantityChange);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Cập nhật số lượng thành công", apiResponse.Message);
            Assert.Equal($"Dụng cụ với ID: {id} được đổi số lượng thành  {quantityChange}", apiResponse.Data);

            // Verify service calls
            mockUtensilService.Verify(s => s.UpdateUtensilQuantityAsync(id, quantityChange), Times.Once);
        }

        [Fact]
        public async Task UpdateUtensilQuantity_ReturnsNotFound_WhenUtensilDoesNotExist()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 999;
            int quantityChange = 5;

            mockUtensilService.Setup(s => s.UpdateUtensilQuantityAsync(id, quantityChange))
                .ThrowsAsync(new NotFoundException($"Utensil with ID {id} not found"));

            // Act
            var result = await adminUtensilController.UpdateUtensilQuantity(id, quantityChange);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal($"Utensil with ID {id} not found", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify(s => s.UpdateUtensilQuantityAsync(id, quantityChange), Times.Once);
        }

        [Fact]
        public async Task UpdateUtensilQuantity_ReturnsBadRequest_WhenValidationExceptionOccurs()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            int quantityChange = -15; // Trying to reduce more than available

            mockUtensilService.Setup(s => s.UpdateUtensilQuantityAsync(id, quantityChange))
                .ThrowsAsync(new ValidationException("Cannot reduce quantity below zero"));

            // Act
            var result = await adminUtensilController.UpdateUtensilQuantity(id, quantityChange);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Validation Error", apiErrorResponse.Status);
            Assert.Equal("Cannot reduce quantity below zero", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify(s => s.UpdateUtensilQuantityAsync(id, quantityChange), Times.Once);
        }

        [Fact]
        public async Task UpdateUtensilQuantity_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            int quantityChange = 5;

            mockUtensilService.Setup(s => s.UpdateUtensilQuantityAsync(id, quantityChange))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminUtensilController.UpdateUtensilQuantity(id, quantityChange);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("Cập nhật số lượng gặp trục trặc", apiErrorResponse.Message);

            // Verify service calls
            mockUtensilService.Verify(s => s.UpdateUtensilQuantityAsync(id, quantityChange), Times.Once);
        }

        #endregion

        #region Edge Cases and Additional Tests

        [Fact]
        public async Task GetUtensilById_HandlesNullUtensilType_WhenUtensilExists()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;

            var utensil = new Utensil
            {
                UtensilId = id,
                Name = "Hot Pot",
                Material = "Stainless Steel",
                Description = "A large pot for cooking hot pot",
                ImageURL = "hotpot.jpg",
                Price = 50.00m,
                Status = true,
                Quantity = 10,
                UtensilTypeId = 1,
                UtensilType = null, // Null UtensilType
                LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-15)
            };

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ReturnsAsync(utensil);

            // Act
            var result = await adminUtensilController.GetUtensilById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UtensilDto>>(okResult.Value);

            var utensilDto = apiResponse.Data;
            Assert.Equal(id, utensilDto.UtensilId);
            Assert.Equal("Hot Pot", utensilDto.Name);
            Assert.Equal("Unknown", utensilDto.UtensilTypeName); // Should default to "Unknown"

            // Verify service calls
            mockUtensilService.Verify();
        }

        [Fact]
        public async Task GetUtensils_HandlesEmptyList_WhenNoUtensilsExist()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int pageNumber = 1;
            int pageSize = 10;

            var emptyPagedResult = new PagedResult<Utensil>
            {
                Items = new List<Utensil>(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 0
            };

            mockUtensilService.Setup(s => s.GetUtensilsAsync(
                null, null, null, pageNumber, pageSize, "Name", true))
                .ReturnsAsync(emptyPagedResult);

            // Act
            var result = await adminUtensilController.GetUtensils(
                null, null, null, pageNumber, pageSize, "Name", true);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<UtensilDto>>>(okResult.Value);

            var returnedPagedResult = apiResponse.Data;
            Assert.Equal(0, returnedPagedResult.TotalCount);
            Assert.Empty(returnedPagedResult.Items);

            // Verify service calls
            mockUtensilService.Verify();
        }

        [Fact]
        public async Task CreateUtensil_HandlesNullDescription_WhenCreatingUtensil()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            var request = new CreateUtensilRequest
            {
                Name = "New Hot Pot",
                Material = "Ceramic",
                Description = null, // Null description
                ImageURL = "newhotpot.jpg",
                Price = 75.00m,
                Status = true,
                Quantity = 5,
                UtensilTypeID = 1
            };

            var utensilType = new UtensilType { UtensilTypeId = 1, Name = "Cooking" };
            var createdUtensil = new Utensil
            {
                UtensilId = 2,
                Name = request.Name,
                Material = request.Material,
                Description = null, // Null description
                ImageURL = request.ImageURL,
                Price = request.Price,
                Status = request.Status,
                Quantity = request.Quantity,
                UtensilTypeId = request.UtensilTypeID,
                UtensilType = utensilType,
                LastMaintainDate = DateTime.UtcNow.AddHours(7),
                CreatedAt = DateTime.UtcNow.AddHours(7),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            mockUtensilService.Setup(s => s.CreateUtensilAsync(It.Is<Utensil>(u =>
                u.Name == request.Name &&
                u.Description == null)))
                .ReturnsAsync(createdUtensil);

            // Act
            var result = await adminUtensilController.CreateUtensil(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UtensilDto>>(createdAtActionResult.Value);

            var utensilDto = apiResponse.Data;
            Assert.Equal(2, utensilDto.UtensilId);
            Assert.Equal("New Hot Pot", utensilDto.Name);
            Assert.Null(utensilDto.Description); // Description should be null

            // Verify service calls
            mockUtensilService.Verify();
        }

        [Fact]
        public async Task UpdateUtensil_OnlyUpdatesProvidedFields_WhenPartialUpdateIsRequested()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            var request = new UpdateUtensilRequest
            {
                Name = "Updated Hot Pot",
                // Only providing name, other fields should remain unchanged
            };

            var utensilType = new UtensilType { UtensilTypeId = 1, Name = "Cooking" };
            var existingUtensil = new Utensil
            {
                UtensilId = id,
                Name = "Hot Pot",
                Material = "Ceramic",
                Description = "A ceramic hot pot",
                ImageURL = "hotpot.jpg",
                Price = 50.00m,
                Status = true,
                Quantity = 10,
                UtensilTypeId = 1,
                UtensilType = utensilType,
                LastMaintainDate = DateTime.UtcNow.AddDays(-30),
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-15)
            };

            var updatedUtensil = new Utensil
            {
                UtensilId = id,
                Name = request.Name, // Only name should change
                Material = existingUtensil.Material,
                Description = existingUtensil.Description,
                ImageURL = existingUtensil.ImageURL,
                Price = existingUtensil.Price,
                Status = existingUtensil.Status,
                Quantity = existingUtensil.Quantity,
                UtensilTypeId = existingUtensil.UtensilTypeId,
                UtensilType = utensilType,
                LastMaintainDate = existingUtensil.LastMaintainDate,
                CreatedAt = existingUtensil.CreatedAt,
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ReturnsAsync(existingUtensil);

            // Capture the Utensil object passed to UpdateUtensilAsync to verify only name is updated
            Utensil capturedUtensil = null;
            mockUtensilService.Setup(s => s.UpdateUtensilAsync(id, It.IsAny<Utensil>()))
                .Callback<int, Utensil>((i, u) => capturedUtensil = u)
                .Returns(Task.CompletedTask);

            mockUtensilService.Setup(s => s.GetUtensilByIdAsync(id))
                .ReturnsAsync(updatedUtensil);

            // Act
            var result = await adminUtensilController.UpdateUtensil(id, request);

            // Assert
            Assert.NotNull(capturedUtensil);
            Assert.Equal("Updated Hot Pot", capturedUtensil.Name);
            Assert.Equal(existingUtensil.Material, capturedUtensil.Material);
            Assert.Equal(existingUtensil.Description, capturedUtensil.Description);
            Assert.Equal(existingUtensil.ImageURL, capturedUtensil.ImageURL);
            Assert.Equal(existingUtensil.Price, capturedUtensil.Price);
            Assert.Equal(existingUtensil.Status, capturedUtensil.Status);
            Assert.Equal(existingUtensil.Quantity, capturedUtensil.Quantity);
            Assert.Equal(existingUtensil.UtensilTypeId, capturedUtensil.UtensilTypeId);

            // Verify service calls
            mockUtensilService.Verify();
        }

        [Fact]
        public async Task UpdateUtensilQuantity_HandlesPositiveQuantityChange_WhenIncreasingQuantity()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            int quantityChange = 5; // Positive change (increase)

            mockUtensilService.Setup(s => s.UpdateUtensilQuantityAsync(id, quantityChange))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminUtensilController.UpdateUtensilQuantity(id, quantityChange);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Cập nhật số lượng thành công", apiResponse.Message);
            Assert.Equal($"Dụng cụ với ID: {id} được đổi số lượng thành  {quantityChange}", apiResponse.Data);

            // Verify service calls
            mockUtensilService.Verify(s => s.UpdateUtensilQuantityAsync(id, quantityChange), Times.Once);
        }

        [Fact]
        public async Task UpdateUtensilQuantity_HandlesNegativeQuantityChange_WhenDecreasingQuantity()
        {
            // Arrange
            var adminUtensilController = this.CreateAdminUtensilController();
            int id = 1;
            int quantityChange = -3; // Negative change (decrease)

            mockUtensilService.Setup(s => s.UpdateUtensilQuantityAsync(id, quantityChange))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminUtensilController.UpdateUtensilQuantity(id, quantityChange);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Cập nhật số lượng thành công", apiResponse.Message);
            Assert.Equal($"Dụng cụ với ID: {id} được đổi số lượng thành  {quantityChange}", apiResponse.Data);

            // Verify service calls
            mockUtensilService.Verify(s => s.UpdateUtensilQuantityAsync(id, quantityChange), Times.Once);
        }

        #endregion
    }
}