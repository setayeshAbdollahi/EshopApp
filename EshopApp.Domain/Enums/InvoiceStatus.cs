namespace EshopApp.Domain.Enums;

/// <summary>
/// Specifies the status of an invoice.
/// </summary>
public enum InvoiceStatus
{
    /// <summary>
    /// The invoice is in draft state and not yet submitted.
    /// </summary>
    Draft = 0,

    /// <summary>
    /// The invoice has been submitted but not yet paid.
    /// </summary>
    Submitted = 1,

    /// <summary>
    /// The invoice has been paid.
    /// </summary>
    Paid = 2,

    /// <summary>
    /// The invoice has been cancelled.
    /// </summary>
    Cancelled = 3
}
