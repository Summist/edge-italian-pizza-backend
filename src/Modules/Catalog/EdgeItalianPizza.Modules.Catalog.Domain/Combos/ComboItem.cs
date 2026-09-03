using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Catalog.Domain;

/// <summary>
/// Слот в комбо-наборе.
/// Определяет тип продукта, дефолтный выбор и правила замены.
/// </summary>
public sealed class ComboItem : ValueObject
{
    /// <summary>
    /// Тип продукта для данного слота.
    /// </summary>
    public ProductType ProductType { get; set; }

    /// <summary>
    /// Идентификатор дефолтного продукта.
    /// </summary>
    public Guid DefaultProductId { get; set; }

    /// <summary>
    /// Название дефолтного продукта (денормализовано).
    /// </summary>
    public string DefaultProductName { get; set; } = string.Empty;

    /// <summary>
    /// Можно ли заменить продукт на другой того же типа.
    /// </summary>
    public bool AllowReplacement { get; set; }

    /// <summary>
    /// Можно ли изменить размер.
    /// </summary>
    public bool AllowSizeChange { get; set; }

    /// <summary>
    /// Доступные размеры для замены (пусто = все доступные).
    /// </summary>
    public List<string> AllowedSizeNames { get; set; } = [];

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return ProductType;
        yield return DefaultProductId;
        yield return DefaultProductName;
        yield return AllowReplacement;
        yield return AllowSizeChange;
    }
}
