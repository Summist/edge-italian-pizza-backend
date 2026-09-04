using EdgeItalianPizza.BuildingBlocks.Primitives;
using EdgeItalianPizza.Modules.Catalog.Domain;

namespace EdgeItalianPizza.Modules.Basket.Domain;

/// <summary>
/// Позиция в корзине — денормализованный снимок продукта на момент добавления.
/// Содержит название, картинку и цену, зафиксированные при добавлении.
/// </summary>
public sealed class BasketItem : ValueObject
{
    /// <summary>
    /// Тип продукта (пицца, напиток, соус, комбо, мерч).
    /// </summary>
    public ProductType ProductType { get; set; }

    /// <summary>
    /// Идентификатор продукта в каталоге.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Название продукта (снимок на момент добавления).
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// URL изображения (снимок на момент добавления).
    /// </summary>
    public required string ImageUrl { get; set; }

    /// <summary>
    /// Количество порций.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Название размера (для пиццы/напитка). null для соусов/мерча.
    /// </summary>
    public string? SizeName { get; set; }

    /// <summary>
    /// Тип теста (для пиццы). null для остальных типов.
    /// </summary>
    public DoughType? DoughType { get; set; }

    /// <summary>
    /// Цена за единицу на момент добавления.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Идентификаторы исключённых ингредиентов (для пиццы).
    /// </summary>
    public List<Guid> ExcludedIngredientIds { get; set; } = [];

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return ProductType;
        yield return ProductId;
        yield return Name;
        yield return SizeName;
        yield return DoughType;
        yield return ExcludedIngredientIds.OrderBy(x => x).ToList();
    }
}
