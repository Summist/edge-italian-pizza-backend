namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Размер (объём) напитка — например, 0.3L, 0.5L, 1L.
/// </summary>
public sealed class DrinkSize
{
    /// <summary>
    /// Название размера (например, «0.3L», «0.5L»).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Объём в миллилитрах.
    /// </summary>
    public int VolumeMl { get; set; }

    /// <summary>
    /// Коэффициент к базовой цене: 1.0 — стандарт, 0.8 — маленький, 1.5 — большой.
    /// </summary>
    public decimal PriceModifier { get; set; }
}
