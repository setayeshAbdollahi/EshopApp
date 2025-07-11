using System.Globalization;

namespace EshopApp.Shared.Helpers;

/// <summary>
/// Provides helper methods for date operations, including Persian date formatting and date range validation.
/// </summary>
public static class DateHelper
{
    /// <summary>
    /// Converts a <see cref="DateTime"/> to a Persian date string in the format yyyy/MM/dd.
    /// </summary>
    /// <param name="date">The date to convert.</param>
    /// <returns>A string representing the date in Persian calendar format.</returns>
    public static string ToPersianDate(this DateTime date)
    {
        var pc = new PersianCalendar();
        return $"{pc.GetYear(date)}/{pc.GetMonth(date):00}/{pc.GetDayOfMonth(date):00}";
    }

    /// <summary>
    /// Determines whether the specified start date is less than or equal to the end date.
    /// </summary>
    /// <param name="startDate">The start date.</param>
    /// <param name="endDate">The end date.</param>
    /// <returns><c>true</c> if the start date is less than or equal to the end date; otherwise, <c>false</c>.</returns>
    public static bool IsValidDateRange(DateTime startDate, DateTime endDate)
    {
        return startDate <= endDate;
    }
}
