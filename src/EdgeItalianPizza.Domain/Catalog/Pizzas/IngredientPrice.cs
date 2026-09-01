using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Объект-значение — стоимость дополнительного ингредиента
/// для конкретного размера и типа теста.
/// Позволяет гибко задавать стоимость — например, пепперони на большой пицце дороже, чем на маленькой.
/// </summary>
public sealed class IngredientPrice : ValueObject
{
    /// <summary>
    /// Ссылка на справочник ингредиентов — используется для синхронизации
    /// данных при изменении ингредиента.
    /// </summary>
    public Guid IngredientId { get; set; }

    /// <summary>
    /// Название ингредиента — дубль для отображения без дополнительных запросов.
    /// </summary>
    public string IngredientName { get; set; } = string.Empty;

    /// <summary>
    /// Изображение ингредиента — дубль для отображения при выборе дополнений.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Стоимость ингредиента для данного размера и типа теста.
    /// </summary>
    public decimal Price { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return IngredientId;
        yield return IngredientName;
        yield return Price;
    }
}
