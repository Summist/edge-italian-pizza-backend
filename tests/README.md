# Тесты Edge Italian Pizza

## Стратегия

### Unit tests (per-module)

Расположены рядом с кодом модуля:
```
src/BuildingBlocks/EdgeItalianPizza.BuildingBlocks.Tests/
src/Modules/Catalog/EdgeItalianPizza.Catalog.Tests/
src/Modules/Users/EdgeItalianPizza.Users.Tests/
```

### Integration tests (planned)

Тесты с реальными хранилищами через Testcontainers.

### E2E tests (planned)

Playwright для полного цикла.

## Стек

| Компонент | Версия |
|-----------|--------|
| xUnit | 2.9.2 |
| FluentAssertions | 6.12.2 |
| NSubstitute | 5.3.0 |
| coverlet | 6.0.2 |

## Запуск

```bash
# Все тесты
dotnet test

# Тесты BuildingBlocks
dotnet test src/BuildingBlocks/EdgeItalianPizza.BuildingBlocks.Tests

# Конкретный тест
dotnet test --filter "FullyQualifiedName~ValidationBehaviorTests"
```

## Структура тестов

```
EdgeItalianPizza.BuildingBlocks.Tests/
├── Behaviors/
│   ├── ValidationBehaviorTests.cs   — 5 тестов
│   └── LoggingBehaviorTests.cs      — 3 теста
├── Results/
│   ├── ResultTests.cs               — 6 тестов
│   └── ErrorTests.cs                — 4 теста
└── Primitives/
    └── ValueObjectTests.cs          — 5 тестов
```

## Конвенции тестов

### Arrange — Act — Assert

```csharp
[Fact]
public async Task Method_Scenario_ExpectedResult()
{
    // Arrange
    var behavior = new ValidationBehavior<...>(validators);

    // Act
    var result = await behavior.Handle(request, next, ct);

    // Assert
    result.IsSuccess.Should().BeTrue();
}
```

### Имена методов

`{Method}_{Scenario}_{ExpectedResult}`

Примеры:
- `Handle_WithFailingValidator_ShouldReturnFailureWithValidationErrors`
- `Result_Success_ShouldHaveIsSuccessTrue`
- `ValueObject_DifferentComponents_ShouldNotBeEqual`

### Mocking

```csharp
var validator = Substitute.For<IValidator<DummyRequest>>();
validator
    .Validate(Arg.Any<ValidationContext<DummyRequest>>())
    .Returns(new ValidationResult());
```

## Coverage

```bash
dotnet test --collect:"XPlat Code Coverage"
```

Целевой показатель: 85% line coverage на Domain + BuildingBlocks.
