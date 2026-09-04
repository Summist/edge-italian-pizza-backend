using System.Diagnostics;
using EdgeItalianPizza.BuildingBlocks.Results;
using Microsoft.Extensions.Logging;

namespace EdgeItalianPizza.BuildingBlocks.Behaviors;

/// <summary>
/// Поведение логирования для команд без результата (Result).
/// Логирует начало, завершение и ошибки обработки.
/// Предупреждает о медленных обработчиках (порог: 3 секунды).
/// </summary>
internal sealed class LoggingBehavior<TRequest>
    : IPipelineBehavior<TRequest, Result>
{
    private readonly ILogger<LoggingBehavior<TRequest>> _logger;
    private static readonly TimeSpan SlowHandlerThreshold = TimeSpan.FromSeconds(3);

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest>> logger)
    {
        _logger = logger;
    }

    public async Task<Result> Handle(
        TRequest request,
        Func<Task<Result>> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;

        LoggingBehaviorLog.LogHandling(_logger, requestName, "Result");

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
