using Capstone.HPTY.API.Controllers.Schedule;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Capstone.HPTY.ServiceLayer.Interfaces.Notification;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Schedule
{
    public class ManagerScheduleControllerTests
    {
        private readonly MockRepository mockRepository;
        private readonly Mock<IScheduleService> mockScheduleService;
        private readonly Mock<IManagerService> mockManagerService;
        private readonly Mock<IStaffService> mockStaffService;
        private readonly Mock<INotificationService> mockNotificationService;

        public ManagerScheduleControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockScheduleService = this.mockRepository.Create<IScheduleService>();
            this.mockManagerService = this.mockRepository.Create<IManagerService>();
            this.mockStaffService = this.mockRepository.Create<IStaffService>();
            this.mockNotificationService = this.mockRepository.Create<INotificationService>();
        }

        private ManagerScheduleController CreateManagerScheduleController()
        {
            var controller = new ManagerScheduleController(
                this.mockScheduleService.Object,
                this.mockManagerService.Object,
                this.mockStaffService.Object,
                this.mockNotificationService.Object);

            return controller;
        }

        private void SetupControllerWithUserClaims(ManagerScheduleController controller, int userId)
        {
            var claims = new List<Claim>
            {
                new Claim("id", userId.ToString()),
                new Claim(ClaimTypes.Role, "Manager")
            };

            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };
        }

        #region GetMySchedule Tests

        [Fact]
        public async Task GetMySchedule_ReturnsOkResult_WithSchedule_WhenUserHasShifts()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            int managerId = 1;

            // Setup user claims
            SetupControllerWithUserClaims(controller, managerId);

            var workShifts = new List<WorkShift>
            {
                new WorkShift
                {
                    WorkShiftId = 1,
                    ShiftName = "Morning Shift",
                    ShiftStartTime = new TimeSpan(8, 0, 0),
                    ShiftEndTime = new TimeSpan(16, 0, 0),
                    Managers = new List<User>
                    {
                        new User
                        {
                            UserId = managerId,
                            Name = "Manager Name",
                            Email = "manager@example.com"
                        }
                    }
                },
                new WorkShift
                {
                    WorkShiftId = 2,
                    ShiftName = "Evening Shift",
                    ShiftStartTime = new TimeSpan(16, 0, 0),
                    ShiftEndTime = new TimeSpan(0, 0, 0),
                    Managers = new List<User>
                    {
                        new User
                        {
                            UserId = managerId,
                            Name = "Manager Name",
                            Email = "manager@example.com"
                        }
                    }
                }
            };

            var manager = new User
            {
                UserId = managerId,
                Name = "Manager Name",
                Email = "manager@example.com",
                WorkDays = WorkDays.Monday | WorkDays.Wednesday | WorkDays.Friday
            };

            this.mockScheduleService
                .Setup(s => s.GetManagerWorkShiftsAsync(managerId))
                .ReturnsAsync(workShifts);

            this.mockManagerService
                .Setup(s => s.GetManagerByIdAsync(managerId))
                .ReturnsAsync(manager);

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedShifts = Assert.IsType<List<ManagerWorkShiftDto>>(okResult.Value);

            Assert.Equal(2, returnedShifts.Count);

            // Check first shift
            Assert.Equal(1, returnedShifts[0].WorkShiftId);
            Assert.Equal("Morning Shift", returnedShifts[0].ShiftName);
            Assert.Equal(new TimeSpan(8, 0, 0), returnedShifts[0].ShiftStartTime);
            Assert.Equal(new TimeSpan(16, 0, 0), returnedShifts[0].ShiftEndTime);
            Assert.Equal(WorkDays.Monday | WorkDays.Wednesday | WorkDays.Friday, returnedShifts[0].DaysOfWeek);
            Assert.Single(returnedShifts[0].Managers);
            Assert.Equal(managerId, returnedShifts[0].Managers[0].UserId);

            // Check second shift
            Assert.Equal(2, returnedShifts[1].WorkShiftId);
            Assert.Equal("Evening Shift", returnedShifts[1].ShiftName);
            Assert.Equal(new TimeSpan(16, 0, 0), returnedShifts[1].ShiftStartTime);
            Assert.Equal(new TimeSpan(0, 0, 0), returnedShifts[1].ShiftEndTime);
            Assert.Equal(WorkDays.Monday | WorkDays.Wednesday | WorkDays.Friday, returnedShifts[1].DaysOfWeek);
            Assert.Single(returnedShifts[1].Managers);
            Assert.Equal(managerId, returnedShifts[1].Managers[0].UserId);

            this.mockScheduleService.Verify(s => s.GetManagerWorkShiftsAsync(managerId), Times.Once);
            this.mockManagerService.Verify(s => s.GetManagerByIdAsync(managerId), Times.Once);
        }

        [Fact]
        public async Task GetMySchedule_ReturnsOkResult_WithEmptyList_WhenUserHasNoShifts()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            int managerId = 1;

            // Setup user claims
            SetupControllerWithUserClaims(controller, managerId);

            var emptyShiftList = new List<WorkShift>();

            this.mockScheduleService
                .Setup(s => s.GetManagerWorkShiftsAsync(managerId))
                .ReturnsAsync(emptyShiftList);

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedShifts = Assert.IsType<List<ManagerWorkShiftDto>>(okResult.Value);

            Assert.Empty(returnedShifts);

            this.mockScheduleService.Verify(s => s.GetManagerWorkShiftsAsync(managerId), Times.Once);
            this.mockManagerService.Verify(s => s.GetManagerByIdAsync(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task GetMySchedule_ReturnsUnauthorized_WhenUserIdClaimIsMissing()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();

            // Setup controller with no user claims
            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = new ClaimsPrincipal(new ClaimsIdentity()) }
            };

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result.Result);
            Assert.Equal("User ID not found in claims", unauthorizedResult.Value);

            this.mockScheduleService.Verify(s => s.GetManagerWorkShiftsAsync(It.IsAny<int>()), Times.Never);
            this.mockManagerService.Verify(s => s.GetManagerByIdAsync(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task GetMySchedule_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            int managerId = 1;

            // Setup user claims
            SetupControllerWithUserClaims(controller, managerId);

            this.mockScheduleService
                .Setup(s => s.GetManagerWorkShiftsAsync(managerId))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("Internal server error", statusCodeResult.Value.ToString());

            this.mockScheduleService.Verify(s => s.GetManagerWorkShiftsAsync(managerId), Times.Once);
            this.mockManagerService.Verify(s => s.GetManagerByIdAsync(It.IsAny<int>()), Times.Never);
        }

        #endregion

        #region GetAllStaffSchedules Tests

        [Fact]
        public async Task GetAllStaffSchedules_ReturnsOkResult_WithStaffSchedules()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();

            var staffMembers = new List<User>
            {
                new User
                {
                    UserId = 101,
                    Name = "Staff 1",
                    Email = "staff1@example.com",
                    WorkDays = WorkDays.Monday | WorkDays.Tuesday
                },
                new User
                {
                    UserId = 102,
                    Name = "Staff 2",
                    Email = "staff2@example.com",
                    WorkDays = WorkDays.Wednesday | WorkDays.Thursday
                }
            };

            this.mockStaffService
                .Setup(s => s.GetAllStaffAsync())
                .ReturnsAsync(staffMembers);

            // Setup for each staff member's shifts
            foreach (var staff in staffMembers)
            {
                this.mockScheduleService
                    .Setup(s => s.GetStaffWorkShiftsAsync(staff.UserId))
                    .ReturnsAsync(new List<WorkShift>());
            }

            // Act
            var result = await controller.GetAllStaffSchedules();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffSchedules = Assert.IsType<List<StaffScheduleDto>>(okResult.Value);

            Assert.Equal(2, staffSchedules.Count);

            // Check first staff
            Assert.Equal(101, staffSchedules[0].Staff.UserId);
            Assert.Equal("Staff 1", staffSchedules[0].Staff.Name);
            Assert.Equal("staff1@example.com", staffSchedules[0].Staff.Email);
            Assert.Equal(WorkDays.Monday | WorkDays.Tuesday, staffSchedules[0].Staff.DaysOfWeek);

            // Check second staff
            Assert.Equal(102, staffSchedules[1].Staff.UserId);
            Assert.Equal("Staff 2", staffSchedules[1].Staff.Name);
            Assert.Equal("staff2@example.com", staffSchedules[1].Staff.Email);
            Assert.Equal(WorkDays.Wednesday | WorkDays.Thursday, staffSchedules[1].Staff.DaysOfWeek);

            this.mockStaffService.Verify(s => s.GetAllStaffAsync(), Times.Once);

            // Verify each staff member's shifts were retrieved
            foreach (var staff in staffMembers)
            {
                this.mockScheduleService.Verify(s => s.GetStaffWorkShiftsAsync(staff.UserId), Times.Once);
            }
        }

        [Fact]
        public async Task GetAllStaffSchedules_ReturnsOkResult_WithEmptyList_WhenNoStaffMembers()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();

            var emptyStaffList = new List<User>();

            this.mockStaffService
                .Setup(s => s.GetAllStaffAsync())
                .ReturnsAsync(emptyStaffList);

            // Act
            var result = await controller.GetAllStaffSchedules();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffSchedules = Assert.IsType<List<StaffScheduleDto>>(okResult.Value);

            Assert.Empty(staffSchedules);

            this.mockStaffService.Verify(s => s.GetAllStaffAsync(), Times.Once);
            this.mockScheduleService.Verify(s => s.GetStaffWorkShiftsAsync(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task GetAllStaffSchedules_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();

            this.mockStaffService
                .Setup(s => s.GetAllStaffAsync())
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.GetAllStaffSchedules();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("Internal server error", statusCodeResult.Value.ToString());

            this.mockStaffService.Verify(s => s.GetAllStaffAsync(), Times.Once);
            this.mockScheduleService.Verify(s => s.GetStaffWorkShiftsAsync(It.IsAny<int>()), Times.Never);
        }

        #endregion

        #region GetStaffSchedule Tests

        [Fact]
        public async Task GetStaffSchedule_ReturnsOkResult_WhenStaffExists()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            int staffId = 101;

            var staff = new User
            {
                UserId = staffId,
                Name = "Staff Name",
                Email = "staff@example.com",
                WorkDays = WorkDays.Monday | WorkDays.Wednesday
            };

            var staffShifts = new List<WorkShift>
            {
                new WorkShift
                {
                    WorkShiftId = 1,
                    ShiftName = "Morning Shift",
                    ShiftStartTime = new TimeSpan(8, 0, 0),
                                      ShiftEndTime = new TimeSpan(16, 0, 0)
                }
            };

            this.mockStaffService
                .Setup(s => s.GetStaffByIdAsync(staffId))
                .ReturnsAsync(staff);

            this.mockScheduleService
                .Setup(s => s.GetStaffWorkShiftsAsync(staffId))
                .ReturnsAsync(staffShifts);

            // Act
            var result = await controller.GetStaffSchedule(staffId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffSchedule = Assert.IsType<StaffScheduleDto>(okResult.Value);

            Assert.NotNull(staffSchedule.Staff);
            Assert.Equal(staffId, staffSchedule.Staff.UserId);
            Assert.Equal("Staff Name", staffSchedule.Staff.Name);
            Assert.Equal("staff@example.com", staffSchedule.Staff.Email);
            Assert.Equal(WorkDays.Monday | WorkDays.Wednesday, staffSchedule.Staff.DaysOfWeek);

            this.mockStaffService.Verify(s => s.GetStaffByIdAsync(staffId), Times.Once);
            this.mockScheduleService.Verify(s => s.GetStaffWorkShiftsAsync(staffId), Times.Once);
        }

        [Fact]
        public async Task GetStaffSchedule_ReturnsNotFound_WhenStaffDoesNotExist()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            int staffId = 999;

            this.mockStaffService
                .Setup(s => s.GetStaffByIdAsync(staffId))
                .ReturnsAsync((User)null);

            // Act
            var result = await controller.GetStaffSchedule(staffId);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"Staff with ID {staffId} not found", notFoundResult.Value);

            this.mockStaffService.Verify(s => s.GetStaffByIdAsync(staffId), Times.Once);
            this.mockScheduleService.Verify(s => s.GetStaffWorkShiftsAsync(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task GetStaffSchedule_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            int staffId = 101;

            this.mockStaffService
                .Setup(s => s.GetStaffByIdAsync(staffId))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.GetStaffSchedule(staffId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("Internal server error", statusCodeResult.Value.ToString());

            this.mockStaffService.Verify(s => s.GetStaffByIdAsync(staffId), Times.Once);
            this.mockScheduleService.Verify(s => s.GetStaffWorkShiftsAsync(It.IsAny<int>()), Times.Never);
        }

        #endregion

        #region GetStaffByDay Tests

        [Fact]
        public async Task GetStaffByDay_ReturnsOkResult_WithFilteredStaff_WhenDayIsSpecified()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            WorkDays day = WorkDays.Monday;

            var allStaff = new List<User>
            {
                new User
                {
                    UserId = 101,
                    Name = "Staff 1",
                    Email = "staff1@example.com",
                    WorkDays = WorkDays.Monday | WorkDays.Tuesday // Works on Monday
                },
                new User
                {
                    UserId = 102,
                    Name = "Staff 2",
                    Email = "staff2@example.com",
                    WorkDays = WorkDays.Wednesday | WorkDays.Thursday // Doesn't work on Monday
                },
                new User
                {
                    UserId = 103,
                    Name = "Staff 3",
                    Email = "staff3@example.com",
                    WorkDays = WorkDays.Monday | WorkDays.Friday // Works on Monday
                }
            };

            this.mockStaffService
                .Setup(s => s.GetAllStaffAsync())
                .ReturnsAsync(allStaff);

            // Act
            var result = await controller.GetStaffByDay(day);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffList = Assert.IsType<List<StaffSDto>>(okResult.Value);

            Assert.Equal(2, staffList.Count); // Only 2 staff work on Monday

            // Check that all returned staff work on Monday
            Assert.All(staffList, staff => Assert.True((staff.DaysOfWeek & WorkDays.Monday) != 0));

            // Check first staff
            Assert.Equal(101, staffList[0].UserId);
            Assert.Equal("Staff 1", staffList[0].Name);

            // Check second staff
            Assert.Equal(103, staffList[1].UserId);
            Assert.Equal("Staff 3", staffList[1].Name);

            this.mockStaffService.Verify(s => s.GetAllStaffAsync(), Times.Once);
        }

        [Fact]
        public async Task GetStaffByDay_ReturnsOkResult_WithAllStaff_WhenDayIsNone()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            WorkDays day = WorkDays.None;

            var allStaff = new List<User>
            {
                new User
                {
                    UserId = 101,
                    Name = "Staff 1",
                    Email = "staff1@example.com",
                    WorkDays = WorkDays.Monday | WorkDays.Tuesday
                },
                new User
                {
                    UserId = 102,
                    Name = "Staff 2",
                    Email = "staff2@example.com",
                    WorkDays = WorkDays.Wednesday | WorkDays.Thursday
                }
            };

            this.mockStaffService
                .Setup(s => s.GetAllStaffAsync())
                .ReturnsAsync(allStaff);

            // Act
            var result = await controller.GetStaffByDay(day);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffList = Assert.IsType<List<StaffSDto>>(okResult.Value);

            Assert.Equal(2, staffList.Count); // All staff returned

            // Check first staff
            Assert.Equal(101, staffList[0].UserId);
            Assert.Equal("Staff 1", staffList[0].Name);

            // Check second staff
            Assert.Equal(102, staffList[1].UserId);
            Assert.Equal("Staff 2", staffList[1].Name);

            this.mockStaffService.Verify(s => s.GetAllStaffAsync(), Times.Once);
        }

        [Fact]
        public async Task GetStaffByDay_HandlesNullWorkDays()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            WorkDays day = WorkDays.Monday;

            var allStaff = new List<User>
            {
                new User
                {
                    UserId = 101,
                    Name = "Staff 1",
                    Email = "staff1@example.com",
                    WorkDays = WorkDays.Monday | WorkDays.Tuesday // Works on Monday
                },
                new User
                {
                    UserId = 102,
                    Name = "Staff 2",
                    Email = "staff2@example.com",
                    WorkDays = null // Null WorkDays
                }
            };

            this.mockStaffService
                .Setup(s => s.GetAllStaffAsync())
                .ReturnsAsync(allStaff);

            // Act
            var result = await controller.GetStaffByDay(day);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffList = Assert.IsType<List<StaffSDto>>(okResult.Value);

            Assert.Single(staffList); // Only 1 staff works on Monday
            Assert.Equal(101, staffList[0].UserId); // Only Staff 1 should be returned

            this.mockStaffService.Verify(s => s.GetAllStaffAsync(), Times.Once);
        }

        [Fact]
        public async Task GetStaffByDay_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            WorkDays day = WorkDays.Monday;

            this.mockStaffService
                .Setup(s => s.GetAllStaffAsync())
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.GetStaffByDay(day);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("Internal server error", statusCodeResult.Value.ToString());

            this.mockStaffService.Verify(s => s.GetAllStaffAsync(), Times.Once);
        }

        #endregion

        #region AssignStaffWorkDays Tests

        [Fact]
        public async Task AssignStaffWorkDays_ReturnsOkResult_WhenRequestIsValid()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            var assignDto = new AssignStaffWorkDaysDto
            {
                StaffId = 101,
                WorkDays = WorkDays.Monday | WorkDays.Wednesday | WorkDays.Friday
            };

            var updatedStaff = new User
            {
                UserId = assignDto.StaffId,
                Name = "Staff Name",
                Email = "staff@example.com",
                WorkDays = assignDto.WorkDays
            };

            this.mockScheduleService
                .Setup(s => s.AssignStaffWorkDaysAsync(assignDto.StaffId, assignDto.WorkDays))
                .ReturnsAsync(updatedStaff);

            this.mockNotificationService
                .Setup(n => n.NotifyUserAsync(
                    assignDto.StaffId,
                    "Schedule",
                    "Lịch làm việc của bạn đã được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "Schedule",
                    "Lịch của nhân viên mới được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await controller.AssignStaffWorkDays(assignDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<StaffSDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal($"Work days assigned to {updatedStaff.Name} successfully", apiResponse.Message);

            var staffDto = apiResponse.Data;
            Assert.Equal(assignDto.StaffId, staffDto.UserId);
            Assert.Equal("Staff Name", staffDto.Name);
            Assert.Equal("staff@example.com", staffDto.Email);
            Assert.Equal(assignDto.WorkDays, staffDto.DaysOfWeek);

            this.mockScheduleService.Verify(s => s.AssignStaffWorkDaysAsync(
                assignDto.StaffId, assignDto.WorkDays), Times.Once);

            this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                assignDto.StaffId,
                "Schedule",
                "Lịch làm việc của bạn đã được cập nhật",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);

            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                "Managers",
                "Schedule",
                "Lịch của nhân viên mới được cập nhật",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);
        }

        [Fact]
        public async Task AssignStaffWorkDays_HandlesWorkDaysNone_WhenClearingSchedule()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            var assignDto = new AssignStaffWorkDaysDto
            {
                StaffId = 101,
                WorkDays = WorkDays.None // No work days
            };

            var updatedStaff = new User
            {
                UserId = assignDto.StaffId,
                Name = "Staff Name",
                Email = "staff@example.com",
                WorkDays = assignDto.WorkDays
            };

            this.mockScheduleService
                .Setup(s => s.AssignStaffWorkDaysAsync(assignDto.StaffId, assignDto.WorkDays))
                .ReturnsAsync(updatedStaff);

            this.mockNotificationService
                .Setup(n => n.NotifyUserAsync(
                    assignDto.StaffId,
                    "Schedule",
                    "Lịch làm việc của bạn đã được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "Schedule",
                    "Lịch của nhân viên mới được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await controller.AssignStaffWorkDays(assignDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<StaffSDto>>(okResult.Value);

            Assert.True(apiResponse.Success);

            var staffDto = apiResponse.Data;
            Assert.Equal(WorkDays.None, staffDto.DaysOfWeek);

            this.mockScheduleService.Verify(s => s.AssignStaffWorkDaysAsync(
                assignDto.StaffId, assignDto.WorkDays), Times.Once);
        }

        [Fact]
        public async Task AssignStaffWorkDays_ReturnsBadRequest_WhenRequestIsNull()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            AssignStaffWorkDaysDto assignDto = null;

            // Act
            var result = await controller.AssignStaffWorkDays(assignDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<StaffSDto>>(badRequestResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal("Staff ID is required", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.AssignStaffWorkDaysAsync(
                               It.IsAny<int>(), It.IsAny<WorkDays>()), Times.Never);

            this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);

            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);
        }

        [Fact]
        public async Task AssignStaffWorkDays_ReturnsBadRequest_WhenStaffIdIsInvalid()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            var assignDto = new AssignStaffWorkDaysDto
            {
                StaffId = 0, // Invalid ID
                WorkDays = WorkDays.Monday
            };

            // Act
            var result = await controller.AssignStaffWorkDays(assignDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<StaffSDto>>(badRequestResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal("Staff ID is required", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.AssignStaffWorkDaysAsync(
                It.IsAny<int>(), It.IsAny<WorkDays>()), Times.Never);

            this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);

            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);
        }

        [Fact]
        public async Task AssignStaffWorkDays_ReturnsNotFound_WhenStaffDoesNotExist()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            var assignDto = new AssignStaffWorkDaysDto
            {
                StaffId = 999,
                WorkDays = WorkDays.Monday
            };

            this.mockScheduleService
                .Setup(s => s.AssignStaffWorkDaysAsync(assignDto.StaffId, assignDto.WorkDays))
                .ThrowsAsync(new KeyNotFoundException($"Staff with ID {assignDto.StaffId} not found"));

            // Act
            var result = await controller.AssignStaffWorkDays(assignDto);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<StaffSDto>>(notFoundResult.Value);

            Assert.False(apiResponse.Success);
            Assert.Equal($"Staff with ID {assignDto.StaffId} not found", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.AssignStaffWorkDaysAsync(
                assignDto.StaffId, assignDto.WorkDays), Times.Once);

            this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);

            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);
        }

        [Fact]
        public async Task AssignStaffWorkDays_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            var assignDto = new AssignStaffWorkDaysDto
            {
                StaffId = 101,
                WorkDays = WorkDays.Monday
            };

            this.mockScheduleService
                .Setup(s => s.AssignStaffWorkDaysAsync(assignDto.StaffId, assignDto.WorkDays))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.AssignStaffWorkDays(assignDto);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);

            var apiResponse = Assert.IsType<ApiResponse<StaffSDto>>(statusCodeResult.Value);
            Assert.False(apiResponse.Success);
            Assert.Equal("Database connection error", apiResponse.Message);

            this.mockScheduleService.Verify(s => s.AssignStaffWorkDaysAsync(
                assignDto.StaffId, assignDto.WorkDays), Times.Once);

            this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                It.IsAny<int>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);

            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Never);
        }

        #endregion

        #region Helper Method Tests

        [Fact]
        public void GetWorkDaysText_ReturnsCorrectText_ForSingleDay()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            var workDays = WorkDays.Monday;

            // Use reflection to access the private method
            var methodInfo = typeof(ManagerScheduleController).GetMethod("GetWorkDaysText",
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
            var controller = this.CreateManagerScheduleController();
            var workDays = WorkDays.Monday | WorkDays.Wednesday | WorkDays.Friday;

            // Use reflection to access the private method
            var methodInfo = typeof(ManagerScheduleController).GetMethod("GetWorkDaysText",
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
            var controller = this.CreateManagerScheduleController();
            var workDays = WorkDays.Monday | WorkDays.Tuesday | WorkDays.Wednesday |
                           WorkDays.Thursday | WorkDays.Friday | WorkDays.Saturday | WorkDays.Sunday;

            // Use reflection to access the private method
            var methodInfo = typeof(ManagerScheduleController).GetMethod("GetWorkDaysText",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Act
            var result = methodInfo.Invoke(controller, new object[] { workDays }) as string;

            // Assert
            Assert.Equal("Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday", result);
        }

        [Fact]
        public void GetWorkDaysText_ReturnsCorrectText_ForNoDays()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            var workDays = WorkDays.None;

            // Use reflection to access the private method
            var methodInfo = typeof(ManagerScheduleController).GetMethod("GetWorkDaysText",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            // Act
            var result = methodInfo.Invoke(controller, new object[] { workDays }) as string;

            // Assert
            Assert.Equal("No days assigned", result);
        }

        #endregion

        #region Edge Cases and Additional Tests

        [Fact]
        public async Task GetMySchedule_HandlesNullManager()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            int managerId = 1;

            // Setup user claims
            SetupControllerWithUserClaims(controller, managerId);

            var workShifts = new List<WorkShift>
            {
                new WorkShift
                {
                    WorkShiftId = 1,
                    ShiftName = "Morning Shift",
                    ShiftStartTime = new TimeSpan(8, 0, 0),
                    ShiftEndTime = new TimeSpan(16, 0, 0),
                    Managers = new List<User>
                    {
                        new User
                        {
                            UserId = managerId,
                            Name = "Manager Name",
                            Email = "manager@example.com"
                        }
                    }
                }
            };

            this.mockScheduleService
                .Setup(s => s.GetManagerWorkShiftsAsync(managerId))
                .ReturnsAsync(workShifts);

            this.mockManagerService
                .Setup(s => s.GetManagerByIdAsync(managerId))
                .ReturnsAsync((User)null); // Manager not found

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedShifts = Assert.IsType<List<ManagerWorkShiftDto>>(okResult.Value);

            Assert.Single(returnedShifts);

            // Check that WorkDays is None when manager is null
            Assert.Equal(WorkDays.None, returnedShifts[0].DaysOfWeek);

            this.mockScheduleService.Verify(s => s.GetManagerWorkShiftsAsync(managerId), Times.Once);
            this.mockManagerService.Verify(s => s.GetManagerByIdAsync(managerId), Times.Once);
        }

        [Fact]
        public async Task GetMySchedule_HandlesNullManagersCollection()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            int managerId = 1;

            // Setup user claims
            SetupControllerWithUserClaims(controller, managerId);

            var workShifts = new List<WorkShift>
            {
                new WorkShift
                {
                    WorkShiftId = 1,
                    ShiftName = "Morning Shift",
                    ShiftStartTime = new TimeSpan(8, 0, 0),
                    ShiftEndTime = new TimeSpan(16, 0, 0),
                    Managers = null // Null managers collection
                }
            };

            var manager = new User
            {
                UserId = managerId,
                Name = "Manager Name",
                Email = "manager@example.com",
                WorkDays = WorkDays.Monday | WorkDays.Wednesday
            };

            this.mockScheduleService
                .Setup(s => s.GetManagerWorkShiftsAsync(managerId))
                .ReturnsAsync(workShifts);

            this.mockManagerService
                .Setup(s => s.GetManagerByIdAsync(managerId))
                .ReturnsAsync(manager);

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedShifts = Assert.IsType<List<ManagerWorkShiftDto>>(okResult.Value);

            Assert.Single(returnedShifts);

            // Check that Managers collection is empty but not null
            Assert.Empty(returnedShifts[0].Managers);

            this.mockScheduleService.Verify(s => s.GetManagerWorkShiftsAsync(managerId), Times.Once);
            this.mockManagerService.Verify(s => s.GetManagerByIdAsync(managerId), Times.Once);
        }

        [Fact]
        public async Task GetStaffByDay_HandlesEmptyStaffList()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            WorkDays day = WorkDays.Monday;

            var emptyStaffList = new List<User>();

            this.mockStaffService
                .Setup(s => s.GetAllStaffAsync())
                .ReturnsAsync(emptyStaffList);

            // Act
            var result = await controller.GetStaffByDay(day);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffList = Assert.IsType<List<StaffSDto>>(okResult.Value);

            Assert.Empty(staffList);

            this.mockStaffService.Verify(s => s.GetAllStaffAsync(), Times.Once);
        }

        [Fact]
        public async Task AssignStaffWorkDays_HandlesNullWorkDays()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            var assignDto = new AssignStaffWorkDaysDto
            {
                StaffId = 101,
                WorkDays = WorkDays.Monday
            };

            var updatedStaff = new User
            {
                UserId = assignDto.StaffId,
                Name = "Staff Name",
                Email = "staff@example.com",
                WorkDays = null // Null WorkDays
            };

            this.mockScheduleService
                .Setup(s => s.AssignStaffWorkDaysAsync(assignDto.StaffId, assignDto.WorkDays))
                .ReturnsAsync(updatedStaff);

            this.mockNotificationService
                .Setup(n => n.NotifyUserAsync(
                    assignDto.StaffId,
                    "Schedule",
                    "Lịch làm việc của bạn đã được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            this.mockNotificationService
                .Setup(n => n.NotifyRoleAsync(
                    "Managers",
                    "Schedule",
                    "Lịch của nhân viên mới được cập nhật",
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, object>>()))
                .Returns(Task.CompletedTask);

            // Act
            var result = await controller.AssignStaffWorkDays(assignDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<StaffSDto>>(okResult.Value);

            Assert.True(apiResponse.Success);

            var staffDto = apiResponse.Data;
            Assert.Equal(assignDto.StaffId, staffDto.UserId);
            Assert.Equal("Staff Name", staffDto.Name);
            Assert.Equal("staff@example.com", staffDto.Email);
            Assert.Equal(WorkDays.None, staffDto.DaysOfWeek); // Should default to None

            this.mockScheduleService.Verify(s => s.AssignStaffWorkDaysAsync(
                assignDto.StaffId, assignDto.WorkDays), Times.Once);

            this.mockNotificationService.Verify(n => n.NotifyUserAsync(
                assignDto.StaffId,
                "Schedule",
                "Lịch làm việc của bạn đã được cập nhật",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);

            this.mockNotificationService.Verify(n => n.NotifyRoleAsync(
                "Managers",
                "Schedule",
                "Lịch của nhân viên mới được cập nhật",
                It.IsAny<string>(),
                It.IsAny<Dictionary<string, object>>()), Times.Once);
        }

        [Fact]
        public async Task GetStaffSchedule_HandlesNullWorkDays()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            int staffId = 101;

            var staff = new User
            {
                UserId = staffId,
                Name = "Staff Name",
                Email = "staff@example.com",
                WorkDays = null // Null WorkDays
            };

            var staffShifts = new List<WorkShift>();

            this.mockStaffService
                .Setup(s => s.GetStaffByIdAsync(staffId))
                .ReturnsAsync(staff);

            this.mockScheduleService
                .Setup(s => s.GetStaffWorkShiftsAsync(staffId))
                .ReturnsAsync(staffShifts);

            // Act
            var result = await controller.GetStaffSchedule(staffId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffSchedule = Assert.IsType<StaffScheduleDto>(okResult.Value);

            Assert.NotNull(staffSchedule.Staff);
            Assert.Equal(staffId, staffSchedule.Staff.UserId);
            Assert.Equal("Staff Name", staffSchedule.Staff.Name);
            Assert.Equal("staff@example.com", staffSchedule.Staff.Email);
            Assert.Equal(WorkDays.None, staffSchedule.Staff.DaysOfWeek); // Should default to None

            this.mockStaffService.Verify(s => s.GetStaffByIdAsync(staffId), Times.Once);
            this.mockScheduleService.Verify(s => s.GetStaffWorkShiftsAsync(staffId), Times.Once);
        }

        [Fact]
        public async Task GetAllStaffSchedules_HandlesNullWorkDays()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();

            var staffMembers = new List<User>
            {
                new User
                {
                    UserId = 101,
                    Name = "Staff 1",
                    Email = "staff1@example.com",
                    WorkDays = WorkDays.Monday | WorkDays.Tuesday
                },
                new User
                {
                    UserId = 102,
                    Name = "Staff 2",
                    Email = "staff2@example.com",
                    WorkDays = null // Null WorkDays
                }
            };

            this.mockStaffService
                .Setup(s => s.GetAllStaffAsync())
                .ReturnsAsync(staffMembers);

            // Setup for each staff member's shifts
            foreach (var staff in staffMembers)
            {
                this.mockScheduleService
                    .Setup(s => s.GetStaffWorkShiftsAsync(staff.UserId))
                    .ReturnsAsync(new List<WorkShift>());
            }

            // Act
            var result = await controller.GetAllStaffSchedules();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffSchedules = Assert.IsType<List<StaffScheduleDto>>(okResult.Value);

            Assert.Equal(2, staffSchedules.Count);

            // Check first staff
            Assert.Equal(101, staffSchedules[0].Staff.UserId);
            Assert.Equal(WorkDays.Monday | WorkDays.Tuesday, staffSchedules[0].Staff.DaysOfWeek);

            // Check second staff
            Assert.Equal(102, staffSchedules[1].Staff.UserId);
            Assert.Equal(WorkDays.None, staffSchedules[1].Staff.DaysOfWeek); // Should default to None

            this.mockStaffService.Verify(s => s.GetAllStaffAsync(), Times.Once);

            // Verify each staff member's shifts were retrieved
            foreach (var staff in staffMembers)
            {
                this.mockScheduleService.Verify(s => s.GetStaffWorkShiftsAsync(staff.UserId), Times.Once);
            }
        }

        [Fact]
        public async Task GetMySchedule_HandlesNullShiftTimes()
        {
            // Arrange
            var controller = this.CreateManagerScheduleController();
            int managerId = 1;

            // Setup user claims
            SetupControllerWithUserClaims(controller, managerId);

            var workShifts = new List<WorkShift>
            {
                new WorkShift
                {
                    WorkShiftId = 1,
                    ShiftName = "Morning Shift",
                    ShiftStartTime = null, // Null start time
                    ShiftEndTime = null, // Null end time
                    Managers = new List<User>
                    {
                        new User
                        {
                            UserId = managerId,
                            Name = "Manager Name",
                            Email = "manager@example.com"
                        }
                    }
                }
            };

            var manager = new User
            {
                UserId = managerId,
                Name = "Manager Name",
                Email = "manager@example.com",
                WorkDays = WorkDays.Monday | WorkDays.Wednesday
            };

            this.mockScheduleService
                .Setup(s => s.GetManagerWorkShiftsAsync(managerId))
                .ReturnsAsync(workShifts);

            this.mockManagerService
                .Setup(s => s.GetManagerByIdAsync(managerId))
                .ReturnsAsync(manager);

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnedShifts = Assert.IsType<List<ManagerWorkShiftDto>>(okResult.Value);

            Assert.Single(returnedShifts);

            // Check that null times are converted to TimeSpan.Zero
            Assert.Equal(TimeSpan.Zero, returnedShifts[0].ShiftStartTime);
            Assert.Equal(TimeSpan.Zero, returnedShifts[0].ShiftEndTime);

            this.mockScheduleService.Verify(s => s.GetManagerWorkShiftsAsync(managerId), Times.Once);
            this.mockManagerService.Verify(s => s.GetManagerByIdAsync(managerId), Times.Once);
        }

        #endregion
    }
}