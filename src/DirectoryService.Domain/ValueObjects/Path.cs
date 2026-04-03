using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record Path
{
    public string Value { get; }

    private Path(string value)
    {
        Value = value;
    }

    public static Result<Path, Error> Create(string value)
    {
        const string PATH_REGEX = @"^[a-z]*(\.[a-z]+)*$";

        Regex regex = new(PATH_REGEX);
        if (!regex.IsMatch(value))
        {
            return Error.Validation(
                "path.validation.error",
                "Введен некорректный путь. Элементы должны быть указаны через точку,"
                + "или указать только код элемента, если он является корневым",
                "Path");
        }

        return new Path(value);
    }
}