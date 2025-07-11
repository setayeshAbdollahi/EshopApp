using EshopApp.Application.DTOs.ReportDTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace EshopApp.Infrastructure.EFCore.QueryHelper
{
    /// <summary>
    /// Provides query helper methods for product-related reports and queries.
    /// </summary>
    public class ProductQueryHelper : IProductQueryHelper
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductQueryHelper"/> class.
        /// </summary>
        /// <param name="context">The application's database context.</param>
        public ProductQueryHelper(AppDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Asynchronously retrieves a list of products with stock less than or equal to the specified threshold.
        /// </summary>
        /// <param name="threshold">The stock threshold value.</param>
        /// <returns>A list of <see cref="LowStockProductDto"/> representing low stock products.</returns>
        public async Task<List<LowStockProductDto>> GetLowStockProductsAsync(int threshold)
        {
            return await _context.Products
                .Where(p => p.Stock <= threshold)
                .Select(p => new LowStockProductDto
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    Stock = p.Stock
                })
                .ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a list of products that are not assigned to any category.
        /// </summary>
        /// <returns>A list of <see cref="UncategorizedProductDto"/> representing uncategorized products.</returns>
        public async Task<List<UncategorizedProductDto>> GetUncategorizedProductsAsync()
        {
            return await _context.Products
                .Where(p => p.CategoryId == Guid.Empty)
                .Select(p => new UncategorizedProductDto
                {
                    ProductId = p.Id,
                    Name = p.Name
                })
                .ToListAsync();
        }

    }
}
