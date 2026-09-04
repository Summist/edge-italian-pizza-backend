using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Infrastructure.Caching;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;
using FluentAssertions;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.IntegrationTests.Handlers;

public sealed class DeactivateLocationCommandHandlerTests : IClassFixture<TestLocationsDbContext>
{
    private readonly TestLocationsDbContext _dbContext;
    private readonly DeactivateLocationCommandHandler _handler;

    public DeactivateLocationCommandHandlerTests(TestLocationsDbContext dbContext)
    {
        _dbContext = dbContext;
        var cache = new FakeCacheService();
        _handler = new DeactivateLocationCommandHandler(dbContext, cache);
    }

    [Fact]
    public async Task DeactivatesLocation_Successfully()
    {
        // Arrange
        var location = await SeedLocation(isActive: true);

        // Act
        var result = await _handler.Handle(new DeactivateLocationCommand(location.Id), CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();

        var deactivated = await _dbContext.Locations
            .Find(x => x.Id == location.Id)
            .FirstOrDefaultAsync();
        deactivated!.IsActive.Should().BeFalse();
    }

    [Fact]
    public async Task ReturnsFailure_WhenNotExists()
    {
        // Arrange
        var fakeId = Guid.NewGuid();

        // Act
        var result = await _handler.Handle(new DeactivateLocationCommand(fakeId), CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Code.Should().Be("Location.NotFound");
    }

    private async Task<Location> SeedLocation(bool isActive)
    {
        var location = new Location
        {
            Name = "Тестовая точка",
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
            IsActive = isActive
        };

        await _dbContext.Locations.InsertOneAsync(location);
        return location;
    }
}
