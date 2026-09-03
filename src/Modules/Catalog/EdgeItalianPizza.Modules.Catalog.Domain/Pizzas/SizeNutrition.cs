using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Пищевая ценность для конкретного размера и теста.
/// КБЖУ на 100 грамм + общий вес.
/// </summary>
public sealed class SizeNutrition : ValueObject
{
    /// <summary>
    /// Общий вес порции в граммах.
    /// </summary>
    public int WeightGrams { get; set; }

    /// <summary>
    /// Калории на 100 грамм.
    /// </summary>
    public int CaloriesPer100g { get; set; }

    /// <summary>
    /// Белки на 100 грамм.
    /// </summary>
    public decimal ProteinPer100g { get; set; }

    /// <summary>
    /// Жиры на 100 грамм.
    /// </summary>
    public decimal FatPer100g { get; set; }

    /// <summary>
    /// Углеводы на 100 грамм.
    /// </summary>
    public decimal CarbsPer100g { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return WeightGrams;
        yield return CaloriesPer100g;
        yield return ProteinPer100g;
        yield return FatPer100g;
        yield return CarbsPer100g;
    }
}
