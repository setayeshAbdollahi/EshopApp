/// <summary>
/// Data transfer object (DTO) for updating an existing product.
/// </summary>
public class UpdateProductDto
{
    /// <summary>
    /// Gets or sets the updated name of the product.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated price of the product.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the updated stock quantity for the product.
    /// </summary>
    public int Stock { get; set; }

    /// <summary>
    /// Gets or sets the updated description of the product (optional).
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the updated category ID to which the product belongs.
    /// </summary>
    public Guid CategoryId { get; set; }
}
