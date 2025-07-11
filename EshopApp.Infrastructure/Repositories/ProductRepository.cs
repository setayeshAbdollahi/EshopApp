using EshopApp.Application.Interfaces;
using EshopApp.Domain.Entities;
using EshopApp.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using EshopApp.Application.Exceptions;

namespace EshopApp.Infrastructure.Repositories;

/// <summary>
/// Repository implementation for managing <see cref="Product"/> entities in the database.
/// </summary>
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adds a new product to the database.
    /// </summary>
    /// <param name="product">The product to add.</param>
    /// <exception cref="InternalServerException">Thrown when an error occurs while adding the product.</exception>
    public async Task AddAsync(Product product)
    {
        try
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new InternalServerException("خطا در افزودن محصول: " + ex.Message);
        }
    }

    /// <summary>
    /// Retrieves a product by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the product.</param>
    /// <returns>The product if found; otherwise, null.</returns>
    /// <exception cref="InternalServerException">Thrown when an error occurs while retrieving the product.</exception>
    public async Task<Product?> GetByIdAsync(Guid id)
    {
        try
        {
            return await _context.Products.FindAsync(id);
        }
        catch (Exception ex)
        {
            throw new InternalServerException("خطا در دریافت محصول: " + ex.Message);
        }
    }

    /// <summary>
    /// Retrieves all products from the database.
    /// </summary>
    /// <returns>A list of all products.</returns>
    /// <exception cref="InternalServerException">Thrown when an error occurs while retrieving the products.</exception>
    public async Task<List<Product>> GetAllAsync()
    {
        try
        {
            return await _context.Products.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new InternalServerException("خطا در دریافت لیست محصولات: " + ex.Message);
        }
    }

    /// <summary>
    /// Updates an existing product in the database.
    /// </summary>
    /// <param name="product">The product to update.</param>
    /// <exception cref="NotFoundException">Thrown when the product is not found.</exception>
    /// <exception cref="InternalServerException">Thrown when an error occurs while updating the product.</exception>
    public async Task UpdateAsync(Product product)
    {
        try
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);

            if (existingProduct == null)
                throw new NotFoundException("محصول مورد نظر یافت نشد.");

            // Update fields
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.Description = product.Description;
            existingProduct.CategoryId = product.CategoryId;

            await _context.SaveChangesAsync();
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InternalServerException("خطا در بروزرسانی محصول: " + ex.Message);
        }
    }

    /// <summary>
    /// Deletes a product from the database.
    /// </summary>
    /// <param name="product">The product to delete.</param>
    /// <exception cref="NotFoundException">Thrown when the product is not found.</exception>
    /// <exception cref="InternalServerException">Thrown when an error occurs while deleting the product.</exception>
    public async Task DeleteAsync(Product product)
    {
        try
        {
            var existingProduct = await _context.Products.FindAsync(product.Id);

            if (existingProduct == null)
                throw new NotFoundException("محصول مورد نظر برای حذف یافت نشد.");

            _context.Products.Remove(existingProduct);
            await _context.SaveChangesAsync();
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InternalServerException("خطا در حذف محصول: " + ex.Message);
        }
    }

    /// <summary>
    /// Updates the stock quantity of a product.
    /// </summary>
    /// <param name="productId">The unique identifier of the product.</param>
    /// <param name="newStock">The new stock quantity to set.</param>
    /// <exception cref="ValidationException">Thrown when the new stock is negative.</exception>
    /// <exception cref="NotFoundException">Thrown when the product is not found.</exception>
    /// <exception cref="InternalServerException">Thrown when an error occurs while updating the stock.</exception>
    public async Task UpdateStockAsync(Guid productId, int newStock)
    {
        try
        {
            if (newStock < 0)
            {
                throw new ValidationException(new Dictionary<string, string[]>
                {
                    { "Stock", new[] { "موجودی نمی‌تواند منفی باشد." } }
                });
            }

            var product = await _context.Products.FindAsync(productId);

            if (product == null)
                throw new NotFoundException("محصول مورد نظر برای بروزرسانی موجودی یافت نشد.");

            product.Stock = newStock;

            await _context.SaveChangesAsync();
        }
        catch (ValidationException)
        {
            throw;
        }
        catch (NotFoundException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new InternalServerException("خطا در بروزرسانی موجودی محصول: " + ex.Message);
        }
    }
}
