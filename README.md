# Edge Italian Pizza

Бэкенд для сети пиццерий в стиле Dodo Pizza.

## О проекте

Модульный монолит на .NET 10. Одна сеть, множество точек, общий каталог.

## Стек

- .NET 10.0
- MongoDB, PostgreSQL, Redis
- RabbitMQ + MassTransit
- Serilog, FluentValidation, Scrutor

## Модули

| Модуль | Хранилище | Статус |
|--------|-----------|--------|
| Catalog | MongoDB | в разработке |
| Users | PostgreSQL | в разработке |
| Locations | MongoDB | в разработке |
| Inventory | PostgreSQL | в разработке |
| Basket | Redis | в разработке |
| Orders | PostgreSQL | планы |
| Payment | MongoDB + PostgreSQL | планы |
| Delivery | MongoDB | планы |

## Запуск

```bash
dotnet restore
dotnet build
dotnet test
```

## Лицензия

MIT
