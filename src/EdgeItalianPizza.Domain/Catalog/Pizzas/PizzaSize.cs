namespace EdgeItalianPizza.Domain.Catalog;

public sealed class PizzaSize
{
    /// <summary>
    /// Название размера (например, «Small», «Medium», «Large»).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Диаметр в сантиметрах.
    /// </summary>
    public int DiameterCm { get; set; }

    /// <summary>
    /// Коэффициент к базовой цене: 1.0 — стандарт, 0.8 — маленькая, 1.3 — большая.
    /// </summary>
    public decimal PriceModifier { get; set; }

    /// <summary>
    /// Варианты теста (классическое, тонкое) — у каждого своя цена и КБЖУ.
    /// </summary>
    public IReadOnlyList<PizzaDoughVariant> DoughVariants { get; set; } = [];
}
