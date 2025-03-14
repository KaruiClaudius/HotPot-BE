using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Equipment;
using Capstone.HPTY.ServiceLayer.Interfaces.StaffService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Staff
{
    [Route("api/staff/equipments")]
    [ApiController]
    public class StaffEquipmentController : ControllerBase
    {
        private readonly IStaffEquipmentService _staffEquipmentService;
        private readonly ILogger<StaffEquipmentController> _logger;

        public StaffEquipmentController(
            IStaffEquipmentService staffEquipmentService,
            ILogger<StaffEquipmentController> logger)
        {
            _staffEquipmentService = staffEquipmentService;
            _logger = logger;
        }
     
        /// Get all rental equipment
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<EquipmentRetrievalDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IEnumerable<EquipmentRetrievalDto>>>> GetAllRentalEquipment()
        {
            try
            {
                _logger.LogInformation("Staff retrieving all rental equipment");

                var equipment = await _staffEquipmentService.GetAllRentalEquipmentAsync();

                return Ok(new ApiResponse<IEnumerable<EquipmentRetrievalDto>>
                {
                    Success = true,
                    Message = "Rental equipment retrieved successfully",
                    Data = equipment
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving rental equipment");

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve rental equipment"
                });
            }
        }

        /// Get details of a specific rental equipment
        [HttpGet("{equipmentType}/{equipmentId}")]
        [ProducesResponseType(typeof(ApiResponse<EquipmentRetrievalDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<EquipmentRetrievalDto>>> GetRentalEquipmentDetails(
            string equipmentType, int equipmentId)
        {
            try
            {
                _logger.LogInformation("Staff retrieving details for {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);

                var equipment = await _staffEquipmentService.GetRentalEquipmentDetailsAsync(equipmentId, equipmentType);

                return Ok(new ApiResponse<EquipmentRetrievalDto>
                {
                    Success = true,
                    Message = "Equipment details retrieved successfully",
                    Data = equipment
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Equipment not found: {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);

                return NotFound(new ApiErrorResponse
                {
                    Status = "Not Found",
                    Message = ex.Message
                });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid equipment type: {EquipmentType}", equipmentType);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Bad Request",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving equipment details for {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve equipment details"
                });
            }
        }

        /// Log an inspection for returned equipment
        [HttpPost("inspection")]
        [ProducesResponseType(typeof(ApiResponse<EquipmentInspectionResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<EquipmentInspectionResponse>>> LogEquipmentInspection(
            [FromBody] EquipmentInspectionRequest request)
        {
            try
            {
                _logger.LogInformation("Staff logging inspection for {EquipmentType} with ID: {EquipmentId}",
                    request.EquipmentType, request.EquipmentId);

                var result = await _staffEquipmentService.LogEquipmentInspectionAsync(request);

                return Ok(new ApiResponse<EquipmentInspectionResponse>
                {
                    Success = true,
                    Message = "Equipment inspection logged successfully",
                    Data = result
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Equipment not found: {EquipmentType} with ID: {EquipmentId}",
                    request.EquipmentType, request.EquipmentId);

                return NotFound(new ApiErrorResponse
                {
                    Status = "Not Found",
                    Message = ex.Message
                });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid equipment type: {EquipmentType}", request.EquipmentType);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Bad Request",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error logging inspection for {EquipmentType} with ID: {EquipmentId}",
                    request.EquipmentType, request.EquipmentId);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to log equipment inspection"
                });
            }
        }

        /// Update the availability status of equipment
        [HttpPut("{equipmentType}/{equipmentId}/availability")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> UpdateEquipmentAvailability(
            string equipmentType,
            int equipmentId,
            [FromBody] UpdateAvailabilityRequest request)
        {
            try
            {
                _logger.LogInformation("Staff updating availability for {EquipmentType} with ID: {EquipmentId} to {IsAvailable}",
                    equipmentType, equipmentId, request.IsAvailable);

                var result = await _staffEquipmentService.UpdateEquipmentAvailabilityAsync(
                    equipmentId, equipmentType, request.IsAvailable);

                return Ok(new ApiResponse<bool>
                {
                    Success = true,
                    Message = $"Equipment availability updated successfully to {(request.IsAvailable ? "available" : "unavailable")}",
                    Data = result
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Equipment not found: {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);

                return NotFound(new ApiErrorResponse
                {
                    Status = "Not Found",
                    Message = ex.Message
                });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid equipment type: {EquipmentType}", equipmentType);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Bad Request",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating availability for {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update equipment availability"
                });
            }
        }

        /// Get inspection history for a specific equipment
        [HttpGet("{equipmentType}/{equipmentId}/inspections")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<EquipmentInspectionResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IEnumerable<EquipmentInspectionResponse>>>> GetEquipmentInspectionHistory(
            string equipmentType, int equipmentId)
        {
            try
            {
                _logger.LogInformation("Staff retrieving inspection history for {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);

                var inspections = await _staffEquipmentService.GetEquipmentInspectionHistoryAsync(equipmentId, equipmentType);

                return Ok(new ApiResponse<IEnumerable<EquipmentInspectionResponse>>
                {
                    Success = true,
                    Message = "Equipment inspection history retrieved successfully",
                    Data = inspections
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Equipment not found: {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);

                return NotFound(new ApiErrorResponse
                {
                    Status = "Not Found",
                    Message = ex.Message
                });
            }
            catch (ArgumentException ex)
            {
                _logger.LogWarning(ex, "Invalid equipment type: {EquipmentType}", equipmentType);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Bad Request",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving inspection history for {EquipmentType} with ID: {EquipmentId}",
                    equipmentType, equipmentId);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve equipment inspection history"
                });
            }
        }

    }
}

