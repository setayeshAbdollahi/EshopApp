using EshopApp.Application.Interfaces;
using EshopApp.Application.Exceptions;

namespace EshopApp.Application.UseCases.InvoiceUseCases;

/// <summary>
/// Use case for calculating the total amount of an invoice.
/// </summary>
public class CalculateInvoiceTotalUseCase
{
    private readonly IInvoiceRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CalculateInvoiceTotalUseCase"/> class.
    /// </summary>
    /// <param name="repository">The invoice repository to use for data access.</param>
    public CalculateInvoiceTotalUseCase(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to calculate the total amount for a given invoice.
    /// </summary>
    /// <param name="invoiceId">The unique identifier of the invoice.</param>
    /// <returns>The total amount of the invoice, or 0 if there are no items.</returns>
    /// <exception cref="NotFoundException">Thrown if the invoice is not found.</exception>
    public async Task<decimal> ExecuteAsync(Guid invoiceId)
    {
        var invoice = await _repository.GetByIdWithItemsAsync(invoiceId);
        if (invoice == null)
            throw new NotFoundException("فاکتور مورد نظر یافت نشد.");

        if (invoice.Items == null || !invoice.Items.Any())
            return 0;

        return invoice.Items.Sum(i => i.Quantity * i.UnitPrice);
    }
}
