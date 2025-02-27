using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.IngredientService;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;
        private readonly ILogger<IngredientsController> _logger;

        public IngredientsController(
            IIngredientService ingredientService,
            ILogger<IngredientsController> logger)
        {
            _ingredientService = ingredientService;
            _logger = logger;
        }

        //    [HttpGet]
        //    [ProducesResponseType(typeof(PagedResult<IEnumerable<IngredientDto>>), StatusCodes.Status200OK)]
        //    public async Task<ActionResult<PagedResult<IEnumerable<IngredientDto>>>> GetIngredients(
        //        [FromQuery] int pageIndex = 1,
        //        [FromQuery] int pageSize = 10,
        //        [FromQuery] string searchTerm = null,
        //        [FromQuery] int? ingredientTypeId = null)
        //    {
        //        try
        //        {
        //            _logger.LogInformation("Getting ingredients page {PageIndex} with size {PageSize}", pageIndex, pageSize);

        //            var (ingredients, totalCount) = await _ingredientService.GetAllPagedAsync(
        //                pageIndex, pageSize, searchTerm, ingredientTypeId);

        //            var ingredientDtos = ingredients.Select(i => new IngredientDto
        //            {
        //                IngredientId = i.IngredientId,
        //                Name = i.Name,
        //                Description = i.Description,
        //                ImageURL = i.ImageURL,
        //                MinStockLevel = i.MinStockLevel,
        //                Quantity = i.Quantity,
        //                IngredientTypeID = i.IngredientTypeID,
        //                IngredientTypeName = i.IngredientType?.Name,
        //                CurrentPrice = i.IngredientPrices?.OrderByDescending(p => p.EffectiveDate)
        //                    .FirstOrDefault()?.Price ?? 0
        //            }).ToList();

        //            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

        //            return Ok(new ApiPagedResponse<IEnumerable<IngredientDto>>
        //            {
        //                Success = true,
        //                Message = $"Retrieved {ingredientDtos.Count} ingredients",
        //                Data = ingredientDtos,
        //                PageIndex = pageIndex,
        //                PageSize = pageSize,
        //                TotalCount = totalCount,
        //                TotalPages = totalPages,
        //                HasPreviousPage = pageIndex > 1,
        //                HasNextPage = pageIndex < totalPages
        //            });
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError(ex, "Error retrieving ingredients");
        //            return BadRequest(new ApiErrorResponse
        //            {
        //                Status = "Error",
        //                Message = "Failed to retrieve ingredients"
        //            });
        //        }
        //    }
    }
}
