using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using FluentValidation;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Базовый валидатор с общими правилами для команд локаций.
/// </summary>
public abstract class LocationCommandValidator<T> : AbstractValidator<T>
    where T : ILocationFields
{
    protected LocationCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Название обязательно")
            .MaximumLength(LocationConstraints.NameMaxLength)
            .WithMessage($"Название не должно превышать {LocationConstraints.NameMaxLength} символов");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("Город обязателен")
            .MaximumLength(LocationConstraints.CityMaxLength)
            .WithMessage($"Город не должен превышать {LocationConstraints.CityMaxLength} символов");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Адрес обязателен")
            .MaximumLength(LocationConstraints.AddressMaxLength)
            .WithMessage($"Адрес не должен превышать {LocationConstraints.AddressMaxLength} символов");

        RuleFor(x => x.Latitude)
            .InclusiveBetween(LocationConstraints.LatitudeMin, LocationConstraints.LatitudeMax)
            .WithMessage($"Широта должна быть от {LocationConstraints.LatitudeMin} до {LocationConstraints.LatitudeMax}");

        RuleFor(x => x.Longitude)
            .InclusiveBetween(LocationConstraints.LongitudeMin, LocationConstraints.LongitudeMax)
            .WithMessage($"Долгота должна быть от {LocationConstraints.LongitudeMin} до {LocationConstraints.LongitudeMax}");

        RuleFor(x => x.DeliveryRadiusKm)
            .GreaterThan(LocationConstraints.DeliveryRadiusMinKm)
            .WithMessage($"Радиус доставки должен быть больше {LocationConstraints.DeliveryRadiusMinKm} км");

        RuleFor(x => x.WorkingHours)
            .NotEmpty().WithMessage("Расписание работы обязательно");
    }
}
