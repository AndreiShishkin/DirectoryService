using DirectoryService.Contracts.Positions;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Application;

[ApiController]
[Route("[controller]")]
public class PositionsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePosotionDto request)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok("Position created");
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdatePositionDto request)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok($"Position {id} updated");
    }
}