using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace EshopApp.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="InvoiceItem"/> entities in the database.
/// </summary>
public class InvoiceItemRepository : IInvoiceItemRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceItemRepository"/> class.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public InvoiceItemRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adds a new invoice item to the database.
    /// </summary>
    /// <param name="item">The invoice item to add.</param>
    public async Task AddAsync(InvoiceItem item)
    {
        await _context.InvoiceItems.AddAsync(item);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates an existing invoice item in the database.
    /// </summary>
    /// <param name="item">The invoice item to update.</param>
    public async Task UpdateAsync(InvoiceItem item)
    {
        _context.InvoiceItems.Update(item);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes an invoice item from the database by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice item to delete.</param>
    public async Task DeleteAsync(Guid id)
    {
        var item = await _context.InvoiceItems.FindAsync(id);
        if (item != null)
        {
            _context.InvoiceItems.Remove(item);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Retrieves an invoice item by its unique identifier, including its related product.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice item.</param>
    /// <returns>The invoice item with its product if found; otherwise, null.</returns>
    public async Task<InvoiceItem?> GetByIdAsync(Guid id)
    {
        return await _context.InvoiceItems
        .Include(i => i.Product)
        .FirstOrDefaultAsync(i => i.Id == id);
    }

    /// <summary>
    /// Retrieves all invoice items for a specific invoice, including their related products.
    /// </summary>
    /// <param name="invoiceId">The unique identifier of the invoice.</param>
    /// <returns>A list of invoice items for the specified invoice.</returns>
    public async Task<List<InvoiceItem>> GetByInvoiceIdAsync(Guid invoiceId)
    {
        return await _context.InvoiceItems
            .Include(i => i.Product)
            .Where(i => i.InvoiceId == invoiceId)
            .ToListAsync();
    }
}