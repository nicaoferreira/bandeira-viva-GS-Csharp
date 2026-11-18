using BandeiraViva.Api.DTOs;
using BandeiraViva.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BandeiraViva.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WaterReadingsController(IWaterReadingService service) : ControllerBase
{
    [HttpGet("beach/{beachId:int}")]
    public async Task<IActionResult> GetByBeach(int beachId, CancellationToken cancellationToken) =>
        Ok(await service.GetByBeachAsync(beachId, cancellationToken));

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create(
        CreateWaterReadingDto dto, CancellationToken cancellationToken)
    {
        var reading = await service.CreateAsync(dto, cancellationToken);
        if (reading is null)
            return NotFound(new { message = "Praia não encontrada." });

        return CreatedAtAction(nameof(GetByBeach),
            new { beachId = reading.BeachId }, reading);
    }
}
