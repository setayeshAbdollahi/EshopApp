using EshopApp.Application.Interfaces;
using EshopApp.Application.DTOs.ReportDTOs;
using EshopApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace EshopApp.Infrastructure.EFCore.QueryHelper;

/// <summary>
/// Provides query helper methods for generating sales reports from the database.
/// </summary>
public class ReportQueryHelper : IReportQueryHelper
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ReportQueryHelper"/> class.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public ReportQueryHelper(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Asynchronously generates a sales report for the specified date range.
    /// </summary>
    /// <param name="start">The start date of the report period.</param>
    /// <param name="end">The end date of the report period.</param>
    /// <returns>A <see cref="SalesReportDto"/> containing total revenue, invoice count, and sales by customer.</returns>
    public async Task<SalesReportDto> GetSalesReportAsync(DateTime start, DateTime end)
    {
        var invoices = await _context.Invoices
            .Include(i => i.Customer)
            .Include(i => i.Items)
            .Where(i => i.CreatedAt >= start && i.CreatedAt <= end)
            .ToListAsync();

        var totalRevenue = invoices
            .SelectMany(i => i.Items)
            .Sum(item => item.Quantity * item.UnitPrice);

        var salesByCustomer = invoices
            .Where(i => i.Customer != null)
            .GroupBy(i => i.Customer)
            .Where(g => g.Key != null)
            .Select(g => new SalesByCustomerDto
            {
                CustomerId = g.Key!.Id,
                CustomerName = g.Key.FullName ?? "ناشناخته",
                TotalSpent = g.SelectMany(i => i.Items).Sum(item => item.Quantity * item.UnitPrice)
            })
            .ToList();

        return new SalesReportDto
        {
            TotalRevenue = totalRevenue,
            TotalInvoices = invoices.Count,
            SalesByCustomers = salesByCustomer
        };
    }
}
