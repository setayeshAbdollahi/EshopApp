using EshopApp.Shared.Base;

namespace EshopApp.Domain.Entities;
/// <summary>
/// Represents a product entity in the system.
/// </summary>
public class Product : BaseEntity
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
    /// Gets or sets the available stock quantity of the product.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Gets or sets the description of the product (optional).
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the category to which the product belongs.
    /// </summary>
    public Guid CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the category entity to which the product belongs.
    /// </summary>
    public Category? Category { get; set; }

    /// <summary>
    /// Gets or sets the list of invoice items that include this product.
    /// </summary>
    public List<InvoiceItem> InvoiceItems { get; set; } = new();
}

  
