using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.SizeDiscount;
using Capstone.HPTY.ServiceLayer.Interfaces.ComboService;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminSizeDiscountController : ControllerBase
    {
        private readonly ISizeDiscountService _sizeDiscountService;
        private readonly ILogger<AdminSizeDiscountController> _logger;

        public AdminSizeDiscountController(
            ISizeDiscountService sizeDiscountService,
            ILogger<AdminSizeDiscountController> logger)
        {
            _sizeDiscountService = sizeDiscountService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResult<SizeDiscountDto>>> GetAll(
         [FromQuery] int? minSize = null,
         [FromQuery] int? maxSize = null,
         [FromQuery] decimal? minDiscount = null,
         [FromQuery] decimal? maxDiscount = null,
         [FromQuery] DateTime? activeDate = null,
         [FromQuery] bool? isActive = null,
         [FromQuery] int pageNumber = 1,
         [FromQuery] int pageSize = 10,
         [FromQuery] string sortBy = "MinSize",
         [FromQuery] bool ascending = true)
        {
            try
            {
                // Validate pagination parameters
                if (pageNumber < 1) pageNumber = 1;
                if (pageSize < 1) pageSize = 10;
                if (pageSize > 50) pageSize = 50;

                var result = await _sizeDiscountService.GetSizeDiscountsAsync(
                    minSize, maxSize, minDiscount, maxDiscount, activeDate, isActive,
                    pageNumber, pageSize, sortBy, ascending);

                var pagedResult = new PagedResult<SizeDiscountDto>
                {
                    Items = result.Items.Select(MapToSizeDiscountDto).ToList(),
                    TotalCount = result.TotalCount,
                    PageNumber = result.PageNumber,
                    PageSize = result.PageSize
                };

                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving size discounts");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SizeDiscountDto>> GetById(int id)
        {
            try
            {
                var discount = await _sizeDiscountService.GetByIdAsync(id);
                if (discount == null)
                    return NotFound(new { message = $"Size discount with ID {id} not found" });

                var discountDto = MapToSizeDiscountDto(discount);

                return Ok(discountDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving size discount with ID {SizeDiscountId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<ActionResult<SizeDiscountDto>> Create(SizeDiscountCreateDto discountDto)
        {
            try
            {
                var discount = new SizeDiscount
                {
                    MinSize = discountDto.MinSize,
                    DiscountPercentage = discountDto.DiscountPercentage,
                    StartDate = discountDto.StartDate,
                    EndDate = discountDto.EndDate,
                };

                var createdDiscount = await _sizeDiscountService.CreateAsync(discount);

                return CreatedAtAction(nameof(GetById), new { id = createdDiscount.SizeDiscountId }, MapToSizeDiscountDto(createdDiscount));
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating size discount");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, SizeDiscountUpdateDto discountDto)
        {
            try
            {
                var existingDiscount = await _sizeDiscountService.GetByIdAsync(id);
                if (existingDiscount == null)
                    return NotFound(new { message = $"Size discount with ID {id} not found" });

                existingDiscount.MinSize = discountDto.MinSize;
                existingDiscount.DiscountPercentage = discountDto.DiscountPercentage;
                existingDiscount.StartDate = discountDto.StartDate;
                existingDiscount.EndDate = discountDto.EndDate;

                await _sizeDiscountService.UpdateAsync(id, existingDiscount);

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
                _logger.LogError(ex, "Error updating size discount with ID {SizeDiscountId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _sizeDiscountService.DeleteAsync(id);
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
                _logger.LogError(ex, "Error deleting size discount with ID {SizeDiscountId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("applicable/{size}")]
        public async Task<ActionResult<SizeDiscountDto>> GetApplicableDiscount(int size)
        {
            try
            {
                var discount = await _sizeDiscountService.GetApplicableDiscountAsync(size);
                if (discount == null)
                    return Ok(new { message = "No applicable discount found for this size", discountPercentage = 0 });

                var discountDto = MapToSizeDiscountDto(discount);

                return Ok(discountDto);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving applicable discount for size {Size}", size);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // DTO mapping method
        private SizeDiscountDto MapToSizeDiscountDto(SizeDiscount sizeDiscount)
        {
            if (sizeDiscount == null) return null;

            return new SizeDiscountDto
            {
                Id = sizeDiscount.SizeDiscountId,
                MinSize = sizeDiscount.MinSize,
                DiscountPercentage = sizeDiscount.DiscountPercentage,
                StartDate = sizeDiscount.StartDate,
                EndDate = sizeDiscount.EndDate,
                CreatedAt = sizeDiscount.CreatedAt,
                UpdatedAt = (DateTime)sizeDiscount.UpdatedAt
            };
        }
    }
}
