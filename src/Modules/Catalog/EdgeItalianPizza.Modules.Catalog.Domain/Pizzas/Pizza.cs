namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Пицца — основной продукт каталога.
/// Содержит базовые ингредиенты и доступные размеры.
/// </summary>
public sealed class Pizza : Product
{
    public override ProductType Type => ProductType.Pizza;

    /// <summary>
    /// Базовые ингредиенты рецепта.
    /// </summary>
    public List<PizzaIngredient> BaseIngredients { get; set; } = [];

    /// <summary>
    /// Доступные размеры пиццы.
    /// </summary>
    public List<PizzaSize> Sizes { get; set; } = [];
}
