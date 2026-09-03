using EdgeItalianPizza.BuildingBlocks.Results;

namespace EdgeItalianPizza.BuildingBlocks.CQRS;

/// <summary>
/// Интерфейс обработчика запроса.
/// </summary>
public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    /// <summary>
    /// Обрабатывает запрос и возвращает результат.
    /// </summary>
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
}
