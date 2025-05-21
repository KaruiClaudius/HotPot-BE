using System.ComponentModel.DataAnnotations;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Combo;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Video;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/admin/combo")]
    [Authorize(Roles = "Admin")]
    public class AdminComboController : ControllerBase
    {
        private readonly IComboService _comboService;
        private readonly IIngredientService _ingredientService;
        private readonly ILogger<AdminHotpotController> _logger;

        public AdminComboController(IComboService comboService, ILogger<AdminHotpotController> logger, IIngredientService ingredientService)
        {
            _comboService = comboService;
            _logger = logger;
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetCombos(
            [FromQuery] string searchTerm = null,
            [FromQuery, Required] bool isCustomizable = false,
            [FromQuery] bool activeOnly = true,
            [FromQuery] int? minSize = null,
            [FromQuery] int? maxSize = null,
            [FromQuery] decimal? minPrice = null,
            [FromQuery] decimal? maxPrice = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10,
            [FromQuery] string sortBy = "Name",
            [FromQuery] bool ascending = true)
        {
            try
            {
                var result = await _comboService.GetCombosAsync(
                    searchTerm, isCustomizable, activeOnly, minSize, maxSize,
                    minPrice, maxPrice, pageNumber, pageSize, sortBy, ascending);

                // Return different data structures based on isCustomizable
                if (isCustomizable)
                {
                    var pagedResult = new PagedResult<CustomizableComboDto>
                    {
                        Items = new List<CustomizableComboDto>(), // Initialize as a List<T>
                        TotalCount = result.TotalCount,
                        PageNumber = result.PageNumber,
                        PageSize = result.PageSize
                    };

                    // Map each combo individually to handle the async mapping
                    foreach (var combo in result.Items)
                    {
                        var mappedCombo = await MapToCustomizableComboDto(combo);
                        ((List<CustomizableComboDto>)pagedResult.Items).Add(mappedCombo);
                    }

                    return Ok(pagedResult);
                }
                else
                {
                    var pagedResult = new PagedResult<RegularComboDto>
                    {
                        Items = result.Items.Select(MapToRegularComboDto).ToList(),
                        TotalCount = result.TotalCount,
                        PageNumber = result.PageNumber,
                        PageSize = result.PageSize
                    };
                    return Ok(pagedResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting combos");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetById(int id)
        {
            try
            {
                var combo = await _comboService.GetByIdAsync(id);
                if (combo == null)
                    return NotFound(new { message = $"Không tìm thấy combo với ID {id}" });

                var detailDto = await MapToComboDetailDto(combo);
                return Ok(detailDto);
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting combo detail by id {ComboId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<RegularComboDto>> Create(CreateComboRequest request)
        {
            try
            {
                // Create tutorial video if provided
                TurtorialVideo tutorialVideo = null;
                if (request.TutorialVideo != null)
                {
                    tutorialVideo = new TurtorialVideo
                    {
                        Name = request.TutorialVideo.Name,
                        Description = request.TutorialVideo.Description,
                        VideoURL = request.TutorialVideo.VideoURL
                    };
                }

                var combo = new Combo
                {
                    Name = request.Name,
                    Description = request.Description,
                    Size = request.Size,
                    IsCustomizable = false,
                    ImageURLs = request.ImageURLs
                };

                var comboIngredients = request.Ingredients.Select(i => new ComboIngredient
                {
                    IngredientId = i.IngredientID,
                    Quantity = i.Quantity
                }).ToList();

                var createdCombo = await _comboService.CreateComboWithVideoAsync(combo, tutorialVideo, comboIngredients);

                return CreatedAtAction(nameof(GetById), new { id = createdCombo.ComboId }, MapToRegularComboDto(createdCombo));
            }
            catch (ModelLayer.Exceptions.ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating combo");
                return StatusCode(500, new { message = "Đã xảy ra lỗi khi tạo combo" });
            }
        }


        [HttpPost("customizable")]
        public async Task<ActionResult<CustomizableComboDto>> CreateCustomizable(CreateCustomizableComboRequest request)
        {
            try
            {
                string groupIdentifier = request.GroupIdentifier;
                bool isFirstInGroup = string.IsNullOrEmpty(groupIdentifier);

                // If this is the first combo in a group, generate a new group identifier
                if (isFirstInGroup)
                {
                    groupIdentifier = await _comboService.GenerateGroupIdentifierAsync(request.Name);
                }
                else
                {
                    // Verify that the group exists
                    var existingGroupCombos = await _comboService.GetCombosByGroupIdentifierAsync(groupIdentifier);
                    if (!existingGroupCombos.Any())
                    {
                        return BadRequest(new { message = $"Không tìm thấy nhóm combo hiện có với định danh '{groupIdentifier}'" });
                    }

                    // Verify that no combo in this group has the same size
                    if (existingGroupCombos.Any(c => c.Size == request.Size))
                    {
                        return BadRequest(new { message = $"Một combo với kích thước {request.Size} đã tồn tại trong nhóm này" });
                    }
                }

                TurtorialVideo tutorialVideo = null;
                if (request.TutorialVideo != null)
                {
                    tutorialVideo = new TurtorialVideo
                    {
                        Name = request.TutorialVideo.Name,
                        Description = request.TutorialVideo.Description,
                        VideoURL = request.TutorialVideo.VideoURL
                    };
                }

                var combo = new Combo
                {
                    Name = request.Name,
                    Description = groupIdentifier, // Set the group identifier here
                    Size = request.Size,
                    IsCustomizable = true,
                    ImageURLs = request.ImageURLs
                };

                var allowedTypes = request.AllowedIngredientTypes.Select(t => new ComboAllowedIngredientType
                {
                    IngredientTypeId = t.IngredientTypeId,
                    MinQuantity = t.MinQuantity
                }).ToList();

                var createdCombo = await _comboService.CreateComboWithVideoAsync(combo, tutorialVideo, null, allowedTypes);

                var mappedCombo = await MapToCustomizableComboDto(createdCombo);
                return CreatedAtAction(nameof(GetById), new { id = createdCombo.ComboId }, mappedCombo);
            }
            catch (ModelLayer.Exceptions.ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating customizable combo");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateComboRequest request)
        {
            try
            {
                var existingCombo = await _comboService.GetByIdAsync(id);
                if (existingCombo == null)
                    return NotFound(new { message = $"Không tìm thấy combo với ID {id}" });

                // Verify this is not a customizable combo
                if (existingCombo.IsCustomizable)
                    return BadRequest(new { message = "Endpoint này chỉ dành cho các combo thông thường. Hãy sử dụng /customizable/{id} cho các combo tùy chỉnh." });

                // Update base properties
                UpdateComboBaseProperties(existingCombo, request);

                // Update description if provided
                if (request.Description != null)
                {
                    existingCombo.Description = request.Description;
                }

                // Create ingredients list if provided in the request
                List<ComboIngredient> ingredients = null;
                if (request.Ingredients != null && request.Ingredients.Any())
                {
                    ingredients = request.Ingredients.Select(i => new ComboIngredient
                    {
                        IngredientId = i.IngredientID,
                        Quantity = i.Quantity
                    }).ToList();
                }

                // Pass the ingredients to the service
                await _comboService.UpdateAsync(id, existingCombo, null, ingredients, null);

                return NoContent();
            }
            catch (ModelLayer.Exceptions.ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating regular combo with ID {ComboId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPut("customizable/{id}")]
        public async Task<ActionResult> UpdateCustomizable(int id, UpdateCustomizeComboRequest request)
        {
            try
            {
                var existingCombo = await _comboService.GetByIdAsync(id);
                if (existingCombo == null)
                    return NotFound(new { message = $"Không tìm thấy combo với ID {id}" });

                // Verify this is a customizable combo
                if (!existingCombo.IsCustomizable)
                    return BadRequest(new { message = "Endpoint này chỉ dành cho các combo tùy chỉnh. Hãy sử dụng endpoint cập nhật thông thường cho các combo không tùy chỉnh." });

                // Update base properties
                UpdateComboBaseProperties(existingCombo, request);

                // Update group identifier if provided
                if (request.GroupIdentifier != null)
                {
                    // If changing group identifier, verify the new group exists
                    if (!string.IsNullOrEmpty(request.GroupIdentifier) &&
                        request.GroupIdentifier != existingCombo.Description)
                    {
                        var existingGroupCombos = await _comboService.GetCombosByGroupIdentifierAsync(request.GroupIdentifier);
                        if (!existingGroupCombos.Any())
                        {
                            return BadRequest(new { message = $"Không tìm thấy nhóm combo hiện có với định danh '{request.GroupIdentifier}'" });
                        }

                        // Verify that no combo in this group has the same size
                        if (existingGroupCombos.Any(c => c.Size == (request.Size ?? existingCombo.Size) && c.ComboId != id))
                        {
                            return BadRequest(new { message = $"Một combo với kích thước {request.Size ?? existingCombo.Size} đã tồn tại trong nhóm này" });
                        }
                    }

                    existingCombo.Description = request.GroupIdentifier;
                }

                // Create allowed ingredient types list if provided in the request
                List<ComboAllowedIngredientType> allowedTypes = null;
                if (request.AllowedIngredientTypes != null && request.AllowedIngredientTypes.Any())
                {
                    allowedTypes = request.AllowedIngredientTypes.Select(t => new ComboAllowedIngredientType
                    {
                        IngredientTypeId = t.IngredientTypeId,
                        MinQuantity = t.MinQuantity
                    }).ToList();
                }

                // Pass the allowed types to the service
                await _comboService.UpdateAsync(id, existingCombo, null, null, allowedTypes);

                return NoContent();
            }
            catch (ModelLayer.Exceptions.ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating customizable combo with ID {ComboId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _comboService.DeleteAsync(id);
                return NoContent();
            }
            catch (ModelLayer.Exceptions.ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error delete combo");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("group/{groupIdentifier}")]
        public async Task<ActionResult<IEnumerable<CustomizableComboDto>>> GetCombosByGroup(string groupIdentifier)
        {
            try
            {
                var combos = await _comboService.GetCombosByGroupIdentifierAsync(groupIdentifier);
                if (!combos.Any())
                    return NotFound(new { message = $"Không tìm thấy combo nào với định danh nhóm '{groupIdentifier}'" });

                var comboDtos = new List<CustomizableComboDto>();
                foreach (var combo in combos)
                {
                    comboDtos.Add(await MapToCustomizableComboDto(combo));
                }

                return Ok(comboDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting combos by group identifier '{GroupIdentifier}'", groupIdentifier);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        private void UpdateComboBaseProperties(Combo combo, UpdateRequest request)
        {
            if (!string.IsNullOrEmpty(request.Name))
            {
                combo.Name = request.Name;
            }

            if (request.Size.HasValue && request.Size > 0)
            {
                combo.Size = request.Size.Value;
            }

            if (request.ImageURLs != null)
            {
                combo.ImageURLs = request.ImageURLs;
            }

            if (request.TurtorialVideoID.HasValue)
            {
                combo.TurtorialVideoId = request.TurtorialVideoID.Value;
            }
        }

        private ComboDto MapToBaseComboDto(Combo combo)
        {
            if (combo == null) return null;

            return new ComboDto
            {
                ComboId = combo.ComboId,
                Name = combo.Name,
                Size = combo.Size,
                BasePrice = combo.BasePrice,
                TotalPrice = combo.TotalPrice,
                ImageURLs = combo.ImageURLs ?? Array.Empty<string>()
            };
        }

        private async Task<ComboDetailDto> MapToComboDetailDto(Combo combo)
        {
            if (combo == null) return null;

            var dto = new ComboDetailDto
            {
                ComboId = combo.ComboId,
                Name = combo.Name,
                Size = combo.Size,
                BasePrice = combo.BasePrice,
                TotalPrice = combo.TotalPrice,
                ImageURLs = combo.ImageURLs ?? Array.Empty<string>(),
                AppliedDiscountID = combo.AppliedDiscountId,
                AppliedDiscountPercentage = combo.AppliedDiscount?.DiscountPercentage ?? 0,
                TurtorialVideoID = combo.TurtorialVideoId,
                TutorialVideoName = combo.TurtorialVideo?.Name,
                TutorialVideoUrl = combo.TurtorialVideo?.VideoURL,
                CreatedAt = combo.CreatedAt,
                UpdatedAt = combo.UpdatedAt ?? DateTime.UtcNow.AddHours(7),
                IsCustomizable = combo.IsCustomizable,
                TutorialVideo = combo.TurtorialVideo != null ? new TutorialVideoDto
                {
                    TurtorialVideoId = combo.TurtorialVideo.TurtorialVideoId,
                    Name = combo.TurtorialVideo.Name,
                    Description = combo.TurtorialVideo.Description,
                    VideoURL = combo.TurtorialVideo.VideoURL
                } : null
            };

            // Populate type-specific properties
            if (combo.IsCustomizable)
            {
                // Customizable combo properties
                dto.GroupIdentifier = combo.Description ?? string.Empty;
                dto.AllowedIngredientTypes = combo.AllowedIngredientTypes?
                    .Where(ait => !ait.IsDelete)
                    .Select(ait => new ComboAllowedIngredientTypeDto
                    {
                        Id = ait.ComboAllowedIngredientTypeId,
                        IngredientTypeId = ait.IngredientTypeId,
                        IngredientTypeName = ait.IngredientType?.Name ?? "Unknown",
                        MinQuantity = ait.MinQuantity
                    })
                    .ToList() ?? new List<ComboAllowedIngredientTypeDto>();

                // Check if this is part of a group
                if (!string.IsNullOrEmpty(combo.Description))
                {
                    var groupCombos = await _comboService.GetCombosByGroupIdentifierAsync(combo.Description);

                    dto.IsPartOfGroup = groupCombos.Count() > 1;

                    if (dto.IsPartOfGroup)
                    {
                        dto.GroupVariants = groupCombos
                            .Where(c => c.ComboId != combo.ComboId) // Exclude the current combo
                            .Select(c => new CustomizableComboVariantDto
                            {
                                ComboId = c.ComboId,
                                Name = c.Name,
                                Size = c.Size,
                            })
                            .ToList();
                    }
                }
            }
            else
            {
                // Regular combo properties
                dto.Description = combo.Description ?? string.Empty;
                dto.Ingredients = combo.ComboIngredients?
                    .Where(ci => !ci.IsDelete)
                    .Select(ci => new ComboIngredientDto
                    {
                        ComboIngredientId = ci.ComboIngredientId,
                        IngredientID = ci.IngredientId,
                        IngredientName = ci.Ingredient?.Name ?? "Unknown",
                        Quantity = ci.Quantity,
                        ImageURL = ci.Ingredient?.ImageURL,
                        TotalPrice = _ingredientService.GetCurrentPriceAsync(ci.IngredientId).Result
                    })
                    .ToList() ?? new List<ComboIngredientDto>();
            }

            return dto;
        }

        private RegularComboDto MapToRegularComboDto(Combo combo)
        {
            if (combo == null) return null;

            return new RegularComboDto
            {
                ComboId = combo.ComboId,
                Name = combo.Name,
                Description = combo.Description ?? string.Empty,
                Size = combo.Size,
                BasePrice = combo.BasePrice,
                TotalPrice = combo.TotalPrice,
                ImageURLs = combo.ImageURLs ?? Array.Empty<string>(),
                Ingredients = combo.ComboIngredients?
                    .Where(ci => !ci.IsDelete)
                    .Select(ci => new ComboIngredientDto
                    {
                        ComboIngredientId = ci.ComboIngredientId,
                        IngredientID = ci.IngredientId,
                        IngredientName = ci.Ingredient?.Name ?? "Unknown",
                        Quantity = ci.Quantity,
                    })
                    .ToList() ?? new List<ComboIngredientDto>()
            };
        }

        private async Task<CustomizableComboDto> MapToCustomizableComboDto(Combo combo)
        {
            if (combo == null) return null;

            var dto = new CustomizableComboDto
            {
                ComboId = combo.ComboId,
                Name = combo.Name,
                GroupIdentifier = combo.Description ?? string.Empty,
                Size = combo.Size,
                BasePrice = combo.BasePrice,
                TotalPrice = combo.TotalPrice,
                ImageURLs = combo.ImageURLs ?? Array.Empty<string>(),
                AllowedIngredientTypes = combo.AllowedIngredientTypes?
                    .Where(ait => !ait.IsDelete)
                    .Select(ait => new ComboAllowedIngredientTypeDto
                    {
                        Id = ait.ComboAllowedIngredientTypeId,
                        IngredientTypeId = ait.IngredientTypeId,
                        IngredientTypeName = ait.IngredientType?.Name ?? "Unknown",
                        MinQuantity = ait.MinQuantity,
                    })
                    .ToList() ?? new List<ComboAllowedIngredientTypeDto>()
            };

            // Check if this is part of a group
            if (!string.IsNullOrEmpty(combo.Description))
            {
                var groupCombos = await _comboService.GetCombosByGroupIdentifierAsync(combo.Description);

                dto.IsPartOfGroup = groupCombos.Count() > 1;

                if (dto.IsPartOfGroup)
                {
                    dto.GroupVariants = groupCombos
                        .Where(c => c.ComboId != combo.ComboId) // Exclude the current combo
                        .Select(c => new CustomizableComboVariantDto
                        {
                            ComboId = c.ComboId,
                            Name = c.Name,
                            Size = c.Size,
                        })
                        .ToList();
                }
            }

            return dto;
        }
    }
}