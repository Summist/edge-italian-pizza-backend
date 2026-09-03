namespace EdgeItalianPizza.BuildingBlocks.CQRS;

/// <summary>
/// Интерфейс запроса, возвращающего результат.
/// Запрос не изменяет состояние системы и должен иметь один обработчик.
/// </summary>
public interface IQuery<TResponse>;
