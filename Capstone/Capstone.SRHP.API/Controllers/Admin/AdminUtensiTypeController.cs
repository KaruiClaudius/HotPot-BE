using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.User;
using Capstone.HPTY.ServiceLayer.DTOs.Utensil;
using Capstone.HPTY.ServiceLayer.Interfaces.UtensilService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/utensils")]
    [Authorize(Roles = "Admin")]
    public class AdminUtensiTypeController : ControllerBase
    {
        private readonly IUtensilService _utensilService;
        private readonly ILogger<AdminUtensiTypeController> _logger;

        public AdminUtensiTypeController(IUtensilService utensilService, ILogger<AdminUtensiTypeController> logger)
        {
            _utensilService = utensilService;
            _logger = logger;
        }


        [HttpGet("types")]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<UtensilTypeDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<UtensilTypeDto>>>> GetUtensilTypes()
        {
            try
            {
                _logger.LogInformation("Admin retrieving all utensil types");

                var types = await _utensilService.GetAllUtensilTypesAsync();

                // Get counts for each type
                var typeIds = types.Select(t => t.UtensilTypeId).ToList();
                var counts = await _utensilService.GetUtensilCountsByTypesAsync(typeIds);

                var typeDtos = types.Select(t => new UtensilTypeDto
                {
                    UtensilTypeId = t.UtensilTypeId,
                    Name = t.Name,
                    UtensilCount = counts.ContainsKey(t.UtensilTypeId) ? counts[t.UtensilTypeId] : 0
                }).ToList();

                return Ok(new ApiResponse<IEnumerable<UtensilTypeDto>>
                {
                    Success = true,
                    Message = "Lấy danh sách loại dụng cụ thành công",
                    Data = typeDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving utensil types");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Lấy danh sách loại dụng cụ gặp trục trặc"
                });
            }
        }

        [HttpPost("types")]
        [ProducesResponseType(typeof(ApiResponse<UtensilTypeDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<UtensilTypeDto>>> CreateUtensilType([FromBody] CreateUtensilTypeRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new utensil type: {TypeName}", request.Name);

                var createdType = await _utensilService.CreateUtensilTypeAsync(request.Name);

                var typeDto = new UtensilTypeDto
                {
                    UtensilTypeId = createdType.UtensilTypeId,
                    Name = createdType.Name,
                    UtensilCount = 0
                };

                return CreatedAtAction(
                    nameof(GetUtensilTypes),
                    new ApiResponse<UtensilTypeDto>
                    {
                        Success = true,
                        Message = "Tạo loại dụng cụ thành công",
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
                    Message = "Tạo loại dụng cụ gặp trục trặc"
                });
            }
        }

        [HttpDelete("types/{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteUtensilType(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting utensil type with ID: {TypeId}", id);
                await _utensilService.DeleteUtensilTypeAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Xoá thành công",
                    Data = $"Loại dụng cụ với ID {id} đã bị xoá"
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
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting utensil type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting utensil type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Xoá gặp trục trặc"
                });
            }
        }

        [HttpGet("types/{id}")]
        [ProducesResponseType(typeof(ApiResponse<UtensilTypeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<UtensilTypeDto>>> GetUtensilTypeById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving utensil type with ID: {TypeId}", id);
                var type = await _utensilService.GetUtensilTypeByIdAsync(id);

                // Get count of utensils for this type
                var counts = await _utensilService.GetUtensilCountsByTypesAsync(new[] { id });

                var typeDto = new UtensilTypeDto
                {
                    UtensilTypeId = type.UtensilTypeId,
                    Name = type.Name,
                    UtensilCount = counts.ContainsKey(id) ? counts[id] : 0
                };

                return Ok(new ApiResponse<UtensilTypeDto>
                {
                    Success = true,
                    Message = "Lấy loại dụng cụ thành công",
                    Data = typeDto
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
                _logger.LogError(ex, "Error retrieving utensil type with ID: {TypeId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Lấy loại dụng cụ gặp trục trặc"
                });
            }
        }
    }
}
