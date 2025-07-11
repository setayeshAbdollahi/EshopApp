using EshopApp.Application.DTOs.CategoryDTOs;
using EshopApp.Application.UseCases.CategoryUseCases;
using Microsoft.AspNetCore.Mvc;

namespace EshopApp.API.Controllers;

/// <summary>
/// Controller for managing category-related operations.
/// </summary>
/// <remarks>
/// Provides endpoints to create, update, delete, and retrieve categories.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly CreateCategoryUseCase _createCategoryUseCase;
    private readonly UpdateCategoryUseCase _updateCategoryUseCase;
    private readonly DeleteCategoryUseCase _deleteCategoryUseCase;
    private readonly GetAllCategoriesUseCase _getAllCategoriesUseCase;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryController"/> class.
    /// </summary>
    /// <param name="createCategoryUseCase">Use case for creating a category.</param>
    /// <param name="updateCategoryUseCase">Use case for updating a category.</param>
    /// <param name="deleteCategoryUseCase">Use case for deleting a category.</param>
    /// <param name="getAllCategoriesUseCase">Use case for retrieving all categories.</param>
    public CategoryController(
        CreateCategoryUseCase createCategoryUseCase,
        UpdateCategoryUseCase updateCategoryUseCase,
        DeleteCategoryUseCase deleteCategoryUseCase,
        GetAllCategoriesUseCase getAllCategoriesUseCase)
    {
        _createCategoryUseCase = createCategoryUseCase;
        _updateCategoryUseCase = updateCategoryUseCase;
        _deleteCategoryUseCase = deleteCategoryUseCase;
        _getAllCategoriesUseCase = getAllCategoriesUseCase;
    }

    /// <summary>
    /// Creates a new category.
    /// </summary>
    /// <param name="dto">The data transfer object containing category details.</param>
    /// <param name="parentId">Optional parent category ID.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto dto, [FromQuery] Guid? parentId)
    {
        await _createCategoryUseCase.ExecuteAsync(dto, parentId);
        return Ok(new { message = "دسته با موفقیت ایجاد شد." });
    }

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="id">The ID of the category to update.</param>
    /// <param name="dto">The data transfer object containing updated category details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryDto dto)
    {
        await _updateCategoryUseCase.ExecuteAsync(id, dto);
        return Ok(new { message = "دسته با موفقیت ویرایش شد." });
    }

    /// <summary>
    /// Deletes a category by its ID.
    /// </summary>
    /// <param name="id">The ID of the category to delete.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteCategoryUseCase.ExecuteAsync(id);
        return Ok(new { message = "دسته با موفقیت حذف شد." });
    }

    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the list of categories.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllCategoriesUseCase.ExecuteAsync();
        return Ok(result);
    }

}