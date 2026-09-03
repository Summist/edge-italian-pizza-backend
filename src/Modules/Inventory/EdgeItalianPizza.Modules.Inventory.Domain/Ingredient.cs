using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Inventory.Domain;

/// <summary>
/// Справочник ингредиентов — эталонная сущность для складского учёта.
/// Отличается от Catalog.PizzaIngredient: это ссылка на реальный складской продукт.
/// </summary>
public sealed class Ingredient : EntityBase
{
    /// <summary>
    /// Название ингредиента.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// URL изображения ингредиента.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Единица измерения (штука, грамм, миллилитр).
    /// </summary>
    public IngredientUnit Unit { get; set; }
}
