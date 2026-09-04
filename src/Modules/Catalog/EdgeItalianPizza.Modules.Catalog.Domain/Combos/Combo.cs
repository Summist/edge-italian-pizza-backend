namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Комбо-набор — составной продукт сdiscount-ом.
/// Слот-based состав: каждый слот — тип продукта + дефолтный выбор + правила замены.
/// </summary>
public sealed class Combo : Product
{
    public override ProductType Type => ProductType.Combo;

    /// <summary>
    /// Описание комбо.
    /// </summary>
    public required string Description { get; set; }

    /// <summary>
    /// Слоты комбо (состав набора).
    /// </summary>
    public List<ComboItem> Items { get; set; } = [];

    /// <summary>
    /// Процент скидки на набор.
    /// </summary>
    public decimal DiscountPercent { get; set; }
}
