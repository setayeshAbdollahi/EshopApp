using EshopApp.Persistence.Data;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace EshopApp.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="Customer"/> entities in the database.
/// </summary>
public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public CustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adds a new customer to the database.
    /// </summary>
    /// <param name="customer">The customer to add.</param>
    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Deletes a customer from the database by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete.</param>
    public async Task DeleteAsync(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer != null)
        {
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }

    /// <summary>
    /// Retrieves all customers from the database.
    /// </summary>
    /// <returns>A list of all customers.</returns>
    public async Task<List<Customer>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    /// <summary>
    /// Retrieves a customer by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The customer if found; otherwise, null.</returns>
    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    /// <summary>
    /// Updates an existing customer in the database.
    /// </summary>
    /// <param name="customer">The customer to update.</param>
    public async Task UpdateAsync(Customer customer)
    {
        _context.Customers.Update(customer);
        await _context.SaveChangesAsync();
    }
}
