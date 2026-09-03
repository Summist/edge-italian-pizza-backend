namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Соус — продукт с фиксированной ценой и весом.
/// </summary>
public sealed class Sauce : Product
{
    public override ProductType Type => ProductType.Sauce;

    /// <summary>
    /// Описание соуса.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Вес порции в граммах.
    /// </summary>
    public int WeightGrams { get; set; }
}
