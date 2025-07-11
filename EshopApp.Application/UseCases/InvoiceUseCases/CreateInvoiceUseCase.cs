using EshopApp.Application.DTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.InvoiceUseCases;

/// <summary>
/// Use case for creating a new invoice with its items.
/// </summary>
public class CreateInvoiceUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateInvoiceUseCase"/> class.
    /// </summary>
    /// <param name="invoiceRepository">The invoice repository to use for data access.</param>
    public CreateInvoiceUseCase(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to create a new invoice and its items.
    /// </summary>
    /// <param name="dto">The data transfer object containing invoice details and items.</param>
    /// <returns>A <see cref="Result"/> indicating success or failure, with validation errors if any.</returns>
    public async Task<Result> ExecuteAsync(CreateInvoiceDto dto)
    {
        var validationErrors = new Dictionary<string, string[]>();

        if (dto.CustomerId == Guid.Empty)
            validationErrors.Add("CustomerId", new[] { "شناسه مشتری نامعتبر است." });

        if (dto.Items == null || !dto.Items.Any())
        {
            validationErrors.Add("Items", new[] { "فاکتور باید حداقل یک آیتم داشته باشد." });
        }
        else
        {
            foreach (var item in dto.Items)
            {
                if (item.ProductId == Guid.Empty)
                    validationErrors.TryAdd("ProductId", new[] { "شناسه محصول نامعتبر است." });

                if (item.Quantity <= 0)
                    validationErrors.TryAdd("Quantity", new[] { "تعداد باید بیشتر از صفر باشد." });

                if (item.UnitPrice < 0)
                    validationErrors.TryAdd("UnitPrice", new[] { "قیمت نمی‌تواند منفی باشد." });
            }
        }

        if (validationErrors.Any())
            return Result.Failure(validationErrors);

        var invoice = new Invoice
        {
            Id = Guid.NewGuid(),
            CustomerId = dto.CustomerId,
            Status = dto.Status,
            Items = dto.Items!.Select(i => new InvoiceItem
            {
                Id = Guid.NewGuid(),
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            }).ToList()
        };

        await _invoiceRepository.AddAsync(invoice);

        return Result.Success();
    }
}
