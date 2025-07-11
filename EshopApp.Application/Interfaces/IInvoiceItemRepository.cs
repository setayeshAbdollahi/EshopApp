using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces
{
    /// <summary>
    /// Defines methods for accessing and managing invoice item entities in the data store.
    /// </summary>
    public interface IInvoiceItemRepository
    {
        /// <summary>
        /// Adds a new invoice item to the data store.
        /// </summary>
        /// <param name="item">The invoice item entity to add.</param>
        Task AddAsync(InvoiceItem item);

        /// <summary>
        /// Retrieves an invoice item by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice item.</param>
        /// <returns>The invoice item entity if found; otherwise, null.</returns>
        Task<InvoiceItem?> GetByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all invoice items associated with a specific invoice.
        /// </summary>
        /// <param name="invoiceId">The unique identifier of the invoice.</param>
        /// <returns>A list of invoice items for the specified invoice.</returns>
        Task<List<InvoiceItem>> GetByInvoiceIdAsync(Guid invoiceId);

        /// <summary>
        /// Deletes an invoice item from the data store by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the invoice item to delete.</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Updates an existing invoice item in the data store.
        /// </summary>
        /// <param name="item">The invoice item entity to update.</param>
        Task UpdateAsync(InvoiceItem item);
    }
}
