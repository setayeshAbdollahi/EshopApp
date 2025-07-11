using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using EshopApp.Persistence.Data;

namespace EshopApp.Persistence;

/// <summary>
/// Factory for creating <see cref="AppDbContext"/> instances at design time (e.g., for migrations).
/// </summary>
public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    /// <summary>
    /// Creates a new instance of <see cref="AppDbContext"/> with a predefined SQLite connection string.
    /// </summary>
    /// <param name="args">Command-line arguments.</param>
    /// <returns>A new <see cref="AppDbContext"/> instance.</returns>
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=eshop.db");

        return new AppDbContext(optionsBuilder.Options);
    }
}
