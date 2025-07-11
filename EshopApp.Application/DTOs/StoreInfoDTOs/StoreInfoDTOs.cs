using EshopApp.Application.DTOs.BaseDTOs;

namespace EshopApp.Application.DTOs.StoreInfoDTOs;

/// <summary>
/// Data transfer object (DTO) representing store information.
/// </summary>
/// <remarks>
/// Inherits common properties from <see cref="BaseDto"/> and adds store-specific fields.
/// </remarks>
public class StoreInfoDto : BaseDto
{
    /// <summary>
    /// Gets or sets the name of the store.
    /// </summary>
    public string StoreName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the address of the store.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number of the store.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL of the store's logo (optional).
    /// </summary>
    public string? LogoUrl { get; set; }
}


