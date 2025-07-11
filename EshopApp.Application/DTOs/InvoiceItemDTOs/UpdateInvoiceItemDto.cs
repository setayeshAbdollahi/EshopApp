namespace EshopApp.Application.DTOs;

/// <summary>
/// Data transfer object (DTO) for updating an existing invoice item.
/// </summary>
public class UpdateInvoiceItemDto
{
    /// <summary>
    /// Gets or sets the ID of the product associated with the invoice item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the updated quantity of the product in the invoice item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the updated unit price of the product in the invoice item.
    /// </summary>
    public int UnitPrice { get; set; }
}
