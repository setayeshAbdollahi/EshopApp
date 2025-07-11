using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Application.Exceptions;
using EshopApp.Application.DTOs.CategoryDTOs;

namespace EshopApp.Application.UseCases.CategoryUseCases;

/// <summary>
/// Use case for updating an existing category's information.
/// </summary>
public class UpdateCategoryUseCase
{
    private readonly ICategoryRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCategoryUseCase"/> class.
    /// </summary>
    /// <param name="repository">The category repository to use for data access.</param>
    public UpdateCategoryUseCase(ICategoryRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to update a category's name.
    /// </summary>
    /// <param name="id">The unique identifier of the category to update.</param>
    /// <param name="dto">The data transfer object containing the updated category details.</param>
    /// <exception cref="ValidationException">Thrown if the category name is null or whitespace.</exception>
    /// <exception cref="NotFoundException">Thrown if the category is not found.</exception>
    public async Task ExecuteAsync(Guid id, UpdateCategoryDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ValidationException(new Dictionary<string, string[]> { { "Name", new[] { "نام دسته نمی‌تواند خالی باشد." } } });

        var category = await _repository.GetByIdAsync(id);
        if (category == null)
            throw new NotFoundException("دسته‌بندی پیدا نشد.");

        category.Name = dto.Name;
        await _repository.UpdateAsync(category);
    }
}