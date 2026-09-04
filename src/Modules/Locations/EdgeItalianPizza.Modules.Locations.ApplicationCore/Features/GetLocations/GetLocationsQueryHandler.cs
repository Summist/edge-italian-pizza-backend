using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Infrastructure.Caching;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Обработчик запроса получения списка точек.
/// </summary>
internal sealed class GetLocationsQueryHandler(
    ILocationsDbContext dbContext,
    ICacheService cache) : IQueryHandler<GetLocationsQuery, IReadOnlyList<LocationResponse>>
{
    public async Task<Result<IReadOnlyList<LocationResponse>>> Handle(
        GetLocationsQuery query,
        CancellationToken cancellationToken)
    {
        var responses = await cache.GetOrAddAsync(
            LocationCacheKeys.All,
            async cancellationToken =>
            {
                var locations = await dbContext.Locations
                    .Find(location => location.IsActive)
                    .ToListAsync(cancellationToken);

                return locations.Select(location => new LocationResponse(
                    location.Id,
                    location.Name,
                    location.City,
                    location.Address,
                    location.Latitude,
                    location.Longitude,
                    location.DeliveryRadiusKm,
                    location.WorkingHours.Select(workingHours => new WorkingHoursResponse(
                        workingHours.DayOfWeek,
                        workingHours.OpenTime,
                        workingHours.CloseTime
                    )).ToList(),
                    location.IsActive
                )).ToList();
            },
            LocationCacheKeys.Expiry,
            cancellationToken);

        return Result<IReadOnlyList<LocationResponse>>.Success(responses!);
    }
}
