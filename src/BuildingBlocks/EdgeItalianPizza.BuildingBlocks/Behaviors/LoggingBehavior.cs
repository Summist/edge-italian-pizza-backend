using System.Diagnostics;
using EdgeItalianPizza.BuildingBlocks.Results;
using Microsoft.Extensions.Logging;

namespace EdgeItalianPizza.BuildingBlocks.Behaviors;

/// <summary>
/// Поведение логирования — логирует начало, завершение и ошибки обработки.
/// Предупреждает о медленных обработчиках (порог: 3 секунды).
/// </summary>
internal sealed class LoggingBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, Result<TResponse>>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;
    private static readonly TimeSpan SlowHandlerThreshold = TimeSpan.FromSeconds(3);

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<Result<TResponse>> Handle(
        TRequest request,
        Func<Task<Result<TResponse>>> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        LoggingBehaviorLog.LogHandling(_logger, requestName, typeof(TResponse).Name);

        var stopwatch = Stopwatch.StartNew();

        try
        {
            var result = await next();
            stopwatch.Stop();

            if (result.IsSuccess)
            {
                if (stopwatch.Elapsed > SlowHandlerThreshold)
                {
                    LoggingBehaviorLog.LogSlowHandler(
                        _logger, requestName, stopwatch.ElapsedMilliseconds,
                        SlowHandlerThreshold.TotalMilliseconds);
                }
                else
                {
                    LoggingBehaviorLog.LogHandled(_logger, requestName, stopwatch.ElapsedMilliseconds);
                }
            }
            else
            {
                LoggingBehaviorLog.LogFailed(
                    _logger, requestName, stopwatch.ElapsedMilliseconds, result.Error.Code);
            }

            return result;
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            LoggingBehaviorLog.LogError(_logger, requestName, stopwatch.ElapsedMilliseconds, ex);
            throw;
        }
    }
}
