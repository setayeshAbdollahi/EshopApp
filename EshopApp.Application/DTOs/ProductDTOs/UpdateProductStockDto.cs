namespace EshopApp.Application.DTOs.Product;

/// <summary>
/// Data transfer object (DTO) for updating the stock quantity of a product.
/// </summary>
public class UpdateProductStockDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the product.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Gets or sets the new stock quantity for the product.
    /// </summary>
    public int NewStock { get; set; }
}
