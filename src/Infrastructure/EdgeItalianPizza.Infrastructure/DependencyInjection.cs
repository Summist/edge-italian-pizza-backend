using EdgeItalianPizza.Infrastructure.Caching;
using EdgeItalianPizza.Infrastructure.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EdgeItalianPizza.Infrastructure;

/// <summary>
/// Регистрация инфраструктуры в DI.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавить инфраструктуру (Redis кэш).
    /// </summary>
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<RedisOptions>(configuration.GetSection(RedisOptions.SectionName));

        services.AddStackExchangeRedisCache(options =>
        {
            var redisOptions = configuration
                .GetSection(RedisOptions.SectionName)
                .Get<RedisOptions>()!;

            options.Configuration = redisOptions.ConnectionString;
        });

        services.AddSingleton<ICacheService, RedisCacheService>();

        return services;
    }
}
