namespace DirectoryService.Contracts;

public record CreateLocationDto(
    string Name,
    string Region,
    string City,
    string Street,
    string House,
    string? Apartment,
    string? PostalCode,
    string Timezone
    );