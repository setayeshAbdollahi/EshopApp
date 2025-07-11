using EshopApp.Application.Interfaces;
using EshopApp.Persistence.Data;

namespace EshopApp.Infrastructure.EFCore.UnitOfWork;

/// <summary>
/// Implements the Unit of Work pattern to coordinate repository operations and manage database transactions.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="UnitOfWork"/> class with the specified repositories and database context.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    /// <param name="invoiceRepo">The invoice repository.</param>
    /// <param name="itemRepo">The invoice item repository.</param>
    /// <param name="productRepo">The product repository.</param>
    /// <param name="customerRepo">The customer repository.</param>
    /// <param name="categoryRepo">The category repository.</param>
    public UnitOfWork(AppDbContext context,
        IInvoiceRepository invoiceRepo,
        IInvoiceItemRepository itemRepo,
        IProductRepository productRepo,
        ICustomerRepository customerRepo,
        ICategoryRepository categoryRepo)
    {
        _context = context;
        InvoiceRepository = invoiceRepo;
        InvoiceItemRepository = itemRepo;
        ProductRepository = productRepo;
        CustomerRepository = customerRepo;
        CategoryRepository = categoryRepo;
    }

    /// <summary>
    /// Gets the invoice repository.
    /// </summary>
    public IInvoiceRepository InvoiceRepository { get; }

    /// <summary>
    /// Gets the invoice item repository.
    /// </summary>
    public IInvoiceItemRepository InvoiceItemRepository { get; }

    /// <summary>
    /// Gets the product repository.
    /// </summary>
    public IProductRepository ProductRepository { get; }

    /// <summary>
    /// Gets the customer repository.
    /// </summary>
    public ICustomerRepository CustomerRepository { get; }

    /// <summary>
    /// Gets the category repository.
    /// </summary>
    public ICategoryRepository CategoryRepository { get; }

    /// <summary>
    /// Asynchronously saves all changes made in this unit of work to the database.
    /// </summary>
    /// <returns>The number of state entries written to the database.</returns>
    public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
}
