using EshopApp.Application.DTOs;
using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Shared.Constants;

namespace EshopApp.Application.UseCases.InvoiceUseCases;

/// <summary>
/// Use case for retrieving all invoices with their items and customer information.
/// </summary>
public class GetAllInvoicesUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllInvoicesUseCase"/> class.
    /// </summary>
    /// <param name="invoiceRepository">The invoice repository to use for data access.</param>
    public GetAllInvoicesUseCase(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to retrieve all invoices, including their items and customer details.
    /// </summary>
    /// <returns>A list of <see cref="GetInvoiceDto"/> representing all invoices.</returns>
    /// <exception cref="NotFoundException">Thrown if no invoices are found.</exception>
    /// <exception cref="ValidationException">Thrown if customer or product information is missing for any invoice or item.</exception>
    public async Task<List<GetInvoiceDto>> ExecuteAsync()
    {
        var invoices = await _invoiceRepository.GetAllAsync();

        if (invoices == null || !invoices.Any())
            throw new NotFoundException(AppConstants.ErrorMessages.InvoiceNotFound);

        var result = new List<GetInvoiceDto>();

        foreach (var invoice in invoices)
        {
            if (invoice.Customer == null)
            {
                throw new ValidationException(new Dictionary<string, string[]>
                {
                    { "Customer", new[] { $"اطلاعات مشتری برای فاکتور با شناسه {invoice.Id} ناقص است." } }
                });
            }

            var invoiceDto = new GetInvoiceDto
            {
                Id = invoice.Id,
                IssuedDate = invoice.IssuedDate,
                CustomerName = invoice.Customer.FullName,
                TotalAmount = invoice.TotalAmount,
                CreatedAt = invoice.CreatedAt,
                UpdatedAt = invoice.UpdatedAt,
                Items = new List<GetInvoiceItemDto>()
            };

            foreach (var item in invoice.Items)
            {
                if (item.Product == null)
                {
                    throw new ValidationException(new Dictionary<string, string[]>
                    {
                        { "Product", new[] { $"اطلاعات محصول برای آیتم با شناسه {item.Id} در فاکتور {invoice.Id} ناقص است." } }
                    });
                }

                invoiceDto.Items.Add(new GetInvoiceItemDto
                {
                    Id = item.Id,
                    ProductName = item.Product.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice,
                    CreatedAt = item.CreatedAt,
                    UpdatedAt = item.UpdatedAt
                });
            }

            result.Add(invoiceDto);
        }

        return result;
    }
}
