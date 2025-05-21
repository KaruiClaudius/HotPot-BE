using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Chat;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Capstone.HPTY.ServiceLayer.Services.ChatService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/chat")]
[ApiController]
[Authorize]
public class ChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly SocketIOClientService _socketService;
    private readonly ILogger<ChatController> _logger;

    public ChatController(IChatService chatService, SocketIOClientService socketService, ILogger<ChatController> logger)
    {
        _chatService = chatService;
        _socketService = socketService;
        _logger = logger;
    }

    [HttpGet("sessions/{sessionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<ChatSessionDetailDto>>> GetChatSession(int sessionId)
    {
        try
        {
            var session = await _chatService.GetChatSessionAsync(sessionId);
            if (session == null)
                return NotFound(ApiResponse<ChatSessionDetailDto>.ErrorResponse($"Chat session not found"));

            return Ok(ApiResponse<ChatSessionDetailDto>.SuccessResponse(session, "Chat session retrieved"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<ChatSessionDetailDto>.ErrorResponse(ex.Message));
        }
    }

    [HttpPost("customer/sessions")]
    [Authorize(Roles = "Customer")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ApiResponse<ChatSessionDto>>> CreateChatSession([FromBody] CreateChatSessionRequest request)
    {
        try
        {
            var session = await _chatService.CreateChatSessionAsync(request.CustomerId, request.Topic);

            // Notify managers about new chat
            await _socketService.NotifyEvent("newChat", new
            {
                sessionId = session.ChatSessionId,
                customerId = session.CustomerId,
                customerName = session.CustomerName,
                topic = session.Topic
            });

            return CreatedAtAction(nameof(GetChatSession), new { sessionId = session.ChatSessionId },
                ApiResponse<ChatSessionDto>.SuccessResponse(session, "Chat session created"));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating chat session");
            return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
        }
    }

    [HttpPost("sessions/manager/{sessionId}/join")]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<ChatSessionDto>>> JoinChatSession(int sessionId)
    {
        try
        {
            // Get current manager ID from claims
            var managerId = int.Parse(User.FindFirst("id")?.Value ?? "0");
            if (managerId == 0)
                return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse("User ID not found in token"));

            var session = await _chatService.AssignManagerToChatSessionAsync(sessionId, managerId);

            // Notify customer that chat was accepted
            await _socketService.NotifyEvent("chatAccepted", new
            {
                sessionId = session.ChatSessionId,
                managerId = session.ManagerId,
                managerName = session.ManagerName,
                customerId = session.CustomerId
            });

            return Ok(ApiResponse<ChatSessionDto>.SuccessResponse(session, "Joined chat session"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
        }
    }

    [HttpPost("messages")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ApiResponse<ChatMessageDto>>> SendMessage([FromBody] SendMessageRequest request)
    {
        try
        {
            var message = await _chatService.SaveMessageAsync(request.SenderId, request.ReceiverId, request.Message);

            // Notify receiver about new message
            await _socketService.NotifyEvent("newMessage", new
            {
                messageId = message.ChatMessageId,
                senderId = message.SenderUserId,
                receiverId = message.ReceiverUserId,
                content = message.Message,
                timestamp = message.CreatedAt
            });

            return Ok(ApiResponse<ChatMessageDto>.SuccessResponse(message, "Message sent"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<ChatMessageDto>.ErrorResponse(ex.Message));
        }
    }

    [HttpGet("messages/session/{sessionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatMessageDto>>>> GetSessionMessages(
        int sessionId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20)
    {
        try
        {
            var messages = await _chatService.GetSessionMessagesAsync(sessionId, pageNumber, pageSize);
            return Ok(ApiResponse<IEnumerable<ChatMessageDto>>.SuccessResponse(messages, "Messages retrieved"));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ApiResponse<IEnumerable<ChatMessageDto>>.ErrorResponse(ex.Message));
        }
    }

    [HttpPut("sessions/{sessionId}/end")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<ChatSessionDto>>> EndChatSession(int sessionId)
    {
        try
        {
            var session = await _chatService.EndChatSessionAsync(sessionId);

            // Notify both parties that chat has ended
            await _socketService.NotifyEvent("chatEnded", new
            {
                sessionId = session.ChatSessionId,
                customerId = session.CustomerId,
                managerId = session.ManagerId
            });

            return Ok(ApiResponse<ChatSessionDto>.SuccessResponse(session, "Chat ended"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
        }
    }

    [HttpGet("manager/sessions/active")]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatSessionDto>>>> GetActiveSessions()
    {
        var sessions = await _chatService.GetActiveChatSessionsAsync();
        return Ok(ApiResponse<IEnumerable<ChatSessionDto>>.SuccessResponse(sessions, "Active sessions retrieved"));
    }

    [HttpGet("manager/sessions/history")]
    [Authorize(Roles = "Manager")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatSessionDto>>>> GetChatHistory()
    {
        try
        {
            // Get current manager ID from claims
            var managerId = int.Parse(User.FindFirst("id")?.Value ?? "0");
            if (managerId == 0)
                return BadRequest(ApiResponse<IEnumerable<ChatSessionDto>>.ErrorResponse("User ID not found in token"));

            var sessions = await _chatService.GetManagerChatHistoryAsync(managerId);
            return Ok(ApiResponse<IEnumerable<ChatSessionDto>>.SuccessResponse(sessions, "Chat history retrieved"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<IEnumerable<ChatSessionDto>>.ErrorResponse(ex.Message));
        }
    }
}