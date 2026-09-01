using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Locations;

/// <summary>
/// Объект-значение — расписание работы точки пиццерии в конкретный день недели.
/// Определяет, с какого часа и до какого точка принимает заказы.
/// </summary>
public sealed class WorkingHours : ValueObject
{
    /// <summary>
    /// День недели.
    /// </summary>
    public DayOfWeek DayOfWeek { get; set; }

    /// <summary>
    /// Время открытия точки.
    /// </summary>
    public TimeOnly OpenTime { get; set; }

    /// <summary>
    /// Время закрытия точки.
    /// </summary>
    public TimeOnly CloseTime { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return DayOfWeek;
        yield return OpenTime;
        yield return CloseTime;
    }
}
