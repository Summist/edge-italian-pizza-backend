namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Пицца — основной продукт каталога. Имеет набор ингредиентов,
/// доступные размеры и варианты теста для каждого размера.
/// </summary>
public sealed class Pizza : Product
{
    public override ProductType Type => ProductType.Pizza;

    /// <summary>
    /// Список ингредиентов в составе пиццы.
    /// Некоторые из них клиент может исключить при заказе.
    /// </summary>
    public IReadOnlyList<PizzaIngredient> BaseIngredients { get; set; } = [];

    /// <summary>
    /// Доступные размеры пиццы — Маленькая, Средняя, Большая и т.д.
    /// Каждый размер имеет свой диаметр, набор теста и цену.
    /// </summary>
    public IReadOnlyList<PizzaSize> Sizes { get; set; } = [];
}
