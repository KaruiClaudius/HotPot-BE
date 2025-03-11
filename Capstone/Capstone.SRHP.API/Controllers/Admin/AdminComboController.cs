using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Combo;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient;
using Capstone.HPTY.ServiceLayer.DTOs.Video;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminComboController : ControllerBase
    {
        private readonly IComboService _comboService;
        private readonly IIngredientService _ingredientService;

        public AdminComboController(IComboService comboService, IIngredientService ingredientService)
        {
            _comboService = comboService;
            _ingredientService = ingredientService;
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
                    HotpotBrothID = request.HotpotBrothID,
                    ImageURLs = request.ImageURLs
                };

                var comboIngredients = request.Ingredients.Select(i => new ComboIngredient
                {
                    IngredientID = i.IngredientID,
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
                return StatusCode(500, new { message = ex.Message });
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
                    HotpotBrothID = request.HotpotBrothID,
                    ImageURLs = request.ImageURLs
                };

                var allowedTypes = request.AllowedIngredientTypes.Select(t => new ComboAllowedIngredientType
                {
                    IngredientTypeId = t.IngredientTypeId,
                    MaxQuantity = t.MaxQuantity
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

                existingCombo.Name = request.Name;
                existingCombo.Description = request.Description;
                existingCombo.Size = request.Size;
                existingCombo.HotpotBrothID = request.HotpotBrothID;
                existingCombo.ImageURLs = request.ImageURLs;

                // Update tutorial video ID if provided
                if (request.TurtorialVideoID.HasValue)
                {
                    existingCombo.TurtorialVideoID = request.TurtorialVideoID.Value;
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
                return StatusCode(500, new { message = ex.Message });
            }
        }



        //[HttpGet("{comboId}/allowed-ingredient-types")]
        //public async Task<ActionResult<IEnumerable<ComboAllowedIngredientTypeDto>>> GetAllowedIngredientTypes(int comboId)
        //{
        //    try
        //    {
        //        var allowedTypes = await _comboService.GetAllowedIngredientTypesAsync(comboId);
        //        var allowedTypeDtos = allowedTypes.Select(t => new ComboAllowedIngredientTypeDto
        //        {
        //            Id = t.ComboAllowedIngredientTypeId,
        //            IngredientTypeId = t.IngredientTypeId,
        //            IngredientTypeName = t.IngredientType?.Name ?? "Unknown",
        //            MaxQuantity = t.MaxQuantity
        //        }).ToList();

        //        return Ok(allowedTypeDtos);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(new { message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        //[HttpPost("{id}/images")]
        //public async Task<ActionResult> UploadComboImages(int id, [FromForm] List<IFormFile> images)
        //{
        //    try
        //    {
        //        var combo = await _comboService.GetByIdAsync(id);
        //        if (combo == null)
        //            return NotFound(new { message = $"Combo with ID {id} not found" });

        //        // List to store uploaded image URLs
        //        var imageUrls = new List<string>();

        //        // Add existing images if any
        //        if (combo.ImageURLs != null)
        //        {
        //            imageUrls.AddRange(combo.ImageURLs);
        //        }

        //        // Process each uploaded file
        //        foreach (var image in images)
        //        {
        //            if (image.Length > 0)
        //            {
        //                // Generate a unique filename
        //                var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(image.FileName)}";

        //                // Define the path where to save the file
        //                var filePath = Path.Combine("wwwroot", "images", "combos", fileName);

        //                // Ensure directory exists
        //                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        //                // Save the file
        //                using (var stream = new FileStream(filePath, FileMode.Create))
        //                {
        //                    await image.CopyToAsync(stream);
        //                }

        //                // Add the URL to the list
        //                var url = $"/images/combos/{fileName}";
        //                imageUrls.Add(url);
        //            }
        //        }

        //        // Update the combo with the new image URLs
        //        combo.ImageURLs = imageUrls.ToArray();
        //        await _comboService.UpdateAsync(id, combo);

        //        return Ok(new { message = "Images uploaded successfully", imageUrls = combo.ImageURLs });
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(new { message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        //[HttpGet("{comboId}/ingredients/{ingredientTypeId}")]
        //public async Task<ActionResult<IEnumerable<IngredientDto>>> GetAvailableIngredientsForType(int comboId, int ingredientTypeId)
        //{
        //    try
        //    {
        //        var ingredients = await _comboService.GetAvailableIngredientsForTypeAsync(comboId, ingredientTypeId);

        //        // Get all ingredient IDs
        //        var ingredientIds = ingredients.Select(i => i.IngredientId).ToList();

        //        // Get current prices for all ingredients in a single query
        //        var currentPrices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

        //        var ingredientDtos = ingredients.Select(i => new IngredientDto
        //        {
        //            IngredientId = i.IngredientId,
        //            Name = i.Name,
        //            Description = i.Description,
        //            Price = currentPrices.TryGetValue(i.IngredientId, out var price) ? price : 0,
        //            Quantity = i.Quantity,
        //            IngredientTypeID = i.IngredientTypeID,
        //            IngredientTypeName = i.IngredientType?.Name ?? "Unknown"
        //        }).ToList();

        //        return Ok(ingredientDtos);
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(new { message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        //[HttpGet("{comboId}/price/{size}")]
        //public async Task<ActionResult<decimal>> CalculatePrice(int comboId, int size)
        //{
        //    try
        //    {
        //        var price = await _comboService.CalculateTotalPriceAsync(comboId, size);
        //        return Ok(new { price });
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(new { message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        //[HttpGet("{comboId}/ingredients")]
        //public async Task<ActionResult<IEnumerable<ComboIngredientDto>>> GetComboIngredients(int comboId)
        //{
        //    try
        //    {
        //        var ingredients = await _comboService.GetComboIngredientsAsync(comboId);
        //        var ingredientDtos = ingredients.Select(ci => new ComboIngredientDto
        //        {
        //            ComboIngredientId = ci.ComboIngredientId,
        //            IngredientID = ci.IngredientID,
        //            IngredientName = ci.Ingredient?.Name ?? "Unknown",
        //            Quantity = ci.Quantity
        //        }).ToList();

        //        return Ok(ingredientDtos);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}


       

        //[HttpDelete("{id}/images")]
        //public async Task<ActionResult> DeleteComboImages(int id, [FromBody] DeleteImagesRequest request)
        //{
        //    try
        //    {
        //        var combo = await _comboService.GetByIdAsync(id);
        //        if (combo == null)
        //            return NotFound(new { message = $"Combo with ID {id} not found" });

        //        if (combo.ImageURLs == null || combo.ImageURLs.Length == 0)
        //            return BadRequest(new { message = "Combo has no images to delete" });

        //        // Filter out the URLs to delete
        //        var remainingUrls = combo.ImageURLs
        //            .Where(url => !request.ImageURLs.Contains(url))
        //            .ToArray();

        //        // Update the combo with the remaining URLs
        //        combo.ImageURLs = remainingUrls;
        //        await _comboService.UpdateAsync(id, combo);

        //        // Optionally, delete the physical files
        //        foreach (var url in request.ImageURLs)
        //        {
        //            if (url.StartsWith("/images/"))
        //            {
        //                var filePath = Path.Combine("wwwroot", url.TrimStart('/'));
        //                if (System.IO.File.Exists(filePath))
        //                {
        //                    System.IO.File.Delete(filePath);
        //                }
        //            }
        //        }

        //        return Ok(new { message = "Images deleted successfully", imageUrls = combo.ImageURLs });
        //    }
        //    catch (ValidationException ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //    catch (NotFoundException ex)
        //    {
        //        return NotFound(new { message = ex.Message });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        private ComboDto MapToComboDto(Combo combo)
        {
            if (combo == null) return null;

            return new ComboDto
            {
                ComboId = combo.ComboId,
                Name = combo.Name,
                Description = combo.Description ?? string.Empty,
                Size = combo.Size,
                BasePrice = combo.BasePrice,
                TotalPrice = combo.TotalPrice,
                IsCustomizable = combo.IsCustomizable,
                HotpotBrothID = combo.HotpotBrothID,
                HotpotBrothName = combo.HotpotBroth?.Name ?? "Unknown",
                AppliedDiscountID = combo.AppliedDiscountID,
                AppliedDiscountPercentage = combo.AppliedDiscount?.DiscountPercentage ?? 0,
                ImageURLs = combo.ImageURLs ?? new string[0],
                TurtorialVideoID = combo.TurtorialVideoID,
                TutorialVideoName = combo.TurtorialVideo?.Name,
                TutorialVideoUrl = combo.TurtorialVideo?.VideoURL,
                Ingredients = combo.ComboIngredients?.Select(ci => new ComboIngredientDto
                {
                    ComboIngredientId = ci.ComboIngredientId,
                    IngredientID = ci.IngredientID,
                    IngredientName = ci.Ingredient?.Name ?? "Unknown",
                    Quantity = ci.Quantity
                }).ToList() ?? new List<ComboIngredientDto>(),
                CreatedAt = combo.CreatedAt,
                UpdatedAt = (DateTime)combo.UpdatedAt
            };
        }

        private ComboDetailDto MapToComboDetailDto(Combo combo)
        {
            if (combo == null) return null;

            return new ComboDetailDto
            {
                ComboId = combo.ComboId,
                Name = combo.Name,
                Description = combo.Description ?? string.Empty,
                Size = combo.Size,
                BasePrice = combo.BasePrice,
                TotalPrice = combo.TotalPrice,
                IsCustomizable = combo.IsCustomizable,
                HotpotBrothID = combo.HotpotBrothID,
                HotpotBrothName = combo.HotpotBroth?.Name ?? "Unknown",
                AppliedDiscountID = combo.AppliedDiscountID,
                AppliedDiscountPercentage = combo.AppliedDiscount?.DiscountPercentage ?? 0,
                ImageURLs = combo.ImageURLs ?? new string[0],
                TurtorialVideoID = combo.TurtorialVideoID,
                TutorialVideo = combo.TurtorialVideo != null ? new TutorialVideoDto
                {
                    TurtorialVideoId = combo.TurtorialVideo.TurtorialVideoId,
                    Name = combo.TurtorialVideo.Name,
                    Description = combo.TurtorialVideo.Description,
                    VideoURL = combo.TurtorialVideo.VideoURL
                } : null,
                Ingredients = combo.ComboIngredients?.Select(ci => new ComboIngredientDto
                {
                    ComboIngredientId = ci.ComboIngredientId,
                    IngredientID = ci.IngredientID,
                    IngredientName = ci.Ingredient?.Name ?? "Unknown",
                    Quantity = ci.Quantity
                }).ToList() ?? new List<ComboIngredientDto>(),
                AllowedIngredientTypes = combo.IsCustomizable ? combo.AllowedIngredientTypes?.Select(ait => new ComboAllowedIngredientTypeDto
                {
                    Id = ait.ComboAllowedIngredientTypeId,
                    IngredientTypeId = ait.IngredientTypeId,
                    IngredientTypeName = ait.IngredientType?.Name ?? "Unknown",
                    MaxQuantity = ait.MaxQuantity
                }).ToList() : null,
                CreatedAt = combo.CreatedAt,
                UpdatedAt = (DateTime)combo.UpdatedAt
            };
        }
    }
}
