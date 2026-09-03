using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;

namespace EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;

/// <summary>
/// Обработчик команды создания точки.
/// </summary>
public sealed class CreateLocationCommandHandler(ILocationsDbContext dbContext)
    : ICommandHandler<CreateLocationCommand, CreateLocationResult>
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
            WorkingHours = command.WorkingHours.Select(wh => new WorkingHours
            {
                DayOfWeek = wh.DayOfWeek,
                OpenTime = wh.OpenTime,
                CloseTime = wh.CloseTime
            }).ToList(),
            IsActive = true
        };

        await dbContext.Locations.InsertOneAsync(location, cancellationToken: cancellationToken);

        return Result<CreateLocationResult>.Success(new CreateLocationResult(location.Id));
    }
}
