using EdgeItalianPizza.Modules.Locations.ApplicationCore;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Testcontainers.MongoDb;

namespace EdgeItalianPizza.Modules.Locations.IntegrationTests;

public sealed class TestLocationsDbContext : ILocationsDbContext, IAsyncLifetime
{
    private readonly MongoDbContainer _container = new MongoDbBuilder()
        .WithImage("mongo:7")
        .Build();

    public IMongoCollection<Location> Locations { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        await _container.StartAsync();

        InitializeMongo();

        var client = new MongoClient(_container.GetConnectionString());
        var database = client.GetDatabase("test_locations");
        Locations = database.GetCollection<Location>("locations");

        await Locations.DeleteManyAsync(FilterDefinition<Location>.Empty);
    }

    public async Task DisposeAsync()
    {
        await _container.DisposeAsync();
    }

    private static volatile bool _initialized;

    private static void InitializeMongo()
    {
        if (_initialized) return;

        var pack = new ConventionPack
        {
            new CamelCaseElementNameConvention(),
            new IgnoreExtraElementsConvention(true)
        };

        ConventionRegistry.Register("EdgeItalianPizzaConventions", pack, _ => true);
        BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));
        BsonSerializer.RegisterSerializer(new DecimalSerializer(BsonType.Decimal128));

        _initialized = true;
    }
}
