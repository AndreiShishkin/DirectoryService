using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record DepartmentName
{
    private const int MIN_LENGTH = 3;
    public const int MAX_LENGTH = 150;
    public string Value { get; }

    private DepartmentName(string value)
    {
        Value = value;
    }

    public static Result<DepartmentName, Error> Create(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            return Error.Validation(
                "name.validation.error",
                "Имя должно быть заполнено, размер поля от 3 до 150 символов",
                "name");
        }

        return new DepartmentName(value);
    }
}