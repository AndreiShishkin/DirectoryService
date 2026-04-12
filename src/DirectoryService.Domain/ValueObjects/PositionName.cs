using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

// В дальнейшем предполагается, что будет загружаться список с названием позиций
// и проверяться уникальность имен при создании названия позиции
public record PositionName
{
    private const int MIN_LENGTH = 3;
    private const int MAX_LENGTH = 100;
    public string Value { get; }
    private PositionName(string value)
    {
        Value = value;
    }

    public static Result<PositionName, Error> Create(IEnumerable<string> positionNames, string value)
    {
        if (positionNames.Contains(value))
        {
            return Error.Validation(
                "name.validation.error",
                "Позиция с таким именем уже существует",
                "name");
        }

        if (string.IsNullOrEmpty(value) || value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            return Error.Validation(
                "name.validation.error",
                "Имя должно быть заполнено, размер поля от 3 до 150 символов",
                "name");
        }

        return new PositionName(value);
    }
}