namespace EdgeItalianPizza.Domain.Inventory;

/// <summary>
/// Тип движения остатков — определяет причину изменения количества
/// ингредиента на складе.
/// </summary>
public enum StockMovementType : byte
{
    /// <summary>
    /// Приход — поставка от поставщика.
    /// </summary>
    Purchase = 1,

    /// <summary>
    /// Расход — списание при приготовлении заказа.
    /// </summary>
    Consumption = 2,

    /// <summary>
    /// Корректировка — результат инвентаризации (излишек или недостача).
    /// </summary>
    Adjustment = 3,

    /// <summary>
    /// Списание — испорченный, просроченный или бракованный ингредиент.
    /// </summary>
    Waste = 4,
}
