using EshopApp.Application.Interfaces;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.ProductUseCases;

/// <summary>
/// Use case for assigning a product to a category.
/// </summary>
public class AssignProductToCategoryUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="AssignProductToCategoryUseCase"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work to use for data access.</param>
    public AssignProductToCategoryUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Executes the use case to assign a product to a category.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="categoryId">The unique identifier of the category.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure, with an error message if applicable.</returns>
    public async Task<Result> ExecuteAsync(Guid productId, Guid categoryId)
    {
        if (productId == Guid.Empty)
            return Result.Failure("شناسه محصول معتبر نیست.");

        if (categoryId == Guid.Empty)
            return Result.Failure("شناسه دسته‌بندی معتبر نیست.");

        var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
        if (product == null)
            return Result.Failure("محصول مورد نظر یافت نشد.");

        var category = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
        if (category == null)
            return Result.Failure("دسته‌بندی مورد نظر یافت نشد.");

        product.Category = category;

        try
        {
            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Failure("خطا در اختصاص دادن دسته‌بندی به محصول.");
        }
    }
}
