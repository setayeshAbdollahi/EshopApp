using EshopApp.Application.DTOs;
using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.ProductUseCases;

/// <summary>
/// Use case for retrieving a product by its unique identifier.
/// </summary>
public class GetProductByIdUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetProductByIdUseCase"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work to use for data access.</param>
    public GetProductByIdUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Executes the use case to retrieve a product by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product to retrieve.</param>
    /// <returns>A <see cref="Result{GetProductDto}"/> containing the product data if found, or an error message.</returns>
    public async Task<Result<GetProductDto>> ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
            return Result<GetProductDto>.Failure("شناسه معتبر نیست");

        var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
        if (product == null)
            return Result<GetProductDto>.Failure("محصول یافت نشد");

        var dto = new GetProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Stock = product.Stock,
            Description = product.Description,
            CategoryId = product.CategoryId
        };

        return Result<GetProductDto>.Success(dto);
    }
}
