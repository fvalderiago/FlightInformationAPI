# Flight Information API

A simple RESTful API for managing flight information. This project uses ASP.NET Core 8.0 with an in-memory repository for testing purposes and supports full CRUD operations, search, and validation.

---

## Features

- **Get all flights**: `GET /api/flights`
- **Get flight by ID**: `GET /api/flights/{id}`
- **Create a new flight**: `POST /api/flights`
- **Update a flight**: `PUT /api/flights/{id}`
- **Delete a flight**: `DELETE /api/flights/{id}`
- **Search flights**: `GET /api/flights/search?airline=&departureAirport=&arrivalAirport=&from=&to=&status=`

### Flight Model

```json
{
  "id": 1,
  "flightNumber": "NZ200",
  "airline": "Air New Zealand",
  "departureAirport": "AKL",
  "arrivalAirport": "WLG",
  "departureTime": "2025-06-24T23:00:00",
  "arrivalTime": "2025-06-25T11:00:00",
  "status": "Scheduled"
}
status is an enum with values: Scheduled, Delayed, Cancelled, Departed, Arrived.

Getting Started
Prerequisites
.NET 8.0 SDK

Visual Studio 2022+ or VS Code

Setup & Run
Clone the repository:

bash
Copy code
git clone https://github.com/yourusername/FlightInformationAPI.git
cd FlightInformationAPI
Restore dependencies:

bash
Copy code
dotnet restore
Run the API:

bash
Copy code
dotnet run --project FlightInformationAPI
Navigate to Swagger UI to test endpoints:

bash
Copy code
https://localhost:5001/swagger/index.html
Running Tests
The project uses xUnit for unit testing and an in-memory repository for isolation.

bash
Copy code
dotnet test
You should see all tests passing for the controller and service layers.

Notes
In-memory repository is used for demonstration and testing. For production, replace it with EF Core + SQL Server or another database.

Validation is implemented using Data Annotations.

Logging is implemented via ILogger.

Search endpoint supports filtering by airline, departure airport, arrival airport, date range, and status.