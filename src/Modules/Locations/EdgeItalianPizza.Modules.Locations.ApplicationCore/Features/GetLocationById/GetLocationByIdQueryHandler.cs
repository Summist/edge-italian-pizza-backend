using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Обработчик запроса получения точки по ID.
/// </summary>
internal sealed class GetLocationByIdQueryHandler(ILocationsDbContext dbContext)
    : IQueryHandler<GetLocationByIdQuery, LocationDetailResponse>
{
    public async Task<Result<LocationDetailResponse>> Handle(
        GetLocationByIdQuery query,
        CancellationToken cancellationToken)
    {
        var location = await dbContext.Locations
            .Find(x => x.Id == query.LocationId)
            .FirstOrDefaultAsync(cancellationToken);

        if (location is null)
        {
            return Result<LocationDetailResponse>.Failure(
                "Location.NotFound",
                $"Точка с ID {query.LocationId} не найдена");
        }

        var response = new LocationDetailResponse(
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

        return Result<LocationDetailResponse>.Success(response);
    }
}
