namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Размер (объём) напитка — определяет цену и отображается клиенту при заказе.
/// </summary>
public sealed class DrinkSize
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
}
