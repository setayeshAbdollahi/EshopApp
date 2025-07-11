using EshopApp.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace EshopApp.API.Middleware;

/// <summary>
/// Middleware for handling exceptions globally in the application.
/// </summary>
/// <remarks>
/// Catches unhandled exceptions, logs them, and returns a standardized error response.
/// </remarks>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    /// <param name="logger">The logger instance.</param>
    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Invokes the middleware to handle exceptions during HTTP request processing.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context); 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    /// <summary>
    /// Handles the exception and writes a standardized error response.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="exception">The exception to handle.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        int statusCode = (int)HttpStatusCode.InternalServerError;
        object response;

        switch (exception)
        {
            case ValidationException validationException:
                statusCode = 400;
                response = new
                {
                    message = validationException.Message,
                    errors = validationException.Errors
                };
                break;

            case AppException appException:
                statusCode = appException.StatusCode;
                response = new { message = appException.Message };
                break;

            default:
                response = new
                {
                    message = exception.Message,
                    detail = exception.InnerException?.Message,
                    stackTrace = exception.StackTrace
                };
                 break;

        }

        context.Response.StatusCode = statusCode;
        var result = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(result);
    }
}

