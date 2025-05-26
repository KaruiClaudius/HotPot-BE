using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.ManagerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Manager
{
    [Route("api/manager/vehicles")]
    [ApiController]
    [Authorize(Roles = "Manager")]

    public class ManagerVehicleManagementController : ControllerBase
    {
        private readonly IVehicleManagementService _vehicleService;
        private readonly ILogger<ManagerVehicleManagementController> _logger;

        public ManagerVehicleManagementController(
            IVehicleManagementService vehicleService,
            ILogger<ManagerVehicleManagementController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PagedResult<VehicleDTO>>> GetVehicles([FromQuery] VehicleQueryParams queryParams)
        {
            try
            {
                var vehicles = await _vehicleService.GetAllVehiclesAsync(queryParams);
                return Ok(ApiResponse<PagedResult<VehicleDTO>>.SuccessResponse(vehicles, "Vehicles retrieved successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all vehicles");
                return StatusCode(500, ApiResponse<IEnumerable<VehicleDTO>>.ErrorResponse("An error occurred while retrieving vehicles"));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<VehicleDTO>>> GetVehicleById(int id)
        {
            try
            {
                var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
                return Ok(ApiResponse<VehicleDTO>.SuccessResponse(vehicle, "Vehicle retrieved successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<VehicleDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving vehicle with ID {VehicleId}", id);
                return StatusCode(500, ApiResponse<VehicleDTO>.ErrorResponse("An error occurred while retrieving the vehicle"));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<VehicleDTO>>> CreateVehicle([FromBody] CreateVehicleRequest request)
        {
            try
            {
                var vehicle = await _vehicleService.CreateVehicleAsync(request);
                return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.VehicleId },
                    ApiResponse<VehicleDTO>.SuccessResponse(vehicle, "Vehicle created successfully"));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ApiResponse<VehicleDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating new vehicle");
                return StatusCode(500, ApiResponse<VehicleDTO>.ErrorResponse("An error occurred while creating the vehicle"));
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<VehicleDTO>>> UpdateVehicle(int id, [FromBody] UpdateVehicleRequest request)
        {
            try
            {
                var vehicle = await _vehicleService.UpdateVehicleAsync(id, request);
                return Ok(ApiResponse<VehicleDTO>.SuccessResponse(vehicle, "Vehicle updated successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<VehicleDTO>.ErrorResponse(ex.Message));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ApiResponse<VehicleDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating vehicle with ID {VehicleId}", id);
                return StatusCode(500, ApiResponse<VehicleDTO>.ErrorResponse("An error occurred while updating the vehicle"));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteVehicle(int id)
        {
            try
            {
                var result = await _vehicleService.DeleteVehicleAsync(id);
                return Ok(ApiResponse<bool>.SuccessResponse(result, "Vehicle deleted successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting vehicle with ID {VehicleId}", id);
                return StatusCode(500, ApiResponse<bool>.ErrorResponse("An error occurred while deleting the vehicle"));
            }
        }

        [HttpPut("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<VehicleDTO>>> UpdateVehicleStatus(int id, [FromBody] UpdateVehicleStatusRequest request)
        {
            try
            {
                var vehicle = await _vehicleService.UpdateVehicleStatusAsync(id, request.Status);
                return Ok(ApiResponse<VehicleDTO>.SuccessResponse(vehicle, $"Vehicle status updated to {request.Status} successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<VehicleDTO>.ErrorResponse(ex.Message));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ApiResponse<VehicleDTO>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating status for vehicle with ID {VehicleId}", id);
                return StatusCode(500, ApiResponse<VehicleDTO>.ErrorResponse("An error occurred while updating the vehicle status"));
            }
        }

        [HttpGet("available")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<VehicleDTO>>>> GetAvailableVehicles([FromQuery] VehicleType? type = null)
        {
            try
            {
                var vehicles = await _vehicleService.GetAvailableVehiclesAsync(type);
                return Ok(ApiResponse<IEnumerable<VehicleDTO>>.SuccessResponse(vehicles,
                    type.HasValue
                        ? $"Available {type.Value} vehicles retrieved successfully"
                        : "Available vehicles retrieved successfully"));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving available vehicles");
                return StatusCode(500, ApiResponse<IEnumerable<VehicleDTO>>.ErrorResponse("An error occurred while retrieving available vehicles"));
            }
        }

    }
}
