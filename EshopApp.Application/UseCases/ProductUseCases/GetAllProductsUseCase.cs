using EshopApp.Application.DTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.ProductUseCases;

/// <summary>
/// Use case for retrieving all products.
/// </summary>
public class GetAllProductsUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllProductsUseCase"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work to use for data access.</param>
    public GetAllProductsUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Executes the use case to retrieve all products.
    /// </summary>
    /// <returns>A <see cref="Result{List{GetProductDto}}"/> containing the list of products, or an error message if none are found.</returns>
    public async Task<Result<List<GetProductDto>>> ExecuteAsync()
    {
        var products = await _unitOfWork.ProductRepository.GetAllAsync();

        if (products == null || !products.Any())
            return Result<List<GetProductDto>>.Failure("هیچ محصولی یافت نشد.");

        var result = products.Select(p => new GetProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Stock = p.Stock,
            Description = p.Description,
            CategoryId = p.CategoryId
        }).ToList();

        return Result<List<GetProductDto>>.Success(result);
    }
}
