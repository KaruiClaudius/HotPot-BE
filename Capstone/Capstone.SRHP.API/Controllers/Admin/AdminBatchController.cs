using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient;
using Capstone.HPTY.ServiceLayer.Extensions;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/batches")]
    [Authorize(Roles = "Admin")]
    public class AdminBatchController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly ILogger<AdminBatchController> _logger;

        public AdminBatchController(
            IIngredientService ingredientService,
            ILogger<AdminBatchController> logger)
        {
            _ingredientService = ingredientService;
            _logger = logger;
        }


        [HttpGet("ingredient/{ingredientId}")]
        [ProducesResponseType(typeof(ApiResponse<List<IngredientBatchDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<List<IngredientBatchDto>>>> GetIngredientBatches(int ingredientId)
        {
            try
            {
                _logger.LogInformation("Admin retrieving batches for ingredient ID: {IngredientId}", ingredientId);

                // Get the ingredient to access its unit and measurement value
                var ingredient = await _ingredientService.GetIngredientByIdAsync(ingredientId);

                // Get all batches for this ingredient
                var batches = await _ingredientService.GetIngredientBatchesAsync(ingredientId);

                // Map to DTOs
                var batchDtos = batches.Select(b => new IngredientBatchDto
                {
                    IngredientBatchId = b.IngredientBatchId,
                    IngredientId = b.IngredientId,
                    IngredientName = ingredient.Name,
                    InitialQuantity = b.InitialQuantity,
                    RemainingQuantity = b.RemainingQuantity,
                    Unit = ingredient.Unit,
                    MeasurementValue = ingredient.MeasurementValue,
                    BestBeforeDate = b.BestBeforeDate,
                    BatchNumber = b.BatchNumber ?? string.Empty,
                    ReceivedDate = b.ReceivedDate
                }).ToList();

                // Calculate total remaining quantity in physical units
                double totalPhysicalQuantity = batchDtos.Sum(b => b.RemainingQuantity * ingredient.MeasurementValue);

                return Ok(new ApiResponse<List<IngredientBatchDto>>
                {
                    Success = true,
                    Message = $"Retrieved {batchDtos.Count} batches for ingredient '{ingredient.Name}'. Total remaining: {totalPhysicalQuantity} {ingredient.Unit}",
                    Data = batchDtos
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Ingredient not found with ID: {IngredientId}", ingredientId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving batches for ingredient ID: {IngredientId}", ingredientId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve ingredient batches"
                });
            }
        }



        [HttpGet("{batchId}")]
        [ProducesResponseType(typeof(ApiResponse<IngredientBatchDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IngredientBatchDto>>> GetBatchById(int batchId)
        {
            try
            {
                _logger.LogInformation("Admin retrieving batch with ID: {BatchId}", batchId);

                var batch = await _ingredientService.GetBatchByIdAsync(batchId);

                // Get the ingredient to access its unit and measurement value
                var ingredient = await _ingredientService.GetIngredientByIdAsync(batch.IngredientId);

                var batchDto = new IngredientBatchDto
                {
                    IngredientBatchId = batch.IngredientBatchId,
                    IngredientId = batch.IngredientId,
                    IngredientName = ingredient.Name,
                    InitialQuantity = batch.InitialQuantity,
                    RemainingQuantity = batch.RemainingQuantity,
                    Unit = ingredient.Unit,
                    MeasurementValue = ingredient.MeasurementValue,
                    BestBeforeDate = batch.BestBeforeDate,
                    BatchNumber = batch.BatchNumber ?? string.Empty,
                    ReceivedDate = batch.ReceivedDate
                };

                return Ok(new ApiResponse<IngredientBatchDto>
                {
                    Success = true,
                    Message = "Batch retrieved successfully",
                    Data = batchDto
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Batch not found with ID: {BatchId}", batchId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving batch with ID: {BatchId}", batchId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve batch"
                });
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<IngredientBatchDto>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<IngredientBatchDto>>> CreateBatch([FromBody] CreateBatchRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating new batch for ingredient ID: {IngredientId}", request.IngredientId);

                // Validate request
                if (request.TotalAmount <= 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Total amount must be greater than 0"
                    });
                }

                // Get the ingredient to access its measurement value and type
                var ingredient = await _ingredientService.GetIngredientByIdAsync(request.IngredientId);

                // Validate expiry date based on ingredient type
                if (!IngredientTypeExpiryConfig.IsValidExpiryDate(ingredient.IngredientTypeId, request.BestBeforeDate))
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = IngredientTypeExpiryConfig.GetExpiryValidationMessage(ingredient.IngredientTypeId)
                    });
                }

                // Calculate quantity based on total amount and measurement value
                int calculatedQuantity = (int)Math.Floor(request.TotalAmount / ingredient.MeasurementValue);

                if (calculatedQuantity <= 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Calculated quantity must be greater than 0. Check your total amount and measurement value."
                    });
                }

                // Add batch with calculated quantity (not an initial batch)
                var batch = await _ingredientService.AddBatchAsync(
                    request.IngredientId,
                    calculatedQuantity,
                    request.BestBeforeDate,
                    false); // Not an initial batch

                // Map to DTO
                var batchDto = new IngredientBatchDto
                {
                    IngredientBatchId = batch.IngredientBatchId,
                    IngredientId = batch.IngredientId,
                    IngredientName = ingredient.Name,
                    InitialQuantity = batch.InitialQuantity,
                    RemainingQuantity = batch.RemainingQuantity,
                    Unit = ingredient.Unit,
                    MeasurementValue = ingredient.MeasurementValue,
                    BestBeforeDate = batch.BestBeforeDate,
                    BatchNumber = batch.BatchNumber ?? string.Empty,
                    ReceivedDate = batch.ReceivedDate
                };

                return CreatedAtAction(
                    nameof(GetBatchById),
                    new { batchId = batch.IngredientBatchId },
                    new ApiResponse<IngredientBatchDto>
                    {
                        Success = true,
                        Message = $"Batch created successfully with {calculatedQuantity} units ({request.TotalAmount} {ingredient.Unit})",
                        Data = batchDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating batch for ingredient ID: {IngredientId}", request.IngredientId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Ingredient not found with ID: {IngredientId}", request.IngredientId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating batch for ingredient ID: {IngredientId}", request.IngredientId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create batch"
                });
            }
        }
        [HttpPost("multiple")]
        [ProducesResponseType(typeof(ApiResponse<List<IngredientBatchDto>>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<List<IngredientBatchDto>>>> CreateMultipleBatches([FromBody] MultipleBatchRequest request)
        {
            try
            {
                _logger.LogInformation("Admin creating multiple batches for {Count} ingredients", request.Batches.Count);

                // Validate request
                if (request.Batches == null || !request.Batches.Any())
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "No batches provided"
                    });
                }

                // Prepare the batch data
                var batchItems = new List<(int ingredientId, int quantity, DateTime bestBeforeDate)>();
                var ingredientIds = request.Batches.Select(b => b.IngredientId).Distinct().ToList();

                // Get all ingredients in a single query
                var ingredients = new Dictionary<int, Ingredient>();
                foreach (var id in ingredientIds)
                {
                    try
                    {
                        var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
                        ingredients[id] = ingredient;
                    }
                    catch (NotFoundException ex)
                    {
                        return NotFound(new ApiErrorResponse
                        {
                            Status = "Error",
                            Message = ex.Message
                        });
                    }
                }

                // Validate all batches before processing
                var validationErrors = new List<string>();

                foreach (var item in request.Batches)
                {
                    // Validate total amount
                    if (item.TotalAmount <= 0)
                    {
                        validationErrors.Add($"Total amount must be greater than 0 for ingredient '{ingredients[item.IngredientId].Name}' (ID: {item.IngredientId})");
                        continue;
                    }

                    var ingredient = ingredients[item.IngredientId];

                    // Validate expiry date based on ingredient type
                    if (!IngredientTypeExpiryConfig.IsValidExpiryDate(ingredient.IngredientTypeId, item.BestBeforeDate))
                    {
                        int minDays = IngredientTypeExpiryConfig.GetMinExpiryDays(ingredient.IngredientTypeId);
                        int maxDays = IngredientTypeExpiryConfig.GetMaxExpiryDays(ingredient.IngredientTypeId);

                        validationErrors.Add($"Best before date for '{ingredient.Name}' (ID: {item.IngredientId}) must be between {minDays} days and {maxDays} days from now");
                        continue;
                    }

                    // Calculate quantity based on total amount and measurement value
                    int calculatedQuantity = (int)Math.Ceiling(item.TotalAmount / ingredient.MeasurementValue);

                    if (calculatedQuantity <= 0)
                    {
                        validationErrors.Add($"Calculated quantity must be greater than 0 for ingredient '{ingredient.Name}' (ID: {item.IngredientId}). Check your total amount and measurement value.");
                        continue;
                    }

                    batchItems.Add((item.IngredientId, calculatedQuantity, item.BestBeforeDate));
                }

                // If there are validation errors, return them
                if (validationErrors.Any())
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "One or more batches failed validation",
                        Errors = validationErrors
                    });
                }

                // Add all batches in a single transaction
                var createdBatches = await _ingredientService.AddMultipleBatchesAsync(batchItems);

                // Map to DTOs
                var batchDtos = new List<IngredientBatchDto>();
                foreach (var batch in createdBatches)
                {
                    var ingredient = ingredients[batch.IngredientId];

                    var dto = new IngredientBatchDto
                    {
                        IngredientBatchId = batch.IngredientBatchId,
                        IngredientId = batch.IngredientId,
                        IngredientName = ingredient.Name,
                        InitialQuantity = batch.InitialQuantity,
                        RemainingQuantity = batch.RemainingQuantity,
                        Unit = ingredient.Unit,
                        MeasurementValue = ingredient.MeasurementValue,
                        BestBeforeDate = batch.BestBeforeDate,
                        BatchNumber = batch.BatchNumber ?? string.Empty,
                        ReceivedDate = batch.ReceivedDate,
                       
                    };

                    batchDtos.Add(dto);
                }

                return CreatedAtAction(
                    nameof(GetBatchById),
                    new { batchId = createdBatches.FirstOrDefault()?.IngredientBatchId ?? 0 },
                    new ApiResponse<List<IngredientBatchDto>>
                    {
                        Success = true,
                        Message = $"Successfully added {createdBatches.Count} batches for {ingredientIds.Count} different ingredients",
                        Data = batchDtos
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error creating multiple batches");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Ingredient not found");
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating multiple batches");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to create batches"
                });
            }
        }

        [HttpPut("{batchId}")]
        [ProducesResponseType(typeof(ApiResponse<IngredientBatchDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<IngredientBatchDto>>> UpdateBatch(int batchId, [FromBody] UpdateBatchRequest request)
        {
            try
            {
                _logger.LogInformation("Admin updating batch with ID: {BatchId}", batchId);

                // Get existing batch
                var existingBatch = await _ingredientService.GetBatchByIdAsync(batchId);

                // Get the ingredient to access its measurement value
                var ingredient = await _ingredientService.GetIngredientByIdAsync(existingBatch.IngredientId);

                // Calculate quantity if total amount is provided
                int quantity = existingBatch.InitialQuantity;
                if (request.TotalAmount.HasValue)
                {
                    if (request.TotalAmount.Value <= 0)
                    {
                        return BadRequest(new ApiErrorResponse
                        {
                            Status = "Validation Error",
                            Message = "Total amount must be greater than 0"
                        });
                    }

                    quantity = (int)Math.Ceiling(request.TotalAmount.Value / ingredient.MeasurementValue);

                    if (quantity <= 0)
                    {
                        return BadRequest(new ApiErrorResponse
                        {
                            Status = "Validation Error",
                            Message = "Calculated quantity must be greater than 0. Check your total amount and measurement value."
                        });
                    }
                }
                else if (request.Quantity.HasValue)
                {
                    // If direct quantity is provided instead of total amount
                    if (request.Quantity.Value < 0)
                    {
                        return BadRequest(new ApiErrorResponse
                        {
                            Status = "Validation Error",
                            Message = "Quantity cannot be negative"
                        });
                    }
                    quantity = request.Quantity.Value;
                }

                // Validate best before date
                DateTime bestBeforeDate = existingBatch.BestBeforeDate;
                if (request.BestBeforeDate.HasValue)
                {
                    if (request.BestBeforeDate.Value <= DateTime.UtcNow.AddHours(7))
                    {
                        return BadRequest(new ApiErrorResponse
                        {
                            Status = "Validation Error",
                            Message = "Best before date must be in the future"
                        });
                    }
                    bestBeforeDate = request.BestBeforeDate.Value;
                }

                // Update batch
                await _ingredientService.UpdateBatchAsync(
                    batchId,
                    quantity,
                    bestBeforeDate,
                    existingBatch.BatchNumber);

                // Get updated batch
                var updatedBatch = await _ingredientService.GetBatchByIdAsync(batchId);

                // Calculate physical quantity
                double physicalQuantity = updatedBatch.RemainingQuantity * ingredient.MeasurementValue;

                var batchDto = new IngredientBatchDto
                {
                    IngredientBatchId = updatedBatch.IngredientBatchId,
                    IngredientId = updatedBatch.IngredientId,
                    IngredientName = ingredient.Name,
                    InitialQuantity = updatedBatch.InitialQuantity,
                    RemainingQuantity = updatedBatch.RemainingQuantity,
                    Unit = ingredient.Unit,
                    MeasurementValue = ingredient.MeasurementValue,
                    BestBeforeDate = updatedBatch.BestBeforeDate,
                    BatchNumber = updatedBatch.BatchNumber ?? string.Empty,
                    ReceivedDate = updatedBatch.ReceivedDate
                };

                return Ok(new ApiResponse<IngredientBatchDto>
                {
                    Success = true,
                    Message = $"Batch updated successfully. Current remaining: {updatedBatch.RemainingQuantity} units ({physicalQuantity} {ingredient.Unit})",
                    Data = batchDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error updating batch with ID: {BatchId}", batchId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Batch not found with ID: {BatchId}", batchId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating batch with ID: {BatchId}", batchId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to update batch"
                });
            }
        }

        [HttpDelete("{batchId}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<string>>> DeleteBatch(int batchId)
        {
            try
            {
                _logger.LogInformation("Admin deleting batch with ID: {BatchId}", batchId);

                await _ingredientService.DeleteBatchAsync(batchId);

                return Ok(new ApiResponse<string>
                {
                    Success = true,
                    Message = "Batch deleted successfully",
                    Data = $"Batch with ID {batchId} has been deleted"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validation error deleting batch with ID: {BatchId}", batchId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Validation Error",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Batch not found with ID: {BatchId}", batchId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting batch with ID: {BatchId}", batchId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to delete batch"
                });
            }
        }

        [HttpGet("expiring")]
        [ProducesResponseType(typeof(ApiResponse<List<IngredientBatchDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<List<IngredientBatchDto>>>> GetExpiringBatches([FromQuery] int daysThreshold = 7)
        {
            try
            {
                _logger.LogInformation("Admin retrieving batches expiring within {DaysThreshold} days", daysThreshold);

                if (daysThreshold <= 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Validation Error",
                        Message = "Days threshold must be greater than 0"
                    });
                }

                var expiringBatches = await _ingredientService.GetExpiringBatchesAsync(daysThreshold);

                // Get all ingredient IDs from the batches
                var ingredientIds = expiringBatches.Select(b => b.IngredientId).Distinct().ToList();

                // Get all ingredients in a single query
                var ingredients = new Dictionary<int, Ingredient>();
                foreach (var id in ingredientIds)
                {
                    try
                    {
                        var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
                        ingredients[id] = ingredient;
                    }
                    catch (NotFoundException)
                    {
                        // Skip if ingredient not found
                    }
                }

                var batchDtos = expiringBatches.Select(b =>
                {
                    var ingredient = ingredients.ContainsKey(b.IngredientId) ? ingredients[b.IngredientId] : null;

                    return new IngredientBatchDto
                    {
                        IngredientBatchId = b.IngredientBatchId,
                        IngredientId = b.IngredientId,
                        IngredientName = ingredient?.Name ?? "Unknown",
                        InitialQuantity = b.InitialQuantity,
                        RemainingQuantity = b.RemainingQuantity,
                        Unit = ingredient?.Unit ?? "unit",
                        MeasurementValue = ingredient?.MeasurementValue ?? 1.0,
                        BestBeforeDate = b.BestBeforeDate,
                        BatchNumber = b.BatchNumber ?? string.Empty,
                        ReceivedDate = b.ReceivedDate
                    };
                }).ToList();

                return Ok(new ApiResponse<List<IngredientBatchDto>>
                {
                    Success = true,
                    Message = $"Retrieved {batchDtos.Count} batches expiring within {daysThreshold} days",
                    Data = batchDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving expiring batches");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve expiring batches"
                });
            }
        }

        [HttpGet("expired")]
        [ProducesResponseType(typeof(ApiResponse<List<IngredientBatchDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<List<IngredientBatchDto>>>> GetExpiredBatches()
        {
            try
            {
                _logger.LogInformation("Admin retrieving expired batches");

                var expiredBatches = await _ingredientService.GetExpiredBatchesAsync();

                // Get all ingredient IDs from the batches
                var ingredientIds = expiredBatches.Select(b => b.IngredientId).Distinct().ToList();

                // Get all ingredients in a single query
                var ingredients = new Dictionary<int, Ingredient>();
                foreach (var id in ingredientIds)
                {
                    try
                    {
                        var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
                        ingredients[id] = ingredient;
                    }
                    catch (NotFoundException)
                    {
                        // Skip if ingredient not found
                    }
                }

                var batchDtos = expiredBatches.Select(b =>
                {
                    var ingredient = ingredients.ContainsKey(b.IngredientId) ? ingredients[b.IngredientId] : null;

                    return new IngredientBatchDto
                    {
                        IngredientBatchId = b.IngredientBatchId,
                        IngredientId = b.IngredientId,
                        IngredientName = ingredient?.Name ?? "Unknown",
                        InitialQuantity = b.InitialQuantity,
                        RemainingQuantity = b.RemainingQuantity,
                        Unit = ingredient?.Unit ?? "unit",
                        MeasurementValue = ingredient?.MeasurementValue ?? 1.0,
                        BestBeforeDate = b.BestBeforeDate,
                        BatchNumber = b.BatchNumber ?? string.Empty,
                        ReceivedDate = b.ReceivedDate
                    };
                }).ToList();

                return Ok(new ApiResponse<List<IngredientBatchDto>>
                {
                    Success = true,
                    Message = $"Retrieved {batchDtos.Count} expired batches",
                    Data = batchDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving expired batches");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve expired batches"
                });
            }
        }

    }
}
