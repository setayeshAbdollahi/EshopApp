namespace EshopApp.Shared.Constants;

/// <summary>
/// Contains application-wide constant values.
/// </summary>
public static class AppConstants
{
    /// <summary>
    /// The default store name.
    /// </summary>
    public const string DefaultStoreName = "فروشگاه من";

    /// <summary>
    /// The default phone number for the store.
    /// </summary>
    public const string DefaultPhoneNumber = "02100000000";

    /// <summary>
    /// The default address for the store.
    /// </summary>
    public const string DefaultAddress = "تهران، ایران";

    /// <summary>
    /// The default logo URL for the store.
    /// </summary>
    public const string DefaultLogoUrl = "/images/default-logo.png";

    /// <summary>
    /// The Persian culture code.
    /// </summary>
    public const string PersianCulture = "fa-IR";

    /// <summary>
    /// The default date format used in the application.
    /// </summary>
    public const string DateFormat = "yyyy/MM/dd";

    /// <summary>
    /// Contains constant error messages used throughout the application.
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// Error message for an invalid product ID.
        /// </summary>
        public const string InvalidProductId = "شناسه محصول نامعتبر است.";

        /// <summary>
        /// Error message when a product is not found.
        /// </summary>
        public const string ProductNotFound = "محصول یافت نشد.";

        /// <summary>
        /// Error message when a category is not found.
        /// </summary>
        public const string CategoryNotFound = "دسته‌بندی یافت نشد.";

        /// <summary>
        /// Error message when an invoice is not found.
        /// </summary>
        public const string InvoiceNotFound = "فاکتور یافت نشد.";

        /// <summary>
        /// Error message for validation failure.
        /// </summary>
        public const string ValidationFailed = "اعتبارسنجی داده‌ها با شکست مواجه شد.";
    }
}
