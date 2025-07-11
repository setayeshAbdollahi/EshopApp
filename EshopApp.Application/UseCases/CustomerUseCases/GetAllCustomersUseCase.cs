using EshopApp.Application.DTOs;
using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.ValueObjects;

namespace EshopApp.Application.UseCases.CustomerUseCases;

/// <summary>
/// Use case for retrieving all customers.
/// </summary>
public class GetAllCustomersUseCase
{
    private readonly ICustomerRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllCustomersUseCase"/> class.
    /// </summary>
    /// <param name="repository">The customer repository to use for data access.</param>
    public GetAllCustomersUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to retrieve all customers.
    /// </summary>
    /// <returns>A list of <see cref="GetCustomerDto"/> representing all customers.</returns>
    /// <exception cref="NotFoundException">Thrown if no customers are found.</exception>
    public async Task<List<GetCustomerDto>> ExecuteAsync()
    {
        var customers = await _repository.GetAllAsync();

        if (customers == null || !customers.Any())
            throw new NotFoundException("هیچ مشتری یافت نشد.");

        return customers.Select(c => new GetCustomerDto
        {
            Id = c.Id,
            FullName = c.FullName,
            PhoneNumber = c.PhoneNumber.ToString(),
            Email = c.Email?.ToString()
        }).ToList();
    }
}
