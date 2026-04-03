using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record Description
{
    private const int MAX_QUANTITY = 1000;
    public string Value { get; }

    private Description(string value)
    {
        Value = value;
    }

    public static Result<Description, Error> Create(string? value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return new Description(string.Empty);
        }

        if (value.Length > MAX_QUANTITY)
        {
            return Error.Validation(
                "description.validation",
                "Поле описание должно содержать не более 1000 символов",
                "description");
        }

        return new Description(value);
    }
}