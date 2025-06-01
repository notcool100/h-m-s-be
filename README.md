# Health Bridge Backend Service

**.NET Version:** .NET 7  
**License:** MIT

The backend service for **Health Bridge** healthcare platform, built with .NET 7 using **Clean Architecture** principles.

---

## 🚀 Features

- **Patient Management:** Secure patient registration and profile management
- **Appointment Booking:** Doctor appointment scheduling system
- **Diagnostic Services:** MRI, CT Scan, and lab test bookings
- **e-Pharmacy:** Online medicine ordering with delivery tracking
- **Emergency Services:** Ambulance request and tracking
- **Secure Authentication:** OTP-based login system
- **Notification System:** Email and SMS notifications
- **Payment Integration:** Support for Khalti, eSewa, and other payment gateways

---

## 📁 Project Structure

```
HealthBridge/
├── Core/               # Domain layer
│   ├── Entities/       # Business entities
│   ├── Enums/          # Enumerations
│   └── ValueObjects/   # Value objects
│
├── Application/        # Application layer
│   ├── Interfaces/     # Service contracts
│   ├── Services/       # Business logic
│   ├── DTOs/           # Data transfer objects
│   ├── Validators/     # Validation rules
│   └── Mapping/        # Object mapping profiles
│
├── Infrastructure/     # Infrastructure layer
│   ├── Data/           # Data access
│   ├── ExternalApis/   # External service integrations
│   └── Services/       # Infrastructure services
│
└── Api/                # Presentation layer
    ├── Controllers/    # API endpoints
    ├── Middleware/     # Custom middleware
    └── Program.cs      # Application entry point
```

---

## 🛠️ Getting Started

### Prerequisites

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- PostgreSQL
- Docker (optional)

---

## 🔧 Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-repo/health-bridge-backend.git
   cd health-bridge-backend
   ```

2. **Configure the application:**
   - Copy `appsettings.Example.json` to `appsettings.json`
   - Update connection strings and other service configurations

3. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

---

## ▶️ Running the Application

### Development Mode

```bash
dotnet run --project src/Api
```

> The API will be available at:  
> `https://localhost:5001`  
> `http://localhost:5000`

### Using Docker

```bash
docker-compose up --build
```

---

## 🗄️ Database Setup

Apply database migrations:

```bash
dotnet ef database update --project src/Infrastructure --startup-project src/Api
```

---

## 📚 API Documentation

Swagger UI available at:

```
https://localhost:5001/swagger
```

---

## 🔑 Key Endpoints

| Endpoint Group  | Description                    | Base Path             |
|-----------------|--------------------------------|------------------------|
| Authentication  | OTP-based authentication       | `/api/auth`           |
| Patients        | Patient management             | `/api/patients`       |
| Appointments    | Doctor appointment booking     | `/api/appointments`   |
| Diagnostics     | Test booking and results       | `/api/diagnostics`    |
| Pharmacy        | Medicine ordering              | `/api/pharmacy`       |
| Emergency       | Ambulance services             | `/api/emergency`      |
| Notifications   | Notification management        | `/api/notifications`  |

---

## ⚙️ Configuration

Edit `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=HealthBridge;Username=postgres;Password=YourStrongPassword"
  },
  "JwtSettings": {
    "Secret": "your-secure-key-here",
    "Issuer": "HealthBridge",
    "Audience": "HealthBridgeUsers",
    "ExpiryInDays": 7
  },
  "SmtpSettings": {
    "Server": "smtp.example.com",
    "Port": 587,
    "SenderEmail": "noreply@healthbridge.com"
  }
}
```

> Use `appsettings.{Environment}.json` for environment-specific configuration.

---

## 🧪 Testing

Run unit tests:

```bash
dotnet test
```

---

## 🚀 Deployment

### Docker

```bash
docker build -t health-bridge-api -f src/Api/Dockerfile .
docker run -p 5000:80 -p 5001:443 health-bridge-api
```

### Azure App Service

```bash
az webapp up --name health-bridge-api --resource-group your-resource-group --runtime "DOTNETCORE:7.0"
```

---

## ❤️ Health Check

**GET** `/health`

**Response:**

```json
{
  "status": "Healthy",
  "timestamp": "2023-06-15T12:00:00Z",
  "version": "1.0.0"
}
```

---

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin feature/your-feature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---

## 📬 Support

For support, contact **support@healthbridge.com** or open an issue in the repository.