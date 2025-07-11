namespace EshopApp.Application.Interfaces;

/// <summary>
/// Represents a unit of work that coordinates the work of multiple repositories.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Gets the repository for managing invoices.
    /// </summary>
    IInvoiceRepository InvoiceRepository { get; }

    /// <summary>
    /// Gets the repository for managing invoice items.
    /// </summary>
    IInvoiceItemRepository InvoiceItemRepository { get; }

    /// <summary>
    /// Gets the repository for managing products.
    /// </summary>
    IProductRepository ProductRepository { get; }

    /// <summary>
    /// Gets the repository for managing customers.
    /// </summary>
    ICustomerRepository CustomerRepository { get; }

    /// <summary>
    /// Gets the repository for managing categories.
    /// </summary>
    ICategoryRepository CategoryRepository { get; }

    /// <summary>
    /// Asynchronously saves all changes made in the unit of work.
    /// </summary>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync();
}
