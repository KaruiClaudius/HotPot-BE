using Capstone.HPTY.API.Controllers.Schedule;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Schedule
{
    public class AdminScheduleControllerTests
    {
        private readonly MockRepository mockRepository;
        private readonly Mock<IScheduleService> mockScheduleService;
        private readonly Mock<INotificationService> mockNotificationService;

        public AdminScheduleControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockScheduleService = this.mockRepository.Create<IScheduleService>();
            this.mockNotificationService = this.mockRepository.Create<INotificationService>();
        }

        private AdminScheduleController CreateAdminScheduleController()
        {
            return new AdminScheduleController(
                this.mockScheduleService.Object,
                this.mockNotificationService.Object);
        }

        #region GetAllWorkShifts Tests

        [Fact]
        public async Task GetAllWorkShifts_ReturnsOkResult_WithWorkShifts()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();

            var workShifts = new List<WorkShift>
            {
                new WorkShift
                {
                    WorkShiftId = 1,
                    ShiftStartTime = new TimeSpan(8, 0, 0),
                    ShiftEndTime = new TimeSpan(16, 0, 0),
                    ShiftName = "Morning Shift",
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5)
                },
                new WorkShift
                {
                    WorkShiftId = 2,
                    ShiftStartTime = new TimeSpan(16, 0, 0),
                    ShiftEndTime = new TimeSpan(0, 0, 0),
                    ShiftName = "Evening Shift",
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5)
                }
            };

            this.mockScheduleService
                .Setup(s => s.GetAllWorkShiftsAsync())
                .ReturnsAsync(workShifts);

            // Act
            var result = await adminScheduleController.GetAllWorkShifts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedShifts = Assert.IsType<List<WorkShiftDto>>(okResult.Value);

            Assert.Equal(2, returnedShifts.Count);

            // Check first shift
            Assert.Equal(1, returnedShifts[0].WorkShiftId);
            Assert.Equal("Morning Shift", returnedShifts[0].ShiftName);
            Assert.Equal(new TimeSpan(8, 0, 0), returnedShifts[0].ShiftStartTime);
            Assert.Equal(new TimeSpan(16, 0, 0), returnedShifts[0].ShiftEndTime);

            // Check second shift
            Assert.Equal(2, returnedShifts[1].WorkShiftId);
            Assert.Equal("Evening Shift", returnedShifts[1].ShiftName);
            Assert.Equal(new TimeSpan(16, 0, 0), returnedShifts[1].ShiftStartTime);
            Assert.Equal(new TimeSpan(0, 0, 0), returnedShifts[1].ShiftEndTime);

            this.mockScheduleService.Verify(s => s.GetAllWorkShiftsAsync(), Times.Once);
        }

        [Fact]
        public async Task GetAllWorkShifts_ReturnsEmptyList_WhenNoWorkShifts()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();

            var emptyList = new List<WorkShift>();

            this.mockScheduleService
                .Setup(s => s.GetAllWorkShiftsAsync())
                .ReturnsAsync(emptyList);

            // Act
            var result = await adminScheduleController.GetAllWorkShifts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedShifts = Assert.IsType<List<WorkShiftDto>>(okResult.Value);

            Assert.Empty(returnedShifts);

            this.mockScheduleService.Verify(s => s.GetAllWorkShiftsAsync(), Times.Once);
        }

        [Fact]
        public async Task GetAllWorkShifts_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();

            this.mockScheduleService
                .Setup(s => s.GetAllWorkShiftsAsync())
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminScheduleController.GetAllWorkShifts();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("Internal server error", statusCodeResult.Value.ToString());

            this.mockScheduleService.Verify(s => s.GetAllWorkShiftsAsync(), Times.Once);
        }

        #endregion

        #region GetWorkShiftById Tests

        [Fact]
        public async Task GetWorkShiftById_ReturnsOkResult_WhenWorkShiftExists()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;

            var workShift = new WorkShift
            {
                WorkShiftId = shiftId,
                ShiftStartTime = new TimeSpan(8, 0, 0),
                ShiftEndTime = new TimeSpan(16, 0, 0),
                ShiftName = "Morning Shift",
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ReturnsAsync(workShift);

            // Act
            var result = await adminScheduleController.GetWorkShiftById(shiftId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedShift = Assert.IsType<WorkShiftDto>(okResult.Value);

            Assert.Equal(shiftId, returnedShift.WorkShiftId);
            Assert.Equal("Morning Shift", returnedShift.ShiftName);
            Assert.Equal(new TimeSpan(8, 0, 0), returnedShift.ShiftStartTime);
            Assert.Equal(new TimeSpan(16, 0, 0), returnedShift.ShiftEndTime);

            this.mockScheduleService.Verify(s => s.GetWorkShiftByIdAsync(shiftId), Times.Once);
        }

        [Fact]
        public async Task GetWorkShiftById_ReturnsNotFound_WhenWorkShiftDoesNotExist()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 999;

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ReturnsAsync((WorkShift)null);

            // Act
            var result = await adminScheduleController.GetWorkShiftById(shiftId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Contains($"Work shift with ID {shiftId} not found", notFoundResult.Value.ToString());

            this.mockScheduleService.Verify(s => s.GetWorkShiftByIdAsync(shiftId), Times.Once);
        }

        [Fact]
        public async Task GetWorkShiftById_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminScheduleController.GetWorkShiftById(shiftId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("Internal server error", statusCodeResult.Value.ToString());

            this.mockScheduleService.Verify(s => s.GetWorkShiftByIdAsync(shiftId), Times.Once);
        }

        #endregion

        #region CreateWorkShift Tests

        [Fact]
        public async Task CreateWorkShift_ReturnsCreatedResult_WhenRequestIsValid()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            var createDto = new CreateWorkShiftDto
            {
                ShiftName = "New Shift",
                ShiftStartTime = new TimeSpan(9, 0, 0),
                ShiftEndTime = new TimeSpan(17, 0, 0)
            };

            var createdWorkShift = new WorkShift
            {
                WorkShiftId = 3,
                ShiftName = createDto.ShiftName,
                ShiftStartTime = createDto.ShiftStartTime,
                ShiftEndTime = createDto.ShiftEndTime,
                CreatedAt = DateTime.UtcNow.AddHours(7),
                UpdatedAt = null,
                Staff = new List<User>(),
                Managers = new List<User>()
            };

            this.mockScheduleService
                .Setup(s => s.CreateWorkShiftAsync(It.IsAny<WorkShift>()))
                .ReturnsAsync(createdWorkShift);

            // Act
            var result = await adminScheduleController.CreateWorkShift(createDto);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(AdminScheduleController.GetWorkShiftById), createdAtActionResult.ActionName);
            Assert.Equal(3, createdAtActionResult.RouteValues["shiftId"]);

            var apiResponse = Assert.IsType<ApiResponse<WorkShiftDto>>(createdAtActionResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Work shift created successfully", apiResponse.Message);

            var shiftDto = apiResponse.Data;
            Assert.Equal(3, shiftDto.WorkShiftId);
            Assert.Equal("New Shift", shiftDto.ShiftName);
            Assert.Equal(new TimeSpan(9, 0, 0), shiftDto.ShiftStartTime);
            Assert.Equal(new TimeSpan(17, 0, 0), shiftDto.ShiftEndTime);

            this.mockScheduleService.Verify(s => s.CreateWorkShiftAsync(It.IsAny<WorkShift>()), Times.Once);

        }

        [Fact]
        public async Task CreateWorkShift_ReturnsBadRequest_WhenRequestIsNull()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            CreateWorkShiftDto createDto = null;

            // Act
            var result = await adminScheduleController.CreateWorkShift(createDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<WorkShiftDto>>(badRequestResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal("Work shift data is required", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.CreateWorkShiftAsync(It.IsAny<WorkShift>()), Times.Never);
            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);
        }

        [Fact]
        public async Task CreateWorkShift_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            var createDto = new CreateWorkShiftDto
            {
                ShiftName = "New Shift",
                ShiftStartTime = new TimeSpan(9, 0, 0),
                ShiftEndTime = new TimeSpan(17, 0, 0)
            };

            this.mockScheduleService
                .Setup(s => s.CreateWorkShiftAsync(It.IsAny<WorkShift>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminScheduleController.CreateWorkShift(createDto);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<WorkShiftDto>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("Database connection error", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.CreateWorkShiftAsync(It.IsAny<WorkShift>()), Times.Once);
            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);
        }

        #endregion

        #region UpdateWorkShift Tests

        [Fact]
        public async Task UpdateWorkShift_ReturnsOkResult_WhenRequestIsValid()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;
            var updateDto = new UpdateWorkShiftDto
            {
                ShiftName = "Updated Shift",
                ShiftStartTime = new TimeSpan(10, 0, 0),
                ShiftEndTime = new TimeSpan(18, 0, 0)
            };

            var updatedWorkShift = new WorkShift
            {
                WorkShiftId = shiftId,
                ShiftName = updateDto.ShiftName,
                ShiftStartTime = updateDto.ShiftStartTime,
                ShiftEndTime = updateDto.ShiftEndTime,
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            var staffMembers = new List<User>
            {
                new User { UserId = 101, Name = "Staff 1", Email = "staff1@example.com" },
                new User { UserId = 102, Name = "Staff 2", Email = "staff2@example.com" }
            };

            var shiftWithStaff = new WorkShift
            {
                WorkShiftId = shiftId,
                ShiftName = updateDto.ShiftName,
                ShiftStartTime = updateDto.ShiftStartTime,
                ShiftEndTime = updateDto.ShiftEndTime,
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddHours(7),
                Staff = staffMembers
            };

            this.mockScheduleService
                .Setup(s => s.UpdateWorkShiftAsync(
                    shiftId,
                    updateDto.ShiftStartTime,
                    updateDto.ShiftEndTime,
                    updateDto.ShiftName))
                .ReturnsAsync(updatedWorkShift);

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ReturnsAsync(shiftWithStaff);

            // Setup notification for each staff member
            foreach (var staff in staffMembers)
            {
                this.mockNotificationService
                    .Setup(n => n.NotifyUserAsync(
                        staff.UserId,
                        "ScheduleUpdate",
                        "Cập nhật ca làm việc",
                        It.IsAny<string>(),
                        It.IsAny<Dictionary<string, object>>()))
                    .Returns(Task.CompletedTask);
            }

            // Setup notification for managers
            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "ScheduleUpdate",
                    "Cập nhật ca làm việc",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminScheduleController.UpdateWorkShift(shiftId, updateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<WorkShiftDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Work shift updated successfully", apiResponse.Message);

            var shiftDto = apiResponse.Data;
            Assert.Equal(shiftId, shiftDto.WorkShiftId);
            Assert.Equal("Updated Shift", shiftDto.ShiftName);
            Assert.Equal(new TimeSpan(10, 0, 0), shiftDto.ShiftStartTime);
            Assert.Equal(new TimeSpan(18, 0, 0), shiftDto.ShiftEndTime);

            this.mockScheduleService.Verify(s => s.UpdateWorkShiftAsync(
                shiftId,
                updateDto.ShiftStartTime,
                updateDto.ShiftEndTime,
                updateDto.ShiftName), Times.Once);

            this.mockScheduleService.Verify(s => s.GetWorkShiftByIdAsync(shiftId), Times.Once);

            // Verify notifications to staff members
            foreach (var staff in staffMembers)
            {
                this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                    staff.UserId,
                    "ScheduleUpdate",
                    "Cập nhật ca làm việc",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()), Times.Once);
            }

            // Verify notification to managers
            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                "Managers",
                "ScheduleUpdate",
                "Cập nhật ca làm việc",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);
        }

        [Fact]
        public async Task UpdateWorkShift_ReturnsBadRequest_WhenRequestIsNull()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;
            UpdateWorkShiftDto updateDto = null;

            // Act
            var result = await adminScheduleController.UpdateWorkShift(shiftId, updateDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<WorkShiftDto>>(badRequestResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal("Update data is required", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.UpdateWorkShiftAsync(
                It.IsAny<int>(),
                It.IsAny<TimeSpan>(),
                It.IsAny<TimeSpan>(),
                It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task UpdateWorkShift_ReturnsNotFound_WhenWorkShiftDoesNotExist()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 999;
            var updateDto = new UpdateWorkShiftDto
            {
                ShiftName = "Updated Shift",
                ShiftStartTime = new TimeSpan(10, 0, 0),
                ShiftEndTime = new TimeSpan(18, 0, 0)
            };

            this.mockScheduleService
                .Setup(s => s.UpdateWorkShiftAsync(
                    shiftId,
                    updateDto.ShiftStartTime,
                    updateDto.ShiftEndTime,
                    updateDto.ShiftName))
                .ThrowsAsync(new KeyNotFoundException($"Work shift with ID {shiftId} not found"));

            // Act
            var result = await adminScheduleController.UpdateWorkShift(shiftId, updateDto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<WorkShiftDto>>(notFoundResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal($"Work shift with ID {shiftId} not found", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.UpdateWorkShiftAsync(
                shiftId,
                updateDto.ShiftStartTime,
                updateDto.ShiftEndTime,
                updateDto.ShiftName), Times.Once);
        }

        [Fact]
        public async Task UpdateWorkShift_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;
            var updateDto = new UpdateWorkShiftDto
            {
                ShiftName = "Updated Shift",
                ShiftStartTime = new TimeSpan(10, 0, 0),
                ShiftEndTime = new TimeSpan(18, 0, 0)
            };

            this.mockScheduleService
                .Setup(s => s.UpdateWorkShiftAsync(
                    shiftId,
                    updateDto.ShiftStartTime,
                    updateDto.ShiftEndTime,
                    updateDto.ShiftName))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminScheduleController.UpdateWorkShift(shiftId, updateDto);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<WorkShiftDto>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while updating the work shift. Please try again later.", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.UpdateWorkShiftAsync(
                shiftId,
                updateDto.ShiftStartTime,
                updateDto.ShiftEndTime,
                updateDto.ShiftName), Times.Once);
        }

        #endregion

        #region DeleteWorkShift Tests

        [Fact]
        public async Task DeleteWorkShift_ReturnsNoContent_WhenWorkShiftExists()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;

            var workShift = new WorkShift
            {
                WorkShiftId = shiftId,
                ShiftName = "Morning Shift",
                ShiftStartTime = new TimeSpan(8, 0, 0),
                ShiftEndTime = new TimeSpan(16, 0, 0),
                Staff = new List<User>
                {
                    new User { UserId = 101, Name = "Staff 1", Email = "staff1@example.com" },
                    new User { UserId = 102, Name = "Staff 2", Email = "staff2@example.com" }
                }
            };

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ReturnsAsync(workShift);

            this.mockScheduleService
                .Setup(s => s.DeleteWorkShiftAsync(shiftId))
                .ReturnsAsync(true);

            // Setup notification for each staff member
            foreach (var staff in workShift.Staff)
            {
                this.mockNotificationService
                    .Setup(n => n.NotifyUserAsync(
                        staff.UserId,
                        "ScheduleUpdate",
                        "Đã xóa ca làm việc",
                        It.IsAny<string>(),
                        It.IsAny<Dictionary<string, object>>()))
                    .Returns(Task.CompletedTask);
            }

            // Setup notification for managers
            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "ScheduleUpdate",
                    "Đã xóa ca làm việc",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminScheduleController.DeleteWorkShift(shiftId);

            // Assert
            Assert.IsType<NoContentResult>(result);

            this.mockScheduleService.Verify(s => s.GetWorkShiftByIdAsync(shiftId), Times.Once);
            this.mockScheduleService.Verify(s => s.DeleteWorkShiftAsync(shiftId), Times.Once);

            // Verify notifications to staff members
            foreach (var staff in workShift.Staff)
            {
                this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                    staff.UserId,
                    "ScheduleUpdate",
                    "Đã xóa ca làm việc",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()), Times.Once);
            }

            // Verify notification to managers
            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                "Managers",
                "ScheduleUpdate",
                "Đã xóa ca làm việc",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);
        }

        [Fact]
        public async Task DeleteWorkShift_ReturnsNotFound_WhenWorkShiftDoesNotExist()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 999;

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ReturnsAsync((WorkShift)null);

            // Act
            var result = await adminScheduleController.DeleteWorkShift(shiftId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<bool>>(notFoundResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal($"Work shift with ID {shiftId} not found", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.GetWorkShiftByIdAsync(shiftId), Times.Once);
            this.mockScheduleService.Verify(s => s.DeleteWorkShiftAsync(shiftId), Times.Never);
        }

        [Fact]
        public async Task DeleteWorkShift_ReturnsNotFound_WhenDeleteFails()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;

            var workShift = new WorkShift
            {
                WorkShiftId = shiftId,
                ShiftName = "Morning Shift",
                ShiftStartTime = new TimeSpan(8, 0, 0),
                ShiftEndTime = new TimeSpan(16, 0, 0),
                Staff = new List<User>()
            };

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ReturnsAsync(workShift);

            this.mockScheduleService
                .Setup(s => s.DeleteWorkShiftAsync(shiftId))
                .ReturnsAsync(false);

            // Act
            var result = await adminScheduleController.DeleteWorkShift(shiftId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<bool>>(notFoundResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal($"Work shift with ID {shiftId} not found", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.GetWorkShiftByIdAsync(shiftId), Times.Once);
            this.mockScheduleService.Verify(s => s.DeleteWorkShiftAsync(shiftId), Times.Once);
        }

        [Fact]
        public async Task DeleteWorkShift_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminScheduleController.DeleteWorkShift(shiftId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<bool>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while deleting the work shift. Please try again later.", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.GetWorkShiftByIdAsync(shiftId), Times.Once);
            this.mockScheduleService.Verify(s => s.DeleteWorkShiftAsync(shiftId), Times.Never);
        }

        #endregion

        #region AssignManagerWorkDaysAndShifts Tests

        [Fact]
        public async Task AssignManagerWorkDaysAndShifts_ReturnsOkResult_WhenRequestIsValid()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            var assignDto = new AssignManagerWorkDaysAndShiftsDto
            {
                ManagerId = 1,
                WorkDays = WorkDays.Monday | WorkDays.Wednesday | WorkDays.Friday,
                WorkShiftIds = new List<int> { 1, 2 }
            };

            var workShifts = new List<WorkShift>
            {
                new WorkShift
                {
                    WorkShiftId = 1,
                    ShiftName = "Morning Shift",
                    ShiftStartTime = new TimeSpan(8, 0, 0),
                    ShiftEndTime = new TimeSpan(16, 0, 0)
                },
                new WorkShift
                {
                    WorkShiftId = 2,
                    ShiftName = "Evening Shift",
                    ShiftStartTime = new TimeSpan(16, 0, 0),
                    ShiftEndTime = new TimeSpan(0, 0, 0)
                }
            };

            var manager = new User
            {
                UserId = assignDto.ManagerId,
                Name = "Manager Name",
                Email = "manager@example.com",
                WorkDays = assignDto.WorkDays,
                MangerWorkShifts = workShifts
            };

            this.mockScheduleService
                .Setup(s => s.AssignManagerToWorkShiftsAsync(
                    assignDto.ManagerId,
                    assignDto.WorkDays,
                    assignDto.WorkShiftIds))
                .ReturnsAsync(manager);

            this.mockNotificationService
                .Setup(n => n.NotifyUserAsync(
                    assignDto.ManagerId,
                    "ScheduleUpdate",
                    "Lịch làm việc của bạn đã được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "ScheduleUpdate",
                    "Lịch trình của Quản lý được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminScheduleController.AssignManagerWorkDaysAndShifts(assignDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<ManagerDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Manager work days and shifts assigned successfully", apiResponse.Message);

            var managerDto = apiResponse.Data;
            Assert.Equal(assignDto.ManagerId, managerDto.UserId);
            Assert.Equal("Manager Name", managerDto.Name);
            Assert.Equal("manager@example.com", managerDto.Email);
            Assert.Equal(assignDto.WorkDays, managerDto.WorkDays);
            Assert.Equal(2, managerDto.WorkShifts.Count);

            // Check first shift
            Assert.Equal(1, managerDto.WorkShifts[0].WorkShiftId);
            Assert.Equal("Morning Shift", managerDto.WorkShifts[0].ShiftName);
            Assert.Equal(new TimeSpan(8, 0, 0), managerDto.WorkShifts[0].ShiftStartTime);
            Assert.Equal(new TimeSpan(16, 0, 0), managerDto.WorkShifts[0].ShiftEndTime);

            // Check second shift
            Assert.Equal(2, managerDto.WorkShifts[1].WorkShiftId);
            Assert.Equal("Evening Shift", managerDto.WorkShifts[1].ShiftName);
            Assert.Equal(new TimeSpan(16, 0, 0), managerDto.WorkShifts[1].ShiftStartTime);
            Assert.Equal(new TimeSpan(0, 0, 0), managerDto.WorkShifts[1].ShiftEndTime);

            this.mockScheduleService.Verify(s => s.AssignManagerToWorkShiftsAsync(
                assignDto.ManagerId,
                assignDto.WorkDays,
                assignDto.WorkShiftIds), Times.Once);

            this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                assignDto.ManagerId,
                "ScheduleUpdate",
                "Lịch làm việc của bạn đã được cập nhật",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);

            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                "Managers",
                "ScheduleUpdate",
                "Lịch trình của Quản lý được cập nhật",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);
        }

        [Fact]
        public async Task AssignManagerWorkDaysAndShifts_HandlesEmptyShiftList_WhenClearingSchedule()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            var assignDto = new AssignManagerWorkDaysAndShiftsDto
            {
                ManagerId = 1,
                WorkDays = WorkDays.None,
                WorkShiftIds = new List<int>() // Empty list
            };

            var manager = new User
            {
                UserId = assignDto.ManagerId,
                Name = "Manager Name",
                Email = "manager@example.com",
                WorkDays = assignDto.WorkDays,
                MangerWorkShifts = new List<WorkShift>() // Empty list
            };

            this.mockScheduleService
                .Setup(s => s.AssignManagerToWorkShiftsAsync(
                    assignDto.ManagerId,
                    assignDto.WorkDays,
                    assignDto.WorkShiftIds))
                .ReturnsAsync(manager);

            this.mockNotificationService
                .Setup(n => n.NotifyUserAsync(
                    assignDto.ManagerId,
                    "ScheduleUpdate",
                    "Lịch làm việc của bạn đã được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "ScheduleUpdate",
                    "Lịch trình của Quản lý được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminScheduleController.AssignManagerWorkDaysAndShifts(assignDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<ManagerDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Manager work days and shifts assigned successfully", apiResponse.Message);

            var managerDto = apiResponse.Data;
            Assert.Equal(assignDto.ManagerId, managerDto.UserId);
            Assert.Equal(WorkDays.None, managerDto.WorkDays);
            Assert.Empty(managerDto.WorkShifts);

            this.mockScheduleService.Verify(s => s.AssignManagerToWorkShiftsAsync(
                assignDto.ManagerId,
                assignDto.WorkDays,
                assignDto.WorkShiftIds), Times.Once);
        }


        [Fact]
        public async Task AssignManagerWorkDaysAndShifts_HandlesNullShiftIds_ByUsingEmptyList()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            var assignDto = new AssignManagerWorkDaysAndShiftsDto
            {
                ManagerId = 1,
                WorkDays = WorkDays.Monday,
                WorkShiftIds = null // Null list
            };

            var manager = new User
            {
                UserId = assignDto.ManagerId,
                Name = "Manager Name",
                Email = "manager@example.com",
                WorkDays = assignDto.WorkDays,
                MangerWorkShifts = new List<WorkShift>() // Empty list
            };

            this.mockScheduleService
                .Setup(s => s.AssignManagerToWorkShiftsAsync(
                    assignDto.ManagerId,
                    assignDto.WorkDays,
                    It.IsAny<List<int>>())) // Should pass an empty list
                .ReturnsAsync(manager);

            this.mockNotificationService
                .Setup(n => n.NotifyUserAsync(
                    assignDto.ManagerId,
                    "ScheduleUpdate",
                    "Lịch làm việc của bạn đã được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "ScheduleUpdate",
                    "Lịch trình của Quản lý được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminScheduleController.AssignManagerWorkDaysAndShifts(assignDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<ManagerDto>>(okResult.Value);

            Assert.True(apiResponse.Success);

            this.mockScheduleService.Verify(s => s.AssignManagerToWorkShiftsAsync(
                assignDto.ManagerId,
                assignDto.WorkDays,
                It.Is<List<int>>(list => list != null && list.Count == 0)), Times.Once);
        }

        [Fact]
        public async Task AssignManagerWorkDaysAndShifts_ReturnsBadRequest_WhenRequestIsNull()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            AssignManagerWorkDaysAndShiftsDto assignDto = null;

            // Act
            var result = await adminScheduleController.AssignManagerWorkDaysAndShifts(assignDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<ManagerDto>>(badRequestResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal("Manager ID is required", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.AssignManagerToWorkShiftsAsync(
                It.IsAny<int>(),
                It.IsAny<WorkDays>(),
                It.IsAny<List<int>>()), Times.Never);
        }

        [Fact]
        public async Task AssignManagerWorkDaysAndShifts_ReturnsBadRequest_WhenManagerIdIsInvalid()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            var assignDto = new AssignManagerWorkDaysAndShiftsDto
            {
                ManagerId = 0, // Invalid ID
                WorkDays = WorkDays.Monday,
                WorkShiftIds = new List<int> { 1, 2 }
            };

            // Act
            var result = await adminScheduleController.AssignManagerWorkDaysAndShifts(assignDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<ManagerDto>>(badRequestResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal("Manager ID is required", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.AssignManagerToWorkShiftsAsync(
                It.IsAny<int>(),
                It.IsAny<WorkDays>(),
                It.IsAny<List<int>>()), Times.Never);
        }

        [Fact]
        public async Task AssignManagerWorkDaysAndShifts_ReturnsNotFound_WhenManagerDoesNotExist()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            var assignDto = new AssignManagerWorkDaysAndShiftsDto
            {
                ManagerId = 999,
                WorkDays = WorkDays.Monday,
                WorkShiftIds = new List<int> { 1, 2 }
            };

            this.mockScheduleService
                .Setup(s => s.AssignManagerToWorkShiftsAsync(
                    assignDto.ManagerId,
                    assignDto.WorkDays,
                    assignDto.WorkShiftIds))
                .ThrowsAsync(new KeyNotFoundException($"Manager with ID {assignDto.ManagerId} not found"));

            // Act
            var result = await adminScheduleController.AssignManagerWorkDaysAndShifts(assignDto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<ManagerDto>>(notFoundResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal($"Manager with ID {assignDto.ManagerId} not found", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.AssignManagerToWorkShiftsAsync(
                assignDto.ManagerId,
                assignDto.WorkDays,
                assignDto.WorkShiftIds), Times.Once);
        }

        [Fact]
        public async Task AssignManagerWorkDaysAndShifts_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            var assignDto = new AssignManagerWorkDaysAndShiftsDto
            {
                ManagerId = 1,
                WorkDays = WorkDays.Monday,
                WorkShiftIds = new List<int> { 1, 2 }
            };

            this.mockScheduleService
                .Setup(s => s.AssignManagerToWorkShiftsAsync(
                    assignDto.ManagerId,
                    assignDto.WorkDays,
                    assignDto.WorkShiftIds))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminScheduleController.AssignManagerWorkDaysAndShifts(assignDto);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<ManagerDto>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("An error occurred while assigning manager work days and shifts. Please try again later.", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.AssignManagerToWorkShiftsAsync(
    assignDto.ManagerId,
    assignDto.WorkDays,
    assignDto.WorkShiftIds), Times.Once);
        }

        #endregion

        #region Helper Method Tests

        [Fact]
        public void GetWorkDaysText_ReturnsCorrectText_ForSingleDay()
        {
            // Arrange
            var controller = this.CreateAdminScheduleController();
            var workDays = WorkDays.Monday;

            // Use reflection to access the private method
            var methodInfo = typeof(AdminScheduleController).GetMethod("GetWorkDaysText",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Act
            var result = methodInfo.Invoke(controller, new object[] { workDays }) as string;

            // Assert
            Assert.Equal("Monday", result);
        }

        [Fact]
        public void GetWorkDaysText_ReturnsCorrectText_ForMultipleDays()
        {
            // Arrange
            var controller = this.CreateAdminScheduleController();
            var workDays = WorkDays.Monday | WorkDays.Wednesday | WorkDays.Friday;

            // Use reflection to access the private method
            var methodInfo = typeof(AdminScheduleController).GetMethod("GetWorkDaysText",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Act
            var result = methodInfo.Invoke(controller, new object[] { workDays }) as string;

            // Assert
            Assert.Equal("Monday, Wednesday, Friday", result);
        }

        [Fact]
        public void GetWorkDaysText_ReturnsCorrectText_ForAllDays()
        {
            // Arrange
            var controller = this.CreateAdminScheduleController();
            var workDays = WorkDays.Monday | WorkDays.Tuesday | WorkDays.Wednesday |
                           WorkDays.Thursday | WorkDays.Friday | WorkDays.Saturday | WorkDays.Sunday;

            // Use reflection to access the private method
            var methodInfo = typeof(AdminScheduleController).GetMethod("GetWorkDaysText",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Act
            var result = methodInfo.Invoke(controller, new object[] { workDays }) as string;

            // Assert
            Assert.Equal("Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday", result);
        }

        [Fact]
        public void GetWorkDaysText_ReturnsCorrectText_ForNoDays()
        {
            // Arrange
            var controller = this.CreateAdminScheduleController();
            var workDays = WorkDays.None;

            // Use reflection to access the private method
            var methodInfo = typeof(AdminScheduleController).GetMethod("GetWorkDaysText",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Act
            var result = methodInfo.Invoke(controller, new object[] { workDays }) as string;

            // Assert
            Assert.Equal("No days assigned", result);
        }

        #endregion

        #region Edge Cases and Additional Tests

        [Fact]
        public async Task UpdateWorkShift_HandlesEmptyStaffList()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;
            var updateDto = new UpdateWorkShiftDto
            {
                ShiftName = "Updated Shift",
                ShiftStartTime = new TimeSpan(10, 0, 0),
                ShiftEndTime = new TimeSpan(18, 0, 0)
            };

            var updatedWorkShift = new WorkShift
            {
                WorkShiftId = shiftId,
                ShiftName = updateDto.ShiftName,
                ShiftStartTime = updateDto.ShiftStartTime,
                ShiftEndTime = updateDto.ShiftEndTime,
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            var shiftWithEmptyStaff = new WorkShift
            {
                WorkShiftId = shiftId,
                ShiftName = updateDto.ShiftName,
                ShiftStartTime = updateDto.ShiftStartTime,
                ShiftEndTime = updateDto.ShiftEndTime,
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddHours(7),
                Staff = new List<User>() // Empty staff list
            };

            this.mockScheduleService
                .Setup(s => s.UpdateWorkShiftAsync(
                    shiftId,
                    updateDto.ShiftStartTime,
                    updateDto.ShiftEndTime,
                    updateDto.ShiftName))
                .ReturnsAsync(updatedWorkShift);

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ReturnsAsync(shiftWithEmptyStaff);

            // Setup notification for managers
            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "ScheduleUpdate",
                    "Cập nhật ca làm việc",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminScheduleController.UpdateWorkShift(shiftId, updateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<WorkShiftDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Work shift updated successfully", apiResponse.Message);

            // Verify no staff notifications were sent
            this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);

            // Verify notification to managers was sent
            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                "Managers",
                "ScheduleUpdate",
                "Cập nhật ca làm việc",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);
        }


        [Fact]
        public async Task UpdateWorkShift_HandlesNullStaffList()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;
            var updateDto = new UpdateWorkShiftDto
            {
                ShiftName = "Updated Shift",
                ShiftStartTime = new TimeSpan(10, 0, 0),
                ShiftEndTime = new TimeSpan(18, 0, 0)
            };

            var updatedWorkShift = new WorkShift
            {
                WorkShiftId = shiftId,
                ShiftName = updateDto.ShiftName,
                ShiftStartTime = updateDto.ShiftStartTime,
                ShiftEndTime = updateDto.ShiftEndTime,
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddHours(7)
            };

            var shiftWithNullStaff = new WorkShift
            {
                WorkShiftId = shiftId,
                ShiftName = updateDto.ShiftName,
                ShiftStartTime = updateDto.ShiftStartTime,
                ShiftEndTime = updateDto.ShiftEndTime,
                CreatedAt = DateTime.UtcNow.AddDays(-10),
                UpdatedAt = DateTime.UtcNow.AddHours(7),
                Staff = null // Null staff list
            };

            this.mockScheduleService
                .Setup(s => s.UpdateWorkShiftAsync(
                    shiftId,
                    updateDto.ShiftStartTime,
                    updateDto.ShiftEndTime,
                    updateDto.ShiftName))
                .ReturnsAsync(updatedWorkShift);

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ReturnsAsync(shiftWithNullStaff);

            // Setup notification for managers
            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "ScheduleUpdate",
                    "Cập nhật ca làm việc",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminScheduleController.UpdateWorkShift(shiftId, updateDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<WorkShiftDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Work shift updated successfully", apiResponse.Message);

            // Verify no staff notifications were sent
            this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);

            // Verify notification to managers was sent
            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                "Managers",
                "ScheduleUpdate",
                "Cập nhật ca làm việc",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);
        }


        [Fact]
        public async Task DeleteWorkShift_HandlesNullStaffList()
        {
            // Arrange
            var adminScheduleController = this.CreateAdminScheduleController();
            int shiftId = 1;

            var workShift = new WorkShift
            {
                WorkShiftId = shiftId,
                ShiftName = "Morning Shift",
                ShiftStartTime = new TimeSpan(8, 0, 0),
                ShiftEndTime = new TimeSpan(16, 0, 0),
                Staff = null // Null staff list
            };

            this.mockScheduleService
                .Setup(s => s.GetWorkShiftByIdAsync(shiftId))
                .ReturnsAsync(workShift);

            this.mockScheduleService
                .Setup(s => s.DeleteWorkShiftAsync(shiftId))
                .ReturnsAsync(true);

            // Setup notification for managers
            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "ScheduleUpdate",
                    "Đã xóa ca làm việc",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminScheduleController.DeleteWorkShift(shiftId);

            // Assert
            Assert.IsType<NoContentResult>(result);

            // Verify no staff notifications were sent
            this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);

            // Verify notification to managers was sent
            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                "Managers",
                "ScheduleUpdate",
                "Đã xóa ca làm việc",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);
        }


        #endregion
    }
}