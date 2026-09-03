using System.Runtime.InteropServices;

namespace EdgeItalianPizza.BuildingBlocks.Results;

/// <summary>
/// Представляет ошибку. Для ошибок валидации заполняется ValidationErrors.
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public sealed record Error
{
    /// <summary>
    /// Пустая ошибка — отсутствие ошибки.
    /// </summary>
    public static readonly Error None = new(string.Empty, string.Empty);

    /// <summary>
    /// Код ошибки.
    /// </summary>
    public string Code { get; }

    /// <summary>
    /// Сообщение ошибки.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Ошибки валидации по полям. Заполняется только при ошибках валидации.
    /// Ключ — имя свойства. Значение — массив сообщений.
    /// </summary>
    public IReadOnlyDictionary<string, string[]>? ValidationErrors { get; }

    public Error(string code, string message)
        : this(code, message, null)
    {
    }

    public Error(string code, string message, IReadOnlyDictionary<string, string[]>? validationErrors)
    {
        Code = code;
        Message = message;
        ValidationErrors = validationErrors;
    }
}
