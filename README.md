# Edge Italian Pizza

![C#](https://img.shields.io/badge/C%23-2395F1?style=flat&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-47A248?style=flat&logo=mongodb&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=flat&logo=postgresql&logoColor=white)
![Redis](https://img.shields.io/badge/Redis-DC382D?style=flat&logo=redis&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=flat&logo=docker&logoColor=white)
![RabbitMQ](https://img.shields.io/badge/RabbitMQ-FF6600?style=flat&logo=rabbitmq&logoColor=white)

Бэкенд для сети пиццерий в стиле Dodo Pizza.
Модульный монолит на .NET 10 — одна сеть, множество точек, общий каталог.

## Стек

| Технология | Назначение |
|------------|------------|
| .NET 10.0 | Рантайм |
| MongoDB | Catalog, Locations |
| PostgreSQL | Users, Inventory |
| Redis | Basket, кэширование |
| RabbitMQ + MassTransit | Межмодульное общение |
| Serilog | Логирование |
| FluentValidation | Валидация |
| Scrutor | DI-регистрация |

## Структура проекта

```
EdgeItalianPizza/
├── BuildingBlocks/              # Общая инфраструктура
│   ├── Primitives/              # EntityBase, ValueObject
│   ├── CQRS/                    # ICommand, IQuery, Handlers
│   ├── Results/                 # Result Pattern
│   ├── Behaviors/               # Pipeline (Validation, Logging)
│   └── DI/                      # Scrutor-регистрация
├── Infrastructure/
│   └── Infrastructure/          # ICacheService, RedisCacheService
├── Modules/
│   ├── Catalog/                 # Vertical Slice + MongoDB
│   │   └── Domain/              # Pizza, Sauce, Product, Ingredient
│   ├── Users/                   # Clean Architecture + PostgreSQL
│   │   └── Domain/              # User, UserRole, UserSession
│   ├── Locations/               # Vertical Slice + MongoDB
│   │   ├── ApplicationCore/     # Domain, Features, ILocationModule
│   │   ├── Persistence.MongoDb/ # LocationsDbContext, MongoInitializer
│   │   ├── UnitTests/           # Валидаторы
│   │   └── IntegrationTests/    # Testcontainers MongoDB
│   ├── Inventory/               # Layered + PostgreSQL
│   │   └── Domain/              # StockItem, StockMovement
│   └── Basket/                  # Redis
│       └── Domain/
├── docker/                      # Docker инфраструктура
│   ├── docker-compose.yml       # MongoDB + Redis (разработка)
│   ├── docker-compose.test.yml  # MongoDB + Redis (тесты)
│   ├── docker-compose.prod.yml  # API + MongoDB + Redis (продакшн)
│   └── Dockerfile               # Multistage сборка
└── docs/
    ├── ARCHITECTURE.md          # Архитектура
    └── CONVENTIONS.md           # Конвенции кодирования
```

## Быстрый старт

### Без Docker

```bash
git clone https://github.com/Summist/edge-italian-pizza-backend.git
cd edge-italian-pizza-backend/backend/EdgeItalianPizza
dotnet restore
dotnet build
dotnet test
```

### С Docker (рекомендуется)

```bash
git clone https://github.com/Summist/edge-italian-pizza-backend.git
cd edge-italian-pizza-backend/backend/EdgeItalianPizza/docker
docker-compose up -d

# В другом терминале
cd ../EdgeItalianPizza
dotnet watch --project src/Modules/Locations/EdgeItalianPizza.Modules.Locations.Persistence.MongoDb
```

## Docker

| Команда | Назначение |
|---------|------------|
| `docker-compose up -d` | Запуск MongoDB + Redis |
| `docker-compose down` | Остановка сервисов |
| `docker-compose down -v` | Остановка + очистка данных |
| `docker-compose -f docker-compose.test.yml up -d` | Сервисы для тестов |
| `docker-compose -f docker-compose.prod.yml up -d` | Полный стек (продакшн) |

Подробнее: [docker/README.md](docker/README.md)

## Тесты

### Unit тесты (без Docker)

```bash
dotnet test --filter "FullyQualifiedName~UnitTests"
```

### Integration тесты (Docker + Testcontainers)

```bash
dotnet test --filter "FullyQualifiedName~IntegrationTests"
```

### Все тесты

```bash
dotnet test
```

## Модули

| Модуль | Архитектура | Хранилище | Статус |
|--------|-------------|-----------|--------|
| BuildingBlocks | Shared | — | готов |
| Infrastructure | Shared | Redis | готов |
| Locations | Vertical Slice | MongoDB | готов (21 тест) |
| Catalog | Vertical Slice | MongoDB | в разработке |
| Users | Clean Architecture | PostgreSQL | в разработке |
| Inventory | Layered | PostgreSQL | в разработке |
| Basket | — | Redis | в разработке |
| Orders | — | PostgreSQL | планы |
| Payment | — | MongoDB + PostgreSQL | планы |
| Delivery | — | MongoDB | планы |

## Архитектура

Подробнее: [docs/ARCHITECTURE.md](docs/ARCHITECTURE.md)

## Конвенции

Подробнее: [docs/CONVENTIONS.md](docs/CONVENTIONS.md)
