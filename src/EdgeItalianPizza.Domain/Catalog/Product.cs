using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Продукт в каталоге — базовая сущность для всех позиций меню:
/// пицц, напитков, соусов, комбо-наборов и мерчандайза.
/// </summary>
public abstract class Product : EntityBase
{
    /// <summary>
    /// Главное изображение продукта для отображения в каталоге.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Название продукта — отображается клиенту (например, «Пепперони», «Кола 0.5л»).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Базовая цена. Для пиццы — стоимость за маленький размер,
    /// для напитков и соусов — фиксированная цена за единицу.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Активен ли продукт. Активные продукты отображаются в каталоге,
    /// неактивные — скрыты от клиентов, но сохраняются в системе.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Дата и время создания записи (UTC).
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Тип продукта — определяет, к какому разделу каталога относится позиция.
    /// </summary>
    public abstract ProductType Type { get; }

    /// <summary>
    /// Рекомендуемые дополнения к продукту — список Id продуктов,
    /// которые предлагаются клиенту при заказе (соусы к пицце, напитки и т.д.).
    /// </summary>
    public IReadOnlyList<Guid> RecommendedAdditionIds { get; set; } = [];
}
