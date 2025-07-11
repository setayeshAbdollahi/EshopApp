using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace EshopApp.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="Invoice"/> entities in the database.
/// </summary>
public class InvoiceRepository : IInvoiceRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceRepository"/> class.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public InvoiceRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adds a new invoice to the database.
    /// </summary>
    /// <param name="invoice">The invoice to add.</param>
    public async Task AddAsync(Invoice invoice)
    {
        await _context.Invoices.AddAsync(invoice);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retrieves an invoice by its unique identifier, including its customer and items with products.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice.</param>
    /// <returns>The invoice with its customer and items if found; otherwise, null.</returns>
    public async Task<Invoice?> GetByIdAsync(Guid id)
    {
        return await _context.Invoices
            .Include(i => i.Customer)
            .Include(i => i.Items)
                .ThenInclude(ii => ii.Product)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    /// <summary>
    /// Retrieves all invoices from the database, including their customers and items with products.
    /// </summary>
    /// <returns>A list of all invoices with their related data.</returns>
    public async Task<List<Invoice>> GetAllAsync()
    {
        return await _context.Invoices
            .Include(i => i.Customer)
            .Include(i => i.Items)
                .ThenInclude(ii => ii.Product)
            .ToListAsync();
    }

    /// <summary>
    /// Searches for invoices by customer name, including their customers and items with products.
    /// </summary>
    /// <param name="customerName">The name of the customer to search for.</param>
    /// <returns>A list of invoices matching the customer name.</returns>
    public async Task<List<Invoice>> SearchAsync(string customerName)
    {
        return await _context.Invoices
            .Include(i => i.Customer)
            .Include(i => i.Items)
                .ThenInclude(ii => ii.Product)
            .Where(i => i.Customer != null && i.Customer.FullName.Contains(customerName))
            .ToListAsync();
    }

    /// <summary>
    /// Deletes an invoice from the database by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice to delete.</param>
    public async Task DeleteAsync(Guid id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        if (invoice != null)
        {
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Retrieves an invoice by its unique identifier, including its customer and items with products.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice.</param>
    /// <returns>The invoice with its customer and items if found; otherwise, null.</returns>
    public async Task<Invoice?> GetByIdWithItemsAsync(Guid id)
    {
        return await _context.Invoices
            .Include(i => i.Customer)
            .Include(i => i.Items)
                .ThenInclude(ii => ii.Product)
            .FirstOrDefaultAsync(i => i.Id == id);
    }
}
