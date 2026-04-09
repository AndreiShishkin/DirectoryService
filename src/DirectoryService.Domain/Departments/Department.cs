using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;
using DirectoryService.Domain.ValueObjects;
using Path = DirectoryService.Domain.ValueObjects.Path;

namespace DirectoryService.Domain.Departments;

public class Department
{
    public Guid Id { get; }

    public DepartmentName DepartmentName { get; private set;  }

    public Identifier Identifier { get; private set; }

    public Guid? ParentId { get; private set; }

    public Path Path { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

    private Department(
        Guid? id,
        DepartmentName departmentName,
        Identifier identifier,
        Guid? parentId,
        Path path,
        short depth)
    {
        Id = id ?? Guid.NewGuid();
        DepartmentName = departmentName;
        Identifier = identifier;
        ParentId = parentId;
        Path = path;
        Depth = depth;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public static Result<Department, Error> Create(
        DepartmentName name,
        Identifier identifier,
        Guid? parentId,
        Path path,
        short depth)
    {
        return new Department(Guid.NewGuid(), name, identifier, parentId, path, depth);
    }
}