namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Ингредиент пиццы — описывает составляющую часть рецепта.
/// Связан со справочником ингредиентов для учёта остатков.
/// </summary>
public sealed class PizzaIngredient
{
    /// <summary>
    /// Ссылка на справочник ингредиентов.
    /// </summary>
    public Guid IngredientId { get; set; }

    /// <summary>
    /// Название ингредиента — отображается клиенту (например, «Моцарелла», «Пепперони»).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Можно ли исключить ингредиент при заказе.
    /// true — клиент может снять галочку, false — ингредиент обязателен.
    /// </summary>
    public bool IsExcludable { get; set; }
}
