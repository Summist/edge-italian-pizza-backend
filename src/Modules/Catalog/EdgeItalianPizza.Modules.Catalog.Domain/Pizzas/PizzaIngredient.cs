using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Ингредиент в рецепте пиццы.
/// Связывает рецепт с referenciaльной сущностью Ingredient из модуля Inventory.
/// </summary>
public sealed class PizzaIngredient : ValueObject
{
    /// <summary>
    /// Идентификатор ингредиента в модуле Inventory.
    /// </summary>
    public Guid IngredientId { get; set; }

    /// <summary>
    /// Название ингредиента (денормализовано для отображения).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Можно ли исключить ингредиент при заказе.
    /// </summary>
    public bool IsExcludable { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return IngredientId;
        yield return Name;
        yield return IsExcludable;
    }
}
