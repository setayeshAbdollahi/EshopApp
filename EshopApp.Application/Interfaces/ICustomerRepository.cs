using EshopApp.Domain.Entities;

namespace EshopApp.Application.Interfaces;

/// <summary>
/// Defines methods for accessing and managing customer entities in the data store.
/// </summary>
public interface ICustomerRepository
{
    /// <summary>
    /// Adds a new customer to the data store.
    /// </summary>
    /// <param name="customer">The customer entity to add.</param>
    Task AddAsync(Customer customer);

    /// <summary>
    /// Updates an existing customer in the data store.
    /// </summary>
    /// <param name="customer">The customer entity to update.</param>
    Task UpdateAsync(Customer customer);

    /// <summary>
    /// Deletes a customer from the data store by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete.</param>
    Task DeleteAsync(Guid id);

    /// <summary>
    /// Retrieves a customer by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The customer entity if found; otherwise, null.</returns>
    Task<Customer?> GetByIdAsync(Guid id);

    /// <summary>
    /// Retrieves all customers from the data store.
    /// </summary>
    /// <returns>A list of all customer entities.</returns>
    Task<List<Customer>> GetAllAsync();
}
