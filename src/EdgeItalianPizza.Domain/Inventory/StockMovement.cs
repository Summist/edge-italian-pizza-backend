using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Inventory;

/// <summary>
/// Запись о движении остатков — фиксирует каждое изменение количества
/// ингредиента на складе: приход, расход, корректировку или списание.
/// Используется для аудита и аналитики.
/// </summary>
public sealed class StockMovement : EntityBase
{
    /// <summary>
    /// Идентификатор ингредиента, к которому относится движение.
    /// </summary>
    public Guid IngredientId { get; set; }

    /// <summary>
    /// Идентификатор локации — на каком складе произошло движение.
    /// </summary>
    public Guid LocationId { get; set; }

    /// <summary>
    /// Тип движения — приход, расход, корректировка или списание.
    /// </summary>
    public StockMovementType Type { get; set; }

    /// <summary>
    /// Количество (положительное — приход, отрицательное — расход).
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Причина движения — описание для аудита (например, «Заказ #1234»,
    /// «Поставка от ООО Поставщик», «Инвентаризация»).
    /// </summary>
    public string Reason { get; set; } = string.Empty;

    /// <summary>
    /// Дата и время движения (UTC).
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }
}
