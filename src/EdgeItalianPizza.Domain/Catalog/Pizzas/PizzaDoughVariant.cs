namespace EdgeItalianPizza.Domain.Catalog;

public sealed class PizzaDoughVariant
{
    /// <summary>
    /// Тип теста — классическое или тонкое.
    /// </summary>
    public DoughType DoughType { get; set; }

    /// <summary>
    /// Фото пиццы с этим размером и тестом.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// КБЖУ и вес для данного варианта.
    /// </summary>
    public SizeNutrition Nutrition { get; set; } = null!;

    /// <summary>
    /// Стоимость каждого ингредиента — зависит от размера.
    /// </summary>
    public IReadOnlyList<IngredientPrice> IngredientPrices { get; set; } = [];
}
