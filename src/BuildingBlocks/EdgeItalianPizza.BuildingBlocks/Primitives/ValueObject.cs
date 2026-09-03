namespace EdgeItalianPizza.BuildingBlocks.Primitives;

/// <summary>
/// Базовый класс объектов-значений — определяет равенство по содержимому, а не по ссылке.
/// Объекты-значения не имеют уникального идентификатора и неизменяемы после создания.
/// </summary>
public abstract class ValueObject
{
    /// <summary>
    /// Возвращает набор компонентов, определяющих равенство двух объектов-значений.
    /// Два объекта считаются равными, если все компоненты совпадают.
    /// </summary>
    public abstract IEnumerable<object?> GetEqualityComponents();

    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
            return false;

        var other = (ValueObject)obj;

        return GetEqualityComponents()
            .SequenceEqual(other.GetEqualityComponents());
    }

    public override int GetHashCode()
    {
        return GetEqualityComponents()
            .Aggregate(1, (current, obj) =>
                current * 23 + (obj?.GetHashCode() ?? 0));
    }

    public static bool operator ==(ValueObject? left, ValueObject? right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(ValueObject? left, ValueObject? right)
    {
        return !Equals(left, right);
    }
}
