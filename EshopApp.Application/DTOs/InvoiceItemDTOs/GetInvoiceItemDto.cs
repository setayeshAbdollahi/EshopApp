using EshopApp.Application.DTOs.BaseDTOs;

namespace EshopApp.Application.DTOs;

/// <summary>
/// Data transfer object (DTO) for retrieving invoice item information.
/// </summary>
/// <remarks>
/// Inherits common properties from <see cref="BaseDto"/> and adds invoice item-specific fields.
/// </remarks>
public class GetInvoiceItemDto : BaseDto
{
    /// <summary>
    /// Gets or sets the name of the product associated with the invoice item.
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of the product in the invoice item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product in the invoice item.
    /// </summary>
    public decimal UnitPrice { get; set; }
}