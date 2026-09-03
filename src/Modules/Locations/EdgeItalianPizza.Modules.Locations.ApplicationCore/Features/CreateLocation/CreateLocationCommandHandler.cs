using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Infrastructure.Caching;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Обработчик команды создания точки.
/// </summary>
internal sealed class CreateLocationCommandHandler(
    ILocationsDbContext dbContext,
    ICacheService cache) : ICommandHandler<CreateLocationCommand, CreateLocationResult>
{
    public async Task<Result<CreateLocationResult>> Handle(
        CreateLocationCommand command,
        CancellationToken cancellationToken)
    {
        var location = new Location
        {
            Name = command.Name,
            City = command.City,
            Address = command.Address,
            Latitude = command.Latitude,
            Longitude = command.Longitude,
            DeliveryRadiusKm = command.DeliveryRadiusKm,
            WorkingHours = command.WorkingHours.Select(workingHours => new WorkingHours
            {
                DayOfWeek = workingHours.DayOfWeek,
                OpenTime = workingHours.OpenTime,
                CloseTime = workingHours.CloseTime
            }).ToList(),
            IsActive = true
        };

        await dbContext.Locations.InsertOneAsync(location, cancellationToken: cancellationToken);

        await cache.RemoveAsync(LocationCacheKeys.All, cancellationToken);

        return Result<CreateLocationResult>.Success(new CreateLocationResult(location.Id));
    }
}
