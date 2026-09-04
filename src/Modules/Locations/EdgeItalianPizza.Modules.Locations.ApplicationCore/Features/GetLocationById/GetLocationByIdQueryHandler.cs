using EdgeItalianPizza.BuildingBlocks.Caching;
using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Обработчик запроса получения точки по ID.
/// </summary>
internal sealed class GetLocationByIdQueryHandler(
    ILocationsDbContext dbContext,
    ICacheService cache) : IQueryHandler<GetLocationByIdQuery, LocationDetailResponse>
{
    public async Task<Result<LocationDetailResponse>> Handle(
        GetLocationByIdQuery query,
        CancellationToken cancellationToken)
    {
        var response = await cache.GetOrAddAsync(
            LocationCacheKeys.ById(query.LocationId),
            async cancellationToken =>
            {
                var location = await dbContext.Locations
                    .Find(x => x.Id == query.LocationId)
                    .FirstOrDefaultAsync(cancellationToken);

                if (location is null)
                {
                    return null;
                }

                return new LocationDetailResponse(
                    location.Id,
                    location.Name,
                    location.City,
                    location.Address,
                    location.Latitude,
                    location.Longitude,
                    location.DeliveryRadiusKm,
                    location.WorkingHours.Select(workingHours => new WorkingHoursDetailResponse(
                        workingHours.DayOfWeek,
                        workingHours.OpenTime,
                        workingHours.CloseTime
                    )).ToList(),
                    location.IsActive
                );
            },
            LocationCacheKeys.Expiry,
            cancellationToken);

        if (response is null)
        {
            return Result<LocationDetailResponse>.Failure(
                "Location.NotFound",
                $"Точка с ID {query.LocationId} не найдена");
        }

        return Result<LocationDetailResponse>.Success(response);
    }
}
