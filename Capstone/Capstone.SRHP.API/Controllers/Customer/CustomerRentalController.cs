using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Orders;
using Capstone.HPTY.ServiceLayer.Interfaces.OrderService;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [Route("api/customer/rentals")]
    [ApiController]
    [Authorize(Roles = "Customer")]

    public class CustomerRentalController : ControllerBase
    {
        private readonly IRentOrderService _rentOrderService;
        private readonly IEquipmentReturnService _equipmentReturnService;
        private readonly INotificationService _notificationService;


        public CustomerRentalController(IRentOrderService rentOrderService, 
            INotificationService notificationService, 
            IEquipmentReturnService equipmentReturnService)
        {
            _rentOrderService = rentOrderService;
            _notificationService = notificationService;
            _equipmentReturnService = equipmentReturnService;
        }


        [HttpGet("pending-pickups")]
        public async Task<IActionResult> GetPendingPickups()
        {
            try
            {
                // Get current user ID from claims
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int userId = int.Parse(userIdClaim.Value);

                var pendingPickups = await _rentOrderService.GetPendingPickupsByUserAsync(userId);
                return Ok(pendingPickups);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetRentalHistory()
        {
            try
            {
                // Get current user ID from claims
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int userId = int.Parse(userIdClaim.Value);

                var rentalHistory = await _rentOrderService.GetRentalHistoryByUserAsync(userId);
                return Ok(rentalHistory);
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

        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetRentOrder(int id)
        {
            try
            {
                var rentOrder = await _equipmentReturnService.GetRentOrderAsync(id);

                // Verify the rental belongs to the current user
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int userId = int.Parse(userIdClaim.Value);

                if (rentOrder.Order.UserId != userId)
                {
                    return Forbid();
                }

                return Ok(rentOrder);
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

        // Keep this endpoint for backward compatibility
        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetRentalDetail(int id)
        {
            try
            {
                var rentOrder = await _equipmentReturnService.GetRentOrderAsync(id);

                // Verify the rental belongs to the current user
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int userId = int.Parse(userIdClaim.Value);

                if (rentOrder.Order.UserId != userId)
                {
                    return Forbid();
                }

                return Ok(rentOrder);
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

        [HttpPost("order/{id}/extend")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse<bool>>> ExtendRentalPeriod(int id, [FromBody] ExtendRentalRequest request)
        {
            try
            {
                // Verify the rental belongs to the current user
                var rentOrder = await _equipmentReturnService.GetRentOrderAsync(id);
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized(ApiResponse<bool>.ErrorResponse("User ID not found in claims"));

                int userId = int.Parse(userIdClaim.Value);

                if (rentOrder.Order.UserId != userId)
                {
                    return Forbid();
                }

                // Get the original return date for the notification
                DateTime originalReturnDate = rentOrder.ExpectedReturnDate;

                var result = await _rentOrderService.ExtendRentalPeriodAsync(id, request.NewExpectedReturnDate);

                // Get equipment summary for more detailed notification
                string equipmentSummary = await GetEquipmentSummaryForRental(rentOrder);

                // Send notification to the customer about the extension
                await _notificationService.NotifyUser(
                    userId,
                    "RentalExtended",
                    "Rental Period Extended",
                    $"Your rental period has been extended to {request.NewExpectedReturnDate.ToShortDateString()}",
                    new Dictionary<string, object>
                    {
                { "RentalId", id },
                { "OriginalReturnDate", originalReturnDate },
                { "NewReturnDate", request.NewExpectedReturnDate },
                { "ExtensionDays", (request.NewExpectedReturnDate - originalReturnDate).Days },
                { "EquipmentSummary", equipmentSummary },
                { "ExtensionDate", DateTime.UtcNow }
                    });

                return Ok(ApiResponse<bool>.SuccessResponse(true, "Rental period extended successfully"));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }

        // Helper method to get a summary of equipment in a rental
        private async Task<string> GetEquipmentSummaryForRental(RentOrder rentOrder)
        {
            try
            {
                // Build a summary of the equipment in the order
                var equipmentItems = new List<string>();

                // Filter for hotpot rentals from RentOrderDetails
                var hotpotRentals = rentOrder.RentOrderDetails
                    .Where(d => d.HotpotInventory != null && d.HotpotInventory.Hotpot != null)
                    .ToList();

                if (hotpotRentals.Any())
                {
                    var hotpotCount = hotpotRentals.Count;
                    equipmentItems.Add($"{hotpotCount} hot pot{(hotpotCount > 1 ? "s" : "")}");
                }

                // Group hotpots by type if you want more detailed information
                // This assumes Hotpot has a Type or Category property
                // If it doesn't, you can remove this section
                var hotpotGroups = hotpotRentals
                    .GroupBy(d => d.HotpotInventory?.Hotpot?.GetType().Name ?? "Other Hotpots")
                    .Where(g => g.Key != "Other Hotpots" || g.Any())
                    .Select(g => $"{g.Count()} {g.Key}");

                if (hotpotGroups.Any())
                {
                    equipmentItems.AddRange(hotpotGroups);
                }

                // Since your model doesn't have UtensilRentals, we'll skip that part
                // If you add utensil support in the future, you can uncomment and adapt this section

                return equipmentItems.Any()
                    ? string.Join(", ", equipmentItems)
                    : "equipment";
            }
            catch (Exception)
            {
                // If there's any error getting the equipment summary, return a generic message
                return "equipment";
            }
        }
    }
}

