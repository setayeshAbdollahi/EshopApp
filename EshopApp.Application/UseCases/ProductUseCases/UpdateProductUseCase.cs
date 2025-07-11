using EshopApp.Application.DTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.ProductUseCases;

/// <summary>
/// Use case for updating an existing product's information.
/// </summary>
public class UpdateProductUseCase
{
    private readonly IProductRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateProductUseCase"/> class.
    /// </summary>
    /// <param name="repository">The product repository to use for data access.</param>
    public UpdateProductUseCase(IProductRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to update a product's information.
    /// </summary>
    /// <param name="id">The unique identifier of the product to update.</param>
    /// <param name="dto">The data transfer object containing the updated product details.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure, with validation errors if any.</returns>
    public async Task<Result> ExecuteAsync(Guid id, UpdateProductDto dto)
    {
        if (id == Guid.Empty)
            return Result.Failure("شناسه محصول نامعتبر است.");

        var product = await _repository.GetByIdAsync(id);
        if (product == null)
            return Result.Failure("محصول مورد نظر یافت نشد.");

        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(dto.Name))
            errors.Add("Name", new[] { "عنوان نمی‌تواند خالی باشد." });

        if (dto.Price < 0)
            errors.Add("Price", new[] { "قیمت نمی‌تواند منفی باشد." });

        if (dto.CategoryId == Guid.Empty)
            errors.Add("CategoryId", new[] { "دسته‌بندی باید مشخص باشد." });

        if (errors.Any())
            return Result.Failure(errors);

        product.Name = dto.Name;
        product.Price = dto.Price;
        product.Stock = dto.Stock;
        product.Description = dto.Description ?? string.Empty;
        product.CategoryId = dto.CategoryId;

        await _repository.UpdateAsync(product);

        return Result.Success();
    }
}
