namespace DirectoryService.Domain.Departments;

public record DepartmentLocation
{
    public Guid Id { get; }

    public Department Department { get; private set; }

    public Guid LocationId { get; private set; }

    public DepartmentLocation(Guid? id, Department department, Guid locationId)
    {
        Id = id ?? Guid.NewGuid();
        Department = department;
        LocationId = locationId;
    }
}