using EdgeItalianPizza.Domain.Catalog;
using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Basket;

/// <summary>
/// Объект-значение — позиция в корзине.
/// Выбранный продукт с параметрами (размер, тесто, исключённые ингредиенты).
/// Хранит снимок цены и изображения на момент добавления.
/// </summary>
public sealed class BasketItem : ValueObject
{
    /// <summary>
    /// Тип продукта — пицца, напиток, соус, комбо или мерчандайз.
    /// </summary>
    public ProductType ProductType { get; set; }

    /// <summary>
    /// Идентификатор продукта в каталоге.
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// Название продукта — дубль для отображения без дополнительных запросов.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Изображение продукта — дубль для отображения корзины.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Количество позиций в корзине.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Название размера — для пиццы (Small, Medium, Large),
    /// для напитка (0.3л, 0.5л).
    /// </summary>
    public string? SizeName { get; set; }

    /// <summary>
    /// Тип теста — только для пиццы (Classic, Thin).
    /// </summary>
    public DoughType? DoughType { get; set; }

    /// <summary>
    /// Цена за единицу — снимок цены на момент добавления в корзину.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Идентификаторы ингредиентов, которые клиент исключил из состава пиццы.
    /// Пустой список — все ингредиенты включены.
    /// </summary>
    public IReadOnlyList<Guid> ExcludedIngredientIds { get; set; } = [];

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return ProductType;
        yield return ProductId;
        yield return Name;
        yield return SizeName;
        yield return DoughType;
    }
}
