using EdgeItalianPizza.BuildingBlocks.Results;
using FluentValidation;

namespace EdgeItalianPizza.BuildingBlocks.Behaviors;

/// <summary>
/// Поведение валидации — проверяет входные данные перед обработкой.
/// Если валидация не прошла, возвращает ошибку без вызова обработчика.
/// </summary>
internal sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, Result<TResponse>>
{
    private readonly IValidator<TRequest>[] _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators.ToArray();
    }

    public async Task<Result<TResponse>> Handle(
        TRequest request,
        Func<Task<Result<TResponse>>> next,
        CancellationToken cancellationToken)
    {
        if (_validators.Length == 0)
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var failures = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure is not null)
            .ToList();

        if (failures.Count == 0)
        {
            return await next();
        }

        var validationErrors = failures
            .GroupBy(failure => failure.PropertyName)
            .ToDictionary(
                group => group.Key,
                group => group.Select(failure => failure.ErrorMessage).ToArray());

        var error = new Error("Validation.Error", "Validation failed", validationErrors);
        return Result<TResponse>.Failure(error);
    }
}
