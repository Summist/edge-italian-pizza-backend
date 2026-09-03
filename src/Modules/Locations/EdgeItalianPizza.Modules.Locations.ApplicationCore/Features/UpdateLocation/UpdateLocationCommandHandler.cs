using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Infrastructure.Caching;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Обработчик команды обновления точки.
/// </summary>
internal sealed class UpdateLocationCommandHandler(
    ILocationsDbContext dbContext,
    ICacheService cache) : ICommandHandler<UpdateLocationCommand, UpdateLocationResult>
{
    public async Task<Result<UpdateLocationResult>> Handle(
        UpdateLocationCommand command,
        CancellationToken cancellationToken)
    {
        var workingHours = command.WorkingHours.Select(workingHours => new WorkingHours
        {
            DayOfWeek = workingHours.DayOfWeek,
            OpenTime = workingHours.OpenTime,
            CloseTime = workingHours.CloseTime
        }).ToList();

        var update = Builders<Location>.Update
            .Set(x => x.Name, command.Name)
            .Set(x => x.City, command.City)
            .Set(x => x.Address, command.Address)
            .Set(x => x.Latitude, command.Latitude)
            .Set(x => x.Longitude, command.Longitude)
            .Set(x => x.DeliveryRadiusKm, command.DeliveryRadiusKm)
            .Set(x => x.WorkingHours, workingHours);

        var result = await dbContext.Locations.UpdateOneAsync(
            x => x.Id == command.LocationId,
            update,
            cancellationToken: cancellationToken);

        if (result.MatchedCount == 0)
        {
            return Result<UpdateLocationResult>.Failure(
                "Location.NotFound",
                $"Точка с ID {command.LocationId} не найдена");
        }

        await cache.RemoveAsync(LocationCacheKeys.All, cancellationToken);
        await cache.RemoveAsync(LocationCacheKeys.ById(command.LocationId), cancellationToken);

        return Result<UpdateLocationResult>.Success(new UpdateLocationResult(command.LocationId));
    }
}
