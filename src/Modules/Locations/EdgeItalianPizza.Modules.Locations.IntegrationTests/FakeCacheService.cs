using EdgeItalianPizza.Infrastructure.Caching;

namespace EdgeItalianPizza.Modules.Locations.IntegrationTests;

internal sealed class FakeCacheService : ICacheService
{
    private readonly Dictionary<string, string> _cache = new();

    public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue(key, out var value))
        {
            var result = System.Text.Json.JsonSerializer.Deserialize<T>(value);
            return Task.FromResult(result);
        }

        return Task.FromResult<T?>(default);
    }

    public Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken cancellationToken = default)
    {
        var serialized = System.Text.Json.JsonSerializer.Serialize(value);
        _cache[key] = serialized;
        return Task.CompletedTask;
    }

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default)
    {
        _cache.Remove(key);
        return Task.CompletedTask;
    }

    public async Task<T> GetOrAddAsync<T>(string key, Func<CancellationToken, Task<T>> factory, TimeSpan? expiry = null, CancellationToken cancellationToken = default)
    {
        if (_cache.TryGetValue(key, out var cached))
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(cached)!;
        }

        var value = await factory(cancellationToken);
        await SetAsync(key, value, expiry, cancellationToken);
        return value;
    }
}
