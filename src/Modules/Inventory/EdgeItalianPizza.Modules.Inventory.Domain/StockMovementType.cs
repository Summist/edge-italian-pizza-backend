namespace EdgeItalianPizza.Modules.Inventory.Domain;

/// <summary>
/// Тип движения stock.
/// </summary>
public enum StockMovementType : byte
{
    /// <summary>Закупка (+).</summary>
    Purchase = 1,

    /// <summary>Расход на производство (-).</summary>
    Consumption = 2,

    /// <summary>Корректировка (±).</summary>
    Adjustment = 3,

    /// <summary>Потеря/порча (-).</summary>
    Waste = 4
}
