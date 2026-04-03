namespace DirectoryService.Domain.Shared;

#pragma warning disable CA1707
public enum ErrorType
{
    VALIDATION,
    NOT_FOUND,
    FAILURE,
    CONFLICT,
    AUTHENTICATION,
    AUTHORIZATION,
}
#pragma warning restore CA1707