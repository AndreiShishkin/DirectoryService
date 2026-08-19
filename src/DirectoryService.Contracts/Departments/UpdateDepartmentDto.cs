namespace DirectoryService.Contracts.Departments;

public record UpdateDepartmentDto(
    string? Name,
    string? Identifier,
    Guid? ParentId,
    IEnumerable<Guid>? LocationIds,
    IEnumerable<Guid>? PositionIds,
    string? Path,
    short? Depth
);