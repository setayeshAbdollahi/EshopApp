using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.DTOs;
using EshopApp.Application.UseCases.InvoiceItemUseCases;

namespace EshopApp.API.Controllers;

/// <summary>
/// Controller for managing invoice item-related operations.
/// </summary>
/// <remarks>
/// Provides endpoints to create, retrieve, update, and delete invoice items.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class InvoiceItemController : ControllerBase
{
    private readonly AddInvoiceItemUseCase _create;
    private readonly GetInvoiceItemsByInvoiceIdUseCase _getAll;
    private readonly GetInvoiceItemByIdUseCase _getById;
    private readonly UpdateInvoiceItemUseCase _update;
    private readonly DeleteInvoiceItemUseCase _delete;

    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceItemController"/> class.
    /// </summary>
    /// <param name="create">Use case for adding an invoice item.</param>
    /// <param name="getAll">Use case for retrieving invoice items by invoice ID.</param>
    /// <param name="getById">Use case for retrieving an invoice item by ID.</param>
    /// <param name="update">Use case for updating an invoice item.</param>
    /// <param name="delete">Use case for deleting an invoice item.</param>
    public InvoiceItemController(
        AddInvoiceItemUseCase create,
        GetInvoiceItemsByInvoiceIdUseCase getAll,
        GetInvoiceItemByIdUseCase getById,
        UpdateInvoiceItemUseCase update,
        DeleteInvoiceItemUseCase delete)
    {
        _create = create;
        _getAll = getAll;
        _getById = getById;
        _update = update;
        _delete = delete;
    }

    /// <summary>
    /// Creates a new invoice item for a specific invoice.
    /// </summary>
    /// <param name="invoiceId">The ID of the invoice.</param>
    /// <param name="dto">The data transfer object containing invoice item details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPost("{invoiceId}")]
    public async Task<IActionResult> Create(Guid invoiceId, [FromBody] CreateInvoiceItemDto dto)
    {
        await _create.ExecuteAsync(invoiceId, dto);
        return Ok("آیتم فاکتور با موفقیت ایجاد شد.");
    }

    /// <summary>
    /// Retrieves all invoice items for a specific invoice.
    /// </summary>
    /// <param name="invoiceId">The ID of the invoice.</param>
    /// <returns>An <see cref="IActionResult"/> containing the list of invoice items.</returns>
    [HttpGet("invoice/{invoiceId}")]
    public async Task<IActionResult> GetAllByInvoiceId(Guid invoiceId)
    {
        var items = await _getAll.ExecuteAsync(invoiceId);
        return Ok(items);
    }

    /// <summary>
    /// Retrieves an invoice item by its ID.
    /// </summary>
    /// <param name="id">The ID of the invoice item to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> containing the invoice item details.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var item = await _getById.ExecuteAsync(id);
        return Ok(item);
    }

    /// <summary>
    /// Updates an existing invoice item.
    /// </summary>
    /// <param name="id">The ID of the invoice item to update.</param>
    /// <param name="dto">The data transfer object containing updated invoice item details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateInvoiceItemDto dto)
    {
        await _update.ExecuteAsync(id, dto.Quantity, dto.UnitPrice);
        return Ok("آیتم فاکتور با موفقیت به‌روزرسانی شد.");
    }

    /// <summary>
    /// Deletes an invoice item by its ID.
    /// </summary>
    /// <param name="id">The ID of the invoice item to delete.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _delete.ExecuteAsync(id);
        return Ok("آیتم فاکتور با موفقیت حذف شد.");
    }
}
