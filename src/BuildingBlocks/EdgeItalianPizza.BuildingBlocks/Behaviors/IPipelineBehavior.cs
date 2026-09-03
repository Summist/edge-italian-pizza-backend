namespace EdgeItalianPizza.BuildingBlocks.Behaviors;

/// <summary>
/// Поведение (Behavior) — промежуточное звено между вызовом и обработчиком.
/// Используется для валидации, логирования и других cross-cutting concerns.
/// </summary>
public interface IPipelineBehavior<in TRequest, TResponse>
{
    /// <summary>
    /// Обрабатывает запрос, выполняя дополнительную логику до/после делегирования следующему звену.
    /// </summary>
    Task<TResponse> Handle(TRequest request, Func<Task<TResponse>> next, CancellationToken cancellationToken);
}
