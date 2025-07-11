using EshopApp.Application.DTOs.BaseDTOs;

namespace EshopApp.Application.DTOs.ReportDTOs;

/// <summary>
/// Data transfer object (DTO) representing sales summary information for a customer.
/// </summary>
/// <remarks>
/// Inherits common properties from <see cref="BaseDto"/> and adds customer sales-specific fields.
/// </remarks>
public class SalesByCustomerDto : BaseDto
{
    /// <summary>
    /// Gets or sets the unique identifier of the customer.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the name of the customer.
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the number of invoices associated with the customer.
    /// </summary>
    public int InvoiceCount { get; set; }

    /// <summary>
    /// Gets or sets the total amount spent by the customer.
    /// </summary>
    public decimal TotalSpent { get; set; }
}

