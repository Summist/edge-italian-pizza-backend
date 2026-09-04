namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Мерчandise — неfood-товары (фигурки, игрушки, сувениры).
/// Фиксированная цена, вес для расчёта доставки.
/// </summary>
public sealed class Merchandise : Product
{
    public override ProductType Type => ProductType.Merchandise;

    /// <summary>
    /// Описание товара.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Вес товара в граммах (для расчёта доставки).
    /// </summary>
    public int WeightGrams { get; set; }
}
