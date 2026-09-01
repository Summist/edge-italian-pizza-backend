namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Слот в комбо-наборе — описывает, какой тип продукта сюда входит,
/// какой товар установлен по умолчанию и какие опции замены доступны клиенту.
/// </summary>
public sealed class ComboItem
{
    /// <summary>
    /// Тип продукта, который можно подставить в этот слот (пицца, напиток, соус).
    /// </summary>
    public ProductType ProductType { get; set; }

    /// <summary>
    /// Идентификатор товара, установленного по умолчанию в этом слоте.
    /// </summary>
    public Guid DefaultProductId { get; set; }

    /// <summary>
    /// Название товара по умолчанию — отображается клиенту без дополнительных запросов.
    /// </summary>
    public string DefaultProductName { get; set; } = string.Empty;

    /// <summary>
    /// Можно ли заменить товар на другой из той же категории.
    /// Например, заменить Колу на Спрайт.
    /// </summary>
    public bool AllowReplacement { get; set; }

    /// <summary>
    /// Можно ли выбрать другой размер или объём товара в этом слоте.
    /// </summary>
    public bool AllowSizeChange { get; set; }

    /// <summary>
    /// Разрешённые размеры для этого слота.
    /// Пустой список — доступен любой размер.
    /// Заполненный — только указанные (например, только 30 см для комбо).
    /// </summary>
    public IReadOnlyList<string> AllowedSizeNames { get; set; } = [];
}
