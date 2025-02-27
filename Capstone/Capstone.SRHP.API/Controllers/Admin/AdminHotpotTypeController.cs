using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Hotpot;
using Capstone.HPTY.ServiceLayer.Interfaces.HotpotService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/hotpot-types")]
    [Authorize(Roles = "Admin")]
    public class AdminHotpotTypeController : ControllerBase
    {
        private readonly IHotpotTypeService _hotpotTypeService;
        private readonly ILogger<AdminHotpotTypeController> _logger;

        public AdminHotpotTypeController(IHotpotTypeService hotpotTypeService, ILogger<AdminHotpotTypeController> logger)
        {
            _hotpotTypeService = hotpotTypeService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<HotpotTypeDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<HotpotTypeDto>>>> GetAllHotpotTypes()
        {
            try
            {
                _logger.LogInformation("Admin retrieving all hotpot types");

                var types = await _hotpotTypeService.GetAllAsync();
                var typeDtos = new List<HotpotTypeDto>();

                foreach (var type in types)
                {
                    var hotpotCount = await _hotpotTypeService.GetHotpotCountByTypeAsync(type.HotpotTypeId);

                    typeDtos.Add(new HotpotTypeDto
                    {
                        HotpotTypeId = type.HotpotTypeId,
                        Name = type.Name,
                        CreatedAt = type.CreatedAt,
                        UpdatedAt = type.UpdatedAt,
                        HotpotCount = hotpotCount
                    });
                }

                return Ok(new ApiResponse<IEnumerable<HotpotTypeDto>>
                {
                    Success = true,
                    Message = "Hotpot types retrieved successfully",
                    Data = typeDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot types");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve hotpot types"
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<HotpotTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<HotpotTypeDto>>> GetHotpotTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving hotpot type with ID: {TypeId}", id);

                var type = await _hotpotTypeService.GetByIdAsync(id);

                if (type == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Hotpot type with ID {id} not found"
                    });
                }

                var hotpotCount = await _hotpotTypeService.GetHotpotCountByTypeAsync(id);

                var typeDto = new HotpotTypeDto
                {
                    HotpotTypeId = type.HotpotTypeId,
                    Name = type.Name,
                    CreatedAt = type.CreatedAt,
                    UpdatedAt = type.UpdatedAt,
                    HotpotCount = hotpotCount
                };

                return Ok(new ApiResponse<HotpotTypeDto>
                {
                    Success = true,
                    Message = "Hotpot type retrieved successfully",
                    Data = typeDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving hotpot type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve hotpot type"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<HotpotTypeDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<HotpotTypeDto>>> CreateHotpotType([FromBody] HotpotTypeRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new hotpot type: {TypeName}", request.Name);

                var hotpotType = new HotpotType
                {
                    Name = request.Name
                };

                var createdType = await _hotpotTypeService.CreateAsync(hotpotType);

                var typeDto = new HotpotTypeDto
                {
                    HotpotTypeId = createdType.HotpotTypeId,
                    Name = createdType.Name,
                    CreatedAt = createdType.CreatedAt,
                    UpdatedAt = createdType.UpdatedAt,
                    HotpotCount = 0
                };

                return CreatedAtAction(
                    nameof(GetHotpotTypeById),
                    new { id = createdType.HotpotTypeId },
                    new ApiResponse<HotpotTypeDto>
                    {
                        Success = true,
                        Message = "Hotpot type created successfully",
                        Data = typeDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating hotpot type: {TypeName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating hotpot type: {TypeName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create hotpot type"
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<HotpotTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<HotpotTypeDto>>> UpdateHotpotType(int id, [FromBody] HotpotTypeRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating hotpot type with ID: {TypeId}", id);

                var existingType = await _hotpotTypeService.GetByIdAsync(id);
                if (existingType == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Hotpot type with ID {id} not found"
                    });
                }

                existingType.Name = request.Name;

                await _hotpotTypeService.UpdateAsync(id, existingType);

                var hotpotCount = await _hotpotTypeService.GetHotpotCountByTypeAsync(id);

                var typeDto = new HotpotTypeDto
                {
                    HotpotTypeId = existingType.HotpotTypeId,
                    Name = existingType.Name,
                    CreatedAt = existingType.CreatedAt,
                    UpdatedAt = existingType.UpdatedAt,
                    HotpotCount = hotpotCount
                };

                return Ok(new ApiResponse<HotpotTypeDto>
                {
                    Success = true,
                    Message = "Hotpot type updated successfully",
                    Data = typeDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating hotpot type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotpot type not found with ID: {TypeId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating hotpot type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update hotpot type"
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteHotpotType(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting hotpot type with ID: {TypeId}", id);

                await _hotpotTypeService.DeleteAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Hotpot type deleted successfully",
                    Data = $"Hotpot type with ID {id} has been deleted"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting hotpot type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Hotpot type not found with ID: {TypeId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting hotpot type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete hotpot type"
                });
            }
        }
    }
}
