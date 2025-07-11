namespace EshopApp.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an unauthorized access is attempted (HTTP 401).
/// </summary>
public class UnauthorizedException : AppException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnauthorizedException"/> class with an optional error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception. Default is a standard unauthorized message.</param>
    public UnauthorizedException(string message = "شما دسترسی ندارید.") : base(message, 401) { }
}
