namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Соус — однопорционный продукт без вариантов размера.
/// Дополняет основное блюдо, добавляется к заказу отдельно.
/// </summary>
public sealed class Sauce : Product
{
    public override ProductType Type => ProductType.Sauce;

    /// <summary>
    /// Описание соуса для отображения в каталоге (вкус, состав, рекомендации).
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Вес соуса в граммах.
    /// </summary>
    public int WeightGrams { get; set; }
}
