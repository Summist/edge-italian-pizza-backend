using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Размер (объём) напитка с модификатором цены.
/// </summary>
public sealed class DrinkSize : ValueObject
{
    /// <summary>
    /// Название размера (например, "0.3 л", "0.5 л").
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Объём в миллилитрах.
    /// </summary>
    public int VolumeMl { get; set; }

    /// <summary>
    /// Множитель цены.
    /// </summary>
    public decimal PriceModifier { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return VolumeMl;
        yield return PriceModifier;
    }
}
