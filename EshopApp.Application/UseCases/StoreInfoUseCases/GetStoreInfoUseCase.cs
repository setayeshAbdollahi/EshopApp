using EshopApp.Application.DTOs.StoreInfoDTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.StoreInfoUseCases;

/// <summary>
/// Use case for retrieving store information.
/// </summary>
public class GetStoreInfoUseCase
{
    private readonly IStoreInfoRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetStoreInfoUseCase"/> class.
    /// </summary>
    /// <param name="repository">The store info repository to use for data access.</param>
    public GetStoreInfoUseCase(IStoreInfoRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to retrieve store information.
    /// </summary>
    /// <returns>A <see cref="Result{StoreInfoDto}"/> containing the store information, or an error message if not found.</returns>
    public async Task<Result<StoreInfoDto>> ExecuteAsync()
    {
        var entity = await _repository.GetAsync();
        if (entity == null)
            return Result<StoreInfoDto>.Failure("اطلاعات فروشگاه یافت نشد.");

        var dto = new StoreInfoDto
        {
            Id = entity.Id,
            StoreName = entity.StoreName,
            Address = entity.Address,
            PhoneNumber = entity.PhoneNumber,
            LogoUrl = entity.LogoUrl
        };

        return Result<StoreInfoDto>.Success(dto);
    }
}
