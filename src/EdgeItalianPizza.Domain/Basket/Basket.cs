namespace EdgeItalianPizza.Domain.Basket;

/// <summary>
/// Корзина пользователя — текущий незавершённый заказ.
/// Одна корзина на пользователя. Хранит выбранные продукты
/// до оформления заказа.
/// </summary>
public sealed class Basket
{
    /// <summary>
    /// Идентификатор пользователя — владельца корзины.
    /// Также используется как ключ корзины.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Идентификатор локации — из какой точки пиццерии оформляется заказ.
    /// </summary>
    public Guid LocationId { get; set; }

    /// <summary>
    /// Позиции в корзине — выбранные продукты с параметрами.
    /// </summary>
    public IReadOnlyList<BasketItem> Items { get; set; } = [];

    /// <summary>
    /// Применённый промокод — если клиент ввёл код скидки.
    /// </summary>
    public string? PromoCode { get; set; }

    /// <summary>
    /// Сумма скидки — рассчитывается на основе промокода.
    /// </summary>
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// Использовать ли монеты для оплаты части заказа.
    /// </summary>
    public bool UseCoins { get; set; }

    /// <summary>
    /// Количество монет к списанию.
    /// </summary>
    public int CoinsAmount { get; set; }

    /// <summary>
    /// Дата и время создания корзины (UTC).
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Дата и время последнего обновления (UTC).
    /// </summary>
    public DateTime UpdatedAtUtc { get; set; }
}
