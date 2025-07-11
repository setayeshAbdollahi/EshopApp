using EshopApp.Application.DTOs.StoreInfoDTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Shared.Result;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.UseCases.StoreInfoUseCases;

/// <summary>
/// Use case for updating or creating store information.
/// </summary>
public class UpdateStoreInfoUseCase
{
    private readonly IStoreInfoRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateStoreInfoUseCase"/> class.
    /// </summary>
    /// <param name="repository">The store info repository to use for data access.</param>
    public UpdateStoreInfoUseCase(IStoreInfoRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to update or create store information.
    /// </summary>
    /// <param name="dto">The data transfer object containing updated store information.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure, with validation errors if any.</returns>
    public async Task<Result> ExecuteAsync(UpdateStoreInfoDto dto)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(dto.StoreName))
            errors.Add("StoreName", new[] { "نام فروشگاه نمی‌تواند خالی باشد." });

        if (!string.IsNullOrWhiteSpace(dto.PhoneNumber) && dto.PhoneNumber.Length < 5)
            errors.Add("PhoneNumber", new[] { "شماره تماس باید معتبر باشد." });

        if (errors.Any())
            return Result.Failure(errors);

        var entity = await _repository.GetAsync();

        if (entity == null)
        {
            var newEntity = new StoreInfo
            {
                Id = Guid.NewGuid(),
                StoreName = dto.StoreName,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                LogoUrl = dto.LogoUrl,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(newEntity);

            return Result.Success();
        }

        entity.StoreName = dto.StoreName;
        entity.Address = dto.Address;
        entity.PhoneNumber = dto.PhoneNumber;
        entity.LogoUrl = dto.LogoUrl;
        entity.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(entity);

        return Result.Success();
    }
}
