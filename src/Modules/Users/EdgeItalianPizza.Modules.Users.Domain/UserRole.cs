namespace EdgeItalianPizza.Modules.Users.Domain;

/// <summary>
/// Роль пользователя в системе.
/// </summary>
public enum UserRole : byte
{
    /// <summary>Администратор (управление системой).</summary>
    Admin = 1,

    /// <summary>Клиент (заказы, корзина, оплата).</summary>
    Customer = 2,

    /// <summary>Сотрудник пиццерии (приём заказов, производство).</summary>
    Staff = 3,

    /// <summary>Курьер (доставка).</summary>
    Courier = 4
}
