using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Объект-значение — размер (объём) напитка.
/// Определяет цену и отображается клиенту при заказе.
/// </summary>
public sealed class DrinkSize : ValueObject
{
    /// <summary>
    /// Название размера для отображения (например, «0.3л», «0.5л»).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Объём в миллилитрах — используется для точного отображения и расчёта.
    /// </summary>
    public int VolumeMl { get; set; }

    /// <summary>
    /// Коэффициент к базовой цене напитка.
    /// 1.0 — стандартный объём, меньше — дешевле, больше — дороже.
    /// </summary>
    public decimal PriceModifier { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return VolumeMl;
        yield return PriceModifier;
    }
}
