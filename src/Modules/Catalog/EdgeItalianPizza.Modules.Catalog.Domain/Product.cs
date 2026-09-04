using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Абстрактный базовый класс для всех продуктов меню.
/// </summary>
public abstract class Product : EntityBase
{
    /// <summary>
    /// URL изображения продукта.
    /// </summary>
    public required string ImageUrl { get; set; }

    /// <summary>
    /// Название продукта.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Базовая цена продукта.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Активен ли продукт в меню.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Тип продукта (пицца, напиток, соус и т.д.).
    /// </summary>
    public abstract ProductType Type { get; }

    /// <summary>
    /// Идентификаторы рекомендованных дополнений.
    /// </summary>
    public List<Guid> RecommendedAdditionIds { get; set; } = [];
}
