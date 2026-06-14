# 🚀 Advanced Unit Conversion API

A production-ready, extensible ASP.NET Core Web API built with **.NET 10** that enables conversion between multiple measurement units across different categories such as **Length**, **Weight**, and **Temperature**.

The application is designed using industry-standard design patterns and clean architecture principles, making it highly scalable, maintainable, and easy to extend with new conversion categories.

---

## 📌 Features

### ✅ Multiple Conversion Categories

Supports conversion between units in:

* Length
* Weight
* Temperature

### ✅ Extensible Architecture

Built using the **Strategy Pattern** and **Factory Pattern**, allowing new conversion categories to be added without modifying existing business logic.

### ✅ Strong Validation

Validates:

* Invalid units
* Unsupported categories
* Cross-category conversions
* Empty or malformed requests

### ✅ Global Exception Handling

Centralized exception middleware provides:

* Consistent error responses
* Proper HTTP status codes
* Clean API contracts

### ✅ Optimized Identity Conversions

Automatically returns the original value when source and target units are identical.

### ✅ Clean API Responses

Standardized JSON responses for both success and failure scenarios.

---

# 🏗️ Architecture Overview

The application follows a layered architecture:

```text
Client Request
      │
      ▼
Controller
      │
      ▼
Conversion Service
      │
      ▼
Unit Converter Factory
      │
      ▼
Concrete Converter Strategy
      │
      ▼
Response
```

---

## Design Patterns Used

### Strategy Pattern

Each conversion category implements a common contract:

```csharp
public interface IUnitConverter
{
    double Convert(double value, string fromUnit, string toUnit);
}
```

Implementations:

* LengthConverter
* WeightConverter
* TemperatureConverter

Each converter encapsulates its own conversion rules and business logic.

---

### Factory Pattern

The factory resolves the appropriate conversion strategy at runtime.

```csharp
public interface IUnitConverterFactory
{
    IUnitConverter GetConverter(ConversionCategory category);
}
```

Benefits:

* Loose coupling
* Easy extensibility
* Better maintainability

---

### Middleware Pattern

A custom exception middleware handles all application-level exceptions and returns standardized API responses.

Benefits:

* No repetitive try-catch blocks
* Centralized error handling
* Consistent response structure

---

# 📂 Project Structure

```text
UnitConversionApi
│
├── Controllers
│   └── ConversionController.cs
│
├── DTOs
│   ├── ConvertRequest.cs
│   └── ConvertResponse.cs
│
├── Middleware
│   └── ExceptionMiddleware.cs
│
├── Models
│   ├── ConversionCategory.cs
│   └── ApiErrorResponse.cs
│
├── Services
│   │
│   ├── Interfaces
│   │   ├── IUnitConverter.cs
│   │   └── IUnitConverterFactory.cs
│   │
│   ├── Converters
│   │   ├── LengthConverter.cs
│   │   ├── WeightConverter.cs
│   │   └── TemperatureConverter.cs
│   │
│   ├── Factory
│   │   └── UnitConverterFactory.cs
│   │
│   └── ConversionService.cs
│
├── Program.cs
└── README.md
```

---

# ⚙️ Technologies Used

* ASP.NET Core Web API
* .NET 10
* Dependency Injection
* Middleware Pipeline
* OpenAPI
* C#
* RESTful API Principles

---

# 🚀 Getting Started

## Prerequisites

Install:

* .NET 10 SDK

Verify installation:

```bash
dotnet --version
```

---

## Clone Repository

```bash
git clone https://github.com/patilpa30/UnitConversionApi.git
cd UnitConversionApi
```

---

## Restore Packages

```bash
dotnet restore
```

---

## Build Project

```bash
dotnet build
```

---

## Run Application

```bash
dotnet run
```

The API will start locally and listen on:

```text
http://localhost:5000
```

or

```text
https://localhost:5001
```

depending on your launch profile.

---

# 📬 API Endpoints

## Convert Units

### POST

```http
/api/conversion
```

---

## Request Example

```json
{
  "category": "Length",
  "fromUnit": "meter",
  "toUnit": "inch",
  "value": 10
}
```

---

## Success Response

**200 OK**

```json
{
  "result": 393.7008
}
```

---

## Invalid Request Example

```json
{
  "category": "Length",
  "fromUnit": "celsius",
  "toUnit": "km",
  "value": 10
}
```

---

## Error Response

**400 Bad Request**

```json
{
  "success": false,
  "message": "Invalid unit 'celsius' for Length category.",
  "statusCode": 400,
  "timestamp": "2026-06-14T08:45:10.1234567Z"
}
```

---

# 🧪 Supported Units

### Length

* mm
* cm
* m
* meter
* km
* inch
* foot
* yard
* mile

### Weight

* mg
* g
* kg
* ounce
* pound

### Temperature

* celsius
* fahrenheit
* kelvin

---

# 📈 Future Enhancements

* Area conversion
* Volume conversion
* Time conversion
* Currency conversion
* Database-driven conversion factors
* Caching support
* API versioning
* Unit testing with xUnit
* CI/CD pipeline integration
* Docker containerization

---

# 🎯 Key Engineering Principles

* SOLID Principles
* Open/Closed Principle (OCP)
* Dependency Injection
* Separation of Concerns
* Clean Code Practices
* Maintainable Architecture

---

# 👨‍💻 Author

**Priti Patil**

GitHub: https://github.com/patilpa30

---
