using EshopApp.Shared.Base;
namespace EshopApp.Domain.Entities;

/// <summary>
/// Represents a product category, which can have a parent category and child categories (for hierarchical organization).
/// </summary>
public class Category : BaseEntity
{
    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the optional parent category ID (for subcategories).
    /// </summary>
    public Guid? ParentId { get; set; }

    /// <summary>
    /// Gets or sets the parent category entity.
    /// </summary>
    public Category? Parent { get; set; }

    /// <summary>
    /// Gets or sets the list of child categories.
    /// </summary>
    public List<Category> Children { get; set; } = new();

    /// <summary>
    /// Gets or sets the list of products assigned to this category.
    /// </summary>
    public List<Product> Products { get; set; } = new();
}
