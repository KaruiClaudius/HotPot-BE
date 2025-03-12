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
    public class AdminUtensilController : ControllerBase
    {
        private readonly IUtensilService _utensilService;
        private readonly ILogger<AdminUtensilController> _logger;

        public AdminUtensilController(IUtensilService utensilService, ILogger<AdminUtensilController> logger)
        {
            _utensilService = utensilService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<PagedResult<UtensilDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<PagedResult<UtensilDto>>>> GetUtensils(
            [FromQuery] string searchTerm = null,
            [FromQuery] int? typeId = null,
            [FromQuery] bool? isAvailable = null,
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
                        Message = "Page number and page size must be greater than 0"
                    });
                }

                _logger.LogInformation("Admin retrieving utensils with filters");

                var pagedUtensils = await _utensilService.GetUtensilsAsync(
                    searchTerm: searchTerm,
                    typeId: typeId,
                    isAvailable: isAvailable,
                    pageNumber: pageNumber,
                    pageSize: pageSize,
                    sortBy: sortBy,
                    ascending: ascending);

                var utensilDtos = pagedUtensils.Items.Select(MapToUtensilDto).ToList();

                var result = new PagedResult<UtensilDto>
                {
                    Items = utensilDtos,
                    PageNumber = pagedUtensils.PageNumber,
                    PageSize = pagedUtensils.PageSize,
                    TotalCount = pagedUtensils.TotalCount
                };

                return Ok(new ApiResponse<PagedResult<UtensilDto>>
                {
                    Success = true,
                    Message = "Utensils retrieved successfully",
                    Data = result
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving utensils");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve utensils"
                });
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<UtensilDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<UtensilDto>>> GetUtensilById(int id)
        {
            try
            {
                _logger.LogInformation("Admin retrieving utensil with ID: {UtensilId}", id);
                var utensil = await _utensilService.GetUtensilByIdAsync(id);
                var utensilDto = MapToUtensilDto(utensil);

                return Ok(new ApiResponse<UtensilDto>
                {
                    Success = true,
                    Message = "Utensil retrieved successfully",
                    Data = utensilDto
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Utensil not found with ID: {UtensilId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving utensil with ID: {UtensilId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve utensil"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<UtensilDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<UtensilDto>>> CreateUtensil([FromBody] CreateUtensilRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new utensil: {UtensilName}", request.Name);

                // Check if we need to create a new type
                if (request.UtensilTypeID <= 0 && !string.IsNullOrWhiteSpace(request.UtensilTypeName))
                {
                    _logger.LogInformation("Creating new utensil type: {TypeName}", request.UtensilTypeName);

                    try
                    {
                        // Create the new type
                        var newType = await _utensilService.CreateUtensilTypeAsync(request.UtensilTypeName);
                        request.UtensilTypeID = newType.UtensilTypeId;

                        _logger.LogInformation("Created new utensil type with ID: {TypeId}", newType.UtensilTypeId);
                    }
                    catch (ValidationException ex)
                    {
                        // If type creation fails due to validation (e.g., duplicate name),
                        // try to find the existing type with that name
                        _logger.LogWarning(ex, "Validation error creating type, checking if it exists: {TypeName}", request.UtensilTypeName);

                        var existingTypes = await _utensilService.GetAllUtensilTypesAsync();
                        var matchingType = existingTypes.FirstOrDefault(t =>
                            t.Name.Equals(request.UtensilTypeName, StringComparison.OrdinalIgnoreCase));

                        if (matchingType != null)
                        {
                            request.UtensilTypeID = matchingType.UtensilTypeId;
                            _logger.LogInformation("Found existing type with ID: {TypeId}", matchingType.UtensilTypeId);
                        }
                        else
                        {
                            // If we can't find a matching type, rethrow the exception
                            throw;
                        }
                    }
                }

                var utensil = new Utensil
                {
                    Name = request.Name,
                    Material = request.Material,
                    Description = request.Description,
                    ImageURL = request.ImageURL,
                    Price = request.Price,
                    Status = request.Status,
                    Quantity = request.Quantity,
                    UtensilTypeID = request.UtensilTypeID
                };

                var createdUtensil = await _utensilService.CreateUtensilAsync(utensil);
                var utensilDto = MapToUtensilDto(createdUtensil);

                return CreatedAtAction(
                    nameof(GetUtensilById),
                    new { id = createdUtensil.UtensilId },
                    new ApiResponse<UtensilDto>
                    {
                        Success = true,
                        Message = "Utensil created successfully",
                        Data = utensilDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating utensil: {UtensilName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating utensil: {UtensilName}", request.Name);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create utensil"
                });
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<UtensilDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<UtensilDto>>> UpdateUtensil(int id, [FromBody] UpdateUtensilRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating utensil with ID: {UtensilId}", id);

                var existingUtensil = await _utensilService.GetUtensilByIdAsync(id);

                // Check if we need to create a new type
                if (request.UtensilTypeID.HasValue && request.UtensilTypeID.Value <= 0 &&
                    !string.IsNullOrWhiteSpace(request.UtensilTypeName))
                {
                    _logger.LogInformation("Creating new utensil type: {TypeName}", request.UtensilTypeName);

                    try
                    {
                        // Create the new type
                        var newType = await _utensilService.CreateUtensilTypeAsync(request.UtensilTypeName);
                        request.UtensilTypeID = newType.UtensilTypeId;

                        _logger.LogInformation("Created new utensil type with ID: {TypeId}", newType.UtensilTypeId);
                    }
                    catch (ValidationException ex)
                    {
                        // If type creation fails due to validation (e.g., duplicate name),
                        // try to find the existing type with that name
                        _logger.LogWarning(ex, "Validation error creating type, checking if it exists: {TypeName}", request.UtensilTypeName);

                        var existingTypes = await _utensilService.GetAllUtensilTypesAsync();
                        var matchingType = existingTypes.FirstOrDefault(t =>
                            t.Name.Equals(request.UtensilTypeName, StringComparison.OrdinalIgnoreCase));

                        if (matchingType != null)
                        {
                            request.UtensilTypeID = matchingType.UtensilTypeId;
                            _logger.LogInformation("Found existing type with ID: {TypeId}", matchingType.UtensilTypeId);
                        }
                        else
                        {
                            // If we can't find a matching type, rethrow the exception
                            throw;
                        }
                    }
                }

                // Update only the properties that are provided
                if (request.Name != null) existingUtensil.Name = request.Name;
                if (request.Material != null) existingUtensil.Material = request.Material;
                if (request.Description != null) existingUtensil.Description = request.Description;
                if (request.ImageURL != null) existingUtensil.ImageURL = request.ImageURL;
                if (request.Price.HasValue) existingUtensil.Price = request.Price.Value;
                if (request.Status.HasValue) existingUtensil.Status = request.Status.Value;
                if (request.Quantity.HasValue) existingUtensil.Quantity = request.Quantity.Value;
                if (request.UtensilTypeID.HasValue) existingUtensil.UtensilTypeID = request.UtensilTypeID.Value;

                await _utensilService.UpdateUtensilAsync(id, existingUtensil);
                var updatedUtensil = await _utensilService.GetUtensilByIdAsync(id);
                var utensilDto = MapToUtensilDto(updatedUtensil);

                return Ok(new ApiResponse<UtensilDto>
                {
                    Success = true,
                    Message = "Utensil updated successfully",
                    Data = utensilDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating utensil with ID: {UtensilId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Utensil not found with ID: {UtensilId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating utensil with ID: {UtensilId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update utensil"
                });
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteUtensil(int id)
        {
            try
            {
                _logger.LogInformation("Admin deleting utensil with ID: {UtensilId}", id);
                await _utensilService.DeleteUtensilAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Utensil deleted successfully",
                    Data = $"Utensil with ID {id} has been deleted"
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Utensil not found with ID: {UtensilId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting utensil with ID: {UtensilId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete utensil"
                });
            }
        }

        [HttpPatch("{id}/status")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> UpdateUtensilStatus(int id, [FromBody] bool status)
        {
            try
            {
                _logger.LogInformation("Admin updating status for utensil with ID: {UtensilId} to {Status}", id, status);
                await _utensilService.UpdateUtensilStatusAsync(id, status);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Utensil status updated successfully",
                    Data = $"Utensil with ID {id} status set to {status}"
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Utensil not found with ID: {UtensilId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating status for utensil with ID: {UtensilId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update utensil status"
                });
            }
        }

        [HttpPatch("{id}/quantity")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> UpdateUtensilQuantity(int id, [FromBody] int quantityChange)
        {
            try
            {
                _logger.LogInformation("Admin updating quantity for utensil with ID: {UtensilId} by {QuantityChange}", id, quantityChange);
                await _utensilService.UpdateUtensilQuantityAsync(id, quantityChange);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Utensil quantity updated successfully",
                    Data = $"Utensil with ID {id} quantity changed by {quantityChange}"
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Utensil not found with ID: {UtensilId}", id);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating quantity for utensil with ID: {UtensilId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating quantity for utensil with ID: {UtensilId}", id);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update utensil quantity"
                });
            }
        }

        private static UtensilDto MapToUtensilDto(Utensil utensil)
        {
            if (utensil == null) return null;

            return new UtensilDto
            {
                UtensilId = utensil.UtensilId,
                Name = utensil.Name,
                Material = utensil.Material,
                Description = utensil.Description,
                ImageURL = utensil.ImageURL,
                Price = utensil.Price,
                Status = utensil.Status,
                Quantity = utensil.Quantity,
                UtensilTypeId = utensil.UtensilTypeID,
                UtensilTypeName = utensil.UtensilType?.Name ?? "Unknown",
                LastMaintainDate = utensil.LastMaintainDate,
                IsAvailable = utensil.Status && utensil.Quantity > 0,
                CreatedAt = utensil.CreatedAt,
                UpdatedAt = utensil.UpdatedAt
            };
        }
    }
}
