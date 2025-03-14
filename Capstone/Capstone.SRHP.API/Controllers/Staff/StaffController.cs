using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Staff
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService ?? throw new ArgumentNullException(nameof(staffService));
        }

        /// <summary>
        /// Gets a staff member by their ID
        /// </summary>
        /// <param name="id">The staff ID</param>
        /// <returns>The staff member details wrapped in an ApiResponse</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<StaffDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<StaffDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<StaffDto>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<StaffDto>>> GetStaffById(int id)
        {
            try
            {
                var staff = await _staffService.GetStaffByIdAsync(id);
                var staffDto = staff.Adapt<StaffDto>();

                return Ok(ApiResponse<StaffDto>.SuccessResponse(staffDto, $"Staff with ID {id} retrieved successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<StaffDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ApiResponse<StaffDto>.ErrorResponse($"Error retrieving staff with ID {id}",
                    new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Gets a staff member by their user ID
        /// </summary>
        /// <param name="userId">The user ID</param>
        /// <returns>The staff member details wrapped in an ApiResponse</returns>
        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(ApiResponse<StaffDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<StaffDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<StaffDto>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<StaffDto>>> GetStaffByUserId(int userId)
        {
            try
            {
                var staff = await _staffService.GetStaffByUserIdAsync(userId);
                var staffDto = staff.Adapt<StaffDto>();

                return Ok(ApiResponse<StaffDto>.SuccessResponse(staffDto, $"Staff with User ID {userId} retrieved successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<StaffDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ApiResponse<StaffDto>.ErrorResponse($"Error retrieving staff with User ID {userId}",
                    new List<string> { ex.Message }));
            }
        }

        /// <summary>
        /// Gets all staff members
        /// </summary>
        /// <returns>A list of all staff members wrapped in an ApiResponse</returns>
        [HttpGet("all")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<StaffDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<StaffDto>>), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<IEnumerable<StaffDto>>>> GetAllStaff()
        {
            try
            {
                var staffList = await _staffService.GetAllStaffAsync();
                var staffDtos = staffList.Adapt<IEnumerable<StaffDto>>();


                return Ok(ApiResponse<IEnumerable<StaffDto>>.SuccessResponse(staffDtos, "All staff retrieved successfully"));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ApiResponse<IEnumerable<StaffDto>>.ErrorResponse("Error retrieving all staff",
                    new List<string> { ex.Message }));
            }
        }
    }
}
