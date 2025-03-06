using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Customization;
using Capstone.HPTY.ServiceLayer.DTOs.SizeDiscount;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<ActionResult<IEnumerable<CustomizationDto>>> GetAll()
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
    public async Task<ActionResult<PagedResult<CustomizationDto>>> GetPaged(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        try
        {
            var result = await _customizationService.GetPagedAsync(pageNumber, pageSize);

            var pagedResult = new PagedResult<CustomizationDto>
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
    public async Task<ActionResult<CustomizationDto>> GetById(int id)
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
    public async Task<ActionResult<IEnumerable<CustomizationDto>>> GetUserCustomizations(int userId)
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
    public async Task<ActionResult<CustomizationDto>> Create(CreateCustomizationRequest customizationDto)
    {
        try
        {
            var customization = await _customizationService.CreateCustomizationAsync(
                customizationDto.ComboID,
                customizationDto.UserID,
                customizationDto.Name,
                customizationDto.Note,
                customizationDto.Size,
                customizationDto.HotpotBrothID,
                customizationDto.Ingredients
            );

            return CreatedAtAction(nameof(GetById), new { id = customization.CustomizationId }, MapToCustomizationDto(customization));
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
    public async Task<ActionResult> Update(int id, UpdateCustomizationRequest customizationDto)
    {
        try
        {
            var existingCustomization = await _customizationService.GetByIdAsync(id);
            if (existingCustomization == null)
                return NotFound(new { message = $"Customization with ID {id} not found" });

            existingCustomization.Name = customizationDto.Name;
            existingCustomization.Note = customizationDto.Note;
            existingCustomization.Size = customizationDto.Size;
            existingCustomization.HotpotBrothID = customizationDto.HotpotBrothID;

            await _customizationService.UpdateAsync(id, existingCustomization);

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
    public async Task<ActionResult<PagedResult<CustomizationDto>>> Search(
        [FromQuery] string searchTerm = "",
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
    {
        try
        {
            var result = await _customizationService.SearchAsync(searchTerm, pageNumber, pageSize);

            var pagedResult = new PagedResult<CustomizationDto>
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

    // DTO mapping method
    private CustomizationDto MapToCustomizationDto(Customization customization)
    {
        if (customization == null) return null;

        return new CustomizationDto
        {
            CustomizationId = customization.CustomizationId,
            Name = customization.Name,
            Note = customization.Note,
            BasePrice = customization.BasePrice,
            TotalPrice = customization.TotalPrice, // Use the stored total price
            Size = customization.Size,
            UserID = customization.UserID,
            UserName = customization.User?.Name ?? "Unknown",
            HotpotBrothID = customization.HotpotBrothID,
            HotpotBrothName = customization.HotpotBroth?.Name ?? "Unknown",
            ComboID = customization.ComboID,
            ComboName = customization.Combo?.Name ?? "Unknown",
            AppliedDiscountID = customization.AppliedDiscountID,
            AppliedDiscountPercentage = customization.AppliedDiscount?.DiscountPercentage ?? 0,
            Ingredients = customization.CustomizationIngredients?.Select(ci => new CustomizationIngredientDto
            {
                CustomizationIngredientId = ci.CustomizationIngredientId,
                IngredientID = ci.IngredientID,
                IngredientName = ci.Ingredient?.Name ?? "Unknown",
                Quantity = ci.Quantity
            }).ToList() ?? new List<CustomizationIngredientDto>(),
            CreatedAt = customization.CreatedAt,
            UpdatedAt = (DateTime)customization.UpdatedAt
        };
    }
}