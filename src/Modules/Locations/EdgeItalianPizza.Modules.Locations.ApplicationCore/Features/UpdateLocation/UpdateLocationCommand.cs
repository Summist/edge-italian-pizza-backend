using EdgeItalianPizza.BuildingBlocks.CQRS;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Команда обновления точки.
/// </summary>
public sealed record UpdateLocationCommand(
    Guid LocationId,
    string Name,
    string City,
    string Address,
    double Latitude,
    double Longitude,
    decimal DeliveryRadiusKm,
    List<WorkingHoursDto> WorkingHours) : ICommand<UpdateLocationResult>, ILocationFields;
