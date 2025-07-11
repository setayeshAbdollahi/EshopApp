using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.DTOs.Product;
using EshopApp.Application.UseCases.ProductUseCases;
using EshopApp.Application.Exceptions;
using EshopApp.Shared.Result;

namespace EshopApp.API.Controllers;

/// <summary>
/// Controller for managing product-related operations.
/// </summary>
/// <remarks>
/// Provides endpoints to create, update, delete, assign, and retrieve products.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly GetAllProductsUseCase _getAllProducts;
    private readonly GetProductByIdUseCase _getProductById;
    private readonly CreateProductUseCase _createProduct;
    private readonly UpdateProductUseCase _updateProduct;
    private readonly DeleteProductUseCase _deleteProduct;
    private readonly AssignProductToCategoryUseCase _assignProduct;
    private readonly UpdateProductStockUseCase _updateProductStockUseCase;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductController"/> class.
    /// </summary>
    /// <param name="getAllProducts">Use case for retrieving all products.</param>
    /// <param name="getProductById">Use case for retrieving a product by ID.</param>
    /// <param name="createProduct">Use case for creating a product.</param>
    /// <param name="updateProduct">Use case for updating a product.</param>
    /// <param name="deleteProduct">Use case for deleting a product.</param>
    /// <param name="assignProduct">Use case for assigning a product to a category.</param>
    /// <param name="updateProductStockUseCase">Use case for updating product stock.</param>
    public ProductController(
        GetAllProductsUseCase getAllProducts,
        GetProductByIdUseCase getProductById,
        CreateProductUseCase createProduct,
        UpdateProductUseCase updateProduct,
        DeleteProductUseCase deleteProduct,
        AssignProductToCategoryUseCase assignProduct,
        UpdateProductStockUseCase updateProductStockUseCase)
    {
        _getAllProducts = getAllProducts;
        _getProductById = getProductById;
        _createProduct = createProduct;
        _updateProduct = updateProduct;
        _deleteProduct = deleteProduct;
        _assignProduct = assignProduct;
        _updateProductStockUseCase = updateProductStockUseCase;
    }

    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the list of products.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllProducts.ExecuteAsync();

        if (!result.IsSuccess)
            return NotFound(new { error = result.Message }); 
        return Ok(result.Data);
    }

    /// <summary>
    /// Retrieves a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> containing the product details.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getProductById.ExecuteAsync(id);

        if (!result.IsSuccess)
            return NotFound(new { error = result.Message }); 
        return Ok(result.Data);
    }

    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="dto">The data transfer object containing product details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
    {
        var result = await _createProduct.ExecuteAsync(dto);

        if (!result.IsSuccess)
            return BadRequest(new { error = result.Error });

        return Ok("محصول با موفقیت ایجاد شد.");
    }

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="id">The ID of the product to update.</param>
    /// <param name="dto">The data transfer object containing updated product details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateProductDto dto)
    {
        var result = await _updateProduct.ExecuteAsync(id, dto);

        if (!result.IsSuccess)
            return BadRequest(new { error = result.Error });

        return Ok("محصول با موفقیت به‌روزرسانی شد.");
    }

    /// <summary>
    /// Deletes a product by its ID.
    /// </summary>
    /// <param name="id">The ID of the product to delete.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _deleteProduct.ExecuteAsync(id);

        if (!result.IsSuccess)
            return BadRequest(new { error = result.Error });

        return Ok("محصول با موفقیت حذف شد.");
    }

    /// <summary>
    /// Assigns a product to a category.
    /// </summary>
    /// <param name="productId">The ID of the product.</param>
    /// <param name="categoryId">The ID of the category.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPut("{productId}/assign/{categoryId}")]
    public async Task<IActionResult> AssignToCategory(Guid productId, Guid categoryId)
    {
        var result = await _assignProduct.ExecuteAsync(productId, categoryId);

        if (!result.IsSuccess)
            return BadRequest(new { error = result.Error });

        return Ok("محصول به دسته‌بندی اختصاص داده شد.");
    }

    /// <summary>
    /// Updates the stock quantity of a product.
    /// </summary>
    /// <param name="dto">The data transfer object containing product ID and new stock value.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPut("UpdateStock")]
    public async Task<IActionResult> UpdateStock([FromBody] UpdateProductStockDto dto)
    {
        try
        {
            Result result = await _updateProductStockUseCase.ExecuteAsync(dto.ProductId, dto.NewStock);

            if (!result.IsSuccess)
                return BadRequest(new { error = result.Error });

            return Ok(new { message = "موجودی محصول با موفقیت به‌روز شد." });
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { error = ex.Message });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "خطایی در سرور رخ داد.", detail = ex.Message });
        }
    }
}
