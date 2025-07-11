namespace EshopApp.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a conflict occurs (HTTP 409).
/// </summary>
public class ConflictException : AppException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConflictException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public ConflictException(string message) : base(message, 409) { }
}
