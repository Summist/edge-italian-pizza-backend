namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Соус — однопорционный продукт без вариантов размера.
/// </summary>
public sealed class Sauce : Product
{
    public override ProductType Type => ProductType.Sauce;

    /// <summary>
    /// Описание соуса для отображения в каталоге.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Вес в граммах.
    /// </summary>
    public int WeightGrams { get; set; }
}
