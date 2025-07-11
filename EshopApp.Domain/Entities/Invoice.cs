using EshopApp.Shared.Base;
using EshopApp.Domain.Enums;

namespace EshopApp.Domain.Entities;

/// <summary>
/// Represents an invoice entity, containing items, customer, and status information.
/// </summary>
public class Invoice : BaseEntity
{
    /// <summary>
    /// Gets the date and time when the invoice was issued.
    /// </summary>
    public DateTime IssuedDate { get; init; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the status of the invoice (e.g., Draft, Paid).
    /// </summary>
    public InvoiceStatus Status { get; set; } = InvoiceStatus.Draft;

    /// <summary>
    /// Gets or sets the unique identifier of the customer associated with the invoice.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the customer entity associated with the invoice.
    /// </summary>
    public Customer? Customer { get; set; }

    /// <summary>
    /// Gets or sets the list of items included in the invoice.
    /// </summary>
    public List<InvoiceItem> Items { get; set; } = new();

    /// <summary>
    /// Gets the total amount of the invoice, calculated as the sum of all item prices multiplied by their quantities.
    /// </summary>
    public decimal TotalAmount => Items.Sum(item => item.UnitPrice * item.Quantity);
}
