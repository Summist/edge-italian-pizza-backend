using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore;

/// <summary>
/// Публичный интерфейс модуля локаций.
/// Единая точка входа для взаимодействия с модулем.
/// </summary>
public interface ILocationModule
{
    /// <summary>
    /// Создать новую точку выдачи/доставки.
    /// </summary>
    Task<Result<CreateLocationResult>> CreateAsync(
        CreateLocationCommand command,
        CancellationToken cancellationToken);

    /// <summary>
    /// Получить список всех точек.
    /// </summary>
    Task<Result<IReadOnlyList<LocationResponse>>> GetAllAsync(
        CancellationToken cancellationToken);

    /// <summary>
    /// Получить точку по идентификатору.
    /// </summary>
    Task<Result<LocationDetailResponse>> GetByIdAsync(
        Guid locationId,
        CancellationToken cancellationToken);

    /// <summary>
    /// Обновить данные точки.
    /// </summary>
    Task<Result<UpdateLocationResult>> UpdateAsync(
        UpdateLocationCommand command,
        CancellationToken cancellationToken);

    /// <summary>
    /// Деактивировать точку.
    /// </summary>
    Task<Result<DeactivateLocationResult>> DeactivateAsync(
        Guid locationId,
        CancellationToken cancellationToken);
}
