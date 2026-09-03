namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Напиток — продукт с фиксированной ценой и вариантами объёма.
/// </summary>
public sealed class Drink : Product
{
    public override ProductType Type => ProductType.Drink;

    /// <summary>
    /// Описание напитка.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Категория напитка (кофе, чай, газировка и т.д.).
    /// </summary>
    public DrinkCategory Category { get; set; }

    /// <summary>
    /// Есть ли опция добавления льда.
    /// </summary>
    public bool HasIceOption { get; set; }

    /// <summary>
    /// Доступные размеры (объёмы) напитка.
    /// </summary>
    public List<DrinkSize> Sizes { get; set; } = [];
}
