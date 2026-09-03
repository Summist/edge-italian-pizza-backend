using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Users.Domain;

/// <summary>
/// Хеш с версией алгоритма.
/// Позволяет мигрировать на новый алгоритм хеширования без массовой перехешировки.
/// </summary>
public sealed class HashedValue : ValueObject
{
    /// <summary>
    /// Захешированное значение.
    /// </summary>
    public string Hash { get; set; } = string.Empty;

    /// <summary>
    /// Версия алгоритма хеширования.
    /// </summary>
    public byte Version { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Hash;
        yield return Version;
    }
}
