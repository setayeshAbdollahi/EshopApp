using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EshopApp.Persistence.Configurations;
using EshopApp.Shared.Base;

namespace EshopApp.Persistence.Data;

/// <summary>
/// The application's Entity Framework database context, managing entity sets and configuration.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class.
    /// </summary>
    /// <param name="options">The options to be used by the DbContext.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Gets the <see cref="DbSet{TEntity}"/> for products.
    /// </summary>
    public DbSet<Product> Products => Set<Product>();

    /// <summary>
    /// Gets the <see cref="DbSet{TEntity}"/> for categories.
    /// </summary>
    public DbSet<Category> Categories => Set<Category>();

    /// <summary>
    /// Gets the <see cref="DbSet{TEntity}"/> for customers.
    /// </summary>
    public DbSet<Customer> Customers => Set<Customer>();

    /// <summary>
    /// Gets the <see cref="DbSet{TEntity}"/> for invoices.
    /// </summary>
    public DbSet<Invoice> Invoices => Set<Invoice>();

    /// <summary>
    /// Gets the <see cref="DbSet{TEntity}"/> for invoice items.
    /// </summary>
    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();

    /// <summary>
    /// Gets the <see cref="DbSet{TEntity}"/> for store information.
    /// </summary>
    public DbSet<StoreInfo> StoreInfos => Set<StoreInfo>();

    /// <summary>
    /// Configures the entity mappings and relationships for the context.
    /// </summary>
    /// <param name="modelBuilder">The builder used to construct the model for the context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceItemConfiguration());
        modelBuilder.ApplyConfiguration(new StoreInfoConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Saves all changes made in this context to the database, applying timestamps.
    /// </summary>
    /// <returns>The number of state entries written to the database.</returns>
    public override int SaveChanges()
    {
        ApplyTimestamps();
        return base.SaveChanges();
    }

    /// <summary>
    /// Asynchronously saves all changes made in this context to the database, applying timestamps.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that represents the asynchronous save operation. The task result contains the number of state entries written to the database.</returns>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        ApplyTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Applies creation and update timestamps to entities derived from <see cref="BaseEntity"/>.
    /// </summary>
    private void ApplyTimestamps()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;
            }
        }
    }
}
