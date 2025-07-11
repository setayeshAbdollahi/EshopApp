using EshopApp.Application.Interfaces;
using EshopApp.Infrastructure.Repositories;
using EshopApp.Infrastructure.EFCore.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace EshopApp.Infrastructure.Extensions;

/// <summary>
/// Provides extension methods for registering infrastructure services in the dependency injection container.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers infrastructure layer services and repositories with the dependency injection container.
    /// </summary>
    /// <param name="services">The service collection to add the services to.</param>
    /// <returns>The updated <see cref="IServiceCollection"/> instance.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        services.AddScoped<IInvoiceItemRepository, InvoiceItemRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IStoreInfoRepository, StoreInfoRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
