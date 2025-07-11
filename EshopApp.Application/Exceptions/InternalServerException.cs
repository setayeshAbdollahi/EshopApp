using System;

namespace EshopApp.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an internal server error occurs (HTTP 500).
/// </summary>
public class InternalServerException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InternalServerException"/> class with a default error message.
    /// </summary>
    public InternalServerException() 
        : base("خطای داخلی سرور رخ داده است.") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalServerException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public InternalServerException(string message) 
        : base(message) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalServerException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public InternalServerException(string message, Exception innerException) 
        : base(message, innerException) { }
}
