namespace EshopApp.Application.DTOs.CategoryDTOs;

/// <summary>
/// Data transfer object (DTO) for creating a new category.
/// </summary>
public class CreateCategoryDto
{
    /// <summary>
    /// Gets or sets the name of the category to be created.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
