using EshopApp.Application.DTOs;
using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCases.InvoiceItemUseCases;

/// <summary>
/// Use case for retrieving an invoice item by its unique identifier.
/// </summary>
public class GetInvoiceItemByIdUseCase
{
    private readonly IInvoiceItemRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetInvoiceItemByIdUseCase"/> class.
    /// </summary>
    /// <param name="repository">The invoice item repository to use for data access.</param>
    public GetInvoiceItemByIdUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to retrieve an invoice item by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice item to retrieve.</param>
    /// <returns>A <see cref="GetInvoiceItemDto"/> containing the invoice item data.</returns>
    /// <exception cref="ValidationException">Thrown if the provided ID is invalid.</exception>
    /// <exception cref="NotFoundException">Thrown if the invoice item is not found.</exception>
    public async Task<GetInvoiceItemDto> ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
            throw new ValidationException(new Dictionary<string, string[]> {
                { "Id", new[] { "شناسه آیتم نامعتبر است." } }
            });

        var item = await _repository.GetByIdAsync(id);

        if (item == null)
            throw new NotFoundException("آیتم مورد نظر یافت نشد.");

        return new GetInvoiceItemDto
        {
            Id = item.Id,
            ProductName = item.Product?.Name ?? "نامشخص",
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            CreatedAt = item.CreatedAt,
            UpdatedAt = item.UpdatedAt
        };
    }
}
