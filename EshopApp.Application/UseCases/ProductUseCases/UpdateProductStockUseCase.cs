using EshopApp.Application.Interfaces;
using EshopApp.Shared.Result;
using EshopApp.Application.Exceptions;

namespace EshopApp.Application.UseCases.ProductUseCases;

/// <summary>
/// Use case for updating the stock quantity of a product.
/// </summary>
public class UpdateProductStockUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateProductStockUseCase"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work to use for data access.</param>
    public UpdateProductStockUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Executes the use case to update the stock quantity of a product.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="newStock">The new stock quantity to set.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure, with an error message if applicable.</returns>
    public async Task<Result> ExecuteAsync(Guid productId, int newStock)
    {
        if (productId == Guid.Empty)
        {
            return Result.Failure("شناسه محصول نامعتبر است.");
        }

        if (newStock < 0)
        {
            return Result.Failure("مقدار موجودی نمی‌تواند منفی باشد.");
        }

        var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);
        if (product == null)
        {
            return Result.Failure("محصول مورد نظر یافت نشد.");
        }

        product.Stock = newStock;

        try
        {
            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return Result.Success();
        }
        catch (Exception)
        {
            return Result.Failure("خطا در به‌روزرسانی موجودی محصول.");
        }
    }
}
