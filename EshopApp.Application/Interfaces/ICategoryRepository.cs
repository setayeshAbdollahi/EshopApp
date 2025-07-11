using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces;

/// <summary>
/// Defines methods for accessing and managing category entities in the data store.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category.</param>
    /// <returns>The category entity if found; otherwise, null.</returns>
    Task<Category?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves all categories as a hierarchical tree structure.
    /// </summary>
    /// <returns>A list of categories organized as a tree.</returns>
    Task<List<Category>> GetAllAsTreeAsync();

    /// <summary>
    /// Adds a new category to the data store.
    /// </summary>
    /// <param name="category">The category entity to add.</param>
    Task AddAsync(Category category);

    /// <summary>
    /// Updates an existing category in the data store.
    /// </summary>
    /// <param name="category">The category entity to update.</param>
    Task UpdateAsync(Category category);

    /// <summary>
    /// Deletes a category from the data store.
    /// </summary>
    /// <param name="category">The category entity to delete.</param>
    Task DeleteAsync(Category category);

    /// <summary>
    /// Retrieves a category by its unique identifier, including its child categories.
    /// </summary>
    /// <param name="id">The unique identifier of the category.</param>
    /// <returns>The category entity with its children if found; otherwise, null.</returns>
    Task<Category?> GetByIdWithChildrenAsync(Guid id);
}

