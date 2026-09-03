namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Ответ со списком точек.
/// </summary>
public sealed record LocationResponse(
    Guid LocationId,
    string Name,
    string City,
    string Address,
    double Latitude,
    double Longitude,
    decimal DeliveryRadiusKm,
    IReadOnlyList<WorkingHoursResponse> WorkingHours,
    bool IsActive);

/// <summary>
/// Ответ с расписанием работы.
/// </summary>
public sealed record WorkingHoursResponse(
    DayOfWeek DayOfWeek,
    TimeOnly OpenTime,
    TimeOnly CloseTime);
