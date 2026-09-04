using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Infrastructure.Caching;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;
using FluentAssertions;

namespace EdgeItalianPizza.Modules.Locations.IntegrationTests.Handlers;

public sealed class GetLocationByIdQueryHandlerTests : IClassFixture<TestLocationsDbContext>
{
    private readonly TestLocationsDbContext _dbContext;
    private readonly GetLocationByIdQueryHandler _handler;

    public GetLocationByIdQueryHandlerTests(TestLocationsDbContext dbContext)
    {
        _dbContext = dbContext;
        var cache = new FakeCacheService();
        _handler = new GetLocationByIdQueryHandler(dbContext, cache);
    }

    [Fact]
    public async Task ReturnsLocation_WhenExists()
    {
        // Arrange
        var location = await SeedLocation("Тестовая точка");

        // Act
        var result = await _handler.Handle(new GetLocationByIdQuery(location.Id), CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value!.Name.Should().Be("Тестовая точка");
    }

    [Fact]
    public async Task ReturnsFailure_WhenNotExists()
    {
        // Arrange
        var fakeId = Guid.NewGuid();

        // Act
        var result = await _handler.Handle(new GetLocationByIdQuery(fakeId), CancellationToken.None);

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
}
