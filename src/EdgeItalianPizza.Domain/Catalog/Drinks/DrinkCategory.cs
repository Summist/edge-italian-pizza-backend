namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Категория напитка — определяет группу в меню и помогает клиенту
/// быстро найти нужный тип напитка.
/// </summary>
public enum DrinkCategory : byte
{
    /// <summary>
    /// Кофе, какао, горячий шоколад.
    /// </summary>
    Coffee = 1,

    /// <summary>
    /// Чёрный, зелёный, травяной чай.
    /// </summary>
    Tea = 2,

    /// <summary>
    /// Кола, спрайт, газированные воды.
    /// </summary>
    Carbonated = 3,

    /// <summary>
    /// Фруктовые и овощные соки.
    /// </summary>
    Juice = 4,

    /// <summary>
    /// Лимонады, морсы, квас.
    /// </summary>
    Lemonade = 5,

    /// <summary>
    /// Милкшейки, смузи.
    /// </summary>
    Milkshake = 6,
}
