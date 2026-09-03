using EdgeItalianPizza.Modules.Locations.ApplicationCore;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using EdgeItalianPizza.Modules.Locations.Persistence.MongoDb.Options;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.Persistence.MongoDb;

/// <summary>
/// Контекст MongoDB для модуля локаций.
/// Предоставляет доступ к коллекциям.
/// </summary>
public sealed class LocationsDbContext : ILocationsDbContext
{
    /// <summary>
    /// Коллекция точек выдачи/доставки.
    /// </summary>
    public IMongoCollection<Location> Locations { get; }

    /// <summary>
    /// Создаёт контекст с подключением к MongoDB.
    /// </summary>
    public LocationsDbContext(IOptions<MongoDbOptions> options)
    {
        MongoInitializer.Initialize();

        var client = new MongoClient(options.Value.ConnectionString);
        var database = client.GetDatabase(options.Value.DatabaseName);
        Locations = database.GetCollection<Location>("locations");
    }
}
