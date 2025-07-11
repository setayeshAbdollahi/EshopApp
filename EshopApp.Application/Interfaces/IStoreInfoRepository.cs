using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces;

/// <summary>
/// Defines repository operations for managing <see cref="StoreInfo"/> entities.
/// </summary>
public interface IStoreInfoRepository
{
    /// <summary>
    /// Asynchronously retrieves the store information.
    /// </summary>
    /// <returns>The <see cref="StoreInfo"/> entity if found; otherwise, null.</returns>
    Task<StoreInfo?> GetAsync();

    /// <summary>
    /// Asynchronously updates the store information.
    /// </summary>
    /// <param name="storeInfo">The store information entity to update.</param>
    Task UpdateAsync(StoreInfo storeInfo);

    /// <summary>
    /// Asynchronously adds new store information to the repository.
    /// </summary>
    /// <param name="storeInfo">The store information entity to add.</param>
    Task AddAsync(StoreInfo storeInfo);
}