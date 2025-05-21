using Capstone.HPTY.API.AppStarts;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Auth;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.User;
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

        /// <summary>
        /// Retrieves the profile information for the authenticated user
        /// </summary>
        [Authorize]
        [HttpGet("profile")]
        [ProducesResponseType(typeof(ApiResponse<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProfile()
        {
            try
            {
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Chưa xác thực, vui lòng đăng nhập"
                    });

                int userId = int.Parse(userIdClaim.Value);             

                var user = await _userService.GetByIdAsync(userId);
                if (user == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Không tìm thấy người dùng"
                    });
                }

                // Map User to UserDto
                var userDto = new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    Email = user.Email ?? string.Empty,
                    PhoneNumber = user.PhoneNumber ?? string.Empty,
                    Address = user.Address ?? string.Empty,
                    RoleName = user.Role?.Name ?? "Customer",
                    ImageURL = user.ImageURL ?? string.Empty,
                    LoyatyPoint = user.LoyatyPoint ?? 0.0
                };

                return Ok(new ApiResponse<UserDto>
                {
                    Success = true,
                    Message = "Lấy thông tin người dùng thành công",
                    Data = userDto
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
                _logger.LogError(ex, "Error retrieving user profile");
                return StatusCode(500, new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Gặp trục trặc khi lấy thông tin người dùng"
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

        /// <summary>
        /// Updates the profile information for the authenticated user
        /// </summary>
        [Authorize]
        [HttpPut("profile")]
        [ProducesResponseType(typeof(ApiResponse<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProfile([FromBody] ProfileUpdateRequest request)
        {
            try
            {
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Chưa xác thực, vui lòng đăng nhập"
                    });

                int userId = int.Parse(userIdClaim.Value);

                // Get the current user
                var currentUser = await _userService.GetByIdAsync(userId);
                if (currentUser == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Không tìm thấy người dùng"
                    });
                }

                // Create a User entity starting with current values
                var userToUpdate = new User
                {
                    UserId = userId,
                    // Start with all current values
                    Name = currentUser.Name,
                    Email = currentUser.Email,
                    Address = currentUser.Address,
                    ImageURL = currentUser.ImageURL,
                    PhoneNumber = currentUser.PhoneNumber,
                    RoleId = currentUser.RoleId,
                    LoyatyPoint = currentUser.LoyatyPoint,
                    WorkDays = currentUser.WorkDays,
                    Note = currentUser.Note
                };

                // Only update fields that are provided in the request
                bool hasChanges = false;

                if (request.Name != null && !string.IsNullOrWhiteSpace(request.Name))
                {
                    userToUpdate.Name = request.Name;
                    hasChanges = true;
                }

                if (request.Email != null && !string.IsNullOrWhiteSpace(request.Email))
                {
                    userToUpdate.Email = request.Email;
                    hasChanges = true;
                }


                if (request.Address != null && !string.IsNullOrWhiteSpace(request.Address))
                {
                    userToUpdate.Address = request.Address;
                    hasChanges = true;
                }

                if (request.ImageURL != null && !string.IsNullOrWhiteSpace(request.ImageURL))
                {
                    userToUpdate.ImageURL = request.ImageURL;
                    hasChanges = true;
                }

                // Only update if there are changes
                if (hasChanges)
                {
                    // Update the user
                    await _userService.UpdateAsync(userId, userToUpdate);
                }

                // Get the updated user
                var updatedUser = await _userService.GetByIdAsync(userId);

                // Map to DTO
                var userDto = new UserDto
                {
                    UserId = updatedUser.UserId,
                    Name = updatedUser.Name,
                    Email = updatedUser.Email ?? string.Empty,
                    PhoneNumber = updatedUser.PhoneNumber ?? string.Empty,
                    Address = updatedUser.Address ?? string.Empty,
                    RoleName = updatedUser.Role?.Name ?? "Customer",
                    ImageURL = updatedUser.ImageURL ?? string.Empty,
                    LoyatyPoint = updatedUser.LoyatyPoint ?? 0.0
                };

                return Ok(new ApiResponse<UserDto>
                {
                    Success = true,
                    Message = hasChanges ? "Cập nhật thông tin người dùng thành công" : "Không có thông tin nào được cập nhật",
                    Data = userDto
                });
            }
            catch (ValidationException ex)
            {
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
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
                _logger.LogError(ex, "Error updating user profile");
                return StatusCode(500, new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Gặp trục trặc khi cập nhật thông tin người dùng"
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
            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null)
                return Unauthorized(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Chưa xác thực, vui lòng đăng nhập"
                });

            int userId = int.Parse(userIdClaim.Value);           
                await _authService.LogoutAsync(userId);
           

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
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Chưa xác thực, vui lòng đăng nhập"
                    });

                int userId = int.Parse(userIdClaim.Value);

                // Verify current password
                var user = await _userService.GetByIdAsync(userId);
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
                await _userService.UpdatePasswordAsync(userId, request.NewPassword);

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
