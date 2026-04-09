using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;
using DirectoryService.Domain.ValueObjects;

namespace DirectoryService.Domain.Locations;

public class Location
{
    public Guid Id { get; }

    public LocationName Name { get; private set; }

    public Address Address { get; private set; }

    public Timezone Timezone { get; private set; }

    public bool IsActive { get; private set; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; private set; }

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
        LocationName name,
        Address address,
        Timezone timezone)
    {
        return new Location(Guid.NewGuid(), name, address, timezone);
    }
}