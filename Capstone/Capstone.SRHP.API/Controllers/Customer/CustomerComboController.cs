using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Combo.customer;
using Capstone.HPTY.ServiceLayer.DTOs.Combo.Customer;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Capstone.HPTY.API.Controllers.Customer
{
    [ApiController]
    [Route("api/customer/combos")]
    [Authorize(Roles = "Customer")]
    public class CustomerComboController : ControllerBase
    {
        private readonly IComboService _comboService;
        private readonly ISizeDiscountService _sizeDiscountService;
        private readonly IIngredientService _ingredientService;
        private readonly ILogger<CustomerComboController> _logger;

        public CustomerComboController(
            IComboService comboService,
            ISizeDiscountService sizeDiscountService,
            ILogger<CustomerComboController> logger,
            IIngredientService ingredientService)
        {
            _comboService = comboService;
            _sizeDiscountService = sizeDiscountService;
            _logger = logger;
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<CustomerComboDto>>> GetCombos(
            [FromQuery] string searchTerm = null,
            [FromQuery] bool? isCustomizable = null,
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
                // Always get active combos only for customers
                bool activeOnly = true;

                var result = await _comboService.GetCombosAsync(
                    searchTerm, isCustomizable, activeOnly, minSize, maxSize,
                    minPrice, maxPrice, pageNumber, pageSize, sortBy, ascending);

                var pagedResult = new PagedResult<CustomerComboDto>
                {
                    Items = new List<CustomerComboDto>(),
                    TotalCount = result.TotalCount,
                    PageNumber = result.PageNumber,
                    PageSize = result.PageSize
                };

                // Map each combo individually to handle the async mapping for group information
                foreach (var combo in result.Items)
                {
                    var mappedCombo = await MapToCustomerComboDtoAsync(combo);
                    ((List<CustomerComboDto>)pagedResult.Items).Add(mappedCombo);
                }

                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting combos for customer");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerComboDetailDto>> GetComboById(int id)
        {
            try
            {
                var combo = await _comboService.GetByIdAsync(id);
                if (combo == null)
                    return NotFound(new { message = $"Combo with ID {id} not found" });

                var comboDto = await MapToCustomerComboDetailDtoAsync(combo);

                return Ok(comboDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting combo by id {ComboId} for customer", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("group/{groupIdentifier}")]
        public async Task<ActionResult<IEnumerable<CustomerComboDto>>> GetCombosByGroup(string groupIdentifier)
        {
            try
            {
                var combos = await _comboService.GetCombosByGroupIdentifierAsync(groupIdentifier);
                if (!combos.Any())
                    return NotFound(new { message = $"No combos found with group identifier '{groupIdentifier}'" });

                var comboDtos = new List<CustomerComboDto>();
                foreach (var combo in combos)
                {
                    comboDtos.Add(await MapToCustomerComboDtoAsync(combo));
                }

                return Ok(comboDtos);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting combos by group identifier '{GroupIdentifier}' for customer", groupIdentifier);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("price/{comboId}")]
        public async Task<ActionResult<ComboSizePriceDto>> GetComboPrice(int comboId, [FromQuery] int size)
        {
            try
            {
                var combo = await _comboService.GetByIdAsync(comboId);
                if (combo == null)
                    return NotFound(new { message = $"Combo with ID {comboId} not found" });

                if (size <= 0 && !combo.IsCustomizable)
                    return BadRequest(new { message = "Size must be greater than 0" });

                // Calculate price for the specified size
                decimal basePrice = 0;
                if (size == 0)
                    basePrice = combo.BasePrice;
                else
                    basePrice = combo.BasePrice * size;

                // Get applicable discount
                var applicableDiscount = await _sizeDiscountService.GetApplicableDiscountAsync(size);
                decimal discountPercentage = applicableDiscount?.DiscountPercentage ?? 0;

                // Calculate final price
                decimal finalPrice = basePrice;
                if (discountPercentage > 0)
                {
                    finalPrice = basePrice * (1 - (discountPercentage / 100m));
                }

                var priceDto = new ComboSizePriceDto
                {
                    ComboId = comboId,
                    Size = size,
                    BasePrice = basePrice,
                    DiscountPercentage = discountPercentage,
                    FinalPrice = finalPrice
                };

                return Ok(priceDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting combo price for combo {ComboId} with size {Size}", comboId, size);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        private async Task<CustomerComboDto> MapToCustomerComboDtoAsync(Combo combo)
        {
            if (combo == null) return null;

            var dto = new CustomerComboDto
            {
                ComboId = combo.ComboId,
                Name = combo.Name,
                Size = combo.Size,
                BasePrice = combo.BasePrice,
                TotalPrice = combo.TotalPrice,
                IsCustomizable = combo.IsCustomizable,
                ImageURLs = combo.ImageURLs ?? new string[0],
                TurtorialVideoID = combo.TurtorialVideoId,
                TutorialVideoName = combo.TurtorialVideo?.Name,
                TutorialVideoUrl = combo.TurtorialVideo?.VideoURL
            };

            // Set type-specific properties
            if (combo.IsCustomizable)
            {
                // For customizable combos, use Description as GroupIdentifier
                dto.GroupIdentifier = combo.Description;

                // Check if this is part of a group
                if (!string.IsNullOrEmpty(combo.Description))
                {
                    var groupCombos = await _comboService.GetCombosByGroupIdentifierAsync(combo.Description);

                    dto.IsPartOfGroup = groupCombos.Count() > 1;

                    if (dto.IsPartOfGroup)
                    {
                        dto.GroupVariants = groupCombos
                            .Where(c => c.ComboId != combo.ComboId) // Exclude the current combo
                            .Select(c => new CustomerComboVariantDto
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
                // For regular combos, use Description as Description
                dto.Description = combo.Description;
            }

            return dto;
        }

        private async Task<CustomerComboDetailDto> MapToCustomerComboDetailDtoAsync(Combo combo)
        {
            if (combo == null) return null;

            // Get the base DTO first
            var baseDto = await MapToCustomerComboDtoAsync(combo);

            // Create the detail DTO
            var detailDto = new CustomerComboDetailDto
            {
                ComboId = baseDto.ComboId,
                Name = baseDto.Name,
                Size = baseDto.Size,
                BasePrice = baseDto.BasePrice,
                TotalPrice = baseDto.TotalPrice,
                IsCustomizable = baseDto.IsCustomizable,
                ImageURLs = baseDto.ImageURLs,
                TurtorialVideoID = baseDto.TurtorialVideoID,
                TutorialVideoName = baseDto.TutorialVideoName,
                TutorialVideoUrl = baseDto.TutorialVideoUrl,
                GroupIdentifier = baseDto.GroupIdentifier,
                IsPartOfGroup = baseDto.IsPartOfGroup,
                GroupVariants = baseDto.GroupVariants,
                Description = baseDto.Description
            };

            // Add tutorial video details
            if (combo.TurtorialVideo != null)
            {
                detailDto.TutorialVideo = new CustomerTutorialVideoDto
                {
                    TurtorialVideoId = combo.TurtorialVideo.TurtorialVideoId,
                    Name = combo.TurtorialVideo.Name,
                    Description = combo.TurtorialVideo.Description,
                    VideoURL = combo.TurtorialVideo.VideoURL
                };
            }

            // Add ingredients for regular combos
            if (!combo.IsCustomizable)
            {
                detailDto.Ingredients = combo.ComboIngredients?
                    .Where(ci => !ci.IsDelete)
                    .Select(ci => new CustomerComboIngredientDto
                    {
                        IngredientID = ci.IngredientId,
                        IngredientName = ci.Ingredient?.Name ?? "Unknown",
                        Quantity = ci.Quantity,
                        Price = _ingredientService.GetCurrentPriceAsync(ci.IngredientId).Result,
                        FormattedQuantity = FormatQuantity(ci.Ingredient.Quantity, ci.Ingredient.Unit)
                    })
                    .ToList();
            }

            // Add allowed ingredient types for customizable combos
            if (combo.IsCustomizable)
            {
                detailDto.AllowedIngredientTypes = combo.AllowedIngredientTypes?
                    .Where(ait => !ait.IsDelete)
                    .Select(ait => new CustomerAllowedIngredientTypeDto
                    {
                        IngredientTypeId = ait.IngredientTypeId,
                        IngredientTypeName = ait.IngredientType?.Name ?? "Unknown",
                        MinQuantity = ait.MinQuantity
                    })
                    .ToList();
            }

            return detailDto;
        }

        private string FormatQuantity(int quantity, string unit)
        {
            if (string.IsNullOrEmpty(unit))
                return quantity.ToString("0.##");

            return $"{quantity.ToString("0.##")} {unit}";
        }
    }
}
