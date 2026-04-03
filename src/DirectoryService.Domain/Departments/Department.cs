using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;
using DirectoryService.Domain.ValueObjects;
using Path = DirectoryService.Domain.ValueObjects.Path;

namespace DirectoryService.Domain.Departments;

public class Department
{
    public Guid Id { get; }

    public Name Name { get; }

    public string Identifier { get; }

    public Guid ParentId { get; }

    public Path Path { get; }

    public short Depth { get; }

    public bool IsActive { get; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }

    private Department(
        Guid? id,
        Name name,
        string identifier,
        Guid parentId,
        Path path,
        short depth)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Identifier = identifier;
        ParentId = parentId;
        Path = path;
        Depth = depth;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public static Result<Department, Error> Create(
        string nameValue,
        string identifier,
        Guid parentId,
        string pathValue,
        short depth)
    {
        var name = Name.Create(nameValue);

        if (name.Error != null)
        {
            return name.Error;
        }

        var path = Path.Create(pathValue);

        if (path.Error != null)
        {
            return path.Error;
        }

        return new Department(Guid.NewGuid(), name.Value, identifier, parentId, path.Value, depth);
    }
}