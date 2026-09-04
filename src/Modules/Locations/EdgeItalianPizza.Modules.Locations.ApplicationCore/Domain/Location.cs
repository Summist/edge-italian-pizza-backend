using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;

/// <summary>
/// Точка выдачи/доставки — физическое расположение пиццерии.
/// Содержит геокоординаты, радиус доставки и расписание работы.
/// </summary>
public sealed class Location : EntityBase
{
    /// <summary>
    /// Название точки (например, "Пиццерия на Тверской").
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Город.
    /// </summary>
    public required string City { get; set; }

    /// <summary>
    /// Полный адрес.
    /// </summary>
    public required string Address { get; set; }

    /// <summary>
    /// Широта (географическая координата).
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Долгота (географическая координата).
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Радиус доставки в километрах.
    /// </summary>
    public decimal DeliveryRadiusKm { get; set; }

    /// <summary>
    /// Расписание работы по дням недели.
    /// </summary>
    public List<WorkingHours> WorkingHours { get; set; } = [];

    /// <summary>
    /// Активна ли точка (отображается в приложении).
    /// </summary>
    public bool IsActive { get; set; }
}
