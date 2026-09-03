using EdgeItalianPizza.BuildingBlocks.Results;
using FluentAssertions;

namespace EdgeItalianPizza.BuildingBlocks.Tests.Results;

public sealed class ResultTests
{
    [Fact]
    public void Result_Success_ShouldHaveIsSuccessTrue()
    {
        // Arrange & Act
        var result = Result.Success();

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().Be(Error.None);
    }

    [Fact]
    public void Result_FailureWithError_ShouldHaveIsSuccessFalse()
    {
        // Arrange
        var error = new Error("NotFound", "Resource not found");

        // Act
        var result = Result.Failure(error);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Should().Be(error);
    }

    [Fact]
    public void Result_FailureWithCodeAndMessage_ShouldCreateError()
    {
        // Arrange & Act
        var result = Result.Failure("Conflict", "Already exists");

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Code.Should().Be("Conflict");
        result.Error.Message.Should().Be("Already exists");
    }

    [Fact]
    public void ResultT_Success_ShouldContainValue()
    {
        // Arrange & Act
        var result = Result<string>.Success("hello");

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("hello");
        result.Error.Should().Be(Error.None);
    }

    [Fact]
    public void ResultT_Failure_ShouldNotContainValue()
    {
        // Arrange
        var error = new Error("NotFound", "Not found");

        // Act
        var result = Result<string>.Failure(error);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        result.Error.Should().Be(error);
    }

    [Fact]
    public void ResultT_ImplicitConversion_ShouldCreateSuccess()
    {
        // Arrange & Act
        Result<string> result = "test";

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("test");
    }
}
