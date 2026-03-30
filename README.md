# Library API

ASP.NET Core Web API для управления библиотекой. Позволяет работать с книгами и отзывами.

## Технологии

- .NET 9.0
- ASP.NET Core
- FluentValidation
- OpenAPI (Swagger)

## Структура проекта

- **Controllers/** - API контроллеры
- **Models/** - Модели данных
- **Dtos/** - Data Transfer Objects для запросов/ответов
- **Services/** - Бизнес-логика
- **Data/** - Работа с данными
- **Validation/** - Валидаторы FluentValidation
- **Mapping/** - Маппинг между моделями

## Запуск

```bash
dotnet run
```

API будет доступна по адресу `https://localhost:5001`

## OpenAPI (Swagger)

При запуске в режиме Development, Swagger документация доступна по адресу `/openapi/v1.json`
