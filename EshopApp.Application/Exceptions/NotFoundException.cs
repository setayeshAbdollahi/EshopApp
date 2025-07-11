namespace EshopApp.Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an entity is not found.
/// </summary>
public class NotFoundException : AppException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified entity name.
    /// </summary>
    /// <param name="entityName">The name of the entity that was not found.</param>
    public NotFoundException(string entityName)
        : base($"{entityName} با شناسه یافت نشد.") { }
}

