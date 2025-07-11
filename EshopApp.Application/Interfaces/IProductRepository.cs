using EshopApp.Domain.Entities;


namespace EshopApp.Application.Interfaces;

/// <summary>
/// Defines repository operations for managing <see cref="Product"/> entities.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Asynchronously adds a new product to the repository.
    /// </summary>
    /// <param name="product">The product entity to add.</param>
    Task AddAsync(Product product);

    /// <summary>
    /// Asynchronously retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <returns>The product if found; otherwise, null.</returns>
    Task<Product?> GetByIdAsync(Guid id);

    /// <summary>
    /// Asynchronously retrieves all products from the repository.
    /// </summary>
    /// <returns>A list of all products.</returns>
    Task<List<Product>> GetAllAsync();

    /// <summary>
    /// Asynchronously updates an existing product in the repository.
    /// </summary>
    /// <param name="product">The product entity to update.</param>
    Task UpdateAsync(Product product);

    /// <summary>
    /// Asynchronously deletes a product from the repository.
    /// </summary>
    /// <param name="product">The product entity to delete.</param>
    Task DeleteAsync(Product product);
}
