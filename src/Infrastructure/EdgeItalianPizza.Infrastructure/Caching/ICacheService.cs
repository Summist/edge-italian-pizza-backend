namespace EdgeItalianPizza.Infrastructure.Caching;

/// <summary>
/// Абстракция кэша.
/// </summary>
public interface ICacheService
{
    /// <summary>
    /// Получить значение из кэша.
    /// </summary>
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Сохранить значение в кэш.
    /// </summary>
    Task SetAsync<T>(
        string key,
        T value,
        TimeSpan? expiry = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Удалить значение из кэша.
    /// </summary>
    Task RemoveAsync(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить значение из кэша или создать и сохранить.
    /// </summary>
    Task<T?> GetOrAddAsync<T>(
        string key,
        Func<CancellationToken, Task<T>> factory,
        TimeSpan? expiry = null,
        CancellationToken cancellationToken = default);
}
