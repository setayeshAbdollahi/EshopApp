using EshopApp.Application.DTOs;
using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCases.InvoiceItemUseCases;

/// <summary>
/// Use case for retrieving all invoice items by invoice identifier.
/// </summary>
public class GetInvoiceItemsByInvoiceIdUseCase
{
    private readonly IInvoiceItemRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetInvoiceItemsByInvoiceIdUseCase"/> class.
    /// </summary>
    /// <param name="repository">The invoice item repository to use for data access.</param>
    public GetInvoiceItemsByInvoiceIdUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to retrieve all invoice items for a given invoice.
    /// </summary>
    /// <param name="invoiceId">The unique identifier of the invoice.</param>
    /// <returns>A list of <see cref="GetInvoiceItemDto"/> representing the invoice items.</returns>
    /// <exception cref="ValidationException">Thrown if the invoice ID is invalid.</exception>
    /// <exception cref="NotFoundException">Thrown if no items are found for the invoice.</exception>
    public async Task<List<GetInvoiceItemDto>> ExecuteAsync(Guid invoiceId)
    {
        if (invoiceId == Guid.Empty)
            throw new ValidationException(new Dictionary<string, string[]> {
                { "InvoiceId", new[] { "شناسه فاکتور نامعتبر است." } }
            });

        var items = await _repository.GetByInvoiceIdAsync(invoiceId);

        if (items == null || !items.Any())
            throw new NotFoundException("هیچ آیتمی برای این فاکتور یافت نشد.");

        return items.Select(i => new GetInvoiceItemDto
        {
            Id = i.Id,
            ProductName = i.Product?.Name ?? "نامشخص",
            Quantity = i.Quantity,
            UnitPrice = i.UnitPrice,
            CreatedAt = i.CreatedAt,
            UpdatedAt = i.UpdatedAt
        }).ToList();
    }
}
