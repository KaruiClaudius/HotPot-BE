using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Combo;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Ingredient;
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
        public async Task<ActionResult<IEnumerable<ComboDto>>> GetAll()
        {
            try
            {
                var combos = await _comboService.GetAllAsync();
                var comboDtos = combos.Select(MapToComboDto).ToList();

                return Ok(comboDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("paged")]
        public async Task<ActionResult<PagedResult<ComboDto>>> GetPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _comboService.GetPagedAsync(pageNumber, pageSize);

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

        [HttpGet("customizable")]
        public async Task<ActionResult<IEnumerable<ComboDto>>> GetCustomizableCombos()
        {
            try
            {
                var combos = await _comboService.GetCustomizableCombosAsync();
                var comboDtos = combos.Select(MapToComboDto).ToList();

                return Ok(comboDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<ComboDto>> Create(CreateComboRequest comboDto)
        {
            try
            {
                var combo = new Combo
                {
                    Name = comboDto.Name,
                    Description = comboDto.Description,
                    Size = comboDto.Size,
                    BasePrice = comboDto.BasePrice,
                    IsCustomizable = false,
                    HotpotBrothID = comboDto.HotpotBrothID
                };

                var comboIngredients = comboDto.Ingredients.Select(i => new ComboIngredient
                {
                    IngredientID = i.IngredientID,
                    Quantity = i.Quantity
                }).ToList();

                var createdCombo = await _comboService.CreateAsync(combo, comboIngredients);

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
        public async Task<ActionResult<ComboDto>> CreateCustomizable(CustomizableComboCreateDto comboDto)
        {
            try
            {
                var combo = new Combo
                {
                    Name = comboDto.Name,
                    Description = comboDto.Description,
                    Size = comboDto.Size,
                    BasePrice = comboDto.BasePrice,
                    IsCustomizable = true,
                    HotpotBrothID = comboDto.HotpotBrothID
                };

                var allowedTypes = comboDto.AllowedIngredientTypes.Select(t => new ComboAllowedIngredientType
                {
                    IngredientTypeId = t.IngredientTypeId,
                    MaxQuantity = t.MaxQuantity
                }).ToList();

                var createdCombo = await _comboService.CreateCustomizableComboAsync(combo, allowedTypes);

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
        public async Task<ActionResult> Update(int id, ComboUpdateDto comboDto)
        {
            try
            {
                var existingCombo = await _comboService.GetByIdAsync(id);
                if (existingCombo == null)
                    return NotFound(new { message = $"Combo with ID {id} not found" });

                existingCombo.Name = comboDto.Name;
                existingCombo.Description = comboDto.Description;
                existingCombo.Size = comboDto.Size;
                existingCombo.BasePrice = comboDto.BasePrice;
                existingCombo.HotpotBrothID = comboDto.HotpotBrothID;

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

        [HttpGet("{comboId}/allowed-ingredient-types")]
        public async Task<ActionResult<IEnumerable<ComboAllowedIngredientTypeDto>>> GetAllowedIngredientTypes(int comboId)
        {
            try
            {
                var allowedTypes = await _comboService.GetAllowedIngredientTypesAsync(comboId);
                var allowedTypeDtos = allowedTypes.Select(t => new ComboAllowedIngredientTypeDto
                {
                    Id = t.Id,
                    IngredientTypeId = t.IngredientTypeId,
                    IngredientTypeName = t.IngredientType?.Name ?? "Unknown",
                    MaxQuantity = t.MaxQuantity
                }).ToList();

                return Ok(allowedTypeDtos);
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

        [HttpGet("{comboId}/ingredients/{ingredientTypeId}")]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> GetAvailableIngredientsForType(int comboId, int ingredientTypeId)
        {
            try
            {
                var ingredients = await _comboService.GetAvailableIngredientsForTypeAsync(comboId, ingredientTypeId);

                // Get all ingredient IDs
                var ingredientIds = ingredients.Select(i => i.IngredientId).ToList();

                // Get current prices for all ingredients in a single query
                var currentPrices = await _ingredientService.GetCurrentPricesAsync(ingredientIds);

                var ingredientDtos = ingredients.Select(i => new IngredientDto
                {
                    IngredientId = i.IngredientId,
                    Name = i.Name,
                    Description = i.Description,
                    Price = currentPrices.TryGetValue(i.IngredientId, out var price) ? price : 0,
                    Quantity = i.Quantity,
                    IngredientTypeID = i.IngredientTypeID,
                    IngredientTypeName = i.IngredientType?.Name ?? "Unknown"
                }).ToList();

                return Ok(ingredientDtos);
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

        [HttpGet("{comboId}/price/{size}")]
        public async Task<ActionResult<decimal>> CalculatePrice(int comboId, int size)
        {
            try
            {
                var price = await _comboService.CalculateTotalPriceAsync(comboId, size);
                return Ok(new { price });
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

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<ComboDto>>> GetActive()
        {
            try
            {
                var combos = await _comboService.GetActiveAsync();
                var comboDtos = combos.Select(MapToComboDto).ToList();

                return Ok(comboDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{comboId}/ingredients")]
        public async Task<ActionResult<IEnumerable<ComboIngredientDto>>> GetComboIngredients(int comboId)
        {
            try
            {
                var ingredients = await _comboService.GetComboIngredientsAsync(comboId);
                var ingredientDtos = ingredients.Select(ci => new ComboIngredientDto
                {
                    ComboIngredientId = ci.ComboIngredientId,
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

        [HttpPost("{comboId}/ingredients")]
        public async Task<ActionResult> AddIngredientToCombo(int comboId, CreateComboIngredientRequest ingredientDto)
        {
            try
            {
                await _comboService.AddIngredientToComboAsync(comboId, ingredientDto.IngredientID, ingredientDto.Quantity);
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

        [HttpDelete("{comboId}/ingredients/{ingredientId}")]
        public async Task<ActionResult> RemoveIngredientFromCombo(int comboId, int ingredientId)
        {
            try
            {
                await _comboService.RemoveIngredientFromComboAsync(comboId, ingredientId);
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

        [HttpPut("{comboId}/ingredients/{ingredientId}")]
        public async Task<ActionResult> UpdateIngredientQuantity(int comboId, int ingredientId, [FromBody] UpdateQuantityRequest quantityDto)
        {
            try
            {
                await _comboService.UpdateIngredientQuantityAsync(comboId, ingredientId, quantityDto.Quantity);
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
        public async Task<ActionResult<PagedResult<ComboDto>>> Search([FromQuery] string searchTerm = "", [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _comboService.SearchAsync(searchTerm, pageNumber, pageSize);

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
                IsCustomizable = combo.IsCustomizable,
                HotpotBrothID = combo.HotpotBrothID,
                HotpotBrothName = combo.HotpotBroth?.Name ?? "Unknown",
                AppliedDiscountID = combo.AppliedDiscountID,
                AppliedDiscountPercentage = combo.AppliedDiscount?.DiscountPercentage ?? 0,
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
                IsCustomizable = combo.IsCustomizable,
                HotpotBrothID = combo.HotpotBrothID,
                HotpotBrothName = combo.HotpotBroth?.Name ?? "Unknown",
                AppliedDiscountID = combo.AppliedDiscountID,
                AppliedDiscountPercentage = combo.AppliedDiscount?.DiscountPercentage ?? 0,
                Ingredients = combo.ComboIngredients?.Select(ci => new ComboIngredientDto
                {
                    ComboIngredientId = ci.ComboIngredientId,
                    IngredientID = ci.IngredientID,
                    IngredientName = ci.Ingredient?.Name ?? "Unknown",
                    Quantity = ci.Quantity
                }).ToList() ?? new List<ComboIngredientDto>(),
                AllowedIngredientTypes = combo.IsCustomizable ? combo.AllowedIngredientTypes?.Select(ait => new ComboAllowedIngredientTypeDto
                {
                    Id = ait.Id,
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
