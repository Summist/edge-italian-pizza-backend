namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Категория напитка.
/// </summary>
public enum DrinkCategory : byte
{
    /// <summary>Кофе.</summary>
    Coffee = 1,

    /// <summary>Чай.</summary>
    Tea = 2,

    /// <summary>Газировка.</summary>
    Carbonated = 3,

    /// <summary>Сок.</summary>
    Juice = 4,

    /// <summary>Лимонад.</summary>
    Lemonade = 5,

    /// <summary>Молочный коктейль.</summary>
    Milkshake = 6
}
