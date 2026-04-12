using CSharpFunctionalExtensions;
using DirectoryService.Domain.Shared;

namespace DirectoryService.Domain.ValueObjects;

public record Address
{
    public string Region { get; }
    public string City { get; }
    public string Street { get; }
    public string House { get; }
    public string? Apartment { get; }
    public string? PostalCode { get; }

    private Address(string region, string city, string street, string house, string? apartment, string? postalCode)
    {
        Region = region;
        City = city;
        Street = street;
        House = house;
        Apartment = apartment;
        PostalCode = postalCode;
    }

    public static Result<Address, Error> Create(
        string region,
        string city,
        string street,
        string house,
        string? apartment,
        string? postalCode)
    {
        if (string.IsNullOrEmpty(region))
        {
            return Error.Validation(
                "address.region.validation.error",
                "Регион должен быть заполнен",
                "address.region");
        }

        if (string.IsNullOrEmpty(city))
        {
            return Error.Validation(
                "address.city.validation.error",
                "Город должен быть заполнен",
                "address.city");
        }

        if (string.IsNullOrEmpty(street))
        {
            return Error.Validation(
                "address.street.validation.error",
                "Улица должена быть заполнена",
                "address.street");
        }

        if (string.IsNullOrEmpty(house))
        {
            return Error.Validation(
                "address.house.validation.error",
                "Номер дома должен быть заполнен",
                "address.house");
        }

        return new Address(region, city, street, house, apartment, postalCode);
    }
}