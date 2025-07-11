namespace EshopApp.Application.DTOs;

/// <summary>
/// Data transfer object (DTO) for creating a new invoice item.
/// </summary>
public class CreateInvoiceItemDto
{
    /// <summary>
    /// Gets or sets the ID of the product associated with the invoice item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product in the invoice item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product in the invoice item.
    /// </summary>
    public decimal UnitPrice { get; set; }
}
