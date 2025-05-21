using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Management;
using Capstone.HPTY.ServiceLayer.Interfaces.UserService;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Enum;
using Capstone.HPTY.ServiceLayer.Interfaces.ReplacementService;
using Capstone.HPTY.RepositoryLayer.Utils;

namespace Capstone.HPTY.API.Controllers.Customer
{
    [Route("api/customer/replacement")]
    [ApiController]
    [Authorize(Roles = "Customer")]

    public class CustomerReplacementController : ControllerBase
    {
        private readonly IReplacementRequestService _replacementService;
        private readonly IUserService _userService;

        public CustomerReplacementController(
            IReplacementRequestService replacementService,
            IUserService userService)
        {
            _replacementService = replacementService;
            _userService = userService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>>> GetMyReplacementRequests()
        {
            // Get the current customer ID using your custom AuthenTools
            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null)
                return Unauthorized("Không tìm thấy ID người dùng trong thông tin xác thực");

            int customerId = int.Parse(userIdClaim.Value);

            // Get user and verify they are a customer
            var user = await _userService.GetByIdAsync(customerId);
            if (user == null || user.Role.Name != "Customer")
                return BadRequest(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.ErrorResponse("User is not a customer"));

            // Get replacement requests for this user
            var requests = await _replacementService.GetCustomerReplacementRequestsAsync(customerId);
            var dtos = requests.Select(MapToSummaryDto).ToList();

            return Ok(ApiResponse<IEnumerable<ReplacementRequestSummaryDto>>.SuccessResponse(
                dtos, "Lấy danh sách yêu cầu thay thế thành công"));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> GetReplacementRequestById(int id)
        {
            // Get the current customer ID using your custom AuthenTools
            var userIdClaim = User.FindFirst("id");
            if (userIdClaim == null)
                return Unauthorized("Không tìm thấy ID người dùng trong thông tin xác thực");

            int customerId = int.Parse(userIdClaim.Value);

            // Get user and verify they are a customer
            var user = await _userService.GetByIdAsync(customerId);
            if (user == null || user.Role.Name != "Customer")
                return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse("Người dùng không phải là khách hàng"));

            var request = await _replacementService.GetReplacementRequestByIdAsync(id);

            if (request == null)
                return NotFound(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse($"Không tìm thấy yêu cầu thay thế với ID {id}"));

            // Ensure the customer owns this request
            if (request.CustomerId != customerId)
                return Forbid();

            var dto = MapToDetailDto(request);

            return Ok(ApiResponse<ReplacementRequestDetailDto>.SuccessResponse(
                dto, "Lấy thông tin yêu cầu thay thế thành công"));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ReplacementRequestDetailDto>>> CreateReplacementRequest(
      [FromBody] CreateReplacementRequestDto createDto)
        {
            try
            {
                // Get the current customer ID using your custom AuthenTools
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized("Không tìm thấy ID người dùng trong thông tin xác thực");

                int customerId = int.Parse(userIdClaim.Value);

                // Get user and verify they are a customer
                var user = await _userService.GetByIdAsync(customerId);
                if (user == null || user.Role.Name != "Customer")
                    return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse("Người dùng không phải là khách hàng"));

                // Validate HotPotInventoryId is provided
                if (!createDto.HotPotInventoryId.HasValue)
                    return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse("Cần cung cấp ID của nồi lẩu"));

                // Create the replacement request
                var request = new ReplacementRequest
                {
                    RequestReason = createDto.RequestReason,
                    AdditionalNotes = createDto.AdditionalNotes,
                    HotPotInventoryId = createDto.HotPotInventoryId,
                    CustomerId = customerId
                };

                var createdRequest = await _replacementService.CreateReplacementRequestAsync(request);
                var dto = MapToDetailDto(createdRequest);

                return CreatedAtAction(nameof(GetReplacementRequestById), new { id = createdRequest.ReplacementRequestId },
                    ApiResponse<ReplacementRequestDetailDto>.SuccessResponse(dto, "Tạo yêu cầu thay thế thành công"));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<ReplacementRequestDetailDto>.ErrorResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<bool>>> CancelReplacementRequest(int id)
        {
            try
            {
                // Get the current customer ID from the authenticated user
                var userIdClaim = User.FindFirst("id");
                if (userIdClaim == null)
                    return Unauthorized("Không tìm thấy ID người dùng trong thông tin xác thực");

                int customerId = int.Parse(userIdClaim.Value);

                // Get user and verify they are a customer
                var user = await _userService.GetByIdAsync(customerId);
                if (user == null || user.Role.Name != "Customer")
                    return BadRequest(ApiResponse<bool>.ErrorResponse("Người dùng không phải là khách hàng"));

                await _replacementService.CancelReplacementRequestAsync(id, customerId);

                return Ok(ApiResponse<bool>.SuccessResponse(true, "Hủy yêu cầu thay thế thành công"));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                return BadRequest(ApiResponse<bool>.ErrorResponse(ex.Message));
            }
        }

        #region Helper Methods

        private ReplacementRequestSummaryDto MapToSummaryDto(ReplacementRequest request)
        {
            string equipmentName = "";

            if (request.HotPotInventory != null)
            {
                equipmentName = request.HotPotInventory.Hotpot?.Name ?? $"HotPot #{request.HotPotInventory.SeriesNumber}";
            }

            return new ReplacementRequestSummaryDto
            {
                ReplacementRequestId = request.ReplacementRequestId,
                RequestReason = request.RequestReason,
                Status = request.Status,
                RequestDate = request.RequestDate,
                ReviewDate = request.ReviewDate,
                CompletionDate = request.CompletionDate,
                // Remove EquipmentType property or set a default value
                EquipmentName = equipmentName,
                CustomerName = request.Customer?.Name ?? "Unknown Customer",
                AssignedStaffName = request.AssignedStaff?.Name
            };
        }

        private ReplacementRequestDetailDto MapToDetailDto(ReplacementRequest request)
        {
            return new ReplacementRequestDetailDto
            {
                ReplacementRequestId = request.ReplacementRequestId,
                RequestReason = request.RequestReason,
                AdditionalNotes = request.AdditionalNotes,
                Status = request.Status,
                RequestDate = request.RequestDate,
                ReviewDate = request.ReviewDate,
                ReviewNotes = request.ReviewNotes,
                CompletionDate = request.CompletionDate,

                CustomerId = request.CustomerId,
                CustomerName = request.Customer?.Name ?? "Unknown Customer",
                CustomerEmail = request.Customer?.Email ?? "Unknown Email",
                CustomerPhone = request.Customer?.PhoneNumber ?? "Unknown Phone",

                AssignedStaffId = request.AssignedStaffId,
                AssignedStaffName = request.AssignedStaff?.Name,

                HotPotInventoryId = request.HotPotInventoryId,
                HotPotSeriesNumber = request.HotPotInventory?.SeriesNumber,
                HotPotName = request.HotPotInventory?.Hotpot?.Name,

            };
        }

        #endregion
    }
}


