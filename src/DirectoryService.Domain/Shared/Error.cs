namespace DirectoryService.Domain.Shared;

public record Error
{
    public string Message { get; }
    public string Code { get; }
    public ErrorType ErrorType { get; }
    public string? InvalidField { get; }

    private Error(string code, string message, ErrorType errorType, string? invalidField)
    {
        Code = code;
        Message = message;
        ErrorType = errorType;
        InvalidField = invalidField;
    }

    public static Error Validation(string code, string message, string? invalidField) =>
        new(code, message, ErrorType.VALIDATION, invalidField);

    public static Error NotFound(string code, string message, string? invalidField) =>
        new(code, message, ErrorType.NOT_FOUND, invalidField);

    public static Error Failure(string code, string message, string? invalidField) =>
        new(code, message, ErrorType.FAILURE, invalidField);

    public static Error Conflict(string code, string message, string? invalidField) =>
        new(code, message, ErrorType.CONFLICT, invalidField);

    public static Error Authentication(string code, string message, string? invalidField) =>
        new(code, message, ErrorType.AUTHENTICATION, invalidField);

    public static Error Authorization(string code, string message, string? invalidField) =>
        new(code, message, ErrorType.AUTHORIZATION, invalidField);
}