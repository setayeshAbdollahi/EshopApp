namespace EshopApp.Application.DTOs.ReportDTOs
{
    /// <summary>
    /// Data transfer object (DTO) representing a product with low stock.
    /// </summary>
    public class LowStockProductDto
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the current stock quantity of the product.
        /// </summary>
        public int Stock { get; set; }
    }
}
