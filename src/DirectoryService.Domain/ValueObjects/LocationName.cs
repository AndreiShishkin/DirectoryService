using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record LocationName
{
    private const int MIN_LENGTH = 3;
    private const int MAX_LENGTH = 120;
    public string Value { get; }

    private LocationName(string value)
    {
        Value = value;
    }

    public static Result<LocationName, Error> Create(IEnumerable<string> positionNames, string value)
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

        return new LocationName(value);
    }
}