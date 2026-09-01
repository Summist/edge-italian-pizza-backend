using EdgeItalianPizza.Domain.Primitives;

namespace EdgeItalianPizza.Domain.Users;

/// <summary>
/// Пользователь системы — клиент, курьер, сотрудник кухни или администратор.
/// Способ авторизации зависит от роли: клиент входит по коду из SMS/почты,
/// сотрудники — по логину и паролю.
/// </summary>
public sealed class User : EntityBase
{
    /// <summary>
    /// Имя пользователя — отображается в профиле и используется для обращения.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Электронная почта — используется для входа по коду (клиенты)
    /// или как способ связи (сотрудники). Не обязательна для всех ролей.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Номер телефона — используется для входа по SMS-коду (клиенты)
    /// или как способ связи (курьеры). Не обязательна для всех ролей.
    /// </summary>
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Хеш пароля с указанием версии алгоритма — заполнен для сотрудников
    /// (Staff, Courier, Admin), пуст для клиентов, которые входят
    /// по одноразовому коду.
    /// </summary>
    public HashedValue? PasswordHash { get; set; }

    /// <summary>
    /// Роль пользователя — определяет права доступа и набор действий в системе.
    /// </summary>
    public UserRole Role { get; set; }

    /// <summary>
    /// Идентификатор локации — привязка к конкретной точке пиццерии.
    /// Заполнен для Staff и Courier, пуст для Customer и Admin.
    /// </summary>
    public Guid? LocationId { get; set; }

    /// <summary>
    /// Дата рождения — используется для программ лояльности и поздравлений.
    /// </summary>
    public DateOnly? Birthday { get; set; }

    /// <summary>
    /// Дата и время регистрации (UTC).
    /// </summary>
    public DateTime CreatedAtUtc { get; set; }
}
