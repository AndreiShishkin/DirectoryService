using DirectoryService.Application.Locations;
using DirectoryService.Contracts.Locations;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presenters.Locations;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    private readonly ILocationsService _locationsService;

    public LocationsController(ILocationsService locationsService)
    {
        _locationsService = locationsService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocationDto request, CancellationToken cancellationToken)
    {
        var locationId = await _locationsService.Create(request, cancellationToken).ConfigureAwait(true);
        return Ok(locationId);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLocationDto request,
        CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok(Array.Empty<object>());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return NoContent();
    }
}