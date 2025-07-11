using EshopApp.Application.DTOs.ReportDTOs;

namespace EshopApp.Application.Interfaces;

/// <summary>
/// Provides services for generating various reports.
/// </summary>
public interface IReportService
{
    /// <summary>
    /// Asynchronously generates a sales report for the specified date range.
    /// </summary>
    /// <param name="startDate">The start date of the report period.</param>
    /// <param name="endDate">The end date of the report period.</param>
    /// <returns>A <see cref="SalesReportDto"/> containing sales data for the specified period.</returns>
    Task<SalesReportDto> GenerateSalesReportAsync(DateTime startDate, DateTime endDate);
}
