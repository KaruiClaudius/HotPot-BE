using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Auth;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.User;

using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using Capstone.HPTY.ServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin")]
    //[Authorize(Roles = "Admin")]   
    public class AdminUserManagementController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<AdminUserManagementController> _logger;

        public AdminUserManagementController(
            IUserService userService,
            ILogger<AdminUserManagementController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        [HttpGet("users")]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<UserDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<UserDto>>>> GetUsers(
         [FromQuery] string searchTerm = null,
         [FromQuery] int? roleId = null,
         [FromQuery] bool? isActive = null,
         [FromQuery] DateTime? createdAfter = null,
         [FromQuery] DateTime? createdBefore = null,
         [FromQuery] int pageNumber = 1,
         [FromQuery] int pageSize = 10,
         [FromQuery] string sortBy = "Name",
         [FromQuery] bool ascending = true)
        {
            try
            {
                if (pageNumber < 1 || pageSize < 1)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = "Số trang và size trang phải lớn hơn 0"
                    });
                }

                _logger.LogInformation("Admin retrieving users with filters");

                var pagedUsers = await _userService.GetUsersAsync(
                    searchTerm: searchTerm,
                    roleId: roleId,
                    isActive: isActive,
                    createdAfter: createdAfter,
                    createdBefore: createdBefore,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    sortBy: sortBy,
                    ascending: ascending);

                var userDtos = pagedUsers.Items.Select(MapToUserDto).ToList();

                var result = new PagedResult<UserDto>
                {
                    Items = userDtos,
                    PageNumber = pagedUsers.PageNumber,
                    PageSize = pagedUsers.PageSize,
                    TotalCount = pagedUsers.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<UserDto>>
                {
                    Success = true,
                    Message = "Lấy danh sách người dùng thành công",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving users");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Danh sách gặp trục trặc"
                });
            }
        }

        [HttpGet("users/{id}")]
        [ProducesResponseType(typeof(ApiResponse<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<UserDto>>> GetUser(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            var userDto = MapToUserDto(user);

            return Ok(new ApiResponse<UserDto>
            {
                Success = true,
                Message = "Lấy người dùng thành công",
                Data = userDto
            });
        }

        [HttpPost("users")]
        [ProducesResponseType(typeof(ApiResponse<UserDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<UserDto>>> CreateUser([FromBody] CreateUserRequest request)
        {
            try
            {
                var role = await _userService.GetByRoleNameAsync(request.RoleName);
                if (role == null)
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Không thấy vai trò '{request.RoleName}'"
                    });

                var userToCreate = new User
                {
                    Email = request.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Name = request.Name,
                    PhoneNumber = request.PhoneNumber,
                    RoleID = role.RoleId,
                    Address = request.Address
                };

                var createdUser = await _userService.CreateAsync(userToCreate);
                var userDto = MapToUserDto(createdUser);

                return CreatedAtAction(
                    nameof(GetUser),
                    new { id = userDto.UserId },
                    new ApiResponse<UserDto>
                    {
                        Success = true,
                        Message = "tạo người dùng thành công",
                        Data = userDto
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "tạo người dùng gặp trục trặc");
                throw;
            }
        }

        [HttpPut("users/{id}")]
        [ProducesResponseType(typeof(ApiResponse<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<UserDto>>> UpdateUser(int id, [FromBody] UpdateUserRequest request)
        {
            try
            {
                var existingUser = await _userService.GetByIdAsync(id);
                if (existingUser == null)
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"không thấy người dùng"
                    });

                var role = await _userService.GetByRoleNameAsync(request.RoleName);
                if (role == null)
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Không thấy vai trò '{request.RoleName}'"
                    });

                existingUser.Email = request.Email;
                existingUser.Name = request.Name;
                existingUser.PhoneNumber = request.PhoneNumber;
                existingUser.Address = request.Address;
                existingUser.RoleID = role.RoleId;
                existingUser.ImageURL = request.ImageURL;

                await _userService.UpdateAsync(id, existingUser);
                var updatedUser = await _userService.GetByIdAsync(id);
                var userDto = MapToUserDto(updatedUser);

                return Ok(new ApiResponse<UserDto>
                {
                    Success = true,
                    Message = "cập nhật người dùng thành công",
                    Data = userDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "cập nhật người dùng gặp sự cố");
                throw;
            }
        }

        [HttpDelete("users/{id}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteUser(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Message = "xoá thành công",
                Data = true
            });
        }


        private static UserDto MapToUserDto(User user)
        {
            if (user == null) return null;

            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                RoleName = user.Role?.Name ?? "Customer",
                ImageURL = user.ImageURL ?? string.Empty
            };
        }

    }
}
