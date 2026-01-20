## Рефакторинг системы аутентификации и авторизации

## Технологический стек
- .NET 9.0
- ASP.NET Core Web API
- Entity Framework Core 9.0
- PostgreSQL
- MediatR (CQRS)
- AutoMapper
- JWT Authentication
- ASP.NET Core Identity


## Архитектура проекта

### Текущая структура слоев:
- Api - Presentation слой (контроллеры, middleware)
- Application - Application слой (CQRS handlers, DTOs, бизнес-логика)
- Domain - Domain слой (сущности, value objects, доменные исключения)
- Infrastructure - Infrastructure слой (DbContext, миграции, конфигурации EF)
- Shared - Общие интерфейсы CQRS

## API Endpoints

### Topics
- `GET /api/topics` - Получить все топики
- `GET /api/topics/{id}` - Получить топик по ID
- `POST /api/topics` - Создать топик
- `PUT /api/topics/{id}` - Обновить топик
- `DELETE /api/topics/{id}` - Удалить топик (soft delete)

### Authentication
- `POST /api/auth/login` - Авторизация
- `POST /api/auth/register` - Регистрация

### AspNetUsers
- Стандартные таблицы ASP.NET Core Identity

### Безопасность
- JWT токены с коротким временем жизни (10 минут)
- HMAC SHA512 подпись
- CORS настроен для React приложения на localhost:3000
- Все endpoints защищены аутентификацией (кроме /api/auth/*)