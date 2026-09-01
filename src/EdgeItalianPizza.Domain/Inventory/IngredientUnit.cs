namespace EdgeItalianPizza.Domain.Inventory;

/// <summary>
/// Единица измерения ингредиента — определяет, как считать количество
/// при заказе и списании.
/// </summary>
public enum IngredientUnit : byte
{
    /// <summary>
    /// Штуки (пепперони, оливки, помидоры).
    /// </summary>
    Piece = 1,

    /// <summary>
    /// Граммы (сыр, мясо, овощи).
    /// </summary>
    Gram = 2,

    /// <summary>
    /// Миллитры (соусы, масло).
    /// </summary>
    Milliliter = 3,
}
