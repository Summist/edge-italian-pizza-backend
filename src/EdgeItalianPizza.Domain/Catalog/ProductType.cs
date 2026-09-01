namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Тип продукта в каталоге.
/// </summary>
public enum ProductType : byte
{
    /// <summary>
    /// Пицца.
    /// </summary>
    Pizza = 1,

    /// <summary>
    /// Напиток (кофе, чай, газировка, соки, лимонады, милкшейки).
    /// </summary>
    Drink = 2,

    /// <summary>
    /// Соус.
    /// </summary>
    Sauce = 3,

    /// <summary>
    /// Комбо-набор.
    /// </summary>
    Combo = 4,

    /// <summary>
    /// Мерчандайз — фигурки, игруки, сувениры и прочий несъедобный мерч.
    /// </summary>
    Merchandise = 5,
}
