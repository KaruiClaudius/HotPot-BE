using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Combo.customer;
using Capstone.HPTY.ServiceLayer.DTOs.Combo.Customer;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Customer
{
    namespace Capstone.HPTY.API.Controllers.Customer
    {
        [ApiController]
        [Route("api/customer/combos")]
        [Authorize(Roles = "Customer")]
        public class CustomerComboController : ControllerBase
        {
            private readonly IComboService _comboService;
            private readonly ISizeDiscountService _sizeDiscountService;

            public CustomerComboController(
                IComboService comboService,
                ISizeDiscountService sizeDiscountService)
            {
                _comboService = comboService;
                _sizeDiscountService = sizeDiscountService;
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
                        Items = result.Items.Select(MapToCustomerComboDto).ToList(),
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
            public async Task<ActionResult<CustomerComboDetailDto>> GetComboById(int id)
            {
                try
                {
                    var combo = await _comboService.GetByIdAsync(id);
                    if (combo == null)
                        return NotFound(new { message = $"Combo with ID {id} not found" });

                    var comboDto = MapToCustomerComboDetailDto(combo);

                    return Ok(comboDto);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { message = ex.Message });
                }
            }


            [HttpGet("price/{comboId}/{size}")]
            public async Task<ActionResult<ComboSizePriceDto>> GetComboPrice(int comboId, int size)
            {
                try
                {
                    if (size <= 0)
                        return BadRequest(new { message = "Size must be greater than 0" });

                    var combo = await _comboService.GetByIdAsync(comboId);
                    if (combo == null)
                        return NotFound(new { message = $"Combo with ID {comboId} not found" });

                    // Calculate price for the specified size
                    var basePrice = combo.BasePrice * size;

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
                    return StatusCode(500, new { message = ex.Message });
                }
            }

            private CustomerComboDto MapToCustomerComboDto(Combo combo)
            {
                if (combo == null) return null;

                return new CustomerComboDto
                {
                    ComboId = combo.ComboId,
                    Name = combo.Name,
                    Description = combo.Description ?? string.Empty,
                    Size = combo.Size,
                    BasePrice = combo.BasePrice,
                    TotalPrice = combo.TotalPrice,
                    IsCustomizable = combo.IsCustomizable,
                    HotpotBrothName = combo.HotpotBroth?.Name ?? "Unknown",
                    ImageURLs = combo.ImageURLs ?? new string[0],
                    TurtorialVideoID = combo.TurtorialVideoID,
                    TutorialVideoName = combo.TurtorialVideo?.Name,
                    TutorialVideoUrl = combo.TurtorialVideo?.VideoURL
                };
            }

            private CustomerComboDetailDto MapToCustomerComboDetailDto(Combo combo)
            {
                if (combo == null) return null;

                var baseDto = MapToCustomerComboDto(combo);

                return new CustomerComboDetailDto
                {
                    ComboId = baseDto.ComboId,
                    Name = baseDto.Name,
                    Description = baseDto.Description,
                    Size = baseDto.Size,
                    BasePrice = baseDto.BasePrice,
                    TotalPrice = baseDto.TotalPrice,
                    IsCustomizable = baseDto.IsCustomizable,
                    HotpotBrothName = baseDto.HotpotBrothName,
                    ImageURLs = baseDto.ImageURLs,
                    TurtorialVideoID = baseDto.TurtorialVideoID,
                    TutorialVideoName = baseDto.TutorialVideoName,
                    TutorialVideoUrl = baseDto.TutorialVideoUrl,
                    TutorialVideo = combo.TurtorialVideo != null ? new CustomerTutorialVideoDto
                    {
                        TurtorialVideoId = combo.TurtorialVideo.TurtorialVideoId,
                        Name = combo.TurtorialVideo.Name,
                        Description = combo.TurtorialVideo.Description,
                        VideoURL = combo.TurtorialVideo.VideoURL
                    } : null,
                    Ingredients = combo.ComboIngredients?.Where(ci => !ci.IsDelete).Select(ci => new CustomerComboIngredientDto
                    {
                        IngredientID = ci.IngredientID,
                        IngredientName = ci.Ingredient?.Name ?? "Unknown",
                        Quantity = ci.Quantity
                    }).ToList() ?? new List<CustomerComboIngredientDto>(),
                    AllowedIngredientTypes = combo.IsCustomizable ? combo.AllowedIngredientTypes?.Where(ait => !ait.IsDelete).Select(ait => new CustomerAllowedIngredientTypeDto
                    {
                        IngredientTypeId = ait.IngredientTypeId,
                        IngredientTypeName = ait.IngredientType?.Name ?? "Unknown",
                        MaxQuantity = ait.MaxQuantity
                    }).ToList() : null
                };
            }
        }
    }
}
