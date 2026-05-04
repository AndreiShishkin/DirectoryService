using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;
using DirectoryService.Domain.ValueObjects;
using Path = DirectoryService.Domain.ValueObjects.Path;

namespace DirectoryService.Domain.Departments;

public class Department
{
    private List<DepartmentLocation> _locations;
    private List<DepartmentPosition> _positions;

    public Guid Id { get; }

    public DepartmentName DepartmentName { get; private set; }

    public Identifier Identifier { get; private set; }

    public Guid? ParentId { get; private set; }

    public IReadOnlyList<DepartmentLocation> Locations => _locations;

    public IReadOnlyList<DepartmentPosition> Positions => _positions;

    public Path Path { get; private set; }

    public short Depth { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

    #pragma warning disable CS8618
    private Department()
    {
    }
    #pragma warning restore CS8618

    private Department(
        Guid? id,
        DepartmentName departmentName,
        Identifier identifier,
        Guid? parentId,
        IEnumerable<Guid> locationIds,
        IEnumerable<Guid> positionIds,
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

        var departmentLocations = locationIds.Select(locationId =>
                new DepartmentLocation(Guid.NewGuid(), this, locationId))
            .ToList();
        _locations = departmentLocations;

        var departmentPositions = positionIds.Select(positionId =>
                new DepartmentPosition(Guid.NewGuid(), this, positionId))
            .ToList();
        _positions = departmentPositions;
    }

    public static Result<Department, Error> Create(
        DepartmentName name,
        Identifier identifier,
        Guid? parentId,
        IEnumerable<Guid> locationIds,
        IEnumerable<Guid> positionIds,
        Path path,
        short depth)
    {
        return new Department(Guid.NewGuid(), name, identifier, parentId, locationIds, positionIds, path, depth);
    }
}