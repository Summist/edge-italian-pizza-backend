namespace EdgeItalianPizza.BuildingBlocks.Results;

/// <summary>
/// Результат операции с возвращаемым значением.
/// </summary>
public readonly record struct Result<T>
{
    /// <summary>
    /// Значение, если операция выполнена успешно.
    /// </summary>
    public T? Value { get; }

    /// <summary>
    /// Ошибка, если операция не удалась.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Указывает, что операция выполнена успешно.
    /// </summary>
    public bool IsSuccess { get; }

    private Result(T? value, Error error, bool isSuccess)
    {
        Value = value;
        Error = error;
        IsSuccess = isSuccess;
    }

    /// <summary>
    /// Создаёт успешный результат со значением.
    /// </summary>
    public static Result<T> Success(T value) =>
        new(value ?? throw new ArgumentNullException(nameof(value)), Error.None, true);

    /// <summary>
    /// Создаёт результат с ошибкой.
    /// </summary>
    public static Result<T> Failure(Error error) => new(default, error, false);

    /// <summary>
    /// Создаёт результат с ошибкой по коду и сообщению.
    /// </summary>
    public static Result<T> Failure(string code, string message) => new(default, new Error(code, message), false);

    /// <summary>
    /// Неявное преобразование значения в успешный результат.
    /// </summary>
    public static implicit operator Result<T>(T value) => Success(value);
}
