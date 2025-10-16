# Solution Structure

This document outlines the folder and project structure for the Airline Reservation System using WinForms, ASP.NET MVC, and Entity Framework following a layered architecture.

## Projects Overview

```
src/
├── AirlineReservation.Domain/
│   ├── Entities/
│   └── ValueObjects/
├── AirlineReservation.Application/
│   ├── Interfaces/
│   ├── Services/
│   └── DTOs/
├── AirlineReservation.Infrastructure/
│   ├── Persistence/
│   │   ├── Configurations/
│   │   └── Context.cs
│   ├── Migrations/
│   ├── Repositories/
│   └── ApiClients/
├── AirlineReservation.Shared/
│   ├── Constants/
│   └── Helpers/
├── AirlineReservation.WinForms/
│   ├── Controllers/
│   ├── ViewModels/
│   └── Views/
├── AirlineReservation.Web/ (ASP.NET MVC)
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   └── wwwroot/
└── AirlineReservation.Api/ (ASP.NET Web API)
    ├── Controllers/
    ├── DTOs/
    ├── Profiles/
    └── BackgroundJobs/
```

## Layer Responsibilities

- **Domain**: Contains core business entities, value objects, and enums that represent the airline reservation domain. No dependencies on other layers.
- **Application**: Implements use cases, service interfaces, and DTOs for communication between layers. Depends only on the Domain layer.
- **Infrastructure**: Hosts Entity Framework DbContext, migrations, repository implementations, and external API clients (e.g., real flight information providers). Depends on both Domain and Application layers.
- **Shared**: Provides cross-cutting helpers, constants, and utility classes shared across multiple projects.
- **WinForms**: Desktop client following MVC pattern with controllers mediating between views and view models, consuming Application layer services.
- **Web**: ASP.NET MVC site for customer and admin portals, integrating with the Application layer for business logic and Infrastructure for persistence.
- **Api**: ASP.NET Web API project exposing endpoints for mobile apps, third-party integration, and background synchronization tasks (flight schedule updates, baggage services, etc.).

## Supporting Directories

- `tests/` contains two projects (`AirlineReservation.Tests.Unit` and `AirlineReservation.Tests.Integration`) to verify business logic and infrastructure integration.
- `docs/database/` stores SQL scripts and schema diagrams, including the provided database definition for reference.

## Next Steps

1. Initialize a `.sln` solution file and add each project using `dotnet new` templates (`classlib`, `winforms`, `mvc`, `webapi`).
2. Configure Entity Framework Core in `Infrastructure/Persistence`, including DbContext and migrations.
3. Implement dependency injection in the Web and API projects to wire Application services and Infrastructure repositories.
4. Build UI flows described in the business processes (booking, payment, post-booking staff actions, admin console).
5. Implement scheduled jobs or background services to synchronize real-world flight data via the `ApiClients` layer.
