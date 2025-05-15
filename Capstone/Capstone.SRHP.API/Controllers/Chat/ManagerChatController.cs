using Capstone.HPTY.API.Hubs;
using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Chat;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Capstone.HPTY.ServiceLayer.Interfaces.ChatService;
using Capstone.HPTY.ServiceLayer.Services.ChatService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
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
    private readonly IHubContext<ChatHub> _hubContext;

    public ManagerChatController(IChatService chatService, SocketIOClientService socketService, IHubContext<ChatHub> hubContext)
    {
        _chatService = chatService;
        _socketService = socketService;
        _hubContext = hubContext;
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

    //[HttpPut("sessions/{sessionId}/assign")]
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //public async Task<ActionResult<ApiResponse<ChatSessionDto>>> AssignManagerToSession(
    //        int sessionId,
    //        [FromBody] AssignManagerRequest request) // Assuming AssignManagerRequest has ManagerId
    //{
    //    try
    //    {
    //        if (request == null || request.ManagerId <= 0)
    //        {
    //            return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse("Invalid request. Manager ID is required."));
    //        }
    //        // Potentially validate that the request.ManagerId is the currently authenticated manager.

    //        var session = await _chatService.AssignManagerToChatSessionAsync(sessionId, request.ManagerId);

    //        // Notify the customer that a manager has accepted their chat via SignalR.
    //        // Client listens for "ReceiveChatAccepted".
    //        // Target the specific customer.
    //        await _hubContext.Clients.Group($"user_{session.CustomerId}").SendAsync("ReceiveChatAccepted", new
    //        {
    //            sessionId = session.ChatSessionId,
    //            managerId = session.ManagerId,
    //            managerName = session.ManagerName ?? "Manager", // Use actual manager name
    //            customerId = session.CustomerId
    //        });

    //        // Also, the manager who accepted might want to join a session-specific group
    //        // And the customer should also join this group to receive messages for this session.
    //        string sessionGroup = $"session_{sessionId}";
    //        // The hub's OnConnected or a dedicated client-invokable hub method should handle group joining.
    //        // For instance, after accepting, the manager's client could call:
    //        // await connection.invoke("JoinChatSessionGroup", sessionId.toString());
    //        // And the customer's client too.

    //        return Ok(ApiResponse<ChatSessionDto>.SuccessResponse(session, "Manager assigned to chat session successfully"));
    //    }
    //    catch (NotFoundException ex)
    //    {
    //        return NotFound(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
    //    }
    //    catch (ValidationException ex) // Assuming ValidationException is a custom exception
    //    {
    //        return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
    //    }
    //    catch (Exception ex)
    //    {
    //        // Log the exception ex
    //        return StatusCode(StatusCodes.Status500InternalServerError,
    //            ApiResponse<ChatSessionDto>.ErrorResponse("An error occurred while assigning the manager. Please try again later."));
    //    }
    //}

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

    //[HttpPut("sessions/{sessionId}/end")]
    //public async Task<ActionResult<ApiResponse<ChatSessionDto>>> EndChatSession(int sessionId)
    //{
    //    // Implementation similar to CustomerChatController, using _hubContext
    //    try
    //    {
    //        var session = await _chatService.EndChatSessionAsync(sessionId);
    //        await _hubContext.Clients.Group($"user_{session.CustomerId}").SendAsync("ReceiveChatEnded", sessionId);
    //        if (session.ManagerId.HasValue)
    //        {
    //            await _hubContext.Clients.Group($"user_{session.ManagerId.Value}").SendAsync("ReceiveChatEnded", sessionId);
    //        }
    //        // Or more broadly to a session group:
    //        // await _hubContext.Clients.Group($"session_{sessionId}").SendAsync("ReceiveChatEnded", sessionId);
    //        return Ok(ApiResponse<ChatSessionDto>.SuccessResponse(session, "Chat session ended successfully"));
    //    }
    //    catch (NotFoundException ex)
    //    {
    //        return NotFound(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
    //    }
    //    catch (Exception ex)
    //    {
    //        return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
    //    }
    //}

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

    //[HttpPost("messages")]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //public async Task<ActionResult<ApiResponse<ChatMessageDto>>> SendMessage([FromBody] SendMessageRequest request)
    //{
    //    try
    //    {
    //        // Validate that the sender is the authenticated user
    //        var currentUserId = int.Parse(User.FindFirst("id")?.Value ?? "0");
    //        if (currentUserId != request.SenderId)
    //        {
    //            return Unauthorized(ApiResponse<ChatMessageDto>.ErrorResponse("You can only send messages as yourself"));
    //        }

    //        if (string.IsNullOrWhiteSpace(request.Message))
    //        {
    //            return BadRequest(ApiResponse<ChatMessageDto>.ErrorResponse("Message cannot be empty"));
    //        }

    //        var message = await _chatService.SaveMessageAsync(request.SenderId, request.ReceiverId, request.Message);

    //        // Get the chat session to determine the session ID
    //        var chatSession = await _chatService.GetChatSessionForUsersAsync(request.SenderId, request.ReceiverId);
    //        if (chatSession == null)
    //        {
    //            return BadRequest(ApiResponse<ChatMessageDto>.ErrorResponse("No active chat session found between these users"));
    //        }

    //        // Send to session group
    //        await _hubContext.Clients.Group($"session_{chatSession.ChatSessionId}")
    //            .SendAsync("ReceiveMessage", message);

    //        // Also send to specific users for redundancy
    //        await _hubContext.Clients.Group($"user_{message.ReceiverUserId}")
    //            .SendAsync("ReceiveMessage", message);
    //        await _hubContext.Clients.Group($"user_{message.SenderUserId}")
    //            .SendAsync("ReceiveMessage", message);

    //        return StatusCode(StatusCodes.Status201Created,
    //            ApiResponse<ChatMessageDto>.SuccessResponse(message, "Message sent successfully"));
    //    }
    //    catch (NotFoundException ex)
    //    {
    //        return NotFound(ApiResponse<ChatMessageDto>.ErrorResponse(ex.Message));
    //    }
    //    catch (Exception ex)
    //    {
    //        // Log the exception
    //        return StatusCode(StatusCodes.Status500InternalServerError,
    //            ApiResponse<ChatMessageDto>.ErrorResponse("An error occurred while sending the message"));
    //    }
    //}

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

    //[HttpPut("messages/{messageId}/read")]
    //public async Task<ActionResult<ApiResponse<bool>>> MarkMessageAsRead(int messageId)
    //{
    //    // Implementation similar to CustomerChatController, using _hubContext
    //    try
    //    {
    //        var result = await _chatService.MarkMessageAsReadAsync(messageId);
    //        if (!result) return NotFound(ApiResponse<bool>.ErrorResponse($"Message with ID {messageId} not found"));

    //        var message = await _chatService.GetMessageByIdAsync(messageId);
    //        if (message != null)
    //        {
    //            await _hubContext.Clients.Group($"user_{message.SenderUserId}")
    //                                     .SendAsync("ReceiveMessageReadConfirmation", messageId, message.ReceiverUserId);
    //        }
    //        return Ok(ApiResponse<bool>.SuccessResponse(true, "Message marked as read successfully"));
    //    }
    //    catch (NotFoundException ex)
    //    {
    //        return NotFound(ApiResponse<bool>.ErrorResponse(ex.Message));
    //    }
    //}

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