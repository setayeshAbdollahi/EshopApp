using EshopApp.Application.Interfaces;
using EshopApp.Infrastructure.Repositories;
using EshopApp.Infrastructure.EFCore.UnitOfWork;
using EshopApp.Infrastructure.EFCore.QueryHelper;
using EshopApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EshopApp.Infrastructure;

/// <summary>
/// Provides extension methods for registering infrastructure services and dependencies.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Registers infrastructure layer services, repositories, unit of work, and query helpers with the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    /// <param name="connectionString">The database connection string.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        // DbContext
        services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(connectionString));

        // Repositories
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();

        // Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Query Helpers
        services.AddScoped<IReportQueryHelper, ReportQueryHelper>();

        return services;
    }
}
