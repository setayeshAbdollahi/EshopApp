using Microsoft.AspNetCore.Mvc;
using EshopApp.Application.UseCases.ReportUseCases;
using EshopApp.Application.Exceptions;

namespace EshopApp.API.Controllers;

/// <summary>
/// Controller for generating various reports.
/// </summary>
/// <remarks>
/// Provides endpoints to generate and retrieve sales reports.
/// </remarks>
[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly GenerateSalesReportUseCase _generateSalesReportUseCase;

    /// <summary>
    /// Initializes a new instance of the <see cref="ReportController"/> class.
    /// </summary>
    /// <param name="generateSalesReportUseCase">Use case for generating sales reports.</param>
    public ReportController(GenerateSalesReportUseCase generateSalesReportUseCase)
    {
        _generateSalesReportUseCase = generateSalesReportUseCase;
    }

    /// <summary>
    /// Retrieves the sales report for a specified date range.
    /// </summary>
    /// <param name="startDate">The start date of the report period.</param>
    /// <param name="endDate">The end date of the report period.</param>
    /// <returns>An <see cref="IActionResult"/> containing the sales report or an error response.</returns>
    [HttpGet("sales")]
    public async Task<IActionResult> GetSalesReport([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        try
        {
            var report = await _generateSalesReportUseCase.ExecuteAsync(startDate, endDate);
            return Ok(report);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { Errors = ex.Errors });
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "خطای داخلی سرور", Detail = ex.Message });
        }
    }
}
