namespace EdgeItalianPizza.Modules.Inventory.Domain;

/// <summary>
/// Единица измерения ингредиента.
/// </summary>
public enum IngredientUnit : byte
{
    /// <summary>Штука.</summary>
    Piece = 1,

    /// <summary>Грамм.</summary>
    Gram = 2,

    /// <summary>Миллилитр.</summary>
    Milliliter = 3,
}
