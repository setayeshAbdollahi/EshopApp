using EshopApp.Application.DTOs.ReportDTOs;
using EshopApp.Application.Interfaces;
using EshopApp.Shared.Helpers;
using EshopApp.Shared.Result;

namespace EshopApp.Application.UseCases.ReportUseCases;

/// <summary>
/// Use case for generating a sales report for a specified date range.
/// </summary>
public class GenerateSalesReportUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenerateSalesReportUseCase"/> class.
    /// </summary>
    /// <param name="invoiceRepository">The invoice repository to use for data access.</param>
    public GenerateSalesReportUseCase(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to generate a sales report for the given date range.
    /// </summary>
    /// <param name="startDate">The start date of the report period.</param>
    /// <param name="endDate">The end date of the report period.</param>
    /// <returns>A <see cref="Result{SalesReportDto}"/> containing the sales report data, or an error message if no data is found.</returns>
    public async Task<Result<SalesReportDto>> ExecuteAsync(DateTime startDate, DateTime endDate)
    {
        if (!DateHelper.IsValidDateRange(startDate, endDate))
        {
            return Result<SalesReportDto>.Failure("بازه تاریخی نامعتبر است.");
        }

        var invoices = await _invoiceRepository.GetAllAsync();

        var filtered = invoices
            .Where(inv => inv.IssuedDate >= startDate && inv.IssuedDate <= endDate)
            .Where(inv => inv.Customer != null)
            .ToList();

        if (!filtered.Any())
        {
            return Result<SalesReportDto>.Failure("هیچ فاکتوری در بازه زمانی مشخص‌شده یافت نشد.");
        }

        var salesByCustomer = filtered
            .GroupBy(i => i.Customer)
            .Where(g => g.Key != null)
            .Select(g => new SalesByCustomerDto
            {
                CustomerId = g.Key!.Id,
                CustomerName = g.Key.FullName ?? "نامشخص",
                TotalSpent = g.Sum(x => x.TotalAmount)
            })
            .ToList();

        var report = new SalesReportDto
        {
            StartDate = startDate,
            EndDate = endDate,
            TotalInvoices = filtered.Count,
            TotalRevenue = filtered.Sum(i => i.TotalAmount),
            SalesByCustomers = salesByCustomer
        };

        return Result<SalesReportDto>.Success(report);
    }
}
