using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Inventory.Domain;

/// <summary>
/// Движение stock — запись аудита каждого изменения остатков.
/// Положительные = приход, отрицательные = расход.
/// </summary>
public sealed class StockMovement : EntityBase
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
    /// Тип движения (закупка, списание, корректировка, потеря).
    /// </summary>
    public StockMovementType Type { get; set; }

    /// <summary>
    /// Количество (+ приход, - расход).
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Причина/комментарий к движению.
    /// </summary>
    public required string Reason { get; set; }
}
