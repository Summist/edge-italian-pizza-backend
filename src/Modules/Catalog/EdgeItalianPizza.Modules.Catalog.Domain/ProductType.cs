namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Тип продукта в каталоге.
/// </summary>
public enum ProductType : byte
{
    /// <summary>Пицца.</summary>
    Pizza = 1,

    /// <summary>Напиток.</summary>
    Drink = 2,

    /// <summary>Соус.</summary>
    Sauce = 3,

    /// <summary>Комбо-набор.</summary>
    Combo = 4,

    /// <summary>Мерчandise (фигурки, игрушки, сувениры).</summary>
    Merchandise = 5,
}
