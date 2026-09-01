namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Мерчандайз — фигурки, игрушки, сувениры и прочий несъедобный мерч.
/// Продаётся как отдельная категория товаров в каталоге.
/// </summary>
public sealed class Merchandise : Product
{
    /// <inheritdoc />
    public override ProductType Type => ProductType.Merchandise;

    /// <summary>
    /// Описание товара для отображения в каталоге (материал, размер, особенности).
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Вес товара в граммах — используется для расчёта доставки.
    /// </summary>
    public int WeightGrams { get; set; }
}
