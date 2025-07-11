using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Application.Exceptions;
using EshopApp.Application.DTOs.CategoryDTOs;

namespace EshopApp.Application.UseCases.CategoryUseCases;

/// <summary>
/// Use case for deleting a category, ensuring it has no child categories before deletion.
/// </summary>
public class DeleteCategoryUseCase
{
    private readonly ICategoryRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteCategoryUseCase"/> class.
    /// </summary>
    /// <param name="repository">The category repository to use for data access.</param>
    public DeleteCategoryUseCase(ICategoryRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to delete a category by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the category to delete.</param>
    /// <exception cref="NotFoundException">Thrown if the category is not found.</exception>
    /// <exception cref="BadRequestException">Thrown if the category has child categories that must be deleted first.</exception>
    public async Task ExecuteAsync(Guid id)
    {
        var category = await _repository.GetByIdWithChildrenAsync(id);
        if (category == null)
            throw new NotFoundException("دسته پیدا نشد.");

        if (category.Children != null && category.Children.Any())
            throw new BadRequestException("ابتدا زیرشاخه‌ها را حذف کنید.");

        await _repository.DeleteAsync(category);
    }
}
