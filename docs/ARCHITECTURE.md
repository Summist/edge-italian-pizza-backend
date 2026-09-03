# Архитектура Edge Italian Pizza

## Обзор

Модульный монолит — один процесс, один API проект. Общение между модулями через интерфейсы в памяти (фасады) и события через MassTransit + RabbitMQ.

## Принципы

1. **Модульная изоляция** — каждый модуль не знает о внутренях другого
2. **Чистый домен** — Domain без зависимостей от инфраструктуры
3. **Result Pattern** — бизнес-ошибки через Result, исключения только для критических
4. **CQRS** — разделение команд и запросов
5. **Pipeline Behaviors** — кросс-концерны (валидация, логирование) через цепочку

## BuildingBlocks

Общая инфраструктура для всех модулей.

### Primitives

- **EntityBase** — Guid v7 (sortable), CreatedAtUtc, UpdatedAtUtc?
- **ValueObject** — абстрактный базовый с GetEqualityComponents()

### CQRS

```csharp
// Команда
public interface ICommand;
public interface ICommand<TResponse>;

// Запрос
public interface IQuery<TResponse>;

// Обработчики — автоматически возвращают Result
public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task<Result> Handle(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
}

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
}
```

### Result Pattern

```csharp
// Успех
var result = Result.Success();
var result = Result<string>.Success("value");
Result<string> result = "value"; // implicit operator

// Ошибка
var result = Result.Failure("NotFound", "Not found");
var result = Result<string>.Failure(error);

// Ошибки валидации
var error = new Error("Validation.Error", "Validation failed", validationErrors);
// error.ValidationErrors = { "Name": ["Ошибка"], "Price": ["Ошибка"] }
```

### Pipeline Behaviors

```csharp
public interface IPipelineBehavior<in TRequest, TResponse>
{
    Task<TResponse> Handle(TRequest request, Func<Task<TResponse>> next, CancellationToken cancellationToken);
}
```

Порядок: Logging → Validation → Handler

### DI Registration

```csharp
services.AddBuildingBlocks(typeof(Program).Assembly);
```

Scrutor сканирует сборку и регистрирует:
- ICommandHandler<,>, ICommandHandler<>
- IQueryHandler<,>
- IValidator<>
- IPipelineBehavior<,>

## Модули

### Catalog (Vertical Slice + MongoDB)

Каждая фича — отдельный folder:
```
Features/Products/CreateProduct/
├── CreateProductCommand.cs
├── CreateProductCommandHandler.cs
├── CreateProductCommandValidator.cs
├── CreateProductEndpoint.cs
└── CreateProductResult.cs
```

### Users (Clean Architecture + PostgreSQL)

Слои:
- Domain — бизнес-логика
- Application — интерфейсы, use cases
- Persistence — EF Core, PostgreSQL

### Inventory (Layered + PostgreSQL)

Паттерн Repository + Unit of Work.

## Хранилища

| Модуль | Хранилище | Почему |
|--------|-----------|--------|
| Catalog | MongoDB | Денormalized product data |
| Users | PostgreSQL | Транзакционные данные |
| Locations | MongoDB | Простые документы |
| Inventory | PostgreSQL | Транзакционные остатки |
| Basket | Redis | Высокочастотные reads/writes |

## Межмодульное общение

### Outbox Pattern (MassTransit)

1. Модуль пишет данные в БД + событие в Outbox (одна транзакция)
2. Background job публикует событие в RabbitMQ
3. Если приложение упало — событие осталось в Outbox

### Saga Pattern (planned)

Orchestration для сложных workflow:
OrderCreated → ReserveInventory → ProcessPayment → DeliverOrder

## Тестирование

- Unit tests — per-module рядом с src
- Behaviors — xUnit + FluentAssertions + NSubstitute
- Arch tests — NetArchTest (planned)

Подробнее: [tests/README.md](../tests/README.md)
