using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore;

/// <summary>
/// Внутренняя реализация модуля локаций.
/// Связывает facade с обработчиками команд и запросов.
/// </summary>
/// <remarks>
/// TODO: При рефакторинге рассмотреть Lazy&lt;T&gt; или IServiceProvider
/// для ленивого резолвинга handler'ов если модуль вырастет до 15+ handler'ов.
/// </remarks>
internal sealed class LocationModule(
    ICommandHandler<CreateLocationCommand, CreateLocationResult> createLocationHandler,
    IQueryHandler<GetLocationsQuery, List<LocationResponse>> getLocationsHandler,
    IQueryHandler<GetLocationByIdQuery, LocationDetailResponse> getLocationByIdHandler,
    ICommandHandler<UpdateLocationCommand, UpdateLocationResult> updateLocationHandler,
    ICommandHandler<DeactivateLocationCommand, DeactivateLocationResult> deactivateLocationHandler
) : ILocationModule
{
    public async Task<Result<CreateLocationResult>> CreateAsync(
        CreateLocationCommand command,
        CancellationToken cancellationToken)
        => await createLocationHandler.Handle(command, cancellationToken);

    public async Task<Result<List<LocationResponse>>> GetAllAsync(
        CancellationToken cancellationToken)
        => await getLocationsHandler.Handle(new GetLocationsQuery(), cancellationToken);

    public async Task<Result<LocationDetailResponse>> GetByIdAsync(
        Guid locationId,
        CancellationToken cancellationToken)
        => await getLocationByIdHandler.Handle(new GetLocationByIdQuery(locationId), cancellationToken);

    public async Task<Result<UpdateLocationResult>> UpdateAsync(
        UpdateLocationCommand command,
        CancellationToken cancellationToken)
        => await updateLocationHandler.Handle(command, cancellationToken);

    public async Task<Result<DeactivateLocationResult>> DeactivateAsync(
        Guid locationId,
        CancellationToken cancellationToken)
        => await deactivateLocationHandler.Handle(new DeactivateLocationCommand(locationId), cancellationToken);
}
