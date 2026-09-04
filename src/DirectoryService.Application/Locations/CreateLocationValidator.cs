using DirectoryService.Contracts.Locations;
using DirectoryService.Domain.ValueObjects;
using FluentValidation;

namespace DirectoryService.Application.Locations;

public class CreateLocationValidator : AbstractValidator<CreateLocationDto>
{
    public CreateLocationValidator()
    {
        RuleFor(l => l.Name)
            .NotEmpty()
            .Length(LocationName.MIN_LENGTH, LocationName.MAX_LENGTH)
            .WithMessage("Имя должно быть заполнено, размер поля от 3 до 150 символов");
        RuleFor(l => l.Region)
            .NotEmpty()
            .WithMessage("Регион должен быть заполнен");
        RuleFor(l => l.City)
            .NotEmpty()
            .WithMessage("Город должен быть заполнен");
        RuleFor(l => l.Street)
            .NotEmpty()
            .WithMessage("Улица должена быть заполнена");
        RuleFor(l => l.House)
            .NotEmpty()
            .WithMessage("Номер дома должен быть заполнен");
    }
}