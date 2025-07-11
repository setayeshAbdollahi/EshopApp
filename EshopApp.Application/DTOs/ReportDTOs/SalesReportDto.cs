using EshopApp.Application.DTOs.BaseDTOs;

namespace EshopApp.Application.DTOs.ReportDTOs;

/// <summary>
/// Data transfer object (DTO) representing a sales report for a specified period.
/// </summary>
/// <remarks>
/// Inherits common properties from <see cref="BaseDto"/> and includes sales summary fields.
/// </remarks>
public class SalesReportDto : BaseDto
{
    /// <summary>
    /// Gets or sets the start date of the sales report period.
    /// </summary>
    public DateTime StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date of the sales report period.
    /// </summary>
    public DateTime EndDate { get; set; }

    /// <summary>
    /// Gets or sets the total number of invoices in the report period.
    /// </summary>
    public int TotalInvoices { get; set; }

    /// <summary>
    /// Gets or sets the total revenue generated in the report period.
    /// </summary>
    public decimal TotalRevenue { get; set; }

    /// <summary>
    /// Gets or sets the list of sales summaries by customer.
    /// </summary>
    public List<SalesByCustomerDto> SalesByCustomers { get; set; } = new();
}