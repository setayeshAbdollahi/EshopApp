using EshopApp.Shared.Base;
using EshopApp.Domain.ValueObjects;
using EshopApp.Domain.Enums;

namespace EshopApp.Domain.Entities;

/// <summary>
/// Represents a customer entity in the system.
/// </summary>
public class Customer : BaseEntity
{
    /// <summary>
    /// Gets or sets the full name of the customer.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number of the customer.
    /// </summary>
    public required PhoneNumber PhoneNumber { get; set; }

    /// <summary>
    /// Gets or sets the type of the customer (e.g., Normal, VIP).
    /// </summary>
    public CustomerType Type { get; set; } = CustomerType.Normal;

    /// <summary>
    /// Gets or sets the email address of the customer (optional).
    /// </summary>
    public EmailAddress? Email { get; set; }

    /// <summary>
    /// Gets or sets the list of invoices associated with the customer.
    /// </summary>
    public List<Invoice> Invoices { get; set; } = new();
}
