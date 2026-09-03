namespace EdgeItalianPizza.BuildingBlocks.Primitives;

/// <summary>
/// Базовый класс сущностей — каждый объект имеет уникальный идентификатор и метки времени.
/// </summary>
public abstract class EntityBase
{
    /// <summary>
    /// Уникальный идентификатор объекта.
    /// </summary>
    public Guid Id { get; set; } = Guid.CreateVersion7();

    /// <summary>
    /// Дата и время создания в UTC.
    /// </summary>
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Дата и время последнего обновления в UTC.
    /// </summary>
    public DateTime? UpdatedAtUtc { get; set; }
}
