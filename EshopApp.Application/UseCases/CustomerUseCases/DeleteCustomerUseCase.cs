using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCases.CustomerUseCases;

/// <summary>
/// Use case for deleting a customer by their unique identifier.
/// </summary>
public class DeleteCustomerUseCase
{
    private readonly ICustomerRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteCustomerUseCase"/> class.
    /// </summary>
    /// <param name="repository">The customer repository to use for data access.</param>
    public DeleteCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to delete a customer by their identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete.</param>
    /// <exception cref="NotFoundException">Thrown if the customer is not found.</exception>
    public async Task ExecuteAsync(Guid id)
    {
        var customer = await _repository.GetByIdAsync(id);

        if (customer == null)
            throw new NotFoundException("مشتری یافت نشد.");

        await _repository.DeleteAsync(id);
    }
}
