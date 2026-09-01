namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Комбо-набор — несколько продуктов по выгодной цене.
/// Скидка — процент от суммы всех товаров в наборе.
/// </summary>
public sealed class Combo : Product
{
    public override ProductType Type => ProductType.Combo;

    /// <summary>
    /// Описание набора для отображения в каталоге.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Товары (слоты), входящие в набор.
    /// </summary>
    public IReadOnlyList<ComboItem> Items { get; set; } = [];

    /// <summary>
    /// Скидка на весь набор (в процентах, от 0 до 100).
    /// </summary>
    public decimal DiscountPercent { get; set; }
}
