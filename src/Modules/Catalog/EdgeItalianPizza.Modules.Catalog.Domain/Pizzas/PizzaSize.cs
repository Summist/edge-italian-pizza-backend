using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Размер пиццы с модификатором цены и вариантами теста.
/// </summary>
public sealed class PizzaSize : ValueObject
{
    /// <summary>
    /// Название размера (например, "25 см", "30 см").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Диаметр в сантиметрах.
    /// </summary>
    public int DiameterCm { get; set; }

    /// <summary>
    /// Множитель цены (базовая цена × модификатор).
    /// </summary>
    public decimal PriceModifier { get; set; }

    /// <summary>
    /// Доступные варианты теста для данного размера.
    /// </summary>
    public List<PizzaDoughVariant> DoughVariants { get; set; } = [];

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return DiameterCm;
        yield return PriceModifier;
    }
}
