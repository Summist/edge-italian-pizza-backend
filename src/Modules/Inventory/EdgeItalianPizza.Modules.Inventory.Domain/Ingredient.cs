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
    public required string Name { get; set; }

    /// <summary>
    /// URL изображения ингредиента.
    /// </summary>
    public required string ImageUrl { get; set; }

    /// <summary>
    /// Единица измерения (штука, грамм, миллилитр).
    /// </summary>
    public IngredientUnit Unit { get; set; }
}
