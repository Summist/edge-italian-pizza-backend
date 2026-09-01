namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Слот в комбо-наборе — описывает, какой тип продукта сюда входит,
/// какой товар по умолчанию и какие опции доступны клиенту.
/// </summary>
public sealed class ComboItem
{
    /// <summary>
    /// Тип продукта, который можно поставить в этот слот (пицца, напиток, соус).
    /// </summary>
    public ProductType ProductType { get; set; }

    /// <summary>
    /// Идентификатор товара по умолчанию.
    /// </summary>
    public Guid DefaultProductId { get; set; }

    /// <summary>
    /// Название товара по умолчанию (снимок на момент создания набора).
    /// </summary>
    public string DefaultProductName { get; set; } = string.Empty;

    /// <summary>
    /// Можно ли заменить товар на другой из той же категории.
    /// </summary>
    public bool AllowReplacement { get; set; }

    /// <summary>
    /// Можно ли выбрать другой размер/объём.
    /// </summary>
    public bool AllowSizeChange { get; set; }

    /// <summary>
    /// Разрешённые размеры. Пустой список — любой размер.
    /// Заполненный — только указанные (например, ["Medium"] для комбо 30 см).
    /// </summary>
    public IReadOnlyList<string> AllowedSizeNames { get; set; } = [];
}
