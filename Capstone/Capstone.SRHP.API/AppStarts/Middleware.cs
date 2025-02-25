using Capstone.HPTY.ModelLayer.Exceptions;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.API.AppStarts
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred");
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var errorResponse = new ApiErrorResponse
            {
                Status = "Error",
                Message = exception.Message,
                DetailedMessage = GetFullExceptionMessage(exception)
            };

            response.StatusCode = exception switch
            {
                ValidationException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedException => StatusCodes.Status401Unauthorized,
                DbUpdateException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            await response.WriteAsJsonAsync(errorResponse);
        }

        private static string GetFullExceptionMessage(Exception ex)
        {
            var messages = new List<string>();
            var currentEx = ex;

            while (currentEx != null)
            {
                messages.Add($"Exception: {currentEx.GetType().Name}\nMessage: {currentEx.Message}\nStack Trace: {currentEx.StackTrace}");
                currentEx = currentEx.InnerException;
            }

            return string.Join("\n\nInner ", messages);
        }
    }

    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Request Method: {Method}", context.Request.Method);
            _logger.LogInformation("Request Path: {Path}", context.Request.Path);
            _logger.LogInformation("Authorization Header: {Auth}",
                context.Request.Headers.Authorization.ToString());

            await _next(context);
        }
    }
}
