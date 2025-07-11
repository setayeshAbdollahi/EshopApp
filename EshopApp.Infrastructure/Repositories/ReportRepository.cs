using EshopApp.Application.Interfaces;
using EshopApp.Application.DTOs.ReportDTOs;
using EshopApp.Domain.Entities;
using EshopApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace EshopApp.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for generating sales reports from invoice data.
/// </summary>
public class ReportRepository : IReportService
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ReportRepository"/> class.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public ReportRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Generates a sales report for the specified date range, including total invoices, revenue, and sales by customer.
    /// </summary>
    /// <param name="startDate">The start date of the report period.</param>
    /// <param name="endDate">The end date of the report period.</param>
    /// <returns>A <see cref="SalesReportDto"/> containing the report data.</returns>
    public async Task<SalesReportDto> GenerateSalesReportAsync(DateTime startDate, DateTime endDate)
    {
        var invoices = await _context.Invoices
            .Include(i => i.Items)
            .Include(i => i.Customer)
            .Where(i => i.IssuedDate >= startDate && i.IssuedDate <= endDate)
            .ToListAsync();

        var totalInvoices = invoices.Count;
        var totalRevenue = invoices
            .SelectMany(i => i.Items)
            .Sum(item => item.UnitPrice * item.Quantity);

        var salesByCustomers = invoices
            .GroupBy(i => i.Customer != null ? i.Customer.FullName : "نامشخص")
            .Select(g => new SalesByCustomerDto
            {
                CustomerName = g.Key,
                InvoiceCount = g.Count(),
                TotalSpent = g
                    .SelectMany(i => i.Items)
                    .Sum(item => item.UnitPrice * item.Quantity)
            })
            .ToList();

        return new SalesReportDto
        {
            StartDate = startDate,
            EndDate = endDate,
            TotalInvoices = totalInvoices,
            TotalRevenue = totalRevenue,
            SalesByCustomers = salesByCustomers
        };
    }
}
