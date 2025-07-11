using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.DTOs;
using EshopApp.Application.UseCases.InvoiceUseCases;

namespace EshopApp.API.Controllers;

/// <summary>
/// Controller for managing invoice-related operations.
/// </summary>
/// <remarks>
/// Provides endpoints to create, retrieve, search, delete, and calculate totals for invoices.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly CreateInvoiceUseCase _createInvoice;
    private readonly GetAllInvoicesUseCase _getAllInvoices;
    private readonly GetInvoiceByIdUseCase _getInvoiceById;
    private readonly SearchInvoiceUseCase _searchInvoice;
    private readonly DeleteInvoiceUseCase _deleteInvoice;
    private readonly CalculateInvoiceTotalUseCase _calculateInvoiceTotal;

    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceController"/> class.
    /// </summary>
    /// <param name="createInvoice">Use case for creating an invoice.</param>
    /// <param name="getAllInvoices">Use case for retrieving all invoices.</param>
    /// <param name="getInvoiceById">Use case for retrieving an invoice by ID.</param>
    /// <param name="searchInvoice">Use case for searching invoices by customer name.</param>
    /// <param name="deleteInvoice">Use case for deleting an invoice.</param>
    /// <param name="calculateInvoiceTotal">Use case for calculating the total of an invoice.</param>
    public InvoiceController(
        CreateInvoiceUseCase createInvoice,
        GetAllInvoicesUseCase getAllInvoices,
        GetInvoiceByIdUseCase getInvoiceById,
        SearchInvoiceUseCase searchInvoice,
        DeleteInvoiceUseCase deleteInvoice,
        CalculateInvoiceTotalUseCase calculateInvoiceTotal)
    {
        _createInvoice = createInvoice;
        _getAllInvoices = getAllInvoices;
        _getInvoiceById = getInvoiceById;
        _searchInvoice = searchInvoice;
        _deleteInvoice = deleteInvoice;
        _calculateInvoiceTotal = calculateInvoiceTotal;
    }

    /// <summary>
    /// Creates a new invoice.
    /// </summary>
    /// <param name="dto">The data transfer object containing invoice details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateInvoiceDto dto)
    {
        await _createInvoice.ExecuteAsync(dto);
        return Ok("فاکتور با موفقیت ایجاد شد.");
    }

    /// <summary>
    /// Retrieves all invoices.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the list of invoices.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var invoices = await _getAllInvoices.ExecuteAsync();
        return Ok(invoices);
    }

    /// <summary>
    /// Retrieves an invoice by its ID.
    /// </summary>
    /// <param name="id">The ID of the invoice to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> containing the invoice details.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var invoice = await _getInvoiceById.ExecuteAsync(id);
        return Ok(invoice);
    }

    /// <summary>
    /// Searches invoices by customer name.
    /// </summary>
    /// <param name="customerName">The name of the customer to search for.</param>
    /// <returns>An <see cref="IActionResult"/> containing the search results.</returns>
    [HttpGet("search")]
    public async Task<IActionResult> Search([FromQuery] string customerName)
    {
        if (string.IsNullOrWhiteSpace(customerName))
            return BadRequest("نام مشتری الزامی است.");

        var results = await _searchInvoice.ExecuteAsync(customerName);
        return Ok(results);
    }

    /// <summary>
    /// Deletes an invoice by its ID.
    /// </summary>
    /// <param name="id">The ID of the invoice to delete.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteInvoice.ExecuteAsync(id);
        return Ok("فاکتور با موفقیت حذف شد.");
    }

    /// <summary>
    /// Calculates the total amount for a specific invoice.
    /// </summary>
    /// <param name="id">The ID of the invoice.</param>
    /// <returns>An <see cref="IActionResult"/> containing the total amount.</returns>
    [HttpGet("{id}/total")]
    public async Task<IActionResult> GetTotal(Guid id)
    {
        var total = await _calculateInvoiceTotal.ExecuteAsync(id);
        return Ok(new { Total = total });
    }
}