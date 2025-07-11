using EshopApp.Application.DTOs;
using EshopApp.Application.Exceptions;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Shared.Constants;

namespace EshopApp.Application.UseCases.InvoiceUseCases;

/// <summary>
/// Use case for searching invoices by customer name.
/// </summary>
public class SearchInvoiceUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="SearchInvoiceUseCase"/> class.
    /// </summary>
    /// <param name="invoiceRepository">The invoice repository to use for data access.</param>
    public SearchInvoiceUseCase(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to search for invoices by customer name.
    /// </summary>
    /// <param name="customerName">The name of the customer to search for.</param>
    /// <returns>A list of <see cref="GetInvoiceDto"/> representing the found invoices.</returns>
    /// <exception cref="ValidationException">Thrown if the customer name is null or whitespace.</exception>
    /// <exception cref="NotFoundException">Thrown if no invoices are found for the given customer name.</exception>
    public async Task<List<GetInvoiceDto>> ExecuteAsync(string customerName)
    {
        if (string.IsNullOrWhiteSpace(customerName))
        {
            throw new ValidationException(new Dictionary<string, string[]>
            {
                { "customerName", new[] { "نام مشتری نمی‌تواند خالی باشد." } }
            });
        }

        var invoices = await _invoiceRepository.SearchAsync(customerName);

        if (invoices == null || !invoices.Any())
        {
            throw new NotFoundException(AppConstants.ErrorMessages.InvoiceNotFound);
        }

        var result = invoices.Select(invoice => new GetInvoiceDto
        {
            Id = invoice.Id,
            IssuedDate = invoice.IssuedDate,
            CustomerName = invoice.Customer?.FullName ?? "ناشناس",
            TotalAmount = invoice.TotalAmount,
            CreatedAt = invoice.CreatedAt,
            UpdatedAt = invoice.UpdatedAt,
            Items = invoice.Items.Select(i => new GetInvoiceItemDto
            {
                Id = i.Id,
                ProductName = i.Product?.Name ?? "نامشخص",
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                CreatedAt = i.CreatedAt,
                UpdatedAt = i.UpdatedAt
            }).ToList()
        }).ToList();

        return result;
    }
}
