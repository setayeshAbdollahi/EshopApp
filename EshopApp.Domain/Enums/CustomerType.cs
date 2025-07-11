namespace EshopApp.Domain.Enums;

/// <summary>
/// Specifies the type of customer.
/// </summary>
public enum CustomerType
{
    /// <summary>
    /// A regular customer.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// A corporate customer (e.g., business or organization).
    /// </summary>
    Corporate = 1,

    /// <summary>
    /// A VIP customer with special privileges.
    /// </summary>
    VIP = 2
}
