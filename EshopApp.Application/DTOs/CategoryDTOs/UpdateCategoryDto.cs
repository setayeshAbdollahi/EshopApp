namespace EshopApp.Application.DTOs.CategoryDTOs;

/// <summary>
/// Data transfer object (DTO) for updating an existing category.
/// </summary>
public class UpdateCategoryDto
{
    /// <summary>
    /// Gets or sets the new name of the category.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}

