using System.Reflection;
using EdgeItalianPizza.BuildingBlocks.Behaviors;
using EdgeItalianPizza.BuildingBlocks.CQRS;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EdgeItalianPizza.BuildingBlocks.DI;

/// <summary>
/// Методы расширения для регистрации BuildingBlocks в DI.
/// </summary>
public static class BuildingBlocksServiceExtensions
{
    /// <summary>
    /// Регистрирует CQRS обработчики, behaviors и валидаторы из указанных сборок.
    /// </summary>
    public static IServiceCollection AddBuildingBlocks(
        this IServiceCollection services,
        params Assembly[] assemblies)
    {
        if (assemblies.Length == 0)
        {
            assemblies = [Assembly.GetCallingAssembly()];
        }

        services.Scan(scan => scan
            .FromAssemblies(assemblies)
            .AddClasses(classes => classes
                .AssignableTo(typeof(ICommandHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()

            .AddClasses(classes => classes
                .AssignableTo(typeof(IQueryHandler<,>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()

            .AddClasses(classes => classes
                .AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime()

            .AddClasses(classes => classes
                .AssignableTo(typeof(IValidator<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

        return services;
    }
}
