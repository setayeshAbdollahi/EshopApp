using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;
using EshopApp.Shared.Constants;

namespace EshopApp.Application.UseCases.InvoiceUseCases;

/// <summary>
/// Use case for deleting an invoice by its unique identifier.
/// </summary>
public class DeleteInvoiceUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteInvoiceUseCase"/> class.
    /// </summary>
    /// <param name="invoiceRepository">The invoice repository to use for data access.</param>
    public DeleteInvoiceUseCase(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to delete an invoice by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice to delete.</param>
    /// <exception cref="ValidationException">Thrown if the invoice ID is invalid.</exception>
    /// <exception cref="NotFoundException">Thrown if the invoice is not found.</exception>
    public async Task ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ValidationException(new Dictionary<string, string[]>
            {
                { "id", new[] { "شناسه فاکتور نامعتبر است." } }
            });
        }

        var invoice = await _invoiceRepository.GetByIdAsync(id);
        if (invoice == null)
        {
            throw new NotFoundException(AppConstants.ErrorMessages.InvoiceNotFound);
        }

        await _invoiceRepository.DeleteAsync(id);
    }
}
