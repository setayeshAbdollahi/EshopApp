namespace EshopApp.Application.Exceptions;

/// <summary>
/// Represents application-specific exceptions with an associated HTTP status code.
/// </summary>
public class AppException : Exception
{
    /// <summary>
    /// Gets the HTTP status code associated with the exception.
    /// </summary>
    public int StatusCode { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="AppException"/> class with a specified error message and status code.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="statusCode">The HTTP status code to associate with this exception (default is 500).</param>
    public AppException(string message, int statusCode = 500) : base(message)
    {
        StatusCode = statusCode;
    }
}
