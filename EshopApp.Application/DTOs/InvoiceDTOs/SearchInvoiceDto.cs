namespace EshopApp.Application.DTOs;

/// <summary>
/// Data transfer object (DTO) for searching invoices based on various criteria.
/// </summary>
public class SearchInvoiceDto
{
    /// <summary>
    /// Gets or sets the customer name to search for.
    /// </summary>
    public string? CustomerName { get; set; }          

    /// <summary>
    /// Gets or sets the start date for the search range.
    /// </summary>
    public DateTime? FromDate { get; set; }             

    /// <summary>
    /// Gets or sets the end date for the search range.
    /// </summary>
    public DateTime? ToDate { get; set; }              

    /// <summary>
    /// Gets or sets the minimum invoice amount for the search.
    /// </summary>
    public decimal? MinAmount { get; set; }            

    /// <summary>
    /// Gets or sets the maximum invoice amount for the search.
    /// </summary>
    public decimal? MaxAmount { get; set; }           
}
