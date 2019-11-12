## Example working CQRS and Sub/Pub with MediatR

### Requirements:

- Have experienced with Entity Framework Core - Code First.
- Have experienced with ASP.NET Core and Rest API
- Optional: Have experienced with Docker
  
### Instructions:

- Setup a MS SQL Server for running database
- Start up project with Customer.API project

### Structures:

- Customer.API: API Layer
- Customer.Data: Data Layer
- Customer.Domain: Models Layer
- Customer.Service: Application Layer

### Run MSSQL Docker:

```
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Demo123456@' -p 1433:1433 -d mcr.microsoft.com/mssql/server:2017-latest
```

### Run DB Migrations:

```
dotnet ef database update
```

### Run application and test with Swagger:

```
dotnet run
```

- Access to: localhost:5000 or localhost:5001 with path: /swagger

### Run with docker-compose
- Requirement:
  - Installed docker and docker-compose
  
```
docker-compose build
docker-compose up
```

### Turn off auto migrate
- Please comment this line in `Startup.cs`

```
app.UseAutoMigrateDatabase<CustomerDbContext>();
```
