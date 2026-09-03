using EdgeItalianPizza.BuildingBlocks.Primitives;

namespace EdgeItalianPizza.Modules.Users.Domain;

/// <summary>
/// Единая сущность пользователя для всех ролей.
/// Способ авторизации зависит от роли:
/// - Клиенты: OTP через SMS/email (без пароля).
/// - Сотрудники/курьеры/админы: логин + пароль (хранится как HashedValue).
/// </summary>
public sealed class User : EntityBase
{
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Email (nullable — не обязателен для клиентов по телефону).
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Номер телефона (nullable — не обязателен для клиентов по email).
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Хеш пароля (только для Staff/Courier/Admin).
    /// </summary>
    public HashedValue? PasswordHash { get; set; }

    /// <summary>
    /// Роль пользователя.
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// Привязка к точке (для Staff/Courier). null для Customer/Admin.
    /// </summary>
    public Guid? LocationId { get; set; }

    /// <summary>
    /// Дата рождения (nullable).
    /// </summary>
    public DateOnly? Birthday { get; set; }
}
