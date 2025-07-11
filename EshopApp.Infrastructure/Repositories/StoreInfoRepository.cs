using EshopApp.Domain.Entities;
using EshopApp.Application.Interfaces;
using EshopApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace EshopApp.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="StoreInfo"/> entities in the database.
/// </summary>
public class StoreInfoRepository : IStoreInfoRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="StoreInfoRepository"/> class.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public StoreInfoRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Retrieves the store information from the database.
    /// </summary>
    /// <returns>The store information if found; otherwise, null.</returns>
    public async Task<StoreInfo?> GetAsync()
    {
        return await _context.StoreInfos.FirstOrDefaultAsync();
    }

    /// <summary>
    /// Updates the store information in the database.
    /// </summary>
    /// <param name="storeInfo">The store information to update.</param>
    public async Task UpdateAsync(StoreInfo storeInfo)
    {
        _context.StoreInfos.Update(storeInfo);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Adds new store information to the database.
    /// </summary>
    /// <param name="storeInfo">The store information to add.</param>
    public async Task AddAsync(StoreInfo storeInfo)
    {
        await _context.StoreInfos.AddAsync(storeInfo);
        await _context.SaveChangesAsync();
    }
}


