using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Chat;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Khách hàng")]

public class CustomerChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly IHubContext<ChatHub> _chatHubContext;

    public CustomerChatController(IChatService chatService, IHubContext<ChatHub> chatHubContext)
    {
        _chatService = chatService;
        _chatHubContext = chatHubContext;
    }

    // CUSTOMER-SPECIFIC ENDPOINTS

    [HttpGet("sessions/{sessionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<ChatSession>>> GetChatSession(int sessionId)
    {
        try
        {
            var session = await _chatService.GetChatSessionAsync(sessionId);
            if (session == null)
                return NotFound(ApiResponse<ChatSession>.ErrorResponse($"Chat session with ID {sessionId} not found"));

            return Ok(ApiResponse<ChatSession>.SuccessResponse(session, "Chat session retrieved successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<ChatSession>.ErrorResponse(ex.Message));
        }
    }

    [HttpPost("sessions")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<ChatSession>>> CreateChatSession([FromBody] CreateChatSessionRequest request)
    {
        try
        {
            // Validate request
            if (request == null || request.CustomerId <= 0 || string.IsNullOrWhiteSpace(request.Topic))
            {
                return BadRequest(ApiResponse<ChatSession>.ErrorResponse("Invalid request. Customer ID and topic are required."));
            }

            var session = await _chatService.CreateChatSessionAsync(request.CustomerId, request.Topic);

            // Get customer name directly from the User entity
            string customerName = "Customer";
            if (session.Customer != null)
            {
                customerName = session.Customer.Name ?? "Customer";
            }

            // Notify managers about the new chat request via SignalR
            await _chatHubContext.Clients.Group("Managers").SendAsync("NewChatRequest",
                session.ChatSessionId,
                session.CustomerId,
                customerName,
                session.Topic,
                session.CreatedAt);

            return CreatedAtAction(nameof(GetChatSession), new { sessionId = session.ChatSessionId },
                ApiResponse<ChatSession>.SuccessResponse(session, "Chat session created successfully"));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ApiResponse<ChatSession>.ErrorResponse(ex.Message));
        }
        catch (ValidationException ex)
        {
            return BadRequest(ApiResponse<ChatSession>.ErrorResponse(ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ApiResponse<ChatSession>.ErrorResponse("An error occurred while creating the chat session. Please try again later."));
        }
    }

    // SHARED FUNCTIONALITY ENDPOINTS

    [HttpGet("messages/session/{sessionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatMessage>>>> GetSessionMessages(
        int sessionId,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 20)
    {
        try
        {
            var messages = await _chatService.GetSessionMessagesAsync(sessionId, pageNumber, pageSize);
            return Ok(ApiResponse<IEnumerable<ChatMessage>>.SuccessResponse(messages, "Session messages retrieved successfully"));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ApiResponse<IEnumerable<ChatMessage>>.ErrorResponse(ex.Message));
        }
    }

    [HttpPost("messages")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ApiResponse<ChatMessage>>> SendMessage([FromBody] SendMessageRequest request)
    {
        try
        {
            var message = await _chatService.SaveMessageAsync(request.SenderId, request.ReceiverId, request.Message);

            // Send the message to the receiver via SignalR
            await _chatHubContext.Clients.User(request.ReceiverId.ToString()).SendAsync("ReceiveMessage",
                message.ChatMessageId,
                message.SenderUserId,
                message.ReceiverUserId,
                message.Message,
                message.CreatedAt);

            return Ok(ApiResponse<ChatMessage>.SuccessResponse(message, "Message sent successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<ChatMessage>.ErrorResponse(ex.Message));
        }
    }

    [HttpPut("sessions/{sessionId}/end")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ApiResponse<ChatSession>>> EndChatSession(int sessionId)
    {
        try
        {
            var session = await _chatService.EndChatSessionAsync(sessionId);

            // Notify both parties that the chat has ended
            if (session.Customer != null)
            {
                await _chatHubContext.Clients.User(session.Customer.UserId.ToString()).SendAsync("ChatEnded", sessionId);
            }

            if (session.Manager != null && session.ManagerId.HasValue)
            {
                await _chatHubContext.Clients.User(session.ManagerId.Value.ToString()).SendAsync("ChatEnded", sessionId);
            }

            return Ok(ApiResponse<ChatSession>.SuccessResponse(session, "Chat session ended successfully"));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ApiResponse<ChatSession>.ErrorResponse(ex.Message));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<ChatSession>.ErrorResponse(ex.Message));
        }
    }

    [HttpPut("messages/{messageId}/read")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<bool>>> MarkMessageAsRead(int messageId)
    {
        var result = await _chatService.MarkMessageAsReadAsync(messageId);
        if (!result)
            return NotFound(ApiResponse<bool>.ErrorResponse($"Message with ID {messageId} not found"));

        // Get the message to notify the sender
        var message = await _chatService.GetMessageByIdAsync(messageId);
        if (message != null)
        {
            await _chatHubContext.Clients.User(message.SenderUserId.ToString()).SendAsync("MessageRead", messageId);
        }

        return Ok(ApiResponse<bool>.SuccessResponse(true, "Message marked as read successfully"));
    }

    [HttpGet("messages/unread/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatMessage>>>> GetUnreadMessages(int userId)
    {
        var messages = await _chatService.GetUnreadMessagesAsync(userId);
        return Ok(ApiResponse<IEnumerable<ChatMessage>>.SuccessResponse(messages, "Unread messages retrieved successfully"));
    }
}