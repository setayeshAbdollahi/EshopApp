using EshopApp.Application.Interfaces;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.ProductUseCases;

/// <summary>
/// Use case for deleting a product by its unique identifier.
/// </summary>
public class DeleteProductUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteProductUseCase"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work to use for data access.</param>
    public DeleteProductUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Executes the use case to delete a product by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to delete.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure, with an error message if applicable.</returns>
    public async Task<Result> ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
            return Result.Failure("شناسه محصول نمی‌تواند خالی باشد.");

        var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

        if (product == null)
            return Result.Failure("محصول مورد نظر یافت نشد.");

        await _unitOfWork.ProductRepository.DeleteAsync(product);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }

}
