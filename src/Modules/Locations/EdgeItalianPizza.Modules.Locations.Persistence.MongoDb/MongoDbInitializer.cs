using EdgeItalianPizza.Modules.Locations.ApplicationCore;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.Persistence.MongoDb;

/// <summary>
/// Инициализатор MongoDB — создание индексов при запуске приложения.
/// </summary>
public sealed class MongoDbInitializer : IHostedService
{
    private readonly ILocationsDbContext _dbContext;

    /// <summary>
    /// Создаёт инициализатор MongoDB.
    /// </summary>
    public MongoDbInitializer(ILocationsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Создаёт индексы при запуске приложения.
    /// </summary>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await CreateIndexesAsync(cancellationToken);
    }

    /// <summary>
    /// Ничего не делает при остановке — индексы переживают перезапуск приложения
    /// и хранятся в MongoDB независимо от lifetime процесса.
    /// Cleanup не требуется, так как здесь нет ресурсов, требующих освобождения
    /// (TCP-соединения, фоновые потоки, буферы).
    /// </summary>
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    private async Task CreateIndexesAsync(CancellationToken cancellationToken)
    {
        // Индекс по городу для фильтрации
        var cityIndexKeys = Builders<Location>.IndexKeys.Ascending(x => x.City);
        var cityIndexModel = new CreateIndexModel<Location>(cityIndexKeys);
        await _dbContext.Locations.Indexes.CreateOneAsync(cityIndexModel, cancellationToken: cancellationToken);

        // Индекс по активности для быстрого поиска активных точек
        var activeIndexKeys = Builders<Location>.IndexKeys.Ascending(x => x.IsActive);
        var activeIndexModel = new CreateIndexModel<Location>(activeIndexKeys);
        await _dbContext.Locations.Indexes.CreateOneAsync(activeIndexModel, cancellationToken: cancellationToken);

        // Составной индекс по городу и активности
        var cityActiveKeys = Builders<Location>.IndexKeys
            .Ascending(x => x.City)
            .Ascending(x => x.IsActive);
        var cityActiveIndexModel = new CreateIndexModel<Location>(cityActiveKeys);
        await _dbContext.Locations.Indexes.CreateOneAsync(cityActiveIndexModel, cancellationToken: cancellationToken);
    }
}
