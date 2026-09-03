using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Inventory.Domain;

/// <summary>
/// Остаток ингредиента на конкретной точке.
/// Привязан к Ingredient + Location.
/// </summary>
public sealed class StockItem : EntityBase
{
    /// <summary>
    /// Идентификатор ингредиента.
    /// </summary>
    public Guid IngredientId { get; set; }

    /// <summary>
    /// Идентификатор точки.
    /// </summary>
    public Guid LocationId { get; set; }

    /// <summary>
    /// Текущее количество на складе.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Порог минимального остатка для уведомления.
    /// </summary>
    public decimal LowStockThreshold { get; set; }
}
