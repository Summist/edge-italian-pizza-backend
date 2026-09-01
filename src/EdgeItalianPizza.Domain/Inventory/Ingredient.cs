using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Inventory;

/// <summary>
/// Справочник ингредиентов — используется для приготовления пиццы
/// и учёта остатков на складе. Каждый ингредиент имеет название,
/// изображение и единицу измерения.
/// </summary>
public sealed class Ingredient : EntityBase
{
    /// <summary>
    /// Название ингредиента (например, «Моцарелла», «Пепперони», «Томатный соус»).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Изображение ингредиента — отображается в админке при управлении остатками.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Единица измерения — определяет, как списывать и учитывать количество.
    /// </summary>
    public IngredientUnit Unit { get; set; }
}
