namespace EshopApp.Application.DTOs.StoreInfoDTOs;

/// <summary>
/// Data transfer object (DTO) for updating store information.
/// </summary>
public class UpdateStoreInfoDto
{
    /// <summary>
    /// Gets or sets the updated name of the store.
    /// </summary>
    public string StoreName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated address of the store.
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated phone number of the store.
    /// </summary>
    public string PhoneNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the updated URL of the store's logo (optional).
    /// </summary>
    public string? LogoUrl { get; set; }
}