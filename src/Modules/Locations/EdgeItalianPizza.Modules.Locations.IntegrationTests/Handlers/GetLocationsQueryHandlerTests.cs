using EdgeItalianPizza.BuildingBlocks.Results;
using EdgeItalianPizza.Infrastructure.Caching;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;
using FluentAssertions;
using MongoDB.Driver;

namespace EdgeItalianPizza.Modules.Locations.IntegrationTests.Handlers;

public sealed class GetLocationsQueryHandlerTests : IClassFixture<TestLocationsDbContext>
{
    private readonly TestLocationsDbContext _dbContext;
    private readonly GetLocationsQueryHandler _handler;

    public GetLocationsQueryHandlerTests(TestLocationsDbContext dbContext)
    {
        _dbContext = dbContext;
        var cache = new FakeCacheService();
        _handler = new GetLocationsQueryHandler(dbContext, cache);
    }

    [Fact]
    public async Task ReturnsLocations_FromDb()
    {
        // Arrange
        await SeedLocations(3);

        // Act
        var result = await _handler.Handle(new GetLocationsQuery(), CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().HaveCount(3);
    }

    [Fact]
    public async Task ReturnsEmptyList_WhenNoData()
    {
        // Arrange
        await _dbContext.Locations.DeleteManyAsync(FilterDefinition<Location>.Empty);

        // Act
        var result = await _handler.Handle(new GetLocationsQuery(), CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEmpty();
    }

    private async Task SeedLocations(int count)
    {
        var locations = Enumerable.Range(0, count)
            .Select(i => new Location
            {
                Name = $"Точка {i}",
                City = "Москва",
                Address = $"ул. Тестовая, {i}",
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
            })
            .ToList();

        await _dbContext.Locations.InsertManyAsync(locations);
    }
}
