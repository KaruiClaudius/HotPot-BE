using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.DTOs.Shipping;
using Capstone.HPTY.ServiceLayer.Interfaces.ShippingService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.HPTY.API.Controllers.Staff
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Staff")]

    public class StaffProofOfDeliveryController : ControllerBase
    {
        private readonly IStaffShippingService _staffShippingService;
        private readonly ILogger<StaffProofOfDeliveryController> _logger;

        public StaffProofOfDeliveryController(
            IStaffShippingService staffShippingService,
            ILogger<StaffProofOfDeliveryController> logger)
        {
            _staffShippingService = staffShippingService;
            _logger = logger;
        }

        /// Save proof of delivery for a shipping order
        [HttpPost("{shippingOrderId}")]
        [ProducesResponseType(typeof(ApiResponse<ProofOfDeliveryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ProofOfDeliveryResponse>>> SaveProofOfDelivery(
            int shippingOrderId,
            [FromBody] ProofOfDeliveryRequest request)
        {
            try
            {
                _logger.LogInformation("Staff saving proof of delivery for shipping order ID: {ShippingOrderId}", shippingOrderId);

                var result = await _staffShippingService.SaveProofOfDeliveryAsync(shippingOrderId, request);

                return Ok(new ApiResponse<ProofOfDeliveryResponse>
                {
                    Success = true,
                    Message = "Proof of delivery saved successfully",
                    Data = result
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Shipping order not found with ID: {ShippingOrderId}", shippingOrderId);

                return NotFound(new ApiErrorResponse
                {
                    Status = "Not Found",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving proof of delivery for shipping order ID: {ShippingOrderId}", shippingOrderId);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to save proof of delivery"
                });
            }
        }


        /// Get proof of delivery for a shipping order
        [HttpGet("{shippingOrderId}")]
        [ProducesResponseType(typeof(ApiResponse<ProofOfDeliveryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ProofOfDeliveryDto>>> GetProofOfDelivery(int shippingOrderId)
        {
            try
            {
                _logger.LogInformation("Staff retrieving proof of delivery for shipping order ID: {ShippingOrderId}", shippingOrderId);

                var proofOfDelivery = await _staffShippingService.GetProofOfDeliveryAsync(shippingOrderId);

                return Ok(new ApiResponse<ProofOfDeliveryDto>
                {
                    Success = true,
                    Message = "Proof of delivery retrieved successfully",
                    Data = proofOfDelivery
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Proof of delivery not found for shipping order ID: {ShippingOrderId}", shippingOrderId);

                return NotFound(new ApiErrorResponse
                {
                    Status = "Not Found",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving proof of delivery for shipping order ID: {ShippingOrderId}", shippingOrderId);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to retrieve proof of delivery"
                });
            }
        }

      
        /// Upload proof of delivery image with form data
        [HttpPost("{shippingOrderId}/upload")]
        [ProducesResponseType(typeof(ApiResponse<ProofOfDeliveryResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<ProofOfDeliveryResponse>>> UploadProofOfDelivery(
            int shippingOrderId,
            [FromForm] ProofOfDeliveryFormRequest request)
        {
            try
            {
                _logger.LogInformation("Staff uploading proof of delivery image for shipping order ID: {ShippingOrderId}", shippingOrderId);

                // Convert IFormFile to base64 string
                string base64Image = null;
                string imageType = null;

                if (request.ProofImage != null && request.ProofImage.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await request.ProofImage.CopyToAsync(memoryStream);
                        byte[] imageBytes = memoryStream.ToArray();
                        base64Image = Convert.ToBase64String(imageBytes);
                        imageType = request.ProofImage.ContentType;
                    }
                }

                // Create request object for the service
                var proofRequest = new ProofOfDeliveryRequest
                {
                    Base64Image = base64Image,
                    ImageType = imageType,
                    Base64Signature = request.Base64Signature,
                    DeliveryNotes = request.DeliveryNotes
                };

                var result = await _staffShippingService.SaveProofOfDeliveryAsync(shippingOrderId, proofRequest);

                return Ok(new ApiResponse<ProofOfDeliveryResponse>
                {
                    Success = true,
                    Message = "Proof of delivery uploaded successfully",
                    Data = result
                });
            }
            catch (NotFoundException ex)
            {
                _logger.LogWarning(ex, "Shipping order not found with ID: {ShippingOrderId}", shippingOrderId);

                return NotFound(new ApiErrorResponse
                {
                    Status = "Not Found",
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error uploading proof of delivery for shipping order ID: {ShippingOrderId}", shippingOrderId);

                return BadRequest(new ApiErrorResponse
                {
                    Status = "Error",
                    Message = "Failed to upload proof of delivery"
                });
            }
        }
    }
}