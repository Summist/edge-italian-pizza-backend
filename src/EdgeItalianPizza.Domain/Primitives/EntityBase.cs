namespace EdgeItalianPizza.Domain.Primitives;

/// <summary>
/// Базовый класс сущностей — каждый объект имеет уникальный идентификатор.
/// </summary>
public abstract class EntityBase
{
    /// <summary>
    /// Уникальный идентификатор — генерируется автоматически (GUID v7).
    /// </summary>
    public Guid Id { get; set; } = Guid.CreateVersion7();
}
