namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Стоимость дополнительного ингредиента для конкретного размера и типа теста.
/// Позволяет гибко задавать стоимость — например, пепперони на большой пицце дороже, чем на маленькой.
/// </summary>
public sealed class IngredientPrice
{
    /// <summary>
    /// Название ингредиента — совпадает с названием в составе пиццы.
    /// </summary>
    public string IngredientName { get; set; } = string.Empty;

    /// <summary>
    /// Изображение ингредиента для отображения при выборе дополнений.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Стоимость ингредиента для данного размера и типа теста.
    /// </summary>
    public decimal Price { get; set; }
}
