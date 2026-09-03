using System.Reflection;
using EdgeItalianPizza.BuildingBlocks.DI;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore;

/// <summary>
/// Регистрация сервисов модуля локаций.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Добавить модуль локаций в контейнер зависимостей.
    /// </summary>
    public static IServiceCollection AddLocationModule(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddBuildingBlocks(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddScoped<ILocationModule, LocationModule>();

        return services;
    }
}
