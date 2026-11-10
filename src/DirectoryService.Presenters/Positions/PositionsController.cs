using DirectoryService.Contracts.Positions;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Presenters.Positions;

[ApiController]
[Route("[controller]")]
public class PositionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePositionDto request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok(Guid.NewGuid());
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdatePositionDto request, CancellationToken cancellationToken)
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