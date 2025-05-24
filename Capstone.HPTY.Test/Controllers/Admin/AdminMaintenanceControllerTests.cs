using Capstone.HPTY.API.Controllers.Admin;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.MaintenanceLog;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.AspNetCore.Http.HttpResults;
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
    public class AdminMaintenanceControllerTests
    {
        private MockRepository mockRepository;

        private Mock<IDamageDeviceService> mockDamageDeviceService;
        private Mock<IUtensilService> mockUtensilService;
        private Mock<IHotpotService> mockHotpotService;
        private Mock<ILogger<AdminMaintenanceController>> mockLogger;

        public AdminMaintenanceControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockDamageDeviceService = this.mockRepository.Create<IDamageDeviceService>();
            this.mockUtensilService = this.mockRepository.Create<IUtensilService>();
            this.mockHotpotService = this.mockRepository.Create<IHotpotService>();
            this.mockLogger = new Mock<ILogger<AdminMaintenanceController>>(MockBehavior.Loose);

            // Setup logger to accept any calls
            mockLogger.Setup(x => x.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()));
        }

        private AdminMaintenanceController CreateAdminMaintenanceController()
        {
            return new AdminMaintenanceController(
                this.mockDamageDeviceService.Object,
                this.mockUtensilService.Object,
                this.mockHotpotService.Object,
                this.mockLogger.Object);
        }

        [Fact]
        public async Task GetHotpotLogs_ReturnsPagedResult_WhenParametersAreValid()
        {
            // Arrange
            var adminMaintenanceController = this.CreateAdminMaintenanceController();
            string searchTerm = "test";
            MaintenanceStatus? status = MaintenanceStatus.Pending;
            int? hotPotInventoryId = 1;
            DateTime? fromDate = DateTime.UtcNow.AddDays(-30);
            DateTime? toDate = DateTime.UtcNow.AddHours(7);
            string sortBy = "LoggedDate";
            bool ascending = false;
            int pageNumber = 1;
            int pageSize = 10;

            var request = new DamageDeviceFilterRequest
            {
                SearchTerm = searchTerm,
                Status = status,
                HotPotInventoryId = hotPotInventoryId,
                FromDate = fromDate,
                ToDate = toDate,
                SortBy = sortBy,
                Ascending = ascending,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var hotpotInventory = new HotPotInventory
            {
                HotPotInventoryId = hotPotInventoryId.Value,
                SeriesNumber = "HP-123456"
            };

            var damageDevices = new List<DamageDevice>
            {
                new DamageDevice
                {
                    DamageDeviceId = 1,
                    Name = "Damaged Hotpot",
                    Description = "Heating element not working",
                    Status = MaintenanceStatus.Pending,
                    LoggedDate = DateTime.UtcNow.AddDays(-5),
                    HotPotInventoryId = hotPotInventoryId,
                    HotPotInventory = hotpotInventory,
                    CreatedAt = DateTime.UtcNow.AddDays(-5),
                    UpdatedAt = null
                }
            };

            var pagedResult = new PagedResult<DamageDevice>
            {
                Items = damageDevices,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockDamageDeviceService.Setup(s => s.GetAllAsync(It.Is<DamageDeviceFilterRequest>(r =>
                r.SearchTerm == searchTerm &&
                r.Status == status &&
                r.HotPotInventoryId == hotPotInventoryId &&
                r.FromDate == fromDate &&
                r.ToDate == toDate &&
                r.SortBy == sortBy &&
                r.Ascending == ascending &&
                r.PageNumber == pageNumber &&
                r.PageSize == pageSize)))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminMaintenanceController.GetHotpotLogs(
                searchTerm,
                status,
                hotPotInventoryId,
                fromDate,
                toDate,
                sortBy,
                ascending,
                pageNumber,
                pageSize);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<DamageHotpotDto>>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Lấy danh sách thiết bị hư hỏng thành công", apiResponse.Message);
            Assert.Equal(1, apiResponse.Data.TotalCount);

            var items = apiResponse.Data.Items.ToList();
            Assert.Single(items);
            Assert.Equal(1, items[0].DamageDeviceId);
            Assert.Equal("Damaged Hotpot", items[0].Name);
            Assert.Equal("Pending", items[0].StatusName);
            Assert.Equal(hotPotInventoryId, items[0].HotPotInventoryId);
            Assert.Equal("HP-123456", items[0].HotPotInventorySeriesNumber);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetHotpotLogs_ReturnsBadRequest_WhenPageParametersAreInvalid()
        {
            // Arrange
            var adminMaintenanceController = this.CreateAdminMaintenanceController();
            string searchTerm = null;
            MaintenanceStatus? status = null;
            int? hotPotInventoryId = null;
            DateTime? fromDate = null;
            DateTime? toDate = null;
            string sortBy = "LoggedDate";
            bool ascending = false;
            int pageNumber = 0; // Invalid
            int pageSize = 0;   // Invalid

            // Setup logger to expect a specific log call or no calls at all
            // Option 1: Setup for a specific log message
            mockLogger.Setup(x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Admin retrieving hotpot damage logs")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()));

            // Act
            var result = await adminMaintenanceController.GetHotpotLogs(
                searchTerm,
                status,
                hotPotInventoryId,
                fromDate,
                toDate,
                sortBy,
                ascending,
                pageNumber,
                pageSize);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi", apiResponse.Status);
            Assert.Equal("Số trang và kích thước trang phải lớn hơn 0", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetHotpotLogs_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminMaintenanceController = this.CreateAdminMaintenanceController();
            string searchTerm = null;
            MaintenanceStatus? status = null;
            int? hotPotInventoryId = null;
            DateTime? fromDate = null;
            DateTime? toDate = null;
            string sortBy = "LoggedDate";
            bool ascending = false;
            int pageNumber = 1;
            int pageSize = 10;

            mockDamageDeviceService.Setup(s => s.GetAllAsync(It.IsAny<DamageDeviceFilterRequest>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminMaintenanceController.GetHotpotLogs(
                searchTerm,
                status,
                hotPotInventoryId,
                fromDate,
                toDate,
                sortBy,
                ascending,
                pageNumber,
                pageSize);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi", apiResponse.Status);
            Assert.Equal("Không thể lấy danh sách thiết bị hư hỏng", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetDeviceById_ReturnsDevice_WhenDeviceExists()
        {
            // Arrange
            var adminMaintenanceController = this.CreateAdminMaintenanceController();
            int id = 1;

            var hotpotInventory = new HotPotInventory
            {
                HotPotInventoryId = 1,
                SeriesNumber = "HP-123456"
            };

            var damageDevice = new DamageDevice
            {
                DamageDeviceId = id,
                Name = "Damaged Hotpot",
                Description = "Heating element not working",
                Status = MaintenanceStatus.Pending,
                LoggedDate = DateTime.UtcNow.AddDays(-5),
                HotPotInventoryId = 1,
                HotPotInventory = hotpotInventory,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                UpdatedAt = null
            };

            mockDamageDeviceService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(damageDevice);

            // Act
            var result = await adminMaintenanceController.GetDeviceById(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<DamageDeviceDetailDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Lấy thông tin thiết bị hư hỏng thành công", apiResponse.Message);
            Assert.Equal(id, apiResponse.Data.DamageDeviceId);
            Assert.Equal("Damaged Hotpot", apiResponse.Data.Name);
            Assert.Equal("Pending", apiResponse.Data.StatusName);
            Assert.Equal(1, apiResponse.Data.HotPotInventoryId);
            Assert.Equal("HP-123456", apiResponse.Data.HotPotInventorySeriesNumber);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetDeviceById_ReturnsNotFound_WhenDeviceDoesNotExist()
        {
            // Arrange
            var adminMaintenanceController = this.CreateAdminMaintenanceController();
            int id = 999;

            mockDamageDeviceService.Setup(s => s.GetByIdAsync(id))
                .ThrowsAsync(new NotFoundException($"Damage device with ID {id} not found"));

            // Act
            var result = await adminMaintenanceController.GetDeviceById(id);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Lỗi", apiResponse.Status);
            Assert.Equal($"Damage device with ID {id} not found", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task GetDeviceById_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminMaintenanceController = this.CreateAdminMaintenanceController();
            int id = 1;

            mockDamageDeviceService.Setup(s => s.GetByIdAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminMaintenanceController.GetDeviceById(id);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi", apiResponse.Status);
            Assert.Equal("Không thể lấy thông tin thiết bị hư hỏng", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        //[Fact]
        //public async Task CreateDevice_ReturnsCreatedDevice_WhenRequestIsValid()
        //{
        //    // Arrange
        //    var adminMaintenanceController = this.CreateAdminMaintenanceController();
        //    var request = new CreateDamageDeviceRequest
        //    {
        //        Name = "New Damaged Hotpot",
        //        Description = "Power button broken",
        //        Status = MaintenanceStatus.Pending,
        //        HotPotInventoryId = 1
        //    };

        //    var createdDevice = new DamageDevice
        //    {
        //        DamageDeviceId = 1,
        //        Name = request.Name,
        //        Description = request.Description,
        //        Status = request.Status,
        //        LoggedDate = DateTime.UtcNow.AddHours(7),
        //        HotPotInventoryId = request.HotPotInventoryId,
        //        CreatedAt = DateTime.UtcNow.AddHours(7),
        //        UpdatedAt = null
        //    };

        //    mockDamageDeviceService.Setup(s => s.CreateAsync(It.Is<DamageDevice>(d =>
        //        d.Name == request.Name &&
        //        d.Description == request.Description &&
        //        d.Status == request.Status &&
        //        d.HotPotInventoryId == request.HotPotInventoryId)))
        //        .ReturnsAsync(createdDevice);

        //    // Act
        //    var result = await adminMaintenanceController.CreateDevice(request);

        //    // Assert
        //    var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        //    Assert.Equal(nameof(AdminMaintenanceController.GetDeviceById), createdAtActionResult.ActionName);
        //    Assert.Equal(1, createdAtActionResult.RouteValues["id"]);

        //    var apiResponse = Assert.IsType<ApiResponse<DamageDeviceDto>>(createdAtActionResult.Value);
        //    Assert.True(apiResponse.Success);
        //    Assert.Equal("Tạo thiết bị hư hỏng thành công", apiResponse.Message);
        //    Assert.Equal(1, apiResponse.Data.DamageDeviceId);
        //    Assert.Equal(request.Name, apiResponse.Data.Name);
        //    Assert.Equal(request.Status.ToString(), apiResponse.Data.StatusName);

        //    this.mockRepository.VerifyAll();
        //}

        //[Fact]
        //public async Task CreateDevice_ReturnsBadRequest_WhenValidationFails()
        //{
        //    // Arrange
        //    var adminMaintenanceController = this.CreateAdminMaintenanceController();
        //    var request = new CreateDamageDeviceRequest
        //    {
        //        Name = "New Damaged Hotpot",
        //        Description = "Power button broken",
        //        Status = MaintenanceStatus.Pending,
        //        HotPotInventoryId = 1
        //    };

        //    mockDamageDeviceService.Setup(s => s.CreateAsync(It.IsAny<DamageDevice>()))
        //        .ThrowsAsync(new ValidationException("Invalid hotpot inventory ID"));

        //    // Act
        //    var result = await adminMaintenanceController.CreateDevice(request);

        //    // Assert
        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        //    var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
        //    Assert.Equal("Lỗi xác thực", apiResponse.Status);
        //    Assert.Equal("Invalid hotpot inventory ID", apiResponse.Message);

        //    this.mockRepository.VerifyAll();
        //}

        //[Fact]
        //public async Task CreateDevice_ReturnsBadRequest_WhenExceptionOccurs()
        //{
        //    // Arrange
        //    var adminMaintenanceController = this.CreateAdminMaintenanceController();
        //    var request = new CreateDamageDeviceRequest
        //    {
        //        Name = "New Damaged Hotpot",
        //        Description = "Power button broken",
        //        Status = MaintenanceStatus.Pending,
        //        HotPotInventoryId = 1
        //    };

        //    mockDamageDeviceService.Setup(s => s.CreateAsync(It.IsAny<DamageDevice>()))
        //        .ThrowsAsync(new Exception("Database connection error"));

        //    // Act
        //    var result = await adminMaintenanceController.CreateDevice(request);

        //    // Assert
        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        //    var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
        //    Assert.Equal("Lỗi", apiResponse.Status);
        //    Assert.Equal("Không thể tạo thiết bị hư hỏng", apiResponse.Message);

        //    this.mockRepository.VerifyAll();
        //}

        [Fact]
        public async Task UpdateDevice_ReturnsUpdatedDevice_WhenRequestIsValid()
        {
            // Arrange
            var adminMaintenanceController = this.CreateAdminMaintenanceController();
            int id = 1;
            var request = new UpdateDamageDeviceRequest
            {
                Name = "Updated Hotpot Name",
                Description = "Updated description",
                Status = "Fixed"
            };

            var existingDevice = new DamageDevice
            {
                DamageDeviceId = id,
                Name = "Old Hotpot Name",
                Description = "Old description",
                Status = MaintenanceStatus.Pending,
                LoggedDate = DateTime.UtcNow.AddDays(-5),
                HotPotInventoryId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                UpdatedAt = null
            };

            var updatedDevice = new DamageDevice
            {
                DamageDeviceId = id,
                Name = request.Name,
                Description = request.Description,
                Status = MaintenanceStatus.Completed,
                LoggedDate = DateTime.UtcNow.AddDays(-5),
                HotPotInventoryId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            mockDamageDeviceService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingDevice);

            mockDamageDeviceService.Setup(s => s.UpdateAsync(id, It.Is<DamageDevice>(d =>
                d.Name == request.Name &&
                d.Description == request.Description &&
                d.Status == MaintenanceStatus.Completed)))
                .Returns(Task.CompletedTask);

            mockDamageDeviceService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(updatedDevice);

            // Act
            var result = await adminMaintenanceController.UpdateDevice(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<DamageDeviceDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Cập nhật thiết bị hư hỏng thành công", apiResponse.Message);
            Assert.Equal(id, apiResponse.Data.DamageDeviceId);
            Assert.Equal(request.Name, apiResponse.Data.Name);
            Assert.Equal(request.Description, apiResponse.Data.Description);
            Assert.Equal("Completed", apiResponse.Data.StatusName);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task UpdateDevice_ReturnsNotFound_WhenDeviceDoesNotExist()
        {
            // Arrange
            var adminMaintenanceController = this.CreateAdminMaintenanceController();
            int id = 999;
            var request = new UpdateDamageDeviceRequest
            {
                Name = "Updated Hotpot Name",
                Description = "Updated description",
                Status = "Fixed"
            };

            mockDamageDeviceService.Setup(s => s.GetByIdAsync(id))
                .ThrowsAsync(new NotFoundException($"Damage device with ID {id} not found"));

            // Act
            var result = await adminMaintenanceController.UpdateDevice(id, request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Lỗi", apiResponse.Status);
            Assert.Equal($"Damage device with ID {id} not found", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task UpdateDevice_ReturnsBadRequest_WhenValidationFails()
        {
            // Arrange
            var adminMaintenanceController = this.CreateAdminMaintenanceController();
            int id = 1;
            var request = new UpdateDamageDeviceRequest
            {
                Name = "Up", // Too short, validation should fail
                Description = "Updated description",
                Status = "Fixed"
            };

            var existingDevice = new DamageDevice
            {
                DamageDeviceId = id,
                Name = "Old Hotpot Name",
                Description = "Old description",
                Status = MaintenanceStatus.Pending,
                LoggedDate = DateTime.UtcNow.AddDays(-5),
                HotPotInventoryId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                UpdatedAt = null
            };

            mockDamageDeviceService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingDevice);

            mockDamageDeviceService.Setup(s => s.UpdateAsync(id, It.IsAny<DamageDevice>()))
                .ThrowsAsync(new ValidationException("Name must be at least 3 characters"));

            // Act
            var result = await adminMaintenanceController.UpdateDevice(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi xác thực", apiResponse.Status);
            Assert.Equal("Name must be at least 3 characters", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        [Fact]
        public async Task UpdateDevice_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminMaintenanceController = this.CreateAdminMaintenanceController();
            int id = 1;
            var request = new UpdateDamageDeviceRequest
            {
                Name = "Updated Hotpot Name",
                Description = "Updated description",
                Status = "Fixed"
            };

            var existingDevice = new DamageDevice
            {
                DamageDeviceId = id,
                Name = "Old Hotpot Name",
                Description = "Old description",
                Status = MaintenanceStatus.Pending,
                LoggedDate = DateTime.UtcNow.AddDays(-5),
                HotPotInventoryId = 1,
                CreatedAt = DateTime.UtcNow.AddDays(-5),
                UpdatedAt = null
            };

            mockDamageDeviceService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingDevice);

            mockDamageDeviceService.Setup(s => s.UpdateAsync(id, It.IsAny<DamageDevice>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminMaintenanceController.UpdateDevice(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Lỗi", apiResponse.Status);
            Assert.Equal("Không thể cập nhật thiết bị hư hỏng", apiResponse.Message);

            this.mockRepository.VerifyAll();
        }

        //[Fact]
        //public async Task DeleteDevice_ReturnsSuccess_WhenDeviceExists()
        //{
        //    // Arrange
        //    var adminMaintenanceController = this.CreateAdminMaintenanceController();
        //    int id = 1;

        //    mockDamageDeviceService.Setup(s => s.DeleteAsync(id))
        //        .Returns(Task.CompletedTask);

        //    // Act
        //    var result = await adminMaintenanceController.DeleteDevice(id);

        //    // Assert
        //    var okResult = Assert.IsType<OkObjectResult>(result.Result);
        //    var apiResponse = Assert.IsType<ApiResponse<string>>(okResult.Value);
        //    Assert.True(apiResponse.Success);
        //    Assert.Equal("Xóa thiết bị hư hỏng thành công", apiResponse.Message);
        //    Assert.Equal($"Thiết bị hư hỏng với ID {id} đã được xóa", apiResponse.Data);

        //    this.mockRepository.VerifyAll();
        //}

        //[Fact]
        //public async Task DeleteDevice_ReturnsNotFound_WhenDeviceDoesNotExist()
        //{
        //    // Arrange
        //    var adminMaintenanceController = this.CreateAdminMaintenanceController();
        //    int id = 999;

        //    mockDamageDeviceService.Setup(s => s.DeleteAsync(id))
        //        .ThrowsAsync(new NotFoundException($"Damage device with ID {id} not found"));

        //    // Act
        //    var result = await adminMaintenanceController.DeleteDevice(id);

        //    // Assert
        //    var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
        //    var apiResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
        //    Assert.Equal("Lỗi", apiResponse.Status);
        //    Assert.Equal($"Damage device with ID {id} not found", apiResponse.Message);

        //    this.mockRepository.VerifyAll();
        //}

        //[Fact]
        //public async Task DeleteDevice_ReturnsBadRequest_WhenValidationFails()
        //{
        //    // Arrange
        //    var adminMaintenanceController = this.CreateAdminMaintenanceController();
        //    int id = 1;

        //    mockDamageDeviceService.Setup(s => s.DeleteAsync(id))
        //        .ThrowsAsync(new ValidationException("Cannot delete device that is in use"));

        //    // Act
        //    var result = await adminMaintenanceController.DeleteDevice(id);

        //    // Assert
        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        //    var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
        //    Assert.Equal("Lỗi xác thực", apiResponse.Status);
        //    Assert.Equal("Cannot delete device that is in use", apiResponse.Message);

        //    this.mockRepository.VerifyAll();
        //}

        //[Fact]
        //public async Task DeleteDevice_ReturnsBadRequest_WhenExceptionOccurs()
        //{
        //    // Arrange
        //    var adminMaintenanceController = this.CreateAdminMaintenanceController();
        //    int id = 1;

        //    mockDamageDeviceService.Setup(s => s.DeleteAsync(id))
        //        .ThrowsAsync(new Exception("Database connection error"));

        //    // Act
        //    var result = await adminMaintenanceController.DeleteDevice(id);

        //    // Assert
        //    var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
        //    var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
        //    Assert.Equal("Lỗi", apiResponse.Status);
        //    Assert.Equal("Không thể xóa thiết bị hư hỏng", apiResponse.Message);

        //    this.mockRepository.VerifyAll();
        //}
    }

}