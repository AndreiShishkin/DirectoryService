using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record Identifier
{
    private const string IDENTIFIER_REGEX = @"^[A-Za-z]*$";

    private const int MIN_LENGTH = 3;
    private const int MAX_LENGTH = 150;

    public string Value { get; }

    private Identifier(string value)
    {
        Value = value;
    }

    public static Result<Identifier, Error> Create(string value)
    {
        if (string.IsNullOrEmpty(value) || value.Length < MIN_LENGTH || value.Length > MAX_LENGTH)
        {
            return Error.Validation(
                "identifier.validation.error",
                "Идентификатор должно быть заполнено, размер поля от 3 до 150 символов",
                "identifier");
        }

        Regex regex = new Regex(IDENTIFIER_REGEX);
        if (!regex.IsMatch(value))
        {
            return Error.Validation(
                "identifier.validation.error",
                "Идентификатор должен состоят только из латинских букв",
                "identifier");
        }

        return new Identifier(value);
    }
}