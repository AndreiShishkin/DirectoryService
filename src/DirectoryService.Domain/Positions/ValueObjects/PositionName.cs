using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;
using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Positions.ValueObjects;

// В дальнейшем предполагается, что будет загружаться список с названием позиций
// и проверяться уникальность имен при создании названия позиции
public record PositionName
{
    public string Value { get; }
    private PositionName(Name name)
    {
        Value = name.Value;
    }

    public static Result<PositionName, Error> Create(string value)
    {
        var name = Name.Create(value);
        if (name.Error != null)
        {
            return name.Error;
        }

        return new PositionName(name.Value);
    }
}