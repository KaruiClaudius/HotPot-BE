using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Customization;
using Capstone.HPTY.ServiceLayer.DTOs.SizeDiscount;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Customer")]

public class CustomizationController : ControllerBase
{
    private readonly ICustomizationService _customizationService;
    private readonly ISizeDiscountService _sizeDiscountService;

    public CustomizationController(
        ICustomizationService customizationService,
        ISizeDiscountService sizeDiscountService)
    {
        _customizationService = customizationService;
        _sizeDiscountService = sizeDiscountService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerCustomizationDto>>> GetAll()
    {
        try
        {
            var customizations = await _customizationService.GetAllAsync();
            var customizationDtos = customizations.Select(MapToCustomizationDto).ToList();

            return Ok(customizationDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PagedResult<CustomerCustomizationDto>>> GetPaged(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        try
        {
            var result = await _customizationService.GetPagedAsync(pageNumber, pageSize);

            var pagedResult = new PagedResult<CustomerCustomizationDto>
            {
                Items = result.Items.Select(MapToCustomizationDto).ToList(),
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
    public async Task<ActionResult<CustomerCustomizationDto>> GetById(int id)
    {
        try
        {
            var customization = await _customizationService.GetByIdAsync(id);
            if (customization == null)
                return NotFound(new { message = $"Customization with ID {id} not found" });

            var customizationDto = MapToCustomizationDto(customization);

            return Ok(customizationDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult<IEnumerable<CustomerCustomizationDto>>> GetUserCustomizations(int userId)
    {
        try
        {
            var customizations = await _customizationService.GetUserCustomizationsAsync(userId);
            var customizationDtos = customizations.Select(MapToCustomizationDto).ToList();

            return Ok(customizationDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<ActionResult<CustomerCustomizationDetailDto>> Create(CreateCustomizationRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var customization = await _customizationService.CreateCustomizationAsync(
                request.ComboId,
                userId,
                request.Name,
                request.Note,
                request.Size,
                request.BrothId,
                request.Ingredients,
                request.ImageURLs); 

            var customizationDto = MapToCustomizationDetailDto(customization);

            return CreatedAtAction(nameof(GetById), new { id = customization.CustomizationId }, customizationDto);
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

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCustomizationRequest request)
    {
        try
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var customization = await _customizationService.GetByIdAsync(id);
            if (customization == null)
                return NotFound(new { message = $"Customization with ID {id} not found" });

            // Verify the customization belongs to the current user
            if (customization.UserID != userId)
                return Forbid();

            // Update basic properties
            customization.Name = request.Name;
            customization.Note = request.Note;
            customization.Size = request.Size;
            customization.HotpotBrothID = request.HotpotBrothID;
            customization.ImageURLs = request.ImageURLs; // Update image URLs

            // Convert ingredients
            var ingredients = request.Ingredients.Select(i => new CustomizationIngredient
            {
                IngredientID = i.IngredientID,
                Quantity = i.Quantity
            }).ToList();

            await _customizationService.UpdateAsync(id, customization, ingredients);

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
            await _customizationService.DeleteAsync(id);
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

    [HttpPost("price-estimate")]
    public async Task<ActionResult<CustomizationPriceEstimate>> CalculatePriceEstimate(PriceEstimateRequest request)
    {
        try
        {
            var estimate = await _customizationService.CalculatePriceEstimateAsync(
                request.ComboId,
                request.Size,
                request.BrothId,
                request.Ingredients
            );

            return Ok(estimate);
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

    [HttpGet("{customizationId}/ingredients")]
    public async Task<ActionResult<IEnumerable<CustomizationIngredientDto>>> GetCustomizationIngredients(int customizationId)
    {
        try
        {
            var ingredients = await _customizationService.GetCustomizationIngredientsAsync(customizationId);
            var ingredientDtos = ingredients.Select(ci => new CustomizationIngredientDto
            {
                CustomizationIngredientId = ci.CustomizationIngredientId,
                IngredientID = ci.IngredientID,
                IngredientName = ci.Ingredient?.Name ?? "Unknown",
                Quantity = ci.Quantity
            }).ToList();

            return Ok(ingredientDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }

    [HttpPost("{customizationId}/ingredients")]
    public async Task<ActionResult> AddIngredientToCustomization(int customizationId, CreateCustomizationIngredientRequest ingredientDto)
    {
        try
        {
            await _customizationService.AddIngredientToCustomizationAsync(
                customizationId,
                ingredientDto.IngredientID,
                ingredientDto.Quantity
            );
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

    [HttpDelete("{customizationId}/ingredients/{ingredientId}")]
    public async Task<ActionResult> RemoveIngredientFromCustomization(int customizationId, int ingredientId)
    {
        try
        {
            await _customizationService.RemoveIngredientFromCustomizationAsync(customizationId, ingredientId);
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

    [HttpPut("{customizationId}/ingredients/{ingredientId}")]
    public async Task<ActionResult> UpdateIngredientQuantity(int customizationId, int ingredientId, [FromBody] UpdateQuantityRequest quantityDto)
    {
        try
        {
            await _customizationService.UpdateIngredientQuantityAsync(customizationId, ingredientId, quantityDto.Quantity);
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

    [HttpGet("search")]
    public async Task<ActionResult<PagedResult<CustomerCustomizationDto>>> Search(
        [FromQuery] string searchTerm = "",
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        try
        {
            var result = await _customizationService.SearchAsync(searchTerm, pageNumber, pageSize);

            var pagedResult = new PagedResult<CustomerCustomizationDto>
            {
                Items = result.Items.Select(MapToCustomizationDto).ToList(),
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

    [HttpPost("{id}/images")]
    public async Task<ActionResult> UploadCustomizationImages(int id, [FromForm] List<IFormFile> images)
    {
        try
        {
            var customization = await _customizationService.GetByIdAsync(id);
            if (customization == null)
                return NotFound(new { message = $"Customization with ID {id} not found" });

            // Verify the customization belongs to the current user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (customization.UserID != int.Parse(userId))
                return Forbid();

            // List to store uploaded image URLs
            var imageUrls = new List<string>();

            // Add existing images if any
            if (customization.ImageURLs != null)
            {
                imageUrls.AddRange(customization.ImageURLs);
            }

            // Process each uploaded file
            foreach (var image in images)
            {
                if (image.Length > 0)
                {
                    // Generate a unique filename
                    var fileName = $"{Guid.NewGuid()}_{Path.GetFileName(image.FileName)}";

                    // Define the path where to save the file
                    var filePath = Path.Combine("wwwroot", "images", "customizations", fileName);

                    // Ensure directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    // Save the file
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    // Add the URL to the list
                    var url = $"/images/customizations/{fileName}";
                    imageUrls.Add(url);
                }
            }

            // Update the customization with the new image URLs
            customization.ImageURLs = imageUrls.ToArray();
            await _customizationService.UpdateAsync(customization.CustomizationId, customization);

            return Ok(new { message = "Images uploaded successfully", imageUrls = customization.ImageURLs });
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

    [HttpDelete("{id}/images")]
    public async Task<ActionResult> DeleteCustomizationImages(int id, [FromBody] DeleteImagesRequest request)
    {
        try
        {
            var customization = await _customizationService.GetByIdAsync(id);
            if (customization == null)
                return NotFound(new { message = $"Customization with ID {id} not found" });

            // Verify the customization belongs to the current user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (customization.UserID != int.Parse(userId))
                return Forbid();

            if (customization.ImageURLs == null || customization.ImageURLs.Length == 0)
                return BadRequest(new { message = "Customization has no images to delete" });

            // Filter out the URLs to delete
            var remainingUrls = customization.ImageURLs
                .Where(url => !request.ImageURLs.Contains(url))
                .ToArray();

            // Update the customization with the remaining URLs
            customization.ImageURLs = remainingUrls;
            await _customizationService.UpdateAsync(customization.CustomizationId, customization);

            // Optionally, delete the physical files
            foreach (var url in request.ImageURLs)
            {
                if (url.StartsWith("/images/"))
                {
                    var filePath = Path.Combine("wwwroot", url.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                }
            }

            return Ok(new { message = "Images deleted successfully", imageUrls = customization.ImageURLs });
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



    // DTO mapping method
    private CustomerCustomizationDto MapToCustomizationDto(Customization customization)
    {
        if (customization == null) return null;

        return new CustomerCustomizationDto
        {
            CustomizationId = customization.CustomizationId,
            Name = customization.Name,
            Note = customization.Note ?? string.Empty,
            Size = customization.Size,
            BasePrice = customization.BasePrice,
            TotalPrice = customization.TotalPrice,
            HotpotBrothName = customization.HotpotBroth?.Name ?? "Unknown",
            ComboName = customization.Combo?.Name ?? "Unknown",
            CreatedAt = customization.CreatedAt,
            ImageURLs = customization.ImageURLs ?? new string[0] // Include image URLs
        };
    }

    private CustomerCustomizationDetailDto MapToCustomizationDetailDto(Customization customization)
    {
        if (customization == null) return null;

        var baseDto = MapToCustomizationDto(customization);

        return new CustomerCustomizationDetailDto
        {
            CustomizationId = baseDto.CustomizationId,
            Name = baseDto.Name,
            Note = baseDto.Note,
            Size = baseDto.Size,
            BasePrice = baseDto.BasePrice,
            TotalPrice = baseDto.TotalPrice,
            HotpotBrothName = baseDto.HotpotBrothName,
            ComboName = baseDto.ComboName,
            CreatedAt = baseDto.CreatedAt,
            ImageURLs = baseDto.ImageURLs, // Include image URLs
            Ingredients = customization.CustomizationIngredients?.Select(ci => new CustomizationIngredientDto
            {
                IngredientID = ci.IngredientID,
                IngredientName = ci.Ingredient?.Name ?? "Unknown",
                Quantity = ci.Quantity
            }).ToList() ?? new List<CustomizationIngredientDto>()
        };
    }
}