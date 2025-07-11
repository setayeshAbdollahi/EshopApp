namespace EshopApp.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a forbidden operation is attempted (HTTP 403).
/// </summary>
public class ForbiddenException : AppException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenException"/> class with an optional error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception. Default is a standard forbidden message.</param>
    public ForbiddenException(string message = "شما مجوز این عملیات را ندارید.") : base(message,403) { }
}
