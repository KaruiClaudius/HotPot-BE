using Capstone.HPTY.API.Controllers.Auth;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Auth;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace Capstone.HPTY.Test.Controllers.Auth
{
    public class AuthControllerTests
    {
        private MockRepository mockRepository;

        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly Mock<ILogger<AuthController>> _mockLogger;
        private readonly AuthController _controller;

        public AuthControllerTests()
        {
            _mockUserService = new Mock<IUserService>();
            _mockAuthService = new Mock<IAuthService>();
            _mockLogger = new Mock<ILogger<AuthController>>();
            _controller = new AuthController(
                _mockUserService.Object,
                _mockAuthService.Object,
                _mockLogger.Object);
        }

        [Fact]
        public async Task Login_WithValidCredentials_ReturnsOkWithToken()
        {
            // Arrange
            var loginRequest = new LoginRequest
            {
                PhoneNumber = "1234567890",
                Password = "password123"
            };

            var authResponse = new AuthResponse
            {
                AccessToken = "test-token",
                RefreshToken = "refresh-token",
                ExpiresAt = DateTime.UtcNow.AddDays(1),
            };

            _mockAuthService
                .Setup(service => service.LoginAsync(It.IsAny<LoginRequest>()))
                .ReturnsAsync(authResponse);

            // Act
            var result = await _controller.Login(loginRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<AuthResponse>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Đăng nhập thành công", apiResponse.Message);
            Assert.Equal(authResponse, apiResponse.Data);
            _mockAuthService.Verify(service => service.LoginAsync(loginRequest), Times.Once);
        }

        [Fact]
        public async Task Login_WithInvalidCredentials_ReturnsUnauthorized()
        {
            // Arrange
            var loginRequest = new LoginRequest
            {
                PhoneNumber = "1234567890",
                Password = "wrongpassword"
            };

            _mockAuthService
                .Setup(service => service.LoginAsync(It.IsAny<LoginRequest>()))
                .ThrowsAsync(new UnauthorizedException("Thông tin đăng nhập không chính xác"));

            // Act
            var result = await _controller.Login(loginRequest);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(unauthorizedResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Thông tin đăng nhập không chính xác", apiResponse.Message);
            _mockAuthService.Verify(service => service.LoginAsync(loginRequest), Times.Once);
        }

        [Fact]
        public async Task GetProfile_WithValidUser_ReturnsUserProfile()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var user = new User
            {
                UserId = userId,
                Name = "Test User",
                Email = "test@example.com",
                PhoneNumber = "1234567890",
                Address = "Test Address",
                Role = new Role { Name = "Customer" },
                ImageURL = "test-image.jpg",
                LoyatyPoint = 100.0
            };

            _mockUserService
                .Setup(service => service.GetByIdAsync(userId))
                .ReturnsAsync(user);

            // Act
            var result = await _controller.GetProfile();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<UserDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Lấy thông tin người dùng thành công", apiResponse.Message);

            var userDto = apiResponse.Data;
            Assert.Equal(userId, userDto.UserId);
            Assert.Equal("Test User", userDto.Name);
            Assert.Equal("test@example.com", userDto.Email);
            Assert.Equal("1234567890", userDto.PhoneNumber);
            Assert.Equal("Test Address", userDto.Address);
            Assert.Equal("Customer", userDto.RoleName);
            Assert.Equal("test-image.jpg", userDto.ImageURL);
            Assert.Equal(100.0, userDto.LoyatyPoint);

            _mockUserService.Verify(service => service.GetByIdAsync(userId), Times.Once);
        }

        [Fact]
        public async Task GetProfile_WithNoAuthenticatedUser_ReturnsUnauthorized()
        {
            // Arrange - no user identity setup
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            // Act
            var result = await _controller.GetProfile();

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(unauthorizedResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Chưa xác thực, vui lòng đăng nhập", apiResponse.Message);
        }

        [Fact]
        public async Task GetProfile_WithNonExistentUser_ReturnsNotFound()
        {
            // Arrange
            int userId = 999;
            SetupUserIdentity(userId);

            _mockUserService
                .Setup(service => service.GetByIdAsync(userId))
                .ReturnsAsync((User)null);

            // Act
            var result = await _controller.GetProfile();

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Không tìm thấy người dùng", apiResponse.Message);
            _mockUserService.Verify(service => service.GetByIdAsync(userId), Times.Once);
        }

        [Fact]
        public async Task Register_WithValidData_ReturnsOkWithToken()
        {
            // Arrange
            var registerRequest = new RegisterRequest
            {
                Name = "New User",
                PhoneNumber = "1234567890",
                Password = "password123"
            };

            var authResponse = new AuthResponse
            {
                AccessToken = "test-token",
                RefreshToken = "refresh-token",
                ExpiresAt = DateTime.UtcNow.AddDays(1),
            };

            _mockAuthService
                .Setup(service => service.RegisterAsync(It.IsAny<RegisterRequest>()))
                .ReturnsAsync(authResponse);

            // Act
            var result = await _controller.Register(registerRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<AuthResponse>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Đăng ký thành công", apiResponse.Message);
            Assert.Equal(authResponse, apiResponse.Data);
            _mockAuthService.Verify(service => service.RegisterAsync(registerRequest), Times.Once);
        }

        [Fact]
        public async Task Register_WithInvalidData_ReturnsBadRequest()
        {
            // Arrange
            var registerRequest = new RegisterRequest
            {
                Name = "New User",
                PhoneNumber = "1234567890",
                Password = "weak"
            };

            _mockAuthService
                .Setup(service => service.RegisterAsync(It.IsAny<RegisterRequest>()))
                .ThrowsAsync(new ValidationException("Mật khẩu phải có ít nhất 8 ký tự"));

            // Act
            var result = await _controller.Register(registerRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Mật khẩu phải có ít nhất 8 ký tự", apiResponse.Message);
            _mockAuthService.Verify(service => service.RegisterAsync(registerRequest), Times.Once);
        }

        [Fact]
        public async Task UpdateProfile_WithValidData_ReturnsUpdatedProfile()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var profileUpdateRequest = new ProfileUpdateRequest
            {
                Name = "Updated Name",
                Email = "updated@example.com",
                Address = "Updated Address",
                ImageURL = "updated-image.jpg"
            };

            var currentUser = new User
            {
                UserId = userId,
                Name = "Original Name",
                Email = "original@example.com",
                PhoneNumber = "1234567890",
                Address = "Original Address",
                Role = new Role { Name = "Customer" },
                ImageURL = "original-image.jpg",
                LoyatyPoint = 100.0,
                RoleId = 2
            };

            var updatedUser = new User
            {
                UserId = userId,
                Name = "Updated Name",
                Email = "updated@example.com",
                PhoneNumber = "1234567890",
                Address = "Updated Address",
                Role = new Role { Name = "Customer" },
                ImageURL = "updated-image.jpg",
                LoyatyPoint = 100.0,
                RoleId = 2
            };

            _mockUserService
                .Setup(service => service.GetByIdAsync(userId))
                .ReturnsAsync(currentUser);

            _mockUserService
                .Setup(service => service.UpdateAsync(userId, It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            // Setup second call to GetByIdAsync to return updated user
            _mockUserService
                .SetupSequence(service => service.GetByIdAsync(userId))
                .ReturnsAsync(currentUser)
                .ReturnsAsync(updatedUser);

            // Act
            var result = await _controller.UpdateProfile(profileUpdateRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<UserDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Cập nhật thông tin người dùng thành công", apiResponse.Message);

            var userDto = apiResponse.Data;
            Assert.Equal(userId, userDto.UserId);
            Assert.Equal("Updated Name", userDto.Name);
            Assert.Equal("updated@example.com", userDto.Email);
            Assert.Equal("Updated Address", userDto.Address);
            Assert.Equal("updated-image.jpg", userDto.ImageURL);

            _mockUserService.Verify(service => service.UpdateAsync(userId, It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task RefreshToken_WithValidToken_ReturnsNewTokens()
        {
            // Arrange
            var refreshTokenRequest = new RefreshTokenRequest
            {
                RefreshToken = "valid-refresh-token"
            };

            var authResponse = new AuthResponse
            {
                AccessToken = "new-token",
                RefreshToken = "new-refresh-token",
                ExpiresAt = DateTime.UtcNow.AddDays(1),
            };

            _mockAuthService
                .Setup(service => service.RefreshTokenAsync(refreshTokenRequest.RefreshToken))
                .ReturnsAsync(authResponse);

            // Act
            var result = await _controller.RefreshToken(refreshTokenRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<AuthResponse>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Token Làm mới thành công", apiResponse.Message);
            Assert.Equal(authResponse, apiResponse.Data);
            _mockAuthService.Verify(service => service.RefreshTokenAsync(refreshTokenRequest.RefreshToken), Times.Once);
        }

        [Fact]
        public async Task RefreshToken_WithInvalidToken_ReturnsUnauthorized()
        {
            // Arrange
            var refreshTokenRequest = new RefreshTokenRequest
            {
                RefreshToken = "invalid-refresh-token"
            };

            _mockAuthService
                .Setup(service => service.RefreshTokenAsync(refreshTokenRequest.RefreshToken))
                .ThrowsAsync(new UnauthorizedException("Token làm mới không hợp lệ hoặc đã hết hạn"));

            // Act
            var result = await _controller.RefreshToken(refreshTokenRequest);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(unauthorizedResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Token làm mới không hợp lệ hoặc đã hết hạn", apiResponse.Message);
            _mockAuthService.Verify(service => service.RefreshTokenAsync(refreshTokenRequest.RefreshToken), Times.Once);
        }

        [Fact]
        public async Task Logout_WithValidUser_ReturnsOk()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            _mockAuthService
                .Setup(service => service.LogoutAsync(userId))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Logout();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<object>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Đăng xuất thành công", apiResponse.Message);
            _mockAuthService.Verify(service => service.LogoutAsync(userId), Times.Once);
        }

        [Fact]
        public async Task Logout_WithNoAuthenticatedUser_ReturnsUnauthorized()
        {
            // Arrange - no user identity setup
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            // Act
            var result = await _controller.Logout();

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(unauthorizedResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Chưa xác thực, vui lòng đăng nhập", apiResponse.Message);
        }

        [Fact]
        public async Task ChangePassword_WithValidData_ReturnsOk()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var changePasswordRequest = new ChangePasswordRequest
            {
                CurrentPassword = "currentPassword",
                NewPassword = "newPassword123"
            };

            var user = new User
            {
                UserId = userId,
                Name = "Test User",
                Password = BCrypt.Net.BCrypt.HashPassword("currentPassword")
            };

            _mockUserService
                .Setup(service => service.GetByIdAsync(userId))
                .ReturnsAsync(user);

            _mockUserService
                .Setup(service => service.UpdatePasswordAsync(userId, changePasswordRequest.NewPassword))
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.ChangePassword(changePasswordRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiResponse<string>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Mật khẩu cập nhật thành công", apiResponse.Message);
            Assert.Equal("Mật khẩu đã đổi", apiResponse.Data);
            _mockUserService.Verify(service => service.UpdatePasswordAsync(userId, changePasswordRequest.NewPassword), Times.Once);
        }

        [Fact]
        public async Task ChangePassword_WithIncorrectCurrentPassword_ReturnsBadRequest()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var changePasswordRequest = new ChangePasswordRequest
            {
                CurrentPassword = "wrongPassword",
                NewPassword = "newPassword123"
            };

            var user = new User
            {
                UserId = userId,
                Name = "Test User",
                Password = BCrypt.Net.BCrypt.HashPassword("currentPassword")
            };

            _mockUserService
                .Setup(service => service.GetByIdAsync(userId))
                .ReturnsAsync(user);

            // Act
            var result = await _controller.ChangePassword(changePasswordRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Mật khẩu hiện tại không trùng khớp", apiResponse.Message);
            _mockUserService.Verify(service => service.UpdatePasswordAsync(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task ChangePassword_WithNoAuthenticatedUser_ReturnsUnauthorized()
        {
            // Arrange
            // Explicitly set up an empty or unauthenticated user context
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };

            var changePasswordRequest = new ChangePasswordRequest
            {
                CurrentPassword = "currentPassword",
                NewPassword = "newPassword123"
            };

            // Act
            var result = await _controller.ChangePassword(changePasswordRequest);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(unauthorizedResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Chưa xác thực, vui lòng đăng nhập", apiResponse.Message);
        }

        [Fact]
        public async Task ChangePassword_WithNonExistentUser_ReturnsNotFound()
        {
            // Arrange
            int userId = 999;
            SetupUserIdentity(userId);

            var changePasswordRequest = new ChangePasswordRequest
            {
                CurrentPassword = "currentPassword",
                NewPassword = "newPassword123"
            };

            _mockUserService
                .Setup(service => service.GetByIdAsync(userId))
                .ReturnsAsync((User)null);

            // Act
            var result = await _controller.ChangePassword(changePasswordRequest);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(notFoundResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("không tìm thấy User", apiResponse.Message);
            _mockUserService.Verify(service => service.UpdatePasswordAsync(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public async Task UpdateProfile_WithNoChanges_ReturnsOkWithNoChangesMessage()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var profileUpdateRequest = new ProfileUpdateRequest
            {
                // All null or empty values
            };

            var currentUser = new User
            {
                UserId = userId,
                Name = "Original Name",
                Email = "original@example.com",
                PhoneNumber = "1234567890",
                Address = "Original Address",
                Role = new Role { Name = "Customer" },
                ImageURL = "original-image.jpg",
                LoyatyPoint = 100.0,
                RoleId = 2
            };

            _mockUserService
                .Setup(service => service.GetByIdAsync(userId))
                .ReturnsAsync(currentUser);

            // Act
            var result = await _controller.UpdateProfile(profileUpdateRequest);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var apiResponse = Assert.IsType<ApiResponse<UserDto>>(okResult.Value);
            Assert.True(apiResponse.Success);
            Assert.Equal("Không có thông tin nào được cập nhật", apiResponse.Message);

            // Verify that UpdateAsync was never called since there were no changes
            _mockUserService.Verify(service => service.UpdateAsync(It.IsAny<int>(), It.IsAny<User>()), Times.Never);
        }

        [Fact]
        public async Task UpdateProfile_WithValidationError_ReturnsBadRequest()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            var profileUpdateRequest = new ProfileUpdateRequest
            {
                Email = "invalid-email-format"
            };

            var currentUser = new User
            {
                UserId = userId,
                Name = "Original Name",
                Email = "original@example.com",
                PhoneNumber = "1234567890"
            };

            _mockUserService
                .Setup(service => service.GetByIdAsync(userId))
                .ReturnsAsync(currentUser);

            _mockUserService
                .Setup(service => service.UpdateAsync(userId, It.IsAny<User>()))
                .ThrowsAsync(new ValidationException("Email không đúng định dạng"));

            // Act
            var result = await _controller.UpdateProfile(profileUpdateRequest);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            var apiResponse = Assert.IsType<ApiErrorResponse>(badRequestResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Email không đúng định dạng", apiResponse.Message);
        }

        [Fact]
        public async Task GetProfile_WithServerError_ReturnsInternalServerError()
        {
            // Arrange
            int userId = 1;
            SetupUserIdentity(userId);

            _mockUserService
                .Setup(service => service.GetByIdAsync(userId))
                .ThrowsAsync(new Exception("Database connection error"));

            // Act
            var result = await _controller.GetProfile();

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
            var apiResponse = Assert.IsType<ApiErrorResponse>(statusCodeResult.Value);
            Assert.Equal("Error", apiResponse.Status);
            Assert.Equal("Gặp trục trặc khi lấy thông tin người dùng", apiResponse.Message);
        }

        // Helper method to set up the User identity for authorized endpoints
        private void SetupUserIdentity(int userId)
        {
            var claims = new List<Claim>
        {
            new Claim("id", userId.ToString())
        };
            var identity = new ClaimsIdentity(claims, "TestAuthType");
            var claimsPrincipal = new ClaimsPrincipal(identity);

            // Set up the ControllerContext
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = claimsPrincipal
                }
            };
        }
    }
}
