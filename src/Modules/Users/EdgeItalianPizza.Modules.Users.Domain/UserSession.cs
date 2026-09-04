using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Users.Domain;

/// <summary>
/// Сессия пользователя — отслеживание активных сессий.
/// Refresh token хранится только как хеш на сервере.
/// </summary>
public sealed class UserSession : EntityBase
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Хеш refresh token (не сам токен).
    /// </summary>
    public required HashedValue RefreshTokenHash { get; set; }

    /// <summary>
    /// IP-адрес клиента.
    /// </summary>
    public string? IpAddress { get; set; }

    /// <summary>
    /// Информация об устройстве (User-Agent).
    /// </summary>
    public string? DeviceInfo { get; set; }

    /// <summary>
    /// Дата и время последней активности.
    /// </summary>
    public DateTime LastActiveAtUtc { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Дата и время отзыва сессии (null = активна).
    /// </summary>
    public DateTime? RevokedAtUtc { get; set; }
}
