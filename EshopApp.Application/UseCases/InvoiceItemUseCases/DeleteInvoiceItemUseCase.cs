using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;

namespace EshopApp.Application.UseCases.InvoiceItemUseCases;

/// <summary>
/// Use case for deleting an invoice item by its unique identifier.
/// </summary>
public class DeleteInvoiceItemUseCase
{
    private readonly IInvoiceItemRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteInvoiceItemUseCase"/> class.
    /// </summary>
    /// <param name="repository">The invoice item repository to use for data access.</param>
    public DeleteInvoiceItemUseCase(IInvoiceItemRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to delete an invoice item by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice item to delete.</param>
    /// <exception cref="NotFoundException">Thrown if the invoice item is not found.</exception>
    public async Task ExecuteAsync(Guid id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
            throw new NotFoundException("آیتم فاکتور یافت نشد.");

        await _repository.DeleteAsync(id);
    }
}