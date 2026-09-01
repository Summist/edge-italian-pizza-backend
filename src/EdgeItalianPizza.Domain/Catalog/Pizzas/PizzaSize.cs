using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Объект-значение — размер пиццы.
/// Определяет диаметр, ценовой коэффициент
/// и набор вариантов теста с КБЖУ для этого размера.
/// </summary>
public sealed class PizzaSize : ValueObject
{
    /// <summary>
    /// Название размера для отображения клиенту (например, «Small», «Medium», «Large»).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Диаметр пиццы в сантиметрах.
    /// </summary>
    public int DiameterCm { get; set; }

    /// <summary>
    /// Коэффициент к базовой цене продукта.
    /// 1.0 — стандартный размер, меньше — дешевле, больше — дороже.
    /// </summary>
    public decimal PriceModifier { get; set; }

    /// <summary>
    /// Варианты теста для данного размера — у каждого свой тип,
    /// стоимость дополнительных ингредиентов и пищевая ценность.
    /// </summary>
    public IReadOnlyList<PizzaDoughVariant> DoughVariants { get; set; } = [];

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return DiameterCm;
        yield return PriceModifier;
    }
}
