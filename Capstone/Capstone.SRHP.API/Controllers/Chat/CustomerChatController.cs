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

[Route("api/customer/chat")]
[ApiController]
[Authorize(Roles = "Customer")]
public class CustomerChatController : ControllerBase
{
    private readonly IChatService _chatService;
    private readonly SocketIOClientService _socketService;
    private readonly IHubContext<ChatHub> _hubContext;


    public CustomerChatController(IChatService chatService, SocketIOClientService socketService, IHubContext<ChatHub> hubContext)
    {
        _chatService = chatService;
        _socketService = socketService;
        _hubContext = hubContext;
    }

    // CUSTOMER-SPECIFIC ENDPOINTS

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


    [HttpPost("sessions")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<ApiResponse<ChatSessionDto>>> CreateChatSession([FromBody] CreateChatSessionRequest request)
    {
        try
        {
            // Validate request
            if (request == null || request.CustomerId <= 0 || string.IsNullOrWhiteSpace(request.Topic))
            {
                return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse("Invalid request. Customer ID and topic are required."));
            }

            var session = await _chatService.CreateChatSessionAsync(request.CustomerId, request.Topic);

            // Notify managers about the new chat request via Socket.IO
            await _socketService.SendNewChatRequestAsync(
                session.ChatSessionId,
                session.CustomerId,
                session.CustomerName,
                session.Topic,
                session.CreatedAt);

            return CreatedAtAction(nameof(GetChatSession), new { sessionId = session.ChatSessionId },
                ApiResponse<ChatSessionDto>.SuccessResponse(session, "Chat session created successfully"));
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
                ApiResponse<ChatSessionDto>.ErrorResponse("An error occurred while creating the chat session. Please try again later."));
        }
    }

    //[HttpPost("sessions")]
    //[ProducesResponseType(StatusCodes.Status201Created)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //public async Task<ActionResult<ApiResponse<ChatSessionDto>>> CreateChatSession([FromBody] CreateChatSessionRequest request)
    //{
    //    try
    //    {
    //        if (request == null || request.CustomerId <= 0 || string.IsNullOrWhiteSpace(request.Topic))
    //        {
    //            return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse("Invalid request. Customer ID and topic are required."));
    //        }

    //        var session = await _chatService.CreateChatSessionAsync(request.CustomerId, request.Topic);

    //        // Notify managers about the new chat request via SignalR
    //        // Assuming managers are in a "Managers" group or you have a way to target them.
    //        // The client-side method to listen for would be "ReceiveNewChatRequest".
    //        await _hubContext.Clients.Group("Managers").SendAsync("ReceiveNewChatRequest", new
    //        {
    //            chatSessionId = session.ChatSessionId,
    //            customerId = session.CustomerId,
    //            customerName = session.CustomerName,
    //            topic = session.Topic,
    //            createdAt = session.CreatedAt
    //        });
    //        // Or call a method on the hub if you defined one:
    //        // await _hubContext.Clients.All.SendAsync("NotifyManagersOfNewChatRequest", session); // If ChatHub has this method

    //        return CreatedAtAction(nameof(GetChatSession), new { sessionId = session.ChatSessionId },
    //            ApiResponse<ChatSessionDto>.SuccessResponse(session, "Chat session created successfully"));
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
    //            ApiResponse<ChatSessionDto>.ErrorResponse("An error occurred while creating the chat session. Please try again later."));
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
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //[ProducesResponseType(StatusCodes.Status400BadRequest)]
    //public async Task<ActionResult<ApiResponse<ChatSessionDto>>> EndChatSession(int sessionId)
    //{
    //    try
    //    {
    //        var session = await _chatService.EndChatSessionAsync(sessionId);

    //        // Notify both parties that the chat has ended via SignalR.
    //        // Clients should listen for "ReceiveChatEnded".
    //        string sessionGroup = $"session_{sessionId}";
    //        await _hubContext.Clients.Group(sessionGroup).SendAsync("ReceiveChatEnded", sessionId, session.CustomerId, session.ManagerId);

    //        // More targeted:
    //        await _hubContext.Clients.Group($"user_{session.CustomerId}").SendAsync("ReceiveChatEnded", sessionId);
    //        if (session.ManagerId.HasValue)
    //        {
    //            await _hubContext.Clients.Group($"user_{session.ManagerId.Value}").SendAsync("ReceiveChatEnded", sessionId);
    //        }


    //        return Ok(ApiResponse<ChatSessionDto>.SuccessResponse(session, "Chat session ended successfully"));
    //    }
    //    catch (NotFoundException ex)
    //    {
    //        return NotFound(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
    //    }
    //    catch (Exception ex) // Catch specific exceptions
    //    {
    //        // Log the exception (ex)
    //        return BadRequest(ApiResponse<ChatSessionDto>.ErrorResponse(ex.Message));
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
    //[ProducesResponseType(StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status404NotFound)]
    //public async Task<ActionResult<ApiResponse<bool>>> MarkMessageAsRead(int messageId)
    //{
    //    try
    //    {
    //        var result = await _chatService.MarkMessageAsReadAsync(messageId);
    //        if (!result)
    //            return NotFound(ApiResponse<bool>.ErrorResponse($"Message with ID {messageId} not found"));

    //        var message = await _chatService.GetMessageByIdAsync(messageId); // Potentially redundant if MarkMessageAsReadAsync could return the message
    //        if (message != null)
    //        {
    //            // Notify the original sender that the message was read.
    //            // Client listens for "ReceiveMessageReadConfirmation".
    //            await _hubContext.Clients.Group($"user_{message.SenderUserId}")
    //                                     .SendAsync("ReceiveMessageReadConfirmation", messageId, message.ReceiverUserId);
    //        }

    //        return Ok(ApiResponse<bool>.SuccessResponse(true, "Message marked as read successfully"));
    //    }
    //    catch (NotFoundException ex) // If GetMessageByIdAsync throws NotFoundException
    //    {
    //        return NotFound(ApiResponse<bool>.ErrorResponse(ex.Message));
    //    }
    //    // Catch other specific exceptions
    //}

    [HttpGet("messages/unread/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatMessageDto>>>> GetUnreadMessages(int userId)
    {
        var messages = await _chatService.GetUnreadMessagesAsync(userId);
        return Ok(ApiResponse<IEnumerable<ChatMessageDto>>.SuccessResponse(messages, "Unread messages retrieved successfully"));
    }

    [HttpGet("sessions/customer/{customerId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ApiResponse<IEnumerable<ChatSessionDto>>>> GetCustomerChatHistory(int customerId)
    {
        try
        {
            var sessions = await _chatService.GetCustomerChatHistoryAsync(customerId);
            return Ok(ApiResponse<IEnumerable<ChatSessionDto>>.SuccessResponse(sessions, "Customer chat history retrieved successfully"));
        }
        catch (NotFoundException ex)
        {
            return NotFound(ApiResponse<IEnumerable<ChatSessionDto>>.ErrorResponse(ex.Message));
        }
    }
}