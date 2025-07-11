using EshopApp.Application.DTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Shared.Constants;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.ProductUseCases;

/// <summary>
/// Use case for creating a new product.
/// </summary>
public class CreateProductUseCase
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateProductUseCase"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work to use for data access.</param>
    public CreateProductUseCase(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Executes the use case to create a new product.
    /// </summary>
    /// <param name="dto">The data transfer object containing product details.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure, with validation errors if any.</returns>
    public async Task<Result> ExecuteAsync(CreateProductDto dto)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(dto.Name))
            errors.Add("Name", new[] { "عنوان محصول نمی‌تواند خالی باشد." });

        if (dto.Price < 0)
            errors.Add("Price", new[] { AppConstants.ErrorMessages.ValidationFailed });

        if (dto.CategoryId == Guid.Empty)
            errors.Add("CategoryId", new[] { "دسته‌بندی باید مشخص شود." });

        if (errors.Any())
            return Result.Failure(errors);

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = dto.Name,
            Price = dto.Price,
            Stock = dto.Stock,
            Description = dto.Description,
            CategoryId = dto.CategoryId
        };

        await _unitOfWork.ProductRepository.AddAsync(product);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
