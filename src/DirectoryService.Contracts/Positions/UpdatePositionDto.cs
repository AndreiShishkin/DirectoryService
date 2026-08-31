namespace DirectoryService.Contracts.Positions;

public record UpdatePositionDto(
    string? Name,
    string? Description
);