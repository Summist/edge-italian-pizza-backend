using EdgeItalianPizza.Modules.Locations.ApplicationCore;
using EdgeItalianPizza.Modules.Locations.Persistence.MongoDb.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace EdgeItalianPizza.Modules.Locations.Persistence.MongoDb;

/// <summary>
/// Регистрация сервисов персистентности модуля локаций.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавить персистентность MongoDB для модуля локаций.
    /// </summary>
    public static IServiceCollection AddLocationPersistenceMongoDb(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<MongoDbOptions>(
            configuration.GetSection(MongoDbOptions.SectionName));

        services.AddSingleton<LocationsDbContext>();
        services.AddSingleton<ILocationsDbContext>(sp => sp.GetRequiredService<LocationsDbContext>());
        services.AddHostedService<MongoDbInitializer>();

        services.AddSingleton<IValidateOptions<MongoDbOptions>, MongoDbOptionsValidator>();

        return services;
    }
}
