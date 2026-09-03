using EdgeItalianPizza.BuildingBlocks.Primitives;
using FluentAssertions;

namespace EdgeItalianPizza.BuildingBlocks.Tests.Primitives;

public sealed class ValueObjectTests
{
    [Fact]
    public void ValueObject_SameComponents_ShouldBeEqual()
    {
        // Arrange
        var vo1 = new TestValueObject("Name", 42);
        var vo2 = new TestValueObject("Name", 42);

        // Act & Assert
        vo1.Should().Be(vo2);
        (vo1 == vo2).Should().BeTrue();
    }

    [Fact]
    public void ValueObject_DifferentComponents_ShouldNotBeEqual()
    {
        // Arrange
        var vo1 = new TestValueObject("Name", 42);
        var vo2 = new TestValueObject("Name", 43);

        // Act & Assert
        vo1.Should().NotBe(vo2);
        (vo1 != vo2).Should().BeTrue();
    }

    [Fact]
    public void ValueObject_Null_ShouldNotBeEqual()
    {
        // Arrange
        var vo = new TestValueObject("Name", 42);

        // Act & Assert
        vo.Equals(null).Should().BeFalse();
    }

    [Fact]
    public void ValueObject_DifferentType_ShouldNotBeEqual()
    {
        // Arrange
        var vo = new TestValueObject("Name", 42);
        var other = "Name";

        // Act & Assert
        vo.Equals(other).Should().BeFalse();
    }

    [Fact]
    public void ValueObject_SameComponents_ShouldHaveSameHashCode()
    {
        // Arrange
        var vo1 = new TestValueObject("Name", 42);
        var vo2 = new TestValueObject("Name", 42);

        // Act & Assert
        vo1.GetHashCode().Should().Be(vo2.GetHashCode());
    }

    private sealed class TestValueObject(string name, int count) : ValueObject
    {
        public override IEnumerable<object?> GetEqualityComponents()
        {
            yield return name;
            yield return count;
        }
    }
}
