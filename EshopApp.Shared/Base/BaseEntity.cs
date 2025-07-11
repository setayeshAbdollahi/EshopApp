namespace EshopApp.Shared.Base;

/// <summary>
/// Represents the base entity for all domain entities, providing common properties.
/// </summary>
public abstract class BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier for the entity.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the creation timestamp of the entity.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the last update timestamp of the entity.
    /// </summary>
    public DateTime? UpdatedAt { get; set; }
}
