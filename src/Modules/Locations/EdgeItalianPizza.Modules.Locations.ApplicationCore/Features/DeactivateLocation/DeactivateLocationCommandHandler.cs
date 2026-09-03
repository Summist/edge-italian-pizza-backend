using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Infrastructure.Caching;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Обработчик команды деактивации точки.
/// </summary>
internal sealed class DeactivateLocationCommandHandler(
    ILocationsDbContext dbContext,
    ICacheService cache) : ICommandHandler<DeactivateLocationCommand, DeactivateLocationResult>
{
    public async Task<Result<DeactivateLocationResult>> Handle(
        DeactivateLocationCommand command,
        CancellationToken cancellationToken)
    {
        var result = await dbContext.Locations.UpdateOneAsync(
            x => x.Id == command.LocationId,
            Builders<Location>.Update.Set(x => x.IsActive, false),
            cancellationToken: cancellationToken);

        if (result.MatchedCount == 0)
        {
            return Result<DeactivateLocationResult>.Failure(
                "Location.NotFound",
                $"Точка с ID {command.LocationId} не найдена");
        }

        await cache.RemoveAsync(LocationCacheKeys.All, cancellationToken);
        await cache.RemoveAsync(LocationCacheKeys.ById(command.LocationId), cancellationToken);

        return Result<DeactivateLocationResult>.Success(new DeactivateLocationResult(command.LocationId));
    }
}
