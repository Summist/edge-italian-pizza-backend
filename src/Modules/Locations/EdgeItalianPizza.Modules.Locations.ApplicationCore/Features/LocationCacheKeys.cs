namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Ключи кэша для локаций.
/// </summary>
internal static class LocationCacheKeys
{
    /// <summary>
    /// Ключ для списка всех локаций.
    /// </summary>
    public const string All = "locations:all";

    /// <summary>
    /// Получить ключ для локации по ID.
    /// </summary>
    public static string ById(Guid id) => $"locations:{id}";

    /// <summary>
    /// Время жизни кэша.
    /// </summary>
    public static TimeSpan Expiry => TimeSpan.FromMinutes(5);
}
