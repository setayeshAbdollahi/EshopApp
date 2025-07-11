namespace EshopApp.Application.DTOs;

/// <summary>
/// Data transfer object (DTO) for updating an existing customer.
/// </summary>
public class UpdateCustomerDto
{
    /// <summary>
    /// Gets or sets the updated full name of the customer.
    /// </summary>
    public string FullName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated phone number of the customer.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated email address of the customer (optional).
    /// </summary>
    public string? Email { get; set; }
}
