using EdgeItalianPizza.BuildingBlocks.CQRS;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Запрос получения списка всех точек.
/// </summary>
public sealed record GetLocationsQuery : IQuery<IReadOnlyList<LocationResponse>>;
