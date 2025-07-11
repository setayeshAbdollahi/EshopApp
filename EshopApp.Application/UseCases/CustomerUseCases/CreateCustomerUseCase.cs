using EshopApp.Application.DTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Domain.ValueObjects;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.CustomerUseCases;

/// <summary>
/// Use case for creating a new customer.
/// </summary>
public class CreateCustomerUseCase
{
    private readonly ICustomerRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateCustomerUseCase"/> class.
    /// </summary>
    /// <param name="repository">The customer repository to use for data access.</param>
    public CreateCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to create a new customer.
    /// </summary>
    /// <param name="dto">The data transfer object containing customer details.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure, with validation errors if any.</returns>
    public async Task<Result> ExecuteAsync(CreateCustomerDto dto)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(dto.FullName))
            errors.Add("FullName", new[] { "نام مشتری الزامی است." });

        if (string.IsNullOrWhiteSpace(dto.PhoneNumber))
            errors.Add("PhoneNumber", new[] { "شماره تماس الزامی است." });

        if (errors.Any())
            return Result.Failure(errors);

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            FullName = dto.FullName,
            PhoneNumber = new PhoneNumber(dto.PhoneNumber),
            Email = string.IsNullOrWhiteSpace(dto.Email) ? null : new EmailAddress(dto.Email)
        };

        await _repository.AddAsync(customer);
        return Result.Success();
    }
}
