using EdgeItalianPizza.BuildingBlocks.CQRS;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Команда создания новой точки выдачи/доставки.
/// </summary>
public sealed record CreateLocationCommand(
    string Name,
    string City,
    string Address,
    double Latitude,
    double Longitude,
    decimal DeliveryRadiusKm,
    IReadOnlyList<WorkingHoursDto> WorkingHours) : ICommand<CreateLocationResult>, ILocationFields;

/// <summary>
/// DTO расписания работы.
/// </summary>
public sealed record WorkingHoursDto(
    DayOfWeek DayOfWeek,
    TimeOnly OpenTime,
    TimeOnly CloseTime);
