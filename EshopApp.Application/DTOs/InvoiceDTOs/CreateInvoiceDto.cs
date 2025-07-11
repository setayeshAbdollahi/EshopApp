using EshopApp.Domain.Enums;
namespace EshopApp.Application.DTOs;

/// <summary>
/// Data transfer object (DTO) for creating a new invoice.
/// </summary>
public class CreateInvoiceDto
{
    /// <summary>
    /// Gets or sets the ID of the customer associated with the invoice.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the list of items included in the invoice.
    /// </summary>
    public List<CreateInvoiceItemDto> Items { get; set; } = new();

    /// <summary>
    /// Gets or sets the status of the invoice.
    /// </summary>
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;
}

