namespace EshopApp.Shared.Result;

/// <summary>
/// Represents the result of an operation, indicating success or failure and containing error information if applicable.
/// </summary>
public class Result
{
    /// <summary>
    /// Gets or sets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// Gets or sets the error message if the operation failed.
    /// </summary>
    public string? Error { get; set; }

    /// <summary>
    /// Gets or sets the validation errors if the operation failed due to validation.
    /// </summary>
    public Dictionary<string, string[]>? ValidationErrors { get; set; }

    /// <summary>
    /// Creates a successful result.
    /// </summary>
    /// <returns>A <see cref="Result"/> indicating success.</returns>
    public static Result Success() => new Result { IsSuccess = true };

    /// <summary>
    /// Creates a failed result with an error message.
    /// </summary>
    /// <param name="error">The error message.</param>
    /// <returns>A <see cref="Result"/> indicating failure with an error message.</returns>
    public static Result Failure(string error) => new Result
    {
        IsSuccess = false,
        Error = error
    };

    /// <summary>
    /// Creates a failed result with validation errors.
    /// </summary>
    /// <param name="validationErrors">The validation errors.</param>
    /// <returns>A <see cref="Result"/> indicating failure with validation errors.</returns>
    public static Result Failure(Dictionary<string, string[]> validationErrors) => new Result
    {
        IsSuccess = false,
        ValidationErrors = validationErrors
    };
}

/// <summary>
/// Represents the result of an operation that returns data, indicating success or failure and containing error information if applicable.
/// </summary>
/// <typeparam name="T">The type of data returned by the operation.</typeparam>
public class Result<T>
{
    /// <summary>
    /// Gets a value indicating whether the operation was successful.
    /// </summary>
    public bool IsSuccess { get; private set; }

    /// <summary>
    /// Gets the message associated with the result, such as an error or success message.
    /// </summary>
    public string? Message { get; private set; }

    /// <summary>
    /// Gets the data returned by the operation if successful.
    /// </summary>
    public T? Data { get; private set; }

    /// <summary>
    /// Creates a successful result with data and an optional message.
    /// </summary>
    /// <param name="data">The data returned by the operation.</param>
    /// <param name="message">An optional message.</param>
    /// <returns>A <see cref="Result{T}"/> indicating success with data.</returns>
    public static Result<T> Success(T data, string? message = null)
    {
        return new Result<T> { IsSuccess = true, Data = data, Message = message };
    }

    /// <summary>
    /// Creates a failed result with an error message.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <returns>A <see cref="Result{T}"/> indicating failure with an error message.</returns>
    public static Result<T> Failure(string message)
    {
        return new Result<T> { IsSuccess = false, Message = message };
    }
}
