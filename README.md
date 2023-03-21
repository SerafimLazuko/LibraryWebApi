# LibraryWebApi
***
 Структура:
1. **Library.API** - Web API проект, контроллеры для функциональности библиотеки и пользователей
2. **Library.BLL** – библиотека бизнес логики, содержит сервисы для обращения к слою доступа к данным, DTO объекты, правила для маппинга и валидации AutoMapper
3. **Library.DAL** – библиотека слой доступа к данным, содержит репозиторий, сервис для обращения к репозиторию, модели и контекст библиотеки (книги и аренда книг). Бд MSSQL Server
4. **Library.User.DAL** – слой доступа к данным пользователей, модели, контекст, репозиторий и сервис для обращения к репозиторию. Postgresql используется в качестве бд.
 
 Технологии:
1. ORM – EF core
2. БД библиотеки – MSSQL Server, Fluent API
3. БД users – Postgresql
4. маппинг – AutoMapper, FluentValidation
5. UI – SwaggerGen
6. Auth – bearer token

***
Для обращения к API необходимо получить ***токен*** – залогиниться под существующей учеткой пользователя (добавляется автоматически при создании бд):

![image](https://user-images.githubusercontent.com/32098170/226669011-5615fcb3-a5d9-4cdc-bc58-baafdd35e13e.png)

    <{
  "password": "secret",
  "login": "SamKing"
    }>