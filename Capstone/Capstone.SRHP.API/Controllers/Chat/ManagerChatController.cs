using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Chat;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Capstone.HPTY.ServiceLayer.Services.ChatService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/manager/chat")]
[ApiController]
[Authorize(Roles = "Manager")]
public class ManagerChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly SocketIOClientService _socketService;

    public ManagerChatController(IChatService chatService, SocketIOClientService socketService)
    {
        _chatService = chatService;
        _socketService = socketService;
    }

    // MANAGER-SPECIFIC ENDPOINTS

    [HttpGet("sessions/active")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatSessionDto>>>> GetActiveSessions()
    {
        var sessions = await _chatService.GetActiveChatSessionsAsync();
        return Ok(ApiResponse<IEnumerable<ChatSessionDto>>.SuccessResponse(sessions, "Active chat sessions retrieved successfully"));
    }

    [HttpGet("sessions/manager/{managerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatSessionDto>>>> GetManagerChatHistory(int managerId)
    {
        try
        {
            var sessions = await _chatService.GetManagerChatHistoryAsync(managerId);
            return Ok(ApiResponse<IEnumerable<ChatSessionDto>>.SuccessResponse(sessions, "Manager chat history retrieved successfully"));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ApiResponse<IEnumerable<ChatSessionDto>>.ErrorResponse(ex.Message));
        }
    }

    [HttpPut("sessions/{sessionId}/assign")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<ChatSessionDto>>> AssignManagerToSession(
    int sessionId,
    [FromBody] AssignManagerRequest request)
    {
        try
        {
            // Validate request
            if (request == null || request.ManagerId <= 0)
            {
                return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse("Invalid request. Manager ID is required."));
            }

            var session = await _chatService.AssignManagerToChatSessionAsync(sessionId, request.ManagerId);

            // Notify the customer that a manager has accepted their chat via Socket.IO
            await _socketService.SendChatAcceptedAsync(
                session.ChatSessionId,
                request.ManagerId,
                session.ManagerName ?? "Manager",
                session.CustomerId);

            return Ok(ApiResponse<ChatSessionDto>.SuccessResponse(session, "Manager assigned to chat session successfully"));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
        }
        catch (ValidationException ex)
        {
            return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ApiResponse<ChatSessionDto>.ErrorResponse("An error occurred while assigning the manager to the chat session. Please try again later."));
        }
    }

    // SHARED FUNCTIONALITY ENDPOINTS

    [HttpGet("messages/session/{sessionId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatMessageDto>>>> GetSessionMessages(
        int sessionId,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 20)
    {
        try
        {
            var messages = await _chatService.GetSessionMessagesAsync(sessionId, pageNumber, pageSize);
            return Ok(ApiResponse<IEnumerable<ChatMessageDto>>.SuccessResponse(messages, "Session messages retrieved successfully"));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ApiResponse<IEnumerable<ChatMessageDto>>.ErrorResponse(ex.Message));
        }
    }

    [HttpGet("messages/unread/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatMessageDto>>>> GetUnreadMessages(int userId)
    {
        var messages = await _chatService.GetUnreadMessagesAsync(userId);
        return Ok(ApiResponse<IEnumerable<ChatMessageDto>>.SuccessResponse(messages, "Unread messages retrieved successfully"));
    }

    [HttpGet("messages/unread/count/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<int>>> GetUnreadMessageCount(int userId)
    {
        var count = await _chatService.GetUnreadMessageCountAsync(userId);
        return Ok(ApiResponse<int>.SuccessResponse(count, "Unread message count retrieved successfully"));
    }

    [HttpPut("sessions/{sessionId}/end")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ApiResponse<ChatSessionDto>>> EndChatSession(int sessionId)
    {
        try
        {
            var session = await _chatService.EndChatSessionAsync(sessionId);

            // Notify both parties that the chat has ended via Socket.IO
            await _socketService.EndChatSessionAsync(
                sessionId,
                session.CustomerId,
                session.ManagerId);

            return Ok(ApiResponse<ChatSessionDto>.SuccessResponse(session, "Chat session ended successfully"));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
        }
    }

    [HttpPost("messages")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ApiResponse<ChatMessageDto>>> SendMessage([FromBody] SendMessageRequest request)
    {
        try
        {
            var message = await _chatService.SaveMessageAsync(request.SenderId, request.ReceiverId, request.Message);

            // Send the message to the receiver via Socket.IO
            await _socketService.SendMessageAsync(
                message.ChatMessageId,
                message.SenderUserId,
                message.ReceiverUserId,
                message.Message,
                message.CreatedAt);

            return Ok(ApiResponse<ChatMessageDto>.SuccessResponse(message, "Message sent successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<ChatMessageDto>.ErrorResponse(ex.Message));
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

        // Get the message to notify the sender via Socket.IO
        var message = await _chatService.GetMessageByIdAsync(messageId);
        if (message != null)
        {
            await _socketService.MarkMessageAsReadAsync(messageId, message.SenderUserId);
        }

        return Ok(ApiResponse<bool>.SuccessResponse(true, "Message marked as read successfully"));
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
                return NotFound(ApiResponse<ChatSessionDetailDto>.ErrorResponse($"Chat session with ID {sessionId} not found"));

            return Ok(ApiResponse<ChatSessionDetailDto>.SuccessResponse(session, "Chat session retrieved successfully"));
        }
        catch (Exception ex)
        {
            return BadRequest(ApiResponse<ChatSessionDetailDto>.ErrorResponse(ex.Message));
        }
    }
}