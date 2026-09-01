namespace EdgeItalianPizza.Domain.Catalog;

public sealed class Pizza : Product
{
    public override ProductType Type => ProductType.Pizza;

    /// <summary>
    /// Ингредиенты из описания пиццы. Некоторые можно исключить при заказе.
    /// </summary>
    public IReadOnlyList<PizzaIngredient> BaseIngredients { get; set; } = [];

    /// <summary>
    /// Доступные размеры — Маленькая, Средняя, Большая и т.д.
    /// </summary>
    public IReadOnlyList<PizzaSize> Sizes { get; set; } = [];
}
