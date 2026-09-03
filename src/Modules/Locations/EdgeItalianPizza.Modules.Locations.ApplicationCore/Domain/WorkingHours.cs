using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;

/// <summary>
/// Расписание работы на один день недели.
/// </summary>
public sealed class WorkingHours : ValueObject
{
    /// <summary>
    /// День недели.
    /// </summary>
    public DayOfWeek DayOfWeek { get; set; }

    /// <summary>
    /// Время открытия.
    /// </summary>
    public TimeOnly OpenTime { get; set; }

    /// <summary>
    /// Время закрытия.
    /// </summary>
    public TimeOnly CloseTime { get; set; }

    public override IEnumerable<object?> GetEqualityComponents()
    {
        yield return DayOfWeek;
        yield return OpenTime;
        yield return CloseTime;
    }
}
