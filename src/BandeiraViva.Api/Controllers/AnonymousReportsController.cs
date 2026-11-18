using BandeiraViva.Api.DTOs;
using BandeiraViva.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BandeiraViva.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnonymousReportsController(IAnonymousReportService service) : ControllerBase
{
    [HttpGet("beach/{beachId:int}")]
    public async Task<IActionResult> GetByBeach(int beachId, CancellationToken cancellationToken) =>
        Ok(await service.GetByBeachAsync(beachId, cancellationToken));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(
        CreateAnonymousReportDto dto, CancellationToken cancellationToken)
    {
        var report = await service.CreateAsync(dto, cancellationToken);
        if (report is null)
            return NotFound(new { message = "Praia não encontrada." });

        return Created($"/api/AnonymousReports/beach/{report.BeachId}", report);
    }
}
