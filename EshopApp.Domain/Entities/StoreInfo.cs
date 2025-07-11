using EshopApp.Shared.Base;

namespace EshopApp.Domain.Entities;
/// <summary>
/// Represents store information such as name, address, contact, and logo.
/// </summary>
public class StoreInfo : BaseEntity
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
