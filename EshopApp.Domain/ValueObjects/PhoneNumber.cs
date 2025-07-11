namespace EshopApp.Domain.ValueObjects;

/// <summary>
/// Represents a phone number value object with validation.
/// </summary>
public class PhoneNumber
{
    /// <summary>
    /// Gets the phone number value.
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PhoneNumber"/> class.
    /// </summary>
    /// <param name="value">The phone number string value.</param>
    /// <exception cref="ArgumentException">Thrown if the value is null, empty, or invalid.</exception>
    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("شماره تماس نمی‌تواند خالی باشد.");

        Value = value;
    }

    /// <summary>
    /// Returns the string representation of the phone number.
    /// </summary>
    public override string ToString() => Value;
}
