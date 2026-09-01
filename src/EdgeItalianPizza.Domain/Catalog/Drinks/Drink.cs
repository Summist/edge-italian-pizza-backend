namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Напиток — кофе, чай, газировка, соки, лимонады, милкшейки.
/// Каждый напиток имеет категорию и доступные объёмы.
/// </summary>
public sealed class Drink : Product
{
    /// <inheritdoc />
    public override ProductType Type => ProductType.Drink;

    /// <summary>
    /// Описание напитка для отображения в каталоге (состав, особенности).
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Категория напитка — определяет группу в меню (кофе, чай, газировка и т.д.).
    /// </summary>
    public DrinkCategory Category { get; set; }

    /// <summary>
    /// Есть ли опция «со льдом» при заказе этого напитка.
    /// </summary>
    public bool HasIceOption { get; set; }

    /// <summary>
    /// Доступные объёмы напитка — например, 0.3л, 0.5л, 1л.
    /// Каждый объём имеет свою цену.
    /// </summary>
    public IReadOnlyList<DrinkSize> Sizes { get; set; } = [];
}
