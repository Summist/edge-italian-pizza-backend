using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Users;

/// <summary>
/// Активная сессия пользователя — хранит информацию о входе:
/// откуда, с какого устройства, когда вошёл и можно ли продлить токен.
/// Позволяет отслеживать и завершать сессии при необходимости.
/// </summary>
public sealed class UserSession : EntityBase
{
    /// <summary>
    /// Идентификатор пользователя, которому принадлежит сессия.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Хеш refresh-токена с указанием версии алгоритма — используется
    /// для продления сессии без повторного входа.
    /// Сам токен хранится только на клиенте.
    /// </summary>
    public HashedValue RefreshTokenHash { get; set; } = new();

    /// <summary>
    /// IP-адрес устройства, с которого был выполнен вход.
    /// Используется для обнаружения подозрительной активности.
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// Информация об устройстве или браузере (например, «iPhone 15», «Chrome 120»).
    /// </summary>
    public string? DeviceInfo { get; set; }

    /// <summary>
    /// Время последней активности — используется для авто-завершения
    /// неактивных сессий.
    /// </summary>
    public DateTime LastActiveAtUtc { get; set; }

    /// <summary>
    /// Дата и время создания сессии — момент входа в систему (UTC).
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }

    /// <summary>
    /// Дата и время отзыва сессии (UTC).
    /// null — сессия активна, значение — сессия отозвана в это время.
    /// </summary>
    public DateTime? RevokedAtUtc { get; set; }
}
