using EdgeItalianPizza.BuildingBlocks.Results;

namespace EdgeItalianPizza.BuildingBlocks.CQRS;

/// <summary>
/// Интерфейс обработчика команды без результата.
/// </summary>
public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    /// <summary>
    /// Обрабатывает команду.
    /// </summary>
    Task<Result> Handle(TCommand command, CancellationToken cancellationToken);
}

/// <summary>
/// Интерфейс обработчика команды с результатом.
/// </summary>
public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    /// <summary>
    /// Обрабатывает команду и возвращает результат.
    /// </summary>
    Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
}
