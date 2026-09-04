namespace EdgeItalianPizza.BuildingBlocks.Primitives;

/// <summary>
/// Базовый класс сущностей — каждый объект имеет уникальный идентификатор и метки времени.
/// </summary>
public abstract class EntityBase
{
    public Guid Id { get; set; } = Guid.CreateVersion7();

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAtUtc { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is not EntityBase other)
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        if (GetType() != other.GetType())
        {
            return false;
        }

        return Id == other.Id;
    }

    public override int GetHashCode() => Id.GetHashCode();
}
