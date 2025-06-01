# Health Bridge Backend

This is the backend service for the Health Bridge healthcare platform, implemented using .NET with a Clean Architecture approach.

## Project Structure

- **Core**: Contains the domain entities.
- **Application**: Contains service interfaces and implementations.
  - `Interface/`: Contains service interface definitions (e.g., `IPatientService.cs`, `IAppointmentService.cs`).
  - `Services/`: Contains service implementations (e.g., `PatientService.cs`, `AppointmentService.cs`).
- **Infrastructure**: Contains data access implementations.
  - `Interfaces/`: Contains repository interface definitions (e.g., `IPatientRepository.cs`, `IAppointmentRepository.cs`).
  - `Repositories/`: Contains repository implementations (e.g., `PatientRepository.cs`, `AppointmentRepository.cs`).
- **Api**: The Web API project exposing endpoints and controllers.

## Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)

### Setup

1. Navigate to the `backend` directory.
2. Restore dependencies and build the project:

```bash
dotnet restore
dotnet build
```

### Running the API

Run the API locally with:

```bash
dotnet run --project src/Api
```

The API will start and listen on the configured ports.

### Health Check Endpoint

A sample health check endpoint is available at:

```
GET /HealthCheck
```

It returns a simple status message confirming the API is running.

## Contributing

Contributions are welcome! Please open issues or submit pull requests.

## License

This project is licensed under the MIT License.
