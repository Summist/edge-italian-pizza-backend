namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;

/// <summary>
/// Ограничения для локаций.
/// </summary>
public static class LocationConstraints
{
    /// <summary>
    /// Максимальная длина названия.
    /// </summary>
    public const int NameMaxLength = 200;

    /// <summary>
    /// Максимальная длина города.
    /// </summary>
    public const int CityMaxLength = 100;

    /// <summary>
    /// Максимальная длина адреса.
    /// </summary>
    public const int AddressMaxLength = 500;

    /// <summary>
    /// Минимальная широта.
    /// </summary>
    public const double LatitudeMin = -90;

    /// <summary>
    /// Максимальная широта.
    /// </summary>
    public const double LatitudeMax = 90;

    /// <summary>
    /// Минимальная долгота.
    /// </summary>
    public const double LongitudeMin = -180;

    /// <summary>
    /// Максимальная долгота.
    /// </summary>
    public const double LongitudeMax = 180;

    /// <summary>
    /// Минимальный радиус доставки в км.
    /// </summary>
    public const decimal DeliveryRadiusMinKm = 0;
}
