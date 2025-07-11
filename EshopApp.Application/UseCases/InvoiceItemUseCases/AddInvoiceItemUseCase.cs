using EshopApp.Application.DTOs;
using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;

namespace EshopApp.Application.UseCases.InvoiceItemUseCases;

/// <summary>
/// Use case for adding a new item to an invoice.
/// </summary>
public class AddInvoiceItemUseCase
{
    private readonly IInvoiceItemRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddInvoiceItemUseCase"/> class.
    /// </summary>
    /// <param name="repository">The invoice item repository to use for data access.</param>
    public AddInvoiceItemUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to add a new item to an invoice.
    /// </summary>
    /// <param name="invoiceId">The unique identifier of the invoice to which the item will be added.</param>
    /// <param name="dto">The data transfer object containing invoice item details.</param>
    /// <exception cref="ValidationException">Thrown if the product ID, quantity, or unit price is invalid.</exception>
    public async Task ExecuteAsync(Guid invoiceId, CreateInvoiceItemDto dto)
    {
        if (dto.ProductId == Guid.Empty || dto.Quantity <= 0 || dto.UnitPrice <= 0)
        {
            var errors = new Dictionary<string, string[]>();
            if (dto.ProductId == Guid.Empty)
                errors.Add("ProductId", new[] { "محصول باید مشخص شود." });
            if (dto.Quantity <= 0)
                errors.Add("Quantity", new[] { "مقدار باید بیشتر از صفر باشد." });
            if (dto.UnitPrice <= 0)
                errors.Add("UnitPrice", new[] { "قیمت باید بیشتر از صفر باشد." });
            throw new ValidationException(errors);
        }

        var item = new InvoiceItem
        {
            Id = Guid.NewGuid(),
            ProductId = dto.ProductId,
            Quantity = dto.Quantity,
            UnitPrice = dto.UnitPrice,
            InvoiceId = invoiceId
        };

        await _repository.AddAsync(item);
    }
}
