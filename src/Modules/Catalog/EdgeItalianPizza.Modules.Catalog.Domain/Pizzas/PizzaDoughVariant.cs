using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Вариант теста для конкретного размера пиццы.
/// Содержит свою картинку, КБЖУ и цены на доп. ингредиенты.
/// </summary>
public sealed class PizzaDoughVariant : ValueObject
{
    /// <summary>
    /// Тип теста (классическое, тонкое).
    /// </summary>
    public DoughType DoughType { get; set; }

    /// <summary>
    /// URL изображения для данного варианта теста и размера.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Пищевая ценность для данного размера и теста.
    /// </summary>
    public SizeNutrition Nutrition { get; set; } = null!;

    /// <summary>
    /// Стоимость доп. ингредиентов для данного размера и теста.
    /// </summary>
    public List<IngredientPrice> IngredientPrices { get; set; } = [];

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return DoughType;
        yield return ImageUrl;
    }
}
