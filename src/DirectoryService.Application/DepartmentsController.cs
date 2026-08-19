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
        return Ok("department created");
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDepartmentDto request)
    {
        await Task.CompletedTask.ConfigureAwait(false);
        return Ok($"department {id} updated");
    }
}