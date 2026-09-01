namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Мерчандайз — фигурки, игрушки, сувениры и прочий несъедобный мерч.
/// </summary>
public sealed class Merchandise : Product
{
    /// <inheritdoc />
    public override ProductType Type => ProductType.Merchandise;

    /// <summary>
    /// Описание для отображения в каталоге.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Вес в граммах.
    /// </summary>
    public int WeightGrams { get; set; }
}
