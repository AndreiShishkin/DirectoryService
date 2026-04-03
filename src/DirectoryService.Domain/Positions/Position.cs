using CSharpFunctionalExtensions;
using DirectoryService.Domain.Positions.ValueObjects;
using DirectoryService.Domain.Shared;
using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Positions;

public class Position
{
    public Guid Id { get; }

    public PositionName Name { get; }

    public Description Description { get; }

    public bool IsActive { get; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }

    private Position(Guid? id, PositionName name, Description description)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Description = description;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Position, Error> Create(string nameValue, string descriptionValue)
    {
        var name = PositionName.Create(nameValue);

        if (name.Error != null)
        {
            return name.Error;
        }

        var description = Description.Create(descriptionValue);

        if (description.Error != null)
        {
            return description.Error;
        }

        return new Position(Guid.NewGuid(), name.Value, description.Value);
    }
}