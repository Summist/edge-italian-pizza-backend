namespace EdgeItalianPizza.Domain.Catalog;

public sealed class PizzaIngredient
{
    /// <summary>
    /// Название (например, «Моцарелла», «Пепперони»).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// true — можно убрать при заказе (снять галочку), false — обязателен.
    /// </summary>
    public bool IsExcludable { get; set; }
}
