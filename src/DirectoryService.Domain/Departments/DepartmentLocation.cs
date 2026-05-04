namespace DirectoryService.Domain.Departments;

public record DepartmentLocation
{
    public Guid Id { get; }

    public Department Department { get; private set; }

    public Guid LocationId { get; private set; }

#pragma warning disable CS8618
    private DepartmentLocation()
    {
    }
#pragma warning restore CS8618

    public DepartmentLocation(Guid? id, Department department, Guid locationId)
    {
        Id = id ?? Guid.NewGuid();
        Department = department;
        LocationId = locationId;
    }
}