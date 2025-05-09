using Capstone.HPTY.API.Controllers.Schedule;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ScheduleService;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Schedule
{
    public class StaffScheduleControllerTests
    {
        private readonly MockRepository mockRepository;
        private readonly Mock<IScheduleService> mockScheduleService;
        private readonly Mock<IStaffService> mockStaffService;

        public StaffScheduleControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockScheduleService = this.mockRepository.Create<IScheduleService>();
            this.mockStaffService = this.mockRepository.Create<IStaffService>();
        }

        private StaffScheduleController CreateStaffScheduleController()
        {
            var controller = new StaffScheduleController(
                this.mockScheduleService.Object,
                this.mockStaffService.Object);

            return controller;
        }

        private void SetupControllerWithUserClaims(StaffScheduleController controller, int userId)
        {
            var claims = new List<Claim>
            {
                new Claim("id", userId.ToString()),
                new Claim(ClaimTypes.Role, "Staff")
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
        public async Task GetMySchedule_ReturnsOkResult_WithSchedule_WhenStaffExists()
        {
            // Arrange
            var controller = this.CreateStaffScheduleController();
            int staffId = 101;

            // Setup user claims
            SetupControllerWithUserClaims(controller, staffId);

            var staff = new User
            {
                UserId = staffId,
                Name = "Staff Name",
                Email = "staff@example.com",
                WorkDays = WorkDays.Monday | WorkDays.Wednesday | WorkDays.Friday
            };

            this.mockStaffService
                .Setup(s => s.GetStaffByIdAsync(staffId))
                .ReturnsAsync(staff);

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffSchedule = Assert.IsType<StaffScheduleDto>(okResult.Value);

            Assert.NotNull(staffSchedule.Staff);
            Assert.Equal(staffId, staffSchedule.Staff.UserId);
            Assert.Equal("Staff Name", staffSchedule.Staff.Name);
            Assert.Equal("staff@example.com", staffSchedule.Staff.Email);
            Assert.Equal(WorkDays.Monday | WorkDays.Wednesday | WorkDays.Friday, staffSchedule.Staff.DaysOfWeek);

            this.mockStaffService.Verify(s => s.GetStaffByIdAsync(staffId), Times.Once);
        }

        [Fact]
        public async Task GetMySchedule_ReturnsUnauthorized_WhenUserIdClaimIsMissing()
        {
            // Arrange
            var controller = this.CreateStaffScheduleController();

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

            this.mockStaffService.Verify(s => s.GetStaffByIdAsync(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public async Task GetMySchedule_ReturnsNotFound_WhenStaffDoesNotExist()
        {
            // Arrange
            var controller = this.CreateStaffScheduleController();
            int staffId = 999;

            // Setup user claims
            SetupControllerWithUserClaims(controller, staffId);

            this.mockStaffService
                .Setup(s => s.GetStaffByIdAsync(staffId))
                .ReturnsAsync((User)null);

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            Assert.Equal($"Staff record not found for user ID {staffId}", notFoundResult.Value);

            this.mockStaffService.Verify(s => s.GetStaffByIdAsync(staffId), Times.Once);
        }

        [Fact]
        public async Task GetMySchedule_HandlesNullWorkDays()
        {
            // Arrange
            var controller = this.CreateStaffScheduleController();
            int staffId = 101;

            // Setup user claims
            SetupControllerWithUserClaims(controller, staffId);

            var staff = new User
            {
                UserId = staffId,
                Name = "Staff Name",
                Email = "staff@example.com",
                WorkDays = null // Null WorkDays
            };

            this.mockStaffService
                .Setup(s => s.GetStaffByIdAsync(staffId))
                .ReturnsAsync(staff);

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var staffSchedule = Assert.IsType<StaffScheduleDto>(okResult.Value);

            Assert.NotNull(staffSchedule.Staff);
            Assert.Equal(staffId, staffSchedule.Staff.UserId);
            Assert.Equal("Staff Name", staffSchedule.Staff.Name);
            Assert.Equal("staff@example.com", staffSchedule.Staff.Email);
            Assert.Equal(WorkDays.None, staffSchedule.Staff.DaysOfWeek); // Should default to None

            this.mockStaffService.Verify(s => s.GetStaffByIdAsync(staffId), Times.Once);
        }

        [Fact]
        public async Task GetMySchedule_ReturnsServerError_WhenExceptionOccurs()
        {
            // Arrange
            var controller = this.CreateStaffScheduleController();
            int staffId = 101;

            // Setup user claims
            SetupControllerWithUserClaims(controller, staffId);

            this.mockStaffService
                .Setup(s => s.GetStaffByIdAsync(staffId))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("Internal server error", statusCodeResult.Value.ToString());

            this.mockStaffService.Verify(s => s.GetStaffByIdAsync(staffId), Times.Once);
        }

        [Fact]
        public async Task GetMySchedule_HandlesInvalidUserIdClaim()
        {
            // Arrange
            var controller = this.CreateStaffScheduleController();

            // Setup user claims with non-numeric ID
            var claims = new List<Claim>
            {
                new Claim("id", "not-a-number"),
                new Claim(ClaimTypes.Role, "Staff")
            };

            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };

            // Act
            var result = await controller.GetMySchedule();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            Assert.Contains("Internal server error", statusCodeResult.Value.ToString());

            this.mockStaffService.Verify(s => s.GetStaffByIdAsync(It.IsAny<int>()), Times.Never);
        }

        #endregion
    }
}