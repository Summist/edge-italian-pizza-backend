namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Цена ингредиента для конкретного размера и теста.
/// </summary>
public sealed class IngredientPrice
{
    /// <summary>
    /// Название ингредиента — совпадает с тем, что в описании пиццы.
    /// </summary>
    public string IngredientName { get; set; } = string.Empty;

    /// <summary>
    /// Иконка ингредиента для отображения в интерфейсе заказа.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Стоимость для данного размера и типа теста.
    /// </summary>
    public decimal Price { get; set; }
}
