using FluentValidation;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Валидатор команды обновления точки.
/// </summary>
public sealed class UpdateLocationCommandValidator
    : LocationCommandValidator<UpdateLocationCommand>
{
    public UpdateLocationCommandValidator()
    {
        RuleFor(x => x.LocationId)
            .NotEmpty().WithMessage("ID точки обязателен");
    }
}
