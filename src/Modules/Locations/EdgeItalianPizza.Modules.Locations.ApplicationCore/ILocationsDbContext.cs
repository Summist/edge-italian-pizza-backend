using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore;

/// <summary>
/// Абстракция контекста БД для модуля локаций.
/// Позволяет handler'ам работать с коллекциями, не зная о конкретной реализации MongoDB.
/// </summary>
public interface ILocationsDbContext
{
    /// <summary>
    /// Коллекция точек выдачи/доставки.
    /// </summary>
    IMongoCollection<Location> Locations { get; }
}
