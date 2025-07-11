using EshopApp.Application.DTOs.BaseDTOs;

namespace EshopApp.Application.DTOs.ReportDTOs;

/// <summary>
/// Data transfer object (DTO) representing a product that is not assigned to any category.
/// </summary>
/// <remarks>
/// Inherits common properties from <see cref="BaseDto"/> and adds product-specific fields.
/// </remarks>
public class UncategorizedProductDto : BaseDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}

