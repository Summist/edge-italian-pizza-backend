using Microsoft.Extensions.Logging;

namespace EdgeItalianPizza.BuildingBlocks.Behaviors;

/// <summary>
/// Source-generated логи для LoggingBehavior.
/// Отдельный non-generic класс, т.к. [LoggerMessage] не работает с generic.
/// </summary>
internal static partial class LoggingBehaviorLog
{
    [LoggerMessage(Level = LogLevel.Information,
        Message = "Handling request {RequestName} expecting response {ResponseName}")]
    public static partial void LogHandling(ILogger logger, string requestName, string responseName);

    [LoggerMessage(Level = LogLevel.Information,
        Message = "Handled {RequestName} in {ElapsedMilliseconds} ms")]
    public static partial void LogHandled(ILogger logger, string requestName, long elapsedMilliseconds);

    [LoggerMessage(Level = LogLevel.Warning,
        Message = "Slow handler detected. {RequestName} took {ElapsedMilliseconds} ms (threshold {ThresholdMilliseconds} ms)")]
    public static partial void LogSlowHandler(ILogger logger, string requestName, long elapsedMilliseconds,
        double thresholdMilliseconds);

    [LoggerMessage(Level = LogLevel.Information,
        Message = "Request {RequestName} failed with {ErrorCode} after {ElapsedMilliseconds} ms")]
    public static partial void LogFailed(ILogger logger, string requestName, long elapsedMilliseconds, string errorCode);

    [LoggerMessage(Level = LogLevel.Error,
        Message = "Request {RequestName} threw exception after {ElapsedMilliseconds} ms")]
    public static partial void LogError(ILogger logger, string requestName, long elapsedMilliseconds, Exception ex);
}
