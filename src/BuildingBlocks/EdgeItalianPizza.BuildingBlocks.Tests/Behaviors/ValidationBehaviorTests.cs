using EdgeItalianPizza.BuildingBlocks.Behaviors;
using EdgeItalianPizza.BuildingBlocks.CQRS;
using EdgeItalianPizza.BuildingBlocks.Results;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using NSubstitute;

namespace EdgeItalianPizza.BuildingBlocks.Tests.Behaviors;

public sealed class ValidationBehaviorTests
{
    [Fact]
    public async Task Handle_WithNoValidators_ShouldCallNext()
    {
        // Arrange
        var behavior = new ValidationBehavior<DummyRequest, string>(
            Array.Empty<IValidator<DummyRequest>>());

        // Act
        var result = await behavior.Handle(
            new DummyRequest(),
            () => Task.FromResult(Result<string>.Success("ok")),
            CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("ok");
    }

    [Fact]
    public async Task Handle_WithPassingValidator_ShouldCallNext()
    {
        // Arrange
        var validator = Substitute.For<IValidator<DummyRequest>>();
        validator
            .Validate(Arg.Any<ValidationContext<DummyRequest>>())
            .Returns(new ValidationResult());

        var behavior = new ValidationBehavior<DummyRequest, string>(new[] { validator });

        // Act
        var result = await behavior.Handle(
            new DummyRequest(),
            () => Task.FromResult(Result<string>.Success("ok")),
            CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("ok");
    }

    [Fact]
    public async Task Handle_WithFailingValidator_ShouldReturnFailureWithValidationErrors()
    {
        // Arrange
        var validator = Substitute.For<IValidator<DummyRequest>>();
        var validationResult = new ValidationResult(new[]
        {
            new ValidationFailure("Name", "Name is required"),
            new ValidationFailure("Price", "Price must be > 0")
        });
        validator
            .Validate(Arg.Any<ValidationContext<DummyRequest>>())
            .Returns(validationResult);

        var behavior = new ValidationBehavior<DummyRequest, string>(new[] { validator });

        // Act
        var result = await behavior.Handle(
            new DummyRequest(),
            () => Task.FromResult(Result<string>.Success("ok")),
            CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.Code.Should().Be("Validation.Error");
        result.Error.ValidationErrors.Should().ContainKey("Name");
        result.Error.ValidationErrors!["Name"].Should().Contain("Name is required");
        result.Error.ValidationErrors.Should().ContainKey("Price");
        result.Error.ValidationErrors["Price"].Should().Contain("Price must be > 0");
    }

    [Fact]
    public async Task Handle_WithMultipleFailingValidators_ShouldGroupErrorsByProperty()
    {
        // Arrange
        var validator1 = Substitute.For<IValidator<DummyRequest>>();
        var validator2 = Substitute.For<IValidator<DummyRequest>>();

        validator1
            .Validate(Arg.Any<ValidationContext<DummyRequest>>())
            .Returns(new ValidationResult(new[]
            {
                new ValidationFailure("Name", "Name is required")
            }));

        validator2
            .Validate(Arg.Any<ValidationContext<DummyRequest>>())
            .Returns(new ValidationResult(new[]
            {
                new ValidationFailure("Name", "Name must be at least 3 characters")
            }));

        var behavior = new ValidationBehavior<DummyRequest, string>(new[] { validator1, validator2 });

        // Act
        var result = await behavior.Handle(
            new DummyRequest(),
            () => Task.FromResult(Result<string>.Success("ok")),
            CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.ValidationErrors.Should().ContainKey("Name");
        result.Error.ValidationErrors!["Name"].Should().HaveCount(2);
        result.Error.ValidationErrors["Name"].Should().Contain("Name is required");
        result.Error.ValidationErrors["Name"].Should().Contain("Name must be at least 3 characters");
    }

    [Fact]
    public async Task Handle_WithMultipleValidatorsAndOneFailing_ShouldReturnOnlyFailures()
    {
        // Arrange
        var passingValidator = Substitute.For<IValidator<DummyRequest>>();
        passingValidator
            .Validate(Arg.Any<ValidationContext<DummyRequest>>())
            .Returns(new ValidationResult());

        var failingValidator = Substitute.For<IValidator<DummyRequest>>();
        failingValidator
            .Validate(Arg.Any<ValidationContext<DummyRequest>>())
            .Returns(new ValidationResult(new[]
            {
                new ValidationFailure("Price", "Price is required")
            }));

        var behavior = new ValidationBehavior<DummyRequest, string>(
            new[] { passingValidator, failingValidator });

        // Act
        var result = await behavior.Handle(
            new DummyRequest(),
            () => Task.FromResult(Result<string>.Success("ok")),
            CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeFalse();
        result.Error.ValidationErrors.Should().ContainKey("Price");
        result.Error.ValidationErrors.Should().HaveCount(1);
    }

    public sealed record DummyRequest : ICommand<string>;
}
