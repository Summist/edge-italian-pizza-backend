namespace EdgeItalianPizza.BuildingBlocks.Results;

/// <summary>
/// Результат операции без возвращаемого значения.
/// </summary>
public readonly record struct Result
{
    /// <summary>
    /// Ошибка, если операция не удалась.
    /// </summary>
    public Error Error { get; }

    /// <summary>
    /// Указывает, что операция выполнена успешно.
    /// </summary>
    public bool IsSuccess { get; }

    private Result(Error error, bool isSuccess)
    {
        Error = error;
        IsSuccess = isSuccess;
    }

    /// <summary>
    /// Создаёт успешный результат.
    /// </summary>
    public static Result Success() => new(Error.None, true);

    /// <summary>
    /// Создаёт результат с ошибкой.
    /// </summary>
    public static Result Failure(Error error) => new(error, false);

    /// <summary>
    /// Создаёт результат с ошибкой по коду и сообщению.
    /// </summary>
    public static Result Failure(string code, string message) => new(new Error(code, message), false);
}
