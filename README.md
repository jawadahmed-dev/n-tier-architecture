
# N-Tier Architecture Template

Welcome to the **N-Tier Architecture Template**! This repository provides a well-structured, scalable, and maintainable solution for building applications using the n-tier architecture pattern. The template is designed as a monolithic architecture but can be adapted for various use cases, making it a great starting point for developers looking to build robust applications.

This template is free for anyone to use, modify, and extend. Whether you're a beginner learning about layered architecture or an experienced developer looking for a solid foundation, this template has you covered. Contributions are welcome—feel free to fork, star, and submit pull requests!

## Table of Contents
1. [Overview](#overview)
2. [Solution Structure](#solution-structure)
3. [Projects in Detail](#projects-in-detail)
   - [DemoApi](#demoapi)
   - [BusinessLogic](#businesslogic)
   - [DataAccess](#dataaccess)
   - [Shared](#shared)
4. [Why Use This Template?](#why-use-this-template)
5. [Getting Started](#getting-started)
6. [How to Use](#how-to-use)
7. [Contributing](#contributing)
8. [Acknowledgments](#acknowledgments)

---

## Overview

This template follows the **n-tier architecture** pattern, which separates concerns into distinct layers to promote modularity, maintainability, and scalability. The solution is structured into four main projects: `DemoApi`, `BusinessLogic`, `DataAccess`, and `Shared`. Each project has a specific role in the architecture, ensuring a clean separation of concerns.

The template is implemented as a **monolithic architecture**, meaning all layers are part of a single deployable unit. This makes it easier to develop, test, and deploy for small to medium-sized applications. However, the modular design allows you to adapt it for microservices or other architectures if needed.

---

## Solution Structure

The solution, named `DemoApi`, consists of four projects, each representing a layer or shared functionality in the n-tier architecture:

- **DemoApi**: The presentation layer (API) that exposes endpoints to interact with the application.
- **BusinessLogic**: The business logic layer that handles the core functionality and rules of the application.
- **DataAccess**: The data access layer responsible for interacting with the database.
- **Shared**: A shared library containing common utilities, configurations, and services used across all layers.

Below is a visual representation of the solution structure:

```
DemoApi.sln
├── DemoApi
│   ├── Connected Services
│   ├── Dependencies
│   ├── Properties
│   ├── wwwroot
│   ├── Controllers
│   ├── Extensions
│   ├── Filters
│   ├── Middlewares
│   ├── appsettings.json
│   ├── Program.cs
│   ├── Startup.cs
│   └── ...
├── BusinessLogic
│   ├── Dependencies
│   ├── Exceptions
│   ├── Helper
│   ├── MappingProfiles
│   ├── RequestHandlers
│   ├── BusinessLogicLayerMarker.cs
│   └── ...
├── DataAccess
│   ├── Dependencies
│   ├── Entities
│   ├── Extensions
│   ├── Identity
│   ├── Migrations
│   ├── Persistence
│   ├── DataAccessLayerMarker.cs
│   ├── UnitOfWork.cs
│   └── ...
└── Shared
    ├── Dependencies
    ├── Options
    │   ├── JwtOptions.cs
    │   ├── SwaggerOptions.cs
    │   └── ...
    ├── Services
    │   ├── ClaimService.cs
    │   └── ...
    └── ...
```

---

## Projects in Detail

### DemoApi

The `DemoApi` project serves as the **presentation layer** of the application. It is an ASP.NET Core Web API that exposes RESTful endpoints for clients to interact with the application.

#### Key Features:
- **Controllers**: Contains the API controllers that handle HTTP requests and responses.
- **Extensions**: Includes extension methods for configuring services, middleware, and other components.
- **Filters**: Custom filters for handling cross-cutting concerns like validation and error handling.
- **Middlewares**: Custom middleware for request processing (e.g., logging, authentication).
- **Configuration**: Uses `appsettings.json` for configuration and `Startup.cs`/`Program.cs` for application setup.
- **wwwroot**: Static files (if any) for serving directly to clients.

#### Purpose:
This layer acts as the entry point for all client requests. It delegates business logic to the `BusinessLogic` layer and relies on dependency injection to interact with other layers.

---

### BusinessLogic

The `BusinessLogic` project is the **business logic layer**, responsible for implementing the core functionality and rules of the application.

#### Key Features:
- **Exceptions**: Custom exceptions for handling business-specific errors.
- **Helper**: Utility classes for common operations.
- **MappingProfiles**: AutoMapper profiles for mapping between DTOs and entities.
- **RequestHandlers**: Classes that handle specific business requests (e.g., using MediatR for CQRS).
- **BusinessLogicLayerMarker.cs**: A marker class for dependency injection configuration.

#### Purpose:
This layer contains the application's business rules and logic. It acts as an intermediary between the `DemoApi` and `DataAccess` layers, ensuring that business rules are enforced before data is persisted or retrieved.

---

### DataAccess

The `DataAccess` project is the **data access layer**, responsible for interacting with the database and managing data persistence.

#### Key Features:
- **Entities**: Defines the database entities (e.g., using Entity Framework Core).
- **Extensions**: Extension methods for configuring the data access layer.
- **Identity**: Custom identity-related classes (e.g., for authentication/authorization).
- **Migrations**: Database migrations for schema updates (if using EF Core).
- **Persistence**: Configuration for database context and repositories.
- **UnitOfWork.cs**: Implements the Unit of Work pattern to manage database transactions.
- **DataAccessLayerMarker.cs**: A marker class for dependency injection configuration.

#### Purpose:
This layer abstracts database operations, ensuring that the `BusinessLogic` layer does not directly interact with the database. It uses the Repository and Unit of Work patterns to provide a clean and maintainable way to handle data.

---

### Shared

The `Shared` project is a **shared library** that contains common utilities, configurations, and services used across all layers.

#### Key Features:
- **Options**: Configuration classes like `JwtOptions.cs` for JWT settings and `SwaggerOptions.cs` for Swagger configuration.
- **Services**: Shared services like `ClaimService.cs` for handling user claims (e.g., in authentication).
- **Dependencies**: References to shared dependencies used across projects.

#### Purpose:
This layer promotes code reuse by providing common functionality that can be used by all other layers. It helps reduce duplication and ensures consistency across the application.

---

## Why Use This Template?

- **Clean Separation of Concerns**: Each layer has a specific responsibility, making the codebase easier to understand and maintain.
- **Scalability**: The modular design allows you to scale the application by splitting layers into separate services if needed.
- **Monolithic Architecture**: Ideal for small to medium-sized applications where a single deployable unit is preferred.
- **Extensibility**: Easily add new features by extending the existing layers.
- **Best Practices**: Incorporates patterns like Repository, Unit of Work, CQRS (via RequestHandlers), and Dependency Injection.
- **Ready-to-Use**: Includes common utilities like JWT authentication, Swagger configuration, and AutoMapper for mapping.

---

## Getting Started

### Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [Visual Studio](https://visualstudio.microsoft.com/) or any IDE that supports .NET (e.g., VS Code)
- A database (e.g., SQL Server, PostgreSQL) if using Entity Framework Core
- [Git](https://git-scm.com/) for cloning the repository

### Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/n-tier-architecture-template.git
   ```
2. Navigate to the project directory:
   ```bash
   cd n-tier-architecture-template
   ```
3. Restore the dependencies:
   ```bash
   dotnet restore
   ```
4. Update the `appsettings.json` file in the `DemoApi` project with your database connection string and other configurations (e.g., JWT settings).
5. Run database migrations (if using EF Core):
   ```bash
   dotnet ef migrations add InitialCreate --project DataAccess
   dotnet ef database update --project DataAccess
   ```
6. Build and run the solution:
   ```bash
   dotnet build
   dotnet run --project DemoApi
   ```

---

## How to Use

1. **Explore the API**: Once the application is running, navigate to `https://localhost:5001/swagger` (or the port specified in your configuration) to view the Swagger UI and test the API endpoints.
2. **Add New Features**:
   - Add new controllers in the `DemoApi` project for new endpoints.
   - Implement business logic in the `BusinessLogic` project.
   - Update the `DataAccess` project with new entities and repositories as needed.
   - Reuse shared utilities from the `Shared` project.
3. **Customize Configurations**: Modify `JwtOptions.cs`, `SwaggerOptions.cs`, and other settings in the `Shared` project to suit your needs.
4. **Extend the Template**: Add new layers or split the monolith into microservices if your application grows.

---

## Contributing

Anyone is welcome to contribute to this project! To contribute, simply follow these steps:

1. Fork the repository to your GitHub account.
2. Clone your forked repository to your local machine:
   ```bash
   git clone https://github.com/your-username/n-tier-architecture-template.git
   ```
3. Create a new branch for your changes using the `feature-` prefix (e.g., `feature-add-user-auth`):
   ```bash
   git checkout -b feature-<your-feature-name>
   ```
4. Make your changes and test them locally to ensure they work as expected.
5. Commit your changes with a clear and descriptive commit message:
   ```bash
   git commit -m "Add feature: <brief description of your changes>"
   ```
6. Push your branch to your forked repository:
   ```bash
   git push origin feature-<your-feature-name>
   ```
7. Open a pull request (PR) from your branch to the `main` branch of this repository. In your PR description, explain:
   - What changes you made.
   - Why these changes are useful.
   - Any additional context (e.g., if your changes fix a specific issue).

We’ll review your pull request as soon as possible. Thank you for contributing!

---

## Acknowledgments

- Built with ❤️ using [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet).
- Inspired by best practices in n-tier architecture and clean code principles.

---

Feel free to star ⭐ this repository if you find it useful! If you have any questions or need assistance, open an issue, and I'll be happy to help.

---
