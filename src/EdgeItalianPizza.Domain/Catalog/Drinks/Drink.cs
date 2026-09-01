namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Напиток — кофе, чай, газировка, соки, лимонады, милкшейки.
/// </summary>
public sealed class Drink : Product
{
    /// <inheritdoc />
    public override ProductType Type => ProductType.Drink;

    /// <summary>
    /// Описание для отображения в каталоге.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Категория напитка (кофе, чай, газировка и т.д.).
    /// </summary>
    public DrinkCategory Category { get; set; }

    /// <summary>
    /// Есть ли опция «со льдом» при заказе.
    /// </summary>
    public bool HasIceOption { get; set; }

    /// <summary>
    /// Доступные объёмы (0.3L, 0.5L, 1L).
    /// </summary>
    public IReadOnlyList<DrinkSize> Sizes { get; set; } = [];
}
