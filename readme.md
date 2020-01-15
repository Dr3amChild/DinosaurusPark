## Описание
Небольшой демонстрационный проект. Ничего серьёзного, просто маленький уютный парк Юрского периода с динозаврами

## Основные используемые технологии
 - .NET Core 3.1
 - ASP.NET Core
 - Docker + Docker-compose
 - PostgreSQL
 
### Основные используемые библиотеки
 - Entity Framework Core 
 - ReactJS
 - Bogus
 - Automapper
 - Polly
 - Serilog
 - Refit 
 - NUnit
 - Moq
 - StyleCop
 
## Запуск приложения из консоли
  1. cd %solution folder%
  2. docker-compose up --build
  3. дождаться запуска контейнера
  4. открыть браузер по адресу localhost:5005
  
## Запуск юнит-тестов
 1. cd %solution folder%/tests/DinosaursPark.UnitTests
 2. dotnet test
  
## Запуск интеграционных тестов
  1. cd %solution folder%/tests/DinosaursPark.IntegrationTests
  2. docker-compose up --build
  3. дождаться запуска контейнеров и выполнения тестов  
 