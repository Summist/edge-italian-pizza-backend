namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Вариант теста для конкретного размера пиццы — связывает тип теста
/// с его стоимостью, пищевой ценностью и отдельным изображением.
/// </summary>
public sealed class PizzaDoughVariant
{
    /// <summary>
    /// Тип теста — классическое или тонкое.
    /// </summary>
    public DoughType DoughType { get; set; }

    /// <summary>
    /// Изображение пиццы с данным размером и типом теста.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Пищевая ценность (КБЖУ) и вес пиццы для этого варианта.
    /// </summary>
    public SizeNutrition Nutrition { get; set; } = null!;

    /// <summary>
    /// Стоимость дополнительных ингредиентов — зависит от размера и типа теста.
    /// </summary>
    public IReadOnlyList<IngredientPrice> IngredientPrices { get; set; } = [];
}
