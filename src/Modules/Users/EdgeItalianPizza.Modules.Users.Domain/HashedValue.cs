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
    public required string Hash { get; set; }

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
