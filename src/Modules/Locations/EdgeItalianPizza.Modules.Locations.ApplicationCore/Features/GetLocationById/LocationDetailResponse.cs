namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Детальный ответ с информацией о точке.
/// </summary>
public sealed record LocationDetailResponse(
    Guid LocationId,
    string Name,
    string City,
    string Address,
    double Latitude,
    double Longitude,
    decimal DeliveryRadiusKm,
    IReadOnlyList<WorkingHoursDetailResponse> WorkingHours,
    bool IsActive);

/// <summary>
/// Ответ с расписанием работы.
/// </summary>
public sealed record WorkingHoursDetailResponse(
    DayOfWeek DayOfWeek,
    TimeOnly OpenTime,
    TimeOnly CloseTime);
