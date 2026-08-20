using DirectoryService.Contracts.Departments;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Application;

[ApiController]
[Route("[controller]")]
public class DepartmentsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDepartmentDto request)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDepartmentDto request)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok(Array.Empty<object>());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return NotFound();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok();
    }
}