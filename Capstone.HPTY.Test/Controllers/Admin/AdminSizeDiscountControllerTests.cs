using Capstone.HPTY.API.Controllers.Admin;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.SizeDiscount;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Admin
{
    public class AdminSizeDiscountControllerTests
    {
        private MockRepository mockRepository;
        private Mock<ISizeDiscountService> mockSizeDiscountService;
        private Mock<ILogger<AdminSizeDiscountController>> mockLogger;

        public AdminSizeDiscountControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockSizeDiscountService = this.mockRepository.Create<ISizeDiscountService>();

            // Create logger with loose behavior
            this.mockLogger = new Mock<ILogger<AdminSizeDiscountController>>(MockBehavior.Loose);
        }

        private AdminSizeDiscountController CreateAdminSizeDiscountController()
        {
            return new AdminSizeDiscountController(
                this.mockSizeDiscountService.Object,
                this.mockLogger.Object);
        }

        // Helper method to get message from response
        private string GetMessageFromResponse(object response)
        {
            var messageProperty = response.GetType().GetProperty("message");
            return messageProperty?.GetValue(response)?.ToString();
        }

        [Fact]
        public async Task GetAll_ReturnsPagedResult_WhenParametersAreValid()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int? minSize = 5;
            int? maxSize = 10;
            decimal? minDiscount = 10;
            decimal? maxDiscount = 20;
            DateTime? activeDate = DateTime.UtcNow.AddHours(7);
            bool? isActive = true;
            int pageNumber = 1;
            int pageSize = 10;
            string sortBy = "MinSize";
            bool ascending = true;

            var sizeDiscounts = new List<SizeDiscount>
            {
                new SizeDiscount
                {
                    SizeDiscountId = 1,
                    MinSize = 5,
                    DiscountPercentage = 15,
                    StartDate = DateTime.UtcNow.AddHours(7).AddDays(-10),
                    EndDate = DateTime.UtcNow.AddDays(10),
                    CreatedAt = DateTime.UtcNow.AddDays(-20),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5)
                }
            };

            var pagedResult = new PagedResult<SizeDiscount>
            {
                Items = sizeDiscounts,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockSizeDiscountService.Setup(s => s.GetSizeDiscountsAsync(
                minSize, maxSize, minDiscount, maxDiscount, activeDate, isActive,
                pageNumber, pageSize, sortBy, ascending))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminSizeDiscountController.GetAll(
                minSize,
                maxSize,
                minDiscount,
                maxDiscount,
                activeDate,
                isActive,
                pageNumber,
                pageSize,
                sortBy,
                ascending);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPagedResult = Assert.IsType<PagedResult<SizeDiscountDto>>(okResult.Value);
            Assert.Equal(1, returnedPagedResult.TotalCount);
            Assert.Equal(pageNumber, returnedPagedResult.PageNumber);
            Assert.Equal(pageSize, returnedPagedResult.PageSize);

            var items = returnedPagedResult.Items.ToList();
            Assert.Single(items);
            Assert.Equal(1, items[0].Id);
            Assert.Equal(5, items[0].MinSize);
            Assert.Equal(15, items[0].DiscountPercentage);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task GetAll_NormalizesInvalidPaginationParameters()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int pageNumber = 0; // Invalid, should be normalized to 1
            int pageSize = 0;   // Invalid, should be normalized to 10
            string sortBy = "MinSize";
            bool ascending = true;

            var sizeDiscounts = new List<SizeDiscount>();
            var pagedResult = new PagedResult<SizeDiscount>
            {
                Items = sizeDiscounts,
                PageNumber = 1, // Normalized
                PageSize = 10,  // Normalized
                TotalCount = 0
            };

            mockSizeDiscountService.Setup(s => s.GetSizeDiscountsAsync(
                null, null, null, null, null, null,
                1, 10, sortBy, ascending)) // Expect normalized values
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminSizeDiscountController.GetAll(
                null, null, null, null, null, null,
                pageNumber, pageSize, sortBy, ascending);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPagedResult = Assert.IsType<PagedResult<SizeDiscountDto>>(okResult.Value);
            Assert.Equal(1, returnedPagedResult.PageNumber); // Should be normalized to 1
            Assert.Equal(10, returnedPagedResult.PageSize);  // Should be normalized to 10

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task GetAll_LimitsPageSizeToMaximum()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int pageNumber = 1;
            int pageSize = 100; // Too large, should be limited to 50
            string sortBy = "MinSize";
            bool ascending = true;

            var sizeDiscounts = new List<SizeDiscount>();
            var pagedResult = new PagedResult<SizeDiscount>
            {
                Items = sizeDiscounts,
                PageNumber = pageNumber,
                PageSize = 50, // Limited
                TotalCount = 0
            };

            mockSizeDiscountService.Setup(s => s.GetSizeDiscountsAsync(
                null, null, null, null, null, null,
                pageNumber, 50, sortBy, ascending)) // Expect limited value
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminSizeDiscountController.GetAll(
                null, null, null, null, null, null,
                pageNumber, pageSize, sortBy, ascending);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedPagedResult = Assert.IsType<PagedResult<SizeDiscountDto>>(okResult.Value);
            Assert.Equal(50, returnedPagedResult.PageSize); // Should be limited to 50

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task GetAll_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int pageNumber = 1;
            int pageSize = 10;
            string sortBy = "MinSize";
            bool ascending = true;

            mockSizeDiscountService.Setup(s => s.GetSizeDiscountsAsync(
                null, null, null, null, null, null,
                pageNumber, pageSize, sortBy, ascending))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminSizeDiscountController.GetAll(
                null, null, null, null, null, null,
                pageNumber, pageSize, sortBy, ascending);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Access the property using reflection
            var message = GetMessageFromResponse(statusCodeResult.Value);
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task GetById_ReturnsSizeDiscount_WhenDiscountExists()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 1;

            var sizeDiscount = new SizeDiscount
            {
                SizeDiscountId = id,
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10),
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockSizeDiscountService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(sizeDiscount);

            // Act
            var result = await adminSizeDiscountController.GetById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var discountDto = Assert.IsType<SizeDiscountDto>(okResult.Value);
            Assert.Equal(id, discountDto.Id);
            Assert.Equal(5, discountDto.MinSize);
            Assert.Equal(15, discountDto.DiscountPercentage);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenDiscountDoesNotExist()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 999;

            mockSizeDiscountService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync((SizeDiscount)null);

            // Act
            var result = await adminSizeDiscountController.GetById(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);

            // Access the property using reflection
            var message = GetMessageFromResponse(notFoundResult.Value);
            Assert.Equal($"Không tìm thấy giảm giá theo kích thước với ID {id}", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task GetById_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 1;

            mockSizeDiscountService.Setup(s => s.GetByIdAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminSizeDiscountController.GetById(id);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Access the property using reflection
            var message = GetMessageFromResponse(statusCodeResult.Value);
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Create_ReturnsCreatedDiscount_WhenRequestIsValid()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            var createDto = new SizeDiscountCreateDto
            {
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10)
            };

            var createdDiscount = new SizeDiscount
            {
                SizeDiscountId = 1,
                MinSize = createDto.MinSize,
                DiscountPercentage = createDto.DiscountPercentage,
                StartDate = createDto.StartDate,
                EndDate = createDto.EndDate,
                CreatedAt = DateTime.UtcNow.AddHours(7),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            mockSizeDiscountService.Setup(s => s.CreateAsync(
                It.Is<SizeDiscount>(d =>
                    d.MinSize == createDto.MinSize &&
                    d.DiscountPercentage == createDto.DiscountPercentage)))
                .ReturnsAsync(createdDiscount);

            // Act
            var result = await adminSizeDiscountController.Create(createDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(AdminSizeDiscountController.GetById), createdAtActionResult.ActionName);
            Assert.Equal(1, createdAtActionResult.RouteValues["id"]);

            var discountDto = Assert.IsType<SizeDiscountDto>(createdAtActionResult.Value);
            Assert.Equal(1, discountDto.Id);
            Assert.Equal(createDto.MinSize, discountDto.MinSize);
            Assert.Equal(createDto.DiscountPercentage, discountDto.DiscountPercentage);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            var createDto = new SizeDiscountCreateDto
            {
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10)
            };

            mockSizeDiscountService.Setup(s => s.CreateAsync(
                It.IsAny<SizeDiscount>()))
                .ThrowsAsync(new ValidationException("Discount with this minimum size already exists"));

            // Act
            var result = await adminSizeDiscountController.Create(createDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);

            // Access the property using reflection
            var message = GetMessageFromResponse(badRequestResult.Value);
            Assert.Equal("Discount with this minimum size already exists", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Create_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            var createDto = new SizeDiscountCreateDto
            {
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10)
            };

            mockSizeDiscountService.Setup(s => s.CreateAsync(
                It.IsAny<SizeDiscount>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminSizeDiscountController.Create(createDto);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Access the property using reflection
            var message = GetMessageFromResponse(statusCodeResult.Value);
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Update_ReturnsNoContent_WhenUpdateSucceeds()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 1;
            var updateDto = new SizeDiscountUpdateDto
            {
                MinSize = 10,
                DiscountPercentage = 20,
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(15)
            };

            var existingDiscount = new SizeDiscount
            {
                SizeDiscountId = id,
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10),
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockSizeDiscountService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingDiscount);

            mockSizeDiscountService.Setup(s => s.UpdateAsync(
                id,
                It.Is<SizeDiscount>(d =>
                    d.MinSize == updateDto.MinSize &&
                    d.DiscountPercentage == updateDto.DiscountPercentage)))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminSizeDiscountController.Update(id, updateDto);

            // Assert
            Assert.IsType<NoContentResult>(result);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenDiscountDoesNotExist()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 999;
            var updateDto = new SizeDiscountUpdateDto
            {
                MinSize = 10,
                DiscountPercentage = 20,
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(15)
            };

            mockSizeDiscountService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync((SizeDiscount)null);

            // Act
            var result = await adminSizeDiscountController.Update(id, updateDto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);

            // Access the property using reflection
            var message = GetMessageFromResponse(notFoundResult.Value);
            Assert.Equal($"Không tìm thấy giảm giá theo kích thước với ID {id}", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Update_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 1;
            var updateDto = new SizeDiscountUpdateDto
            {
                MinSize = 10,
                DiscountPercentage = 20,
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(15)
            };

            var existingDiscount = new SizeDiscount
            {
                SizeDiscountId = id,
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10),
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockSizeDiscountService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingDiscount);

            mockSizeDiscountService.Setup(s => s.UpdateAsync(
                id,
                It.IsAny<SizeDiscount>()))
                .ThrowsAsync(new ValidationException("Discount with this minimum size already exists"));

            // Act
            var result = await adminSizeDiscountController.Update(id, updateDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

            // Access the property using reflection
            var message = GetMessageFromResponse(badRequestResult.Value);
            Assert.Equal("Discount with this minimum size already exists", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenNotFoundExceptionIsThrown()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 1;
            var updateDto = new SizeDiscountUpdateDto
            {
                MinSize = 10,
                DiscountPercentage = 20,
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(15)
            };

            var existingDiscount = new SizeDiscount
            {
                SizeDiscountId = id,
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10),
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockSizeDiscountService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingDiscount);

            mockSizeDiscountService.Setup(s => s.UpdateAsync(
                id,
                It.IsAny<SizeDiscount>()))
                .ThrowsAsync(new NotFoundException($"Size discount with ID {id} not found"));

            // Act
            var result = await adminSizeDiscountController.Update(id, updateDto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);

            // Access the property using reflection
            var message = GetMessageFromResponse(notFoundResult.Value);
            Assert.Equal($"Size discount with ID {id} not found", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Update_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 1;
            var updateDto = new SizeDiscountUpdateDto
            {
                MinSize = 10,
                DiscountPercentage = 20,
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(15)
            };

            var existingDiscount = new SizeDiscount
            {
                SizeDiscountId = id,
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10),
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockSizeDiscountService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingDiscount);

            mockSizeDiscountService.Setup(s => s.UpdateAsync(
                id,
                It.IsAny<SizeDiscount>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminSizeDiscountController.Update(id, updateDto);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Access the property using reflection
            var message = GetMessageFromResponse(statusCodeResult.Value);
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Delete_ReturnsNoContent_WhenDeleteSucceeds()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 1;

            mockSizeDiscountService.Setup(s => s.DeleteAsync(id))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminSizeDiscountController.Delete(id);

            // Assert
            Assert.IsType<NoContentResult>(result);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Delete_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 1;

            mockSizeDiscountService.Setup(s => s.DeleteAsync(id))
                .ThrowsAsync(new ValidationException("Cannot delete discount that is in use"));

            // Act
            var result = await adminSizeDiscountController.Delete(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

            // Access the property using reflection
            var message = GetMessageFromResponse(badRequestResult.Value);
            Assert.Equal("Cannot delete discount that is in use", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Delete_ReturnsNotFound_WhenDiscountDoesNotExist()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 999;

            mockSizeDiscountService.Setup(s => s.DeleteAsync(id))
                .ThrowsAsync(new NotFoundException($"Size discount with ID {id} not found"));

            // Act
            var result = await adminSizeDiscountController.Delete(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);

            // Access the property using reflection
            var message = GetMessageFromResponse(notFoundResult.Value);
            Assert.Equal($"Size discount with ID {id} not found", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task Delete_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 1;

            mockSizeDiscountService.Setup(s => s.DeleteAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminSizeDiscountController.Delete(id);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Access the property using reflection
            var message = GetMessageFromResponse(statusCodeResult.Value);
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task GetApplicableDiscount_ReturnsDiscount_WhenDiscountExists()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int size = 10;

            var sizeDiscount = new SizeDiscount
            {
                SizeDiscountId = 1,
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10),
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockSizeDiscountService.Setup(s => s.GetApplicableDiscountAsync(size))
                .ReturnsAsync(sizeDiscount);

            // Act
            var result = await adminSizeDiscountController.GetApplicableDiscount(size);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var discountDto = Assert.IsType<SizeDiscountDto>(okResult.Value);
            Assert.Equal(1, discountDto.Id);
            Assert.Equal(5, discountDto.MinSize);
            Assert.Equal(15, discountDto.DiscountPercentage);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task GetApplicableDiscount_ReturnsNoDiscountMessage_WhenNoDiscountExists()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int size = 3; // Too small for any discount

            mockSizeDiscountService.Setup(s => s.GetApplicableDiscountAsync(size))
                .ReturnsAsync((SizeDiscount)null);

            // Act
            var result = await adminSizeDiscountController.GetApplicableDiscount(size);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);

            // Since this returns a dynamic object, we need to check properties
            var resultValue = okResult.Value;
            var messageProperty = resultValue.GetType().GetProperty("message");
            var discountPercentageProperty = resultValue.GetType().GetProperty("discountPercentage");

            Assert.Equal("Không tìm thấy giảm giá áp dụng cho kích thước này", messageProperty.GetValue(resultValue));
            Assert.Equal(0, discountPercentageProperty.GetValue(resultValue));

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task GetApplicableDiscount_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int size = -5; // Invalid size

            mockSizeDiscountService.Setup(s => s.GetApplicableDiscountAsync(size))
                .ThrowsAsync(new ValidationException("Size must be greater than 0"));

            // Act
            var result = await adminSizeDiscountController.GetApplicableDiscount(size);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);

            // Access the property using reflection
            var message = GetMessageFromResponse(badRequestResult.Value);
            Assert.Equal("Size must be greater than 0", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        [Fact]
        public async Task GetApplicableDiscount_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int size = 10;

            mockSizeDiscountService.Setup(s => s.GetApplicableDiscountAsync(size))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminSizeDiscountController.GetApplicableDiscount(size);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            // Access the property using reflection
            var message = GetMessageFromResponse(statusCodeResult.Value);
            Assert.Equal("Database connection error", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        // Additional test for edge case: UpdatedAt is null
        //[Fact]
        //public async Task GetById_HandlesNullUpdatedAt_WhenDiscountExists()
        //{
        //    // Arrange
        //    var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
        //    int id = 1;

        //    var sizeDiscount = new SizeDiscount
        //    {
        //        SizeDiscountId = id,
        //        MinSize = 5,
        //        DiscountPercentage = 15,
        //        StartDate = DateTime.UtcNow.AddDays(-10),
        //        EndDate = DateTime.UtcNow.AddDays(10),
        //        CreatedAt = DateTime.UtcNow.AddDays(-20),
        //        UpdatedAt = null // Null UpdatedAt
        //    };

        //    mockSizeDiscountService.Setup(s => s.GetByIdAsync(id))
        //        .ReturnsAsync(sizeDiscount);

        //    // Act
        //    var result = await adminSizeDiscountController.GetById(id);

        //    // Assert
        //    // The controller is returning a 500 error because of the null UpdatedAt
        //    var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
        //    Assert.Equal(500, statusCodeResult.StatusCode);

        //    // Access the property using reflection
        //    var message = GetMessageFromResponse(statusCodeResult.Value);
        //    Assert.Contains("Nullable object must have a value", message);

        //    // Verify service calls
        //    mockSizeDiscountService.Verify();
        //}

        // Test for date range validation
        [Fact]
        public async Task Create_ReturnsBadRequest_WhenDateRangeIsInvalid()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            var createDto = new SizeDiscountCreateDto
            {
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(10),
                EndDate = DateTime.UtcNow.AddDays(5) // End date before start date
            };

            mockSizeDiscountService.Setup(s => s.CreateAsync(
                It.IsAny<SizeDiscount>()))
                .ThrowsAsync(new ValidationException("End date must be after start date"));

            // Act
            var result = await adminSizeDiscountController.Create(createDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);

            // Access the property using reflection
            var message = GetMessageFromResponse(badRequestResult.Value);
            Assert.Equal("End date must be after start date", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        // Test for discount percentage validation
        [Fact]
        public async Task Update_ReturnsBadRequest_WhenDiscountPercentageIsInvalid()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            int id = 1;
            var updateDto = new SizeDiscountUpdateDto
            {
                MinSize = 10,
                DiscountPercentage = 101, // Invalid: > 100%
                StartDate = DateTime.UtcNow.AddDays(-5),
                EndDate = DateTime.UtcNow.AddDays(15)
            };

            var existingDiscount = new SizeDiscount
            {
                SizeDiscountId = id,
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10),
                CreatedAt = DateTime.UtcNow.AddDays(-20),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockSizeDiscountService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingDiscount);

            mockSizeDiscountService.Setup(s => s.UpdateAsync(
                id,
                It.IsAny<SizeDiscount>()))
                .ThrowsAsync(new ValidationException("Discount percentage must be between 0 and 100"));

            // Act
            var result = await adminSizeDiscountController.Update(id, updateDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);

            // Access the property using reflection
            var message = GetMessageFromResponse(badRequestResult.Value);
            Assert.Equal("Discount percentage must be between 0 and 100", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }

        // Test for overlapping discount ranges
        [Fact]
        public async Task Create_ReturnsBadRequest_WhenDiscountRangesOverlap()
        {
            // Arrange
            var adminSizeDiscountController = this.CreateAdminSizeDiscountController();
            var createDto = new SizeDiscountCreateDto
            {
                MinSize = 5,
                DiscountPercentage = 15,
                StartDate = DateTime.UtcNow.AddDays(-10),
                EndDate = DateTime.UtcNow.AddDays(10)
            };

            mockSizeDiscountService.Setup(s => s.CreateAsync(
                It.IsAny<SizeDiscount>()))
                .ThrowsAsync(new ValidationException("Discount range overlaps with existing discount"));

            // Act
            var result = await adminSizeDiscountController.Create(createDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);

            // Access the property using reflection
            var message = GetMessageFromResponse(badRequestResult.Value);
            Assert.Equal("Discount range overlaps with existing discount", message);

            // Verify service calls
            mockSizeDiscountService.Verify();
        }
    }
}