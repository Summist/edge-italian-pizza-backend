using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Users;

/// <summary>
/// Объект-значение для хранения хеша с указанием версии алгоритма хеширования.
/// Позволяет менять алгоритм без миграции всех данных — проверка идёт
/// по версии, а при смене алгоритма старые хеши пересчитываются при повторном входе.
/// </summary>
public sealed class HashedValue : ValueObject
{
    /// <summary>
    /// Хеш значения (пароля, токена и т.д.).
    /// </summary>
    public string Hash { get; set; } = string.Empty;

    /// <summary>
    /// Версия алгоритма хеширования — позволяет менять алгоритм
    /// без миграции всех хешей.
    /// </summary>
    public byte Version { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Hash;
        yield return Version;
    }
}
