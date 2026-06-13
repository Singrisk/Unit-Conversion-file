# Unit Conversion API

## Overview

Unit Conversion API is a RESTful ASP.NET Core Web API that converts numerical values between different units of measurement.

Currently supported conversion categories:

* Length

  * Meter
  * Kilometer
  * Foot
  * Inch

* Weight / Mass

  * Kilogram
  * Gram
  * Pound

* Temperature

  * Celsius
  * Fahrenheit
  * Kelvin

The solution is designed with extensibility in mind, making it easy to add additional unit categories and conversion types in the future.

---

## Technology Stack

* ASP.NET Core Web API
* .NET 9 (or latest stable version)
* Swagger / OpenAPI
* Dependency Injection
* xUnit (for unit testing)

---

## Project Structure

```text
UnitConversion.Api
│
├── Controllers
├── Models
├── Services
├── Properties
├── Program.cs
├── appsettings.json
└── UnitConversion.Api.csproj
```

---

## Running the Application

### Prerequisites

* .NET SDK 9.0 or later

Verify installation:

```bash
dotnet --version
```

### Clone Repository

```bash
git clone <repository-url>
```

### Navigate to Project

```bash
cd UnitConversion.Api
```

### Restore Dependencies

```bash
dotnet restore
```

### Build the Project

```bash
dotnet build
```

### Run the Application

```bash
dotnet run
```

The API will start and display URLs similar to:

```text
https://localhost:7xxx
http://localhost:5xxx
```

---

## Swagger Documentation

Once the application is running, open:

```text
https://localhost:<port>/swagger
```

Swagger UI provides interactive API documentation and allows testing endpoints directly from the browser.

---

## API Endpoints

### Convert Units

**POST** `/api/conversions`

#### Request

```json
{
  "value": 100,
  "fromUnit": "meter",
  "toUnit": "foot"
}
```

#### Response

```json
{
  "originalValue": 100,
  "fromUnit": "meter",
  "toUnit": "foot",
  "convertedValue": 328.08399
}
```

---

### Get Supported Units

**GET** `/api/conversions/units`

#### Response

```json
{
  "length": [
    "meter",
    "kilometer",
    "foot",
    "inch"
  ],
  "weight": [
    "kilogram",
    "gram",
    "pound"
  ],
  "temperature": [
    "celsius",
    "fahrenheit",
    "kelvin"
  ]
}
```

---

## Design Decisions

### Strategy-Based Conversion Design

Each conversion category is implemented through a dedicated converter class that implements a common interface. This approach improves maintainability and allows new conversion categories to be added without modifying existing code.

### Base Unit Conversion

Length and weight conversions are normalized through a base unit before converting to the target unit. This reduces complexity and simplifies future expansion.

### Temperature Conversion

Temperature conversion uses dedicated formulas because temperature scales cannot be converted using simple multiplication factors.

### Dependency Injection

Converters and services are registered using ASP.NET Core Dependency Injection to improve testability and maintainability.

---

## Future Improvements

Potential enhancements for a production environment include:

* Database-driven unit management
* Caching for frequently used conversions
* FluentValidation for request validation
* Global exception handling middleware
* Docker support
* CI/CD pipeline using GitHub Actions
* Additional conversion categories such as:

  * Volume
  * Area
  * Speed
  * Time
  * Pressure

---

## Testing

Run tests using:

```bash
dotnet test
```

---

## Author

Rahul Ranjan Singh
