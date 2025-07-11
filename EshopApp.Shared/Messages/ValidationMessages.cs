namespace EshopApp.Shared.Massages;

/// <summary>
/// Contains constant validation messages used throughout the application.
/// </summary>
public static class ValidationMessages
{
    /// <summary>
    /// Message indicating a required field.
    /// </summary>
    public const string Required = "فیلد الزامی است.";

    /// <summary>
    /// Message indicating an invalid GUID value.
    /// </summary>
    public const string InvalidGuid = "شناسه نامعتبر است.";

    /// <summary>
    /// Message indicating a value cannot be negative.
    /// </summary>
    public const string NegativeValue = "مقدار نمی‌تواند منفی باشد.";

    /// <summary>
    /// Message indicating a name cannot be empty.
    /// </summary>
    public const string EmptyName = "نام نمی‌تواند خالی باشد.";

    /// <summary>
    /// Message indicating quantity must be greater than zero.
    /// </summary>
    public const string ZeroOrLessQuantity = "تعداد باید بیشتر از صفر باشد.";
}
