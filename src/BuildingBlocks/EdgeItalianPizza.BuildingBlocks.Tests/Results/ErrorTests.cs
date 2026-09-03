using EdgeItalianPizza.BuildingBlocks.Results;
using FluentAssertions;

namespace EdgeItalianPizza.BuildingBlocks.Tests.Results;

public sealed class ErrorTests
{
    [Fact]
    public void Error_None_ShouldHaveEmptyCodeAndMessage()
    {
        // Arrange & Act
        var error = Error.None;

        // Assert
        error.Code.Should().BeEmpty();
        error.Message.Should().BeEmpty();
    }

    [Fact]
    public void Error_WithCodeAndMessage_ShouldSetProperties()
    {
        // Arrange & Act
        var error = new Error("NotFound", "Resource not found");

        // Assert
        error.Code.Should().Be("NotFound");
        error.Message.Should().Be("Resource not found");
        error.ValidationErrors.Should().BeNull();
    }

    [Fact]
    public void Error_WithValidationErrors_ShouldSetProperty()
    {
        // Arrange
        var validationErrors = new Dictionary<string, string[]>
        {
            ["Name"] = ["Name is required"],
            ["Price"] = ["Price must be > 0"]
        };

        // Act
        var error = new Error("Validation.Error", "Validation failed", validationErrors);

        // Assert
        error.Code.Should().Be("Validation.Error");
        error.Message.Should().Be("Validation failed");
        error.ValidationErrors.Should().ContainKey("Name");
        error.ValidationErrors!["Name"].Should().Contain("Name is required");
        error.ValidationErrors.Should().ContainKey("Price");
        error.ValidationErrors["Price"].Should().Contain("Price must be > 0");
    }

    [Fact]
    public void Error_EqualValues_ShouldBeEqual()
    {
        // Arrange
        var error1 = new Error("Code", "Message");
        var error2 = new Error("Code", "Message");

        // Act & Assert
        error1.Should().Be(error2);
        (error1 == error2).Should().BeTrue();
    }
}
