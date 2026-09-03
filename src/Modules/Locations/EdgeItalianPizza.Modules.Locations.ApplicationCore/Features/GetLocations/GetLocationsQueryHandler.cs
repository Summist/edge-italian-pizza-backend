using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Обработчик запроса получения списка точек.
/// </summary>
public sealed class GetLocationsQueryHandler(ILocationsDbContext dbContext)
    : IQueryHandler<GetLocationsQuery, List<LocationResponse>>
{
    public async Task<Result<List<LocationResponse>>> Handle(
        GetLocationsQuery query,
        CancellationToken cancellationToken)
    {
        var locations = await dbContext.Locations
            .Find(_ => true)
            .ToListAsync(cancellationToken);

        var responses = locations.Select(location => new LocationResponse(
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

        return Result<List<LocationResponse>>.Success(responses);
    }
}
