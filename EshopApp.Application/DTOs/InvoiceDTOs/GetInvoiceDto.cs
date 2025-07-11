using EshopApp.Application.DTOs.BaseDTOs;

namespace EshopApp.Application.DTOs;

/// <summary>
/// Data transfer object (DTO) for retrieving invoice information.
/// </summary>
/// <remarks>
/// Inherits common properties from <see cref="BaseDto"/> and adds invoice-specific fields.
/// </remarks>
public class GetInvoiceDto : BaseDto
{
    /// <summary>
    /// Gets or sets the date the invoice was issued.
    /// </summary>
    public DateTime IssuedDate { get; set; }

    /// <summary>
    /// Gets or sets the name of the customer associated with the invoice.
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the list of items included in the invoice.
    /// </summary>
    public List<GetInvoiceItemDto> Items { get; set; } = new();

    /// <summary>
    /// Gets or sets the total amount of the invoice.
    /// </summary>
    public decimal TotalAmount { get; set; }
}

