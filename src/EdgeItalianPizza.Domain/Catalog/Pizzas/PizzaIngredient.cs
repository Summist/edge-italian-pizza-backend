using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Объект-значение — ингредиент пиццы в составе рецепта.
/// Связан со справочником ингредиентов для учёта остатков.
/// </summary>
public sealed class PizzaIngredient : ValueObject
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

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return IngredientId;
        yield return Name;
        yield return IsExcludable;
    }
}
