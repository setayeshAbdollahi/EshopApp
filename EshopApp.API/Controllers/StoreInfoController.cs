using EshopApp.Application.DTOs.StoreInfoDTOs;
using EshopApp.Application.UseCases.StoreInfoUseCases;
using Microsoft.AspNetCore.Mvc;

namespace EshopApp.API.Controllers;

/// <summary>
/// Controller for managing store information.
/// </summary>
/// <remarks>
/// Provides endpoints to retrieve and update store information.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class StoreInfoController : ControllerBase
{
    private readonly GetStoreInfoUseCase _getUseCase;
    private readonly UpdateStoreInfoUseCase _updateUseCase;

    /// <summary>
    /// Initializes a new instance of the <see cref="StoreInfoController"/> class.
    /// </summary>
    /// <param name="getUseCase">Use case for retrieving store information.</param>
    /// <param name="updateUseCase">Use case for updating store information.</param>
    public StoreInfoController(
        GetStoreInfoUseCase getUseCase,
        UpdateStoreInfoUseCase updateUseCase)
    {
        _getUseCase = getUseCase;
        _updateUseCase = updateUseCase;
    }

    /// <summary>
    /// Retrieves the store information.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> containing the store information.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _getUseCase.ExecuteAsync();
        return Ok(result);
    }

    /// <summary>
    /// Updates the store information.
    /// </summary>
    /// <param name="dto">The data transfer object containing updated store information.</param>
    /// <returns>An <see cref="IActionResult"/> indicating the result of the operation.</returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStoreInfoDto dto)
    {
        await _updateUseCase.ExecuteAsync(dto);
        return Ok(new
        {
            isSuccess = true,
            message = "اطلاعات فروشگاه با موفقیت به‌روزرسانی شد.",
            data = (object?)null
        });
    }

}