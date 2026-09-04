using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Infrastructure.Caching;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;
using FluentAssertions;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.IntegrationTests.Handlers;

public sealed class CreateLocationCommandHandlerTests : IClassFixture<TestLocationsDbContext>
{
    private readonly TestLocationsDbContext _dbContext;
    private readonly CreateLocationCommandHandler _handler;

    public CreateLocationCommandHandlerTests(TestLocationsDbContext dbContext)
    {
        _dbContext = dbContext;
        var cache = new FakeCacheService();
        _handler = new CreateLocationCommandHandler(dbContext, cache);
    }

    [Fact]
    public async Task CreatesLocation_Successfully()
    {
        // Arrange
        var command = CreateValidCommand();

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value!.LocationId.Should().NotBe(Guid.Empty);

        var location = await _dbContext.Locations
            .Find(x => x.Id == result.Value.LocationId)
            .FirstOrDefaultAsync();
        location.Should().NotBeNull();
        location!.Name.Should().Be("Тестовая точка");
        location.IsActive.Should().BeTrue();
    }

    [Fact]
    public async Task CreatesLocation_WithCorrectFields()
    {
        // Arrange
        var command = CreateValidCommand();

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        var location = await _dbContext.Locations
            .Find(x => x.Id == result.Value!.LocationId)
            .FirstOrDefaultAsync();

        location!.City.Should().Be("Москва");
        location.Address.Should().Be("ул. Тестовая, 1");
        location.Latitude.Should().Be(55.75);
        location.Longitude.Should().Be(37.62);
        location.DeliveryRadiusKm.Should().Be(5);
        location.WorkingHours.Should().HaveCount(1);
    }

    private static CreateLocationCommand CreateValidCommand() => new(
        Name: "Тестовая точка",
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
