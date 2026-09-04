using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Infrastructure.Caching;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;
using FluentAssertions;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.IntegrationTests.Handlers;

public sealed class UpdateLocationCommandHandlerTests : IClassFixture<TestLocationsDbContext>
{
    private readonly TestLocationsDbContext _dbContext;
    private readonly UpdateLocationCommandHandler _handler;

    public UpdateLocationCommandHandlerTests(TestLocationsDbContext dbContext)
    {
        _dbContext = dbContext;
        var cache = new FakeCacheService();
        _handler = new UpdateLocationCommandHandler(dbContext, cache);
    }

    [Fact]
    public async Task UpdatesLocation_Successfully()
    {
        // Arrange
        var location = await SeedLocation("Старое название");
        var command = CreateValidCommand(location.Id);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();

        var updated = await _dbContext.Locations
            .Find(x => x.Id == location.Id)
            .FirstOrDefaultAsync();
        updated!.Name.Should().Be("Новое название");
    }

    [Fact]
    public async Task ReturnsFailure_WhenNotExists()
    {
        // Arrange
        var command = CreateValidCommand(Guid.NewGuid());

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Code.Should().Be("Location.NotFound");
    }

    private async Task<Location> SeedLocation(string name)
    {
        var location = new Location
        {
            Name = name,
            City = "Москва",
            Address = "ул. Тестовая, 1",
            Latitude = 55.75,
            Longitude = 37.62,
            DeliveryRadiusKm = 5,
            WorkingHours =
            [
                new WorkingHours
                {
                    DayOfWeek = DayOfWeek.Monday,
                    OpenTime = new TimeOnly(9, 0),
                    CloseTime = new TimeOnly(21, 0)
                }
            ],
            IsActive = true
        };

        await _dbContext.Locations.InsertOneAsync(location);
        return location;
    }

    private static UpdateLocationCommand CreateValidCommand(Guid locationId) => new(
        LocationId: locationId,
        Name: "Новое название",
        City: "Москва",
        Address: "ул. Тестовая, 1",
        Latitude: 55.75,
        Longitude: 37.62,
        DeliveryRadiusKm: 5,
        WorkingHours:
        [
            new WorkingHoursDto(DayOfWeek.Monday, new TimeOnly(9, 0), new TimeOnly(21, 0))
        ]);
}
