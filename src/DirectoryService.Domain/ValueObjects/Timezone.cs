using System.Text.RegularExpressions;
using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record Timezone
{
    private const string TIMEZONE_REGEX = @"^[\w-]+\/[\w-]+$";
    public string Value { get; }

    private Timezone(string value)
    {
        Value = value;
    }

    public static Result<Timezone, Error> Create(string value)
    {
        Regex regex = new Regex(TIMEZONE_REGEX);
        if (!regex.IsMatch(value))
        {
            return Error.Validation(
                "timezone.validation.error",
                "Неверный формат часового пояса. Для заполнения поля используйте IANA-код",
                "timezone");
        }

        return new Timezone(value);
    }
}