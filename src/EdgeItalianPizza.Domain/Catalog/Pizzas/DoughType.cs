namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Тип теста пиццы — определяет вкус, текстуру и влияет на пищевую ценность.
/// </summary>
public enum DoughType : byte
{
    /// <summary>
    /// Классическое пышное тесто — стандартный вариант.
    /// </summary>
    Classic = 1,

    /// <summary>
    /// Тонкое тесто — легче, хрустящее, менее калорийное.
    /// </summary>
    Thin = 2,
}
