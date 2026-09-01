namespace EdgeItalianPizza.Domain.Catalog;

/// <summary>
/// Тип теста — влияет на вес, калорийность.
/// </summary>
public enum DoughType : byte
{
    /// <summary>
    /// Классическое пышное тесто — стандартный вариант.
    /// </summary>
    Classic = 1,

    /// <summary>
    /// Тонкое тесто — легче и менее калорийное.
    /// </summary>
    Thin = 2,
}
