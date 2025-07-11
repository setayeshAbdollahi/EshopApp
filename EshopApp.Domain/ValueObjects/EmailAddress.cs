namespace EshopApp.Domain.ValueObjects;

/// <summary>
/// Represents an email address value object with validation.
/// </summary>
public record EmailAddress
{
    /// <summary>
    /// Gets the email address value.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailAddress"/> record.
    /// </summary>
    /// <param name="value">The email address string value.</param>
    /// <exception cref="ArgumentException">Thrown if the value is null, empty, or not a valid email address.</exception>
    public EmailAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("ایمیل نمی‌تواند خالی باشد.");

        if (!value.Contains("@"))
            throw new ArgumentException("ایمیل نامعتبر است.");

        Value = value;
    }

    /// <summary>
    /// Returns the string representation of the email address.
    /// </summary>
    public override string ToString() => Value;
}
