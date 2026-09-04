using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.Locations;
using DirectoryService.Domain.ValueObjects;
using FluentValidation;

namespace DirectoryService.Application.Locations;

public class LocationsService : ILocationsService
{
    private readonly IValidator<CreateLocationDto> _validator;

    public LocationsService(IValidator<CreateLocationDto> validator)
    {
        _validator = validator;
    }

    public async Task<Guid> Create(CreateLocationDto locationDto, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(locationDto);

        var validationResult = await _validator
            .ValidateAsync(locationDto, cancellationToken)
            .ConfigureAwait(false);

        var locationName = LocationName.Create([], locationDto.Name).Value;

        var locationAddress = Address.Create(
            locationDto.Region,
            locationDto.City,
            locationDto.Street,
            locationDto.House,
            locationDto.Apartment,
            locationDto.PostalCode).Value;

        var locationTimezone = Timezone.Create(locationDto.Timezone).Value;

        var location = Location.Create(locationName, locationAddress, locationTimezone);
        return location.Value.Id;
    }
}