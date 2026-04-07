namespace DirectoryService.Domain.Departments;

public record DepartmentPosition
{
    public Guid Id { get; }

    public Department Department { get; private set; }

    public Guid PositionId { get; private set; }

    public DepartmentPosition(Guid? id, Department department, Guid positionId)
    {
        Id = id ?? Guid.NewGuid();
        Department = department;
        PositionId = positionId;
    }
}