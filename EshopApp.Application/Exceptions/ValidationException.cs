namespace EshopApp.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when validation errors occur.
/// </summary>
public class ValidationException : AppException
{
    /// <summary>
    /// Gets the collection of validation errors, where the key is the property name and the value is an array of error messages.
    /// </summary>
    public Dictionary<string, string[]> Errors { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationException"/> class with a collection of validation errors.
    /// </summary>
    /// <param name="errors">A dictionary containing property names and their associated validation error messages.</param>
    public ValidationException(Dictionary<string, string[]> errors)
        : base("خطاهای اعتبارسنجی رخ داده است.")
    {
        Errors = errors;
    }
}
