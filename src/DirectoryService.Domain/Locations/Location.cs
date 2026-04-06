using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;
using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Locations;

public class Location
{
    public Guid Id { get; }

    public LocationName Name { get; }

    public Address Address { get; }

    public Timezone Timezone { get; }

    public bool IsActive { get; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }

    private Location(Guid? id, LocationName name, Address address, Timezone timezone)
    {
        Id = id ?? Guid.NewGuid();
        Name = name;
        Address = address;
        Timezone = timezone;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public static Result<Location, Error> Create(
        string name,
        string region,
        string city,
        string street,
        string house,
        string? apartment,
        string? postalCode,
        string timezone)
    {
        var locationName = LocationName.Create(Array.Empty<string>(), name);

        if (locationName.IsFailure)
        {
            return locationName.Error;
        }

        var address = Address.Create(region, city, street, house, apartment, postalCode);

        if (address.IsFailure)
        {
            return address.Error;
        }

        var locationTimezone = Timezone.Create(timezone);

        if (locationTimezone.IsFailure)
        {
            return locationTimezone.Error;
        }

        return new Location(Guid.NewGuid(), locationName.Value, address.Value, locationTimezone.Value);
    }
}