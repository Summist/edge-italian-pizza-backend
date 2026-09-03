# Docker — Edge Italian Pizza

## Структура

| Файл | Назначение |
|------|------------|
| docker-compose.yml | MongoDB + Redis для локальной разработки |
| docker-compose.test.yml | MongoDB + Redis для integration тестов |
| docker-compose.prod.yml | API + MongoDB + Redis (продакшн) |
| Dockerfile | Multistage сборка API |
| .dockerignore | Исключения для сборки |

---

## 1. Локальная разработка

### Запуск сервисов

```bash
cd docker
docker-compose up -d
```

### Проверка

```bash
docker-compose ps
```

### Запуск API (Hot Reload)

```bash
cd ../EdgeItalianPizza
dotnet watch --project src/Modules/Locations/EdgeItalianPizza.Modules.Locations.Persistence.MongoDb
```

### Остановка

```bash
cd docker
docker-compose down
```

### Очистка данных

```bash
docker-compose down -v
```

---

## 2. Integration тесты

### Вариант A: Testcontainers (рекомендуется)

Testcontainers автоматически поднимает MongoDB в Docker.
Docker должен быть запущен.

```bash
dotnet test --filter "FullyQualifiedName~IntegrationTests"
```

### Вариант B: docker-compose.test.yml

```bash
cd docker
docker-compose -f docker-compose.test.yml up -d

cd ../EdgeItalianPizza
dotnet test --filter "FullyQualifiedName~IntegrationTests"

cd ../docker
docker-compose -f docker-compose.test.yml down
```

---

## 3. Продакшн

### Сборка образа

```bash
cd docker
docker build -f Dockerfile -t edge-italian-pizza-api ..
```

### Запуск (только API)

```bash
docker run -d \
  -p 8080:8080 \
  --name edge-pizza-api \
  -e ConnectionStrings__MongoDb="mongodb://mongodb:27017" \
  -e ConnectionStrings__Redis="redis:6379" \
  edge-italian-pizza-api
```

### Запуск (полный стек)

```bash
docker-compose -f docker-compose.prod.yml up -d
```

### Остановка

```bash
docker-compose -f docker-compose.prod.yml down
```

---

## 4. Полезные команды

### Просмотр логов

```bash
docker-compose logs -f mongodb
docker-compose logs -f api
```

### Подключение к MongoDB

```bash
mongosh "mongodb://localhost:27017"
```

### Подключение к Redis

```bash
redis-cli -h localhost -p 6379
```

### Проверка образов

```bash
docker images | grep edge-italian-pizza
```

### Очистка неиспользуемых образов

```bash
docker system prune -f
```
