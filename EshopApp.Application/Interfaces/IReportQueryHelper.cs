using EshopApp.Application.DTOs.ReportDTOs;

namespace EshopApp.Application.Interfaces;

/// <summary>
/// Provides methods for querying and generating sales reports.
/// </summary>
public interface IReportQueryHelper
{
    /// <summary>
    /// Asynchronously generates a sales report for the specified date range.
    /// </summary>
    /// <param name="start">The start date of the report period.</param>
    /// <param name="end">The end date of the report period.</param>
    /// <returns>A <see cref="SalesReportDto"/> containing sales data for the specified period.</returns>
    Task<SalesReportDto> GetSalesReportAsync(DateTime start, DateTime end);
}
