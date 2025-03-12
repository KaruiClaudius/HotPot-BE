using Capstone.HPTY.API.AppStarts;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Auth;
using Capstone.HPTY.ServiceLayer.DTOs.Common;

using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Capstone.HPTY.ServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Capstone.HPTY.API.Controllers.Auth
{
    [ApiController]
    [Route("api/auth")]
    [SwaggerGroup("Auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUserService userService, IAuthService authService, ILogger<AuthController> logger)
        {
            _userService = userService;
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(ApiResponse<AuthResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _authService.LoginAsync(request);
                return Ok(new ApiResponse<AuthResponse>
                {
                    Success = true,
                    Message = "Đăng nhập thành công",
                    Data = response
                });
            }
            catch (UnauthorizedException ex)
            {
                _logger.LogWarning(ex, "Đăng nhập không thành công: SĐT {PhoneNumber}", request.PhoneNumber);
                return Unauthorized(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }

        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(ApiResponse<AuthResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            try
            {
                var response = await _authService.RegisterAsync(request);
                return Ok(new ApiResponse<AuthResponse>
                {
                    Success = true,
                    Message = "Đăng ký thành công",
                    Data = response
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Đăng ký thất bại: SĐT {PhoneNumber}", request.PhoneNumber);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
        }

        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(ApiResponse<AuthResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                var response = await _authService.RefreshTokenAsync(request.RefreshToken);
                return Ok(new ApiResponse<AuthResponse>
                {
                    Success = true,
                    Message = "Token Làm mới thành công",
                    Data = response
                });
            }
            catch (UnauthorizedException ex)
            {
                return Unauthorized(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
        }

        [Authorize]
        [HttpPost("logout")]
        [ProducesResponseType(typeof(ApiResponse<object>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Logout()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (int.TryParse(userId, out int id))
            {
                await _authService.LogoutAsync(id);
            }

            return Ok(new ApiResponse<object>
            {
                Success = true,
                Message = "Đăng xuất thành công"
            });
        }

        [HttpPut("change-password")]
        [Authorize] // Requires authentication
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            try
            {
                // Get the current user's ID from the token
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int id))
                {
                    return Unauthorized(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Chưa xác thực, vui lòng đăng nhập"
                    });
                }

                // Verify current password
                var user = await _userService.GetByIdAsync(id);
                if (user == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "không tìm thấy User"
                    });
                }

                // Verify the current password
                if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, user.Password))
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Mật khẩu hiện tại không trùng khớp"
                    });
                }

                // Update the password
                await _userService.UpdatePasswordAsync(id, request.NewPassword);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Mật khẩu cập nhật thành công",
                    Data = "Mật khẩu đã đổi"
                });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Gặp trục trặc khi đổi mật khẩu"
                });
            }
        }

        [HttpPost("signin-google")]
        [ProducesResponseType(typeof(ApiResponse<AuthResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GoogleLogin([FromBody] GoogleLoginRequest request)
        {
            try
            {
                var response = await _authService.GoogleLoginAsync(request.IdToken);
                return Ok(new ApiResponse<AuthResponse>
                {
                    Success = true,
                    Message = "Đăng nhập Google thành công",
                    Data = response
                });
            }
            catch (UnauthorizedException ex)
            {
                _logger.LogWarning(ex, "Đăng nhập Google thất bại");
                return Unauthorized(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
        }
    }
}
