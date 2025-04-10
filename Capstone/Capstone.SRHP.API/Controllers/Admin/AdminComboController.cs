using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Combo;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient;
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

        public AdminComboController(IComboService comboService, IIngredientService ingredientService, ILogger<AdminHotpotController> logger)
        {
            _comboService = comboService;
            _ingredientService = ingredientService;
            _logger = logger;
        }



        [HttpGet]
        public async Task<ActionResult<PagedResult<ComboDto>>> GetCombos(
            [FromQuery] string searchTerm = null,
            [FromQuery] bool? isCustomizable = null,
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

                var pagedResult = new PagedResult<ComboDto>
                {
                    Items = result.Items.Select(MapToComboDto).ToList(),
                    TotalCount = result.TotalCount,
                    PageNumber = result.PageNumber,
                    PageSize = result.PageSize
                };

                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error get combo");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ComboDetailDto>> GetById(int id)
        {
            try
            {
                var combo = await _comboService.GetByIdAsync(id);
                if (combo == null)
                    return NotFound(new { message = $"Combo with ID {id} not found" });

                var comboDto = MapToComboDetailDto(combo);

                return Ok(comboDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error get by id combo");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<ActionResult<ComboDto>> Create(CreateComboRequest request)
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
                    HotpotBrothId = request.HotpotBrothID,
                    ImageURLs = request.ImageURLs
                };

                var comboIngredients = request.Ingredients.Select(i => new ComboIngredient
                {
                    IngredientId = i.IngredientID,
                    Quantity = i.Quantity
                }).ToList();

                var createdCombo = await _comboService.CreateComboWithVideoAsync(combo, tutorialVideo, comboIngredients);

                return CreatedAtAction(nameof(GetById), new { id = createdCombo.ComboId }, MapToComboDto(createdCombo));
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating combo");
                return StatusCode(500, new { message = "An error occurred while creating the combo" });
            }
        }


        [HttpPost("customizable")]
        public async Task<ActionResult<ComboDto>> CreateCustomizable(CreateCustomizableComboRequest request)
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
                    IsCustomizable = true,
                    HotpotBrothId = request.HotpotBrothID,
                    ImageURLs = request.ImageURLs
                };

                var allowedTypes = request.AllowedIngredientTypes.Select(t => new ComboAllowedIngredientType
                {
                    IngredientTypeId = t.IngredientTypeId,
                    MinQuantity = t.MinQuantity
                }).ToList();

                var createdCombo = await _comboService.CreateComboWithVideoAsync(combo, tutorialVideo, null, allowedTypes);

                return CreatedAtAction(nameof(GetById), new { id = createdCombo.ComboId }, MapToComboDto(createdCombo));
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error create customize combo");
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
                    return NotFound(new { message = $"Combo with ID {id} not found" });


                // Only update properties that are explicitly provided in the request
                if (!string.IsNullOrEmpty(request.Name))
                {
                    existingCombo.Name = request.Name;
                }

                // For nullable properties, check if they're provided in the request
                if (request.Description != null) // This allows explicitly setting to null or a new value
                {
                    existingCombo.Description = request.Description;
                }

                if (request.Size > 0)
                {
                    existingCombo.Size = request.Size.Value;
                }

                if (request.HotpotBrothID > 0)
                {
                    existingCombo.HotpotBrothId = request.HotpotBrothID.Value;
                }

                if (request.ImageURLs != null) // This allows explicitly setting to null or a new array
                {
                    existingCombo.ImageURLs = request.ImageURLs;
                }

                if (request.TurtorialVideoID.HasValue)
                {
                    existingCombo.TurtorialVideoId = request.TurtorialVideoID.Value;
                }

                await _comboService.UpdateAsync(id, existingCombo);

                return NoContent();
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating combo with ID {ComboId}", id);
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
            catch (ValidationException ex)
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


        private ComboDto MapToComboDto(Combo combo)
        {
            if (combo == null) return null;

            var comboDto = new ComboDto
            {
                ComboId = combo.ComboId,
                Name = combo.Name,
                Description = combo.Description ?? string.Empty,
                Size = combo.Size,
                BasePrice = combo.BasePrice,
                TotalPrice = combo.TotalPrice,
                IsCustomizable = combo.IsCustomizable,
                HotpotBrothID = combo.HotpotBrothId,
                HotpotBrothName = combo.HotpotBroth?.Name ?? "Unknown",
                ImageURLs = combo.ImageURLs ?? new string[0]
            };

            // Only set Ingredients if there are any
            if (combo.ComboIngredients != null && combo.ComboIngredients.Any())
            {
                comboDto.Ingredients = combo.ComboIngredients.Select(ci => new ComboIngredientDto
                {
                    ComboIngredientId = ci.ComboIngredientId,
                    IngredientID = ci.IngredientId,
                    IngredientName = ci.Ingredient?.Name ?? "Unknown",
                    Quantity = ci.Quantity
                }).ToList();
            }

            // Only set AllowedIngredientTypes for customizable combos if there are any
            if (combo.IsCustomizable && combo.AllowedIngredientTypes != null && combo.AllowedIngredientTypes.Any())
            {
                comboDto.AllowedIngredientTypes = combo.AllowedIngredientTypes.Select(ait => new ComboAllowedIngredientTypeDto
                {
                    Id = ait.ComboAllowedIngredientTypeId,
                    IngredientTypeId = ait.IngredientTypeId,
                    IngredientTypeName = ait.IngredientType?.Name ?? "Unknown",
                    MinQuantity = ait.MinQuantity
                }).ToList();
            }

            return comboDto;
        }

        private ComboDetailDto MapToComboDetailDto(Combo combo)
        {
            if (combo == null) return null;

            var comboDetailDto = new ComboDetailDto
            {
                ComboId = combo.ComboId,
                Name = combo.Name,
                Description = combo.Description ?? string.Empty,
                Size = combo.Size,
                BasePrice = combo.BasePrice,
                TotalPrice = combo.TotalPrice,
                IsCustomizable = combo.IsCustomizable,
                HotpotBrothID = combo.HotpotBrothId,
                HotpotBrothName = combo.HotpotBroth?.Name ?? "Unknown",
                AppliedDiscountID = combo.AppliedDiscountId,
                AppliedDiscountPercentage = combo.AppliedDiscount?.DiscountPercentage ?? 0,
                ImageURLs = combo.ImageURLs ?? new string[0],
                TurtorialVideoID = combo.TurtorialVideoId,
                TutorialVideoName = combo.TurtorialVideo?.Name,
                TutorialVideoUrl = combo.TurtorialVideo?.VideoURL,
                CreatedAt = combo.CreatedAt,
                UpdatedAt = (DateTime)combo.UpdatedAt,
                TutorialVideo = combo.TurtorialVideo != null ? new TutorialVideoDto
                {
                    TurtorialVideoId = combo.TurtorialVideo.TurtorialVideoId,
                    Name = combo.TurtorialVideo.Name,
                    Description = combo.TurtorialVideo.Description,
                    VideoURL = combo.TurtorialVideo.VideoURL
                } : null
            };

            // Only set Ingredients if there are any
            if (combo.ComboIngredients != null && combo.ComboIngredients.Any())
            {
                comboDetailDto.Ingredients = combo.ComboIngredients.Select(ci => new ComboIngredientDto
                {
                    ComboIngredientId = ci.ComboIngredientId,
                    IngredientID = ci.IngredientId,
                    IngredientName = ci.Ingredient?.Name ?? "Unknown",
                    Quantity = ci.Quantity
                }).ToList();
            }

            // Only set AllowedIngredientTypes for customizable combos if there are any
            if (combo.IsCustomizable && combo.AllowedIngredientTypes != null && combo.AllowedIngredientTypes.Any())
            {
                comboDetailDto.AllowedIngredientTypes = combo.AllowedIngredientTypes.Select(ait => new ComboAllowedIngredientTypeDto
                {
                    Id = ait.ComboAllowedIngredientTypeId,
                    IngredientTypeId = ait.IngredientTypeId,
                    IngredientTypeName = ait.IngredientType?.Name ?? "Unknown",
                    MinQuantity = ait.MinQuantity
                }).ToList();
            }

            return comboDetailDto;
        }
    }
}