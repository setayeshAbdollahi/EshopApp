namespace EshopApp.Application.DTOs;

/// <summary>
/// Data transfer object (DTO) for creating a new customer.
/// </summary>
public class CreateCustomerDto
{
    /// <summary>
    /// Gets or sets the full name of the customer.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number of the customer.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address of the customer (optional).
    /// </summary>
    public string? Email { get; set; }
}
