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

        [HttpGet("all")]
        [ProducesResponseType(typeof(ApiResponse<List<BatchSummaryDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<List<BatchSummaryDto>>>> GetAllBatchesSummary()
        {
            try
            {
                _logger.LogInformation("Admin retrieving all batch summaries");

                // Get all batch summaries
                var batchSummaries = await _ingredientService.GetAllBatchesSummaryAsync();

                return Ok(new ApiResponse<List<BatchSummaryDto>>
                {
                    Success = true,
                    Message = $"Đã lấy {batchSummaries.Count} lô hàng",
                    Data = batchSummaries
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy tất cả lô hàng");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy tất cả lô hàng"
                });
            }
        }

        [HttpGet("batch-number/{batchNumber}")]
        [ProducesResponseType(typeof(ApiResponse<List<IngredientBatchDto>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<List<IngredientBatchDto>>>> GetBatchesByBatchNumber(string batchNumber)
        {
            try
            {
                _logger.LogInformation("Admin retrieving batches with batch number: {BatchNumber}", batchNumber);

                // Get batches with the specified batch number
                var batches = await _ingredientService.GetBatchesByBatchNumberAsync(batchNumber);

                // Map to DTOs
                var batchDtos = new List<IngredientBatchDto>();

                foreach (var batch in batches)
                {
                    var ingredient = batch.Ingredient;

                    var batchDto = new IngredientBatchDto
                    {
                        IngredientBatchId = batch.IngredientBatchId,
                        IngredientId = batch.IngredientId,
                        IngredientName = ingredient?.Name ?? "Unknown",
                        InitialQuantity = batch.InitialQuantity,
                        RemainingQuantity = batch.RemainingQuantity,
                        ProvideCompany = batch.ProvideCompany,
                        Unit = ingredient?.Unit ?? "unit",
                        MeasurementValue = ingredient?.MeasurementValue ?? 1.0,
                        BestBeforeDate = batch.BestBeforeDate,
                        BatchNumber = batch.BatchNumber ?? string.Empty,
                        ReceivedDate = batch.ReceivedDate
                    };

                    batchDtos.Add(batchDto);
                }

                // Calculate total quantities
                double totalInitialPhysicalQuantity = 0;
                double totalRemainingPhysicalQuantity = 0;

                foreach (var batchDto in batchDtos)
                {
                    totalInitialPhysicalQuantity += batchDto.InitialQuantity * batchDto.MeasurementValue;
                    totalRemainingPhysicalQuantity += batchDto.RemainingQuantity * batchDto.MeasurementValue;
                }

                return Ok(new ApiResponse<List<IngredientBatchDto>>
                {
                    Success = true,
                    Message = $"Đã lấy {batchDtos.Count} lô hàng với số lô '{batchNumber}'. " +
                              $"Tổng ban đầu: {totalInitialPhysicalQuantity} {batchDtos.FirstOrDefault()?.Unit ?? "unit"}, " +
                              $"Tổng còn lại: {totalRemainingPhysicalQuantity} {batchDtos.FirstOrDefault()?.Unit ?? "unit"}",
                    Data = batchDtos
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Không tìm thấy lô hàng với số lô: {BatchNumber}", batchNumber);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Lỗi xác thực khi lấy lô hàng với số lô: {BatchNumber}", batchNumber);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy lô hàng với số lô: {BatchNumber}", batchNumber);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy lô hàng"
                });
            }
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
                    ProvideCompany = b.ProvideCompany,
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
                    Message = $"Đã lấy {batchDtos.Count} lô hàng cho nguyên liệu '{ingredient.Name}'. Tổng còn lại: {totalPhysicalQuantity} {ingredient.Unit}",
                    Data = batchDtos
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Không tìm thấy nguyên liệu với ID: {IngredientId}", ingredientId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy lô hàng cho nguyên liệu ID: {IngredientId}", ingredientId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy lô hàng nguyên liệu"
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
                    ProvideCompany = batch.ProvideCompany,
                    Unit = ingredient.Unit,
                    MeasurementValue = ingredient.MeasurementValue,
                    BestBeforeDate = batch.BestBeforeDate,
                    BatchNumber = batch.BatchNumber ?? string.Empty,
                    ReceivedDate = batch.ReceivedDate
                };

                return Ok(new ApiResponse<IngredientBatchDto>
                {
                    Success = true,
                    Message = "Lô hàng đã được lấy thành công",
                    Data = batchDto
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Không tìm thấy lô hàng với ID: {BatchId}", batchId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy lô hàng với ID: {BatchId}", batchId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy lô hàng"
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
                        Status = "Lỗi xác thực",
                        Message = "Tổng số tiền phải lớn hơn 0"
                    });
                }
                // Get the ingredient to access its measurement value and type
                var ingredient = await _ingredientService.GetIngredientByIdAsync(request.IngredientId);

                // Validate expiry date based on ingredient type
                if (!IngredientTypeExpiryConfig.IsValidExpiryDate(ingredient.IngredientTypeId, request.BestBeforeDate))
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Lỗi xác thực",
                        Message = IngredientTypeExpiryConfig.GetExpiryValidationMessage(ingredient.IngredientTypeId)
                    });
                }


                // Check if the total amount divides evenly by the measurement value
                var remainder = request.TotalAmount % ingredient.MeasurementValue;
                int calculatedQuantity = (int)Math.Floor(request.TotalAmount / ingredient.MeasurementValue);


                if (calculatedQuantity <= 0)
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Lỗi xác thực",
                        Message = "Số lượng tính toán phải lớn hơn 0. Kiểm tra tổng số tiền và giá trị đo lường của bạn."
                    });
                }

                if (remainder > 0)
                {
                    // Calculate the nearest valid amounts (lower and higher)
                    var lowerValidAmount = calculatedQuantity * ingredient.MeasurementValue;
                    var higherValidAmount = (calculatedQuantity + 1) * ingredient.MeasurementValue;

                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Lỗi xác thực",
                        Message = $"Số lượng {request.TotalAmount} {ingredient.Unit} không chia hết cho đơn vị đo {ingredient.MeasurementValue} {ingredient.Unit}. " +
                                  $"Vui lòng sử dụng số lượng hợp lệ như {lowerValidAmount} {ingredient.Unit} hoặc {higherValidAmount} {ingredient.Unit}."
                    });
                }


                // Add batch with calculated quantity (not an initial batch)
                var batch = await _ingredientService.AddBatchAsync(
                    request.IngredientId,
                    calculatedQuantity,
                    request.BestBeforeDate,
                    request.ProvideCompany,
                    false); // Not an initial batch

                // Map to DTO
                var batchDto = new IngredientBatchDto
                {
                    IngredientBatchId = batch.IngredientBatchId,
                    IngredientId = batch.IngredientId,
                    IngredientName = ingredient.Name,
                    InitialQuantity = batch.InitialQuantity,
                    RemainingQuantity = batch.RemainingQuantity,
                    ProvideCompany = batch.ProvideCompany,
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
                        Message = $"Lô hàng đã được tạo thành công với {calculatedQuantity} đơn vị ({request.TotalAmount} {ingredient.Unit})",
                        Data = batchDto
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Lỗi xác thực khi tạo lô hàng cho nguyên liệu ID: {IngredientId}", request.IngredientId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Không tìm thấy nguyên liệu với ID: {IngredientId}", request.IngredientId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo lô hàng cho nguyên liệu ID: {IngredientId}", request.IngredientId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể tạo lô hàng"
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
                        Message = "Lô không được trống"
                    });
                }

                // Prepare the batch data
                var batchItems = new List<(int ingredientId, int quantity, DateTime bestBeforeDate, string? provideCompany)>();
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
                        validationErrors.Add($"Tổng số tiền phải lớn hơn 0 cho nguyên liệu '{ingredients[item.IngredientId].Name}' (ID: {item.IngredientId})");
                        continue;
                    }

                    var ingredient = ingredients[item.IngredientId];

                    // Validate expiry date based on ingredient type
                    if (!IngredientTypeExpiryConfig.IsValidExpiryDate(ingredient.IngredientTypeId, item.BestBeforeDate))
                    {
                        int minDays = IngredientTypeExpiryConfig.GetMinExpiryDays(ingredient.IngredientTypeId);
                        int maxDays = IngredientTypeExpiryConfig.GetMaxExpiryDays(ingredient.IngredientTypeId);

                        validationErrors.Add($"Ngày hết hạn cho '{ingredient.Name}' (ID: {item.IngredientId}) phải nằm trong khoảng từ {minDays} ngày đến {maxDays} ngày kể từ bây giờ");
                        continue;
                    }

                    // Calculate quantity based on total amount and measurement value
                    var remainder = item.TotalAmount % ingredient.MeasurementValue;
                    int calculatedQuantity = (int)Math.Ceiling(item.TotalAmount / ingredient.MeasurementValue);

                    if (calculatedQuantity <= 0)
                    {
                        validationErrors.Add($"Số lượng tính toán phải lớn hơn 0 cho nguyên liệu '{ingredient.Name}' (ID: {item.IngredientId}). Kiểm tra tổng số tiền và giá trị đo lường của bạn.");
                        continue;
                    }

                    if (remainder > 0)
                    {
                        // Calculate the nearest valid amounts (lower and higher)
                        var lowerValidAmount = calculatedQuantity * ingredient.MeasurementValue;
                        var higherValidAmount = (calculatedQuantity + 1) * ingredient.MeasurementValue;

                        validationErrors.Add($"Số lượng {item.TotalAmount} {ingredient.Unit} cho nguyên liệu '{ingredient.Name}' không chia hết cho đơn vị đo {ingredient.MeasurementValue} {ingredient.Unit}. " +
                                            $"Vui lòng sử dụng số lượng hợp lệ như {lowerValidAmount} {ingredient.Unit} hoặc {higherValidAmount} {ingredient.Unit}.");
                        continue;
                    }

                    

                    batchItems.Add((item.IngredientId, calculatedQuantity, item.BestBeforeDate, item.ProvideCompany));
                }

                // If there are validation errors, return them
                if (validationErrors.Any())
                {
                    return BadRequest(new ApiErrorResponse
                    {
                        Status = "Lỗi xác thực",
                        Message = "Một hoặc nhiều lô hàng không đạt yêu cầu xác thực",
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
                        ProvideCompany = batch.ProvideCompany,
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
                        Message = $"Đã thêm thành công {createdBatches.Count} lô hàng cho {ingredientIds.Count} nguyên liệu khác nhau",
                        Data = batchDtos
                    });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Lỗi xác thực khi tạo nhiều lô hàng");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Không tìm thấy nguyên liệu");
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi tạo nhiều lô hàng");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể tạo lô hàng"
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
                            Status = "Lỗi xác thực",
                            Message = "Tổng số tiền phải lớn hơn 0"
                        });
                    }

                    quantity = (int)Math.Ceiling(request.TotalAmount.Value / ingredient.MeasurementValue);

                    if (quantity <= 0)
                    {
                        return BadRequest(new ApiErrorResponse
                        {
                            Status = "Lỗi xác thực",
                            Message = "Số lượng tính toán phải lớn hơn 0. Kiểm tra tổng số tiền và giá trị đo lường của bạn."
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
                            Status = "Lỗi xác thực",
                            Message = "Số lượng không thể là số âm"
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
                            Status = "Lỗi xác thực",
                            Message = "Ngày hết hạn phải là ngày trong tương lai"
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
                    ProvideCompany = updatedBatch.ProvideCompany,
                    Unit = ingredient.Unit,
                    MeasurementValue = ingredient.MeasurementValue,
                    BestBeforeDate = updatedBatch.BestBeforeDate,
                    BatchNumber = updatedBatch.BatchNumber ?? string.Empty,
                    ReceivedDate = updatedBatch.ReceivedDate
                };

                return Ok(new ApiResponse<IngredientBatchDto>
                {
                    Success = true,
                    Message = $"Lô hàng đã được cập nhật thành công. Số lượng còn lại hiện tại: {updatedBatch.RemainingQuantity} đơn vị ({physicalQuantity} {ingredient.Unit})",
                    Data = batchDto
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Lỗi xác thực khi cập nhật lô hàng với ID: {BatchId}", batchId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Không tìm thấy lô hàng với ID: {BatchId}", batchId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi cập nhật lô hàng với ID: {BatchId}", batchId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể cập nhật lô hàng"
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
                    Message = "Lô hàng đã được xóa thành công",
                    Data = $"Lô hàng với ID {batchId} đã được xóa"
                });
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Lỗi xác thực khi xóa lô hàng với ID: {BatchId}", batchId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi xác thực",
                    Message = ex.Message
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Không tìm thấy lô hàng với ID: {BatchId}", batchId);
                return NotFound(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi xóa lô hàng với ID: {BatchId}", batchId);
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể xóa lô hàng"
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
                        Status = "Lỗi xác thực",
                        Message = "Ngưỡng ngày phải lớn hơn 0"
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
                        ProvideCompany = b.ProvideCompany,
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
                    Message = $"Đã lấy {batchDtos.Count} lô hàng hết hạn trong vòng {daysThreshold} ngày",
                    Data = batchDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy các lô hàng sắp hết hạn");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy các lô hàng sắp hết hạn"
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
                        ProvideCompany = b.ProvideCompany,
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
                    Message = $"Đã lấy {batchDtos.Count} lô hàng đã hết hạn",
                    Data = batchDtos
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy các lô hàng đã hết hạn");
                return BadRequest(new ApiErrorResponse
                {
                    Status = "Lỗi",
                    Message = "Không thể lấy các lô hàng đã hết hạn"
                });
            }
        }

    }
}
