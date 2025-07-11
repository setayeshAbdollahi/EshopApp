namespace EshopApp.Application.Interfaces;

using EshopApp.Domain.Entities;

/// <summary>
/// Defines methods for accessing and managing invoice entities in the data store.
/// </summary>
public interface IInvoiceRepository
{
    /// <summary>
    /// Adds a new invoice to the data store.
    /// </summary>
    /// <param name="invoice">The invoice entity to add.</param>
    Task AddAsync(Invoice invoice);

    /// <summary>
    /// Retrieves an invoice by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice.</param>
    /// <returns>The invoice entity if found; otherwise, null.</returns>
    Task<Invoice?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves an invoice by its unique identifier, including its items.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice.</param>
    /// <returns>The invoice entity with its items if found; otherwise, null.</returns>
    Task<Invoice?> GetByIdWithItemsAsync(Guid id);

    /// <summary>
    /// Retrieves all invoices from the data store.
    /// </summary>
    /// <returns>A list of all invoice entities.</returns>
    Task<List<Invoice>> GetAllAsync();

    /// <summary>
    /// Searches invoices by customer name.
    /// </summary>
    /// <param name="customerName">The name of the customer to search for.</param>
    /// <returns>A list of invoices matching the customer name.</returns>
    Task<List<Invoice>> SearchAsync(string customerName);

    /// <summary>
    /// Deletes an invoice from the data store by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice to delete.</param>
    Task DeleteAsync(Guid id);
}
