using EshopApp.Application.DTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Shared.Constants;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.InvoiceUseCases;

/// <summary>
/// Use case for retrieving an invoice by its unique identifier.
/// </summary>
public class GetInvoiceByIdUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetInvoiceByIdUseCase"/> class.
    /// </summary>
    /// <param name="invoiceRepository">The invoice repository to use for data access.</param>
    public GetInvoiceByIdUseCase(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to retrieve an invoice by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the invoice to retrieve.</param>
    /// <returns>A <see cref="Result{GetInvoiceDto}"/> containing the invoice data if found, or an error message.</returns>
    public async Task<Result<GetInvoiceDto>> ExecuteAsync(Guid id)
    {
        if (id == Guid.Empty)
        {
            return Result<GetInvoiceDto>.Failure("شناسه فاکتور معتبر نیست.");
        }

        var invoice = await _invoiceRepository.GetByIdAsync(id);

        if (invoice == null)
        {
            return Result<GetInvoiceDto>.Failure(AppConstants.ErrorMessages.InvoiceNotFound);
        }

        var result = new GetInvoiceDto
        {
            Id = invoice.Id,
            IssuedDate = invoice.IssuedDate,
            CustomerName = invoice.Customer?.FullName ?? "ناشناس",
            TotalAmount = invoice.TotalAmount,
            Items = invoice.Items.Select(i => new GetInvoiceItemDto
            {
                ProductName = i.Product?.Name ?? "نامشخص",
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };

        return Result<GetInvoiceDto>.Success(result);
    }
}
