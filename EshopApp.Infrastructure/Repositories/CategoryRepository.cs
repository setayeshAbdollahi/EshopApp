using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using EshopApp.Persistence.Data;


namespace EshopApp.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="Category"/> entities in the database.
/// </summary>
public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public CategoryRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves a category by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category.</param>
    /// <returns>The category if found; otherwise, null.</returns>
    public async Task<Category?> GetByIdAsync(Guid id)
    {
        return await _context.Categories.FindAsync(id);
    }

    /// <summary>
    /// Retrieves all categories from the database.
    /// </summary>
    /// <returns>A list of all categories.</returns>
    public async Task<List<Category>> GetAllAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    /// <summary>
    /// Adds a new category to the database.
    /// </summary>
    /// <param name="category">The category to add.</param>
    public async Task AddAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates an existing category in the database.
    /// </summary>
    /// <param name="category">The category to update.</param>
    public async Task UpdateAsync(Category category)
    {
        _context.Categories.Update(category);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes a category from the database.
    /// </summary>
    /// <param name="category">The category to delete.</param>
    public async Task DeleteAsync(Category category)
    {
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves all categories as a tree structure, including their children.
    /// </summary>
    /// <returns>A list of root categories with their children populated.</returns>
    public async Task<List<Category>> GetAllAsTreeAsync()
    {
        var categories = await _context.Categories
            .Include(c => c.Children)
            .ToListAsync();

        return categories.Where(c => c.ParentId == null).ToList();
    }

    /// <summary>
    /// Retrieves a category by its unique identifier, including its children.
    /// </summary>
    /// <param name="id">The unique identifier of the category.</param>
    /// <returns>The category with its children if found; otherwise, null.</returns>
    public async Task<Category?> GetByIdWithChildrenAsync(Guid id)
    {
        return await _context.Categories
            .Include(c => c.Children)
            .FirstOrDefaultAsync(c => c.Id == id);
    }
}
