namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Общие поля локации для валидации.
/// </summary>
public interface ILocationFields
{
    /// <summary>
    /// Название точки.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Город.
    /// </summary>
    string City { get; }

    /// <summary>
    /// Адрес.
    /// </summary>
    string Address { get; }

    /// <summary>
    /// Широта.
    /// </summary>
    double Latitude { get; }

    /// <summary>
    /// Долгота.
    /// </summary>
    double Longitude { get; }

    /// <summary>
    /// Радиус доставки в км.
    /// </summary>
    decimal DeliveryRadiusKm { get; }

    /// <summary>
    /// Расписание работы.
    /// </summary>
    IReadOnlyList<WorkingHoursDto> WorkingHours { get; }
}
