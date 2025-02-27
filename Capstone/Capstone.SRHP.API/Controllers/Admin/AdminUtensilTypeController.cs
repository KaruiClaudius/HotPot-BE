using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Utensil;
using Capstone.HPTY.ServiceLayer.Interfaces.UtensilService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/utensil-types")]
    [Authorize(Roles = "Admin")]
    public class AdminUtensilTypeController : ControllerBase
    {
        private readonly IUtensilTypeService _utensilTypeService;
        private readonly ILogger<AdminUtensilTypeController> _logger;

        public AdminUtensilTypeController(IUtensilTypeService utensilTypeService, ILogger<AdminUtensilTypeController> logger)
        {
            _utensilTypeService = utensilTypeService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<UtensilTypeDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<UtensilTypeDto>>>> GetAllUtensilTypes()
        {
            try
            {
                _logger.LogInformation("Admin retrieving all utensil types");

                var types = await _utensilTypeService.GetAllAsync();
                var typeDtos = new List<UtensilTypeDto>();

                foreach (var type in types)
                {
                    var utensilCount = await _utensilTypeService.GetUtensilCountByTypeAsync(type.UtensilTypeId);

                    typeDtos.Add(new UtensilTypeDto
                    {
                        UtensilTypeId = type.UtensilTypeId,
                        Name = type.Name,
                        CreatedAt = type.CreatedAt,
                        UpdatedAt = type.UpdatedAt,
                        UtensilCount = utensilCount
                    });
                }

                return Ok(new ApiResponse<IEnumerable<UtensilTypeDto>>
                {
                    Success = true,
                    Message = "Utensil types retrieved successfully",
                    Data = typeDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving utensil types");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve utensil types"
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<UtensilTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<UtensilTypeDto>>> GetUtensilTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving utensil type with ID: {TypeId}", id);

                var type = await _utensilTypeService.GetByIdAsync(id);

                if (type == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Utensil type with ID {id} not found"
                    });
                }

                var utensilCount = await _utensilTypeService.GetUtensilCountByTypeAsync(id);

                var typeDto = new UtensilTypeDto
                {
                    UtensilTypeId = type.UtensilTypeId,
                    Name = type.Name,
                    CreatedAt = type.CreatedAt,
                    UpdatedAt = type.UpdatedAt,
                    UtensilCount = utensilCount
                };

                return Ok(new ApiResponse<UtensilTypeDto>
                {
                    Success = true,
                    Message = "Utensil type retrieved successfully",
                    Data = typeDto
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving utensil type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve utensil type"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<UtensilTypeDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<UtensilTypeDto>>> CreateUtensilType([FromBody] UtensilTypeRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new utensil type: {TypeName}", request.Name);

                var utensilType = new UtensilType
                {
                    Name = request.Name
                };

                var createdType = await _utensilTypeService.CreateAsync(utensilType);

                var typeDto = new UtensilTypeDto
                {
                    UtensilTypeId = createdType.UtensilTypeId,
                    Name = createdType.Name,
                    CreatedAt = createdType.CreatedAt,
                    UpdatedAt = createdType.UpdatedAt,
                    UtensilCount = 0
                };

                return CreatedAtAction(
                    nameof(GetUtensilTypeById),
                    new { id = createdType.UtensilTypeId },
                    new ApiResponse<UtensilTypeDto>
                    {
                        Success = true,
                        Message = "Utensil type created successfully",
                        Data = typeDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating utensil type: {TypeName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating utensil type: {TypeName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create utensil type"
                });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<UtensilTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<UtensilTypeDto>>> UpdateUtensilType(int id, [FromBody] UtensilTypeRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating utensil type with ID: {TypeId}", id);

                var existingType = await _utensilTypeService.GetByIdAsync(id);
                if (existingType == null)
                {
                    return NotFound(new ApiErrorResponse
                    {
                        Status = "Error",
                        Message = $"Utensil type with ID {id} not found"
                    });
                }

                existingType.Name = request.Name;

                await _utensilTypeService.UpdateAsync(id, existingType);

                var utensilCount = await _utensilTypeService.GetUtensilCountByTypeAsync(id);

                var typeDto = new UtensilTypeDto
                {
                    UtensilTypeId = existingType.UtensilTypeId,
                    Name = existingType.Name,
                    CreatedAt = existingType.CreatedAt,
                    UpdatedAt = existingType.UpdatedAt,
                    UtensilCount = utensilCount
                };

                return Ok(new ApiResponse<UtensilTypeDto>
                {
                    Success = true,
                    Message = "Utensil type updated successfully",
                    Data = typeDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating utensil type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Utensil type not found with ID: {TypeId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating utensil type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update utensil type"
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteUtensilType(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting utensil type with ID: {TypeId}", id);

                await _utensilTypeService.DeleteAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Utensil type deleted successfully",
                    Data = $"Utensil type with ID {id} has been deleted"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting utensil type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Utensil type not found with ID: {TypeId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting utensil type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete utensil type"
                });
            }
        }
    }
}
