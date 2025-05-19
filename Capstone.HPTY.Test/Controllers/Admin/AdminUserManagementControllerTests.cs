using Capstone.HPTY.API.Controllers.Admin;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.DTOs.Auth;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
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
    public class AdminUserManagementControllerTests
    {
        private MockRepository mockRepository;
        private Mock<IUserService> mockUserService;
        private Mock<ILogger<AdminUserManagementController>> mockLogger;

        public AdminUserManagementControllerTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            this.mockUserService = this.mockRepository.Create<IUserService>();

            // Create logger with loose behavior to avoid having to set up every log call
            this.mockLogger = new Mock<ILogger<AdminUserManagementController>>(MockBehavior.Loose);
        }

        private AdminUserManagementController CreateAdminUserManagementController()
        {
            return new AdminUserManagementController(
                this.mockUserService.Object,
                this.mockLogger.Object);
        }

        #region GetUsers Tests

        [Fact]
        public async Task GetUsers_ReturnsPagedResult_WhenParametersAreValid()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            string searchTerm = "test";
            string rolename = "Admin";
            bool isActive = true;
            DateTime createdAfter = DateTime.UtcNow.AddDays(-30);
            DateTime createdBefore = DateTime.UtcNow;
            int pageNumber = 1;
            int pageSize = 10;
            string sortBy = "Name";
            bool ascending = true;

            var role = new Role { RoleId = 1, Name = rolename };

            var users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    Name = "Test User",
                    Email = "test@example.com",
                    PhoneNumber = "1234567890",
                    Address = "123 Test St",
                    Role = role,
                    ImageURL = "test.jpg",
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5)
                }
            };

            var pagedResult = new PagedResult<User>
            {
                Items = users,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockUserService.Setup(s => s.GetByRoleNameAsync(rolename))
                .ReturnsAsync(role);

            mockUserService.Setup(s => s.GetUsersAsync(
                searchTerm, role.RoleId, isActive, createdAfter, createdBefore,
                pageNumber, pageSize, sortBy, ascending))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminUserManagementController.GetUsers(
                searchTerm,
                rolename,
                isActive,
                createdAfter,
                createdBefore,
                pageNumber,
                pageSize,
                sortBy,
                ascending);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<UserDto>>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Lấy danh sách người dùng thành công", apiResponse.Message);

            var returnedPagedResult = apiResponse.Data;
            Assert.Equal(1, returnedPagedResult.TotalCount);
            Assert.Equal(pageNumber, returnedPagedResult.PageNumber);
            Assert.Equal(pageSize, returnedPagedResult.PageSize);

            var items = returnedPagedResult.Items.ToList();
            Assert.Single(items);
            Assert.Equal(1, items[0].UserId);
            Assert.Equal("Test User", items[0].Name);
            Assert.Equal("test@example.com", items[0].Email);
            Assert.Equal("Admin", items[0].RoleName);

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task GetUsers_ReturnsBadRequest_WhenPaginationParametersAreInvalid()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int pageNumber = 0; // Invalid
            int pageSize = 0;   // Invalid

            // Act
            var result = await adminUserManagementController.GetUsers(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("Số trang và size trang phải lớn hơn 0", apiErrorResponse.Message);

            // No service calls should be made
            mockUserService.Verify(s => s.GetUsersAsync(
                It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<bool?>(),
                It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>()),
                Times.Never);
        }

        [Fact]
        public async Task GetUsers_ReturnsBadRequest_WhenRoleNameIsInvalid()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            string rolename = "NonExistentRole";
            int pageNumber = 1;
            int pageSize = 10;

            mockUserService.Setup(s => s.GetByRoleNameAsync(rolename))
                .ReturnsAsync((Role)null);

            // Act
            var result = await adminUserManagementController.GetUsers(
                null, rolename, null, null, null,
                pageNumber, pageSize, "Name", true);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal($"Không thấy vai trò '{rolename}'", apiErrorResponse.Message);

            // Verify service calls
            mockUserService.Verify(s => s.GetByRoleNameAsync(rolename), Times.Once);
            mockUserService.Verify(s => s.GetUsersAsync(
                It.IsAny<string>(), It.IsAny<int?>(), It.IsAny<bool?>(),
                It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<bool>()),
                Times.Never);
        }

        [Fact]
        public async Task GetUsers_ReturnsBadRequest_WhenExceptionOccurs()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int pageNumber = 1;
            int pageSize = 10;

            mockUserService.Setup(s => s.GetUsersAsync(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await adminUserManagementController.GetUsers(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("Danh sách gặp trục trặc", apiErrorResponse.Message);

            // Verify service calls
            mockUserService.Verify();
        }

        #endregion

        #region GetUser Tests

        [Fact]
        public async Task GetUser_ReturnsUser_WhenUserExists()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int id = 1;

            var role = new Role { RoleId = 1, Name = "Admin" };
            var user = new User
            {
                UserId = id,
                Name = "Test User",
                Email = "test@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Test St",
                Role = role,
                ImageURL = "test.jpg",
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockUserService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(user);

            // Act
            var result = await adminUserManagementController.GetUser(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UserDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Lấy người dùng thành công", apiResponse.Message);

            var userDto = apiResponse.Data;
            Assert.Equal(id, userDto.UserId);
            Assert.Equal("Test User", userDto.Name);
            Assert.Equal("test@example.com", userDto.Email);
            Assert.Equal("Admin", userDto.RoleName);

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task GetUser_ReturnsNull_WhenUserDoesNotExist()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int id = 999;

            mockUserService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync((User)null);

            // Act
            var result = await adminUserManagementController.GetUser(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UserDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Lấy người dùng thành công", apiResponse.Message);
            Assert.Null(apiResponse.Data);

            // Verify service calls
            mockUserService.Verify();
        }

        #endregion

        #region CreateUser Tests

        [Fact]
        public async Task CreateUser_ReturnsCreatedUser_WhenRequestIsValid()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            var request = new CreateUserRequest
            {
                Name = "New User",
                Email = "new@example.com",
                Password = "password123",
                PhoneNumber = "9876543210",
                RoleName = "Customer"
            };

            var role = new Role { RoleId = 2, Name = "Customer" };
            var createdUser = new User
            {
                UserId = 2,
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Role = role,
                CreatedAt = DateTime.UtcNow.AddHours(7),
                UpdatedAt = DateTime.UtcNow
            };

            mockUserService.Setup(s => s.GetByRoleNameAsync(request.RoleName))
                .ReturnsAsync(role);

            mockUserService.Setup(s => s.CreateAsync(It.IsAny<User>()))
                .ReturnsAsync(createdUser);

            // Act
            var result = await adminUserManagementController.CreateUser(request);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(nameof(AdminUserManagementController.GetUser), createdAtActionResult.ActionName);
            Assert.Equal(2, createdAtActionResult.RouteValues["id"]);

            var apiResponse = Assert.IsType<ApiResponse<UserDto>>(createdAtActionResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("tạo người dùng thành công", apiResponse.Message);

            var userDto = apiResponse.Data;
            Assert.Equal(2, userDto.UserId);
            Assert.Equal("New User", userDto.Name);
            Assert.Equal("new@example.com", userDto.Email);
            Assert.Equal("Customer", userDto.RoleName);

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task CreateUser_ReturnsBadRequest_WhenRoleNameIsInvalid()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            var request = new CreateUserRequest
            {
                Name = "New User",
                Email = "new@example.com",
                Password = "password123",
                PhoneNumber = "9876543210",
                RoleName = "NonExistentRole"
            };

            mockUserService.Setup(s => s.GetByRoleNameAsync(request.RoleName))
                .ReturnsAsync((Role)null);

            // Act
            var result = await adminUserManagementController.CreateUser(request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal($"Không thấy vai trò '{request.RoleName}'", apiErrorResponse.Message);

            // Verify service calls
            mockUserService.Verify(s => s.GetByRoleNameAsync(request.RoleName), Times.Once);
            mockUserService.Verify(s => s.CreateAsync(It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task CreateUser_ThrowsException_WhenExceptionOccurs()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            var request = new CreateUserRequest
            {
                Name = "New User",
                Email = "new@example.com",
                Password = "password123",
                PhoneNumber = "9876543210",
                RoleName = "Customer"
            };

            var role = new Role { RoleId = 2, Name = "Customer" };

            mockUserService.Setup(s => s.GetByRoleNameAsync(request.RoleName))
                .ReturnsAsync(role);

            mockUserService.Setup(s => s.CreateAsync(It.IsAny<User>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => adminUserManagementController.CreateUser(request));

            // Verify service calls
            mockUserService.Verify();
        }

        #endregion

        #region UpdateUser Tests

        [Fact]
        public async Task UpdateUser_ReturnsUpdatedUser_WhenRequestIsValid()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int id = 1;
            var request = new UpdateUserRequest
            {
                Name = "Updated User",
                Email = "updated@example.com",
                PhoneNumber = "5555555555",
                Address = "456 Update St",
                RoleName = "Admin",
                ImageURL = "updated.jpg"
            };

            var role = new Role { RoleId = 1, Name = "Admin" };
            var existingUser = new User
            {
                UserId = id,
                Name = "Original User",
                Email = "original@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Original St",
                Role = new Role { RoleId = 2, Name = "Customer" },
                ImageURL = "original.jpg",
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            var updatedUser = new User
            {
                UserId = id,
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Role = role,
                ImageURL = request.ImageURL,
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                UpdatedAt = DateTime.UtcNow
            };

            mockUserService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingUser);

            mockUserService.Setup(s => s.GetByRoleNameAsync(request.RoleName))
                .ReturnsAsync(role);

            mockUserService.Setup(s => s.UpdateAsync(id, It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            mockUserService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(updatedUser);

            // Act
            var result = await adminUserManagementController.UpdateUser(id, request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UserDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("cập nhật người dùng thành công", apiResponse.Message);

            var userDto = apiResponse.Data;
            Assert.Equal(id, userDto.UserId);
            Assert.Equal("Updated User", userDto.Name);
            Assert.Equal("updated@example.com", userDto.Email);
            Assert.Equal("Admin", userDto.RoleName);
            Assert.Equal("456 Update St", userDto.Address);
            Assert.Equal("updated.jpg", userDto.ImageURL);

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task UpdateUser_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int id = 999;
            var request = new UpdateUserRequest
            {
                Name = "Updated User",
                Email = "updated@example.com",
                PhoneNumber = "5555555555",
                Address = "456 Update St",
                RoleName = "Admin",
                ImageURL = "updated.jpg"
            };

            mockUserService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync((User)null);

            // Act
            var result = await adminUserManagementController.UpdateUser(id, request);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal("không thấy người dùng", apiErrorResponse.Message);

            // Verify service calls
            mockUserService.Verify(s => s.GetByIdAsync(id), Times.Once);
            mockUserService.Verify(s => s.GetByRoleNameAsync(It.IsAny<string>()), Times.Never);
            mockUserService.Verify(s => s.UpdateAsync(It.IsAny<int>(), It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task UpdateUser_ReturnsBadRequest_WhenRoleNameIsInvalid()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int id = 1;
            var request = new UpdateUserRequest
            {
                Name = "Updated User",
                Email = "updated@example.com",
                PhoneNumber = "5555555555",
                Address = "456 Update St",
                RoleName = "NonExistentRole",
                ImageURL = "updated.jpg"
            };

            var existingUser = new User
            {
                UserId = id,
                Name = "Original User",
                Email = "original@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Original St",
                Role = new Role { RoleId = 2, Name = "Customer" },
                ImageURL = "original.jpg",
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockUserService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingUser);

            mockUserService.Setup(s => s.GetByRoleNameAsync(request.RoleName))
                .ReturnsAsync((Role)null);

            // Act
            var result = await adminUserManagementController.UpdateUser(id, request);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiErrorResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);

            Assert.Equal("Error", apiErrorResponse.Status);
            Assert.Equal($"Không thấy vai trò '{request.RoleName}'", apiErrorResponse.Message);

            // Verify service calls
            mockUserService.Verify(s => s.GetByIdAsync(id), Times.Once);
            mockUserService.Verify(s => s.GetByRoleNameAsync(request.RoleName), Times.Once);
            mockUserService.Verify(s => s.UpdateAsync(It.IsAny<int>(), It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task UpdateUser_ThrowsException_WhenExceptionOccurs()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int id = 1;
            var request = new UpdateUserRequest
            {
                Name = "Updated User",
                Email = "updated@example.com",
                PhoneNumber = "5555555555",
                Address = "456 Update St",
                RoleName = "Admin",
                ImageURL = "updated.jpg"
            };

            var role = new Role { RoleId = 1, Name = "Admin" };
            var existingUser = new User
            {
                UserId = id,
                Name = "Original User",
                Email = "original@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Original St",
                Role = new Role { RoleId = 2, Name = "Customer" },
                ImageURL = "original.jpg",
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockUserService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingUser);

            mockUserService.Setup(s => s.GetByRoleNameAsync(request.RoleName))
                .ReturnsAsync(role);

            mockUserService.Setup(s => s.UpdateAsync(id, It.IsAny<User>()))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => adminUserManagementController.UpdateUser(id, request));

            // Verify service calls
            mockUserService.Verify(s => s.GetByIdAsync(id), Times.Once);
            mockUserService.Verify(s => s.GetByRoleNameAsync(request.RoleName), Times.Once);
            mockUserService.Verify(s => s.UpdateAsync(id, It.IsAny<User>()), Times.Once);
        }

        #endregion

        #region DeleteUser Tests

        [Fact]
        public async Task DeleteUser_ReturnsSuccess_WhenDeleteSucceeds()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int id = 1;

            mockUserService.Setup(s => s.DeleteAsync(id))
                .Returns(Task.CompletedTask);

            // Act
            var result = await adminUserManagementController.DeleteUser(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<bool>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("xoá thành công", apiResponse.Message);
            Assert.True(apiResponse.Data);

            // Verify service calls
            mockUserService.Verify(s => s.DeleteAsync(id), Times.Once);
        }

        [Fact]
        public async Task DeleteUser_ThrowsException_WhenExceptionOccurs()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int id = 1;

            mockUserService.Setup(s => s.DeleteAsync(id))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => adminUserManagementController.DeleteUser(id));

            // Verify service calls
            mockUserService.Verify(s => s.DeleteAsync(id), Times.Once);
        }

        #endregion

        #region Edge Cases and Additional Tests

        [Fact]
        public async Task GetUser_HandlesNullRole_WhenUserExists()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int id = 1;

            var user = new User
            {
                UserId = id,
                Name = "Test User",
                Email = "test@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Test St",
                Role = null, // Null role
                ImageURL = "test.jpg",
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            mockUserService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(user);

            // Act
            var result = await adminUserManagementController.GetUser(id);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<UserDto>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Lấy người dùng thành công", apiResponse.Message);

            var userDto = apiResponse.Data;
            Assert.Equal(id, userDto.UserId);
            Assert.Equal("Test User", userDto.Name);
            Assert.Equal("test@example.com", userDto.Email);
            Assert.Equal("Customer", userDto.RoleName); // Default to "Customer" when role is null

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task GetUsers_HandlesEmptyList_WhenNoUsersExist()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int pageNumber = 1;
            int pageSize = 10;

            var emptyPagedResult = new PagedResult<User>
            {
                Items = new List<User>(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 0
            };

            mockUserService.Setup(s => s.GetUsersAsync(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true))
                .ReturnsAsync(emptyPagedResult);

            // Act
            var result = await adminUserManagementController.GetUsers(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<UserDto>>>(okResult.Value);

            Assert.True(apiResponse.Success);
            Assert.Equal("Lấy danh sách người dùng thành công", apiResponse.Message);

            var returnedPagedResult = apiResponse.Data;
            Assert.Equal(0, returnedPagedResult.TotalCount);
            Assert.Empty(returnedPagedResult.Items);

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task CreateUser_HandlesPasswordHashing_WhenCreatingUser()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            var request = new CreateUserRequest
            {
                Name = "New User",
                Email = "new@example.com",
                Password = "password123",
                PhoneNumber = "9876543210",
                RoleName = "Customer"
            };

            var role = new Role { RoleId = 2, Name = "Customer" };
            var createdUser = new User
            {
                UserId = 2,
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Role = role,
                CreatedAt = DateTime.UtcNow.AddHours(7),
                UpdatedAt = DateTime.UtcNow
            };

            mockUserService.Setup(s => s.GetByRoleNameAsync(request.RoleName))
                .ReturnsAsync(role);

            // Capture the User object passed to CreateAsync to verify password hashing
            User capturedUser = null;
            mockUserService.Setup(s => s.CreateAsync(It.IsAny<User>()))
                .Callback<User>(u => capturedUser = u)
                .ReturnsAsync(createdUser);

            // Act
            var result = await adminUserManagementController.CreateUser(request);

            // Assert
            Assert.NotNull(capturedUser);
            Assert.NotEqual(request.Password, capturedUser.Password); // Password should be hashed
            Assert.True(BCrypt.Net.BCrypt.Verify(request.Password, capturedUser.Password)); // Verify hash

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task UpdateUser_PreservesExistingPassword_WhenUpdatingUser()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int id = 1;
            var request = new UpdateUserRequest
            {
                Name = "Updated User",
                Email = "updated@example.com",
                PhoneNumber = "5555555555",
                Address = "456 Update St",
                RoleName = "Admin",
                ImageURL = "updated.jpg"
            };

            var role = new Role { RoleId = 1, Name = "Admin" };
            var existingUser = new User
            {
                UserId = id,
                Name = "Original User",
                Email = "original@example.com",
                PhoneNumber = "1234567890",
                Address = "123 Original St",
                Password = "hashedpassword123", // Existing password
                Role = new Role { RoleId = 2, Name = "Customer" },
                ImageURL = "original.jpg",
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                UpdatedAt = DateTime.UtcNow.AddDays(-5)
            };

            var updatedUser = new User
            {
                UserId = id,
                Name = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
                Password = "hashedpassword123", // Password should remain unchanged
                Role = role,
                ImageURL = request.ImageURL,
                CreatedAt = DateTime.UtcNow.AddDays(-15),
                UpdatedAt = DateTime.UtcNow
            };

            mockUserService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(existingUser);

            mockUserService.Setup(s => s.GetByRoleNameAsync(request.RoleName))
                .ReturnsAsync(role);

            // Capture the User object passed to UpdateAsync to verify password preservation
            User capturedUser = null;
            mockUserService.Setup(s => s.UpdateAsync(id, It.IsAny<User>()))
                .Callback<int, User>((i, u) => capturedUser = u)
                .Returns(Task.CompletedTask);

            mockUserService.Setup(s => s.GetByIdAsync(id))
                .ReturnsAsync(updatedUser);

            // Act
            var result = await adminUserManagementController.UpdateUser(id, request);

            // Assert
            Assert.NotNull(capturedUser);
            Assert.Equal("hashedpassword123", capturedUser.Password); // Password should remain unchanged

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task GetUsers_HandlesNullImageURL_WhenReturningUsers()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int pageNumber = 1;
            int pageSize = 10;

            var role = new Role { RoleId = 2, Name = "Customer" };
            var users = new List<User>
            {
                new User
                {
                    UserId = 1,
                    Name = "Test User",
                    Email = "test@example.com",
                    PhoneNumber = "1234567890",
                    Address = "123 Test St",
                    Role = role,
                    ImageURL = null, // Null ImageURL
                    CreatedAt = DateTime.UtcNow.AddDays(-15),
                    UpdatedAt = DateTime.UtcNow.AddDays(-5)
                }
            };

            var pagedResult = new PagedResult<User>
            {
                Items = users,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockUserService.Setup(s => s.GetUsersAsync(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminUserManagementController.GetUsers(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<UserDto>>>(okResult.Value);

            var returnedPagedResult = apiResponse.Data;
            var items = returnedPagedResult.Items.ToList();
            Assert.Single(items);
            Assert.Equal(string.Empty, items[0].ImageURL); // ImageURL should be empty string, not null

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task GetUsers_HandlesNullAddress_WhenReturningUsers()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int pageNumber = 1;
            int pageSize = 10;

            var role = new Role { RoleId = 2, Name = "Customer" };
            var users = new List<User>
    {
        new User
        {
            UserId = 1,
            Name = "Test User",
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            Address = null, // Null Address
            Role = role,
            ImageURL = "test.jpg",
            CreatedAt = DateTime.UtcNow.AddDays(-15),
            UpdatedAt = DateTime.UtcNow.AddDays(-5)
        }
    };

            var pagedResult = new PagedResult<User>
            {
                Items = users,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockUserService.Setup(s => s.GetUsersAsync(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminUserManagementController.GetUsers(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<UserDto>>>(okResult.Value);

            var returnedPagedResult = apiResponse.Data;
            var items = returnedPagedResult.Items.ToList();
            Assert.Single(items);
            Assert.Null(items[0].Address); // Current implementation returns null for null Address

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task GetUsers_HandlesNullPhoneNumber_WhenReturningUsers()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int pageNumber = 1;
            int pageSize = 10;

            var role = new Role { RoleId = 2, Name = "Customer" };
            var users = new List<User>
    {
        new User
        {
            UserId = 1,
            Name = "Test User",
            Email = "test@example.com",
            PhoneNumber = null, // Null PhoneNumber
            Address = "123 Test St",
            Role = role,
            ImageURL = "test.jpg",
            CreatedAt = DateTime.UtcNow.AddDays(-15),
            UpdatedAt = DateTime.UtcNow.AddDays(-5)
        }
    };

            var pagedResult = new PagedResult<User>
            {
                Items = users,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockUserService.Setup(s => s.GetUsersAsync(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminUserManagementController.GetUsers(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<UserDto>>>(okResult.Value);

            var returnedPagedResult = apiResponse.Data;
            var items = returnedPagedResult.Items.ToList();
            Assert.Single(items);
            Assert.Null(items[0].PhoneNumber); // Current implementation returns null for null PhoneNumber

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task GetUsers_HandlesWorkDays_WhenReturningUsers()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int pageNumber = 1;
            int pageSize = 10;

            var role = new Role { RoleId = 2, Name = "Customer" };
            var users = new List<User>
    {
        new User
        {
            UserId = 1,
            Name = "Test User",
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            Address = "123 Test St",
            Role = role,
            ImageURL = "test.jpg",
            WorkDays = WorkDays.Monday | WorkDays.Wednesday | WorkDays.Friday, // Set WorkDays
            CreatedAt = DateTime.UtcNow.AddDays(-15),
            UpdatedAt = DateTime.UtcNow.AddDays(-5)
        }
    };

            var pagedResult = new PagedResult<User>
            {
                Items = users,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockUserService.Setup(s => s.GetUsersAsync(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminUserManagementController.GetUsers(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<UserDto>>>(okResult.Value);

            var returnedPagedResult = apiResponse.Data;
            var items = returnedPagedResult.Items.ToList();
            Assert.Single(items);
            Assert.Null(items[0].WorkDays); // Current implementation doesn't map WorkDays

            // Verify service calls
            mockUserService.Verify();
        }

        [Fact]
        public async Task GetUsers_HandlesLoyaltyPoints_WhenReturningUsers()
        {
            // Arrange
            var adminUserManagementController = this.CreateAdminUserManagementController();
            int pageNumber = 1;
            int pageSize = 10;

            var role = new Role { RoleId = 2, Name = "Customer" };
            var users = new List<User>
    {
        new User
        {
            UserId = 1,
            Name = "Test User",
            Email = "test@example.com",
            PhoneNumber = "1234567890",
            Address = "123 Test St",
            Role = role,
            ImageURL = "test.jpg",
            LoyatyPoint = 110, // Set LoyaltyPoints
            CreatedAt = DateTime.UtcNow.AddDays(-15),
            UpdatedAt = DateTime.UtcNow.AddDays(-5)
        }
    };

            var pagedResult = new PagedResult<User>
            {
                Items = users,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = 1
            };

            mockUserService.Setup(s => s.GetUsersAsync(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await adminUserManagementController.GetUsers(
                null, null, null, null, null,
                pageNumber, pageSize, "Name", true);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<PagedResult<UserDto>>>(okResult.Value);

            var returnedPagedResult = apiResponse.Data;
            var items = returnedPagedResult.Items.ToList();
            Assert.Single(items);
            Assert.Equal(0, items[0].LoyatyPoint); // The current implementation doesn't map LoyatyPoint

            // Verify service calls
            mockUserService.Verify();
        }

        #endregion
    }
}