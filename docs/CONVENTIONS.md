# Конвенции кодирования

## Язык

- Russian XML comments в коде
- Russian git commit prefixes
- Russian документация

## Именование

### Файлы
- `{ИмяКласса}.cs` — один класс на файл
- `{ИмяКласса}Tests.cs` — тесты для класса

### Пространства имён
```csharp
EdgeItalianPizza.{Module}.{Layer}.{Feature}
// Пример:
EdgeItalianPizza.Catalog.Domain.Products
EdgeItalianPizza.Catalog.Application.Products.CreateProduct
```

### Классы
- `ICommand`, `IQuery` — маркерные интерфейсы
- `ICommandHandler<TCommand, TResponse>` — обработчик команды
- `ValidationBehavior<TRequest, TResponse>` — behavior
- `CreateProductCommand` — команда (noun + verb)
- `CreateProductResult` — результат команды

## Паттерны

### Result Pattern
```csharp
// Правильно
return Result<T>.Success(value);
return Result<T>.Failure("Code", "Message");
return result; // implicit operator

// Неправильно
throw new BusinessException("..."); // только для критических
```

### Async Handlers
```csharp
// Правильно
public async Task<Result<TResponse>> Handle(TCommand command, CancellationToken ct)
{
    // async операции
}

// Неправильно
public Result<TResponse> Handle(TCommand command, CancellationToken ct)
{
    // синхронный код (допустимо для простых операций)
}
```

### CancellationToken
Всегда последний аргумент:
```csharp
Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken)
Task<TResponse> Handle(TRequest request, Func<Task<TResponse>> next, CancellationToken cancellationToken)
```

## Тестирование

### Структура
```
src/BuildingBlocks/EdgeItalianPizza.BuildingBlocks.Tests/
├── Behaviors/
│   ├── ValidationBehaviorTests.cs
│   └── LoggingBehaviorTests.cs
├── Results/
│   ├── ResultTests.cs
│   └── ErrorTests.cs
└── Primitives/
    └── ValueObjectTests.cs
```

### Стиль
- xUnit + FluentAssertions + NSubstitute
- Arrange — Act — Assert, разделённые пустыми строками
- Одно поведение на тестовый метод
- Имена: `Method_Scenario_ExpectedResult`

### Пример
```csharp
[Fact]
public async Task Handle_WithFailingValidator_ShouldReturnFailureWithValidationErrors()
{
    // Arrange
    var validator = Substitute.For<IValidator<DummyRequest>>();
    // ...

    // Act
    var result = await behavior.Handle(request, next, CancellationToken.None);

    // Assert
    result.IsSuccess.Should().BeFalse();
}
```

## Git

### Префиксы коммитов
- `новое:` — новый функционал
- `исправление:` — багфикс
- `рефакторинг:` — рефакторинг без изменения поведения
- `тесты:` — добавление/изменение тестов
- `документация:` — документация

### Примеры
```
новое: добавлен Catalog module с Vertical Slice архитектурой
исправление: исправлена валидация Price в CreateProductCommand
рефакторинг: вынесен ValidationBehavior в BuildingBlocks
```

## Запрещено

- EF in-memory для Identity/Ordering/Payment
- MediatR — используем кастомный CQRS
- Throw для бизнес-ошибок — используем Result Pattern
- Комментарии на английском в коде
