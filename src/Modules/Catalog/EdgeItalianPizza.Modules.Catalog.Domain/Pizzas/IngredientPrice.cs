using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Стоимость дополнительного ингредиента для конкретного размера и теста.
/// </summary>
public sealed class IngredientPrice : ValueObject
{
    /// <summary>
    /// Идентификатор ингредиента в модуле Inventory.
    /// </summary>
    public Guid IngredientId { get; set; }

    /// <summary>
    /// Название ингредиента (денормализовано).
    /// </summary>
    public required string IngredientName { get; set; }

    /// <summary>
    /// URL изображения ингредиента.
    /// </summary>
    public required string ImageUrl { get; set; }

    /// <summary>
    /// Стоимость добавления.
    /// </summary>
    public decimal Price { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return IngredientId;
        yield return IngredientName;
        yield return Price;
    }
}
