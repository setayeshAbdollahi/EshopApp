using EshopApp.Application.DTOs.BaseDTOs;

/// <summary>
/// Data transfer object (DTO) for retrieving product information.
/// </summary>
/// <remarks>
/// Inherits common properties from <see cref="BaseDto"/> and adds product-specific fields.
/// </remarks>
public class GetProductDto : BaseDto
{
    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the available stock quantity for the product.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Gets or sets the description of the product (optional).
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the name of the category to which the product belongs.
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ID of the category to which the product belongs.
    /// </summary>
    public Guid CategoryId { get; set; }

}
