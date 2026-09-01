namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// КБЖУ и вес пиццы. Все показатели — на 100 грамм.
/// </summary>
public sealed class SizeNutrition
{
    /// <summary>
    /// Общий вес пиццы в граммах.
    /// </summary>
    public int WeightGrams { get; set; }

    /// <summary>
    /// Калорийность на 100 грамм (ккал).
    /// </summary>
    public int CaloriesPer100g { get; set; }

    /// <summary>
    /// Белки на 100 грамм (г).
    /// </summary>
    public decimal ProteinPer100g { get; set; }

    /// <summary>
    /// Жиры на 100 грамм (г).
    /// </summary>
    public decimal FatPer100g { get; set; }

    /// <summary>
    /// Углеводы на 100 грамм (г).
    /// </summary>
    public decimal CarbsPer100g { get; set; }
}
