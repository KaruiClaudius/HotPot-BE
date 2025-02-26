using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Auth;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces;
using Capstone.HPTY.ServiceLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin")]
    [Authorize(Roles = "Admin")]   
    public class AdminUserManagementController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly ILogger<AdminUserManagementController> _logger;

        public AdminUserManagementController(
            IUserService userService,
            IRoleService roleService,
            ILogger<AdminUserManagementController> logger)
        {
            _userService = userService;
            _roleService = roleService;
            _logger = logger;
        }


        [HttpGet("users")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserDto>>>> GetAllUsers()
        {
            var users = await _userService.GetAllAsync();
            var userDtos = users.Select(MapToUserDto);

            return Ok(new ApiResponse<IEnumerable<UserDto>>
            {
                Success = true,
                Message = "Users retrieved successfully",
                Data = userDtos
            });
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
                Message = "User retrieved successfully",
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
                var role = await _roleService.GetByNameAsync(request.RoleName);
                if (role == null)
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Role '{request.RoleName}' not found"
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

                // Get role-specific data
                //var roleData = await _userService.GetRoleSpecificDataAsync(createdUser.Id);

                return CreatedAtAction(
                    nameof(GetUser),
                    new { id = userDto.UserId },
                    new ApiResponse<UserDto>
                    {
                        Success = true,
                        Message = "User created successfully",
                        Data = userDto
                    });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating user");
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
                        Message = $"User with ID {id} not found"
                    });

                var role = await _roleService.GetByNameAsync(request.RoleName);
                if (role == null)
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Role '{request.RoleName}' not found"
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
                    Message = "User updated successfully",
                    Data = userDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user");
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
                Message = "User deleted successfully",
                Data = true
            });
        }


        [HttpGet("users/by-role/{roleId}")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<UserDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<UserDto>>>> GetUsersByRole(int roleId)
        {
            var users = await _userService.GetByRoleAsync(roleId);
            var userDtos = users.Select(MapToUserDto);
            return Ok(new ApiResponse<IEnumerable<UserDto>>
            {
                Success = true,
                Message = "Users retrieved successfully",
                Data = userDtos
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

        //private StaffDto MapToStaffDto(Staff staff)
        //{
        //    if (staff == null) return null;

        //    return new StaffDto
        //    {
        //        Id = staff.StaffId,
        //        User = MapToUserDto(staff.User),
        //        WorkShifts = staff.WorkShifts,
        //        ShippingOrders = staff.ShippingOrders
        //    };
        //}

        //private ManagerDto MapToManagerDto(Manager manager)
        //{
        //    if (manager == null) return null;

        //    return new ManagerDto
        //    {
        //        Id = manager.ManagerId,
        //        User = MapToUserDto(manager.User),
        //        WorkShifts = manager.WorkShifts
        //    };
        //}
    }
}
