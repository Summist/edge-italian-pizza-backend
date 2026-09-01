using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Inventory;

/// <summary>
/// Текущий остаток ингредиента на конкретной локации.
/// Обновляется при каждом движении (приход, расход, корректировка).
/// </summary>
public sealed class StockItem : EntityBase
{
    /// <summary>
    /// Идентификатор ингредиента в справочнике.
    /// </summary>
    public Guid IngredientId { get; set; }

    /// <summary>
    /// Идентификатор локации — к какой точке пиццерии относится остаток.
    /// </summary>
    public Guid LocationId { get; set; }

    /// <summary>
    /// Текущее количество на складе.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Порог низкого остатка — при достижении генерируется уведомление.
    /// </summary>
    public decimal LowStockThreshold { get; set; }
}
