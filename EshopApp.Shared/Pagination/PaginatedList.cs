namespace EshopApp.Shared.Pagination;

/// <summary>
/// Represents a paginated list of items with pagination metadata.
/// </summary>
/// <typeparam name="T">The type of items in the list.</typeparam>
public class PaginatedList<T>
{
    /// <summary>
    /// Gets the items on the current page.
    /// </summary>
    public List<T> Items { get; private set; } = new();

    /// <summary>
    /// Gets the current page index (1-based).
    /// </summary>
    public int PageIndex { get; private set; }

    /// <summary>
    /// Gets the total number of pages.
    /// </summary>
    public int TotalPages { get; private set; }

    /// <summary>
    /// Gets the total number of items across all pages.
    /// </summary>
    public int TotalCount { get; private set; }

    /// <summary>
    /// Gets a value indicating whether there is a previous page.
    /// </summary>
    public bool HasPreviousPage => PageIndex > 1;

    /// <summary>
    /// Gets a value indicating whether there is a next page.
    /// </summary>
    public bool HasNextPage => PageIndex < TotalPages;

    /// <summary>
    /// Initializes a new instance of the <see cref="PaginatedList{T}"/> class.
    /// </summary>
    /// <param name="items">The items on the current page.</param>
    /// <param name="count">The total number of items.</param>
    /// <param name="pageIndex">The current page index (1-based).</param>
    /// <param name="pageSize">The number of items per page.</param>
    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        Items = items;
        TotalCount = count;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)pageSize);
    }

    /// <summary>
    /// Creates a new <see cref="PaginatedList{T}"/> from the given source list, page index, and page size.
    /// </summary>
    /// <param name="source">The source list of items.</param>
    /// <param name="pageIndex">The current page index (1-based).</param>
    /// <param name="pageSize">The number of items per page.</param>
    /// <returns>A paginated list containing the items for the specified page.</returns>
    public static PaginatedList<T> Create(List<T> source, int pageIndex, int pageSize)
    {
        var count = source.Count;
        var items = source
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        return new PaginatedList<T>(items, count, pageIndex, pageSize);
    }
}
