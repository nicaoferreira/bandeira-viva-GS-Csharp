using BandeiraViva.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BandeiraViva.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeachesController(IBeachService service) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken) =>
        Ok(await service.GetAllAsync(cancellationToken));

    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var beach = await service.GetByIdAsync(id, cancellationToken);
        return beach is null ? NotFound(new { message = "Praia não encontrada." }) : Ok(beach);
    }
}
