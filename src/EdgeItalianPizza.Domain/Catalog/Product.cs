using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Продукт в каталоге — базовый класс для пиццы, напитков, соусов и комбо.
/// </summary>
public abstract class Product : EntityBase
{
    /// <summary>
    /// Главное фото продукта в каталоге.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// Название (например, «Пепперони», «Кола»).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Базовая цена. Для пиццы — за маленький размер.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Активный продукт показывается в каталоге, неактивный — скрыт.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Дата и время создания (UTC).
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Тип продукта — дискриминатор для разделения пицц, напитков, соусов и комбо.
    /// </summary>
    public abstract ProductType Type { get; }
}
