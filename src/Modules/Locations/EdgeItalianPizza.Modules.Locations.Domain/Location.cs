using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Locations.Domain;

/// <summary>
/// Точка выдачи/доставки — физическое расположение пиццерии.
/// Содержит геокоординаты, радиус доставки и расписание работы.
/// </summary>
public sealed class Location : EntityBase
{
    /// <summary>
    /// Название точки (например, "Пиццерия на Тверской").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Город.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Полный адрес.
    /// </summary>
    public string Address { get; set; } = string.Empty;

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
