using EshopApp.Application.DTOs;
using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCases.InvoiceItemUseCases;

/// <summary>
/// Use case for updating an existing invoice item's quantity and unit price.
/// </summary>
public class UpdateInvoiceItemUseCase
{
    private readonly IInvoiceItemRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateInvoiceItemUseCase"/> class.
    /// </summary>
    /// <param name="repository">The invoice item repository to use for data access.</param>
    public UpdateInvoiceItemUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to update an invoice item's quantity and unit price.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice item to update.</param>
    /// <param name="quantity">The new quantity for the invoice item.</param>
    /// <param name="unitPrice">The new unit price for the invoice item.</param>
    /// <exception cref="NotFoundException">Thrown if the invoice item is not found.</exception>
    /// <exception cref="ValidationException">Thrown if the quantity or unit price is invalid.</exception>
    public async Task ExecuteAsync(Guid id, int quantity, decimal unitPrice)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
            throw new NotFoundException("آیتم فاکتور مورد نظر یافت نشد.");

        if (quantity <= 0 || unitPrice <= 0)
        {
            var errors = new Dictionary<string, string[]>();
            if (quantity <= 0)
                errors.Add("Quantity", new[] { "مقدار باید بیشتر از صفر باشد." });
            if (unitPrice <= 0)
                errors.Add("UnitPrice", new[] { "قیمت باید بیشتر از صفر باشد." });
            throw new ValidationException(errors);
        }

        item.Quantity = quantity;
        item.UnitPrice = unitPrice;

        await _repository.UpdateAsync(item);
    }
}