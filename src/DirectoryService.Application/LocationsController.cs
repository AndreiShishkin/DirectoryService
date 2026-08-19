using CSharpFunctionalExtensions;
using DirectoryService.Contracts.Locations;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Application;

[ApiController]
[Route("[controller]")]
public class LocationsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocationDto request)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok("Location created");
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLocationDto request)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok($"Location {id} updated");
    }
}