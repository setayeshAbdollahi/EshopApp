using EshopApp.Application.DTOs.ReportDTOs;

namespace EshopApp.Application.Interfaces
{
    /// <summary>
    /// Defines helper methods for querying product-related reports and statistics.
    /// </summary>
    public interface IProductQueryHelper
    {
        /// <summary>
        /// Retrieves a list of products with stock below the specified threshold.
        /// </summary>
        /// <param name="threshold">The stock quantity threshold. Defaults to 10.</param>
        /// <returns>A list of products with low stock.</returns>
        Task<List<LowStockProductDto>> GetLowStockProductsAsync(int threshold = 10);

        /// <summary>
        /// Retrieves a list of products that are not assigned to any category.
        /// </summary>
        /// <returns>A list of uncategorized products.</returns>
        Task<List<UncategorizedProductDto>> GetUncategorizedProductsAsync();
    }
}
