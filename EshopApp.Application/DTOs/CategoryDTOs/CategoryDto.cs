using System;
using EshopApp.Application.DTOs.BaseDTOs;

namespace EshopApp.Application.DTOs.CategoryDTOs
{
    /// <summary>
    /// Data transfer object (DTO) representing a category.
    /// </summary>
    /// <remarks>
    /// Inherits common properties from <see cref="BaseDto"/> and adds category-specific fields.
    /// </remarks>
    public class CategoryDto : BaseDto
    {
        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }

}