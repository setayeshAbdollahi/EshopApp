using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.DTOs;
using EshopApp.Application.UseCases.CustomerUseCases;

namespace EshopApp.API.Controllers;

/// <summary>
/// Controller for managing customer-related operations.
/// </summary>
/// <remarks>
/// Provides endpoints to create, update, delete, and retrieve customers.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CreateCustomerUseCase _createCustomer;
    private readonly UpdateCustomerUseCase _updateCustomer;
    private readonly DeleteCustomerUseCase _deleteCustomer;
    private readonly GetCustomerByIdUseCase _getCustomerById;
    private readonly GetAllCustomersUseCase _getAllCustomers;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomerController"/> class.
    /// </summary>
    /// <param name="createCustomer">Use case for creating a customer.</param>
    /// <param name="updateCustomer">Use case for updating a customer.</param>
    /// <param name="deleteCustomer">Use case for deleting a customer.</param>
    /// <param name="getCustomerById">Use case for retrieving a customer by ID.</param>
    /// <param name="getAllCustomers">Use case for retrieving all customers.</param>
    public CustomerController(
        CreateCustomerUseCase createCustomer,
        UpdateCustomerUseCase updateCustomer,
        DeleteCustomerUseCase deleteCustomer,
        GetCustomerByIdUseCase getCustomerById,
        GetAllCustomersUseCase getAllCustomers)
    {
        _createCustomer = createCustomer;
        _updateCustomer = updateCustomer;
        _deleteCustomer = deleteCustomer;
        _getCustomerById = getCustomerById;
        _getAllCustomers = getAllCustomers;
    }

    /// <summary>
    /// Creates a new customer.
    /// </summary>
    /// <param name="dto">The data transfer object containing customer details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerDto dto)
    {
        await _createCustomer.ExecuteAsync(dto);
        return Ok("مشتری با موفقیت ایجاد شد.");
    }

    /// <summary>
    /// Updates an existing customer.
    /// </summary>
    /// <param name="id">The ID of the customer to update.</param>
    /// <param name="dto">The data transfer object containing updated customer details.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCustomerDto dto)
    {
        await _updateCustomer.ExecuteAsync(id, dto);
        return Ok("اطلاعات مشتری با موفقیت به‌روزرسانی شد.");
    }

    /// <summary>
    /// Deletes a customer by its ID.
    /// </summary>
    /// <param name="id">The ID of the customer to delete.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _deleteCustomer.ExecuteAsync(id);
        return Ok("مشتری با موفقیت حذف شد.");
    }

    /// <summary>
    /// Retrieves a customer by its ID.
    /// </summary>
    /// <param name="id">The ID of the customer to retrieve.</param>
    /// <returns>An <see cref="IActionResult"/> containing the customer details.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _getCustomerById.ExecuteAsync(id);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all customers.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the list of customers.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _getAllCustomers.ExecuteAsync();
        return Ok(result);
    }
}