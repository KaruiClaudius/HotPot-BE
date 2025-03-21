using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Order;
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
                var userIdClaim = User.FindFirst("uid");
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
                var userIdClaim = User.FindFirst("uid");
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalDetail(int id)
        {
            try
            {
                var rentOrderDetail = await _equipmentReturnService.GetRentOrderDetailAsync(id);

                // Verify the rental belongs to the current user
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int userId = int.Parse(userIdClaim.Value);

                if (rentOrderDetail.Order.UserId != userId)
                {
                    return Forbid();
                }

                return Ok(rentOrderDetail);
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

        [HttpPost("{id}/extend")]
        public async Task<IActionResult> ExtendRentalPeriod(int id, [FromBody] ExtendRentalRequest request)
        {
            try
            {
                // Verify the rental belongs to the current user
                var rentOrderDetail = await _equipmentReturnService.GetRentOrderDetailAsync(id);
                var userIdClaim = User.FindFirst("uid");
                if (userIdClaim == null)
                    return Unauthorized("User ID not found in claims");

                int userId = int.Parse(userIdClaim.Value);

                if (rentOrderDetail.Order.UserId != userId)
                {
                    return Forbid();
                }

                var result = await _rentOrderService.ExtendRentalPeriodAsync(id, request.NewExpectedReturnDate);

                // Send notification to the customer about the extension
                await _notificationService.NotifyCustomerRentalExtendedAsync(
                    userId,
                    id,
                    request.NewExpectedReturnDate);

                return Ok(new { message = "Rental period extended successfully" });
            }
            catch (NotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
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

    }
}

