using EdgeItalianPizza.Infrastructure.Caching;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace EdgeItalianPizza.Infrastructure.Tests.Caching;

public sealed class InMemoryCacheServiceTests : IDisposable
{
    private readonly ICacheService _cache;
    private readonly ServiceProvider _serviceProvider;

    public InMemoryCacheServiceTests()
    {
        var services = new ServiceCollection();
        services.AddMemoryCache();
        services.AddDistributedMemoryCache();
        services.AddSingleton<ICacheService, RedisCacheService>();

        _serviceProvider = services.BuildServiceProvider();
        _cache = _serviceProvider.GetRequiredService<ICacheService>();
    }

    public void Dispose()
    {
        _serviceProvider.Dispose();
    }

    [Fact]
    public async Task GetAsync_KeyExists_ReturnsValue()
    {
        // Arrange
        var key = "test:key";
        var value = new TestValue("hello", 42);
        await _cache.SetAsync(key, value);

        // Act
        var result = await _cache.GetAsync<TestValue>(key);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("hello");
        result.Number.Should().Be(42);
    }

    [Fact]
    public async Task GetAsync_KeyNotExists_ReturnsNull()
    {
        // Arrange
        var key = "test:nonexistent";

        // Act
        var result = await _cache.GetAsync<TestValue>(key);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task SetAsync_StoresValue_CanRetrieve()
    {
        // Arrange
        var key = "test:set";
        var value = new TestValue("world", 100);

        // Act
        await _cache.SetAsync(key, value);
        var result = await _cache.GetAsync<TestValue>(key);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("world");
        result.Number.Should().Be(100);
    }

    [Fact]
    public async Task RemoveAsync_ExistingKey_RemovesValue()
    {
        // Arrange
        var key = "test:remove";
        await _cache.SetAsync(key, new TestValue("data", 1));

        // Act
        await _cache.RemoveAsync(key);
        var result = await _cache.GetAsync<TestValue>(key);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetOrAddAsync_KeyExists_ReturnsCachedValue()
    {
        // Arrange
        var key = "test:oradd";
        var original = new TestValue("original", 1);
        await _cache.SetAsync(key, original);

        var factoryCalled = false;

        // Act
        var result = await _cache.GetOrAddAsync(key, ct =>
        {
            factoryCalled = true;
            return Task.FromResult<TestValue?>(new TestValue("new", 2));
        });

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("original");
        result.Number.Should().Be(1);
        factoryCalled.Should().BeFalse();
    }

    [Fact]
    public async Task GetOrAddAsync_KeyNotExists_CallsFactoryAndCaches()
    {
        // Arrange
        var key = "test:oradd:new";
        var factoryValue = new TestValue("factory", 99);

        // Act
        var result = await _cache.GetOrAddAsync(key, ct =>
        {
            return Task.FromResult<TestValue?>(factoryValue);
        });

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("factory");
        result.Number.Should().Be(99);

        // Verify it was cached
        var cached = await _cache.GetAsync<TestValue>(key);
        cached.Should().NotBeNull();
        cached!.Name.Should().Be("factory");
    }

    [Fact]
    public async Task GetOrAddAsync_FactoryReturnsNull_DoesNotCache()
    {
        // Arrange
        var key = "test:oradd:null";

        // Act
        var result = await _cache.GetOrAddAsync(key, ct =>
        {
            return Task.FromResult<TestValue?>(null);
        });

        // Assert
        result.Should().BeNull();

        // Verify it was not cached
        var cached = await _cache.GetAsync<TestValue>(key);
        cached.Should().BeNull();
    }

    private sealed record TestValue(string Name, int Number);
}
