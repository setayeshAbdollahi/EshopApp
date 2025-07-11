using EshopApp.Shared.Base;

namespace EshopApp.Domain.Entities;
/// <summary>
/// Represents an item within an invoice, including product, quantity, and price information.
/// </summary>
public class InvoiceItem : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the product associated with this invoice item.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the product entity associated with this invoice item.
    /// </summary>
    public Product? Product { get; set; }

    /// <summary>
    /// Gets or sets the quantity of the product in this invoice item.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product in this invoice item.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the invoice to which this item belongs.
    /// </summary>
    public Guid InvoiceId { get; set; }

    /// <summary>
    /// Gets or sets the invoice entity to which this item belongs.
    /// </summary>
    public Invoice? Invoice { get; set; }
}
