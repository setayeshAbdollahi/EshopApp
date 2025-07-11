using EshopApp.Application.DTOs.BaseDTOs;
namespace EshopApp.Application.DTOs;

/// <summary>
/// Data transfer object (DTO) for retrieving customer information.
/// </summary>
/// <remarks>
/// Inherits common properties from <see cref="BaseDto"/> and adds customer-specific fields.
/// </remarks>
public class GetCustomerDto : BaseDto
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
