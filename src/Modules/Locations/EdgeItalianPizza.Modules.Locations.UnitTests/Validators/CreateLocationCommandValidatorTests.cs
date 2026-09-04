using EdgeItalianPizza.Modules.Locations.ApplicationCore.Domain;
using EdgeItalianPizza.Modules.Locations.ApplicationCore.Features;
using FluentAssertions;

namespace EdgeItalianPizza.Modules.Locations.UnitTests.Validators;

public sealed class CreateLocationCommandValidatorTests
{
    private readonly CreateLocationCommandValidator _validator = new();

    [Fact]
    public void ValidCommand_PassesValidation()
    {
        // Arrange
        var command = CreateValidCommand();

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void EmptyName_FailsValidation()
    {
        // Arrange
        var command = CreateValidCommand() with { Name = string.Empty };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "Name");
    }

    [Fact]
    public void NameExceedsMaxLength_FailsValidation()
    {
        // Arrange
        var command = CreateValidCommand() with { Name = new string('a', LocationConstraints.NameMaxLength + 1) };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "Name");
    }

    [Fact]
    public void EmptyCity_FailsValidation()
    {
        // Arrange
        var command = CreateValidCommand() with { City = string.Empty };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "City");
    }

    [Fact]
    public void CityExceedsMaxLength_FailsValidation()
    {
        // Arrange
        var command = CreateValidCommand() with { City = new string('a', LocationConstraints.CityMaxLength + 1) };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "City");
    }

    [Fact]
    public void EmptyAddress_FailsValidation()
    {
        // Arrange
        var command = CreateValidCommand() with { Address = string.Empty };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "Address");
    }

    [Fact]
    public void AddressExceedsMaxLength_FailsValidation()
    {
        // Arrange
        var command = CreateValidCommand() with { Address = new string('a', LocationConstraints.AddressMaxLength + 1) };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "Address");
    }

    [Fact]
    public void LatitudeOutOfRange_FailsValidation()
    {
        // Arrange
        var command = CreateValidCommand() with { Latitude = 91 };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "Latitude");
    }

    [Fact]
    public void LongitudeOutOfRange_FailsValidation()
    {
        // Arrange
        var command = CreateValidCommand() with { Longitude = 181 };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "Longitude");
    }

    [Fact]
    public void DeliveryRadiusZero_FailsValidation()
    {
        // Arrange
        var command = CreateValidCommand() with { DeliveryRadiusKm = 0 };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "DeliveryRadiusKm");
    }

    [Fact]
    public void EmptyWorkingHours_FailsValidation()
    {
        // Arrange
        var command = CreateValidCommand() with { WorkingHours = [] };

        // Act
        var result = _validator.Validate(command);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.PropertyName == "WorkingHours");
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
            new(DayOfWeek.Monday, new TimeOnly(9, 0), new TimeOnly(21, 0))
        ]);
}
