# E-Commerce API 🛍️

> ⚠️ **Note**: This project is currently under development and not complete.

## Overview 🎯

This is a Domain-Driven Design (DDD) and CQRS-based E-Commerce API built with .NET 9. The project follows clean architecture principles and implements modern design patterns for building scalable and maintainable e-commerce solutions.

## Architecture 🏗️

- **Domain-Driven Design (DDD)**: Organized around business domains and complex business logic
- **CQRS Pattern**: Separates read and write operations for better scalability
- **Event-Driven**: Uses domain events for loose coupling between components
- **Clean Architecture**: Follows onion architecture principles with clear separation of concerns

## Project Structure 📁

- `ECM.Domain`: Core business logic and entities
- `ECM.Application`: Application services, commands, and queries
- `ECM.Infrastructure`: Data persistence, external services integration
- `ECM.Api`: REST API endpoints and controllers
- `ECM.SharedKernel`: Shared components and base classes
- `ECM.Tests`: Unit and integration tests

## Key Features ✨

- Clean Architecture implementation
- CQRS with MediatR
- Domain Events handling
- Atomic event processing
- Entity Framework Core for persistence
- FluentValidation for request validation
- Docker support

## Event Handling 🔄

The system implements an event-driven architecture where:
- Domain events are dispatched atomically with database transactions
- Events are processed in-memory for consistency
- Each aggregate root can raise domain events
- Event handlers are automatically discovered and registered

## Dependencies 📦

- `.NET 9`
- `Entity Framework Core`
- `MediatR` for CQRS implementation
- `FluentValidation`
- `PostgreSQL`
- `Docker` for containerization

## Getting Started 🚀

1. Clone the repository
2. Install required tools:
   ```bash
   make install-tools  # Installs dotnet-ef and other required tools
   ```
3. Make sure you have Docker installed
4. Run:
   ```bash
   make docker-up        # Starts the Docker containers
   make update-database  # Applies database migrations
   ```

## Development 👩‍💻

```bash
make run           # Runs the API
make build         # Builds the solution
make clean         # Cleans build artifacts
make docker-logs   # View Docker container logs
make docker-down   # Stop Docker containers

# Database Commands
make add-migration MIGRATION_NAME=YourMigrationName  # Add new migration
make remove-migration                                # Remove last migration
make update-database                                # Update database to latest migration
```

## API Documentation 📚

Once running, access the Swagger documentation at:
```
http://localhost:5000/api-docs
```

The API documentation is available in the following formats:
- Interactive UI: `/api-docs`
- OpenAPI JSON: `/api-docs/v1/swagger.json`
