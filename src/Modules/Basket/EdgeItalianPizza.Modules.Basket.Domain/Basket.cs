namespace EdgeItalianPizza.Modules.Basket.Domain;

/// <summary>
/// Корзина пользователя — текущий не оформленный заказ.
/// Одна корзина на пользователя. Содержит снимок цен на момент добавления.
/// </summary>
public sealed class Basket
{
    /// <summary>
    /// Идентификатор владельца корзины.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Идентификатор выбранной точки выдачи/доставки.
    /// </summary>
    public Guid LocationId { get; set; }

    /// <summary>
    /// Позиции в корзине.
    /// </summary>
    public List<BasketItem> Items { get; set; } = [];

    /// <summary>
    /// Применённый промокод (если есть).
    /// </summary>
    public string? PromoCode { get; set; }

    /// <summary>
    /// Сумма скидки по промокоду.
    /// </summary>
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// Использовать ли монеты для оплаты.
    /// </summary>
    public bool UseCoins { get; set; }

    /// <summary>
    /// Количество монет к списанию.
    /// </summary>
    public int CoinsAmount { get; set; }

    /// <summary>
    /// Дата и время создания корзины.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Дата и время последнего обновления.
    /// </summary>
    public DateTime UpdatedAtUtc { get; set; }
}
