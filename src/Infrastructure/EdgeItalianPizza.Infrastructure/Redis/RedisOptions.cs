namespace EdgeItalianPizza.Infrastructure.Redis;

/// <summary>
/// Конфигурация Redis.
/// </summary>
public sealed class RedisOptions
{
    /// <summary>
    /// Имя секции в конфигурации.
    /// </summary>
    public const string SectionName = "Redis";

    /// <summary>
    /// Строка подключения к Redis.
    /// </summary>
    public required string ConnectionString { get; init; }
}
