using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Locations;

/// <summary>
/// Точка пиццерии — физическое заведение с адресом, координатами
/// и зоной доставки. Каждая точка имеет своё расписание работы
/// и привязанный персонал.
/// </summary>
public sealed class Location : EntityBase
{
    /// <summary>
    /// Название точки для отображения (например, «Edge Italian Pizza — Тверская»).
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Город, в котором находится точка.
    /// </summary>
    public string City { get; set; } = string.Empty;

    /// <summary>
    /// Полный адрес точки (например, «ул. Тверская, д. 15»).
    /// </summary>
    public string Address { get; set; } = string.Empty;

    /// <summary>
    /// Широта координат точки — используется для расчёта расстояния
    /// до адреса доставки.
    /// </summary>
    public double Latitude { get; set; }

    /// <summary>
    /// Долгота координат точки — используется для расчёта расстояния
    /// до адреса доставки.
    /// </summary>
    public double Longitude { get; set; }

    /// <summary>
    /// Радиус доставки в километрах — заказы принимаются только
    /// из пределов этой зоны.
    /// </summary>
    public decimal DeliveryRadiusKm { get; set; }

    /// <summary>
    /// Расписание работы точки по дням недели.
    /// </summary>
    public IReadOnlyList<WorkingHours> WorkingHours { get; set; } = [];

    /// <summary>
    /// Активна ли точка. Активные точки отображаются клиентам,
    /// неактивные — скрыты, но сохраняются в системе.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Дата и время создания точки (UTC).
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }
}
