using EshopApp.Application.DTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.CustomerUseCases;

/// <summary>
/// Use case for retrieving a customer by their unique identifier.
/// </summary>
public class GetCustomerByIdUseCase
{
    private readonly ICustomerRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetCustomerByIdUseCase"/> class.
    /// </summary>
    /// <param name="repository">The customer repository to use for data access.</param>
    public GetCustomerByIdUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to retrieve a customer by their identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to retrieve.</param>
    /// <returns>A <see cref="Result{GetCustomerDto}"/> containing the customer data if found, or an error message.</returns>
    public async Task<Result<GetCustomerDto>> ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
            return Result<GetCustomerDto>.Failure("شناسه مشتری نامعتبر است.");

        var customer = await _repository.GetByIdAsync(id);

        if (customer == null)
            return Result<GetCustomerDto>.Failure("مشتری یافت نشد.");

        return Result<GetCustomerDto>.Success(new GetCustomerDto
        {
            Id = customer.Id,
            FullName = customer.FullName,
            PhoneNumber = customer.PhoneNumber.Value,
            Email = customer.Email?.Value
        });
    }
}
