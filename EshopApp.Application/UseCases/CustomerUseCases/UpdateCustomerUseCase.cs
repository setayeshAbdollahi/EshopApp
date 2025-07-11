using EshopApp.Application.DTOs;
using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.ValueObjects;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.CustomerUseCases;

/// <summary>
/// Use case for updating an existing customer's information.
/// </summary>
public class UpdateCustomerUseCase
{
    private readonly ICustomerRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateCustomerUseCase"/> class.
    /// </summary>
    /// <param name="repository">The customer repository to use for data access.</param>
    public UpdateCustomerUseCase(ICustomerRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to update a customer's information.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to update.</param>
    /// <param name="dto">The data transfer object containing the updated customer details.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure, with validation errors if any.</returns>
    public async Task<Result> ExecuteAsync(Guid id, UpdateCustomerDto dto)
    {
        var errors = new Dictionary<string, string[]>();

        if (string.IsNullOrWhiteSpace(dto.FullName))
            errors.Add("FullName", new[] { "نام مشتری الزامی است." });

        if (string.IsNullOrWhiteSpace(dto.PhoneNumber))
            errors.Add("PhoneNumber", new[] { "شماره تماس الزامی است." });

        if (errors.Any())
            return Result.Failure(errors);

        var customer = await _repository.GetByIdAsync(id);

        if (customer == null)
            return Result.Failure("مشتری یافت نشد.");

        try
        {
            customer.FullName = dto.FullName;
            customer.PhoneNumber = new PhoneNumber(dto.PhoneNumber); // استفاده از ValueObject
            customer.Email = string.IsNullOrWhiteSpace(dto.Email) ? null : new EmailAddress(dto.Email); // اگر null نباشد
        }
        catch (Exception ex)
        {
            return Result.Failure("مقداردهی یکی از فیلدها نامعتبر است: " + ex.Message);
        }

        await _repository.UpdateAsync(customer);
        return Result.Success();
    }
}
