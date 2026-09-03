using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson.Serialization.Serializers;

namespace EdgeItalianPizza.Modules.Locations.Persistence.MongoDb;

/// <summary>
/// Инициализатор MongoDB — регистрация конвенций и сериализаторов.
/// Вызывается один раз при первом обращении к контексту.
/// </summary>
internal static class MongoInitializer
{
    private static volatile bool _initialized;
    private static readonly Lock _lock = new();

    /// <summary>
    /// Инициализирует MongoDB конвенции и сериализаторы.
    /// Потокобезопасно — выполняется только один раз.
    /// </summary>
    public static void Initialize()
    {
        if (_initialized) return;

        lock (_lock)
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
}
