using EdgeItalianPizza.BuildingBlocks.Behaviors;
using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace EdgeItalianPizza.BuildingBlocks.Tests.Behaviors;

public sealed class LoggingBehaviorTests
{
    [Fact]
    public async Task Handle_WhenNextSucceeds_ShouldReturnResult()
    {
        // Arrange
        var logger = Substitute.For<ILogger<LoggingBehavior<DummyRequest, string>>>();
        var behavior = new LoggingBehavior<DummyRequest, string>(logger);

        // Act
        var result = await behavior.Handle(
            new DummyRequest("payload"),
            () => Task.FromResult(Result<string>.Success("ok")),
            CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("ok");
    }

    [Fact]
    public async Task Handle_WhenNextFails_ShouldReturnFailureAndLogFailed()
    {
        // Arrange
        var logger = Substitute.For<ILogger<LoggingBehavior<DummyRequest, string>>>();
        var behavior = new LoggingBehavior<DummyRequest, string>(logger);

        // Act
        var result = await behavior.Handle(
            new DummyRequest("payload"),
            () => Task.FromResult(Result<string>.Failure("NotFound", "Not found")),
            CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Code.Should().Be("NotFound");
    }

    [Fact]
    public async Task Handle_WhenNextThrows_ShouldLogErrorAndRethrow()
    {
        // Arrange
        var logger = Substitute.For<ILogger<LoggingBehavior<DummyRequest, string>>>();
        var behavior = new LoggingBehavior<DummyRequest, string>(logger);

        // Act
        var act = () => behavior.Handle(
            new DummyRequest("payload"),
            () => throw new InvalidOperationException("boom"),
            CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("boom");
    }

    public sealed record DummyRequest(string Payload) : ICommand<string>;
}
