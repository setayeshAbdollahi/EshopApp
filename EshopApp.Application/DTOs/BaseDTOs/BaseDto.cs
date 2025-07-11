namespace EshopApp.Application.DTOs.BaseDTOs;

/// <summary>
/// Represents the base data transfer object (DTO) for entities.
/// </summary>
/// <remarks>
/// Provides common properties such as Id, CreatedAt, and UpdatedAt for all DTOs.
/// </remarks>
public abstract class BaseDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the creation date and time of the entity.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
