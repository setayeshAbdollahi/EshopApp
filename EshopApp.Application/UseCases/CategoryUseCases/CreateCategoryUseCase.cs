using EshopApp.Application.DTOs.CategoryDTOs;
using EshopApp.Application.Exceptions;
using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCases.CategoryUseCases;

/// <summary>
/// Use case for creating a new category, optionally as a child of an existing category.
/// </summary>
public class CreateCategoryUseCase
{
    private readonly ICategoryRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCategoryUseCase"/> class.
    /// </summary>
    /// <param name="repository">The category repository to use for data access.</param>
    public CreateCategoryUseCase(ICategoryRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to create a new category.
    /// </summary>
    /// <param name="dto">The data transfer object containing category details.</param>
    /// <param name="parentId">The optional parent category ID.</param>
    /// <exception cref="ValidationException">Thrown if the category name is null or whitespace.</exception>
    /// <exception cref="NotFoundException">Thrown if the specified parent category does not exist.</exception>
    public async Task ExecuteAsync(CreateCategoryDto dto, Guid? parentId = null)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ValidationException(new Dictionary<string, string[]> { { "Name", new[] { "نام دسته نمی‌تواند خالی باشد." } } });

        if (parentId != null)
        {
            var parent = await _repository.GetByIdAsync(parentId.Value);
            if (parent == null)
                throw new NotFoundException("دسته‌بندی پدر پیدا نشد.");
        }

        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            ParentId = parentId
        };

        await _repository.AddAsync(category);
    }
}
