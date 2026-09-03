namespace EdgeItalianPizza.BuildingBlocks.CQRS;

/// <summary>
/// Интерфейс команды без результата.
/// Команда изменяет состояние системы и должна иметь один обработчик.
/// </summary>
public interface ICommand;

/// <summary>
/// Интерфейс команды, возвращающей результат.
/// </summary>
public interface ICommand<TResponse>;
