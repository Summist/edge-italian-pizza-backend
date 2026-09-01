namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Комбо-набор — набор продуктов по выгодной цене.
/// Клиент получает скидку на всю сумму товаров в наборе.
/// Состав набора определяется слотами (ComboItem), каждый из которых
/// описывает тип продукта и опции выбора.
/// </summary>
public sealed class Combo : Product
{
    public override ProductType Type => ProductType.Combo;

    /// <summary>
    /// Описание набора для отображения в каталоге — что входит и какая выгода.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Список слотов набора — каждый слот описывает, какой тип продукта
    /// можно подставить и какие опции доступны клиенту.
    /// </summary>
    public IReadOnlyList<ComboItem> Items { get; set; } = [];

    /// <summary>
    /// Размер скидки на весь набор в процентах (от 0 до 100).
    /// </summary>
    public decimal DiscountPercent { get; set; }
}
