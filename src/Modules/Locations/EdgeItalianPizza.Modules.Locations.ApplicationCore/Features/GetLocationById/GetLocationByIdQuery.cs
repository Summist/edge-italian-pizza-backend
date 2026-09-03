using EdgeItalianPizza.BuildingBlocks.CQRS;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Запрос получения точки по идентификатору.
/// </summary>
public sealed record GetLocationByIdQuery(Guid LocationId) : IQuery<LocationDetailResponse>;
